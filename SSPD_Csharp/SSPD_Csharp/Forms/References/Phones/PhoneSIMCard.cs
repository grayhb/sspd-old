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
        public Dictionary<string, string> SIM = null;

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

        private void SaveSIM()
        {
            if (NSim.Text.Trim().Length == 0)
            {
                SSPDUI.MsgEx("Не указан уникальный номер SIM-карты!", "Остановка сохранения");
                NSim.Focus();
                return;
            }

            if (ANamber.Text.Trim().Length == 0)
            {
                SSPDUI.MsgEx("Не указан абонентный номер!", "Остановка сохранения");
                ANamber.Focus();
                return;
            }

            Dictionary<string, string> DataSet = new Dictionary<string, string>();;
            DataSet.Add("NSim", NSim.Text.Trim());
            DataSet.Add("ANamber", ANamber.Text.Trim());
            DataSet.Add("PIN1", PIN1.Text.Trim());
            DataSet.Add("PIN2", PIN2.Text.Trim());
            DataSet.Add("PUK1", PUK1.Text.Trim());
            DataSet.Add("PUK2", PUK2.Text.Trim());

            if (EditMode == true)
            {
                DB.SetFields(DataSet, "PhoneSIM", "ID_Sim = " + ID_SIM);
            }
            else
            {
                var rs = DB.GetFields("SELECT Isnull(MAX(ID_Sim),0) + 1 AS NewID From PhoneSIM");
                ID_SIM = rs[0]["NewID"].ToString();
                DataSet.Add("ID_Sim", ID_SIM);
                DB.InsertRow(DataSet, "PhoneSIM");
            }
            SIM = DataSet;
            FlSave = true;
            this.Close();
        }

        private void PhoneSIMCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.F2) SaveSIM();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSIM();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
