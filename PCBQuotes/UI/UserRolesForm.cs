using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PCBQuotes.UI
{
    public partial class UserRolesForm : Telerik.WinControls.UI.RadForm
    {
        
        public UserRolesForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            this.Text = "角色管理";
            this.vgUserRoles.AutoSizeColumnsMode = VirtualGridAutoSizeColumnsMode.Fill;//
            this.vgUserRoles.EnableAlternatingRowColor = true;
            this.vgUserRoles.Selection.Multiselect = false;
            this.vgUserRoles.SelectionMode = VirtualGridSelectionMode.FullRowSelect;
            this.vgUserRoles.AllowAddNewRow = false;
            this.vgUserRoles.AllowDelete = false;
            this.vgUserRoles.AllowEdit = false;
             
             
            Helpers.VirtualGridData<Models.UserRole> data = new Helpers.VirtualGridData<Models.UserRole> {  Grid= this.vgUserRoles,LoadedCount=0,PerLoadSize=100 };
            Helpers.VirtualGridDataHelper.InitalLoad<Models.UserRole>(data, System.Threading.SynchronizationContext.Current);

            this.btnReLoad.Click += (s, e) => {
                Helpers.VirtualGridDataHelper.InitalLoad<Models.UserRole>(data, System.Threading.SynchronizationContext.Current);
            };
             
            this.btnAdd.Click += (s, e) => {
                UserRolesAddEditForm form = new UserRolesAddEditForm();
                //form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            };
        }
    }
}
