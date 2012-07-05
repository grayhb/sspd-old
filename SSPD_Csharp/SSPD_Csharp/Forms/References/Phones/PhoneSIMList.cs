using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class PhoneSIMList : Form
    {

        private bool ReadOnly;

        /// <summary>
        /// переменные для поиска в гриде
        /// </summary>
        private bool FlSearchStop=false;
        private int IndexFind;

        public PhoneSIMList(bool FlRead)
        {
            InitializeComponent();

            StrFind.GotFocus += new EventHandler(StrFind_GotFocus);
            StrFind.LostFocus += new EventHandler(StrFind_LostFocus);
            StrFind.TextChanged += new EventHandler(StrFind_TextChanged);
            StrFind.KeyDown +=new KeyEventHandler(StrFind_KeyDown);

            ReadOnly = FlRead;

            if (ReadOnly == true)
            {
                toolStripStatusLabel2.Visible = false;
                toolStripStatusLabel3.Visible = false;
                toolStripStatusLabel4.Visible = false;
                записиToolStripMenuItem.Visible = false;
                toolStripStatusLabel5.Visible = true;
                выбратьToolStripMenuItem.Visible = true;
                toolStripSeparator1.Visible = true;
            }
            else
            {
                toolStripStatusLabel2.Visible = true;
                toolStripStatusLabel3.Visible = true;
                toolStripStatusLabel4.Visible = true;
                записиToolStripMenuItem.Visible = true;
                toolStripStatusLabel5.Visible = false;
                выбратьToolStripMenuItem.Visible = false;
                toolStripSeparator1.Visible = false;
            }

            if (Screen.PrimaryScreen.WorkingArea.Width > 1150) this.Width = 1150;
        }

        private void PhoneSIMList_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadSIMList();
            Cursor.Current = Cursors.Default;
        }


        private void LoadSIMList()
        {
            string SqlStr ="";
            if (ReadOnly == false) {
                SqlStr = "SELECT PhoneSim.ID_Sim, PhoneSim.NSim, PhoneSim.ANamber, PhoneSim.PIN1, PhoneSim.PIN2, PhoneSim.PUK1, PhoneSim.PUK2,"
                + " DERIVEDTBL.DateTimeInp , DERIVEDTBL.DateTimeOut, DERIVEDTBL.FIO, DERIVEDTBL.NB_Otdel, DERIVEDTBL.TUse"
                + " FROM PhoneSim LEFT OUTER JOIN"
                + " (SELECT ISNULL(PhoneMov.DateTimeInp, 1) AS DateTimeInp, PhoneMov.DateTimeOut, Workers.F_Worker + ' ' + Workers.I_Worker AS FIO,"
                + " Otdels.NB_Otdel , PhoneMov.TUse, PhoneMov.ID_Sim"
                + " FROM PhoneMov INNER JOIN"
                + " Workers ON PhoneMov.ID_Worker = Workers.ID_Worker INNER JOIN"
                + " Otdels ON Workers.ID_Otdel = Otdels.ID_Otdel"
                + " WHERE (PhoneMov.DateTimeInp IS NULL)) DERIVEDTBL ON PhoneSim.ID_Sim = DERIVEDTBL.ID_Sim";
            } else {
                SqlStr = "SELECT PhoneSim.ID_Sim, PhoneSim.NSim, PhoneSim.ANamber, PhoneSim.PIN1, PhoneSim.PIN2, PhoneSim.PUK1, PhoneSim.PUK2,"
                + " DERIVEDTBL.DateTimeInp"
                + " FROM         PhoneSim LEFT OUTER JOIN"
                + " (SELECT     ID_Sim, isnull(DateTimeInp, 1) AS DateTimeInp"
                + " From PhoneMov"
                + " WHERE      (DateTimeInp IS NULL)) DERIVEDTBL ON PhoneSim.ID_Sim = DERIVEDTBL.ID_Sim"
                + " WHERE     (DERIVEDTBL.DateTimeInp IS NULL)";
            }
            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;

            DataGridViewRow DGVR;
            DGV.Rows.Clear();

            foreach (DataRow dr in rs)
            {
                DGV.Rows.Add();
                DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];
                DGVR.Tag = dr["ID_Sim"].ToString();
                DGVR.Cells[0].Value = dr["ANamber"].ToString();
                DGVR.Cells[1].Value = dr["NSim"].ToString();
                DGVR.Cells[2].Value = dr["PIN1"].ToString();
                DGVR.Cells[3].Value = dr["PIN2"].ToString();
                DGVR.Cells[4].Value = dr["PUK1"].ToString();
                DGVR.Cells[5].Value = dr["PUK2"].ToString();
                if (ReadOnly == false && dr["DateTimeOut"].ToString().Length >0 )
                {
                    DGVR.Cells[6].Value = "Выдана ";
                    DGVR.Cells[6].Value += dr["TUse"].ToString() == "0" ? "во временное пользование " : "в постоянное пользование ";
                    DGVR.Cells[6].Value += string.Format ("{0:dd-MM-yyyy hh:mm}",Convert.ToDateTime (dr["DateTimeOut"].ToString()));
                    DGVR.Cells[6].Value += ". Пользователь - " + dr["FIO"].ToString() + " (" + dr["NB_Otdel"].ToString() + ")";
                }
            }

            //красим строки
            SSPDUI.SetBgRowInDGV(DGV);
        }

        /// <summary>
        /// Поиск по всем ячейкам грида
        /// </summary>
        private void SearchInDGV()
        {
            if (StrFind.Text.Length == 0) return;
            FlSearchStop = false;
            if (IndexFind != DGV.CurrentRow.Index) IndexFind = -1;
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                if (FlSearchStop == true) return;
                foreach (DataGridViewCell DGVC in DGVR.Cells)
                {
                    if (FlSearchStop == true) return;
                    if (DGVC.Value != null && DGVC.Value.ToString().ToLower().IndexOf(StrFind.Text.ToLower()) > -1 && DGVR.Index > IndexFind && DGVR.Visible == true)
                    {
                        DGV.ClearSelection();
                        DGVC.Selected = true;
                        DGVR.Selected = true;
                        FlSearchStop = true;
                        IndexFind = DGVR.Index;
                        return;
                    }
                }
            }
        }

        private void AddNewSIM()
        {
            PhoneSIMCard SimCard = new PhoneSIMCard(false, "");
            SimCard.ShowDialog();
        }

        private void EditSIM()
        {
            if (DGV.Rows.Count == 0) return;
            PhoneSIMCard SimCard = new PhoneSIMCard(true, DGV.CurrentRow.Tag.ToString());
            SimCard.ShowDialog();
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
                e.Handled = true;
            }
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
            if (e.KeyCode == Keys.Enter) SearchInDGV();
        }

        private void StrFind_TextChanged(object sender, EventArgs e)
        {
            IndexFind = -1;
        }

        private void PhoneSIMList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7) SearchInDGV();
            if (e.KeyCode == Keys.Insert) AddNewSIM();
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
            SearchInDGV();
        }


        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            AddNewSIM();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSIM();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            EditSIM();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            EditSIM();
        }

    }
}
