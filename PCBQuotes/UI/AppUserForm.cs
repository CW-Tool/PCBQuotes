using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PCBQuotes.UI
{
    public partial class AppUserForm : Telerik.WinControls.UI.RadForm
    {
        private Helpers.VirtualGridData<Models.AppUser> data;
        private readonly object obj = new object();//用于线程锁对象
        private SynchronizationContext syncContext = SynchronizationContext.Current;//线程中更新UI模型传播上下文
        private BLL.GeneralBll bll = new BLL.GeneralBll();
        public AppUserForm()
        {
            InitializeComponent();
            this.Text = "用户管理";
            //窗体关闭时dispose
            this.FormClosed += (s, e) => {
                if (bll != null)
                {
                    bll.Dispose();
                    bll = null;
                }
            };

            data = new Helpers.VirtualGridData<Models.AppUser> { Grid = this.vgMainGrid, LoadedCount = 0, PerLoadSize = 100 };
            this.vgMainGrid.AutoSizeColumnsMode = VirtualGridAutoSizeColumnsMode.Fill;//
            this.vgMainGrid.EnableAlternatingRowColor = true;
            this.vgMainGrid.Selection.Multiselect = false;
            this.vgMainGrid.SelectionMode = VirtualGridSelectionMode.FullRowSelect;
            this.vgMainGrid.AllowAddNewRow = false;
            this.vgMainGrid.AllowEdit = false;
            this.vgMainGrid.FilterChanged += (s, e) => { Helpers.VirtualGridDataHelper.InitalLoad<Models.AppUser>(data); };
            this.vgMainGrid.SortChanged += (s, e) => { Helpers.VirtualGridDataHelper.InitalLoad<Models.AppUser>(data); };
            //表格删除时
            this.vgMainGrid.UserDeletedRow += (s, e) =>
            {
                DeleteEntry();

            };
            //双击编辑
            this.vgMainGrid.CellDoubleClick += (s, e) => {
                var cell = this.vgMainGrid.CurrentCell;
                if (cell == null)
                {
                    return;
                }
                if (cell.RowIndex < 0)
                {
                    return;
                }

                var current = data.Data[cell.RowIndex];
                AppUserAddEditForm form = new AppUserAddEditForm();
                form.EditMode = Enums.EditFormMode.Edit;
                form.DataEntry = current;


                var dr = form.ShowDialog(this);

                if (dr == DialogResult.OK)
                {
                    this.vgMainGrid.BeginUpdate();
                    data.Data[cell.RowIndex] = form.DataEntry;
                    this.vgMainGrid.EndUpdate();
                    this.vgMainGrid.SelectCell(cell.RowIndex, cell.ColumnIndex);
                }
            };
            //按钮编辑
            this.btnEdit.Click += (s, e) => {
                var cell = this.vgMainGrid.CurrentCell;
                if (cell == null)
                {
                    RadMessageBox.Show(this, "请选择一行！", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }
                if (cell.RowIndex < 0)
                {
                    return;
                }

                var current = data.Data[cell.RowIndex];
                AppUserAddEditForm form = new AppUserAddEditForm();
                form.EditMode = Enums.EditFormMode.Edit;
                form.DataEntry = current;
                var dr = form.ShowDialog(this);
                //form.FormClosed += (ss, ee) => { Helpers.VirtualGridDataHelper.InitalLoad<Models.UserRole>(data, syncContext); };
                if (dr == DialogResult.OK)
                {
                    this.vgMainGrid.BeginUpdate();
                    data.Data[cell.RowIndex] = form.DataEntry;
                    this.vgMainGrid.EndUpdate();
                    this.vgMainGrid.SelectCell(cell.RowIndex, cell.ColumnIndex);
                }
            };


            this.btnReLoad.Click += (s, e) => {
                Helpers.VirtualGridDataHelper.InitalLoad<Models.AppUser>(data);
            };

            this.btnAdd.Click += (s, e) => {
                AppUserAddEditForm form = new AppUserAddEditForm();
                //form.StartPosition = FormStartPosition.WindowsDefaultLocation;
                form.EditMode = Enums.EditFormMode.Add;
                var dr = form.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    this.vgMainGrid.BeginUpdate();
                    this.data.Data.Insert(0, form.DataEntry);
                    this.vgMainGrid.RowCount++;
                    this.vgMainGrid.EndUpdate();
                    this.vgMainGrid.SelectCell(0, 0);

                }
            };

            this.btnDelete.Click += (s, e) => { DeleteEntry(); };

            Helpers.VirtualGridDataHelper.InitalLoad<Models.AppUser>(data);
        }
        /// <summary>
        /// 删除方法
        /// </summary>
        private void DeleteEntry()
        {

            var cell = this.vgMainGrid.CurrentCell;
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
                this.vgMainGrid.BeginUpdate();
                data.Data.RemoveAt(cell.RowIndex);
                this.vgMainGrid.RowCount--;
                this.vgMainGrid.EndUpdate();
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
