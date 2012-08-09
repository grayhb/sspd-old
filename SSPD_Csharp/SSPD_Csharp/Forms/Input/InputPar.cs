using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD.Input
{
    public partial class InputPar : Form
    {
        //возврат значения
        public string GetPar = "";

        public InputPar(string FormText, string SetPar, string SerParLabel)
        {
            InitializeComponent();

            if (FormText != null)
                this.Text = FormText;
            else
                this.ControlBox = false;

            if (SetPar != null) Par.Text = SetPar;
            if (SerParLabel != null) ParLabel.Text = SerParLabel;

        }

        #region [События элементов формы]

        private void InputPar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetPar = Par.Text;
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetPar = Par.Text;
            this.Close();
        }

        #endregion
    }
}
