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
    public partial class ListEquip : Form
    {

        public string SelEq = "";

        public ListEquip()
        {
            InitializeComponent();

            
        }

        private void ListEquip_Load(object sender, EventArgs e)
        {
            LoadData();
            Filter.Select();
        }



        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            doSelect();
        }

        private void ListEquip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        
        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doSelect();
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            UI.FilterInDGV(DGV, Filter.Text);
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


        private void LoadData()
        {
            string SqlStr = "SELECT DISTINCT Equipment FROM КонтрольТКП ";

            DataRowCollection dra = LocalDB.LoadData(SqlStr);

            DGV.Rows.Clear();

            if (dra.Count > 0)
            {
                foreach (DataRow dr in dra)
                {
                    if (dr["Equipment"].ToString() != "")
                    {
                        DGV.Rows.Add();
                        DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];
                        DGVR.Cells["Equipment"].Value = dr["Equipment"].ToString();
                    }
                }
            }
        }

        private void doSelect()
        {
            if (DGV.SelectedRows.Count > 0)
                SelEq = DGV.SelectedRows[0].Cells[0].Value.ToString();

            this.Close();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.RowIndex % 2 == 0 )
                    e.CellStyle.BackColor = Color.FromArgb(240, 240, 240);
                else
                    e.CellStyle.BackColor = Color.White;
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


  

    }
}
