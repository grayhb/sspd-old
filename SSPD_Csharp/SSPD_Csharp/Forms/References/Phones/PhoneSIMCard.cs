using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class PhoneSIMCard : Form
    {
        public bool FlSave = false;

        private bool EditMode;
        private string ID_SIM;

        public PhoneSIMCard(bool FlEdit, string IDSIM)
        {
            InitializeComponent();

            ID_SIM = IDSIM;
            EditMode = FlEdit;
            if (EditMode == false)
            {
                this.Text = "Добавить новую SIM карту";
            }
            else
            {
                this.Text = "Редактирование данных SIM карты";
                LoadSIM();
            }
        }

        private void LoadSIM()
        {
            var rs = DB.GetFields("SELECT ID_Sim, NSim, ANamber, PIN1, PIN2, PUK1, PUK2 From PhoneSIM Where ID_Sim = " + ID_SIM);
            if (rs.Count == 0) return;
            NSim.Text = rs[0]["NSim"].ToString();
            ANamber.Text = rs[0]["ANamber"].ToString();
            PIN1.Text = rs[0]["PIN1"].ToString();
            PIN2.Text = rs[0]["PIN2"].ToString();
            PUK1.Text = rs[0]["PUK1"].ToString();
            PUK2.Text = rs[0]["PUK2"].ToString();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PhoneSIMCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
    }
}
