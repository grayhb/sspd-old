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
    public partial class ListDocsInp : Form
    {

        public bool flSel = false;
        public string IDDoc = "";

        private DataRowCollection dra = null;

        Timer tm = new Timer();
        

        public ListDocsInp()
        {
            InitializeComponent();
            this.Width = 1280;

            tm.Interval = 750;
            tm.Tick +=new EventHandler(tm_Tick);
            tm.Enabled = false;
        }

        private void ListDocsInp_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            LoadData();
            GetListDoc();

            DGV.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void LoadData()
        {

            string SqlStr = "SELECT DISTINCT dbo.DocsInput.ID_DocInp, dbo.DocsInput.RN_DocInp, dbo.DocsInput.Date_DocInp, dbo.DocsInput.Note_DocInp, dbo.Orgs.Name, ";
            SqlStr += " dbo.DocsInput.Aut_Org, dbo.DocsInput.PathToImage";
            SqlStr += " FROM dbo.DocsInput INNER JOIN";
            SqlStr += " dbo.DocsInputExec ON dbo.DocsInput.ID_DocInp = dbo.DocsInputExec.ID_DocInp INNER JOIN";
            SqlStr += " dbo.Orgs ON dbo.DocsInput.ID_Org = dbo.Orgs.ID_Org INNER JOIN";
            SqlStr += " dbo.Workers ON dbo.Workers.ID_Worker = dbo.DocsInputExec.ID_WorkerInput";
            SqlStr += " WHERE Workers.ID_Otdel = " + TKP_Conf.AdminIDOtdel;
            SqlStr += " ORDER BY DocsInput.ID_DocInp DESC";

            dra = DB.GetFields(SqlStr);
            
        }

        private void GetListDoc()
        {
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            if (dra != null)
            {
                DGV.Rows.Clear();
                foreach (DataRow dr in dra)
                {
                    if (CheckFilter(dr))
                    {
                        DGV.Rows.Add();
                        DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                        DGVR.Cells["RNDoc"].Value = string.Format("{0:000000}", dr["RN_DocInp"]); 
                        DGVR.Cells["RNDoc"].Tag = dr["ID_DocInp"].ToString();

                        DGVR.Cells["DateDoc"].Value = UI.GetDate(dr["Date_DocInp"].ToString());
                        DGVR.Cells["Note"].Value = dr["Note_DocInp"].ToString();
                        DGVR.Cells["Org"].Value = dr["Name"].ToString();
                        DGVR.Cells["Adr"].Value = dr["Aut_Org"].ToString();

                        DGVR.Tag = dr["PathToImage"].ToString();
                    }
                }
                UI.SetBgRowInDGV(DGV);
            }
            CountRowLabel.Text = UI.GetCountRow(DGV);
            Cursor.Current = Cursors.Default;
        }

        private bool CheckFilter(DataRow dr)
        {
            bool ret = true;

            if (ФОтсутствует.Checked == true) return true;

            if (ФМесяц.Checked)
            {
                if (Convert.ToDateTime(dr["Date_DocInp"]).Date >= DateTime.Now.AddDays(-30).Date)
                    ret = true;
                else
                    ret = false;
            }

            return ret;
        }

        private void doSelect()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                IDDoc = DGV.SelectedRows[0].Cells["RNDoc"].Tag.ToString();
                flSel = true;
            }
            this.Close();
        }

        private void doCheck(ToolStripMenuItem items, ToolStripMenuItem item)
        {
            foreach (object obj in items.DropDownItems)
            {
                if (obj.GetType() == ФОтсутствует.GetType())
                {
                    ((ToolStripMenuItem)obj).Checked = false;
                }
            }
            item.Checked = true;
            ФОтсутствует.Checked = false;
        }

        private void ФОтсутствует_Click(object sender, EventArgs e)
        {
            foreach (object obj in Фильтр.DropDownItems)
                if (obj.GetType() == ФОтсутствует.GetType())
                    ((ToolStripMenuItem)obj).Checked = false;
            ФОтсутствует.Checked = true;
            GetListDoc();
        }

        private void ФМесяц_Click(object sender, EventArgs e)
        {
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            ФМесяц.Checked = true;
            GetListDoc();
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            tm.Enabled = true;
        }

        private void Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && DGV.Rows.Count > 0)
            {
                DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Selected = true;
                DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Cells[0].Selected = true;
                DGV.Focus();
            }
            tm.Enabled = false;
        }

        private void ListDocsInp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void ЭлектроннаяВерсияДокумента_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
                FTP.DonwloadFile(DGV.SelectedRows[0].Tag.ToString());
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            tm.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            UI.FilterInDGV(DGV, Filter.Text, true);
            CountRowLabel.Text = UI.GetCountRow(DGV);
            Cursor.Current = Cursors.Default;
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            doSelect();
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
                doSelect();
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doSelect();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {
            UI.SetBgRowInDGV(DGV);
        }
        

    }
}
