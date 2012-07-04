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

        //флаг поиска
        private bool FlSearchStop = true;
        //индекс последнего найденного работника
        private int IndexFind = -1;


        public WorkersSpravEdit()
        {
            InitializeComponent();
            this.Shown +=new EventHandler(WorkersSpravEdit_Shown);
            this.SizeChanged += new EventHandler(WorkersSpravEdit_SizeChanged);
            this.KeyDown +=new KeyEventHandler(WorkersSpravEdit_KeyDown);
            StrFind.TextChanged +=new EventHandler(StrFind_TextChanged);
            StatusFilter.SelectedIndexChanged +=new EventHandler(StatusFilter_SelectedIndexChanged);
            StrFind.GotFocus +=new EventHandler(StrFind_GotFocus);
            StrFind.LostFocus  +=new EventHandler(StrFind_LostFocus);
            DGV.Sorted+=new EventHandler(DGV_Sorted);
            DGV.CellMouseDoubleClick +=new DataGridViewCellMouseEventHandler(DGV_CellMouseDoubleClick);
        }

        private void DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex!=-1) 
                OpenWorkerCard();
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {
            SetBgRowInDGV();
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

        private void StatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            doFilter(StatusFilter.Text);
        }

        private void StrFind_TextChanged(object sender, EventArgs e)
        {
            IndexFind = -1;
        }

        private void WorkersSpravEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7) SearchInDGV();
            if (e.KeyCode == Keys.Escape) this.Close();
            if (StrFind.Focused == false) StrFind.Focus();
            else if (e.KeyCode == Keys.Enter) SearchInDGV();
        }

        private void WorkersSpravEdit_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadWorkers();
            
            Application.DoEvents();
            this.Opacity = 1;
            StrFind.Focus();
            Cursor.Current = Cursors.Default;
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
            SetBgRowInDGV();
        }

        /// <summary>
        /// Поиск по всем ячейкам грида
        /// </summary>
        private void SearchInDGV()
        {
            if (StrFind.Text.Length == 0) return;
            FlSearchStop = false;
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                if (FlSearchStop == true) return;
                foreach (DataGridViewCell DGVC in DGVR.Cells)
                {
                    if (FlSearchStop == true) return;
                    if (DGVC.Value.ToString().ToLower().IndexOf(StrFind.Text.ToLower()) > -1 && DGVR.Index > IndexFind && DGVR.Visible==true)
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

            //не найдено, и поиск начат с середины, повторяем поиск с первой позиции
            if (IndexFind > -1) { IndexFind = -1; SearchInDGV(); }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FlSearchStop = false;
            SearchInDGV();
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
            SetBgRowInDGV();

            //выделяем первую видимую строку в гриде
            DGV.ClearSelection();
            DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Cells[0].Selected = true;
            DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Selected = true;
        }

        /// <summary>
        /// Заливаем четные строки
        /// </summary>
        private void SetBgRowInDGV()
        {
            bool odd = false;
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                foreach (DataGridViewCell DGVC in DGVR.Cells)
                {
                    if (odd) DGVC.Style.BackColor = Color.FromArgb(240,240,240);
                    else DGVC.Style.BackColor = Color.White;
                }
                if (DGVR.Visible) odd = odd == true ? false : true;
            }
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
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWorkerCard();
        }
    }
}
