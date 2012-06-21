using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class Declarations : Form
    {
        public Declarations()
        {
            InitializeComponent();
            this.Shown += new EventHandler(Declarations_Shown);
        }

        private void Declarations_Shown(object sedner, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
