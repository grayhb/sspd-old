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
            this.lblIMEI = new System.Windows.Forms.Label();
            this.Inv = new System.Windows.Forms.TextBox();
            this.lblInv = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.TextBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
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
            // lblIMEI
            // 
            this.lblIMEI.AutoSize = true;
            this.lblIMEI.Location = new System.Drawing.Point(12, 15);
            this.lblIMEI.Name = "lblIMEI";
            this.lblIMEI.Size = new System.Drawing.Size(82, 13);
            this.lblIMEI.TabIndex = 13;
            this.lblIMEI.Text = "IMEI аппарата:";
            // 
            // Inv
            // 
            this.Inv.Location = new System.Drawing.Point(129, 38);
            this.Inv.MaxLength = 10;
            this.Inv.Name = "Inv";
            this.Inv.Size = new System.Drawing.Size(251, 20);
            this.Inv.TabIndex = 16;
            // 
            // lblInv
            // 
            this.lblInv.AutoSize = true;
            this.lblInv.Location = new System.Drawing.Point(12, 41);
            this.lblInv.Name = "lblInv";
            this.lblInv.Size = new System.Drawing.Size(114, 13);
            this.lblInv.TabIndex = 15;
            this.lblInv.Text = "Инвентарный номер:";
            // 
            // Label
            // 
            this.Label.Location = new System.Drawing.Point(129, 64);
            this.Label.MaxLength = 20;
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(251, 20);
            this.Label.TabIndex = 18;
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(12, 67);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(93, 13);
            this.lblLabel.TabIndex = 17;
            this.lblLabel.Text = "Марка аппарата:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Location = new System.Drawing.Point(224, 103);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "ОК";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(305, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PhoneApCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 138);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.LineSeparatorBottom);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.Inv);
            this.Controls.Add(this.lblInv);
            this.Controls.Add(this.IMEI);
            this.Controls.Add(this.lblIMEI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PhoneApCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Load += new System.EventHandler(this.PhoneApCard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PhoneApCard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IMEI;
        private System.Windows.Forms.Label lblIMEI;
        private System.Windows.Forms.TextBox Inv;
        private System.Windows.Forms.Label lblInv;
        private System.Windows.Forms.TextBox Label;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox LineSeparatorBottom;
        private System.Windows.Forms.Button btnCancel;
    }
}