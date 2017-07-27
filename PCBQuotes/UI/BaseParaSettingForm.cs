using PCBQuotes.Helpers;
using PCBQuotes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Linq;

namespace PCBQuotes.UI
{
    public partial class BaseParaSettingForm : Telerik.WinControls.UI.RadForm
    {
        private readonly object obj = new object();//用于线程锁对象
        private SynchronizationContext syncContext = SynchronizationContext.Current;//线程中更新UI模型传播上下文
        private BLL.GeneralBll bll = new BLL.GeneralBll();
        private Enums.EditFormMode EditMode;
        private BasLayer OriLayer;
        //private bool isUpdate = false;
        //private ObservableCollection<BasLayer> layerData = new ObservableCollection<BasLayer>();
        public BaseParaSettingForm()
        {
            InitializeComponent();
            this.Text = "基础参数设置";
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
             
            this.pvSetting.SelectedPageChanged += (s, e) => {
                var p = this.pvSetting.SelectedPage;
                
            };
            InitLayerDataEntry();
            InitLayerGridView();
            LoadLayerData();
            //取消按钮事件
            this.btnLayerCancel.Click += (s, e) => {
                 
                if (EditMode == Enums.EditFormMode.Add)
                {
                    this.deLayer.DataSource = new BasLayer();
                    
                }
                else if (EditMode == Enums.EditFormMode.Edit)
                {
                    this.deLayer.DataSource = OriLayer;
                    var cur = this.gvLayer.CurrentRow.DataBoundItem as BasLayer;
                    ObjectHelper.CopyAllField(OriLayer, cur);
                    //this.deLayer.DataSource = OriginalLayer ;
                }
            };
            //加载按钮事件
            this.btnReLoad.Click += (s, e) => { LoadLayerData(); };
            //新增按钮事件
            this.btnLayerAdd.Click += (s, e) => {
                EditMode = Enums.EditFormMode.Add;
                this.deLayer.DataSource = new BasLayer();
                 
            };
            //删除按钮事件
            this.btnLayerDelete.Click += (s, e) => {
                if (RadMessageBox.Show(this,"确认删除？","",MessageBoxButtons.YesNo,RadMessageIcon.Question)== DialogResult.Yes)
                {
                    this.btnLayerDelete.Enabled = false;  
                    Task.Factory.StartNew<BasLayer>(()=> {
                        var cur = this.gvLayer.CurrentRow.DataBoundItem as BasLayer;
                        if (bll.Delete<BasLayer>(cur.Id) > 0)
                        {
                            return cur;
                        }
                        else
                        {
                            return null;
                        }
                        
                    }).ContinueWith(t=> {
                        if (!t.IsFaulted && t.Result!=null)
                        {
                            syncContext.Post((state)=> {
                                this.gvLayer.BeginUpdate();
                                var layerData = this.gvLayer.DataSource as ObservableCollection<BasLayer>;
                                layerData.Remove(t.Result);
                                this.gvLayer.EndUpdate();
                            },"");
                        }
                        syncContext.Post((state) => {
                            this.btnLayerDelete.Enabled = true;
                        }, "");
                    });
                }
            };
            //保存按钮事件
            this.btnLayerSave.Click += (s, e) => { 
                var t = ValidationHelper.hasValidationErrors(this.deLayer.Controls);
              
                if (t)
                {
                    return;
                }
                this.btnLayerSave.Enabled = false;
                Task.Factory.StartNew<BasLayer>(()=> {
                    BasLayer re = null;
                    if (EditMode == Enums.EditFormMode.Add)
                    {
                        re=bll.Insert<BasLayer>(this.deLayer.CurrentObject as BasLayer);
                    }
                    else if (EditMode == Enums.EditFormMode.Edit)
                    {
                        re=bll.Update(this.deLayer.CurrentObject as BasLayer);
                        OriLayer = re;
                    }
                    return re;
                }).ContinueWith(tt=> {
                    if (!tt.IsFaulted)
                    {
                        syncContext.Post((state)=> {

                            if (tt.Result!=null)
                            {
                                this.gvLayer.BeginUpdate();
                                if (EditMode == Enums.EditFormMode.Add)
                                {
                                    var layerData = this.gvLayer.DataSource as ObservableCollection<BasLayer>;
                                    layerData.Insert(0, tt.Result);
                                }
                                else if(EditMode == Enums.EditFormMode.Edit)
                                {
                                    var layerData = this.gvLayer.DataSource as ObservableCollection<BasLayer>;
                                    var cur = this.gvLayer.CurrentRow.DataBoundItem as BasLayer;
                                    //cur = tt.Result;
                                    layerData[layerData.IndexOf(cur)] = tt.Result ;
                                }
                                
                                this.gvLayer.EndUpdate();

                                if (EditMode == Enums.EditFormMode.Add)
                                {

                                    this.gvLayer.Rows[0].IsCurrent = true;
                                }

                            }
                             
                        },"");
                        
                    }
                    syncContext.Post((state)=> {
                        this.btnLayerSave.Enabled = true;
                    },"");
                });
            };
        }

        private void InitLayerDataEntry()
        {
            this.deLayer.FitToParentWidth = true;
            this.deLayer.ShowValidationPanel = true;
            this.deLayer.EditorInitializing += (s, e) => {
                if (e.Property.Name=="LayerValue")
                {
                    RadMaskedEditBox radMaskedEditBox = new RadMaskedEditBox();
                    radMaskedEditBox.MaskType = MaskType.Numeric;
                    radMaskedEditBox.MaskedEditBoxElement.StretchVertically = true;
                    e.Editor = radMaskedEditBox;
                    //RadSpinEditor editor = new RadSpinEditor();
                    //editor.Maximum = 10000;
                    //editor.SpinElement.StretchVertically = true;
                    //editor.DecimalPlaces = 0;
                    //e.Editor = editor;
                }
                e.Editor.Name = e.Property.Name;
            };
            this.deLayer.ItemValidating += (s, e) => {
                var curr = this.deLayer.CurrentObject as BasLayer; 
                Control con = s as Control;
                switch (con.Name)
                {
                    case "LayerName":
                        if (string.IsNullOrWhiteSpace(curr.LayerName))
                        {
                            string errorMessage = "不能为空！";
                            e.ErrorProvider.SetError(s as Control, errorMessage);
                            e.Cancel = true;
                            Helpers.DataEntryHelper.AddErrorLabel(this.deLayer, e.Label.Text, errorMessage);
                        }
                        else
                        {
                            e.ErrorProvider.Clear();
                            this.deLayer.ValidationPanel.PanelContainer.Controls.RemoveByKey(e.Label.Text);
                        }
                        break;
                    case "LayerValue":
                        if (curr.LayerValue<1)
                        {
                            string errorMessage = "请输入大于0 的整数！";
                            e.ErrorProvider.SetError(s as Control, errorMessage);
                            e.Cancel = true;
                            Helpers.DataEntryHelper.AddErrorLabel(this.deLayer, e.Label.Text, errorMessage);
                        }
                        else
                        {
                            e.ErrorProvider.Clear();
                            this.deLayer.ValidationPanel.PanelContainer.Controls.RemoveByKey(e.Label.Text);
                        }
                        break;
                    default:
                        break;
                }
            };
        }

        private void InitLayerGridView()
        {
            this.gvLayer.AllowAddNewRow = false;
            this.gvLayer.AllowEditRow = false;
            this.gvLayer.AllowSearchRow = true;
            this.gvLayer.EnableFiltering = true;
            this.gvLayer.CurrentRowChanged += (s, e) => {
                var currentRow = e.CurrentRow;
                if (currentRow!=null && !(currentRow is GridViewNewRowInfo))
                {
                    if ( e.OldRow!=null && OriLayer!=null)
                    {
                        var oldData = e.OldRow.DataBoundItem as BasLayer;
                        ObjectHelper.CopyAllField(OriLayer, oldData);
                       
                    }
                    var curData = e.CurrentRow.DataBoundItem as BasLayer;
                    OriLayer = ObjectHelper.DeepClone(curData); 
                    this.deLayer.DataSource = curData;
                    EditMode = Enums.EditFormMode.Edit;
                }
            };
        }

        private void LoadLayerData()
        {
            this.waitBarLayerGrid.StartWaiting();
            this.gvLayer.Rows.Clear();
            Task.Factory.StartNew<ObservableCollection<BasLayer>>(()=> {
                lock (obj)
                {
                    var layerData =new ObservableCollection<BasLayer>( bll.Select<BasLayer>().OrderByDescending(x=>x.LayerValue));
                    return layerData;
                }  
            }).ContinueWith(t=> {
                if (!t.IsFaulted )
                {
                    syncContext.Post((state)=> {
                        this.gvLayer.BeginUpdate();
                        this.gvLayer.DataSource = t.Result;
                        //foreach (var i in this.gvLayer.Columns)
                        //{
                        //    i.BestFit();
                        //}
                        this.gvLayer.BestFitColumns();
                        
                        this.gvLayer.EndUpdate();
                    },t.Result);
                }
                syncContext.Post((state)=> {
                     
                    this.waitBarLayerGrid.StopWaiting();
                },"");
            });
        }
    }
}
