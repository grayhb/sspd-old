using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SSPD.Select
{
    public partial class SelectPar : Form
    {

        //возврат значения
        public bool FlSel = false;

        public int IDSel;
        public Dictionary<int, string> SetPar;

        public SelectPar(string FormText, string SerParLabel)
        {
            InitializeComponent();
            
            if (FormText != null)
                this.Text = FormText;
            else
                this.ControlBox = false;

            if (SerParLabel != null) ParLabel.Text = SerParLabel;
        }

        private void SelectPar_Load(object sender, EventArgs e)
        {
            SSPDUI.ComboType CT = new SSPDUI.ComboType();

            foreach (int IDPar in SetPar.Keys)
            {
                CT.ID_Item = IDPar;
                CT.Name_Item = SetPar[IDPar];
                Par.Items.Add(CT);
                if (IDPar == IDSel)
                    Par.SelectedItem = Par.Items[Par.Items.Count - 1];
            }

            Par.Focus();
        }

        #region [События элементов формы]

        private void SelectPar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FlSel = true;
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
            FlSel = true;
            this.Close();
        }

        #endregion




    }
}
