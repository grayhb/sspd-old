namespace SSPD.ObjectsTN
{
    partial class FileList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.StrFind = new System.Windows.Forms.ToolStripTextBox();
            this.btn_Search = new System.Windows.Forms.ToolStripButton();
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.mbtnOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFileCard = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSepor2 = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnFileAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFileDel = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFilterObj = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFilterWorker = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFilterType = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnFilterName = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSepor1 = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnFilterNone = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmbtnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbtnCard = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.CntMNLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntRNULabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntLPDSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntPlaceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TopToolStrip.SuspendLayout();
            this.TopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.contextMenu.SuspendLayout();
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
            this.TopToolStrip.Size = new System.Drawing.Size(952, 33);
            this.TopToolStrip.TabIndex = 11;
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
            this.mbtnOperation,
            this.mbtnFile,
            this.mbtnFilter});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(952, 24);
            this.TopMenu.TabIndex = 10;
            this.TopMenu.Text = "menuStrip1";
            // 
            // mbtnOperation
            // 
            this.mbtnOperation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mbtnOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnClose});
            this.mbtnOperation.Name = "mbtnOperation";
            this.mbtnOperation.Size = new System.Drawing.Size(69, 20);
            this.mbtnOperation.Text = "Операции";
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
            // mbtnFile
            // 
            this.mbtnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnFileOpen,
            this.mbtnFileCard,
            this.mbtnSepor2,
            this.mbtnFileAdd,
            this.mbtnFileDel});
            this.mbtnFile.Name = "mbtnFile";
            this.mbtnFile.Size = new System.Drawing.Size(69, 20);
            this.mbtnFile.Text = "Материал";
            // 
            // mbtnFileOpen
            // 
            this.mbtnFileOpen.Name = "mbtnFileOpen";
            this.mbtnFileOpen.Size = new System.Drawing.Size(192, 22);
            this.mbtnFileOpen.Text = "Открыть";
            this.mbtnFileOpen.Click += new System.EventHandler(this.mbtnFileOpen_Click);
            // 
            // mbtnFileCard
            // 
            this.mbtnFileCard.Name = "mbtnFileCard";
            this.mbtnFileCard.Size = new System.Drawing.Size(192, 22);
            this.mbtnFileCard.Text = "Карточка документа";
            this.mbtnFileCard.Click += new System.EventHandler(this.mbtnFileCard_Click);
            // 
            // mbtnSepor2
            // 
            this.mbtnSepor2.Name = "mbtnSepor2";
            this.mbtnSepor2.Size = new System.Drawing.Size(189, 6);
            // 
            // mbtnFileAdd
            // 
            this.mbtnFileAdd.Name = "mbtnFileAdd";
            this.mbtnFileAdd.Size = new System.Drawing.Size(192, 22);
            this.mbtnFileAdd.Text = "Добавить";
            this.mbtnFileAdd.Click += new System.EventHandler(this.mbtnFileAdd_Click);
            // 
            // mbtnFileDel
            // 
            this.mbtnFileDel.Name = "mbtnFileDel";
            this.mbtnFileDel.Size = new System.Drawing.Size(192, 22);
            this.mbtnFileDel.Text = "Удалить";
            // 
            // mbtnFilter
            // 
            this.mbtnFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnFilterObj,
            this.mbtnFilterWorker,
            this.mbtnFilterType,
            this.mbtnFilterName,
            this.mbtnSepor1,
            this.mbtnFilterNone});
            this.mbtnFilter.Name = "mbtnFilter";
            this.mbtnFilter.Size = new System.Drawing.Size(57, 20);
            this.mbtnFilter.Text = "Фильтр";
            // 
            // mbtnFilterObj
            // 
            this.mbtnFilterObj.Name = "mbtnFilterObj";
            this.mbtnFilterObj.Size = new System.Drawing.Size(245, 22);
            this.mbtnFilterObj.Text = "По объекту";
            this.mbtnFilterObj.Click += new System.EventHandler(this.mbtnFilterObj_Click);
            // 
            // mbtnFilterWorker
            // 
            this.mbtnFilterWorker.Name = "mbtnFilterWorker";
            this.mbtnFilterWorker.Size = new System.Drawing.Size(245, 22);
            this.mbtnFilterWorker.Text = "Материал добавил";
            // 
            // mbtnFilterType
            // 
            this.mbtnFilterType.Name = "mbtnFilterType";
            this.mbtnFilterType.Size = new System.Drawing.Size(245, 22);
            this.mbtnFilterType.Text = "Тип материал";
            // 
            // mbtnFilterName
            // 
            this.mbtnFilterName.Name = "mbtnFilterName";
            this.mbtnFilterName.Size = new System.Drawing.Size(245, 22);
            this.mbtnFilterName.Text = "По вхождению в наименование";
            this.mbtnFilterName.Click += new System.EventHandler(this.mbtnFilterName_Click);
            // 
            // mbtnSepor1
            // 
            this.mbtnSepor1.Name = "mbtnSepor1";
            this.mbtnSepor1.Size = new System.Drawing.Size(242, 6);
            // 
            // mbtnFilterNone
            // 
            this.mbtnFilterNone.Name = "mbtnFilterNone";
            this.mbtnFilterNone.Size = new System.Drawing.Size(245, 22);
            this.mbtnFilterNone.Text = "Отсутствует";
            this.mbtnFilterNone.Click += new System.EventHandler(this.mbtnFilterNone_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV.ColumnHeadersHeight = 20;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.DGV.ContextMenuStrip = this.contextMenu;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV.Location = new System.Drawing.Point(0, 57);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowTemplate.Height = 20;
            this.DGV.RowTemplate.ReadOnly = true;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(952, 594);
            this.DGV.TabIndex = 12;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.Sorted += new System.EventHandler(this.DGV_Sorted);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Рег. номер";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 75;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Наименование материала";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Тип материала";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Объект";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Организация источник";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Добавил";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 75;
            // 
            // Column7
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column7.HeaderText = "Дата добавления";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 115;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "CRC";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbtnOpen,
            this.cmbtnCard});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(192, 48);
            // 
            // cmbtnOpen
            // 
            this.cmbtnOpen.Name = "cmbtnOpen";
            this.cmbtnOpen.Size = new System.Drawing.Size(191, 22);
            this.cmbtnOpen.Text = "Открыть";
            this.cmbtnOpen.Click += new System.EventHandler(this.cmbtnOpen_Click);
            // 
            // cmbtnCard
            // 
            this.cmbtnCard.Name = "cmbtnCard";
            this.cmbtnCard.Size = new System.Drawing.Size(191, 22);
            this.cmbtnCard.Text = "Карточка материала";
            this.cmbtnCard.Click += new System.EventHandler(this.cmbtnCard_Click);
            // 
            // BottomStatusStrip
            // 
            this.BottomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CntMNLabel,
            this.CntRNULabel,
            this.CntLPDSLabel,
            this.CntPlaceLabel});
            this.BottomStatusStrip.Location = new System.Drawing.Point(0, 651);
            this.BottomStatusStrip.Name = "BottomStatusStrip";
            this.BottomStatusStrip.Size = new System.Drawing.Size(952, 22);
            this.BottomStatusStrip.TabIndex = 14;
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
            // FileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 673);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.BottomStatusStrip);
            this.Controls.Add(this.TopToolStrip);
            this.Controls.Add(this.TopMenu);
            this.KeyPreview = true;
            this.Name = "FileList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Материалы к объектам";
            this.Load += new System.EventHandler(this.FileList_Load);
            this.SizeChanged += new System.EventHandler(this.FileList_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileList_KeyDown);
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.contextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem mbtnOperation;
        private System.Windows.Forms.ToolStripMenuItem mbtnClose;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.StatusStrip BottomStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel CntMNLabel;
        private System.Windows.Forms.ToolStripStatusLabel CntRNULabel;
        private System.Windows.Forms.ToolStripStatusLabel CntLPDSLabel;
        private System.Windows.Forms.ToolStripStatusLabel CntPlaceLabel;
        private System.Windows.Forms.ToolStripMenuItem mbtnFilter;
        private System.Windows.Forms.ToolStripMenuItem mbtnFilterObj;
        private System.Windows.Forms.ToolStripMenuItem mbtnFilterWorker;
        private System.Windows.Forms.ToolStripMenuItem mbtnFilterType;
        private System.Windows.Forms.ToolStripMenuItem mbtnFilterName;
        private System.Windows.Forms.ToolStripSeparator mbtnSepor1;
        private System.Windows.Forms.ToolStripMenuItem mbtnFilterNone;
        private System.Windows.Forms.ToolStripMenuItem mbtnFile;
        private System.Windows.Forms.ToolStripMenuItem mbtnFileAdd;
        private System.Windows.Forms.ToolStripMenuItem mbtnFileDel;
        private System.Windows.Forms.ToolStripMenuItem mbtnFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mbtnFileCard;
        private System.Windows.Forms.ToolStripSeparator mbtnSepor2;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmbtnOpen;
        private System.Windows.Forms.ToolStripMenuItem cmbtnCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}