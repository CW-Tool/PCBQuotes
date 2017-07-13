using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace PCBQuotes.Helpers
{
    public class VirtualGridDataHelper
    {
        private static readonly object obj = new object();//用于线程锁对象
        //private static SynchronizationContext syncContext = SynchronizationContext.Current;//线程中更新UI模型传播上下文


        /// <summary>
        /// 设置virtualgrid 数据 并设置  CellValueNeeded
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="d"></param>
        /// <param name="syncContext"></param>
        public static void InitalLoad<T>(VirtualGridData<T> d, SynchronizationContext syncContext) where T:new()
        {
            var grid = d.Grid;
            grid.RowCount = 0;
            grid.ColumnCount = ModelHelper.GetColumnDisplayNames(typeof(T)).Count();

            //设置Column宽度
            grid.TableElement.ColumnsViewState.SetItemSize(0,30);

            grid.ColumnWidthChanging += (s, e) => {
                //ID列为命令按钮，固定大小，不允许resize
                int idIndex = Array.IndexOf(ModelHelper.GetColumnNames(typeof(T)), "ID");
                if (e.ColumnIndex==idIndex)
                {
                    e.Cancel = true;
                }
            };

            grid.CreateCellElement += (s, e) => {
                //ID列约定为命令按钮
                int idIndex = Array.IndexOf(ModelHelper.GetColumnNames(typeof(T)), "ID");
                if (e.RowIndex>=0 && e.ColumnIndex == idIndex)
                {
                    e.CellElement = new Helpers.VirtualGridEditCommandCellElement(); 
                }
                
            };
            grid.CellFormatting += (s, e) => {
                //ID列约定为命令按钮
                int idIndex = Array.IndexOf(ModelHelper.GetColumnNames(typeof(T)), "ID");
                if (e.CellElement.RowIndex == -3 && e.CellElement.ColumnIndex == idIndex)
                {
                    e.CellElement.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                }
                if (e.CellElement.RowIndex == -1 && e.CellElement.ColumnIndex == idIndex)
                {
                    e.CellElement.Visibility= Telerik.WinControls.ElementVisibility.Hidden;
                }
            };
            

            grid.CellValueNeeded += (s, e) => {
                if (e.ColumnIndex < 0 || d.Data == null) //|| data == null
                    return;

                if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
                {
                    e.Value = Helpers.ModelHelper.GetColumnDisplayNames(typeof(T))[e.ColumnIndex];
                }

                if (e.RowIndex < 0)
                {
                    e.FieldName = ModelHelper.GetColumnNames(typeof(T))[e.ColumnIndex];
                }

                if (e.RowIndex == e.ViewInfo.RowCount - 1 && e.ViewInfo.RowCount < d.Data.Count)
                {
                    e.Value = null;
                    e.ViewInfo.StartRowWaiting(e.RowIndex);
                    LazyLoad<T>(d,syncContext);
                    //if (!this.lazyLoader.IsBusy)
                    //{
                    //    this.lazyLoader.RunWorkerAsync();
                    //}
                }
                else if (e.RowIndex >= 0)
                {
                    e.Value = ModelHelper.GetValueByPropertyName<T>(d.Data[e.RowIndex], ModelHelper.GetColumnNames(typeof(T))[e.ColumnIndex]);
                }
            };

            if (!grid.MasterViewInfo.IsWaiting)
            {
                grid.MasterViewInfo.IsWaiting = true;
            }
            Task.Factory.StartNew(()=> {
                using (BLL.GeneralBll bll = new BLL.GeneralBll())
                {
                    lock (obj)
                    {
                        var count = bll.CountTable<T>(grid.FilterDescriptors.Expression);
                        d.Data = new List<T>(count);
                        for (int i = 0; i < count; i++)
                        {
                            d.Data.Add(new T());
                        }
                        var initData = bll.Select<T>(grid.SortDescriptors.Expression, grid.FilterDescriptors.Expression, 1, d.PerLoadSize);
                        d.LoadedCount = initData.Count();
                        for (int i = 0; i < initData.Count; i++)
                        {
                            d.Data[i] = initData[i];
                        }
                    }
                    
                    
                }
                syncContext.Post((state) => {
                    //dynamic d = state;
                    //var grid = da.Grid as RadVirtualGrid;
                    if (grid.IsDisposed)
                    {
                        return;
                    }
                    grid.RowCount = Math.Min(d.LoadedCount + 1, d.Data.Count);
                    if (grid.MasterViewInfo.IsWaiting)
                    {
                        grid.MasterViewInfo.IsWaiting = false;
                    }
                }, d);
            });
        }

        public static void LazyLoad<T>(VirtualGridData<T> d, SynchronizationContext syncContext) where T : new()
        {
            Task.Factory.StartNew(()=> {
                using (BLL.GeneralBll bll = new BLL.GeneralBll())
                {
                    lock (obj)
                    {
                        int endIndex = Math.Min(d.LoadedCount + d.PerLoadSize, d.Data.Count);
                        var lazyData = bll.Select<T>(d.Grid.SortDescriptors.Expression, d.Grid.FilterDescriptors.Expression, d.LoadedCount + 1, endIndex);//bll.Read().OrderByDescending(x => x.ID).Skip(this.loadedRowCount).Take(endIndex - this.loadedRowCount).ToList();
                        for (int i = d.LoadedCount; i < endIndex; i++)
                        {
                            d.Data[i] = lazyData[i - d.LoadedCount];
                        }
                        d.LoadedCount = endIndex;
                    }
                }
                syncContext.Post((state)=> {
                    //dynamic da = state;
                    //var grid = da.Grid as RadVirtualGrid;
                    var grid = d.Grid;
                    if (grid.IsDisposed)
                    {
                        return;
                    }
                    int waitingRow = grid.RowCount - 1;
                    grid.RowCount = Math.Min(d.LoadedCount + 1, d.Data.Count);
                    grid.MasterViewInfo.StopRowWaiting(waitingRow);
                },d);
            });
        }
    }
    public class VirtualGridData<T>
    {
        public RadVirtualGrid Grid { get; set; }
        public List<T> Data { get; set; }
        //public int Count { get; set; }
        public int LoadedCount { get; set; }
        public int PerLoadSize { get; set; }
    }
}
