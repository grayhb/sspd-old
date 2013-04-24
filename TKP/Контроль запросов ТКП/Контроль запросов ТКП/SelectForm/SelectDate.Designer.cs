namespace Контроль_запросов_ТКП.SelectForm
{
    partial class SelectDate
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
            this.mCalendar = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // mCalendar
            // 
            this.mCalendar.Location = new System.Drawing.Point(6, 6);
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 1;
            this.mCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mCalendar_DateSelected);
            this.mCalendar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mCalendar_KeyDown);
            this.mCalendar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mCalendar_MouseDown);
            // 
            // SelectDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 167);
            this.Controls.Add(this.mCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "SelectDate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Выбор даты";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectDate_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.MonthCalendar mCalendar;

    }
}