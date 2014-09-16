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
        public string IDOrg = "";

        public string SqlFastSearch = "";

        private DataRowCollection dra = null;

        Timer tm = new Timer();
        bool flLoadList = false;
        

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

        }

        private void ListDocsInp_Shown(object sender, EventArgs e)
        {
            SqlFastSearch = string.Format(" AND DocsInput.Date_DocInp >= '{0}'", DateTime.Now.AddDays(-30).Date);
            
            Application.DoEvents();
            LoadData();

            GetListDoc();

            CountRowLabel.Text += " (За последние 30 дней)";


            DGV.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }


        private void LoadData()
        {

            string SqlStr = "SELECT DISTINCT DocsInput.ID_DocInp, DocsInput.RN_DocInp, DocsInput.Date_DocInp, DocsInput.Note_DocInp, Orgs.Name, ";
            SqlStr += " DocsInput.Aut_Org, DocsInput.PathToImage, Orgs.ID_Org";
            SqlStr += " FROM DocsInput INNER JOIN";
            SqlStr += " DocsInputExec ON DocsInput.ID_DocInp = DocsInputExec.ID_DocInp INNER JOIN";
            SqlStr += " Orgs ON DocsInput.ID_Org = Orgs.ID_Org INNER JOIN";
            SqlStr += " Workers ON Workers.ID_Worker = DocsInputExec.ID_WorkerInput";
            SqlStr += " WHERE Workers.ID_Otdel = " + TKP_Conf.AdminIDOtdel + SqlFastSearch;
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
                    //if (CheckFilter(dr))
                    //{
                    DGV.Rows.Add();
                    DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                    DGVR.Cells["RNDoc"].Value = string.Format("{0:000000}", dr["RN_DocInp"]); 
                    DGVR.Cells["RNDoc"].Tag = dr["ID_DocInp"].ToString();

                    DGVR.Cells["DateDoc"].Value = UI.GetDate(dr["Date_DocInp"].ToString());
                    DGVR.Cells["Note"].Value = dr["Note_DocInp"].ToString();
                    DGVR.Cells["Org"].Value = dr["Name"].ToString();
                    DGVR.Cells["Org"].Tag = dr["ID_Org"].ToString();
                    DGVR.Cells["Adr"].Value = dr["Aut_Org"].ToString();

                    DGVR.Tag = dr["PathToImage"].ToString();

                    //}
                }
                UI.SetBgRowInDGV(DGV);
            }
            CountRowLabel.Text = UI.GetCountRow(DGV);
            Cursor.Current = Cursors.Default;

            flLoadList = true;
        }


        private void setFastSearch(string txt)
        {
            if (flLoadList == false) return;

            string sfs = "";

            txt = LocalDB.SetQuotes(txt);

            if (txt.Length > 2)
            {
                sfs = string.Format(" AND (CHARINDEX('{0}',DocsInput.RN_DocInp)<>0", txt);
                sfs += string.Format(" OR CHARINDEX('{0}',DocsInput.Date_DocInp)<>0", txt);
                sfs += string.Format(" OR CHARINDEX('{0}',DocsInput.Note_DocInp)<>0", txt);
                sfs += string.Format(" OR CHARINDEX('{0}',Orgs.Name)<>0", txt);
                sfs += string.Format(" OR CHARINDEX('{0}',DocsInput.Aut_Org)<>0", txt);
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




        //private bool CheckFilter(DataRow dr)
        //{
        //    bool ret = true;

        //    if (ФОтсутствует.Checked == true) return true;

        //    if (ФМесяц.Checked)
        //    {
        //        if (Convert.ToDateTime(dr["Date_DocInp"]).Date >= DateTime.Now.AddDays(-30).Date)
        //            ret = true;
        //        else
        //            ret = false;
        //    }

        //    return ret;
        //}

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
            //UI.FilterInDGV(DGV, Filter.Text, true);
            setFastSearch(Filter.Text);
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
            //UI.SetBgRowInDGV(DGV);
        }

        private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && DGV.Rows.Count > 0) UI.SetBgRowInDGV(DGV);
        }


        

    }
}
