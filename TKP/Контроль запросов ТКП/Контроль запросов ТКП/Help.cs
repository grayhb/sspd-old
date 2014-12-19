using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Контроль_запросов_ТКП
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }



        private void Help_Load(object sender, EventArgs e)
        {
            LabelBG1.BackColor = UI.bgUseTKP;
            Label1.Text = "- отметка о использовании данных в сметах";

            LabelBG2.BackColor = UI.bgFailPir;
            Label2.Text = "- выполненные/отмененные объекты плана ПИР";

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Help_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
    }
}
