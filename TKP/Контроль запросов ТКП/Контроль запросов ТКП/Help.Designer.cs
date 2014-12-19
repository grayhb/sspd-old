namespace Контроль_запросов_ТКП
{
    partial class Help
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.LabelBG1 = new System.Windows.Forms.Label();
            this.LabelBG2 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(277, 97);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Закрыть";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // LabelBG1
            // 
            this.LabelBG1.BackColor = System.Drawing.Color.Khaki;
            this.LabelBG1.Location = new System.Drawing.Point(21, 21);
            this.LabelBG1.Name = "LabelBG1";
            this.LabelBG1.Size = new System.Drawing.Size(70, 20);
            this.LabelBG1.TabIndex = 7;
            // 
            // LabelBG2
            // 
            this.LabelBG2.BackColor = System.Drawing.Color.DimGray;
            this.LabelBG2.Location = new System.Drawing.Point(19, 59);
            this.LabelBG2.Name = "LabelBG2";
            this.LabelBG2.Size = new System.Drawing.Size(70, 20);
            this.LabelBG2.TabIndex = 11;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(95, 63);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(10, 13);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "-";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(97, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(267, 20);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "-";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 150);
            this.Controls.Add(this.LabelBG2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.LabelBG1);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Help";
            this.Opacity = 0.97D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.Load += new System.EventHandler(this.Help_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Help_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Label LabelBG1;
        internal System.Windows.Forms.Label LabelBG2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}