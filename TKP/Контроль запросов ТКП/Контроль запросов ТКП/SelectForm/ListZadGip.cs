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
    public partial class ListZadGip : Form
    {

        public bool flSel = false;
        public DataRow drSel;

        private DataRowCollection draSSPD = null;
        private DataRowCollection draTKP = null;

        public ListZadGip()
        {
            InitializeComponent();

            this.Width = 1280;
        }


        private void ListZadGip_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadTKP();
            LoadData();

            Filter.Select();
            Cursor.Current = Cursors.Default;
        }

        private void LoadData()
        {
            string SqlStr = " SELECT ZadFromGIPReestr.ID_Rec, Workers.F_Worker + ' ' + Workers.I_Worker AS GIP, Projects.Sh_project, Projects.Name_Project, ";
            SqlStr += " ZadFromGIPReestr.PathFiles, ZadFromGIPReestr.Node, ZadFromGIPReestr.DT_Out";
            SqlStr += " FROM  ZadFromGIPReestr INNER JOIN";
            SqlStr += " ZadFromGIPReestrAdr ON ZadFromGIPReestr.ID_Rec = ZadFromGIPReestrAdr.ID_RecZadGip INNER JOIN";
            SqlStr += " Projects ON ZadFromGIPReestr.ID_Project = Projects.ID_Project INNER JOIN";
            SqlStr += " Workers ON ZadFromGIPReestr.ID_GIP = Workers.ID_Worker";
            SqlStr += " WHERE ZadFromGIPReestrAdr.ID_OtdelInp = " + TKP_Conf.AdminIDOtdel;
            SqlStr += " ORDER BY ZadFromGIPReestr.DT_Out DESC";

            draSSPD = DB.GetFields(SqlStr);
        }

        private void LoadTKP()
        {
            draTKP = LocalDB.LoadData("SELECT DISTINCT ID_Zad FROM КонтрольТКП WHERE TypeZad = 1");
        }
        
        private void GetListZad()
        {
            if (draSSPD == null) return;
            DGV.Rows.Clear();
            foreach (DataRow dr in draSSPD)
            {
                if (CheckFilter(dr))
                {
                    DGV.Rows.Add();
                    DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                    DGVR.Cells["NumZad"].Value = string.Format("{0:000000}", dr["ID_Rec"]);
                    DGVR.Cells["NumZad"].Tag = dr["ID_Rec"].ToString();

                    DGVR.Cells["ShPrj"].Value = dr["Sh_project"].ToString();
                    DGVR.Cells["NamePrj"].Value = dr["Name_Project"].ToString();
                    DGVR.Cells["GIPOut"].Value = dr["GIP"].ToString();
                    DGVR.Cells["DateOut"].Value = string.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(dr["DT_Out"]));
                    DGVR.Cells["Note"].Value = dr["Node"].ToString();
                    DGVR.Tag = dr["PathFiles"].ToString();

                    CheckTKP(dr["ID_Rec"].ToString(), DGVR);
                }
            }
        }

        //Если задание добавлено, красим строку
        private void CheckTKP(string IDRec, DataGridViewRow DGVR)
        {
            foreach (DataRow dr in draTKP)
            {
                if (dr["ID_Zad"].ToString() == IDRec)
                {
                    foreach (DataGridViewCell dgvc in DGVR.Cells)
                    {
                        dgvc.Style.BackColor = UI.bgHaveTKP;
                    }
                    return;
                }
            }
        }

        private bool CheckFilter(DataRow dr)
        {
            bool ret = true;

            if (ФОтсутствует.Checked == true) return true;

            if (ФМесяц.Checked)
            {
                if (Convert.ToDateTime(dr["DT_Out"]).Date >= DateTime.Now.AddDays(-30).Date)
                    ret = true;
                else
                    ret = false;
            }

            if (ret && ФПроект.Tag != null)
            {
                if (dr["Sh_project"].ToString() == ФПроект.Tag.ToString())
                    ret = true;
                else
                    ret = false;
            }

            return ret;
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
        
        private void doSelect()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                foreach (DataRow dr in draSSPD)
                {
                    if (dr["ID_Rec"].ToString() == DGV.SelectedRows[0].Cells[0].Tag.ToString())
                    {
                        drSel = dr;
                        flSel = true;
                        break;
                    }
                }
            }
            this.Close();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            UI.FilterInDGV(DGV, Filter.Text, false);
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

        private void ListZadGip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }


        private void ФМесяц_Click(object sender, EventArgs e)
        {
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListZad();
        }

        private void ФПроект_Click(object sender, EventArgs e)
        {
            SelectForm.ListProject LP = new SelectForm.ListProject();
            LP.ShowDialog();
            if (LP.SelID != "")
            {
                doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
                ФПроект.Text = "По проекту - " + LP.SelShPrj;
                ФПроект.Tag = LP.SelShPrj;
                GetListZad(); ;
            }
        }

        private void ФОтсутствует_Click(object sender, EventArgs e)
        {
            foreach (object obj in Фильтр.DropDownItems)
                if (obj.GetType() == ФОтсутствует.GetType())
                    ((ToolStripMenuItem)obj).Checked = false;
            ФОтсутствует.Checked = true;
            ФПроект.Tag = null;
            ФПроект.Text = "По проекту";
            GetListZad();
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doSelect();
        }

        private void элВерсияЗаданияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
                FTP.DonwloadFile(DGV.SelectedRows[0].Tag.ToString(),
                    DGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            doSelect();
        }


        

    }
}
