using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class MainForm : Form
    {
        Declarations Declarations = new Declarations();

        public MainForm()
        {
            InitializeComponent();

            this.Shown +=new EventHandler(Main_Shown);

            Config cfg = new Config();
            cfg.ReadCFG();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            this.Text = "my";
            

            Declarations.MdiParent = this;
            Declarations.Show();

            this.Opacity = 100;

            Cfg mycfg = new Cfg();
            mycfg.ShowDialog();
            /*
            DB sspdDb = new DB();
            var DRC = sspdDb.GetFields("SELECT * FROM Otdels");

            SSPDUI.MsgEx(DRC.Count.ToString(), "Количество строк в таблице Otdels");
             */

        }
    }
}
