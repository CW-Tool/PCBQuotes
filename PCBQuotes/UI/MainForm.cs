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
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public MainForm()
        {
            InitializeComponent();
            InitForm();
        }

        /// <summary>
        /// 初始化窗口
        /// </summary>
        private void InitForm()
        {
            this.IsMdiContainer = true; //MDI主窗口
        }
    }
}
