namespace SSPD
{
    partial class WorkersSprav
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkersSprav));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeSGTP = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Room = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NPost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NOtdel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PWorker = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NWorker = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Foto = new System.Windows.Forms.PictureBox();
            this.FWorker = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IPPhoneNamber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ANamber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.PhoneGroup = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.PhoneInner = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PhoneMATS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PhoneTown = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.StrFind = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Foto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 446);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(992, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.ShortcutKeyDisplayString = "ESC";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // treeSGTP
            // 
            this.treeSGTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeSGTP.FullRowSelect = true;
            this.treeSGTP.HideSelection = false;
            this.treeSGTP.ImageIndex = 0;
            this.treeSGTP.ImageList = this.imageList1;
            this.treeSGTP.Indent = 25;
            this.treeSGTP.ItemHeight = 18;
            this.treeSGTP.LineColor = System.Drawing.Color.Gray;
            this.treeSGTP.Location = new System.Drawing.Point(12, 65);
            this.treeSGTP.Name = "treeSGTP";
            this.treeSGTP.SelectedImageIndex = 1;
            this.treeSGTP.Size = new System.Drawing.Size(466, 367);
            this.treeSGTP.TabIndex = 2;
            this.treeSGTP.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSGTP_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder-horizontal_16.png");
            this.imageList1.Images.SetKeyName(1, "folder-horizontal-open_16.png");
            this.imageList1.Images.SetKeyName(2, "user-white_16.png");
            this.imageList1.Images.SetKeyName(3, "user-business-boss_16.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Room);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.NPost);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NOtdel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.PWorker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.NWorker);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Foto);
            this.groupBox1.Controls.Add(this.FWorker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(484, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 208);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основные сведения";
            // 
            // Room
            // 
            this.Room.BackColor = System.Drawing.Color.White;
            this.Room.Location = new System.Drawing.Point(81, 175);
            this.Room.Name = "Room";
            this.Room.ReadOnly = true;
            this.Room.Size = new System.Drawing.Size(75, 20);
            this.Room.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Комната";
            // 
            // NPost
            // 
            this.NPost.BackColor = System.Drawing.Color.White;
            this.NPost.Location = new System.Drawing.Point(81, 141);
            this.NPost.Name = "NPost";
            this.NPost.ReadOnly = true;
            this.NPost.Size = new System.Drawing.Size(263, 20);
            this.NPost.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Должность";
            // 
            // NOtdel
            // 
            this.NOtdel.BackColor = System.Drawing.Color.White;
            this.NOtdel.Location = new System.Drawing.Point(81, 115);
            this.NOtdel.Name = "NOtdel";
            this.NOtdel.ReadOnly = true;
            this.NOtdel.Size = new System.Drawing.Size(263, 20);
            this.NOtdel.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Отдел";
            // 
            // PWorker
            // 
            this.PWorker.BackColor = System.Drawing.Color.White;
            this.PWorker.Location = new System.Drawing.Point(81, 72);
            this.PWorker.Name = "PWorker";
            this.PWorker.ReadOnly = true;
            this.PWorker.Size = new System.Drawing.Size(263, 20);
            this.PWorker.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Отчество";
            // 
            // NWorker
            // 
            this.NWorker.BackColor = System.Drawing.Color.White;
            this.NWorker.Location = new System.Drawing.Point(81, 46);
            this.NWorker.Name = "NWorker";
            this.NWorker.ReadOnly = true;
            this.NWorker.Size = new System.Drawing.Size(263, 20);
            this.NWorker.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Имя";
            // 
            // Foto
            // 
            this.Foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Foto.ErrorImage = global::SSPD.Properties.Resources.no_images;
            this.Foto.Image = global::SSPD.Properties.Resources.no_images;
            this.Foto.Location = new System.Drawing.Point(354, 20);
            this.Foto.Name = "Foto";
            this.Foto.Size = new System.Drawing.Size(130, 175);
            this.Foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Foto.TabIndex = 2;
            this.Foto.TabStop = false;
            // 
            // FWorker
            // 
            this.FWorker.BackColor = System.Drawing.Color.White;
            this.FWorker.Location = new System.Drawing.Point(81, 20);
            this.FWorker.Name = "FWorker";
            this.FWorker.ReadOnly = true;
            this.FWorker.Size = new System.Drawing.Size(263, 20);
            this.FWorker.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Фамилия";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.IPPhoneNamber);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.ANamber);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.PhoneGroup);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.PhoneInner);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.PhoneMATS);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.PhoneTown);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(484, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 187);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сведения о рабочих телефонах";
            // 
            // IPPhoneNamber
            // 
            this.IPPhoneNamber.BackColor = System.Drawing.Color.White;
            this.IPPhoneNamber.Location = new System.Drawing.Point(132, 152);
            this.IPPhoneNamber.Name = "IPPhoneNamber";
            this.IPPhoneNamber.ReadOnly = true;
            this.IPPhoneNamber.Size = new System.Drawing.Size(352, 20);
            this.IPPhoneNamber.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(75, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "IP Phone";
            // 
            // ANamber
            // 
            this.ANamber.BackColor = System.Drawing.Color.White;
            this.ANamber.Location = new System.Drawing.Point(132, 126);
            this.ANamber.Name = "ANamber";
            this.ANamber.ReadOnly = true;
            this.ANamber.Size = new System.Drawing.Size(352, 20);
            this.ANamber.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Телефон мобильный";
            // 
            // PhoneGroup
            // 
            this.PhoneGroup.BackColor = System.Drawing.Color.White;
            this.PhoneGroup.Location = new System.Drawing.Point(132, 100);
            this.PhoneGroup.Name = "PhoneGroup";
            this.PhoneGroup.ReadOnly = true;
            this.PhoneGroup.Size = new System.Drawing.Size(352, 20);
            this.PhoneGroup.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Телефон группы";
            // 
            // PhoneInner
            // 
            this.PhoneInner.BackColor = System.Drawing.Color.White;
            this.PhoneInner.Location = new System.Drawing.Point(132, 74);
            this.PhoneInner.Name = "PhoneInner";
            this.PhoneInner.ReadOnly = true;
            this.PhoneInner.Size = new System.Drawing.Size(352, 20);
            this.PhoneInner.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Телефон внутренний";
            // 
            // PhoneMATS
            // 
            this.PhoneMATS.BackColor = System.Drawing.Color.White;
            this.PhoneMATS.Location = new System.Drawing.Point(132, 48);
            this.PhoneMATS.Name = "PhoneMATS";
            this.PhoneMATS.ReadOnly = true;
            this.PhoneMATS.Size = new System.Drawing.Size(352, 20);
            this.PhoneMATS.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Телефон МАТС";
            // 
            // PhoneTown
            // 
            this.PhoneTown.BackColor = System.Drawing.Color.White;
            this.PhoneTown.Location = new System.Drawing.Point(132, 22);
            this.PhoneTown.Name = "PhoneTown";
            this.PhoneTown.ReadOnly = true;
            this.PhoneTown.Size = new System.Drawing.Size(352, 20);
            this.PhoneTown.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Телефон городской";
            // 
            // StrFind
            // 
            this.StrFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StrFind.ForeColor = System.Drawing.Color.DarkGray;
            this.StrFind.Location = new System.Drawing.Point(12, 38);
            this.StrFind.MaxLength = 255;
            this.StrFind.Name = "StrFind";
            this.StrFind.Size = new System.Drawing.Size(372, 20);
            this.StrFind.TabIndex = 7;
            this.StrFind.Text = "Введите строку для поиска";
            this.StrFind.WordWrap = false;
            this.StrFind.TextChanged += new System.EventHandler(this.StrFind_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Image = global::SSPD.Properties.Resources.binocular_small;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(390, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 6;
            this.button1.TabStop = false;
            this.button1.Text = "найти [F7]";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WorkersSprav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 468);
            this.Controls.Add(this.StrFind);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeSGTP);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(729, 495);
            this.Name = "WorkersSprav";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник работников";
            this.Load += new System.EventHandler(this.WorkersSprav_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Foto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TreeView treeSGTP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox StrFind;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox Room;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NPost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NOtdel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PWorker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NWorker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox Foto;
        private System.Windows.Forms.TextBox FWorker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPPhoneNamber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ANamber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox PhoneGroup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox PhoneInner;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PhoneMATS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PhoneTown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}