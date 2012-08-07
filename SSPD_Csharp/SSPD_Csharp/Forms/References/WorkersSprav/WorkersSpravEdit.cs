using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class WorkersSpravEdit : Form
    {

        public WorkersSpravEdit()
        {
            InitializeComponent();

            //обработка событий:
            this.SizeChanged += new EventHandler(WorkersSpravEdit_SizeChanged);
            this.KeyDown +=new KeyEventHandler(WorkersSpravEdit_KeyDown);
            StatusFilter.SelectedIndexChanged +=new EventHandler(StatusFilter_SelectedIndexChanged);
            StrFind.GotFocus +=new EventHandler(StrFind_GotFocus);
            StrFind.LostFocus  +=new EventHandler(StrFind_LostFocus);
            DGV.Sorted+=new EventHandler(DGV_Sorted);
            DGV.CellMouseDoubleClick +=new DataGridViewCellMouseEventHandler(DGV_CellMouseDoubleClick);

            LoadWorkers();
            StrFind.Focus();
        }

        private void DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex!=-1) 
                OpenWorkerCard();
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {
            SSPDUI.SetBgRowInDGV(DGV);
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

        private void StatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            doFilter(StatusFilter.Text);
        }


        private void WorkersSpravEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7) SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
            if (e.KeyCode == Keys.Escape) this.Close();
        }


        private void WorkersSpravEdit_SizeChanged(object sender, EventArgs e)
        {
            DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }

        /// <summary>
        /// Загрузка списка работников
        /// </summary>
        private void LoadWorkers()
        {
            string SqlStr = "SELECT Workers.ID_Worker, Workers.F_Worker + ' ' + Workers.N_Worker +  ISNULL(' ' + Workers.P_Worker, '') AS FIO, Posts.N_Post, Otdels.Name_Otdel,"
                            + " Workers.Fl_Rel, "
                            + " CASE Workers.Fl_Rel WHEN 1 THEN 'Уволен' WHEN 2 THEN 'Командировка' WHEN 3 THEN 'Отпуск' WHEN 4 THEN 'Больничный' WHEN 5 THEN 'Декрет' WHEN 6 THEN 'Прочее ДО' ELSE '' END AS Status"
                            + " FROM Workers INNER JOIN"
                            + " Posts ON Workers.ID_Post = Posts.ID_Post INNER JOIN"
                            + " Otdels ON Workers.ID_Otdel = Otdels.ID_Otdel";
            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;

            StatusLabel.Text = "Всего работников: " + rs.Count.ToString();

            DataGridViewRow DGVR;
            DGV.Rows.Clear();
            StatusFilter.Items.Clear();
            StatusFilter.Items.Add("Все");

            foreach (DataRow dr in rs)
            {
                DGV.Rows.Add();
                DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];
                DGVR.Tag = dr["ID_Worker"].ToString();
                DGVR.Cells[0].Value = dr["FIO"].ToString();
                DGVR.Cells[1].Value = dr["N_Post"].ToString();
                DGVR.Cells[2].Value = dr["Name_Otdel"].ToString();
                DGVR.Cells[3].Value = dr["Status"].ToString();
                AddStatusInFilter(dr["Status"].ToString());
            }
            
            StatusFilter.SelectedIndex = 0;

            //меняем размер столбцов
            WorkersSpravEdit_SizeChanged(null, null);
            //красим строки
            SSPDUI.SetBgRowInDGV(DGV);
        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Заполнение фильтра статусов
        /// </summary>
        /// <param name="StatusLabel">Статус</param>
        private void AddStatusInFilter(string StatusLabel)
        {
            foreach(string obj in StatusFilter.Items){
                if (obj == StatusLabel) return;
            }
            StatusFilter.Items.Add(StatusLabel);
        }


        /// <summary>
        /// Фильтр по выбранному статусу
        /// </summary>
        /// <param name="txtFltr">Выбранный статус</param>
        private void doFilter(string txtFltr)
        {
            if (DGV.Rows.Count==0) return;
            int CountFilterRow = 0;
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                if (txtFltr != "Все")
                {
                    DGVR.Visible = false;
                    if (txtFltr == "")
                    {
                        if (DGVR.Cells[3].Value.ToString() == "")
                        {
                            DGVR.Visible = true; CountFilterRow++;
                        }
                    }
                    else if (DGVR.Cells[3].Value.ToString().IndexOf(txtFltr) > -1)
                    {
                        DGVR.Visible = true; CountFilterRow++;
                    }
                }
                else { DGVR.Visible = true; CountFilterRow++; }
            }

            StatusLabel.Text = "Всего работников: " + DGV.Rows.Count.ToString();
            if (txtFltr != "Все") StatusLabel.Text += ", отфильтровано: " + CountFilterRow.ToString();
            
            //меняем размер столбцов
            WorkersSpravEdit_SizeChanged(null, null);
            //красим строки
            SSPDUI.SetBgRowInDGV(DGV);

            //выделяем первую видимую строку в гриде
            DGV.ClearSelection();
            DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Cells[0].Selected = true;
            DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Selected = true;
        }



        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkersSpravCard WSC = new WorkersSpravCard(null);
            WSC.ShowDialog();
        }

        private void OpenWorkerCard()
        {
            if (DGV.SelectedRows.Count == 0) return;
            WorkersSpravCard WSC = new WorkersSpravCard(DGV.SelectedRows[0].Tag.ToString());
            WSC.ShowDialog();
            if (WSC.FlSave == true)
            {
                string SqlStr = "SELECT Workers.ID_Worker, Workers.F_Worker + ' ' + Workers.N_Worker +  ISNULL(' ' + Workers.P_Worker, '') AS FIO, Posts.N_Post, Otdels.Name_Otdel,"
                + " Workers.Fl_Rel, "
                + " CASE Workers.Fl_Rel WHEN 1 THEN 'Уволен' WHEN 2 THEN 'Командировка' WHEN 3 THEN 'Отпуск' WHEN 4 THEN 'Больничный' WHEN 5 THEN 'Декрет' WHEN 6 THEN 'Прочее ДО' ELSE '' END AS Status"
                + " FROM Workers INNER JOIN"
                + " Posts ON Workers.ID_Post = Posts.ID_Post INNER JOIN"
                + " Otdels ON Workers.ID_Otdel = Otdels.ID_Otdel"
                + " WHERE Workers.ID_Worker = " + WSC.IDW;
                var rs = DB.GetFields(SqlStr);
                if (rs.Count == 0) return;
                
                DataGridViewRow DGVR = DGV.SelectedRows[0];
                DataRow dr = rs[0];
                DGVR.Tag = dr["ID_Worker"].ToString();
                DGVR.Cells[0].Value = dr["FIO"].ToString();
                DGVR.Cells[1].Value = dr["N_Post"].ToString();
                DGVR.Cells[2].Value = dr["Name_Otdel"].ToString();
                DGVR.Cells[3].Value = dr["Status"].ToString();
            }
            WSC.Dispose();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWorkerCard();
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (DGV.Rows.Count == 0)
                return;
            else if (e.KeyCode == Keys.Home)
            {
                DGV.ClearSelection();
                DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Selected = true;
                DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Cells[0].Selected = true;
            }
            else if (e.KeyCode == Keys.End)
            {
                DGV.ClearSelection();
                DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)].Selected = true;
                DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)].Cells[0].Selected = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                OpenWorkerCard();
                e.Handled = true;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
        }


    }
}
