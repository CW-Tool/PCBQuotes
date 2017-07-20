using Microsoft.Data.ConnectionUI;
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

            //this.menuFile.Shortcuts.Add(new RadShortcut(Keys.Alt,Keys.F));
            //this.menuFile.HintText = "(F)";
             
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

            //数据库设置菜单事件
            this.menuDatabaseSetting.Click += (s, e) => {
                //Helpers.MDIFormHelper.OpenUniqueMDIChildWindow<UI.DatabaseSettingForm>(this);
                SetDatabaseConnectionString();
            };

            //用户角色 管理
            this.menuUserRoles.Click += (s, e) => {
                Helpers.MDIFormHelper.OpenUniqueMDIChildWindow<UI.UserRolesForm>(this,FormWindowState.Normal);
            };
            //用户管理菜单事件
            this.menuUsers.Click += (s, e) => {
                Helpers.MDIFormHelper.OpenUniqueMDIChildWindow<UI.AppUserForm>(this, FormWindowState.Normal);
            };
            //基础参数设置
            this.menuBaseParaSetting.Click += (s, e) => {
                Helpers.MDIFormHelper.OpenUniqueMDIChildWindow<UI.BaseParaSettingForm>(this, FormWindowState.Normal);
            };
        }

        private void SetDatabaseConnectionString()
        {
            

            DataConnectionDialog dialog = new DataConnectionDialog();
            dialog.DataSources.Clear();

            //添加数据源列表，可以向窗口中添加所需要的数据源类型 必须至少有一项
            dialog.DataSources.Add(DataSource.AccessDataSource);    //Access
            dialog.DataSources.Add(DataSource.SqlDataSource);       //Sql Server
            dialog.DataSources.Add(DataSource.OracleDataSource);    //Oracle
            dialog.DataSources.Add(DataSource.OdbcDataSource);      //Odbc
            dialog.DataSources.Add(DataSource.SqlFileDataSource);   //Sql Server File

            //设置默认数据提供程序
            dialog.SelectedDataSource = DataSource.SqlDataSource;
            dialog.SelectedDataProvider = DataProvider.SqlDataProvider;
            dialog.Text = "数据库连接设置";

            
            var connStr = Helpers.AppConfigHelper.GetConnectionString("DefaultConnStr");
            if (!string.IsNullOrWhiteSpace(connStr))
            {
                dialog.ConnectionString = connStr;
            }

            //dialog.Title = "Cosmic_Spy";
            //dialog.ConnectionString = "Data Source=****;Initial Catalog=****;Integrated Security=True"; //也可以设置默认连接字符串
            //只能够通过DataConnectionDialog类的静态方法Show出对话框，不能使用dialog.Show()或dialog.ShowDialog()来呈现对话框
            if (DataConnectionDialog.Show(dialog) == DialogResult.OK)
            {
                Helpers.AppConfigHelper.UpdateConnectionString("DefaultConnStr", dialog.ConnectionString, dialog.SelectedDataProvider.Name);
                //result = dialog.ConnectionString;
            }
        }

        private string GetDatabaseConnectionString()
        {
            string result = string.Empty;
            DataConnectionDialog dialog = new DataConnectionDialog();
            dialog.DataSources.Clear();

            //添加数据源列表，可以向窗口中添加所需要的数据源类型 必须至少有一项
            dialog.DataSources.Add(DataSource.AccessDataSource);    //Access
            dialog.DataSources.Add(DataSource.SqlDataSource);       //Sql Server
            dialog.DataSources.Add(DataSource.OracleDataSource);    //Oracle
            dialog.DataSources.Add(DataSource.OdbcDataSource);      //Odbc
            dialog.DataSources.Add(DataSource.SqlFileDataSource);   //Sql Server File

            //设置默认数据提供程序
            dialog.SelectedDataSource = DataSource.SqlDataSource;
            dialog.SelectedDataProvider = DataProvider.SqlDataProvider;
            dialog.Text = "数据库连接设置";
            
        
            //dialog.Title = "Cosmic_Spy";
            //dialog.ConnectionString = "Data Source=****;Initial Catalog=****;Integrated Security=True"; //也可以设置默认连接字符串
            //只能够通过DataConnectionDialog类的静态方法Show出对话框，不能使用dialog.Show()或dialog.ShowDialog()来呈现对话框
            if (DataConnectionDialog.Show(dialog) == DialogResult.OK)
            {
                result = dialog.ConnectionString;
            }
            return result;
        }
    }
}
