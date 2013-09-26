using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Контроль_запросов_ТКП.SelectForm
{
    public partial class ListOrg : Form
    {

        public string SelIDOrg = "";
        public string SelNameOrg = "";

        public ListOrg()
        {
            InitializeComponent();
        }

        private void ListOrg_Load(object sender, EventArgs e)
        {
            LoadData();
            Filter.Select();
        }


        private void doSelect()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                //SelEq = DGV.SelectedRows[0].Cells[0].Value.ToString();
                SelIDOrg = DGV.SelectedRows[0].Tag.ToString();
                SelNameOrg = DGV.SelectedRows[0].Cells[0].Value.ToString();
            }

            this.Close();
        }


        private void LoadData()
        {
            string SqlStr = "SELECT DISTINCT ID_Org, Name_Br, Name_Full FROM КонтрольТКП_Организации";

            DataRowCollection dra = LocalDB.LoadData(SqlStr);

            DGV.Rows.Clear();

            if (dra.Count > 0)
            {
                foreach (DataRow dr in dra)
                {
                    DGV.Rows.Add();
                    DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];
                    DGVR.Cells["NameBr"].Value = dr["Name_Br"].ToString();
                    DGVR.Cells["NameFull"].Value = dr["Name_Full"].ToString();
                    DGVR.Tag = dr["ID_Org"].ToString();
                }
                UI.SetBgRowInDGV(DGV);
            }
        }


        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (DGV.Rows.Count == 0) return;
            if (e.KeyCode == Keys.Home)
            {
                DGV.Rows[0].Selected = true;
                DGV.Rows[0].Cells[0].Selected = true;
            }
            if (e.KeyCode == Keys.End)
            {
                DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)].Selected = true;
                DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)].Cells[0].Selected = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                doSelect();
            }
        }

        private void Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && DGV.Rows.Count > 0)
            {
                DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Selected = true;
                DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Cells[0].Selected = true;
                DGV.Focus();
            }

            if (e.KeyCode == Keys.Enter && DGV.Rows.GetRowCount(DataGridViewElementStates.Visible) == 1)
                doSelect();
        }


        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doSelect();
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            UI.FilterInDGV(DGV, Filter.Text, true);
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                doSelect();
        }



        private void ListOrg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && DGV.Rows.Count > 0) UI.SetBgRowInDGV(DGV);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
