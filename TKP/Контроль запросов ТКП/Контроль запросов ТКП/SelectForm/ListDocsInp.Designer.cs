namespace Контроль_запросов_ТКП.SelectForm
{
    partial class ListDocsInp
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.RNDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Org = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filter = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ЭлектроннаяВерсияДокумента = new System.Windows.Forms.ToolStripMenuItem();
            this.Фильтр = new System.Windows.Forms.ToolStripMenuItem();
            this.ФМесяц = new System.Windows.Forms.ToolStripMenuItem();
            this.заПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ФОтсутствует = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CountRowLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.RNDoc,
            this.DateDoc,
            this.Note,
            this.Org,
            this.Adr});
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 44);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(892, 507);
            this.DGV.TabIndex = 19;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.Sorted += new System.EventHandler(this.DGV_Sorted);
            this.DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyDown);
            // 
            // RNDoc
            // 
            this.RNDoc.HeaderText = "Рег. номер";
            this.RNDoc.Name = "RNDoc";
            this.RNDoc.ReadOnly = true;
            // 
            // DateDoc
            // 
            this.DateDoc.HeaderText = "Дата";
            this.DateDoc.Name = "DateDoc";
            this.DateDoc.ReadOnly = true;
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.HeaderText = "Краткое содержание";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            // 
            // Org
            // 
            this.Org.HeaderText = "Организация";
            this.Org.Name = "Org";
            this.Org.ReadOnly = true;
            this.Org.Width = 300;
            // 
            // Adr
            // 
            this.Adr.HeaderText = "Отправитель";
            this.Adr.Name = "Adr";
            this.Adr.ReadOnly = true;
            this.Adr.Width = 120;
            // 
            // Filter
            // 
            this.Filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.Filter.Location = new System.Drawing.Point(0, 24);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(892, 20);
            this.Filter.TabIndex = 20;
            this.Filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            this.Filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Filter_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операцииToolStripMenuItem,
            this.ЭлектроннаяВерсияДокумента,
            this.Фильтр});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьToolStripMenuItem,
            this.toolStripSeparator1,
            this.закрытьToolStripMenuItem});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // выбратьToolStripMenuItem
            // 
            this.выбратьToolStripMenuItem.Name = "выбратьToolStripMenuItem";
            this.выбратьToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.выбратьToolStripMenuItem.Text = "Выбрать";
            this.выбратьToolStripMenuItem.Click += new System.EventHandler(this.выбратьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // ЭлектроннаяВерсияДокумента
            // 
            this.ЭлектроннаяВерсияДокумента.Name = "ЭлектроннаяВерсияДокумента";
            this.ЭлектроннаяВерсияДокумента.Size = new System.Drawing.Size(132, 20);
            this.ЭлектроннаяВерсияДокумента.Text = "Эл. версия документа";
            this.ЭлектроннаяВерсияДокумента.Click += new System.EventHandler(this.ЭлектроннаяВерсияДокумента_Click);
            // 
            // Фильтр
            // 
            this.Фильтр.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ФМесяц,
            this.заПериодToolStripMenuItem,
            this.toolStripSeparator2,
            this.ФОтсутствует});
            this.Фильтр.Name = "Фильтр";
            this.Фильтр.Size = new System.Drawing.Size(57, 20);
            this.Фильтр.Text = "Фильтр";
            // 
            // ФМесяц
            // 
            this.ФМесяц.Checked = true;
            this.ФМесяц.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ФМесяц.Name = "ФМесяц";
            this.ФМесяц.Size = new System.Drawing.Size(186, 22);
            this.ФМесяц.Text = "За последний месяц";
            this.ФМесяц.Click += new System.EventHandler(this.ФМесяц_Click);
            // 
            // заПериодToolStripMenuItem
            // 
            this.заПериодToolStripMenuItem.Enabled = false;
            this.заПериодToolStripMenuItem.Name = "заПериодToolStripMenuItem";
            this.заПериодToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.заПериодToolStripMenuItem.Text = "За период";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // ФОтсутствует
            // 
            this.ФОтсутствует.Name = "ФОтсутствует";
            this.ФОтсутствует.Size = new System.Drawing.Size(186, 22);
            this.ФОтсутствует.Text = "Отсутствует";
            this.ФОтсутствует.Click += new System.EventHandler(this.ФОтсутствует_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CountRowLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(892, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CountRowLabel
            // 
            this.CountRowLabel.Name = "CountRowLabel";
            this.CountRowLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ListDocsInp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 573);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "ListDocsInp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список входящих документов";
            this.Load += new System.EventHandler(this.ListDocsInp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListDocsInp_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.TextBox Filter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ЭлектроннаяВерсияДокумента;
        private System.Windows.Forms.ToolStripMenuItem Фильтр;
        private System.Windows.Forms.ToolStripMenuItem ФМесяц;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ФОтсутствует;
        private System.Windows.Forms.ToolStripMenuItem заПериодToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn RNDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn Org;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adr;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel CountRowLabel;
    }
}