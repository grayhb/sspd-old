using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class PhoneInnerCard : Form
    {

        public bool FlSave = false;
        public Dictionary<string, string> GetData = null;

        private bool EditMode;
        private string ID_Item;

        public PhoneInnerCard(bool FlEdit, string IDitem)
        {
            InitializeComponent();

            ID_Item = IDitem;
            EditMode = FlEdit;
            LoadComboData();

            if (EditMode == false)
            {
                this.Text = "Добавить нового абонента";
            }
            else
            {
                this.Text = "Редактирование данных абонента";
                LoadData();
            }
        }

        private void LoadComboData()
        {
            SSPDUI.ComboType CT = new SSPDUI.ComboType();

            //городские номера
            var rs = DB.GetFields("SELECT ID_PTown, NamberPTown From PhoneTown ORDER BY NamberPTown");
            PhoneTown.Items.Add("Отсутствует");
            PhoneTown.SelectedIndex = 0;
            if (rs.Count > 0)
            {
                foreach (DataRow dr in rs)
                {
                    CT.ID_Item = Convert.ToInt32(dr["ID_PTown"]);
                    CT.Name_Item = dr["NamberPTown"].ToString();
                    PhoneTown.Items.Add(CT);
                }
            }

            //телефоны МАТС
            rs = DB.GetFields("SELECT ID_PMATS, NamberPMATS From PhoneMATS ORDER BY NamberPMATS");
            PhoneMATS.Items.Add("Отсутствует");
            PhoneMATS.SelectedIndex = 0;
            if (rs.Count > 0)
            {
                foreach (DataRow dr in rs)
                {
                    CT.ID_Item = Convert.ToInt32(dr["ID_PMATS"]);
                    CT.Name_Item = dr["NamberPMATS"].ToString();
                    PhoneMATS.Items.Add(CT);
                }
            }

            //телефоны групп
            rs = DB.GetFields("SELECT ID_PGroup, NamberGroup, NameGroup From PhoneGroup ORDER BY NamberGroup");
            PhoneGroup.Items.Add("Отсутствует");
            PhoneGroup.SelectedIndex = 0;
            if (rs.Count > 0)
            {
                foreach (DataRow dr in rs)
                {
                    CT.ID_Item = Convert.ToInt32(dr["ID_PGroup"]);
                    CT.Name_Item = dr["NamberGroup"].ToString();
                    PhoneGroup.Items.Add(CT);
                }
            }
        }

        private void LoadData()
        {
            var rs = DB.GetFields("SELECT ID_PInner, NamberPInner, ID_PTown, ID_PMATS, ID_PGroup, Room From PhoneInner Where ID_PInner = " + ID_Item);
            if (rs.Count == 0) return;
            PhoneInner.Text = rs[0]["NamberPInner"].ToString();
            PhoneInner.Enabled = false;
            PhoneTown.Tag = rs[0]["ID_PTown"].ToString();
            PhoneMATS.Tag = rs[0]["ID_PMATS"].ToString();
            PhoneGroup.Tag = rs[0]["ID_PGroup"].ToString();
            Room.Text = rs[0]["Room"].ToString();

            for (int i=1; i<=PhoneTown.Items.Count-1;i++)
                if ((((SSPDUI.ComboType)PhoneTown.Items[i]).ID_Item).ToString() == PhoneTown.Tag.ToString())
                {
                    PhoneTown.SelectedIndex = i;
                    break;
                }

            for (int i = 1; i <= PhoneMATS.Items.Count - 1; i++)
                if ((((SSPDUI.ComboType)PhoneMATS.Items[i]).ID_Item).ToString() == PhoneMATS.Tag.ToString())
                {
                    PhoneMATS.SelectedIndex = i;
                    break;
                }

            for (int i = 1; i <= PhoneGroup.Items.Count - 1; i++)
                if ((((SSPDUI.ComboType)PhoneGroup.Items[i]).ID_Item).ToString() == PhoneGroup.Tag.ToString())
                {
                    PhoneGroup.SelectedIndex = i;
                    break;
                }
        }

        private void SaveData()
        {

            if (PhoneInner.Text.Trim().Length == 0)
            {
                SSPDUI.MsgEx("Не указан внутренний номер!", "Остановка сохранения");
                PhoneInner.Focus();
                return;
            }

            Dictionary<string, string> DataSet = new Dictionary<string, string>();

            if (PhoneTown.SelectedIndex>0)
                DataSet.Add("ID_PTown", ((SSPDUI.ComboType)PhoneTown.SelectedItem).ID_Item.ToString());
            else
                DataSet.Add("ID_PTown", "0");

            if (PhoneMATS.SelectedIndex > 0)
                DataSet.Add("ID_PMATS", ((SSPDUI.ComboType)PhoneMATS.SelectedItem).ID_Item.ToString());
            else
                DataSet.Add("ID_PMATS", "0");

            if (PhoneGroup.SelectedIndex > 0)
                DataSet.Add("ID_PGroup", ((SSPDUI.ComboType)PhoneGroup.SelectedItem).ID_Item.ToString());
            else
                DataSet.Add("ID_PGroup", "0");

            DataSet.Add("NamberPInner", PhoneInner.Text);
            DataSet.Add("Room", Room.Text);

            if (EditMode == true)
            {
                DB.SetFields(DataSet, "PhoneInner", "ID_PInner = " + ID_Item);
            }
            else
            {
                PhoneInner.Text = PhoneInner.Text.Trim();
                var rs = DB.GetFields("SELECT COUNT(*) AS MaxRec From PhoneInner WHERE NamberPInner = '" + PhoneInner.Text + "'");
                if (Convert.ToInt32(rs[0]["MaxRec"]) > 0)
                {
                    SSPDUI.MsgEx("Указанный внутренний номер описан в базе данных!", "Остановка сохранения");
                    PhoneInner.Focus();
                    return;
                }
                else
                {
                    rs = DB.GetFields("SELECT Isnull(MAX(ID_PInner),0) + 1 AS NewID From PhoneInner");
                    ID_Item = rs[0]["NewID"].ToString();
                    DataSet.Add("ID_PInner", ID_Item);
                    DB.InsertRow(DataSet, "PhoneInner");
                }
            }

            if (PhoneTown.SelectedIndex > 0) DataSet.Add("NamberPTown", PhoneTown.SelectedItem.ToString());
            else DataSet.Add("NamberPTown", "");

            if (PhoneMATS.SelectedIndex > 0) DataSet.Add("NamberPMATS", PhoneMATS.SelectedItem.ToString());
            else DataSet.Add("NamberPMATS", "");

            if (PhoneGroup.SelectedIndex > 0) DataSet.Add("NamberGroup", PhoneGroup.SelectedItem.ToString());
            else DataSet.Add("NamberGroup", "");

            GetData = DataSet;
            FlSave = true;
            this.Close();
        }

        private void PhoneInnerCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.F2) SaveData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
