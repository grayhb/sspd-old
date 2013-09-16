namespace Контроль_запросов_ТКП
{
    partial class CardWorker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardWorker));
            this.Foto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FIO = new System.Windows.Forms.TextBox();
            this.OtdelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Post = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TelInner = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TelTown = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LineSeparatorBottom = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Foto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // Foto
            // 
            this.Foto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Foto.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Foto.ErrorImage")));
            this.Foto.Location = new System.Drawing.Point(507, 12);
            this.Foto.Name = "Foto";
            this.Foto.Size = new System.Drawing.Size(130, 175);
            this.Foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Foto.TabIndex = 29;
            this.Foto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "ФИО";
            // 
            // FIO
            // 
            this.FIO.Location = new System.Drawing.Point(120, 12);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(372, 20);
            this.FIO.TabIndex = 31;
            this.FIO.TextChanged += new System.EventHandler(this.FIO_TextChanged);
            // 
            // OtdelName
            // 
            this.OtdelName.Location = new System.Drawing.Point(120, 56);
            this.OtdelName.Name = "OtdelName";
            this.OtdelName.Size = new System.Drawing.Size(372, 20);
            this.OtdelName.TabIndex = 33;
            this.OtdelName.TextChanged += new System.EventHandler(this.OtdelName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Отдел";
            // 
            // Post
            // 
            this.Post.Location = new System.Drawing.Point(120, 100);
            this.Post.Name = "Post";
            this.Post.Size = new System.Drawing.Size(372, 20);
            this.Post.TabIndex = 35;
            this.Post.TextChanged += new System.EventHandler(this.Post_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Должность";
            // 
            // TelInner
            // 
            this.TelInner.Location = new System.Drawing.Point(120, 144);
            this.TelInner.Name = "TelInner";
            this.TelInner.Size = new System.Drawing.Size(80, 20);
            this.TelInner.TabIndex = 37;
            this.TelInner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TelInner.TextChanged += new System.EventHandler(this.TelInner_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Тел. внутренний";
            // 
            // TelTown
            // 
            this.TelTown.Location = new System.Drawing.Point(382, 144);
            this.TelTown.Name = "TelTown";
            this.TelTown.Size = new System.Drawing.Size(110, 20);
            this.TelTown.TabIndex = 39;
            this.TelTown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TelTown.TextChanged += new System.EventHandler(this.TelTown_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Тел. городской";
            // 
            // LineSeparatorBottom
            // 
            this.LineSeparatorBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LineSeparatorBottom.BackgroundImage = global::Контроль_запросов_ТКП.Properties.Resources.LineSeparator;
            this.LineSeparatorBottom.Location = new System.Drawing.Point(12, 200);
            this.LineSeparatorBottom.Name = "LineSeparatorBottom";
            this.LineSeparatorBottom.Size = new System.Drawing.Size(625, 2);
            this.LineSeparatorBottom.TabIndex = 41;
            this.LineSeparatorBottom.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Location = new System.Drawing.Point(562, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "ОК";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CardWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 248);
            this.Controls.Add(this.LineSeparatorBottom);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.TelTown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TelInner);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Post);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OtdelName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FIO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Foto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CardWorker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карточка сотрудника";
            this.Load += new System.EventHandler(this.CardWorker_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CardWorker_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Foto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineSeparatorBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Foto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FIO;
        private System.Windows.Forms.TextBox OtdelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Post;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TelInner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TelTown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox LineSeparatorBottom;
        private System.Windows.Forms.Button btnSave;
    }
}