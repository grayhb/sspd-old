namespace Контроль_запросов_ТКП
{
    partial class ExportScanDoc
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
            this.fBDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.textPath = new System.Windows.Forms.TextBox();
            this.labelFolder = new System.Windows.Forms.Label();
            this.cmdOpenFolder = new System.Windows.Forms.Button();
            this.checkProject = new System.Windows.Forms.CheckBox();
            this.checkZad = new System.Windows.Forms.CheckBox();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.checkOutDoc = new System.Windows.Forms.CheckBox();
            this.checkInpDoc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fBDialog
            // 
            this.fBDialog.Description = "Папка для экспорта документов";
            // 
            // textPath
            // 
            this.textPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textPath.Location = new System.Drawing.Point(78, 32);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(321, 20);
            this.textPath.TabIndex = 0;
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(12, 34);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(42, 13);
            this.labelFolder.TabIndex = 1;
            this.labelFolder.Text = "Папка:";
            // 
            // cmdOpenFolder
            // 
            this.cmdOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOpenFolder.Location = new System.Drawing.Point(405, 29);
            this.cmdOpenFolder.Name = "cmdOpenFolder";
            this.cmdOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdOpenFolder.TabIndex = 2;
            this.cmdOpenFolder.Text = "Обзор";
            this.cmdOpenFolder.UseVisualStyleBackColor = true;
            this.cmdOpenFolder.Click += new System.EventHandler(this.cmdOpenFolder_Click);
            // 
            // checkProject
            // 
            this.checkProject.AutoSize = true;
            this.checkProject.Checked = true;
            this.checkProject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkProject.Location = new System.Drawing.Point(339, 69);
            this.checkProject.Name = "checkProject";
            this.checkProject.Size = new System.Drawing.Size(141, 17);
            this.checkProject.TabIndex = 3;
            this.checkProject.Text = "группировать проекты";
            this.checkProject.UseVisualStyleBackColor = true;
            // 
            // checkZad
            // 
            this.checkZad.AutoSize = true;
            this.checkZad.Checked = true;
            this.checkZad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkZad.Location = new System.Drawing.Point(339, 92);
            this.checkZad.Name = "checkZad";
            this.checkZad.Size = new System.Drawing.Size(140, 17);
            this.checkZad.TabIndex = 4;
            this.checkZad.Text = "группировать задания";
            this.checkZad.UseVisualStyleBackColor = true;
            // 
            // PB
            // 
            this.PB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PB.Location = new System.Drawing.Point(12, 158);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(468, 23);
            this.PB.TabIndex = 5;
            this.PB.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(405, 121);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "Отмена";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExport.Location = new System.Drawing.Point(290, 121);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(109, 23);
            this.cmdExport.TabIndex = 7;
            this.cmdExport.Text = "Экспортировать";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // checkOutDoc
            // 
            this.checkOutDoc.AutoSize = true;
            this.checkOutDoc.Checked = true;
            this.checkOutDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkOutDoc.Location = new System.Drawing.Point(78, 69);
            this.checkOutDoc.Name = "checkOutDoc";
            this.checkOutDoc.Size = new System.Drawing.Size(82, 17);
            this.checkOutDoc.TabIndex = 8;
            this.checkOutDoc.Text = "исходящие";
            this.checkOutDoc.UseVisualStyleBackColor = true;
            // 
            // checkInpDoc
            // 
            this.checkInpDoc.AutoSize = true;
            this.checkInpDoc.Checked = true;
            this.checkInpDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkInpDoc.Location = new System.Drawing.Point(78, 92);
            this.checkInpDoc.Name = "checkInpDoc";
            this.checkInpDoc.Size = new System.Drawing.Size(76, 17);
            this.checkInpDoc.TabIndex = 9;
            this.checkInpDoc.Text = "входящие";
            this.checkInpDoc.UseVisualStyleBackColor = true;
            // 
            // ExportScanDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 193);
            this.Controls.Add(this.checkInpDoc);
            this.Controls.Add(this.checkOutDoc);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.PB);
            this.Controls.Add(this.checkZad);
            this.Controls.Add(this.checkProject);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.cmdOpenFolder);
            this.Controls.Add(this.textPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportScanDoc";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Экспорт документов";
            this.Load += new System.EventHandler(this.ExportScanDoc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExportScanDoc_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fBDialog;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.Button cmdOpenFolder;
        private System.Windows.Forms.CheckBox checkProject;
        private System.Windows.Forms.CheckBox checkZad;
        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.CheckBox checkOutDoc;
        private System.Windows.Forms.CheckBox checkInpDoc;
    }
}