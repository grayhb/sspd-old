namespace SSPD.ObjectsTN
{
    partial class FileCard
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
            this.lblRegN = new System.Windows.Forms.Label();
            this.RegN = new System.Windows.Forms.TextBox();
            this.TypeM = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.Org = new System.Windows.Forms.TextBox();
            this.lblOrg = new System.Windows.Forms.Label();
            this.ObjectName = new System.Windows.Forms.TextBox();
            this.lblObjectName = new System.Windows.Forms.Label();
            this.DateAdd = new System.Windows.Forms.TextBox();
            this.lblDateAdd = new System.Windows.Forms.Label();
            this.WorkerAdd = new System.Windows.Forms.TextBox();
            this.lblWorkerAdd = new System.Windows.Forms.Label();
            this.WorkerArch = new System.Windows.Forms.TextBox();
            this.lblWorkerArch = new System.Windows.Forms.Label();
            this.DateArch = new System.Windows.Forms.TextBox();
            this.lblDateArch = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelObj = new System.Windows.Forms.Button();
            this.btnSelOrg = new System.Windows.Forms.Button();
            this.btnSelType = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegN
            // 
            this.lblRegN.AutoSize = true;
            this.lblRegN.Location = new System.Drawing.Point(12, 21);
            this.lblRegN.Name = "lblRegN";
            this.lblRegN.Size = new System.Drawing.Size(63, 13);
            this.lblRegN.TabIndex = 0;
            this.lblRegN.Text = "Рег. номер";
            // 
            // RegN
            // 
            this.RegN.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RegN.Location = new System.Drawing.Point(140, 18);
            this.RegN.Name = "RegN";
            this.RegN.ReadOnly = true;
            this.RegN.Size = new System.Drawing.Size(100, 20);
            this.RegN.TabIndex = 1;
            this.RegN.TabStop = false;
            this.RegN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TypeM
            // 
            this.TypeM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TypeM.Location = new System.Drawing.Point(140, 49);
            this.TypeM.Name = "TypeM";
            this.TypeM.ReadOnly = true;
            this.TypeM.Size = new System.Drawing.Size(463, 20);
            this.TypeM.TabIndex = 5;
            this.TypeM.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(12, 52);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(84, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Тип материала";
            // 
            // FileName
            // 
            this.FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FileName.Location = new System.Drawing.Point(140, 80);
            this.FileName.Multiline = true;
            this.FileName.Name = "FileName";
            this.FileName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FileName.Size = new System.Drawing.Size(492, 110);
            this.FileName.TabIndex = 0;
            this.FileName.TextChanged += new System.EventHandler(this.FileName_TextChanged);
            // 
            // Org
            // 
            this.Org.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Org.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Org.Location = new System.Drawing.Point(140, 201);
            this.Org.Name = "Org";
            this.Org.ReadOnly = true;
            this.Org.Size = new System.Drawing.Size(463, 20);
            this.Org.TabIndex = 8;
            this.Org.TabStop = false;
            // 
            // lblOrg
            // 
            this.lblOrg.AutoSize = true;
            this.lblOrg.Location = new System.Drawing.Point(12, 204);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(123, 13);
            this.lblOrg.TabIndex = 7;
            this.lblOrg.Text = "Организация источник";
            // 
            // ObjectName
            // 
            this.ObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ObjectName.Location = new System.Drawing.Point(140, 232);
            this.ObjectName.Name = "ObjectName";
            this.ObjectName.ReadOnly = true;
            this.ObjectName.Size = new System.Drawing.Size(463, 20);
            this.ObjectName.TabIndex = 10;
            this.ObjectName.TabStop = false;
            // 
            // lblObjectName
            // 
            this.lblObjectName.AutoSize = true;
            this.lblObjectName.Location = new System.Drawing.Point(12, 235);
            this.lblObjectName.Name = "lblObjectName";
            this.lblObjectName.Size = new System.Drawing.Size(45, 13);
            this.lblObjectName.TabIndex = 9;
            this.lblObjectName.Text = "Объект";
            // 
            // DateAdd
            // 
            this.DateAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DateAdd.Location = new System.Drawing.Point(140, 277);
            this.DateAdd.Name = "DateAdd";
            this.DateAdd.ReadOnly = true;
            this.DateAdd.Size = new System.Drawing.Size(113, 20);
            this.DateAdd.TabIndex = 32;
            this.DateAdd.TabStop = false;
            this.DateAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDateAdd
            // 
            this.lblDateAdd.AutoSize = true;
            this.lblDateAdd.Location = new System.Drawing.Point(12, 280);
            this.lblDateAdd.Name = "lblDateAdd";
            this.lblDateAdd.Size = new System.Drawing.Size(96, 13);
            this.lblDateAdd.TabIndex = 31;
            this.lblDateAdd.Text = "Дата добавления";
            // 
            // WorkerAdd
            // 
            this.WorkerAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.WorkerAdd.Location = new System.Drawing.Point(487, 277);
            this.WorkerAdd.Name = "WorkerAdd";
            this.WorkerAdd.ReadOnly = true;
            this.WorkerAdd.Size = new System.Drawing.Size(145, 20);
            this.WorkerAdd.TabIndex = 34;
            this.WorkerAdd.TabStop = false;
            // 
            // lblWorkerAdd
            // 
            this.lblWorkerAdd.AutoSize = true;
            this.lblWorkerAdd.Location = new System.Drawing.Point(429, 280);
            this.lblWorkerAdd.Name = "lblWorkerAdd";
            this.lblWorkerAdd.Size = new System.Drawing.Size(52, 13);
            this.lblWorkerAdd.TabIndex = 33;
            this.lblWorkerAdd.Text = "Добавил";
            // 
            // WorkerArch
            // 
            this.WorkerArch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.WorkerArch.Location = new System.Drawing.Point(487, 308);
            this.WorkerArch.Name = "WorkerArch";
            this.WorkerArch.ReadOnly = true;
            this.WorkerArch.Size = new System.Drawing.Size(145, 20);
            this.WorkerArch.TabIndex = 38;
            this.WorkerArch.TabStop = false;
            // 
            // lblWorkerArch
            // 
            this.lblWorkerArch.AutoSize = true;
            this.lblWorkerArch.Location = new System.Drawing.Point(429, 311);
            this.lblWorkerArch.Name = "lblWorkerArch";
            this.lblWorkerArch.Size = new System.Drawing.Size(45, 13);
            this.lblWorkerArch.TabIndex = 37;
            this.lblWorkerArch.Text = "Принял";
            // 
            // DateArch
            // 
            this.DateArch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DateArch.Location = new System.Drawing.Point(140, 308);
            this.DateArch.Name = "DateArch";
            this.DateArch.ReadOnly = true;
            this.DateArch.Size = new System.Drawing.Size(113, 20);
            this.DateArch.TabIndex = 36;
            this.DateArch.TabStop = false;
            this.DateArch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDateArch
            // 
            this.lblDateArch.AutoSize = true;
            this.lblDateArch.Location = new System.Drawing.Point(12, 311);
            this.lblDateArch.Name = "lblDateArch";
            this.lblDateArch.Size = new System.Drawing.Size(74, 13);
            this.lblDateArch.TabIndex = 35;
            this.lblDateArch.Text = "Дата приема";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(532, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Закрыть";
            this.toolTip1.SetToolTip(this.btnCancel, "Закрыть карточку");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 83);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(118, 13);
            this.lblFileName.TabIndex = 42;
            this.lblFileName.Text = "Наименование файла";
            // 
            // btnSelObj
            // 
            this.btnSelObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelObj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelObj.Image = global::SSPD.Properties.Resources.ui_button_navigation_back;
            this.btnSelObj.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSelObj.Location = new System.Drawing.Point(609, 230);
            this.btnSelObj.Name = "btnSelObj";
            this.btnSelObj.Size = new System.Drawing.Size(23, 23);
            this.btnSelObj.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnSelObj, "Выбрать объект ОАО КТН");
            this.btnSelObj.UseVisualStyleBackColor = true;
            this.btnSelObj.Click += new System.EventHandler(this.btnSelObj_Click);
            // 
            // btnSelOrg
            // 
            this.btnSelOrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelOrg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelOrg.Image = global::SSPD.Properties.Resources.ui_button_navigation_back;
            this.btnSelOrg.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSelOrg.Location = new System.Drawing.Point(609, 199);
            this.btnSelOrg.Name = "btnSelOrg";
            this.btnSelOrg.Size = new System.Drawing.Size(23, 23);
            this.btnSelOrg.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnSelOrg, "Выбрать организацию источник");
            this.btnSelOrg.UseVisualStyleBackColor = true;
            this.btnSelOrg.Click += new System.EventHandler(this.btnSelOrg_Click);
            // 
            // btnSelType
            // 
            this.btnSelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelType.Image = global::SSPD.Properties.Resources.ui_button_navigation_back;
            this.btnSelType.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSelType.Location = new System.Drawing.Point(609, 47);
            this.btnSelType.Name = "btnSelType";
            this.btnSelType.Size = new System.Drawing.Size(23, 23);
            this.btnSelType.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnSelType, "Выбрать тип материала");
            this.btnSelType.UseVisualStyleBackColor = true;
            this.btnSelType.Click += new System.EventHandler(this.btnSelType_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.Image = global::SSPD.Properties.Resources.drive_download;
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnOpen.Location = new System.Drawing.Point(487, 16);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnOpen.Size = new System.Drawing.Size(145, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Открыть материал";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnOpen, "Открыть электронную версию материала");
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::SSPD.Properties.Resources.LineSeparator;
            this.pictureBox1.Location = new System.Drawing.Point(12, 339);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(620, 2);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // LineSeparatorBottom
            // 
            this.LineSeparatorBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LineSeparatorBottom.BackgroundImage = global::SSPD.Properties.Resources.LineSeparator;
            this.LineSeparatorBottom.Location = new System.Drawing.Point(12, 264);
            this.LineSeparatorBottom.Name = "LineSeparatorBottom";
            this.LineSeparatorBottom.Size = new System.Drawing.Size(620, 2);
            this.LineSeparatorBottom.TabIndex = 30;
            this.LineSeparatorBottom.TabStop = false;
            // 
            // FileCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 388);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WorkerArch);
            this.Controls.Add(this.lblWorkerArch);
            this.Controls.Add(this.DateArch);
            this.Controls.Add(this.lblDateArch);
            this.Controls.Add(this.WorkerAdd);
            this.Controls.Add(this.lblWorkerAdd);
            this.Controls.Add(this.DateAdd);
            this.Controls.Add(this.lblDateAdd);
            this.Controls.Add(this.LineSeparatorBottom);
            this.Controls.Add(this.btnSelObj);
            this.Controls.Add(this.btnSelOrg);
            this.Controls.Add(this.btnSelType);
            this.Controls.Add(this.ObjectName);
            this.Controls.Add(this.lblObjectName);
            this.Controls.Add(this.Org);
            this.Controls.Add(this.lblOrg);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.TypeM);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.RegN);
            this.Controls.Add(this.lblRegN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карточка материала";
            this.Load += new System.EventHandler(this.FileCard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileCard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRegN;
        private System.Windows.Forms.TextBox RegN;
        private System.Windows.Forms.Button btnOpen;
        public System.Windows.Forms.TextBox TypeM;
        private System.Windows.Forms.Label lblType;
        public System.Windows.Forms.TextBox FileName;
        public System.Windows.Forms.TextBox Org;
        private System.Windows.Forms.Label lblOrg;
        public System.Windows.Forms.TextBox ObjectName;
        private System.Windows.Forms.Label lblObjectName;
        private System.Windows.Forms.Button btnSelType;
        private System.Windows.Forms.Button btnSelOrg;
        private System.Windows.Forms.Button btnSelObj;
        private System.Windows.Forms.PictureBox LineSeparatorBottom;
        private System.Windows.Forms.TextBox DateAdd;
        private System.Windows.Forms.Label lblDateAdd;
        private System.Windows.Forms.TextBox WorkerAdd;
        private System.Windows.Forms.Label lblWorkerAdd;
        private System.Windows.Forms.TextBox WorkerArch;
        private System.Windows.Forms.Label lblWorkerArch;
        private System.Windows.Forms.TextBox DateArch;
        private System.Windows.Forms.Label lblDateArch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}