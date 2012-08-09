namespace SSPD
{
    partial class WorkersSpravEdit
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
            this.BottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mbtnOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnData = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnDataAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnDataEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.StrFind = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.StatusFilter = new System.Windows.Forms.ToolStripComboBox();
            this.lblStatusFilter = new System.Windows.Forms.ToolStripLabel();
            this.BottomStatusStrip.SuspendLayout();
            this.TopMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.TopToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomStatusStrip
            // 
            this.BottomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.BottomStatusStrip.Location = new System.Drawing.Point(0, 491);
            this.BottomStatusStrip.Name = "BottomStatusStrip";
            this.BottomStatusStrip.Size = new System.Drawing.Size(952, 22);
            this.BottomStatusStrip.TabIndex = 0;
            this.BottomStatusStrip.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(111, 17);
            this.StatusLabel.Text = "Всего работников: 0";
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnOperation,
            this.mbtnData});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Size = new System.Drawing.Size(952, 24);
            this.TopMenuStrip.TabIndex = 1;
            this.TopMenuStrip.Text = "menuStrip1";
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
            // mbtnData
            // 
            this.mbtnData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnDataAdd,
            this.mbtnDataEdit});
            this.mbtnData.Name = "mbtnData";
            this.mbtnData.Size = new System.Drawing.Size(54, 20);
            this.mbtnData.Text = "Записи";
            // 
            // mbtnDataAdd
            // 
            this.mbtnDataAdd.Name = "mbtnDataAdd";
            this.mbtnDataAdd.Size = new System.Drawing.Size(135, 22);
            this.mbtnDataAdd.Text = "Добавить";
            this.mbtnDataAdd.Click += new System.EventHandler(this.mbtnDataAdd_Click);
            // 
            // mbtnDataEdit
            // 
            this.mbtnDataEdit.Name = "mbtnDataEdit";
            this.mbtnDataEdit.Size = new System.Drawing.Size(135, 22);
            this.mbtnDataEdit.Text = "Изменить";
            this.mbtnDataEdit.Click += new System.EventHandler(this.mbtnDataEdit_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV.ColumnHeadersHeight = 20;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
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
            this.DGV.Size = new System.Drawing.Size(952, 434);
            this.DGV.TabIndex = 2;
            this.DGV.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_CellMouseDoubleClick);
            this.DGV.Sorted += new System.EventHandler(this.DGV_Sorted);
            this.DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyDown);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Фамилия, имя, отчество";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Должность";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 313;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Отдел";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Статус";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 75;
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StrFind,
            this.btnSearch,
            this.StatusFilter,
            this.lblStatusFilter});
            this.TopToolStrip.Location = new System.Drawing.Point(0, 24);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.Padding = new System.Windows.Forms.Padding(0, 5, 1, 5);
            this.TopToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TopToolStrip.ShowItemToolTips = false;
            this.TopToolStrip.Size = new System.Drawing.Size(952, 33);
            this.TopToolStrip.TabIndex = 3;
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
            this.StrFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StrFind_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SSPD.Properties.Resources.binocular_small;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 20);
            this.btnSearch.Text = "найти [F7]";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // StatusFilter
            // 
            this.StatusFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusFilter.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.StatusFilter.Margin = new System.Windows.Forms.Padding(1, 0, 5, 0);
            this.StatusFilter.Name = "StatusFilter";
            this.StatusFilter.Size = new System.Drawing.Size(121, 23);
            this.StatusFilter.SelectedIndexChanged += new System.EventHandler(this.StatusFilter_SelectedIndexChanged);
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(154, 20);
            this.lblStatusFilter.Text = "Отфильтровать по статусу: ";
            // 
            // WorkersSpravEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 513);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.BottomStatusStrip);
            this.Controls.Add(this.TopToolStrip);
            this.Controls.Add(this.TopMenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.TopMenuStrip;
            this.MinimumSize = new System.Drawing.Size(860, 194);
            this.Name = "WorkersSpravEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование сотрудников";
            this.Load += new System.EventHandler(this.WorkersSpravEdit_Load);
            this.SizeChanged += new System.EventHandler(this.WorkersSpravEdit_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WorkersSpravEdit_KeyDown);
            this.BottomStatusStrip.ResumeLayout(false);
            this.BottomStatusStrip.PerformLayout();
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip BottomStatusStrip;
        private System.Windows.Forms.MenuStrip TopMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mbtnOperation;
        private System.Windows.Forms.ToolStripMenuItem mbtnClose;
        private System.Windows.Forms.ToolStripMenuItem mbtnData;
        private System.Windows.Forms.ToolStripMenuItem mbtnDataAdd;
        private System.Windows.Forms.ToolStripMenuItem mbtnDataEdit;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ToolStripTextBox StrFind;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripComboBox StatusFilter;
        private System.Windows.Forms.ToolStripLabel lblStatusFilter;

    }
}