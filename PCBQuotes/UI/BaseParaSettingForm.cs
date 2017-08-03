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
        private QuoLayer OriLayer;
        private List<int> delIds = new List<int>();//要删除的id
        private BindingList<ComboboxItemModel> cmbLayer = new BindingList<ComboboxItemModel>();
        private BindingList<ComboboxItemModel> cmbMaterial = new BindingList<ComboboxItemModel>();
        //private bool isUpdate = false;
        //private ObservableCollection<BasLayer> layerData = new ObservableCollection<BasLayer>();
        public BaseParaSettingForm()
        {
            InitializeComponent();
            this.Text = "基础参数设置";
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;//控件验证时 validating e.cancel = true 时可以 切换焦点




            InitMaterialCostGridView();
            InitMaterialGridView();
            InitLayerDataEntry();
            InitLayerGridView();
            LoadLayerData();

            this.pvSetting.SelectedPageChanged += (s, e) => {
                switch (this.pvSetting.SelectedPage.Name)
                {
                    case "pvpMaterialSetting": //物料设置
                        //InitMaterialGridView();
                        LoadMaterialData();
                        break;
                    case "pvpLayerSetting"://层数设置
                        //InitLayerDataEntry();
                        //InitLayerGridView();
                        LoadLayerData();
                        break;
                    default:
                        break;
                }

            };

            this.btnMaterialReload.Click += (s, e) => {
                LoadMaterialData();
            };
            this.btnMaterialDelete.Click += (s, e) => {
                if (RadMessageBox.Show(this, "确认删除所选行？", "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                {
                    return;
                }
                var rows = this.gvMaterial.SelectedRows;
                if (rows.Count<=0)
                {
                    RadMessageBox.Show(this, "请选择想删除的行！", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }
                delIds.Clear();
                foreach (var row    in rows)
                {
                    var tmp = row.DataBoundItem as QuoMaterial;
                    if (tmp!=null && tmp.Id>0)
                    {
                        delIds.Add(tmp.Id);
                    }
                   
                }
                if (delIds.Count>0)
                {
                    Task.Factory.StartNew(() => {
                        bll.Delete<QuoMaterial>(delIds);
                    }).ContinueWith(t => {
                        if (t.IsFaulted)
                        {
                            LoadMaterialData();
                        }
                        syncContext.Post((state)=> {
                            this.gvMaterial.BeginUpdate();
                            foreach (var i in rows)
                            {
                                this.gvMaterial.Rows.Remove(i);
                            }
                            this.gvMaterial.EndUpdate();
                        },"");
                        
                    });
                }
            };
           
            //取消按钮事件
            this.btnLayerCancel.Click += (s, e) => {
                 
                if (EditMode == Enums.EditFormMode.Add)
                {
                    this.deLayer.DataSource = new QuoLayer();
                    
                }
                else if (EditMode == Enums.EditFormMode.Edit)
                {
                    this.deLayer.DataSource = OriLayer;
                    var cur = this.gvLayer.CurrentRow.DataBoundItem as QuoLayer;
                    ObjectHelper.CopyAllField(OriLayer, cur);
                    //this.deLayer.DataSource = OriginalLayer ;
                }
            };
            //加载按钮事件
            this.btnReLoad.Click += (s, e) => { LoadLayerData(); };
            //新增按钮事件
            this.btnLayerAdd.Click += (s, e) => {
                EditMode = Enums.EditFormMode.Add;
                this.deLayer.DataSource = new QuoLayer();
                 
            };
            //删除按钮事件
            this.btnLayerDelete.Click += (s, e) => {
                if (RadMessageBox.Show(this,"确认删除？","",MessageBoxButtons.YesNo,RadMessageIcon.Question)== DialogResult.Yes)
                {
                    this.btnLayerDelete.Enabled = false;  
                    Task.Factory.StartNew<QuoLayer>(()=> {
                        var cur = this.gvLayer.CurrentRow.DataBoundItem as QuoLayer;
                        if (bll.Delete<QuoLayer>(cur.Id) > 0)
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
                                var layerData = this.gvLayer.DataSource as ObservableCollection<QuoLayer>;
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
                Task.Factory.StartNew<QuoLayer>(()=> {
                    QuoLayer re = null;
                    if (EditMode == Enums.EditFormMode.Add)
                    {
                        re=bll.Insert<QuoLayer>(this.deLayer.CurrentObject as QuoLayer);
                    }
                    else if (EditMode == Enums.EditFormMode.Edit)
                    {
                        re=bll.Update(this.deLayer.CurrentObject as QuoLayer);
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
                                    var layerData = this.gvLayer.DataSource as ObservableCollection<QuoLayer>;
                                    layerData.Insert(0, tt.Result);
                                }
                                else if(EditMode == Enums.EditFormMode.Edit)
                                {
                                    var layerData = this.gvLayer.DataSource as ObservableCollection<QuoLayer>;
                                    var cur = this.gvLayer.CurrentRow.DataBoundItem as QuoLayer;
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
                var curr = this.deLayer.CurrentObject as QuoLayer; 
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
                        var oldData = e.OldRow.DataBoundItem as QuoLayer;
                        ObjectHelper.CopyAllField(OriLayer, oldData);
                       
                    }
                    var curData = e.CurrentRow.DataBoundItem as QuoLayer;
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
            Task.Factory.StartNew<ObservableCollection<QuoLayer>>(()=> {
                lock (obj)
                {
                    var layerData =new ObservableCollection<QuoLayer>( bll.Select<QuoLayer>().OrderByDescending(x=>x.LayerValue));
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

        private void InitMaterialCostGridView()
        {
            this.gvMaterialCost.AddNewRowPosition = SystemRowPosition.Top;
            this.gvMaterialCost.EnableFiltering = true;
            this.gvMaterialCost.AllowAddNewRow = true;
            this.gvMaterialCost.AllowSearchRow = true;
            this.gvMaterialCost.AutoGenerateColumns = false;

            //var lst = bll.Select<QuoLayer>();
            //var dLst = new List<ComboboxItemModel>();
            //foreach (var i in lst)
            //{
            //    dLst.Add(new ComboboxItemModel {  DisplayMember=i.LayerName,ValueMember=i.Id});
            //}
            GridViewComboBoxColumn c1 = new GridViewComboBoxColumn();
            c1.DataSource = cmbLayer;
            c1.HeaderText = "层数"; 
            c1.Name = "LayerId";
            c1.FieldName = "LayerId";
            c1.ValueMember = "ValueMember";
            c1.DisplayMember =  "DisplayMember";
            c1.FilteringMode = GridViewFilteringMode.DisplayMember;
            c1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            c1.Width = 80;
            this.gvMaterialCost.Columns.Add(c1);
            GridViewComboBoxColumn c2 = new GridViewComboBoxColumn();
            c2.DataSource = cmbMaterial;
            c2.HeaderText = "物料名称";
            c2.Name = "MaterialId";
            c2.FieldName = "MaterialId";
            c2.ValueMember = "ValueMember";
            c2.DisplayMember = "DisplayMember";
            c2.FilteringMode = GridViewFilteringMode.DisplayMember;
            c2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            c2.Width = 100;
            c2.WrapText = true;
            this.gvMaterialCost.Columns.Add(c2);
            GridViewTextBoxColumn c3 = new GridViewTextBoxColumn();
            c3.HeaderText = "价格";
            c3.Name = "Cost";
            c3.FieldName = "Cost";
            c3.Width = 80;
            this.gvMaterialCost.Columns.Add(c3);
            GridViewTextBoxColumn c4 = new GridViewTextBoxColumn();
            c4.HeaderText = "备注";
            c4.Name = "Remark";
            c4.FieldName = "Remark";
            c4.Width = 100;
            c4.WrapText = true;
            this.gvMaterialCost.Columns.Add(c4);

            
            this.gvMaterialCost.UserDeletingRow += (s, e) => {
                if (RadMessageBox.Show(this, "确认删除所选行？", "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                if (e.Rows != null && e.Rows.Count() > 0)
                {
                    delIds.Clear();
                    foreach (var row in e.Rows)
                    {
                        var tmp = row.DataBoundItem as QuoMaterialCost;
                        if (tmp != null && tmp.Id > 0)
                        {
                            delIds.Add(tmp.Id);
                        }
                    }

                }
            };
            this.gvMaterialCost.UserDeletedRow += (s, e) => {
                if (delIds != null && delIds.Count > 0)
                {
                    Task.Factory.StartNew(() => {
                        bll.Delete<QuoMaterialCost>(delIds);
                    }).ContinueWith(t => {
                        if (t.IsFaulted)
                        {
                            syncContext.Post((state) => {
                                LoadMaterialCostData();
                            }, null);
                        }
                    });
                }
            };

            this.gvMaterialCost.UserAddedRow += (s, e) => {
                var tmp = e.Row.DataBoundItem as QuoMaterialCost;
                if (tmp != null)
                {
                    Task.Factory.StartNew<QuoMaterialCost>(() => {
                        return bll.Insert(tmp);
                    }).ContinueWith(t => {
                        if (!t.IsFaulted)
                        {
                            syncContext.Post((state) => {
                                LoadMaterialCostData();
                            }, null);
                        }
                        
 
                    });
                }
            };

             
            this.gvMaterialCost.CellValueChanged += (s, e) => {
                var cur = e.Row.DataBoundItem as QuoMaterialCost;
                Task.Factory.StartNew(() =>
                {
                    bll.Update<QuoMaterialCost>(cur.Id, e.Column.FieldName, e.Value);
                }).ContinueWith(t=> {
                    if (!t.IsFaulted)
                    {
                        syncContext.Post((state)=> {
                            LoadMaterialCostData();
                        },null);
                    }
                }) ;
            };

            //验证
            this.gvMaterialCost.CellValidating += (s, e) => {
                GridViewDataColumn column = e.Column as GridViewDataColumn;
                if ((e.Row is GridViewNewRowInfo || e.Row is GridViewDataRowInfo) && column != null && column.Name == "LayerId")// 
                {
                    if (e.Value == null || ((int)e.Value) <=0)
                    {
                        e.Cancel = true;
                        e.Row.ErrorText = "Validation error!";
                        //((GridViewDataRowInfo)e.Row).ErrorText = "Validation error!";
                    }
                    else
                    {
                        ((GridViewDataRowInfo)e.Row).ErrorText = string.Empty;
                    }
                }
                if ((e.Row is GridViewNewRowInfo || e.Row is GridViewDataRowInfo) && column != null && column.Name == "MaterialId")// 
                {
                    if (e.Value == null || ((int)e.Value) <= 0)
                    {
                        e.Cancel = true;
                        e.Row.ErrorText = "Validation error!";
                        //((GridViewDataRowInfo)e.Row).ErrorText = "Validation error!";
                    }
                    else
                    {
                        e.Row.ErrorText = string.Empty;
                    }
                }
            };
            ////initialize default values for the new row
            //this.gvMaterialCost.DefaultValuesNeeded += (s, e) => {
            //    var currentMaterial = this.gvMaterial.CurrentRow.DataBoundItem as QuoMaterial;
            //    e.Row.Cells["MaterialId"].Value = currentMaterial.Id;
            //};

            //initialize default values for the data row
            //this.gvMaterialCost.CellEditorInitialized += (s, e) => {
            //    if (e.Row is GridViewDataRowInfo)

            //    {

            //        if (e.Column.Name == "ContactName")

            //        {

            //            e.ActiveEditor.Value = "Default Value";

            //        }

            //    }
            //};

            this.gvMaterialCost.CellFormatting += (s, e) => {
                //if (e.Row is GridViewDataRowInfo && e.Column.Name == "LayerId" && e.Row.Cells["LayerId"].Value == null)
                //{
                //    e.Row.Cells["LayerId"].Value = (e.Row.DataBoundItem as QuoMaterialCost).LayerId;

                //}


            };
            
        }

        private void LoadMaterialCostData()
        {
            this.wbMaterialCostGridView.StartWaiting();
            this.gvMaterialCost.Rows.Clear();

            
             
            var materialRow = this.gvMaterial.CurrentRow;
            if (materialRow!=null)
            {
                var currentMaterial = materialRow.DataBoundItem as QuoMaterial;
                if (currentMaterial!=null)
                {
                    Task.Factory.StartNew(() => {
                        if (cmbLayer.Count<1)
                        {
                            var lays = bll.Select<QuoLayer>();
                            foreach (var i in lays)
                            {
                                cmbLayer.Add(new ComboboxItemModel { DisplayMember = i.LayerName, ValueMember = i.Id });
                            }
                        }
                        if (cmbMaterial.Count<1)
                        {
                            foreach (var i in bll.Select<QuoMaterial>())
                            {
                                cmbMaterial.Add(new ComboboxItemModel { DisplayMember= i.MaterialName,ValueMember=i.Id});
                            }
                        }
                        var re = bll.Select<QuoMaterialCost>(string.Format(" MaterialId = {0}",currentMaterial.Id));//new BindingList<QuoMaterialCostViewModel>(bll.SelectQuoMaterialCostViewModel(currentMaterial.Id).OrderByDescending(x => x.Id).ToList());
                        return re;
                    }).ContinueWith(t => {
                        if (!t.IsFaulted)
                        {
                            syncContext.Post((state) => {
                                this.gvMaterialCost.BeginUpdate();
                               
                                this.gvMaterialCost.DataSource = t.Result;

                                //设置new row default value
                                var addRow = this.gvMaterialCost.MasterView.TableAddNewRow;
                                addRow.Cells["MaterialId"].Value = currentMaterial.Id;
                                //foreach (var i in this.gvMaterialCost.Columns)
                                //{

                                //    i.MinWidth = 100;
                                //}
                                //this.gvMaterialCost.BestFitColumns();
                                this.gvMaterialCost.EndUpdate();
                            }, t.Result);
                        }
                        syncContext.Post((state) => {
                            this.wbMaterialCostGridView.StopWaiting();
                        }, "");
                    });
                }
            }
            
        }

        private void InitMaterialGridView()
        {
            this.gvMaterial.AddNewRowPosition = SystemRowPosition.Top;
            this.gvMaterial.EnableFiltering = true;
            this.gvMaterial.AllowAddNewRow = true;
            this.gvMaterial.AllowSearchRow = true;
            
            //验证
            this.gvMaterial.CellValidating += (s, e) => {
                GridViewDataColumn column = e.Column as GridViewDataColumn;
                if ((e.Row is GridViewNewRowInfo||e.Row is GridViewDataRowInfo) && column != null && column.Name == "MaterialName")//物料名称
                {
                    if (string.IsNullOrEmpty((string)e.Value) || ((string)e.Value).Trim() == string.Empty)
                    {
                        e.Cancel = true;
                        e.Row.ErrorText = "Validation error!";
                        //((GridViewDataRowInfo)e.Row).ErrorText = "Validation error!";
                    }
                    else
                    {
                         e.Row.ErrorText = string.Empty;
                    }
                }

            };
            
            this.gvMaterial.UserDeletingRow += (s, e) => {
                if (RadMessageBox.Show(this,"确认删除所选行？","",MessageBoxButtons.YesNo,RadMessageIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                if (e.Rows !=null && e.Rows .Count()>0)
                {
                    delIds.Clear();
                    foreach (var row in e.Rows)
                    {
                        var tmp = row.DataBoundItem as QuoMaterial;
                        if (tmp != null && tmp.Id > 0)
                        {
                            delIds.Add(tmp.Id);
                        }
                    }
                     
                }
                
            };

            this.gvMaterial.UserDeletedRow += (s, e) => {
                if (delIds!=null && delIds.Count>0)
                {
                    Task.Factory.StartNew(()=> {
                        bll.Delete<QuoMaterial>(delIds);
                    }).ContinueWith(t=> {
                        if (t.IsFaulted)
                        {
                            syncContext.Post((state) => {
                                LoadMaterialData();
                            }, null);
                        }
                    });
                }
            };
            
            this.gvMaterial.UserAddedRow += (s, e) => {
                var tmp = e.Row.DataBoundItem as QuoMaterial;
                if (tmp!=null)
                {
                    Task.Factory.StartNew<QuoMaterial>(()=> {
                        return bll.Insert(tmp);
                    }).ContinueWith(t=> {
                        syncContext.Post((state)=> {
                            LoadMaterialData();
                        },null);
                        
                        //if (!t.IsFaulted && t.Result!=null)
                        //{
                        //    syncContext.Post((state) => {
                        //        this.gvMaterial.BeginUpdate();
                        //        ObjectHelper.CopyAllField(t.Result, tmp);
                                 
                        //        this.gvMaterial.EndUpdate();
                        //    },"");
                            
                        //}
                        //if (t.IsFaulted || t.Result == null)
                        //{
                        //    this.gvMaterial.BeginUpdate();
                        //    var ds = this.gvMaterial.DataSource as BindingList<BasMaterial>;
                        //    ds.Remove(tmp);
                        //    this.gvMaterial.EndUpdate();
                        //}
                    });
                }
            };

            this.gvMaterial.CurrentRowChanged += (s, e) => {
                LoadMaterialCostData();
            };

            this.gvMaterial.RowsChanging += (s, e) => {
                if(e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.ItemChanging)
                {
                    var cur = e.GridViewTemplate.MasterTemplate.CurrentRow.DataBoundItem as QuoMaterial; 
                    if (cur!=null)
                    {
                        Task.Factory.StartNew(() => {
                            //return false;
                            return bll.Update<QuoMaterial>(cur.Id, e.PropertyName, e.NewValue) > 0;
                        }).ContinueWith(t => {

                            if (t.IsFaulted || !t.Result)
                            {
                                syncContext.Post((sta) =>
                                {
                                    this.gvMaterial.BeginUpdate();
                                    ModelHelper.SetValueByPropertyName(cur, e.PropertyName, e.OldValue);
                                    this.gvMaterial.EndUpdate();
                                }, "");
                            }
                        });
                    }
                    
                }
            };

        }
        private void LoadMaterialData()
        {
            this.wbMaterialGridView.StartWaiting();
            this.gvMaterial.Rows.Clear();
            Task.Factory.StartNew (()=> {
                var re = new BindingList<QuoMaterial>(bll.Select<QuoMaterial>().OrderByDescending(x=>x.Id).ToList());
                return re;
            }).ContinueWith(t=> {
                if (!t.IsFaulted)
                {
                    syncContext.Post((state)=> {
                        this.gvMaterial.BeginUpdate();
                        this.gvMaterial.DataSource = t.Result;
                        foreach (var i in this.gvMaterial.Columns)
                        {
                            
                            i.MinWidth = 100;
                        }
                        this.gvMaterial.BestFitColumns( );
                        this.gvMaterial.EndUpdate();
                    },t.Result);
                }
                syncContext.Post((state) => { 
                    this.wbMaterialGridView.StopWaiting();
                }, "");
            });
        }


    }
}
