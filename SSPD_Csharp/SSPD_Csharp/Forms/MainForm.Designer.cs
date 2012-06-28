namespace SSPD
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.МенюПроекты = new System.Windows.Forms.ToolStripMenuItem();
            this.МенюПроектыСписок = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокРаботниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.МенюПроекты,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // МенюПроекты
            // 
            this.МенюПроекты.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.МенюПроектыСписок});
            this.МенюПроекты.Name = "МенюПроекты";
            this.МенюПроекты.Size = new System.Drawing.Size(64, 20);
            this.МенюПроекты.Text = "Проекты";
            // 
            // МенюПроектыСписок
            // 
            this.МенюПроектыСписок.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.МенюПроектыСписок.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.МенюПроектыСписок.Name = "МенюПроектыСписок";
            this.МенюПроектыСписок.ShowShortcutKeys = false;
            this.МенюПроектыСписок.Size = new System.Drawing.Size(154, 22);
            this.МенюПроектыСписок.Text = "Список проектов";
            this.МенюПроектыСписок.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокРаботниковToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // списокРаботниковToolStripMenuItem
            // 
            this.списокРаботниковToolStripMenuItem.Name = "списокРаботниковToolStripMenuItem";
            this.списокРаботниковToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.списокРаботниковToolStripMenuItem.Text = "Список работников";
            this.списокРаботниковToolStripMenuItem.Click += new System.EventHandler(this.списокРаботниковToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(36)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(952, 673);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система Сопровождения Проектной Деятельности";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem МенюПроекты;
        private System.Windows.Forms.ToolStripMenuItem МенюПроектыСписок;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокРаботниковToolStripMenuItem;
    }
}

