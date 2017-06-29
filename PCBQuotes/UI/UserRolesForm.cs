using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

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
        }
    }
}
