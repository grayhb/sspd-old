using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class PhoneIPList : Form
    {

        public string SelIPPhone = "";
        public string SelIDIPPhone = "";

        public PhoneIPList()
        {
            InitializeComponent();

            StrFind.GotFocus += new EventHandler(StrFind_GotFocus);
            StrFind.LostFocus += new EventHandler(StrFind_LostFocus);
            StrFind.KeyDown += new KeyEventHandler(StrFind_KeyDown);

            if (Screen.PrimaryScreen.WorkingArea.Width > 1150) this.Width = 1150;

            LoadDataList();
        }


        private void LoadDataList()
        {
            string SqlStr = "SELECT dbo.PhoneIP.ID_IPPhone, dbo.PhoneIP.IPPhoneNamber, dbo.Workers.F_Worker + ' ' + dbo.Workers.I_Worker AS FIO, dbo.Otdels.Name_Otdel,"
                        + " dbo.Posts.N_Post"
                        + " FROM dbo.Workers INNER JOIN"
                        + " dbo.WorkersExt ON dbo.Workers.ID_Worker = dbo.WorkersExt.ID_Worker INNER JOIN"
                        + " dbo.Otdels ON dbo.Workers.ID_Otdel = dbo.Otdels.ID_Otdel INNER JOIN"
                        + " dbo.Posts ON dbo.Workers.ID_Post = dbo.Posts.ID_Post RIGHT OUTER JOIN"
                        + " dbo.PhoneIP ON dbo.WorkersExt.ID_IPPhone = dbo.PhoneIP.ID_IPPhone";

            var rs = DB.GetFields(SqlStr + " ORDER BY PhoneIP.ID_IPPhone DESC");
            if (rs.Count == 0) return;

            DataGridViewRow DGVR;
            DGV.Rows.Clear();

            foreach (DataRow dr in rs)
            {
                DGV.Rows.Add();
                DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                DGVR.Tag = dr["ID_IPPhone"].ToString();
                DGVR.Cells[0].Value = dr["IPPhoneNamber"].ToString();
                DGVR.Cells[1].Value = dr["FIO"].ToString();
                DGVR.Cells[2].Value = dr["Name_Otdel"].ToString();
                DGVR.Cells[3].Value = dr["N_Post"].ToString();
            }

            //красим строки
            SSPDUI.SetBgRowInDGV(DGV);
        }


        private void AddNewItem()
        {
            SSPD.Input.InputPar InputPar = new SSPD.Input.InputPar("Добавление нового номера", null, "Абонентный номер IP Phone:");
            InputPar.Par.MaxLength = 5;
            InputPar.ShowDialog();

            if (InputPar.GetPar.Trim().Length > 0)
            {
                DGV.Rows.Add();
                DGV.ClearSelection();
                DGV.Rows[DGV.Rows.Count - 1].Selected = true;
                DGV.Rows[DGV.Rows.Count - 1].Cells[0].Selected = true;
                DGV.CurrentRow.Cells[0].Value = InputPar.GetPar.Trim();

                var rs = DB.GetFields("SELECT COUNT(*) AS MaxRec From PhoneIP WHERE IPPhoneNamber = '" + InputPar.GetPar.Trim() + "'");
                if (Convert.ToInt32(rs[0]["MaxRec"]) == 0)
                {
                    Dictionary<string, string> DataSet = new Dictionary<string, string>();
                    DataSet.Add("IPPhoneNamber", InputPar.GetPar.Trim());
                    DB.InsertRow(DataSet, "PhoneIP");
                    rs = DB.GetFields("SELECT ID_IPPhone From PhoneIP WHERE IPPhoneNamber = '" + InputPar.GetPar.Trim() + "'");
                    if (rs.Count > 0)
                        DGV.CurrentRow.Tag = rs[0]["ID_IPPhone"].ToString();
                }
            }
        }


        private void DelItem()
        {
            if (MessageBox.Show("Удалить номер - " + DGV.CurrentRow.Cells[0].Value.ToString() + "?", "Удаление IP номера",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var rs = DB.GetFields("SELECT COUNT(*) AS MaxRec From WorkersExt WHERE ID_IPPhone = " + DGV.CurrentRow.Tag.ToString());
            if (Convert.ToInt32(rs[0]["MaxRec"]) > 0)
            {
                Dictionary<string, string> DataSet = new Dictionary<string, string>();
                DataSet.Add("ID_IPPhone", "");
                DB.SetFields(DataSet, "WorkersExt", "ID_IPPhone = " + DGV.CurrentRow.Tag.ToString());
            }
            DB.DeleteRow("PhoneIP", "ID_IPPhone = " + DGV.CurrentRow.Tag.ToString());
            DGV.Rows.RemoveAt(DGV.CurrentRow.Index);
            SSPDUI.SetBgRowInDGV(DGV);
        }

        private void SelectItem()
        {
            SelIDIPPhone = DGV.CurrentRow.Tag.ToString();
            SelIPPhone = DGV.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {
            //красим строки
            SSPDUI.SetBgRowInDGV(DGV);
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DGV.Rows.Count == 0) return;
                SelectItem();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void StrFind_LostFocus(object sender, EventArgs e)
        {
            if (StrFind.Text == "")
            {
                StrFind.Text = Params.StrFindLabel;
                StrFind.ForeColor = Color.DarkGray;
            }
        }

        private void StrFind_GotFocus(object sender, EventArgs e)
        {
            if (StrFind.Text == Params.StrFindLabel)
            {
                StrFind.Text = "";
                StrFind.ForeColor = Color.Black;
            }
        }

        private void StrFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
        }


        private void PhoneIPList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7) SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
            if (e.KeyCode == Keys.Insert) AddNewItem();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
        }


        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            AddNewItem();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewItem();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            SelectItem();
        }


        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            DelItem();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelItem();
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

    }
}
