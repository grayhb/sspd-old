using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSPD;

namespace Контроль_запросов_ТКП.SelectForm
{
    public partial class ListProject : Form
    {
        public string SelID = "";
        public string SelShPrj = "";
        public string SelNamePrj = "";
        public string SelGIP = "";

        public ListProject()
        {
            InitializeComponent();
            this.Width = 1280;
        }

        private void ListProject_Load(object sender, EventArgs e)
        {
            LoadData();
            Filter.Select();
        }

        private void LoadData()
        {
            string SqlStr = "SELECT DISTINCT Projects.Sh_project,  Projects.Name_Project,  Projects.ID_Project,  Workers.F_Worker + ' ' +  Workers.I_Worker AS GIP";
            SqlStr = SqlStr + " FROM ExchandeZadReestr INNER JOIN";
            SqlStr = SqlStr + " Projects ON  ExchandeZadReestr.ID_Project =  Projects.ID_Project INNER JOIN";
            SqlStr = SqlStr + " Workers ON  Projects.ID_GIP =  Workers.ID_Worker";
            SqlStr = SqlStr + " WHERE ExchandeZadReestr.ID_OtdelInp = " + TKP_Conf.AdminIDOtdel + " AND ExchandeZadReestr.Status = 1";

            DataRowCollection dra = DB.GetFields(SqlStr);

            DGV.Rows.Clear();

            if (dra.Count > 0)
            {
                foreach (DataRow dr in dra)
                {
                    DGV.Rows.Add();
                    DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];
                    DGVR.Tag = dr["ID_Project"].ToString();
                    DGVR.Cells["ShPrj"].Value = dr["Sh_project"].ToString();
                    DGVR.Cells["NamePrj"].Value = dr["Name_Project"].ToString();
                    DGVR.Cells["GIP"].Value = dr["GIP"].ToString();
                }
                UI.SetBgRowInDGV(DGV);
            }
            
        }

        private void doSelect()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                SelID = DGV.SelectedRows[0].Tag.ToString();
                SelShPrj = DGV.SelectedRows[0].Cells["ShPrj"].Value.ToString();
                SelNamePrj = DGV.SelectedRows[0].Cells["NamePrj"].Value.ToString();
                SelGIP = DGV.SelectedRows[0].Cells["GIP"].Value.ToString();
            }

            this.Close();
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            UI.FilterInDGV(DGV, Filter.Text, true);
        }

        private void Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && DGV.Rows.Count > 0)
            {
                DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Selected = true;
                DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Cells[0].Selected = true;
                DGV.Focus();
            }
            
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doSelect();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) 
                doSelect();
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

        private void ListProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && DGV.Rows.Count > 0) UI.SetBgRowInDGV(DGV);
        }
    }
}
