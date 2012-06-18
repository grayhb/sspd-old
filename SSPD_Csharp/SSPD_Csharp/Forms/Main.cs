using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD_Csharp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            this.Shown +=new EventHandler(Main_Shown);

        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.Opacity = 100;
        }
    }
}
