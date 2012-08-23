namespace SSPD.ObjectsTN
{
    partial class FileAdd
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Шаги", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Выбор объекта");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Ввод регистрационных данных");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Выбор файла");
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.SeporLine = new System.Windows.Forms.PictureBox();
            this.panelSelectObject = new System.Windows.Forms.Panel();
            this.Object = new System.Windows.Forms.TextBox();
            this.btnSelObj = new System.Windows.Forms.Button();
            this.ObjLabel = new System.Windows.Forms.Label();
            this.listSteps = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelInputData = new System.Windows.Forms.Panel();
            this.Org = new System.Windows.Forms.TextBox();
            this.btnSelOrg = new System.Windows.Forms.Button();
            this.OrgLabel = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileType = new System.Windows.Forms.TextBox();
            this.btnSelFileType = new System.Windows.Forms.Button();
            this.FileTypeLabel = new System.Windows.Forms.Label();
            this.panelSelectFile = new System.Windows.Forms.Panel();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.btnSelFilePath = new System.Windows.Forms.Button();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SeporLine)).BeginInit();
            this.panelSelectObject.SuspendLayout();
            this.panelInputData.SuspendLayout();
            this.panelSelectFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(496, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.Location = new System.Drawing.Point(405, 291);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(85, 23);
            this.btnNext.TabIndex = 45;
            this.btnNext.Text = "&Далее >";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Enabled = false;
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrev.Location = new System.Drawing.Point(314, 291);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(85, 23);
            this.btnPrev.TabIndex = 46;
            this.btnPrev.Text = "< &Назад";
            this.btnPrev.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // SeporLine
            // 
            this.SeporLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SeporLine.BackgroundImage = global::SSPD.Properties.Resources.LineSeparator;
            this.SeporLine.Location = new System.Drawing.Point(0, 280);
            this.SeporLine.Name = "SeporLine";
            this.SeporLine.Size = new System.Drawing.Size(602, 2);
            this.SeporLine.TabIndex = 48;
            this.SeporLine.TabStop = false;
            // 
            // panelSelectObject
            // 
            this.panelSelectObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSelectObject.BackColor = System.Drawing.SystemColors.Control;
            this.panelSelectObject.Controls.Add(this.Object);
            this.panelSelectObject.Controls.Add(this.btnSelObj);
            this.panelSelectObject.Controls.Add(this.ObjLabel);
            this.panelSelectObject.Location = new System.Drawing.Point(210, 166);
            this.panelSelectObject.Name = "panelSelectObject";
            this.panelSelectObject.Size = new System.Drawing.Size(325, 108);
            this.panelSelectObject.TabIndex = 49;
            this.panelSelectObject.Tag = "0";
            // 
            // Object
            // 
            this.Object.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Object.Location = new System.Drawing.Point(13, 38);
            this.Object.Multiline = true;
            this.Object.Name = "Object";
            this.Object.ReadOnly = true;
            this.Object.Size = new System.Drawing.Size(272, 51);
            this.Object.TabIndex = 2;
            this.Object.TabStop = false;
            // 
            // btnSelObj
            // 
            this.btnSelObj.Location = new System.Drawing.Point(291, 37);
            this.btnSelObj.Name = "btnSelObj";
            this.btnSelObj.Size = new System.Drawing.Size(75, 23);
            this.btnSelObj.TabIndex = 1;
            this.btnSelObj.Text = "выбрать";
            this.btnSelObj.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelObj.UseVisualStyleBackColor = true;
            this.btnSelObj.Click += new System.EventHandler(this.btnSelObj_Click);
            // 
            // ObjLabel
            // 
            this.ObjLabel.AutoSize = true;
            this.ObjLabel.Location = new System.Drawing.Point(10, 21);
            this.ObjLabel.Name = "ObjLabel";
            this.ObjLabel.Size = new System.Drawing.Size(45, 13);
            this.ObjLabel.TabIndex = 0;
            this.ObjLabel.Text = "Объект";
            // 
            // listSteps
            // 
            this.listSteps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listSteps.BackColor = System.Drawing.Color.White;
            this.listSteps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listSteps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listSteps.FullRowSelect = true;
            listViewGroup1.Header = "Шаги";
            listViewGroup1.Name = "Шаги";
            this.listSteps.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listSteps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listSteps.HideSelection = false;
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup1;
            listViewItem3.Group = listViewGroup1;
            this.listSteps.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listSteps.Location = new System.Drawing.Point(12, 12);
            this.listSteps.MultiSelect = false;
            this.listSteps.Name = "listSteps";
            this.listSteps.Size = new System.Drawing.Size(187, 270);
            this.listSteps.TabIndex = 51;
            this.listSteps.TabStop = false;
            this.listSteps.UseCompatibleStateImageBehavior = false;
            this.listSteps.View = System.Windows.Forms.View.Details;
            this.listSteps.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 172;
            // 
            // panelInputData
            // 
            this.panelInputData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInputData.BackColor = System.Drawing.SystemColors.Control;
            this.panelInputData.Controls.Add(this.Org);
            this.panelInputData.Controls.Add(this.btnSelOrg);
            this.panelInputData.Controls.Add(this.OrgLabel);
            this.panelInputData.Controls.Add(this.FileName);
            this.panelInputData.Controls.Add(this.FileNameLabel);
            this.panelInputData.Controls.Add(this.FileType);
            this.panelInputData.Controls.Add(this.btnSelFileType);
            this.panelInputData.Controls.Add(this.FileTypeLabel);
            this.panelInputData.Location = new System.Drawing.Point(210, 12);
            this.panelInputData.Name = "panelInputData";
            this.panelInputData.Size = new System.Drawing.Size(371, 262);
            this.panelInputData.TabIndex = 52;
            this.panelInputData.Tag = "1";
            // 
            // Org
            // 
            this.Org.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Org.Location = new System.Drawing.Point(13, 185);
            this.Org.Name = "Org";
            this.Org.ReadOnly = true;
            this.Org.Size = new System.Drawing.Size(269, 20);
            this.Org.TabIndex = 7;
            this.Org.TabStop = false;
            // 
            // btnSelOrg
            // 
            this.btnSelOrg.Location = new System.Drawing.Point(288, 182);
            this.btnSelOrg.Name = "btnSelOrg";
            this.btnSelOrg.Size = new System.Drawing.Size(75, 23);
            this.btnSelOrg.TabIndex = 6;
            this.btnSelOrg.Text = "выбрать";
            this.btnSelOrg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelOrg.UseVisualStyleBackColor = true;
            this.btnSelOrg.Click += new System.EventHandler(this.btnSelOrg_Click);
            // 
            // OrgLabel
            // 
            this.OrgLabel.AutoSize = true;
            this.OrgLabel.Location = new System.Drawing.Point(10, 169);
            this.OrgLabel.Name = "OrgLabel";
            this.OrgLabel.Size = new System.Drawing.Size(123, 13);
            this.OrgLabel.TabIndex = 5;
            this.OrgLabel.Text = "Организация источник";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(13, 88);
            this.FileName.Multiline = true;
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(350, 60);
            this.FileName.TabIndex = 4;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(10, 72);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(83, 13);
            this.FileNameLabel.TabIndex = 3;
            this.FileNameLabel.Text = "Наименование";
            // 
            // FileType
            // 
            this.FileType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FileType.Location = new System.Drawing.Point(13, 38);
            this.FileType.Name = "FileType";
            this.FileType.ReadOnly = true;
            this.FileType.Size = new System.Drawing.Size(269, 20);
            this.FileType.TabIndex = 2;
            this.FileType.TabStop = false;
            // 
            // btnSelFileType
            // 
            this.btnSelFileType.Location = new System.Drawing.Point(288, 36);
            this.btnSelFileType.Name = "btnSelFileType";
            this.btnSelFileType.Size = new System.Drawing.Size(75, 23);
            this.btnSelFileType.TabIndex = 1;
            this.btnSelFileType.Text = "выбрать";
            this.btnSelFileType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelFileType.UseVisualStyleBackColor = true;
            // 
            // FileTypeLabel
            // 
            this.FileTypeLabel.AutoSize = true;
            this.FileTypeLabel.Location = new System.Drawing.Point(10, 22);
            this.FileTypeLabel.Name = "FileTypeLabel";
            this.FileTypeLabel.Size = new System.Drawing.Size(84, 13);
            this.FileTypeLabel.TabIndex = 0;
            this.FileTypeLabel.Text = "Тип материала";
            // 
            // panelSelectFile
            // 
            this.panelSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSelectFile.BackColor = System.Drawing.SystemColors.Control;
            this.panelSelectFile.Controls.Add(this.FilePath);
            this.panelSelectFile.Controls.Add(this.btnSelFilePath);
            this.panelSelectFile.Controls.Add(this.FilePathLabel);
            this.panelSelectFile.Location = new System.Drawing.Point(439, 39);
            this.panelSelectFile.Name = "panelSelectFile";
            this.panelSelectFile.Size = new System.Drawing.Size(137, 102);
            this.panelSelectFile.TabIndex = 52;
            this.panelSelectFile.Tag = "2";
            // 
            // FilePath
            // 
            this.FilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FilePath.Location = new System.Drawing.Point(13, 38);
            this.FilePath.Multiline = true;
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Size = new System.Drawing.Size(272, 71);
            this.FilePath.TabIndex = 5;
            this.FilePath.TabStop = false;
            // 
            // btnSelFilePath
            // 
            this.btnSelFilePath.Location = new System.Drawing.Point(291, 37);
            this.btnSelFilePath.Name = "btnSelFilePath";
            this.btnSelFilePath.Size = new System.Drawing.Size(75, 23);
            this.btnSelFilePath.TabIndex = 4;
            this.btnSelFilePath.Text = "выбрать";
            this.btnSelFilePath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelFilePath.UseVisualStyleBackColor = true;
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Location = new System.Drawing.Point(10, 22);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(111, 13);
            this.FilePathLabel.TabIndex = 3;
            this.FilePathLabel.Text = "Файл с материалом";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 285);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // FileAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 326);
            this.Controls.Add(this.panelSelectObject);
            this.Controls.Add(this.SeporLine);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.listSteps);
            this.Controls.Add(this.panelSelectFile);
            this.Controls.Add(this.panelInputData);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileAdd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление нового материала к объекту";
            this.Load += new System.EventHandler(this.FileAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SeporLine)).EndInit();
            this.panelSelectObject.ResumeLayout(false);
            this.panelSelectObject.PerformLayout();
            this.panelInputData.ResumeLayout(false);
            this.panelInputData.PerformLayout();
            this.panelSelectFile.ResumeLayout(false);
            this.panelSelectFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.PictureBox SeporLine;
        private System.Windows.Forms.Panel panelSelectObject;
        private System.Windows.Forms.ListView listSteps;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panelInputData;
        private System.Windows.Forms.Panel panelSelectFile;
        private System.Windows.Forms.TextBox Object;
        private System.Windows.Forms.Button btnSelObj;
        private System.Windows.Forms.Label ObjLabel;
        private System.Windows.Forms.TextBox Org;
        private System.Windows.Forms.Button btnSelOrg;
        private System.Windows.Forms.Label OrgLabel;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.TextBox FileType;
        private System.Windows.Forms.Button btnSelFileType;
        private System.Windows.Forms.Label FileTypeLabel;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Button btnSelFilePath;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}