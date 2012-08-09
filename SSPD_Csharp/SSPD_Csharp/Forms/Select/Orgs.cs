using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD.Select
{
    public partial class Orgs : Form
    {

        #region [Объявление переменных]

        //флаг выбора
        public bool FlSel = false;

        //выбранные значения
        public string SelectID = null;
        public string SelectValue = null;
        
        //запрос
        private string SqlStr = null;

        //вариант отображения списка организаций
        public int means;

        #endregion

        #region [Инициализация и загрузка формы]

        public Orgs()
        {
            InitializeComponent();

            StrFind.GotFocus += new EventHandler(StrFind_GotFocus);
            StrFind.LostFocus += new EventHandler(StrFind_LostFocus);
            StrFind.KeyDown += new KeyEventHandler(StrFind_KeyDown);
        }

        private void Orgs_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region [Работа с данными]

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void LoadData()
        {
            //определяем вариант запроса
            switch (means)
            {
                case 2:
                    SqlStr = "SELECT Nakls.ID_Inp as ID_Org, Orgs.Name FROM Nakls INNER JOIN Orgs ON Nakls.ID_Inp = Orgs.ID_Org GROUP BY Nakls.ID_Inp, Orgs.Name";
                    break;
                case 3:
                    SqlStr = "SELECT Nakls.ID_Out as ID_Org, Orgs.Name FROM Nakls INNER JOIN Orgs ON Nakls.ID_Out = Orgs.ID_Org GROUP BY Nakls.ID_Out, Orgs.Name";
                    break;
                case 4:
                    SqlStr = "SELECT Orgs.name, Projects.ID_Zak as ID_Org FROM Orgs INNER JOIN Projects ON Orgs.ID_Org = Projects.ID_Zak GROUP BY Orgs.Name, Projects.ID_Zak";
                    break;
                case 5:
                    SqlStr = "SELECT Orgs.Name, PIRPlan.ID_Zak as ID_Org FROM  Orgs INNER JOIN PIRPlan ON Orgs.ID_Org = PIRPlan.ID_Zak GROUP BY Orgs.Name, PIRPlan.ID_Zak";
                    break;
                case 6:
                    SqlStr = "SELECT Orgs.Name, PIRPlan.ID_Isp as ID_Org FROM Orgs INNER JOIN  PIRPlan ON Orgs.ID_Org = PIRPlan.ID_Isp GROUP BY Orgs.Name, PIRPlan.ID_Isp";
                    break;
                case 7:
                    SqlStr = "SELECT Orgs.Name, ZPReestr.ID_Zak as ID_Org FROM Orgs INNER JOIN ZPReestr ON Orgs.ID_Org = ZPReestr.ID_Zak GROUP BY Orgs.Name, ZPReestr.ID_Zak";
                    break;
                case 8:
                    SqlStr = "SELECT Orgs.Name, PIRPlan.ID_Isp AS ID_Org FROM Orgs INNER JOIN PIRPlan ON Orgs.ID_Org = PIRPlan.ID_Isp GROUP BY Orgs.Name, PIRPlan.ID_Isp";
                    break;
                case 9:
                    SqlStr = "SELECT Orgs.Name, PIRPlan.IspII AS ID_Org FROM Orgs INNER JOIN PIRPlan ON Orgs.ID_Org = PIRPlan.IspII GROUP BY Orgs.Name, PIRPlan.IspII";
                    break;
                case 10:
                    SqlStr = "SELECT Name, ID_Org From Orgs WHERE (ID_Org =(SELECT RTRIM(LTRIM(Val_Par)) AS IDO From Params WHERE (ID_Par = 10)))";
                    break;
                case 11:
                    SqlStr = "SELECT Orgs.Name, ExpDocs.ID_Org as ID_Org FROM Orgs INNER JOIN ExpDocs ON Orgs.ID_Org = ExpDocs.ID_Org GROUP BY Orgs.Name, ExpDocs.ID_Org";
                    break;
                case 12:
                    SqlStr = "SELECT  ExpInnerParts.ID_Org AS ID_Org, Orgs.Name FROM ExpInnerParts INNER JOIN Orgs ON ExpInnerParts.ID_Org = Orgs.ID_Org GROUP BY ExpInnerParts.ID_Org, Orgs.Name";
                    break;
                default:
                    SqlStr = "SELECT ID_Org, Name From Orgs";
                    break;
            }

            var rs = DB.GetFields(SqlStr);
            
            DGV.Rows.Clear();
            DataGridViewRow DGVR;

            if (means > 1)
            {
                DGV.Rows.Add();
                DGVR = DGV.Rows[DGV.Rows.Count - 1];
                DGVR.Cells[1].Value = " [ Полный список организаций ] ";
            }

            
            if (rs.Count > 0)
            {
                foreach (DataRow dr in rs)
                {
                    DGV.Rows.Add();
                    DGVR = DGV.Rows[DGV.Rows.Count - 1];
                    DGVR.Tag = dr["ID_Org"].ToString();
                    DGVR.Cells[1].Value = dr["Name"].ToString();
                }
                //красим строки
                SSPDUI.SetBgRowInDGV(DGV);
            }
        }

        /// <summary>
        /// Выбрать элементы
        /// </summary>
        private void SelectItems()
        {
            if (DGV.CurrentRow.Tag == null)
            {
                means = 0;
                LoadData();
            }
            else
            {
                SelectID = DGV.CurrentRow.Tag.ToString();
                SelectValue = DGV.CurrentRow.Cells[1].Value.ToString();
                FlSel = true;
                this.Close();
            }
        }

        /// <summary>
        /// Поиск
        /// </summary>
        private void doSearch()
        {
            SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
        }


        #endregion

        #region [События элементов формы]

        private void Orgs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7) doSearch();
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void mbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbtnSelect_Click(object sender, EventArgs e)
        {
            SelectItems();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectItems();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            doSearch();
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
            if (e.KeyCode == Keys.Enter) doSearch();
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {
            //красим строки
            SSPDUI.SetBgRowInDGV(DGV);
        }

        private void DGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ChangeStat(e.RowIndex);
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectItems();
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Return)
                SelectItems();
        }

        /// <summary>
        /// Снять все чекбоксы и поставить в указанную строку
        /// </summary>
        /// <param name="RowIndex">Индекс строки</param>
        private void ChangeStat(int RowIndex)
        {
            if (RowIndex > -1 && DGV.Rows[RowIndex].Tag != null)
            {
                foreach (DataGridViewRow DGVR in DGV.Rows)
                {
                    DGVR.Cells[0].Value = false;
                    if (DGVR.Index == RowIndex) DGVR.Cells[0].Value = DGVR.Cells[0].Value == null ? false : true;
                }
            }
        }

        #endregion

    }
}
