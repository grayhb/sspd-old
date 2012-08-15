namespace SSPD.Select
{
    partial class SelectPar
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ParLabel = new System.Windows.Forms.Label();
            this.Par = new System.Windows.Forms.ComboBox();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(407, 65);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Location = new System.Drawing.Point(326, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ОК";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ParLabel
            // 
            this.ParLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ParLabel.AutoSize = true;
            this.ParLabel.Location = new System.Drawing.Point(12, 10);
            this.ParLabel.Name = "ParLabel";
            this.ParLabel.Size = new System.Drawing.Size(0, 13);
            this.ParLabel.TabIndex = 32;
            // 
            // Par
            // 
            this.Par.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Par.FormattingEnabled = true;
            this.Par.Location = new System.Drawing.Point(12, 26);
            this.Par.Name = "Par";
            this.Par.Size = new System.Drawing.Size(470, 21);
            this.Par.TabIndex = 1;
            // 
            // LineSeparatorBottom
            // 
            this.LineSeparatorBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LineSeparatorBottom.BackgroundImage = global::SSPD.Properties.Resources.LineSeparator;
            this.LineSeparatorBottom.Location = new System.Drawing.Point(12, 55);
            this.LineSeparatorBottom.Name = "LineSeparatorBottom";
            this.LineSeparatorBottom.Size = new System.Drawing.Size(470, 2);
            this.LineSeparatorBottom.TabIndex = 29;
            this.LineSeparatorBottom.TabStop = false;
            // 
            // SelectPar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 100);
            this.Controls.Add(this.Par);
            this.Controls.Add(this.ParLabel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.LineSeparatorBottom);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectPar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SelectPar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectPar_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox LineSeparatorBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label ParLabel;
        public System.Windows.Forms.ComboBox Par;
    }
}