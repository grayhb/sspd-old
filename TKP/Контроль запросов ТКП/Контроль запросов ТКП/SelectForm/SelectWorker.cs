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
    public partial class SelectWorker : Form
    {

        public string SelIDWorker="";
        public string SelNBFIO="";
        public string SelFIO = "";

        public string SqlQuery = "";

        public SelectWorker()
        {
            InitializeComponent();
        }

        private void SelectOtdel_Load(object sender, EventArgs e)
        {
            LoadData();
            Filter.Select();
        }

        private void SelectOtdel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                doSelect();
        }

        private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && DGV.Rows.Count > 0) UI.SetBgRowInDGV(DGV);
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

            if (e.KeyCode == Keys.Enter && DGV.Rows.GetRowCount(DataGridViewElementStates.Visible) == 1)
                doSelect();
        }

        private void doSelect()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                SelIDWorker = DGV.SelectedRows[0].Tag.ToString();
                SelNBFIO = DGV.SelectedRows[0].Cells["FIO"].Tag.ToString();
                SelFIO = DGV.SelectedRows[0].Cells["FIO"].Value.ToString();
            }

            this.Close();
        }


        private void LoadData()
        {
            string SqlStr = "SELECT ID_Worker, F_Worker, I_Worker, N_Worker, P_Worker FROM Workers WHERE Fl_Rel = 0 AND ID_Post = " + TKP_Conf.GIPIDPost;

            if (SqlQuery != "") SqlStr = SqlQuery;

            DataRowCollection dra = SSPD.DB.GetFields(SqlStr);

            DGV.Rows.Clear();

            if (dra.Count > 0)
            {
                foreach (DataRow dr in dra)
                {
                    DGV.Rows.Add();
                    DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];
                    DGVR.Cells["FIO"].Value = string.Format("{0} {1} {2}", dr["F_Worker"], dr["N_Worker"], dr["P_Worker"]);
                    DGVR.Cells["FIO"].Tag = string.Format("{0} {1}", dr["F_Worker"], dr["I_Worker"]);
                    DGVR.Tag = dr["ID_Worker"].ToString();
                }
            }
            UI.SetBgRowInDGV(DGV);
        }


        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doSelect();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
        
    }
}
