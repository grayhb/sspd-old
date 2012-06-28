using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class InputPassword : Form
    {
        public bool retVal = false;
        private string Pass = "dgk 12545";

        public InputPassword()
        {
            InitializeComponent();

            this.KeyDown +=new KeyEventHandler(InputPassword_KeyDown);

            

        }

        private void InputPassword_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter) {
                if (InputPass.Text == Pass) { retVal = true; }
                this.Close(); 
            }

            if (e.KeyCode == Keys.Escape) this.Close();
        }

    }
}
