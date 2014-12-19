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
    public partial class ListDocsOut : Form
    {

        public bool flSel = false;
        public string IDDoc = "";
        public string IDOrg = "";

        private DataRowCollection dra = null;

        Timer tm = new Timer();

        public string SqlFastSearch = "";
        bool flLoadList = false;

        public ListDocsOut()
        {
            InitializeComponent();

            this.Width = 1280;

            tm.Interval = 750;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Enabled = false;
        }

        private void ListDocsOut_Load(object sender, EventArgs e)
        {
            Application.DoEvents();

            SqlFastSearch = string.Format(" DocsOutput.Date_DocOut >= '{0}'", DateTime.Now.AddDays(-30).Date);
            LoadData();
            GetListDoc();

            DGV.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void LoadData()
        {
            string SqlStr = "SELECT DocsOutput.ID_DocOut, DocsOutput.PathToImage, DocsOutput.RN_DocOut, DocsOutput.Date_DocOut, DocsOutput.Note_DocOut, ";
            SqlStr += " DOutRec.Org, DOutRec.Rec_Org, DOutRec.ID_Org";
            SqlStr += " FROM DocsOutput INNER JOIN";
            SqlStr += " (SELECT DISTINCT * FROM (SELECT      ID_DocOut AS IDO";
            SqlStr += " FROM DocsOutput INNER JOIN Workers ON Workers.ID_Worker = DocsOutput.ID_Worker";
            SqlStr += " WHERE (Workers.ID_Otdel = "+ TKP_Conf.AdminIDOtdel + ") UNION SELECT      ID_DocOut AS IDO";
            SqlStr += " FROM ImageDocOutAc INNER JOIN Workers ON Workers.ID_Worker = ImageDocOutAc.ID_Worker";
            SqlStr += " WHERE (Workers.ID_Otdel = "+ TKP_Conf.AdminIDOtdel + ") GROUP BY ID_DocOut UNION SELECT      DocsOutput.ID_DocOut AS IDO";
            SqlStr += " FROM DocsOutput INNER JOIN DocsInputExec ON DocsOutput.ID_DocInp = DocsInputExec.ID_DocInp INNER JOIN";
            SqlStr += " Workers ON Workers.ID_Worker = DocsInputExec.ID_WorkerInput";
            SqlStr += " WHERE (Workers.ID_Otdel = "+ TKP_Conf.AdminIDOtdel + ")";
            SqlStr += " GROUP BY ID_DocOut) t) Isp ON DocsOutput.ID_DocOut = Isp.IDO LEFT OUTER JOIN";
            SqlStr += " (SELECT DocsOutputRec.ID_DocOut, Orgs.Name AS Org, DocsOutputRec.Rec_Org, Orgs.ID_Org";
            SqlStr += " FROM DocsOutputRec INNER JOIN Orgs ON DocsOutputRec.ID_Org = Orgs.ID_Org";
            SqlStr += " WHERE (DocsOutputRec.RecOrd = 1)) DOutRec ON DocsOutput.ID_DocOut = DOutRec.ID_DocOut";
            if (SqlFastSearch.Length > 0) SqlStr += string.Format(" WHERE {0}", SqlFastSearch); 
            SqlStr += " ORDER BY DocsOutput.ID_DocOut DESC";

            dra = DB.GetFields(SqlStr);
        }

        private void GetListDoc()
        {
            Application.DoEvents();
            DGV.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;
            if (dra != null)
            {
                foreach (DataRow dr in dra)
                {
                    DGV.Rows.Add();
                    DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                    DGVR.Cells["RNDoc"].Value = dr["RN_DocOut"].ToString();
                    DGVR.Cells["RNDoc"].Tag = dr["ID_DocOut"].ToString();

                    DGVR.Cells["DateDoc"].Value = UI.GetDate(dr["Date_DocOut"].ToString());
                    DGVR.Cells["Note"].Value = dr["Note_DocOut"].ToString();
                    DGVR.Cells["Org"].Value = dr["Org"].ToString();
                    DGVR.Cells["Org"].Tag = dr["ID_Org"].ToString();
                    DGVR.Cells["Adr"].Value = dr["Rec_Org"].ToString();

                    DGVR.Tag = dr["PathToImage"].ToString();
                }
                UI.SetBgRowInDGV(DGV);
            }
            CountRowLabel.Text = UI.GetCountRow(DGV);
            Cursor.Current = Cursors.Default;

            flLoadList = true;
        }

        private bool CheckFilter(DataRow dr)
        {
            bool ret = true;

            if (ФОтсутствует.Checked == true) return true;

            if (ФМесяц.Checked)
            {
                if (Convert.ToDateTime(dr["Date_DocOut"]).Date >= DateTime.Now.AddDays(-30).Date)
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
                IDOrg = DGV.SelectedRows[0].Cells["Org"].Tag.ToString();
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

        private void tm_Tick(object sender, EventArgs e)
        {
            tm.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            //UI.FilterInDGV(DGV, Filter.Text, true);
            setFastSearch(Filter.Text);
            CountRowLabel.Text = UI.GetCountRow(DGV);
            Cursor.Current = Cursors.Default;
        }

        private void ListDocsOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
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

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doSelect();
        }

        private void ЭлектроннаяВерсияДокумента_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
                FTP.DonwloadFile(DGV.SelectedRows[0].Tag.ToString());
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

            flLoadList = false;
            SqlFastSearch = string.Format(" DocsOutput.Date_DocOut >= '{0}'", DateTime.Now.AddDays(-30).Date);
            LoadData();
            GetListDoc();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            doSelect();
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                doSelect();
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {
            //UI.SetBgRowInDGV(DGV);
        }

        private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && DGV.Rows.Count > 0) UI.SetBgRowInDGV(DGV);
        }


        private void setFastSearch(string txt)
        {
            if (flLoadList == false) return;

            string sfs = "";

            txt = LocalDB.SetQuotes(txt);

            if (txt.Length > 2)
            {
                sfs = string.Format(" (CHARINDEX('{0}',DocsOutput.RN_DocOut)<>0", txt);
                sfs += string.Format(" OR CHARINDEX('{0}',DocsOutput.Date_DocOut)<>0", txt);
                sfs += string.Format(" OR CHARINDEX('{0}',DocsOutput.Note_DocOut)<>0", txt);
                sfs += string.Format(" OR CHARINDEX('{0}',DOutRec.Org)<>0", txt);
                sfs += string.Format(" OR CHARINDEX('{0}',DOutRec.Rec_Org)<>0", txt);
                sfs += ")";
            }

            if (sfs != SqlFastSearch)
            {
                flLoadList = false;
                SqlFastSearch = sfs;
                LoadData();
                GetListDoc();
            }

        }



    }
}
