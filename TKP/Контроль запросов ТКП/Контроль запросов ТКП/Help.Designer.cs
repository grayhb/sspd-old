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
            this.Button1 = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(280, 127);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 9;
            this.Button1.Text = "Закрыть";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Khaki;
            this.Label4.Location = new System.Drawing.Point(12, 21);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 20);
            this.Label4.TabIndex = 7;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.LightCoral;
            this.Label3.Location = new System.Drawing.Point(12, 53);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(70, 20);
            this.Label3.TabIndex = 8;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.DarkRed;
            this.Label2.Location = new System.Drawing.Point(12, 88);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(70, 20);
            this.Label2.TabIndex = 6;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(88, 21);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(267, 20);
            this.Label6.TabIndex = 3;
            this.Label6.Text = "- прошло 5 дней с момента отправления ТКП";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(88, 53);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(267, 20);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "- осталось меньше 30 дней до окончания проекта ";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(88, 86);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(263, 26);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "- осталось меньше 30 дней до окончания проекта \r\nи прошло 5 дней с момента отправ" +
                "ления ТКП";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 164);
            this.ControlBox = false;
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Help";
            this.Opacity = 0.97D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Help_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label1;
    }
}