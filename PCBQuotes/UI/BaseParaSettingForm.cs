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
    public partial class BaseParaSettingForm : Telerik.WinControls.UI.RadForm
    {
        public BaseParaSettingForm()
        {
            InitializeComponent();
            this.Text = "基础参数设置";
        }
    }
}
