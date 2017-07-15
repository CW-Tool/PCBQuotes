using PCBQuotes.Helpers;
using PCBQuotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Linq;
using System.Threading;
using System.Collections.ObjectModel;

namespace PCBQuotes.UI
{
    public partial class UserRolesForm : Telerik.WinControls.UI.RadForm
    {
        private Helpers.VirtualGridData<Models.AppRole> data;
        private readonly object obj = new object();//用于线程锁对象
        private SynchronizationContext syncContext = SynchronizationContext.Current;//线程中更新UI模型传播上下文
        private BLL.GeneralBll bll = new BLL.GeneralBll();
        public UserRolesForm()
        {
            InitializeComponent();
            
            InitForm();
        }

        private void InitForm()
        {
            //窗体关闭时dispose
            this.FormClosed += (s, e) => {
                if (bll != null)
                {
                    bll.Dispose();
                    bll = null;
                }
            };
  
            data = new Helpers.VirtualGridData<Models.AppRole> { Grid = this.vgUserRoles, LoadedCount = 0, PerLoadSize = 100 };
            this.Text = "角色管理";
            this.vgUserRoles.AutoSizeColumnsMode = VirtualGridAutoSizeColumnsMode.Fill;//
            this.vgUserRoles.EnableAlternatingRowColor = true;
            this.vgUserRoles.Selection.Multiselect = false;
            this.vgUserRoles.SelectionMode = VirtualGridSelectionMode.FullRowSelect;
            this.vgUserRoles.AllowAddNewRow = false;
            //this.vgUserRoles.AllowDelete = false;
            this.vgUserRoles.AllowEdit = false;
            this.vgUserRoles.FilterChanged += (s, e) => { Helpers.VirtualGridDataHelper.InitalLoad<Models.AppRole>(data); };
            this.vgUserRoles.SortChanged += (s, e) => { Helpers.VirtualGridDataHelper.InitalLoad<Models.AppRole>(data); };
            //表格删除时
            this.vgUserRoles.UserDeletedRow += (s, e) =>
            {
                DeleteEntry();

            };
            //双击编辑
            this.vgUserRoles.CellDoubleClick += (s, e) => {
                var cell = this.vgUserRoles.CurrentCell;
                if (cell == null)
                {
                    return;
                }
                if (cell.RowIndex < 0)
                {
                    return;
                }

                var current = data.Data[cell.RowIndex];
                UserRolesAddEditForm form = new UserRolesAddEditForm();
                form.EditMode = Enums.EditFormMode.Edit;
                form.UserRole = current;

                
                var dr = form.ShowDialog(this);

                if (dr == DialogResult.OK)
                {
                    this.vgUserRoles.BeginUpdate();
                    data.Data[cell.RowIndex] = form.UserRole;
                    this.vgUserRoles.EndUpdate();
                    this.vgUserRoles.SelectCell(cell.RowIndex, cell.ColumnIndex);
                }
            };
            //按钮编辑
            this.btnEdit.Click += (s, e) => {
                var cell = this.vgUserRoles.CurrentCell;
                if (cell == null)
                {
                    RadMessageBox.Show(this,"请选择一行！","",MessageBoxButtons.OK,RadMessageIcon.Error);
                    return;
                }
                if (cell.RowIndex < 0)
                {
                    return;
                }

                var current = data.Data[cell.RowIndex];
                UserRolesAddEditForm form = new UserRolesAddEditForm();
                form.EditMode = Enums.EditFormMode.Edit;
                form.UserRole = current;
                var dr = form.ShowDialog(this);
                //form.FormClosed += (ss, ee) => { Helpers.VirtualGridDataHelper.InitalLoad<Models.UserRole>(data, syncContext); };
                if (dr == DialogResult.OK)
                {
                    this.vgUserRoles.BeginUpdate();
                    data.Data[cell.RowIndex] = form.UserRole;
                    this.vgUserRoles.EndUpdate();
                    this.vgUserRoles.SelectCell(cell.RowIndex, cell.ColumnIndex);
                }
            };
            

            this.btnReLoad.Click += (s, e) => {
                Helpers.VirtualGridDataHelper.InitalLoad<Models.AppRole>(data);
            };
             
            this.btnAdd.Click += (s, e) => {
                UserRolesAddEditForm form = new UserRolesAddEditForm();
                //form.StartPosition = FormStartPosition.WindowsDefaultLocation;
                form.EditMode = Enums.EditFormMode.Add;
                var dr = form.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    this.vgUserRoles.BeginUpdate();
                    this.data.Data.Insert(0, form.UserRole);
                    this.vgUserRoles.RowCount++;
                    this.vgUserRoles.EndUpdate();
                    this.vgUserRoles.SelectCell(0, 0);
                    
                }
            };

            this.btnDelete.Click += (s, e) => { DeleteEntry(); };

            Helpers.VirtualGridDataHelper.InitalLoad<Models.AppRole>(data);

            //设置Column宽度 命令列，使用ID列做为命令列
            //this.vgUserRoles.TableElement.ColumnsViewState.SetItemSize(0, 30);

            //this.vgUserRoles.ColumnWidthChanging += (s, e) => {
            //    //ID列为命令按钮，固定大小，不允许resize
            //    int idIndex = Array.IndexOf(ModelHelper.GetColumnNames(typeof(UserRole)), "ID");
            //    if (e.ColumnIndex == idIndex)
            //    {
            //        e.Cancel = true;
            //    }
            //};

            //this.vgUserRoles.CreateCellElement += (s, e) => {
            //    //ID列约定为命令按钮
            //    int idIndex = Array.IndexOf(ModelHelper.GetColumnNames(typeof(UserRole)), "ID");
            //    if (e.RowIndex >= 0 && e.ColumnIndex == idIndex)
            //    {
            //        var cmd = new Helpers.VirtualGridEditCommandCellElement();
            //        cmd.EditButtonClicked += (ss, ee) => {
            //            var id = (int)cmd.Value;
            //            var entity =  data.Data.FirstOrDefault(x => x.ID == id);
            //            if (entity!=null)
            //            {
            //                UserRolesAddEditForm form = new UserRolesAddEditForm(); 
            //                form.EditMode = Enums.EditFormMode.Edit;
            //                form.UserRole = entity;
            //                var dr = form.ShowDialog(this);
            //                if (dr == DialogResult.OK)
            //                {
            //                    Helpers.VirtualGridDataHelper.InitalLoad<Models.UserRole>(data, System.Threading.SynchronizationContext.Current);
            //                }
            //            }
            //        };
            //        cmd.DeleteButtonClicked += (ss, ee) => { };
            //        e.CellElement = cmd;
            //    }

            //};
            //this.vgUserRoles.CellFormatting += (s, e) => {
            //    //ID列约定为命令按钮
            //    int idIndex = Array.IndexOf(ModelHelper.GetColumnNames(typeof(UserRole)), "ID");
            //    if (e.CellElement.RowIndex == -3 && e.CellElement.ColumnIndex == idIndex)
            //    {
            //        e.CellElement.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            //    }
            //    if (e.CellElement.RowIndex == -1 && e.CellElement.ColumnIndex == idIndex)
            //    {
            //        e.CellElement.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            //    }
            //};
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        private void DeleteEntry()
        {
            
            var cell = this.vgUserRoles.CurrentCell;
            if (cell == null)
            {
                RadMessageBox.Show(this, "请选择一行！", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            if (cell.RowIndex < 0)
            {
                return;
            }
            var dr = RadMessageBox.Show(this, "确认删除？", "确认？", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dr == DialogResult.No)
            {

                return;
            }
            var current = data.Data[cell.RowIndex];
            var re = bll.Delete<Models.AppRole>(current.Id);
            if (re > 0)
            {
                this.vgUserRoles.BeginUpdate();
                data.Data.RemoveAt(cell.RowIndex);
                this.vgUserRoles.RowCount--;
                this.vgUserRoles.EndUpdate();
                //if (cell.RowIndex>0)
                //{
                //    this.vgUserRoles.SelectCell();
                //}
            }
            //ObservableCollection<Models.UserRole> adf = new ObservableCollection<UserRole>();
            //this.vgUserRoles.MultiSelect = true; e.RowIndices 如果允许多选，可以使用前面的属性遍历选中的行号，此处我采用单行删除
        }
    }
}
