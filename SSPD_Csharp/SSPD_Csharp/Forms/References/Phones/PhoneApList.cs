using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class PhoneApList : Form
    {

        public string SelectedIDAN;
        public string SelectedAN; 

        private bool ReadOnly;


        public PhoneApList(bool FlRead)
        {
            InitializeComponent();

            StrFind.GotFocus += new EventHandler(StrFind_GotFocus);
            StrFind.LostFocus += new EventHandler(StrFind_LostFocus);
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

        private void PhoneApList_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadDataList();
            Cursor.Current = Cursors.Default;
        }


        private void LoadDataList()
        {
            string SqlStr ="";
            if (ReadOnly == false) {
                SqlStr = "SELECT     PhoneAp.ID_PA, PhoneAp.Inv, PhoneAp.IMEI, PhoneAp.Label, DERIVEDTBL.DateTimeInp, DERIVEDTBL.DateTimeOut, DERIVEDTBL.FIO,"
                + " DERIVEDTBL.NB_Otdel , DERIVEDTBL.TUse"
                + " FROM         PhoneAp LEFT OUTER JOIN"
                + " (SELECT     PhoneMov.ID_PA, ISNULL(PhoneMov.DateTimeInp, 1) AS DateTimeInp, PhoneMov.DateTimeOut,"
                + " Workers.F_Worker + ' ' + Workers.I_Worker AS FIO, Otdels.NB_Otdel, PhoneMov.TUse"
                + " FROM          PhoneMov INNER JOIN"
                + " Workers ON PhoneMov.ID_Worker = Workers.ID_Worker INNER JOIN"
                + " Otdels ON Workers.ID_Otdel = Otdels.ID_Otdel"
                + " WHERE      (PhoneMov.DateTimeInp IS NULL)) DERIVEDTBL ON PhoneAp.ID_PA = DERIVEDTBL.ID_PA";
            } else {
                SqlStr = "SELECT PhoneAp.ID_PA, PhoneAp.Inv, PhoneAp.IMEI, PhoneAp.Label"
                + " FROM PhoneAp LEFT OUTER JOIN"
                + " (SELECT     ID_PA, isnull(DateTimeInp, 1) AS DateTimeInp"
                + " From PhoneMov"
                + " WHERE      (DateTimeInp IS NULL)) DERIVEDTBL ON PhoneAp.ID_PA = DERIVEDTBL.ID_PA"
                + " Where (DERIVEDTBL.DateTimeInp Is Null)";
            }
            var rs = DB.GetFields(SqlStr + " ORDER BY PhoneAp.IMEI DESC");
            if (rs.Count == 0) return;

            DataGridViewRow DGVR;
            DGV.Rows.Clear();
            

            foreach (DataRow dr in rs)
            {
                DGV.Rows.Add();
                DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                DGVR.Tag = dr["ID_PA"].ToString();
                DGVR.Cells[0].Value = dr["IMEI"].ToString();
                DGVR.Cells[1].Value = dr["Inv"].ToString();
                DGVR.Cells[2].Value = dr["Label"].ToString();
                if (ReadOnly == false && dr["DateTimeOut"].ToString().Length >0 )
                {
                    DGVR.Cells[3].Value = "Выдан ";
                    DGVR.Cells[3].Value += dr["TUse"].ToString() == "0" ? "во временное пользование " : "в постоянное пользование ";
                    DGVR.Cells[3].Value += string.Format ("{0:dd-MM-yyyy hh:mm}",Convert.ToDateTime (dr["DateTimeOut"].ToString()));
                    DGVR.Cells[3].Value += ". Пользователь - " + dr["FIO"].ToString() + " (" + dr["NB_Otdel"].ToString() + ")";
                }
            }

            //красим строки
            SSPDUI.SetBgRowInDGV(DGV);
        }


        private void AddNewItem()
        {
            //PhoneSIMCard SimCard = new PhoneSIMCard(false, "");
            //SimCard.ShowDialog();
            //if (SimCard.FlSave == true) LoadDataList();
        }

        private void EditItem()
        {
            if (DGV.Rows.Count == 0) return;
            /*PhoneSIMCard SimCard = new PhoneSIMCard(true, DGV.CurrentRow.Tag.ToString());
            SimCard.ShowDialog();
            if (SimCard.FlSave == true && SimCard.SIM!= null)
            {
                DGV.CurrentRow.Cells[0].Value = SimCard.SIM["ANamber"];
                DGV.CurrentRow.Cells[1].Value = SimCard.SIM["NSim"];
                DGV.CurrentRow.Cells[2].Value = SimCard.SIM["PIN1"];
                DGV.CurrentRow.Cells[3].Value = SimCard.SIM["PIN2"];
                DGV.CurrentRow.Cells[4].Value = SimCard.SIM["PUK1"];
                DGV.CurrentRow.Cells[5].Value = SimCard.SIM["PUK2"];
            }
             * */
        }

        private void DelItem()
        {
            if (MessageBox.Show("Удалить номер " + DGV.CurrentRow.Cells[0].Value.ToString() + "?", "Удаление карты SIM",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            /*DB.DeleteRow("PhoneSim", "ID_Sim = " + DGV.CurrentRow.Tag.ToString());
            DGV.Rows.RemoveAt(DGV.CurrentRow.Index);
            SSPDUI.SetBgRowInDGV(DGV);
             * */
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
                if (DGV.Rows.Count == 0) return;
                if (ReadOnly == true)
                {
                    SelectedIDAN = DGV.CurrentRow.Tag.ToString();
                    this.Close();
                }
                else EditItem();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape) this.Close();
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
            if (e.KeyCode == Keys.Enter) SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
        }


        private void PhoneSIMList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7) SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
            if (e.KeyCode == Keys.Insert) AddNewItem();
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
            SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
        }


        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            AddNewItem();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewItem();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            EditItem();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            DelItem();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelItem();
        }

    }
}
