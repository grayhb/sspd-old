namespace SSPD.ObjectsTN
{
    partial class List
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(List));
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.StrFind = new System.Windows.Forms.ToolStripTextBox();
            this.btn_Search = new System.Windows.Forms.ToolStripButton();
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSepor1 = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.МенюОбъекты = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnView = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnCollapseOST = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnCollapseRNU = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnCollapseLPDS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnExpandeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeObj = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            this.lblLegendaPrjVsp = new System.Windows.Forms.Label();
            this.lblLegendaVsp = new System.Windows.Forms.Label();
            this.lblLegendaPrj = new System.Windows.Forms.Label();
            this.BottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.CntMNLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntRNULabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntLPDSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntPlaceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TopToolStrip.SuspendLayout();
            this.TopMenu.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).BeginInit();
            this.BottomStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StrFind,
            this.btn_Search});
            this.TopToolStrip.Location = new System.Drawing.Point(0, 24);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.Padding = new System.Windows.Forms.Padding(0, 5, 1, 5);
            this.TopToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TopToolStrip.ShowItemToolTips = false;
            this.TopToolStrip.Size = new System.Drawing.Size(782, 33);
            this.TopToolStrip.TabIndex = 9;
            this.TopToolStrip.Text = "toolStrip1";
            // 
            // StrFind
            // 
            this.StrFind.ForeColor = System.Drawing.Color.DarkGray;
            this.StrFind.Margin = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.StrFind.MaxLength = 255;
            this.StrFind.Name = "StrFind";
            this.StrFind.Size = new System.Drawing.Size(300, 23);
            this.StrFind.Text = "Введите строку для поиска";
            // 
            // btn_Search
            // 
            this.btn_Search.Image = global::SSPD.Properties.Resources.binocular_small;
            this.btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Search.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(80, 20);
            this.btn_Search.Text = "найти [F7]";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // TopMenu
            // 
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операцииToolStripMenuItem,
            this.МенюОбъекты,
            this.mbtnView});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(782, 24);
            this.TopMenu.TabIndex = 8;
            this.TopMenu.Text = "menuStrip1";
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnSelect,
            this.mbtnSepor1,
            this.mbtnClose});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // mbtnSelect
            // 
            this.mbtnSelect.Name = "mbtnSelect";
            this.mbtnSelect.Size = new System.Drawing.Size(155, 22);
            this.mbtnSelect.Text = "Выбрать";
            this.mbtnSelect.Visible = false;
            this.mbtnSelect.Click += new System.EventHandler(this.mbtnSelect_Click);
            // 
            // mbtnSepor1
            // 
            this.mbtnSepor1.Name = "mbtnSepor1";
            this.mbtnSepor1.Size = new System.Drawing.Size(152, 6);
            this.mbtnSepor1.Visible = false;
            // 
            // mbtnClose
            // 
            this.mbtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mbtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mbtnClose.Name = "mbtnClose";
            this.mbtnClose.ShortcutKeyDisplayString = "ESC";
            this.mbtnClose.Size = new System.Drawing.Size(155, 22);
            this.mbtnClose.Text = "Закрыть";
            this.mbtnClose.Click += new System.EventHandler(this.mbtnClose_Click);
            // 
            // МенюОбъекты
            // 
            this.МенюОбъекты.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnExplorer,
            this.mbtnFiles,
            this.toolStripSeparator2,
            this.mbtnAdd,
            this.mbtnEdit,
            this.mbtnDel});
            this.МенюОбъекты.Name = "МенюОбъекты";
            this.МенюОбъекты.Size = new System.Drawing.Size(66, 20);
            this.МенюОбъекты.Text = "Объекты";
            // 
            // mbtnExplorer
            // 
            this.mbtnExplorer.Name = "mbtnExplorer";
            this.mbtnExplorer.Size = new System.Drawing.Size(226, 22);
            this.mbtnExplorer.Text = "Проводник объекта";
            this.mbtnExplorer.Click += new System.EventHandler(this.mbtnExplorer_Click);
            // 
            // mbtnFiles
            // 
            this.mbtnFiles.Name = "mbtnFiles";
            this.mbtnFiles.Size = new System.Drawing.Size(226, 22);
            this.mbtnFiles.Text = "Вспомогательный материал";
            this.mbtnFiles.Click += new System.EventHandler(this.mbtnFiles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // mbtnAdd
            // 
            this.mbtnAdd.Name = "mbtnAdd";
            this.mbtnAdd.Size = new System.Drawing.Size(226, 22);
            this.mbtnAdd.Text = "Добавить";
            this.mbtnAdd.Click += new System.EventHandler(this.mbtnAdd_Click);
            // 
            // mbtnEdit
            // 
            this.mbtnEdit.Name = "mbtnEdit";
            this.mbtnEdit.Size = new System.Drawing.Size(226, 22);
            this.mbtnEdit.Text = "Изменить";
            this.mbtnEdit.Click += new System.EventHandler(this.mbtnEdit_Click);
            // 
            // mbtnDel
            // 
            this.mbtnDel.Name = "mbtnDel";
            this.mbtnDel.Size = new System.Drawing.Size(226, 22);
            this.mbtnDel.Text = "Удалить";
            this.mbtnDel.Click += new System.EventHandler(this.mbtnDel_Click);
            // 
            // mbtnView
            // 
            this.mbtnView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnCollapseOST,
            this.mbtnCollapseRNU,
            this.mbtnCollapseLPDS,
            this.toolStripSeparator1,
            this.mbtnExpandeAll});
            this.mbtnView.Name = "mbtnView";
            this.mbtnView.Size = new System.Drawing.Size(38, 20);
            this.mbtnView.Text = "Вид";
            // 
            // mbtnCollapseOST
            // 
            this.mbtnCollapseOST.Name = "mbtnCollapseOST";
            this.mbtnCollapseOST.Size = new System.Drawing.Size(199, 22);
            this.mbtnCollapseOST.Text = "Свернуть ветки ОСТ";
            this.mbtnCollapseOST.Click += new System.EventHandler(this.свернутьВеткиМНToolStripMenuItem_Click);
            // 
            // mbtnCollapseRNU
            // 
            this.mbtnCollapseRNU.Name = "mbtnCollapseRNU";
            this.mbtnCollapseRNU.Size = new System.Drawing.Size(199, 22);
            this.mbtnCollapseRNU.Text = "Свернуть ветки РНУ";
            this.mbtnCollapseRNU.Click += new System.EventHandler(this.свернутьВеткиРНУToolStripMenuItem_Click);
            // 
            // mbtnCollapseLPDS
            // 
            this.mbtnCollapseLPDS.Name = "mbtnCollapseLPDS";
            this.mbtnCollapseLPDS.Size = new System.Drawing.Size(199, 22);
            this.mbtnCollapseLPDS.Text = "Свернуть ветки ЛПДС";
            this.mbtnCollapseLPDS.Click += new System.EventHandler(this.свернутьВеткиЛПДСToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // mbtnExpandeAll
            // 
            this.mbtnExpandeAll.Name = "mbtnExpandeAll";
            this.mbtnExpandeAll.Size = new System.Drawing.Size(199, 22);
            this.mbtnExpandeAll.Text = "Раскрыть все";
            this.mbtnExpandeAll.Click += new System.EventHandler(this.раскрытьВсеToolStripMenuItem_Click);
            // 
            // TreeObj
            // 
            this.TreeObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeObj.HideSelection = false;
            this.TreeObj.HotTracking = true;
            this.TreeObj.ImageIndex = 0;
            this.TreeObj.ImageList = this.imageList1;
            this.TreeObj.Indent = 40;
            this.TreeObj.ItemHeight = 18;
            this.TreeObj.Location = new System.Drawing.Point(0, 57);
            this.TreeObj.Name = "TreeObj";
            this.TreeObj.SelectedImageIndex = 0;
            this.TreeObj.Size = new System.Drawing.Size(782, 463);
            this.TreeObj.TabIndex = 11;
            this.TreeObj.DoubleClick += new System.EventHandler(this.TreeObj_DoubleClick);
            this.TreeObj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TreeObj_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "building.gif");
            this.imageList1.Images.SetKeyName(1, "chart_organisation.gif");
            this.imageList1.Images.SetKeyName(2, "chart_organisation_delete.gif");
            this.imageList1.Images.SetKeyName(3, "brick.gif");
            this.imageList1.Images.SetKeyName(4, "brick_delete.gif");
            this.imageList1.Images.SetKeyName(5, "database.gif");
            this.imageList1.Images.SetKeyName(6, "database_delete.gif");
            this.imageList1.Images.SetKeyName(7, "database_prj.png");
            this.imageList1.Images.SetKeyName(8, "database_files.png");
            this.imageList1.Images.SetKeyName(9, "database_prj_files.png");
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.LineSeparatorBottom);
            this.BottomPanel.Controls.Add(this.lblLegendaPrjVsp);
            this.BottomPanel.Controls.Add(this.lblLegendaVsp);
            this.BottomPanel.Controls.Add(this.lblLegendaPrj);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 520);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(782, 35);
            this.BottomPanel.TabIndex = 12;
            // 
            // LineSeparatorBottom
            // 
            this.LineSeparatorBottom.BackgroundImage = global::SSPD.Properties.Resources.LineSeparator;
            this.LineSeparatorBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.LineSeparatorBottom.Location = new System.Drawing.Point(0, 0);
            this.LineSeparatorBottom.Name = "LineSeparatorBottom";
            this.LineSeparatorBottom.Size = new System.Drawing.Size(782, 2);
            this.LineSeparatorBottom.TabIndex = 27;
            this.LineSeparatorBottom.TabStop = false;
            // 
            // lblLegendaPrjVsp
            // 
            this.lblLegendaPrjVsp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLegendaPrjVsp.ImageIndex = 9;
            this.lblLegendaPrjVsp.ImageList = this.imageList1;
            this.lblLegendaPrjVsp.Location = new System.Drawing.Point(453, 6);
            this.lblLegendaPrjVsp.Name = "lblLegendaPrjVsp";
            this.lblLegendaPrjVsp.Size = new System.Drawing.Size(317, 23);
            this.lblLegendaPrjVsp.TabIndex = 3;
            this.lblLegendaPrjVsp.Text = "Есть связанные проекты и вспомогательный материал";
            this.lblLegendaPrjVsp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLegendaVsp
            // 
            this.lblLegendaVsp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLegendaVsp.ImageIndex = 8;
            this.lblLegendaVsp.ImageList = this.imageList1;
            this.lblLegendaVsp.Location = new System.Drawing.Point(208, 6);
            this.lblLegendaVsp.Name = "lblLegendaVsp";
            this.lblLegendaVsp.Size = new System.Drawing.Size(204, 23);
            this.lblLegendaVsp.TabIndex = 2;
            this.lblLegendaVsp.Text = "Есть вспомогательный материал";
            this.lblLegendaVsp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLegendaPrj
            // 
            this.lblLegendaPrj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLegendaPrj.ImageIndex = 7;
            this.lblLegendaPrj.ImageList = this.imageList1;
            this.lblLegendaPrj.Location = new System.Drawing.Point(12, 6);
            this.lblLegendaPrj.Name = "lblLegendaPrj";
            this.lblLegendaPrj.Size = new System.Drawing.Size(151, 23);
            this.lblLegendaPrj.TabIndex = 1;
            this.lblLegendaPrj.Text = "Есть связь с проектом";
            this.lblLegendaPrj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BottomStatusStrip
            // 
            this.BottomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CntMNLabel,
            this.CntRNULabel,
            this.CntLPDSLabel,
            this.CntPlaceLabel});
            this.BottomStatusStrip.Location = new System.Drawing.Point(0, 555);
            this.BottomStatusStrip.Name = "BottomStatusStrip";
            this.BottomStatusStrip.Size = new System.Drawing.Size(782, 22);
            this.BottomStatusStrip.TabIndex = 13;
            this.BottomStatusStrip.Text = "statusStrip1";
            // 
            // CntMNLabel
            // 
            this.CntMNLabel.Name = "CntMNLabel";
            this.CntMNLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CntMNLabel.Size = new System.Drawing.Size(20, 17);
            // 
            // CntRNULabel
            // 
            this.CntRNULabel.Name = "CntRNULabel";
            this.CntRNULabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CntRNULabel.Size = new System.Drawing.Size(20, 17);
            // 
            // CntLPDSLabel
            // 
            this.CntLPDSLabel.Name = "CntLPDSLabel";
            this.CntLPDSLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CntLPDSLabel.Size = new System.Drawing.Size(20, 17);
            // 
            // CntPlaceLabel
            // 
            this.CntPlaceLabel.Name = "CntPlaceLabel";
            this.CntPlaceLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CntPlaceLabel.Size = new System.Drawing.Size(20, 17);
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 577);
            this.Controls.Add(this.TreeObj);
            this.Controls.Add(this.TopToolStrip);
            this.Controls.Add(this.TopMenu);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.BottomStatusStrip);
            this.KeyPreview = true;
            this.Name = "List";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник объектов КТН";
            this.Load += new System.EventHandler(this.List_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.List_KeyDown);
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.BottomStatusStrip.ResumeLayout(false);
            this.BottomStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ToolStripTextBox StrFind;
        private System.Windows.Forms.ToolStripButton btn_Search;
        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtnClose;
        private System.Windows.Forms.ToolStripMenuItem МенюОбъекты;
        private System.Windows.Forms.ToolStripMenuItem mbtnAdd;
        private System.Windows.Forms.ToolStripMenuItem mbtnEdit;
        private System.Windows.Forms.ToolStripMenuItem mbtnDel;
        private System.Windows.Forms.TreeView TreeObj;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label lblLegendaPrjVsp;
        private System.Windows.Forms.Label lblLegendaVsp;
        private System.Windows.Forms.Label lblLegendaPrj;
        private System.Windows.Forms.PictureBox LineSeparatorBottom;
        private System.Windows.Forms.StatusStrip BottomStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel CntMNLabel;
        private System.Windows.Forms.ToolStripStatusLabel CntRNULabel;
        private System.Windows.Forms.ToolStripStatusLabel CntLPDSLabel;
        private System.Windows.Forms.ToolStripStatusLabel CntPlaceLabel;
        private System.Windows.Forms.ToolStripMenuItem mbtnView;
        private System.Windows.Forms.ToolStripMenuItem mbtnCollapseOST;
        private System.Windows.Forms.ToolStripMenuItem mbtnCollapseRNU;
        private System.Windows.Forms.ToolStripMenuItem mbtnCollapseLPDS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mbtnExpandeAll;
        private System.Windows.Forms.ToolStripMenuItem mbtnExplorer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mbtnFiles;
        private System.Windows.Forms.ToolStripMenuItem mbtnSelect;
        private System.Windows.Forms.ToolStripSeparator mbtnSepor1;
    }
}