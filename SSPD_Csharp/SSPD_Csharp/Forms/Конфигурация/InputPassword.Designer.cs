namespace SSPD
{
    partial class InputPassword
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
            this.InputPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InputPass
            // 
            this.InputPass.Location = new System.Drawing.Point(16, 16);
            this.InputPass.Name = "InputPass";
            this.InputPass.PasswordChar = '*';
            this.InputPass.Size = new System.Drawing.Size(190, 20);
            this.InputPass.TabIndex = 0;
            this.InputPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InputPass.WordWrap = false;
            // 
            // InputPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 52);
            this.ControlBox = false;
            this.Controls.Add(this.InputPass);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "InputPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ССПД : Конфигуратор";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputPass;

    }
}