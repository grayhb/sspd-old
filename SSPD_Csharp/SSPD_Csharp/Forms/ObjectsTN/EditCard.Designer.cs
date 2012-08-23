namespace SSPD.ObjectsTN
{
    partial class EditCard
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MN = new System.Windows.Forms.TabPage();
            this.btnChangeOrg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MN_Name = new System.Windows.Forms.TextBox();
            this.RNU = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.RNU_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RNU_MN_Name = new System.Windows.Forms.TextBox();
            this.LPDS = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.LPDS_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LPDS_RNU = new System.Windows.Forms.TextBox();
            this.Place = new System.Windows.Forms.TabPage();
            this.btnLPDSAdd = new System.Windows.Forms.Button();
            this.PlaceRN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PlaceStatus = new System.Windows.Forms.CheckBox();
            this.comboLPDS = new System.Windows.Forms.ComboBox();
            this.checkLPDS = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Place_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Place_RNU = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSepor = new System.Windows.Forms.ToolStripSeparator();
            this.mbtnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).BeginInit();
            this.TabControl.SuspendLayout();
            this.MN.SuspendLayout();
            this.RNU.SuspendLayout();
            this.LPDS.SuspendLayout();
            this.Place.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(505, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Location = new System.Drawing.Point(424, 268);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "ОК";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // LineSeparatorBottom
            // 
            this.LineSeparatorBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LineSeparatorBottom.BackgroundImage = global::SSPD.Properties.Resources.LineSeparator;
            this.LineSeparatorBottom.Location = new System.Drawing.Point(12, 258);
            this.LineSeparatorBottom.Name = "LineSeparatorBottom";
            this.LineSeparatorBottom.Size = new System.Drawing.Size(567, 2);
            this.LineSeparatorBottom.TabIndex = 29;
            this.LineSeparatorBottom.TabStop = false;
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.MN);
            this.TabControl.Controls.Add(this.RNU);
            this.TabControl.Controls.Add(this.LPDS);
            this.TabControl.Controls.Add(this.Place);
            this.TabControl.Location = new System.Drawing.Point(12, 33);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(568, 216);
            this.TabControl.TabIndex = 31;
            // 
            // MN
            // 
            this.MN.Controls.Add(this.btnChangeOrg);
            this.MN.Controls.Add(this.label1);
            this.MN.Controls.Add(this.MN_Name);
            this.MN.Location = new System.Drawing.Point(4, 22);
            this.MN.Name = "MN";
            this.MN.Padding = new System.Windows.Forms.Padding(3);
            this.MN.Size = new System.Drawing.Size(560, 190);
            this.MN.TabIndex = 0;
            this.MN.Text = "ОСТ";
            this.MN.UseVisualStyleBackColor = true;
            // 
            // btnChangeOrg
            // 
            this.btnChangeOrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeOrg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeOrg.Image = global::SSPD.Properties.Resources.ui_button_navigation_back;
            this.btnChangeOrg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeOrg.Location = new System.Drawing.Point(381, 34);
            this.btnChangeOrg.Name = "btnChangeOrg";
            this.btnChangeOrg.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnChangeOrg.Size = new System.Drawing.Size(158, 23);
            this.btnChangeOrg.TabIndex = 2;
            this.btnChangeOrg.Text = "Выбрать организацию";
            this.btnChangeOrg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeOrg.UseVisualStyleBackColor = true;
            this.btnChangeOrg.Click += new System.EventHandler(this.btnChangeOrg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование организации";
            // 
            // MN_Name
            // 
            this.MN_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MN_Name.BackColor = System.Drawing.Color.White;
            this.MN_Name.Location = new System.Drawing.Point(23, 36);
            this.MN_Name.Name = "MN_Name";
            this.MN_Name.ReadOnly = true;
            this.MN_Name.Size = new System.Drawing.Size(352, 20);
            this.MN_Name.TabIndex = 0;
            // 
            // RNU
            // 
            this.RNU.Controls.Add(this.label3);
            this.RNU.Controls.Add(this.RNU_Name);
            this.RNU.Controls.Add(this.label2);
            this.RNU.Controls.Add(this.RNU_MN_Name);
            this.RNU.Location = new System.Drawing.Point(4, 22);
            this.RNU.Name = "RNU";
            this.RNU.Padding = new System.Windows.Forms.Padding(3);
            this.RNU.Size = new System.Drawing.Size(560, 190);
            this.RNU.TabIndex = 1;
            this.RNU.Text = "РНУ";
            this.RNU.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Наименование районного управления";
            // 
            // RNU_Name
            // 
            this.RNU_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RNU_Name.BackColor = System.Drawing.Color.White;
            this.RNU_Name.Location = new System.Drawing.Point(23, 84);
            this.RNU_Name.Name = "RNU_Name";
            this.RNU_Name.Size = new System.Drawing.Size(517, 20);
            this.RNU_Name.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Наименование организации";
            // 
            // RNU_MN_Name
            // 
            this.RNU_MN_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RNU_MN_Name.BackColor = System.Drawing.Color.Gainsboro;
            this.RNU_MN_Name.Location = new System.Drawing.Point(23, 36);
            this.RNU_MN_Name.Name = "RNU_MN_Name";
            this.RNU_MN_Name.ReadOnly = true;
            this.RNU_MN_Name.Size = new System.Drawing.Size(517, 20);
            this.RNU_MN_Name.TabIndex = 5;
            this.RNU_MN_Name.TabStop = false;
            // 
            // LPDS
            // 
            this.LPDS.Controls.Add(this.label6);
            this.LPDS.Controls.Add(this.LPDS_Name);
            this.LPDS.Controls.Add(this.label4);
            this.LPDS.Controls.Add(this.LPDS_RNU);
            this.LPDS.Location = new System.Drawing.Point(4, 22);
            this.LPDS.Name = "LPDS";
            this.LPDS.Padding = new System.Windows.Forms.Padding(3);
            this.LPDS.Size = new System.Drawing.Size(560, 190);
            this.LPDS.TabIndex = 2;
            this.LPDS.Text = "ЛПДС";
            this.LPDS.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Наименование ЛПДС";
            // 
            // LPDS_Name
            // 
            this.LPDS_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LPDS_Name.BackColor = System.Drawing.Color.White;
            this.LPDS_Name.Location = new System.Drawing.Point(23, 84);
            this.LPDS_Name.Name = "LPDS_Name";
            this.LPDS_Name.Size = new System.Drawing.Size(517, 20);
            this.LPDS_Name.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Наименование районного управления";
            // 
            // LPDS_RNU
            // 
            this.LPDS_RNU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LPDS_RNU.BackColor = System.Drawing.Color.Gainsboro;
            this.LPDS_RNU.Location = new System.Drawing.Point(23, 36);
            this.LPDS_RNU.Name = "LPDS_RNU";
            this.LPDS_RNU.Size = new System.Drawing.Size(517, 20);
            this.LPDS_RNU.TabIndex = 6;
            this.LPDS_RNU.TabStop = false;
            // 
            // Place
            // 
            this.Place.Controls.Add(this.btnLPDSAdd);
            this.Place.Controls.Add(this.PlaceRN);
            this.Place.Controls.Add(this.label8);
            this.Place.Controls.Add(this.PlaceStatus);
            this.Place.Controls.Add(this.comboLPDS);
            this.Place.Controls.Add(this.checkLPDS);
            this.Place.Controls.Add(this.label7);
            this.Place.Controls.Add(this.Place_Name);
            this.Place.Controls.Add(this.label5);
            this.Place.Controls.Add(this.Place_RNU);
            this.Place.Location = new System.Drawing.Point(4, 22);
            this.Place.Name = "Place";
            this.Place.Padding = new System.Windows.Forms.Padding(3);
            this.Place.Size = new System.Drawing.Size(560, 190);
            this.Place.TabIndex = 3;
            this.Place.Text = "Площадка";
            this.Place.UseVisualStyleBackColor = true;
            // 
            // btnLPDSAdd
            // 
            this.btnLPDSAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLPDSAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLPDSAdd.Enabled = false;
            this.btnLPDSAdd.Image = global::SSPD.Properties.Resources.ui_button_navigation_back;
            this.btnLPDSAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLPDSAdd.Location = new System.Drawing.Point(448, 146);
            this.btnLPDSAdd.Name = "btnLPDSAdd";
            this.btnLPDSAdd.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnLPDSAdd.Size = new System.Drawing.Size(90, 23);
            this.btnLPDSAdd.TabIndex = 17;
            this.btnLPDSAdd.Text = "добавить";
            this.btnLPDSAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnLPDSAdd, "Добавить новую ЛПДС");
            this.btnLPDSAdd.UseVisualStyleBackColor = true;
            this.btnLPDSAdd.Click += new System.EventHandler(this.btnLPDSAdd_Click);
            // 
            // PlaceRN
            // 
            this.PlaceRN.Location = new System.Drawing.Point(112, 17);
            this.PlaceRN.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.PlaceRN.Name = "PlaceRN";
            this.PlaceRN.Size = new System.Drawing.Size(100, 20);
            this.PlaceRN.TabIndex = 16;
            this.PlaceRN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.PlaceRN, "Регистрационный номер объекта");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Номер объекта";
            // 
            // PlaceStatus
            // 
            this.PlaceStatus.AutoSize = true;
            this.PlaceStatus.Location = new System.Drawing.Point(456, 19);
            this.PlaceStatus.Name = "PlaceStatus";
            this.PlaceStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PlaceStatus.Size = new System.Drawing.Size(80, 17);
            this.PlaceStatus.TabIndex = 14;
            this.PlaceStatus.Text = "Действует";
            this.toolTip1.SetToolTip(this.PlaceStatus, "Статус объекта");
            this.PlaceStatus.UseVisualStyleBackColor = true;
            // 
            // comboLPDS
            // 
            this.comboLPDS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLPDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLPDS.Enabled = false;
            this.comboLPDS.FormattingEnabled = true;
            this.comboLPDS.Location = new System.Drawing.Point(139, 148);
            this.comboLPDS.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.comboLPDS.Name = "comboLPDS";
            this.comboLPDS.Size = new System.Drawing.Size(303, 21);
            this.comboLPDS.TabIndex = 13;
            // 
            // checkLPDS
            // 
            this.checkLPDS.AutoSize = true;
            this.checkLPDS.Location = new System.Drawing.Point(21, 150);
            this.checkLPDS.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.checkLPDS.Name = "checkLPDS";
            this.checkLPDS.Size = new System.Drawing.Size(112, 17);
            this.checkLPDS.TabIndex = 12;
            this.checkLPDS.Text = "В составе ЛПДС";
            this.toolTip1.SetToolTip(this.checkLPDS, "Площадка входит в состав ЛПДС");
            this.checkLPDS.UseVisualStyleBackColor = true;
            this.checkLPDS.CheckStateChanged += new System.EventHandler(this.checkLPDS_CheckStateChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Наименование площадки";
            // 
            // Place_Name
            // 
            this.Place_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Place_Name.BackColor = System.Drawing.Color.White;
            this.Place_Name.Location = new System.Drawing.Point(21, 113);
            this.Place_Name.Name = "Place_Name";
            this.Place_Name.Size = new System.Drawing.Size(517, 20);
            this.Place_Name.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Наименование районного управления";
            // 
            // Place_RNU
            // 
            this.Place_RNU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Place_RNU.BackColor = System.Drawing.Color.Gainsboro;
            this.Place_RNU.Location = new System.Drawing.Point(21, 65);
            this.Place_RNU.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.Place_RNU.Name = "Place_RNU";
            this.Place_RNU.Size = new System.Drawing.Size(515, 20);
            this.Place_RNU.TabIndex = 8;
            this.Place_RNU.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(592, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnSave,
            this.mbtnSepor,
            this.mbtnClose});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // mbtnSave
            // 
            this.mbtnSave.Name = "mbtnSave";
            this.mbtnSave.Size = new System.Drawing.Size(152, 22);
            this.mbtnSave.Text = "Сохранить";
            this.mbtnSave.Click += new System.EventHandler(this.mbtnSave_Click);
            // 
            // mbtnSepor
            // 
            this.mbtnSepor.Name = "mbtnSepor";
            this.mbtnSepor.Size = new System.Drawing.Size(149, 6);
            // 
            // mbtnClose
            // 
            this.mbtnClose.Name = "mbtnClose";
            this.mbtnClose.Size = new System.Drawing.Size(152, 22);
            this.mbtnClose.Text = "Закрыть";
            this.mbtnClose.Click += new System.EventHandler(this.mbtnClose_Click);
            // 
            // EditCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 303);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.LineSeparatorBottom);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "EditCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карточка объекта";
            this.Load += new System.EventHandler(this.EditCard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditCard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.MN.ResumeLayout(false);
            this.MN.PerformLayout();
            this.RNU.ResumeLayout(false);
            this.RNU.PerformLayout();
            this.LPDS.ResumeLayout(false);
            this.LPDS.PerformLayout();
            this.Place.ResumeLayout(false);
            this.Place.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox LineSeparatorBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage MN;
        private System.Windows.Forms.Button btnChangeOrg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MN_Name;
        private System.Windows.Forms.TabPage RNU;
        private System.Windows.Forms.TabPage LPDS;
        private System.Windows.Forms.TabPage Place;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtnSave;
        private System.Windows.Forms.ToolStripSeparator mbtnSepor;
        private System.Windows.Forms.ToolStripMenuItem mbtnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RNU_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RNU_MN_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LPDS_RNU;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Place_RNU;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LPDS_Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Place_Name;
        private System.Windows.Forms.ComboBox comboLPDS;
        private System.Windows.Forms.CheckBox checkLPDS;
        private System.Windows.Forms.CheckBox PlaceStatus;
        private System.Windows.Forms.TextBox PlaceRN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLPDSAdd;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}