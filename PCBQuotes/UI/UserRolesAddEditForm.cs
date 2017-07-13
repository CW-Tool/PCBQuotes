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
    public partial class UserRolesAddEditForm : Telerik.WinControls.UI.RadForm
    {
        public UserRolesAddEditForm()
        {
            InitializeComponent();

            this.Text = "新增/编辑";
        }
    }
}
