using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class PhoneApCard : Form
    {
        public bool FlSave = false;
        public Dictionary<string, string> GetData = null;

        private bool EditMode;
        private string ID_Item;

        public PhoneApCard(bool FlEdit, string IDitem)
        {
            InitializeComponent();


            ID_Item = IDitem;
            EditMode = FlEdit;
            if (EditMode == false)
            {
                this.Text = "Добавить новый аппарат";
            }
            else
            {
                this.Text = "Редактирование данных аппарата";
                LoadData();
            }
        }

        private void LoadData()
        {
            var rs = DB.GetFields("SELECT ID_PA, Inv, IMEI, Label From PhoneAp Where ID_PA = " + ID_Item);
            if (rs.Count == 0) return;
            Inv.Text = rs[0]["Inv"].ToString();
            IMEI.Text = rs[0]["IMEI"].ToString();
            Label.Text = rs[0]["Label"].ToString();
        }

        private void SaveData()
        {
            if (IMEI.Text.Trim().Length == 0)
            {
                SSPDUI.MsgEx("Не указан IMEI аппарата!", "Остановка сохранения");
                IMEI.Focus();
                return;
            }

            if (Inv.Text.Trim().Length == 0)
            {
                SSPDUI.MsgEx("Не указан инвентарный номер аппарата!", "Остановка сохранения");
                Inv.Focus();
                return;
            }

            if (Label.Text.Trim().Length == 0)
            {
                SSPDUI.MsgEx("Не указана марка аппарата!", "Остановка сохранения");
                Label.Focus();
                return;
            }
            
            Dictionary<string, string> DataSet = new Dictionary<string, string>(); ;
            DataSet.Add("IMEI", IMEI.Text.Trim());
            DataSet.Add("Inv", Inv.Text.Trim());
            DataSet.Add("Label", Label.Text.Trim());

            if (EditMode == true)
            {
                DB.SetFields(DataSet, "PhoneAp", "ID_PA = " + ID_Item);
            }
            else
            {
                var rs = DB.GetFields("SELECT Isnull(MAX(ID_PA),0) + 1 AS NewID From PhoneAp");
                ID_Item = rs[0]["NewID"].ToString();
                DataSet.Add("ID_PA", ID_Item);
                DB.InsertRow(DataSet, "PhoneAp");
            }
            GetData = DataSet;
            FlSave = true;
            this.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PhoneApCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.F2) SaveData();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
