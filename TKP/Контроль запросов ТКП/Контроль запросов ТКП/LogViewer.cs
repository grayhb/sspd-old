using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSPD;

namespace Контроль_запросов_ТКП
{
    public partial class LogViewer : Form
    {
        DataRowCollection drcWorkers;

        //период
        DateTime PDate1 = DateTime.Now;
        DateTime PDate2 = DateTime.Now;

        public LogViewer()
        {
            InitializeComponent();
        }

        private void LogViewer_Load(object sender, EventArgs e)
        {
            LoadWorkers();
            LoadLogList();
            //MessageBox.Show(getFIO("6774"));
        }


        private void LoadLogList()
        {
            DGV.Rows.Clear();

            string sql = "SELECT * FROM КонтрольТКП_Лог ";
            sql += " WHERE ID_Worker <> 6774 ";
            sql += getSqlFilter();
            
            sql += " ORDER BY DateTimeLog DESC";
            var drc = LocalDB.LoadData(sql);

            if (drc == null) return;

            foreach (DataRow dr in drc)
            {
                DGV.Rows.Add();
                DataGridViewRow dgvr = DGV.Rows[DGV.Rows.Count - 1];
                dgvr.Cells["DateTimeLog"].Value = string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["DateTimeLog"]);
                dgvr.Cells["Worker"].Value = getFIO(dr["ID_Worker"].ToString());
                dgvr.Cells["TableName"].Value = dr["TableName"].ToString();
                dgvr.Cells["EventLog"].Value = dr["EventLog"].ToString();
                dgvr.Cells["DescLog"].Value = dr["DescLog"].ToString();
                dgvr.Cells["ID_RecTable"].Value = dr["ID_RecTable"].ToString();
                
            }

            UI.SetBgRowInDGV(DGV);
            DGVCount.Text = string.Format("Найдено записей: {0} | Обновлено: {1}", DGV.Rows.Count, DateTime.Now);
        }


        /// <summary>
        /// Установка фильтров
        /// </summary>
        /// <returns>Строка с условием</returns>
        private string getSqlFilter()
        {
            string sql;

            sql = string.Format(" AND (((DateTimeLog)>=#{0}#) AND ((DateTimeLog)<=#{1}#))",
                string.Format("{0:MM}/{0:dd}/{0:yyyy} 0:00:00", PDate1), string.Format("{0:MM}/{0:dd}/{0:yyyy} 23:59:59", PDate2));

            
            return sql;
        }

        /// <summary>
        /// Возвращает ФИО сотрудника по ID
        /// </summary>
        /// <param name="IDW">ID сотрудника</param>
        /// <returns>ФИО</returns>
        private string getFIO(string IDW)
        {
            string ret = "";

            foreach (DataRow dr in drcWorkers)
            {
                if (dr["ID_Worker"].ToString() == IDW)
                {
                    ret = dr["FIO"].ToString();
                    break;
                }
            }


            return ret;
        }

        /// <summary>
        /// Загрузка массива всех сотрудников
        /// </summary>
        private void LoadWorkers()
        {
            string sql = "SELECT ID_Worker, F_Worker + ' '+ I_Worker as FIO FROM Workers WHERE fl_Rel = 0";
            drcWorkers = DB.GetFields(sql);
        }



        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            LoadLogList();
        }

        
        private void cmdSelPeriod_Click(object sender, EventArgs e)
        {
            SelectForm.SelectPeriod sp = new SelectForm.SelectPeriod();
            sp.D1 = PDate1;
            sp.D2 = PDate2;
            sp.ShowDialog();

            if (sp.flSel)
            {
                PDate1 = sp.D1;
                PDate2 = sp.D2;

                if (PDate1 == PDate2 && PDate1 == DateTime.Now)
                    LabelPeriod.Text = "Период: за сегодня";
                else
                    LabelPeriod.Text = string.Format("Период: с {0} по {1}", PDate1.ToShortDateString(), PDate2.ToShortDateString());

                LoadLogList();
            }
        }

    }
}
