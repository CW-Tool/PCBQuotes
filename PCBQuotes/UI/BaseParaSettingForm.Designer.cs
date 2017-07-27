namespace PCBQuotes.UI
{
    partial class BaseParaSettingForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pvSetting = new Telerik.WinControls.UI.RadPageView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.pvpLayerSetting = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.gvLayer = new Telerik.WinControls.UI.RadGridView();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.deLayer = new Telerik.WinControls.UI.RadDataEntry();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnLayerAdd = new Telerik.WinControls.UI.CommandBarButton();
            this.btnLayerSave = new Telerik.WinControls.UI.CommandBarButton();
            this.btnLayerDelete = new Telerik.WinControls.UI.CommandBarButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReLoad = new Telerik.WinControls.UI.RadButton();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.waitBarLayerGrid = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.btnLayerCancel = new Telerik.WinControls.UI.CommandBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.pvSetting)).BeginInit();
            this.pvSetting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.pvpLayerSetting.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLayer.MasterTemplate)).BeginInit();
            this.gvLayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deLayer)).BeginInit();
            this.deLayer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitBarLayerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pvSetting
            // 
            this.pvSetting.Controls.Add(this.pvpLayerSetting);
            this.pvSetting.Controls.Add(this.radPageViewPage1);
            this.pvSetting.DefaultPage = this.pvpLayerSetting;
            this.pvSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvSetting.Location = new System.Drawing.Point(3, 43);
            this.pvSetting.Name = "pvSetting";
            this.pvSetting.SelectedPage = this.pvpLayerSetting;
            this.pvSetting.Size = new System.Drawing.Size(686, 424);
            this.pvSetting.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pvSetting, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(692, 470);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 34);
            this.panel1.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(75, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "基础参数设置";
            // 
            // pvpLayerSetting
            // 
            this.pvpLayerSetting.Controls.Add(this.tableLayoutPanel2);
            this.pvpLayerSetting.ItemSize = new System.Drawing.SizeF(58F, 28F);
            this.pvpLayerSetting.Location = new System.Drawing.Point(10, 37);
            this.pvpLayerSetting.Name = "pvpLayerSetting";
            this.pvpLayerSetting.Size = new System.Drawing.Size(665, 376);
            this.pvpLayerSetting.Text = "层数设置";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.radSplitContainer1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 376F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(665, 376);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.EnableCollapsing = true;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(665, 376);
            this.radSplitContainer1.SplitterWidth = 8;
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            this.radSplitContainer1.UseSplitterButtons = true;
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.tableLayoutPanel4);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel1.Size = new System.Drawing.Size(328, 376);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.tableLayoutPanel3);
            this.splitPanel2.Location = new System.Drawing.Point(336, 0);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(329, 376);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            // 
            // gvLayer
            // 
            this.gvLayer.Controls.Add(this.waitBarLayerGrid);
            this.gvLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLayer.Location = new System.Drawing.Point(3, 43);
            // 
            // 
            // 
            this.gvLayer.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvLayer.Name = "gvLayer";
            this.gvLayer.Size = new System.Drawing.Size(322, 330);
            this.gvLayer.TabIndex = 0;
            this.gvLayer.Text = "radGridView1";
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // deLayer
            // 
            this.deLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deLayer.Location = new System.Drawing.Point(3, 35);
            this.deLayer.Name = "deLayer";
            // 
            // deLayer.PanelContainer
            // 
            this.deLayer.PanelContainer.Size = new System.Drawing.Size(321, 336);
            this.deLayer.Size = new System.Drawing.Size(323, 338);
            this.deLayer.TabIndex = 0;
            this.deLayer.Text = "radDataEntry1";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.deLayer, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.radCommandBar1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(329, 376);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(3, 3);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(323, 55);
            this.radCommandBar1.TabIndex = 1;
            this.radCommandBar1.Text = "radCommandBar1";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnLayerAdd,
            this.btnLayerSave,
            this.btnLayerCancel,
            this.btnLayerDelete});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // btnLayerAdd
            // 
            this.btnLayerAdd.DisplayName = "commandBarButton1";
            this.btnLayerAdd.Image = global::PCBQuotes.Properties.Resources.Plus_18px;
            this.btnLayerAdd.Name = "btnLayerAdd";
            this.btnLayerAdd.Text = "commandBarButton1";
            this.btnLayerAdd.ToolTipText = "新增";
            // 
            // btnLayerSave
            // 
            this.btnLayerSave.DisplayName = "commandBarButton2";
            this.btnLayerSave.Image = global::PCBQuotes.Properties.Resources.Save_18px;
            this.btnLayerSave.Name = "btnLayerSave";
            this.btnLayerSave.Text = "commandBarButton2";
            this.btnLayerSave.ToolTipText = "保存";
            // 
            // btnLayerDelete
            // 
            this.btnLayerDelete.DisplayName = "commandBarButton3";
            this.btnLayerDelete.Image = global::PCBQuotes.Properties.Resources.Delete_18px;
            this.btnLayerDelete.Name = "btnLayerDelete";
            this.btnLayerDelete.Text = "commandBarButton3";
            this.btnLayerDelete.ToolTipText = "删除";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.gvLayer, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(328, 376);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReLoad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 34);
            this.panel2.TabIndex = 1;
            // 
            // btnReLoad
            // 
            this.btnReLoad.Image = global::PCBQuotes.Properties.Resources.Refresh_18px;
            this.btnReLoad.Location = new System.Drawing.Point(4, 7);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(110, 24);
            this.btnReLoad.TabIndex = 0;
            this.btnReLoad.Text = "加载";
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(112F, 28F);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(665, 376);
            this.radPageViewPage1.Text = "radPageViewPage1";
            // 
            // waitBarLayerGrid
            // 
            this.waitBarLayerGrid.AssociatedControl = this.gvLayer;
            this.waitBarLayerGrid.Location = new System.Drawing.Point(106, 54);
            this.waitBarLayerGrid.Name = "waitBarLayerGrid";
            this.waitBarLayerGrid.Size = new System.Drawing.Size(70, 70);
            this.waitBarLayerGrid.TabIndex = 1;
            this.waitBarLayerGrid.Text = "radWaitingBar1";
            this.waitBarLayerGrid.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement1);
            this.waitBarLayerGrid.WaitingSpeed = 50;
            this.waitBarLayerGrid.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            // 
            // btnLayerCancel
            // 
            this.btnLayerCancel.DisplayName = "commandBarButton1";
            this.btnLayerCancel.Image = global::PCBQuotes.Properties.Resources.Cancel_18px;
            this.btnLayerCancel.Name = "btnLayerCancel";
            this.btnLayerCancel.Text = "commandBarButton1";
            this.btnLayerCancel.ToolTipText = "取消";
            // 
            // BaseParaSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BaseParaSettingForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "BaseParaSettingForm1";
            ((System.ComponentModel.ISupportInitialize)(this.pvSetting)).EndInit();
            this.pvSetting.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.pvpLayerSetting.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLayer.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLayer)).EndInit();
            this.gvLayer.ResumeLayout(false);
            this.gvLayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deLayer)).EndInit();
            this.deLayer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnReLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitBarLayerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pvSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadPageViewPage pvpLayerSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.RadGridView gvLayer;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Telerik.WinControls.UI.RadDataEntry deLayer;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton btnLayerAdd;
        private Telerik.WinControls.UI.CommandBarButton btnLayerSave;
        private Telerik.WinControls.UI.CommandBarButton btnLayerDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton btnReLoad;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadWaitingBar waitBarLayerGrid;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.CommandBarButton btnLayerCancel;
    }
}
