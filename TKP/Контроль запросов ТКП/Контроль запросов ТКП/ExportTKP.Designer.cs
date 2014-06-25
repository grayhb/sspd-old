namespace Контроль_запросов_ТКП
{
    partial class ExportTKP
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
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.labelFolder = new System.Windows.Forms.Label();
            this.cmdOpenFolder = new System.Windows.Forms.Button();
            this.textPath = new System.Windows.Forms.TextBox();
            this.fBDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExport.Location = new System.Drawing.Point(290, 68);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(109, 23);
            this.cmdExport.TabIndex = 13;
            this.cmdExport.Text = "Экспортировать";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(405, 68);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.Text = "Отмена";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // PB
            // 
            this.PB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PB.Location = new System.Drawing.Point(12, 103);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(468, 23);
            this.PB.TabIndex = 11;
            this.PB.Visible = false;
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(14, 28);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(42, 13);
            this.labelFolder.TabIndex = 9;
            this.labelFolder.Text = "Папка:";
            // 
            // cmdOpenFolder
            // 
            this.cmdOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOpenFolder.Location = new System.Drawing.Point(405, 23);
            this.cmdOpenFolder.Name = "cmdOpenFolder";
            this.cmdOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdOpenFolder.TabIndex = 10;
            this.cmdOpenFolder.Text = "Обзор";
            this.cmdOpenFolder.UseVisualStyleBackColor = true;
            this.cmdOpenFolder.Click += new System.EventHandler(this.cmdOpenFolder_Click);
            // 
            // textPath
            // 
            this.textPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textPath.Location = new System.Drawing.Point(80, 26);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(319, 20);
            this.textPath.TabIndex = 8;
            // 
            // fBDialog
            // 
            this.fBDialog.Description = "Папка для экспорта документов";
            // 
            // ExportTKP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 138);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.PB);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.cmdOpenFolder);
            this.Controls.Add(this.textPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportTKP";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Экспорт ТКП";
            this.Load += new System.EventHandler(this.ExportTKP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.Button cmdOpenFolder;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.FolderBrowserDialog fBDialog;
    }
}