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
        private static SynchronizationContext syncContext = SynchronizationContext.Current;//线程中更新UI模型传播上下文

        public static void InitalLoad<T>(VirtualGridData<T> d) where T:new()
        {
            var grid = d.Grid;
            if (!grid.MasterViewInfo.IsWaiting)
            {
                grid.MasterViewInfo.IsWaiting = true;
            }
            Task.Factory.StartNew(()=> {
                using (BLL.GeneralBll bll = new BLL.GeneralBll())
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
                    syncContext.Post((state)=> {

                    },d);
                }
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
