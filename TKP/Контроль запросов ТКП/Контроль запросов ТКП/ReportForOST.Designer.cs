namespace Контроль_запросов_ТКП
{
    partial class ReportForOST
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
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSelOrg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OST = new System.Windows.Forms.TextBox();
            this.Period = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSelPeriod = new System.Windows.Forms.Button();
            this.textPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSelPath = new System.Windows.Forms.Button();
            this.fBDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.flExpDoc = new System.Windows.Forms.CheckBox();
            this.PrjSh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdSelProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdApply
            // 
            this.cmdApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdApply.Location = new System.Drawing.Point(162, 169);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(161, 26);
            this.cmdApply.TabIndex = 0;
            this.cmdApply.Text = "Сформировать отчет";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(54, 169);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(102, 26);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Отмена";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSelOrg
            // 
            this.cmdSelOrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelOrg.Location = new System.Drawing.Point(297, 22);
            this.cmdSelOrg.Name = "cmdSelOrg";
            this.cmdSelOrg.Size = new System.Drawing.Size(26, 22);
            this.cmdSelOrg.TabIndex = 1;
            this.cmdSelOrg.Text = "...";
            this.cmdSelOrg.UseVisualStyleBackColor = true;
            this.cmdSelOrg.Click += new System.EventHandler(this.cmdSelOrg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Заказчик";
            // 
            // OST
            // 
            this.OST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OST.BackColor = System.Drawing.Color.White;
            this.OST.Location = new System.Drawing.Point(108, 26);
            this.OST.Name = "OST";
            this.OST.ReadOnly = true;
            this.OST.Size = new System.Drawing.Size(182, 20);
            this.OST.TabIndex = 3;
            this.OST.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Period
            // 
            this.Period.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Period.BackColor = System.Drawing.Color.White;
            this.Period.Location = new System.Drawing.Point(108, 52);
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            this.Period.Size = new System.Drawing.Size(182, 20);
            this.Period.TabIndex = 6;
            this.Period.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Период";
            // 
            // cmdSelPeriod
            // 
            this.cmdSelPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelPeriod.Location = new System.Drawing.Point(297, 50);
            this.cmdSelPeriod.Name = "cmdSelPeriod";
            this.cmdSelPeriod.Size = new System.Drawing.Size(26, 22);
            this.cmdSelPeriod.TabIndex = 4;
            this.cmdSelPeriod.Text = "...";
            this.cmdSelPeriod.UseVisualStyleBackColor = true;
            this.cmdSelPeriod.Click += new System.EventHandler(this.cmdSelPeriod_Click);
            // 
            // textPath
            // 
            this.textPath.BackColor = System.Drawing.Color.White;
            this.textPath.Location = new System.Drawing.Point(108, 117);
            this.textPath.Name = "textPath";
            this.textPath.ReadOnly = true;
            this.textPath.Size = new System.Drawing.Size(182, 20);
            this.textPath.TabIndex = 9;
            this.textPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Путь экспорта";
            // 
            // cmdSelPath
            // 
            this.cmdSelPath.Location = new System.Drawing.Point(297, 115);
            this.cmdSelPath.Name = "cmdSelPath";
            this.cmdSelPath.Size = new System.Drawing.Size(26, 22);
            this.cmdSelPath.TabIndex = 7;
            this.cmdSelPath.Text = "...";
            this.cmdSelPath.UseVisualStyleBackColor = true;
            this.cmdSelPath.Click += new System.EventHandler(this.cmdSelPath_Click);
            // 
            // fBDialog
            // 
            this.fBDialog.Description = "Папка для экспорта документов";
            // 
            // flExpDoc
            // 
            this.flExpDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flExpDoc.AutoSize = true;
            this.flExpDoc.Location = new System.Drawing.Point(108, 140);
            this.flExpDoc.Name = "flExpDoc";
            this.flExpDoc.Size = new System.Drawing.Size(145, 17);
            this.flExpDoc.TabIndex = 10;
            this.flExpDoc.Text = "экспортировать файлы";
            this.flExpDoc.UseVisualStyleBackColor = true;
            this.flExpDoc.CheckedChanged += new System.EventHandler(this.flExpDoc_CheckedChanged);
            // 
            // PrjSh
            // 
            this.PrjSh.BackColor = System.Drawing.Color.White;
            this.PrjSh.Location = new System.Drawing.Point(108, 78);
            this.PrjSh.Name = "PrjSh";
            this.PrjSh.ReadOnly = true;
            this.PrjSh.Size = new System.Drawing.Size(182, 20);
            this.PrjSh.TabIndex = 13;
            this.PrjSh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Проект";
            // 
            // cmdSelProject
            // 
            this.cmdSelProject.Location = new System.Drawing.Point(297, 76);
            this.cmdSelProject.Name = "cmdSelProject";
            this.cmdSelProject.Size = new System.Drawing.Size(26, 22);
            this.cmdSelProject.TabIndex = 11;
            this.cmdSelProject.Text = "...";
            this.cmdSelProject.UseVisualStyleBackColor = true;
            this.cmdSelProject.Click += new System.EventHandler(this.cmdSelProject_Click);
            // 
            // ReportForOST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 207);
            this.ControlBox = false;
            this.Controls.Add(this.PrjSh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdSelProject);
            this.Controls.Add(this.flExpDoc);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdSelPath);
            this.Controls.Add(this.Period);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSelPeriod);
            this.Controls.Add(this.OST);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSelOrg);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "ReportForOST";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчет по исх. письмам без ответа";
            this.Load += new System.EventHandler(this.ReportForOST_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSelOrg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OST;
        private System.Windows.Forms.TextBox Period;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSelPeriod;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSelPath;
        private System.Windows.Forms.FolderBrowserDialog fBDialog;
        private System.Windows.Forms.CheckBox flExpDoc;
        private System.Windows.Forms.TextBox PrjSh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdSelProject;
    }
}