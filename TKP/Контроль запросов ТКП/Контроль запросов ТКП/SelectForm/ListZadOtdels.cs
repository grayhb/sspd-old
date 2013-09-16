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
    public partial class ListZadOtdels : Form
    {

        public bool flSel = false;
        public DataRow drSel;

        private DataRowCollection draSSPD = null;
        private DataRowCollection draTKP = null;

        public ListZadOtdels()
        {
            InitializeComponent();

            this.Width = 1280;

        }

        private void ListZadOtdels_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadTKP();
            LoadData();
            GetListZad();
            Filter.Select();
            Cursor.Current = Cursors.Default;
        }

        private void LoadData()
        {
            string SqlStr = "SELECT ExchandeZadReestr.ID_Rec,  Projects.Sh_project,  Projects.Name_Project,  Otdels.NB_Otdel,  ExchandeZadReestr.DT_Out, ExchandeZadReestr.Node, ExchandeZadReestr.PathFiles";
            SqlStr = SqlStr + " FROM ExchandeZadReestr INNER JOIN ";
            SqlStr = SqlStr + " Projects ON  ExchandeZadReestr.ID_Project =  Projects.ID_Project INNER JOIN ";
            SqlStr = SqlStr + " Otdels ON  ExchandeZadReestr.ID_OtdelOut =  Otdels.ID_Otdel ";
            SqlStr = SqlStr + " WHERE ExchandeZadReestr.ID_OtdelInp = " + TKP_Conf.AdminIDOtdel + " AND ExchandeZadReestr.Status = 1 ";
            SqlStr = SqlStr + " ORDER BY ExchandeZadReestr.DT_Out DESC";

            draSSPD = DB.GetFields(SqlStr);
        }

        private void LoadTKP()
        {
            draTKP = LocalDB.LoadData("SELECT DISTINCT ID_Zad FROM КонтрольТКП WHERE TypeZad = 0");
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
                    DGVR.Cells["OtdelOut"].Value = dr["NB_Otdel"].ToString();
                    DGVR.Cells["DateOut"].Value = UI.GetDate(dr["DT_Out"].ToString(), 1);
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

        private void ListZadOtdels_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doSelect();
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

        private void элВерсияЗаданияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
                FTP.DonwloadFile(DGV.SelectedRows[0].Tag.ToString(),
                    DGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >-1)
                doSelect();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
