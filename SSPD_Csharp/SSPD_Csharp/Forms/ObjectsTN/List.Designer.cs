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
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.МенюОбъекты = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВеткиМНToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВеткиРНУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВеткиЛПДСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.раскрытьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeObj = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.BottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.CntMNLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntRNULabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntLPDSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntPlaceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_Search = new System.Windows.Forms.ToolStripButton();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            this.lblLegendaPrjVsp = new System.Windows.Forms.Label();
            this.lblLegendaVsp = new System.Windows.Forms.Label();
            this.lblLegendaPrj = new System.Windows.Forms.Label();
            this.проводникОбъектаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TopToolStrip.SuspendLayout();
            this.TopMenu.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.BottomStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).BeginInit();
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
            // TopMenu
            // 
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операцииToolStripMenuItem,
            this.МенюОбъекты,
            this.видToolStripMenuItem});
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
            this.выходToolStripMenuItem});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.выходToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.выходToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeyDisplayString = "ESC";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.выходToolStripMenuItem.Text = "Закрыть";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // МенюОбъекты
            // 
            this.МенюОбъекты.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проводникОбъектаToolStripMenuItem,
            this.toolStripSeparator2,
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.МенюОбъекты.Name = "МенюОбъекты";
            this.МенюОбъекты.Size = new System.Drawing.Size(66, 20);
            this.МенюОбъекты.Text = "Объекты";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.свернутьВеткиМНToolStripMenuItem,
            this.свернутьВеткиРНУToolStripMenuItem,
            this.свернутьВеткиЛПДСToolStripMenuItem,
            this.toolStripSeparator1,
            this.раскрытьВсеToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // свернутьВеткиМНToolStripMenuItem
            // 
            this.свернутьВеткиМНToolStripMenuItem.Name = "свернутьВеткиМНToolStripMenuItem";
            this.свернутьВеткиМНToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.свернутьВеткиМНToolStripMenuItem.Text = "Свернуть ветки ОСТ";
            this.свернутьВеткиМНToolStripMenuItem.Click += new System.EventHandler(this.свернутьВеткиМНToolStripMenuItem_Click);
            // 
            // свернутьВеткиРНУToolStripMenuItem
            // 
            this.свернутьВеткиРНУToolStripMenuItem.Name = "свернутьВеткиРНУToolStripMenuItem";
            this.свернутьВеткиРНУToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.свернутьВеткиРНУToolStripMenuItem.Text = "Свернуть ветки РНУ";
            this.свернутьВеткиРНУToolStripMenuItem.Click += new System.EventHandler(this.свернутьВеткиРНУToolStripMenuItem_Click);
            // 
            // свернутьВеткиЛПДСToolStripMenuItem
            // 
            this.свернутьВеткиЛПДСToolStripMenuItem.Name = "свернутьВеткиЛПДСToolStripMenuItem";
            this.свернутьВеткиЛПДСToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.свернутьВеткиЛПДСToolStripMenuItem.Text = "Свернуть ветки ЛПДС";
            this.свернутьВеткиЛПДСToolStripMenuItem.Click += new System.EventHandler(this.свернутьВеткиЛПДСToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // раскрытьВсеToolStripMenuItem
            // 
            this.раскрытьВсеToolStripMenuItem.Name = "раскрытьВсеToolStripMenuItem";
            this.раскрытьВсеToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.раскрытьВсеToolStripMenuItem.Text = "Раскрыть все";
            this.раскрытьВсеToolStripMenuItem.Click += new System.EventHandler(this.раскрытьВсеToolStripMenuItem_Click);
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
            // проводникОбъектаToolStripMenuItem
            // 
            this.проводникОбъектаToolStripMenuItem.Name = "проводникОбъектаToolStripMenuItem";
            this.проводникОбъектаToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.проводникОбъектаToolStripMenuItem.Text = "Проводник объекта";
            this.проводникОбъектаToolStripMenuItem.Click += new System.EventHandler(this.проводникОбъектаToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
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
            this.BottomStatusStrip.ResumeLayout(false);
            this.BottomStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ToolStripTextBox StrFind;
        private System.Windows.Forms.ToolStripButton btn_Search;
        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem МенюОбъекты;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВеткиМНToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВеткиРНУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВеткиЛПДСToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem раскрытьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проводникОбъектаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}