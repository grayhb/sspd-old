﻿namespace Контроль_запросов_ТКП.SelectForm
{
    partial class SelectPeriod
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DFrom = new System.Windows.Forms.TextBox();
            this.DTo = new System.Windows.Forms.TextBox();
            this.btnSelDate1 = new System.Windows.Forms.Button();
            this.btnSelDate2 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "по";
            // 
            // DFrom
            // 
            this.DFrom.Location = new System.Drawing.Point(62, 15);
            this.DFrom.Name = "DFrom";
            this.DFrom.Size = new System.Drawing.Size(109, 20);
            this.DFrom.TabIndex = 2;
            // 
            // DTo
            // 
            this.DTo.Location = new System.Drawing.Point(62, 44);
            this.DTo.Name = "DTo";
            this.DTo.Size = new System.Drawing.Size(109, 20);
            this.DTo.TabIndex = 3;
            // 
            // btnSelDate1
            // 
            this.btnSelDate1.Location = new System.Drawing.Point(177, 13);
            this.btnSelDate1.Name = "btnSelDate1";
            this.btnSelDate1.Size = new System.Drawing.Size(25, 23);
            this.btnSelDate1.TabIndex = 4;
            this.btnSelDate1.Text = "...";
            this.btnSelDate1.UseVisualStyleBackColor = true;
            this.btnSelDate1.Click += new System.EventHandler(this.btnSelDate1_Click);
            // 
            // btnSelDate2
            // 
            this.btnSelDate2.Location = new System.Drawing.Point(177, 42);
            this.btnSelDate2.Name = "btnSelDate2";
            this.btnSelDate2.Size = new System.Drawing.Size(25, 23);
            this.btnSelDate2.TabIndex = 5;
            this.btnSelDate2.Text = "...";
            this.btnSelDate2.UseVisualStyleBackColor = true;
            this.btnSelDate2.Click += new System.EventHandler(this.btnSelDate2_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 77);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butOK.Location = new System.Drawing.Point(116, 77);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(88, 23);
            this.butOK.TabIndex = 7;
            this.butOK.Text = "Принять";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // SelectPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 112);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelDate2);
            this.Controls.Add(this.btnSelDate1);
            this.Controls.Add(this.DTo);
            this.Controls.Add(this.DFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectPeriod";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор периода";
            this.Load += new System.EventHandler(this.SelectPeriod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DFrom;
        private System.Windows.Forms.TextBox DTo;
        private System.Windows.Forms.Button btnSelDate1;
        private System.Windows.Forms.Button btnSelDate2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button butOK;
    }
}