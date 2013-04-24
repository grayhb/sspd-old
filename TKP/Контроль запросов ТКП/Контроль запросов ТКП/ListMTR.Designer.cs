namespace Контроль_запросов_ТКП
{
    partial class ListMTR
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.NameMTR = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Code = new System.Windows.Forms.TextBox();
            this.CBRazdel = new System.Windows.Forms.ComboBox();
            this.TV = new System.Windows.Forms.TreeView();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ОперацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Выбрать = new System.Windows.Forms.ToolStripMenuItem();
            this.Sepor1 = new System.Windows.Forms.ToolStripSeparator();
            this.ЗакрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ВидToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СвернутьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.РазвернутьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ДобавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ИзменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Filter = new System.Windows.Forms.TextBox();
            this.GroupBox1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.btnSave);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.btnCancel);
            this.GroupBox1.Controls.Add(this.NameMTR);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Code);
            this.GroupBox1.Controls.Add(this.CBRazdel);
            this.GroupBox1.Location = new System.Drawing.Point(13, 455);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(702, 156);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Карточка раздела МТР";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(582, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(19, 72);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(154, 13);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Наименование раздела МТР";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(461, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NameMTR
            // 
            this.NameMTR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NameMTR.Enabled = false;
            this.NameMTR.Location = new System.Drawing.Point(22, 88);
            this.NameMTR.Name = "NameMTR";
            this.NameMTR.Size = new System.Drawing.Size(539, 20);
            this.NameMTR.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(579, 72);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(26, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Код";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(19, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(147, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Раздел номенклатуры МТР";
            // 
            // Code
            // 
            this.Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Code.Enabled = false;
            this.Code.Location = new System.Drawing.Point(582, 88);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(100, 20);
            this.Code.TabIndex = 1;
            this.Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CBRazdel
            // 
            this.CBRazdel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CBRazdel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBRazdel.Enabled = false;
            this.CBRazdel.FormattingEnabled = true;
            this.CBRazdel.Location = new System.Drawing.Point(22, 40);
            this.CBRazdel.MaxDropDownItems = 16;
            this.CBRazdel.Name = "CBRazdel";
            this.CBRazdel.Size = new System.Drawing.Size(660, 21);
            this.CBRazdel.TabIndex = 0;
            // 
            // TV
            // 
            this.TV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TV.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TV.FullRowSelect = true;
            this.TV.HotTracking = true;
            this.TV.Indent = 36;
            this.TV.ItemHeight = 18;
            this.TV.Location = new System.Drawing.Point(13, 60);
            this.TV.Name = "TV";
            this.TV.Size = new System.Drawing.Size(702, 385);
            this.TV.TabIndex = 6;
            this.TV.DoubleClick += new System.EventHandler(this.TV_DoubleClick);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ОперацииToolStripMenuItem,
            this.ВидToolStripMenuItem,
            this.ЗаписиToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(727, 24);
            this.MenuStrip1.TabIndex = 4;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // ОперацииToolStripMenuItem
            // 
            this.ОперацииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Выбрать,
            this.Sepor1,
            this.ЗакрытьToolStripMenuItem});
            this.ОперацииToolStripMenuItem.Name = "ОперацииToolStripMenuItem";
            this.ОперацииToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.ОперацииToolStripMenuItem.Text = "Операции";
            // 
            // Выбрать
            // 
            this.Выбрать.Name = "Выбрать";
            this.Выбрать.Size = new System.Drawing.Size(152, 22);
            this.Выбрать.Text = "Выбрать";
            this.Выбрать.Click += new System.EventHandler(this.Выбрать_Click);
            // 
            // Sepor1
            // 
            this.Sepor1.Name = "Sepor1";
            this.Sepor1.Size = new System.Drawing.Size(149, 6);
            // 
            // ЗакрытьToolStripMenuItem
            // 
            this.ЗакрытьToolStripMenuItem.Name = "ЗакрытьToolStripMenuItem";
            this.ЗакрытьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ЗакрытьToolStripMenuItem.Text = "Закрыть";
            this.ЗакрытьToolStripMenuItem.Click += new System.EventHandler(this.ЗакрытьToolStripMenuItem_Click);
            // 
            // ВидToolStripMenuItem
            // 
            this.ВидToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.СвернутьВсеToolStripMenuItem,
            this.РазвернутьВсеToolStripMenuItem});
            this.ВидToolStripMenuItem.Name = "ВидToolStripMenuItem";
            this.ВидToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.ВидToolStripMenuItem.Text = "Вид";
            // 
            // СвернутьВсеToolStripMenuItem
            // 
            this.СвернутьВсеToolStripMenuItem.Name = "СвернутьВсеToolStripMenuItem";
            this.СвернутьВсеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.СвернутьВсеToolStripMenuItem.Text = "Свернуть все";
            this.СвернутьВсеToolStripMenuItem.Click += new System.EventHandler(this.СвернутьВсеToolStripMenuItem_Click);
            // 
            // РазвернутьВсеToolStripMenuItem
            // 
            this.РазвернутьВсеToolStripMenuItem.Name = "РазвернутьВсеToolStripMenuItem";
            this.РазвернутьВсеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.РазвернутьВсеToolStripMenuItem.Text = "Развернуть все";
            this.РазвернутьВсеToolStripMenuItem.Click += new System.EventHandler(this.РазвернутьВсеToolStripMenuItem_Click);
            // 
            // ЗаписиToolStripMenuItem
            // 
            this.ЗаписиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ДобавитьToolStripMenuItem,
            this.ИзменитьToolStripMenuItem});
            this.ЗаписиToolStripMenuItem.Name = "ЗаписиToolStripMenuItem";
            this.ЗаписиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.ЗаписиToolStripMenuItem.Text = "Записи";
            // 
            // ДобавитьToolStripMenuItem
            // 
            this.ДобавитьToolStripMenuItem.Name = "ДобавитьToolStripMenuItem";
            this.ДобавитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ДобавитьToolStripMenuItem.Text = "Добавить";
            this.ДобавитьToolStripMenuItem.Click += new System.EventHandler(this.ДобавитьToolStripMenuItem_Click);
            // 
            // ИзменитьToolStripMenuItem
            // 
            this.ИзменитьToolStripMenuItem.Name = "ИзменитьToolStripMenuItem";
            this.ИзменитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ИзменитьToolStripMenuItem.Text = "Изменить";
            this.ИзменитьToolStripMenuItem.Click += new System.EventHandler(this.ИзменитьToolStripMenuItem_Click);
            // 
            // Filter
            // 
            this.Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Filter.Location = new System.Drawing.Point(13, 34);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(702, 20);
            this.Filter.TabIndex = 8;
            this.Filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // ListMTR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 623);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.TV);
            this.Controls.Add(this.MenuStrip1);
            this.KeyPreview = true;
            this.Name = "ListMTR";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Реестр МТР";
            this.Load += new System.EventHandler(this.ListMTR_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListMTR_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TextBox NameMTR;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox Code;
        internal System.Windows.Forms.ComboBox CBRazdel;
        internal System.Windows.Forms.TreeView TV;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem ОперацииToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem Выбрать;
        internal System.Windows.Forms.ToolStripSeparator Sepor1;
        internal System.Windows.Forms.ToolStripMenuItem ЗакрытьToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ВидToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem СвернутьВсеToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem РазвернутьВсеToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ЗаписиToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ДобавитьToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ИзменитьToolStripMenuItem;
        private System.Windows.Forms.TextBox Filter;
    }
}