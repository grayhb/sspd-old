namespace SSPD
{
    partial class PhoneIPList
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
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.StrFind = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.mbtnOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnData = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnDataAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnDataDel = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.btnClose = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDataAdd = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDataDel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDataSelect = new System.Windows.Forms.ToolStripStatusLabel();
            this.TopToolStrip.SuspendLayout();
            this.TopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.BottomStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StrFind,
            this.btnSearch});
            this.TopToolStrip.Location = new System.Drawing.Point(0, 24);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.Padding = new System.Windows.Forms.Padding(0, 5, 1, 5);
            this.TopToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TopToolStrip.ShowItemToolTips = false;
            this.TopToolStrip.Size = new System.Drawing.Size(952, 33);
            this.TopToolStrip.TabIndex = 8;
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
            // 
            // TopMenu
            // 
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnOperation,
            this.mbtnData});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(952, 24);
            this.TopMenu.TabIndex = 9;
            this.TopMenu.Text = "menuStrip1";
            // 
            // mbtnOperation
            // 
            this.mbtnOperation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mbtnOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnSelect,
            this.toolStripSeparator1,
            this.mbtnClose});
            this.mbtnOperation.Name = "mbtnOperation";
            this.mbtnOperation.Size = new System.Drawing.Size(69, 20);
            this.mbtnOperation.Text = "Операции";
            // 
            // mbtnSelect
            // 
            this.mbtnSelect.Name = "mbtnSelect";
            this.mbtnSelect.Size = new System.Drawing.Size(155, 22);
            this.mbtnSelect.Text = "Выбрать";
            this.mbtnSelect.Click += new System.EventHandler(this.mbtnSelect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
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
            this.mbtnDataDel});
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
            // mbtnDataDel
            // 
            this.mbtnDataDel.Name = "mbtnDataDel";
            this.mbtnDataDel.Size = new System.Drawing.Size(135, 22);
            this.mbtnDataDel.Text = "Удалить";
            this.mbtnDataDel.Click += new System.EventHandler(this.mbtnDataDel_Click);
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
            this.DGV.Size = new System.Drawing.Size(952, 391);
            this.DGV.TabIndex = 10;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Номер IPPhone";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Фамилия, инициалы";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 31.91489F;
            this.Column3.HeaderText = "Отдел";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 31.91489F;
            this.Column4.HeaderText = "Должность";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // BottomStatusStrip
            // 
            this.BottomStatusStrip.AutoSize = false;
            this.BottomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnDataAdd,
            this.btnDataDel,
            this.btnDataSelect});
            this.BottomStatusStrip.Location = new System.Drawing.Point(0, 448);
            this.BottomStatusStrip.Name = "BottomStatusStrip";
            this.BottomStatusStrip.Size = new System.Drawing.Size(952, 25);
            this.BottomStatusStrip.TabIndex = 11;
            this.BottomStatusStrip.Text = "statusStrip1";
            // 
            // btnClose
            // 
            this.btnClose.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.btnClose.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClose.Size = new System.Drawing.Size(95, 22);
            this.btnClose.Text = "Закрыть [ESC]";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDataAdd
            // 
            this.btnDataAdd.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.btnDataAdd.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.btnDataAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDataAdd.Margin = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.btnDataAdd.Name = "btnDataAdd";
            this.btnDataAdd.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnDataAdd.Size = new System.Drawing.Size(99, 22);
            this.btnDataAdd.Text = "Добавить [INS]";
            this.btnDataAdd.Click += new System.EventHandler(this.btnDataAdd_Click);
            // 
            // btnDataDel
            // 
            this.btnDataDel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.btnDataDel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.btnDataDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDataDel.Margin = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.btnDataDel.Name = "btnDataDel";
            this.btnDataDel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnDataDel.Size = new System.Drawing.Size(94, 22);
            this.btnDataDel.Text = "Удалить [DEL]";
            this.btnDataDel.Click += new System.EventHandler(this.btnDataDel_Click);
            // 
            // btnDataSelect
            // 
            this.btnDataSelect.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.btnDataSelect.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.btnDataSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDataSelect.Margin = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.btnDataSelect.Name = "btnDataSelect";
            this.btnDataSelect.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnDataSelect.Size = new System.Drawing.Size(108, 22);
            this.btnDataSelect.Text = "Выбрать [ENTER]";
            this.btnDataSelect.Click += new System.EventHandler(this.btnDataSelect_Click);
            // 
            // PhoneIPList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 473);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.BottomStatusStrip);
            this.Controls.Add(this.TopToolStrip);
            this.Controls.Add(this.TopMenu);
            this.KeyPreview = true;
            this.Name = "PhoneIPList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список IP номеров";
            this.Load += new System.EventHandler(this.PhoneIPList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PhoneIPList_KeyDown);
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.BottomStatusStrip.ResumeLayout(false);
            this.BottomStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ToolStripTextBox StrFind;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem mbtnOperation;
        private System.Windows.Forms.ToolStripMenuItem mbtnSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mbtnClose;
        private System.Windows.Forms.ToolStripMenuItem mbtnData;
        private System.Windows.Forms.ToolStripMenuItem mbtnDataAdd;
        private System.Windows.Forms.ToolStripMenuItem mbtnDataDel;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.StatusStrip BottomStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel btnClose;
        private System.Windows.Forms.ToolStripStatusLabel btnDataAdd;
        private System.Windows.Forms.ToolStripStatusLabel btnDataDel;
        private System.Windows.Forms.ToolStripStatusLabel btnDataSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;

    }
}