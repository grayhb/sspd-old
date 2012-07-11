namespace SSPD
{
    partial class PhoneApCard
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
            this.IMEI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Inv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // IMEI
            // 
            this.IMEI.Location = new System.Drawing.Point(129, 12);
            this.IMEI.MaxLength = 20;
            this.IMEI.Name = "IMEI";
            this.IMEI.Size = new System.Drawing.Size(251, 20);
            this.IMEI.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "IMEI аппарата:";
            // 
            // Inv
            // 
            this.Inv.Location = new System.Drawing.Point(129, 38);
            this.Inv.MaxLength = 10;
            this.Inv.Name = "Inv";
            this.Inv.Size = new System.Drawing.Size(251, 20);
            this.Inv.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Инвентарный номер:";
            // 
            // Label
            // 
            this.Label.Location = new System.Drawing.Point(129, 64);
            this.Label.MaxLength = 20;
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(251, 20);
            this.Label.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Марка аппарата:";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSave.Location = new System.Drawing.Point(224, 103);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 25;
            this.buttonSave.Text = "ОК";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // LineSeparatorBottom
            // 
            this.LineSeparatorBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LineSeparatorBottom.BackgroundImage = global::SSPD.Properties.Resources.LineSeparator;
            this.LineSeparatorBottom.Location = new System.Drawing.Point(12, 93);
            this.LineSeparatorBottom.Name = "LineSeparatorBottom";
            this.LineSeparatorBottom.Size = new System.Drawing.Size(368, 2);
            this.LineSeparatorBottom.TabIndex = 26;
            this.LineSeparatorBottom.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonCancel.Location = new System.Drawing.Point(305, 103);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 27;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // PhoneApCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 138);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.LineSeparatorBottom);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Inv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IMEI);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PhoneApCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PhoneApCard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IMEI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Inv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PictureBox LineSeparatorBottom;
        private System.Windows.Forms.Button buttonCancel;
    }
}