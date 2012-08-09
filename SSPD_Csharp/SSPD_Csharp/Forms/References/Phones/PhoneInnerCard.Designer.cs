namespace SSPD
{
    partial class PhoneInnerCard
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
            this.lblPhoneInner = new System.Windows.Forms.Label();
            this.lblPhoneTown = new System.Windows.Forms.Label();
            this.lblPhoneMATS = new System.Windows.Forms.Label();
            this.lblPhoneGroup = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.PhoneInner = new System.Windows.Forms.TextBox();
            this.Room = new System.Windows.Forms.TextBox();
            this.PhoneTown = new System.Windows.Forms.ComboBox();
            this.PhoneMATS = new System.Windows.Forms.ComboBox();
            this.PhoneGroup = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPhoneInner
            // 
            this.lblPhoneInner.AutoSize = true;
            this.lblPhoneInner.Location = new System.Drawing.Point(12, 15);
            this.lblPhoneInner.Name = "lblPhoneInner";
            this.lblPhoneInner.Size = new System.Drawing.Size(104, 13);
            this.lblPhoneInner.TabIndex = 13;
            this.lblPhoneInner.Text = "Внутренний номер:";
            // 
            // lblPhoneTown
            // 
            this.lblPhoneTown.AutoSize = true;
            this.lblPhoneTown.Location = new System.Drawing.Point(12, 41);
            this.lblPhoneTown.Name = "lblPhoneTown";
            this.lblPhoneTown.Size = new System.Drawing.Size(99, 13);
            this.lblPhoneTown.TabIndex = 14;
            this.lblPhoneTown.Text = "Городской номер:";
            // 
            // lblPhoneMATS
            // 
            this.lblPhoneMATS.AutoSize = true;
            this.lblPhoneMATS.Location = new System.Drawing.Point(12, 68);
            this.lblPhoneMATS.Name = "lblPhoneMATS";
            this.lblPhoneMATS.Size = new System.Drawing.Size(88, 13);
            this.lblPhoneMATS.TabIndex = 15;
            this.lblPhoneMATS.Text = "Телефон МАТС:";
            // 
            // lblPhoneGroup
            // 
            this.lblPhoneGroup.AutoSize = true;
            this.lblPhoneGroup.Location = new System.Drawing.Point(12, 95);
            this.lblPhoneGroup.Name = "lblPhoneGroup";
            this.lblPhoneGroup.Size = new System.Drawing.Size(94, 13);
            this.lblPhoneGroup.TabIndex = 16;
            this.lblPhoneGroup.Text = "Телефон группы:";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(12, 122);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(52, 13);
            this.lblRoom.TabIndex = 17;
            this.lblRoom.Text = "Кабинет:";
            // 
            // PhoneInner
            // 
            this.PhoneInner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PhoneInner.Location = new System.Drawing.Point(130, 12);
            this.PhoneInner.MaxLength = 10;
            this.PhoneInner.Name = "PhoneInner";
            this.PhoneInner.Size = new System.Drawing.Size(121, 20);
            this.PhoneInner.TabIndex = 18;
            // 
            // Room
            // 
            this.Room.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Room.Location = new System.Drawing.Point(130, 119);
            this.Room.MaxLength = 5;
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(121, 20);
            this.Room.TabIndex = 19;
            // 
            // PhoneTown
            // 
            this.PhoneTown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PhoneTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PhoneTown.FormattingEnabled = true;
            this.PhoneTown.Location = new System.Drawing.Point(130, 38);
            this.PhoneTown.Name = "PhoneTown";
            this.PhoneTown.Size = new System.Drawing.Size(121, 21);
            this.PhoneTown.TabIndex = 20;
            // 
            // PhoneMATS
            // 
            this.PhoneMATS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PhoneMATS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PhoneMATS.FormattingEnabled = true;
            this.PhoneMATS.Location = new System.Drawing.Point(130, 65);
            this.PhoneMATS.Name = "PhoneMATS";
            this.PhoneMATS.Size = new System.Drawing.Size(121, 21);
            this.PhoneMATS.TabIndex = 21;
            // 
            // PhoneGroup
            // 
            this.PhoneGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PhoneGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PhoneGroup.FormattingEnabled = true;
            this.PhoneGroup.Location = new System.Drawing.Point(130, 92);
            this.PhoneGroup.Name = "PhoneGroup";
            this.PhoneGroup.Size = new System.Drawing.Size(121, 21);
            this.PhoneGroup.TabIndex = 22;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(176, 158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LineSeparatorBottom
            // 
            this.LineSeparatorBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LineSeparatorBottom.BackgroundImage = global::SSPD.Properties.Resources.LineSeparator;
            this.LineSeparatorBottom.Location = new System.Drawing.Point(12, 148);
            this.LineSeparatorBottom.Name = "LineSeparatorBottom";
            this.LineSeparatorBottom.Size = new System.Drawing.Size(239, 2);
            this.LineSeparatorBottom.TabIndex = 29;
            this.LineSeparatorBottom.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Location = new System.Drawing.Point(95, 158);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "ОК";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PhoneInnerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 193);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.LineSeparatorBottom);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.PhoneGroup);
            this.Controls.Add(this.PhoneMATS);
            this.Controls.Add(this.PhoneTown);
            this.Controls.Add(this.Room);
            this.Controls.Add(this.PhoneInner);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblPhoneGroup);
            this.Controls.Add(this.lblPhoneMATS);
            this.Controls.Add(this.lblPhoneTown);
            this.Controls.Add(this.lblPhoneInner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PhoneInnerCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.PhoneInnerCard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PhoneInnerCard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPhoneInner;
        private System.Windows.Forms.Label lblPhoneTown;
        private System.Windows.Forms.Label lblPhoneMATS;
        private System.Windows.Forms.Label lblPhoneGroup;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox PhoneInner;
        private System.Windows.Forms.TextBox Room;
        private System.Windows.Forms.ComboBox PhoneTown;
        private System.Windows.Forms.ComboBox PhoneMATS;
        private System.Windows.Forms.ComboBox PhoneGroup;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox LineSeparatorBottom;
        private System.Windows.Forms.Button btnSave;
    }
}