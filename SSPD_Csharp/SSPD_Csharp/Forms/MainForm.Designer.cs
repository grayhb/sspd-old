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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.МенюПроекты = new System.Windows.Forms.ToolStripMenuItem();
            this.МенюПроектыСписок = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuListObjKTN = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокРаботниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.МенюСписокРаботниковАдминистрирование = new System.Windows.Forms.ToolStripMenuItem();
            this.МенюСправочникСИМКарт = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникМобильныхТелефоновToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникТелефонныхТочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.положениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадомToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.вертикальноToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.горизонтальноToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.развернутьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.закрытьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.МенюПроекты,
            this.справочникиToolStripMenuItem,
            this.окноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.окноToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // МенюПроекты
            // 
            this.МенюПроекты.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.МенюПроектыСписок,
            this.toolStripSeparator1,
            this.MenuListObjKTN});
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
            this.МенюПроектыСписок.Size = new System.Drawing.Size(221, 22);
            this.МенюПроектыСписок.Text = "Список проектов";
            this.МенюПроектыСписок.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // MenuListObjKTN
            // 
            this.MenuListObjKTN.Name = "MenuListObjKTN";
            this.MenuListObjKTN.Size = new System.Drawing.Size(221, 22);
            this.MenuListObjKTN.Text = "Справочник объектов КТН";
            this.MenuListObjKTN.Click += new System.EventHandler(this.MenuListObjKTN_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокРаботниковToolStripMenuItem,
            this.МенюСписокРаботниковАдминистрирование,
            this.МенюСправочникСИМКарт,
            this.справочникМобильныхТелефоновToolStripMenuItem,
            this.справочникТелефонныхТочекToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // списокРаботниковToolStripMenuItem
            // 
            this.списокРаботниковToolStripMenuItem.Name = "списокРаботниковToolStripMenuItem";
            this.списокРаботниковToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.списокРаботниковToolStripMenuItem.Text = "Список сотрудников";
            this.списокРаботниковToolStripMenuItem.Click += new System.EventHandler(this.списокРаботниковToolStripMenuItem_Click);
            // 
            // МенюСписокРаботниковАдминистрирование
            // 
            this.МенюСписокРаботниковАдминистрирование.Name = "МенюСписокРаботниковАдминистрирование";
            this.МенюСписокРаботниковАдминистрирование.Size = new System.Drawing.Size(303, 22);
            this.МенюСписокРаботниковАдминистрирование.Text = "Список сотрудников (администрирование)";
            this.МенюСписокРаботниковАдминистрирование.Click += new System.EventHandler(this.списокРаботниковадминистрированиеToolStripMenuItem_Click);
            // 
            // МенюСправочникСИМКарт
            // 
            this.МенюСправочникСИМКарт.Name = "МенюСправочникСИМКарт";
            this.МенюСправочникСИМКарт.Size = new System.Drawing.Size(303, 22);
            this.МенюСправочникСИМКарт.Text = "Справочник SIM карт";
            this.МенюСправочникСИМКарт.Click += new System.EventHandler(this.МенюСправочникСИМКарт_Click);
            // 
            // справочникМобильныхТелефоновToolStripMenuItem
            // 
            this.справочникМобильныхТелефоновToolStripMenuItem.Name = "справочникМобильныхТелефоновToolStripMenuItem";
            this.справочникМобильныхТелефоновToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.справочникМобильныхТелефоновToolStripMenuItem.Text = "Справочник мобильных телефонов";
            this.справочникМобильныхТелефоновToolStripMenuItem.Click += new System.EventHandler(this.справочникМобильныхТелефоновToolStripMenuItem_Click);
            // 
            // справочникТелефонныхТочекToolStripMenuItem
            // 
            this.справочникТелефонныхТочекToolStripMenuItem.Name = "справочникТелефонныхТочекToolStripMenuItem";
            this.справочникТелефонныхТочекToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.справочникТелефонныхТочекToolStripMenuItem.Text = "Справочник телефонных точек";
            this.справочникТелефонныхТочекToolStripMenuItem.Click += new System.EventHandler(this.справочникТелефонныхТочекToolStripMenuItem_Click);
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.положениеToolStripMenuItem,
            this.toolStripSeparator2});
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.окноToolStripMenuItem.Text = "Окно";
            // 
            // положениеToolStripMenuItem
            // 
            this.положениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадомToolStripMenuItem1,
            this.вертикальноToolStripMenuItem1,
            this.горизонтальноToolStripMenuItem1,
            this.toolStripSeparator3,
            this.свернутьToolStripMenuItem,
            this.развернутьВсеToolStripMenuItem,
            this.toolStripSeparator4,
            this.закрытьВсеToolStripMenuItem});
            this.положениеToolStripMenuItem.Name = "положениеToolStripMenuItem";
            this.положениеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.положениеToolStripMenuItem.Text = "Положение";
            // 
            // каскадомToolStripMenuItem1
            // 
            this.каскадомToolStripMenuItem1.Name = "каскадомToolStripMenuItem1";
            this.каскадомToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.каскадомToolStripMenuItem1.Text = "Каскадом";
            this.каскадомToolStripMenuItem1.Click += new System.EventHandler(this.каскадомToolStripMenuItem1_Click);
            // 
            // вертикальноToolStripMenuItem1
            // 
            this.вертикальноToolStripMenuItem1.Name = "вертикальноToolStripMenuItem1";
            this.вертикальноToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.вертикальноToolStripMenuItem1.Text = "Вертикально";
            this.вертикальноToolStripMenuItem1.Click += new System.EventHandler(this.вертикальноToolStripMenuItem1_Click);
            // 
            // горизонтальноToolStripMenuItem1
            // 
            this.горизонтальноToolStripMenuItem1.Name = "горизонтальноToolStripMenuItem1";
            this.горизонтальноToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.горизонтальноToolStripMenuItem1.Text = "Горизонтально";
            this.горизонтальноToolStripMenuItem1.Click += new System.EventHandler(this.горизонтальноToolStripMenuItem1_Click);
            // 
            // свернутьToolStripMenuItem
            // 
            this.свернутьToolStripMenuItem.Name = "свернутьToolStripMenuItem";
            this.свернутьToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.свернутьToolStripMenuItem.Text = "Свернуть все";
            this.свернутьToolStripMenuItem.Click += new System.EventHandler(this.свернутьToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 650);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(952, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            // 
            // развернутьВсеToolStripMenuItem
            // 
            this.развернутьВсеToolStripMenuItem.Name = "развернутьВсеToolStripMenuItem";
            this.развернутьВсеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.развернутьВсеToolStripMenuItem.Text = "Развернуть все";
            this.развернутьВсеToolStripMenuItem.Click += new System.EventHandler(this.развернутьВсеToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // закрытьВсеToolStripMenuItem
            // 
            this.закрытьВсеToolStripMenuItem.Name = "закрытьВсеToolStripMenuItem";
            this.закрытьВсеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.закрытьВсеToolStripMenuItem.Text = "Закрыть все";
            this.закрытьВсеToolStripMenuItem.Click += new System.EventHandler(this.закрытьВсеToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(36)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(952, 673);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.progressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.ToolStripMenuItem МенюСписокРаботниковАдминистрирование;
        private System.Windows.Forms.ToolStripMenuItem МенюСправочникСИМКарт;
        private System.Windows.Forms.ToolStripMenuItem справочникМобильныхТелефоновToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникТелефонныхТочекToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuListObjKTN;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem положениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem вертикальноToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem горизонтальноToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem свернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem развернутьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem закрытьВсеToolStripMenuItem;
    }
}

