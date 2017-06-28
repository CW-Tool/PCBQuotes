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
            this.Text = "主窗口";
            this.WindowState = FormWindowState.Maximized;//窗口最大化 
            //关闭主界面时
            this.FormClosing += (s, e) => {
                var dr =RadMessageBox.Show (this,"是否退出程序？","是否退出？",MessageBoxButtons.YesNo,RadMessageIcon.Question,MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
            };
            this.FormClosed += (s, e) => {
                Application.Exit();//请注意在每一个子窗口中处理线程关闭in FormClosing
            };

            //关闭所有窗口菜单事件
            this.menuCloseAllWindow.Click += (s, e) => {
                foreach (var m in this.MdiChildren)
                {
                    m.Close();
                }
            };

            //退出 程序 菜单事件
            this.menuExit.Click += (s, e) => {
                this.Close();
                //Environment.Exit(Environment.ExitCode);
            };
        }
    }
}
