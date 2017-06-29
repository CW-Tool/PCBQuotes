namespace PCBQuotes.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.menuFile = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.menuExit = new Telerik.WinControls.UI.RadMenuItem();
            this.menuSettings = new Telerik.WinControls.UI.RadMenuItem();
            this.menuDatabaseSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.menuWindows = new Telerik.WinControls.UI.RadMenuItem();
            this.menuCloseAllWindow = new Telerik.WinControls.UI.RadMenuItem();
            this.menuAbout = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.menuUserRoles = new Telerik.WinControls.UI.RadMenuItem();
            this.menuUsers = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuFile,
            this.menuSettings,
            this.menuWindows,
            this.menuAbout});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(792, 20);
            this.radMenu1.TabIndex = 0;
            this.radMenu1.Text = "radMenu1";
            // 
            // menuFile
            // 
            this.menuFile.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuSeparatorItem1,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Text = "文件";
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Text = "退出";
            // 
            // menuSettings
            // 
            this.menuSettings.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuUserRoles,
            this.menuUsers,
            this.radMenuSeparatorItem2,
            this.menuDatabaseSetting});
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Text = "设置";
            // 
            // menuDatabaseSetting
            // 
            this.menuDatabaseSetting.Name = "menuDatabaseSetting";
            this.menuDatabaseSetting.Text = "数据库设置";
            // 
            // menuWindows
            // 
            this.menuWindows.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuCloseAllWindow});
            this.menuWindows.MdiList = true;
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Text = "窗口";
            // 
            // menuCloseAllWindow
            // 
            this.menuCloseAllWindow.Name = "menuCloseAllWindow";
            this.menuCloseAllWindow.Text = "关闭所有窗口";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Text = "关于";
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuUserRoles
            // 
            this.menuUserRoles.Name = "menuUserRoles";
            this.menuUserRoles.Text = "用户角色管理";
            // 
            // menuUsers
            // 
            this.menuUsers.Name = "menuUsers";
            this.menuUsers.Text = "用户管理";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 570);
            this.Controls.Add(this.radMenu1);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "主窗口";
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem menuFile;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem menuExit;
        private Telerik.WinControls.UI.RadMenuItem menuWindows;
        private Telerik.WinControls.UI.RadMenuItem menuCloseAllWindow;
        private Telerik.WinControls.UI.RadMenuItem menuAbout;
        private Telerik.WinControls.UI.RadMenuItem menuSettings;
        private Telerik.WinControls.UI.RadMenuItem menuDatabaseSetting;
        private Telerik.WinControls.UI.RadMenuItem menuUserRoles;
        private Telerik.WinControls.UI.RadMenuItem menuUsers;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
    }
}
