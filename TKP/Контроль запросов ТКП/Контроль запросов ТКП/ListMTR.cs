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
    public partial class ListMTR : Form
    {
        public byte mean;
        
        DataRowCollection dra = null;

        public bool FlSel = false;
        public DataRow SelItem = null;

        public ListMTR()
        {
            InitializeComponent();
        }

        private void ListMTR_Load(object sender, EventArgs e)
        {
            if (mean != 1)
            {
                Выбрать.Visible = false;
                Sepor1.Visible = false;
            }

            LoadData();
            GetItems();
        }

        private void LoadData()
        {
            dra = LocalDB.LoadData("SELECT * FROM ГруппыМТР");
        }

        private void GetItems()
        {
            TV.Nodes.Clear();

            CBRazdel.Items.Clear();
            CBRazdel.Items.Add("");

            TreeNode TN;
            if (dra != null)
            {
                foreach (DataRow dr in dra)
                {
                    if (dr["ID_Parent"].ToString() == "")
                    {
                        TN = new TreeNode();
                        TN.Tag = dr;
                        TN.Text = "[" + dr["Code"].ToString() + "] " + dr["NameMTR"].ToString();

                        UI.CBItem CBI = new UI.CBItem(dr["NameMTR"].ToString(), dr["ID_Rec"].ToString());
                        CBRazdel.Items.Add(CBI);

                        AddSubItem(TN, dr["ID_Rec"].ToString());

                        TV.Nodes.Add(TN);
                    }
                }
            }
        }

        private void AddSubItem(TreeNode TN, string IDParent) 
        {
            TreeNode subTN;
            foreach (DataRow dr in dra)
            {
                if (dr["ID_Parent"].ToString() == IDParent)
                {
                    subTN = new TreeNode();
                    subTN.Tag = dr;
                    subTN.Text = "[" + dr["Code"].ToString() + "] " + dr["NameMTR"].ToString();
                    TN.Nodes.Add(subTN);
                }
            }
        }



        private void Filter_TextChanged(object sender, EventArgs e)
        {
                foreach (TreeNode TN in TV.Nodes)
                {
                    TN.BackColor = Color.White;
                    TN.Collapse();
                    if (Filter.Text.Length > 1)
                        if (TN.Text.ToLower().IndexOf(Filter.Text.ToLower()) > -1)
                            TN.BackColor = Color.LightYellow;
                    SearchInNodes(TN);
                }
        }

        private void SearchInNodes(TreeNode TN)
        {
            foreach(TreeNode subTN in TN.Nodes) {
                subTN.BackColor = Color.White;
                if (Filter.Text.Length > 1)
                    if (subTN.Text.ToLower().IndexOf(Filter.Text.ToLower()) > -1)
                    {
                        subTN.BackColor = Color.LightYellow;
                        TN.Expand();
                    }
            }
        }

        private void СвернутьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TV.CollapseAll();
        }

        private void РазвернутьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TV.ExpandAll();
        }

        private void ЗакрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Выбрать_Click(object sender, EventArgs e)
        {
            doSelect();
        }

        private void OpenCard()
        {
            CBRazdel.Enabled = true;
            NameMTR.Enabled = true;
            NameMTR.Focus();
            NameMTR.Select();
            Code.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            TV.Enabled = false;
        }

        private void CloseCard()
        {
            CBRazdel.Enabled = false;
            NameMTR.Enabled = false;
            Code.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            Code.Text = "";
            Code.Tag = null;
            NameMTR.Text = "";
            CBRazdel.SelectedIndex = 0;
            TV.Enabled = true;
        }

        private void ДобавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCard();
        }

        private void ИзменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TV.SelectedNode != null)
            {
                OpenCard();
                DataRow dr = (DataRow)TV.SelectedNode.Tag;
                NameMTR.Text = dr["NameMTR"].ToString();
                Code.Text = dr["Code"].ToString();
                Code.Tag = dr["ID_Rec"].ToString();

                CBRazdel.SelectedIndex = 0;
                if (CBRazdel.Items.Count > 1)
                {
                    for (int i = 1; i < CBRazdel.Items.Count; i++)
                    {
                        if (((UI.CBItem)CBRazdel.Items[i]).Value == dr["ID_Parent"].ToString())
                        {
                            CBRazdel.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отменить ввод данных?","Реестр МТР",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)== DialogResult.Yes)
                CloseCard();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NameMTR.Text.Trim().Length == 0)
            {
                MessageBox.Show("Не указано наименование раздела МТР", "Реестр МТР", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NameMTR.Focus();
                NameMTR.Select();
                return;
            }

            Dictionary<string, object> DS = new Dictionary<string, object>();
            DS.Add("NameMTR", NameMTR.Text);
            DS.Add("Code", Code.Text);

            if (CBRazdel.SelectedIndex > 0)
                DS.Add("ID_Parent", ((UI.CBItem)CBRazdel.SelectedItem).Value);

            if (Code.Tag != null)
            {  // изменение
                LocalDB.UpdateData(DS, "ГруппыМТР", "ID_REC = " + Code.Tag.ToString());
            }
            else
            { //новая запись
                LocalDB.InsertData(DS, "ГруппыМТР");
            }
            LoadData();
            GetItems();
            CloseCard();
        }

        private void doSelect()
        {
            if (TV.SelectedNode != null)
            {
                FlSel = true;
                SelItem = (DataRow)TV.SelectedNode.Tag;
                this.Close();
            }
        }

        private void TV_DoubleClick(object sender, EventArgs e)
        {
            if (mean==1)
                doSelect();
        }

        private void ListMTR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }

    }
}
