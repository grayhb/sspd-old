namespace Контроль_запросов_ТКП
{
    partial class LogViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewer));
            this.DGV = new System.Windows.Forms.DataGridView();
            this.DateTimeLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_RecTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DGVCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelPeriod = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdUpdate = new System.Windows.Forms.ToolStripButton();
            this.cmdSelPeriod = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateTimeLog,
            this.Worker,
            this.EventLog,
            this.TableName,
            this.ID_RecTable,
            this.DescLog});
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 25);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(992, 426);
            this.DGV.TabIndex = 7;
            // 
            // DateTimeLog
            // 
            this.DateTimeLog.HeaderText = "Дата";
            this.DateTimeLog.Name = "DateTimeLog";
            this.DateTimeLog.ReadOnly = true;
            this.DateTimeLog.Width = 150;
            // 
            // Worker
            // 
            this.Worker.HeaderText = "ФИО";
            this.Worker.Name = "Worker";
            this.Worker.ReadOnly = true;
            this.Worker.Width = 150;
            // 
            // EventLog
            // 
            this.EventLog.HeaderText = "Событие";
            this.EventLog.Name = "EventLog";
            this.EventLog.ReadOnly = true;
            this.EventLog.Width = 150;
            // 
            // TableName
            // 
            this.TableName.HeaderText = "Имя таблицы";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            this.TableName.Width = 150;
            // 
            // ID_RecTable
            // 
            this.ID_RecTable.HeaderText = "Значение";
            this.ID_RecTable.Name = "ID_RecTable";
            this.ID_RecTable.ReadOnly = true;
            // 
            // DescLog
            // 
            this.DescLog.HeaderText = "Описание";
            this.DescLog.Name = "DescLog";
            this.DescLog.ReadOnly = true;
            this.DescLog.Width = 270;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdUpdate,
            this.toolStripSeparator1,
            this.LabelPeriod,
            this.cmdSelPeriod,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(992, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DGVCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(992, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DGVCount
            // 
            this.DGVCount.Name = "DGVCount";
            this.DGVCount.Size = new System.Drawing.Size(0, 17);
            // 
            // LabelPeriod
            // 
            this.LabelPeriod.Name = "LabelPeriod";
            this.LabelPeriod.Size = new System.Drawing.Size(107, 22);
            this.LabelPeriod.Text = "Период: за сегодня";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdUpdate.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdate.Image")));
            this.cmdUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(23, 22);
            this.cmdUpdate.Text = "Обновить";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdSelPeriod
            // 
            this.cmdSelPeriod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSelPeriod.Image = global::Контроль_запросов_ТКП.Properties.Resources.date;
            this.cmdSelPeriod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSelPeriod.Name = "cmdSelPeriod";
            this.cmdSelPeriod.Size = new System.Drawing.Size(23, 22);
            this.cmdSelPeriod.Text = "toolStripButton1";
            this.cmdSelPeriod.Click += new System.EventHandler(this.cmdSelPeriod_Click);
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 473);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LogViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LogViewer";
            this.Load += new System.EventHandler(this.LogViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTimeLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_RecTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel DGVCount;
        private System.Windows.Forms.ToolStripButton cmdUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel LabelPeriod;
        private System.Windows.Forms.ToolStripButton cmdSelPeriod;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}