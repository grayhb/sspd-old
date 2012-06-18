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
        public MainForm()
        {
            InitializeComponent();

            this.Shown +=new EventHandler(Main_Shown);

            Config cfg = new Config();
            cfg.ReadCFG();

        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.Opacity = 100;
        }
    }
}
