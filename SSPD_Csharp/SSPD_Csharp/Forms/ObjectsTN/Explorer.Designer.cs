namespace SSPD.ObjectsTN
{
    partial class Explorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.раскрытьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeExp = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.TopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операцииToolStripMenuItem,
            this.видToolStripMenuItem});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(692, 24);
            this.TopMenu.TabIndex = 9;
            this.TopMenu.Text = "menuStrip1";
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.выходToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.выходToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeyDisplayString = "ESC";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.выходToolStripMenuItem.Text = "Закрыть";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.раскрытьВсеToolStripMenuItem,
            this.свернутьВсеToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // раскрытьВсеToolStripMenuItem
            // 
            this.раскрытьВсеToolStripMenuItem.Name = "раскрытьВсеToolStripMenuItem";
            this.раскрытьВсеToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.раскрытьВсеToolStripMenuItem.Text = "Раскрыть все";
            this.раскрытьВсеToolStripMenuItem.Click += new System.EventHandler(this.раскрытьВсеToolStripMenuItem_Click);
            // 
            // свернутьВсеToolStripMenuItem
            // 
            this.свернутьВсеToolStripMenuItem.Name = "свернутьВсеToolStripMenuItem";
            this.свернутьВсеToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.свернутьВсеToolStripMenuItem.Text = "Свернуть все";
            this.свернутьВсеToolStripMenuItem.Click += new System.EventHandler(this.свернутьВсеToolStripMenuItem_Click);
            // 
            // TreeExp
            // 
            this.TreeExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeExp.HideSelection = false;
            this.TreeExp.HotTracking = true;
            this.TreeExp.ImageIndex = 9;
            this.TreeExp.ImageList = this.imageList;
            this.TreeExp.Indent = 24;
            this.TreeExp.ItemHeight = 18;
            this.TreeExp.Location = new System.Drawing.Point(0, 24);
            this.TreeExp.Name = "TreeExp";
            this.TreeExp.SelectedImageIndex = 9;
            this.TreeExp.Size = new System.Drawing.Size(692, 649);
            this.TreeExp.TabIndex = 12;
            this.TreeExp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TreeExp_MouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "building.gif");
            this.imageList.Images.SetKeyName(1, "chart_organisation.gif");
            this.imageList.Images.SetKeyName(2, "brick.gif");
            this.imageList.Images.SetKeyName(3, "database.gif");
            this.imageList.Images.SetKeyName(4, "books.png");
            this.imageList.Images.SetKeyName(5, "education.png");
            this.imageList.Images.SetKeyName(6, "file_manager.png");
            this.imageList.Images.SetKeyName(7, "folder_database.png");
            this.imageList.Images.SetKeyName(8, "file_extension_zip.png");
            this.imageList.Images.SetKeyName(9, "info_rhombus.png");
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 673);
            this.Controls.Add(this.TreeExp);
            this.Controls.Add(this.TopMenu);
            this.KeyPreview = true;
            this.Name = "Explorer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проводник объекта";
            this.Load += new System.EventHandler(this.Explorer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Explorer_KeyDown);
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem раскрытьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВсеToolStripMenuItem;
        private System.Windows.Forms.TreeView TreeExp;
        private System.Windows.Forms.ImageList imageList;
    }
}