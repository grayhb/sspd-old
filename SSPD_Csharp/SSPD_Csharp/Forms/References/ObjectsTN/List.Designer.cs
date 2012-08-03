namespace SSPD.ObjectsTN
{
    partial class List
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(List));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StrFind = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.МенюОбъекты = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВеткиМНToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВеткиРНУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВеткиЛПДСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.раскрытьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeObj = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CntMNLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntRNULabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntLPDSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CntPlaceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StrFind,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 5, 1, 5);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(782, 33);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StrFind
            // 
            this.StrFind.ForeColor = System.Drawing.Color.DarkGray;
            this.StrFind.Margin = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.StrFind.MaxLength = 255;
            this.StrFind.Name = "StrFind";
            this.StrFind.Size = new System.Drawing.Size(300, 23);
            this.StrFind.Text = "Введите строку для поиска";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::SSPD.Properties.Resources.binocular_small;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(80, 20);
            this.toolStripButton1.Text = "найти [F7]";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операцииToolStripMenuItem,
            this.МенюОбъекты,
            this.видToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.выходToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.выходToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeyDisplayString = "ESC";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.выходToolStripMenuItem.Text = "Закрыть";
            // 
            // МенюОбъекты
            // 
            this.МенюОбъекты.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.МенюОбъекты.Name = "МенюОбъекты";
            this.МенюОбъекты.Size = new System.Drawing.Size(66, 20);
            this.МенюОбъекты.Text = "Объекты";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.свернутьВеткиМНToolStripMenuItem,
            this.свернутьВеткиРНУToolStripMenuItem,
            this.свернутьВеткиЛПДСToolStripMenuItem,
            this.toolStripSeparator1,
            this.раскрытьВсеToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // свернутьВеткиМНToolStripMenuItem
            // 
            this.свернутьВеткиМНToolStripMenuItem.Name = "свернутьВеткиМНToolStripMenuItem";
            this.свернутьВеткиМНToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.свернутьВеткиМНToolStripMenuItem.Text = "Свернуть ветки ОСТ";
            this.свернутьВеткиМНToolStripMenuItem.Click += new System.EventHandler(this.свернутьВеткиМНToolStripMenuItem_Click);
            // 
            // свернутьВеткиРНУToolStripMenuItem
            // 
            this.свернутьВеткиРНУToolStripMenuItem.Name = "свернутьВеткиРНУToolStripMenuItem";
            this.свернутьВеткиРНУToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.свернутьВеткиРНУToolStripMenuItem.Text = "Свернуть ветки РНУ";
            this.свернутьВеткиРНУToolStripMenuItem.Click += new System.EventHandler(this.свернутьВеткиРНУToolStripMenuItem_Click);
            // 
            // свернутьВеткиЛПДСToolStripMenuItem
            // 
            this.свернутьВеткиЛПДСToolStripMenuItem.Name = "свернутьВеткиЛПДСToolStripMenuItem";
            this.свернутьВеткиЛПДСToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.свернутьВеткиЛПДСToolStripMenuItem.Text = "Свернуть ветки ЛПДС";
            this.свернутьВеткиЛПДСToolStripMenuItem.Click += new System.EventHandler(this.свернутьВеткиЛПДСToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // раскрытьВсеToolStripMenuItem
            // 
            this.раскрытьВсеToolStripMenuItem.Name = "раскрытьВсеToolStripMenuItem";
            this.раскрытьВсеToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.раскрытьВсеToolStripMenuItem.Text = "Раскрыть все";
            this.раскрытьВсеToolStripMenuItem.Click += new System.EventHandler(this.раскрытьВсеToolStripMenuItem_Click);
            // 
            // TreeObj
            // 
            this.TreeObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeObj.ImageIndex = 0;
            this.TreeObj.ImageList = this.imageList1;
            this.TreeObj.Indent = 40;
            this.TreeObj.ItemHeight = 18;
            this.TreeObj.Location = new System.Drawing.Point(0, 57);
            this.TreeObj.Name = "TreeObj";
            this.TreeObj.SelectedImageIndex = 0;
            this.TreeObj.Size = new System.Drawing.Size(782, 463);
            this.TreeObj.TabIndex = 11;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "building.gif");
            this.imageList1.Images.SetKeyName(1, "chart_organisation.gif");
            this.imageList1.Images.SetKeyName(2, "chart_organisation_delete.gif");
            this.imageList1.Images.SetKeyName(3, "brick.gif");
            this.imageList1.Images.SetKeyName(4, "brick_delete.gif");
            this.imageList1.Images.SetKeyName(5, "database.gif");
            this.imageList1.Images.SetKeyName(6, "database_delete.gif");
            this.imageList1.Images.SetKeyName(7, "database_prj.png");
            this.imageList1.Images.SetKeyName(8, "database_files.png");
            this.imageList1.Images.SetKeyName(9, "database_prj_files.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LineSeparatorBottom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 35);
            this.panel1.TabIndex = 12;
            // 
            // LineSeparatorBottom
            // 
            this.LineSeparatorBottom.BackgroundImage = global::SSPD.Properties.Resources.LineSeparator;
            this.LineSeparatorBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.LineSeparatorBottom.Location = new System.Drawing.Point(0, 0);
            this.LineSeparatorBottom.Name = "LineSeparatorBottom";
            this.LineSeparatorBottom.Size = new System.Drawing.Size(782, 2);
            this.LineSeparatorBottom.TabIndex = 27;
            this.LineSeparatorBottom.TabStop = false;
            // 
            // label3
            // 
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.ImageIndex = 9;
            this.label3.ImageList = this.imageList1;
            this.label3.Location = new System.Drawing.Point(453, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Есть связанные проекты и вспомогательный материал";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImageIndex = 8;
            this.label2.ImageList = this.imageList1;
            this.label2.Location = new System.Drawing.Point(208, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Есть вспомогательный материал";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImageIndex = 7;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Есть связь с проектом";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CntMNLabel,
            this.CntRNULabel,
            this.CntLPDSLabel,
            this.CntPlaceLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(782, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CntMNLabel
            // 
            this.CntMNLabel.Name = "CntMNLabel";
            this.CntMNLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CntMNLabel.Size = new System.Drawing.Size(20, 17);
            // 
            // CntRNULabel
            // 
            this.CntRNULabel.Name = "CntRNULabel";
            this.CntRNULabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CntRNULabel.Size = new System.Drawing.Size(20, 17);
            // 
            // CntLPDSLabel
            // 
            this.CntLPDSLabel.Name = "CntLPDSLabel";
            this.CntLPDSLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CntLPDSLabel.Size = new System.Drawing.Size(20, 17);
            // 
            // CntPlaceLabel
            // 
            this.CntPlaceLabel.Name = "CntPlaceLabel";
            this.CntPlaceLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CntPlaceLabel.Size = new System.Drawing.Size(20, 17);
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 577);
            this.Controls.Add(this.TreeObj);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "List";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник объектов КТН";
            this.Load += new System.EventHandler(this.List_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.List_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox StrFind;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem МенюОбъекты;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.TreeView TreeObj;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox LineSeparatorBottom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel CntMNLabel;
        private System.Windows.Forms.ToolStripStatusLabel CntRNULabel;
        private System.Windows.Forms.ToolStripStatusLabel CntLPDSLabel;
        private System.Windows.Forms.ToolStripStatusLabel CntPlaceLabel;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВеткиМНToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВеткиРНУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВеткиЛПДСToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem раскрытьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}