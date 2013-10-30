using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace Контроль_запросов_ТКП
{
    class ExportExl
    {

        public static void ExportTKP(DataGridView DGV)
        {
            List<Hashtable> TKP = new List<Hashtable>();
            ExportExl exportXls = new ExportExl();

            Form frm = exportXls.initFormProgress();
            
            TKP = exportXls.CreateHash(DGV, frm);

            exportXls.WriteInExcel(TKP, frm);
            
            exportXls.diposeFormProgress(frm);
        }

        /// <summary>
        /// Вывод данных в Экзель
        /// </summary>
        /// <param name="TKP">Массив данных по ТКП</param>
        private void WriteInExcel(List<Hashtable> TKP, Form frmProgress)
        {
            //прогресс бар
            ProgressBar PB = ((ProgressBar)frmProgress.Controls[0]);

            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet wbs = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            Excel.Range range = wbs.UsedRange;
            try
            {
                (range.Cells[1, 1] as Excel.Range).Value = "№ п/п";
                (range.Cells[1, 2] as Excel.Range).Value = "N/З";
                (range.Cells[1, 3] as Excel.Range).Value = "Шифр ОЛ/ТЗ";
                (range.Cells[1, 4] as Excel.Range).Value = "Наименование проекта";
                (range.Cells[1, 5] as Excel.Range).Value = "Оборудование";
                (range.Cells[1, 6] as Excel.Range).Value = "Сдача пр.";
                (range.Cells[1, 7] as Excel.Range).Value = "Выдал";
                (range.Cells[1, 8] as Excel.Range).Value = "Дата выдачи";
                (range.Cells[1, 9] as Excel.Range).Value = "ГИП";
                (range.Cells[1, 10] as Excel.Range).Value = "Статус запроса";
                (range.Cells[1, 11] as Excel.Range).Value = "Выполнено";

                (range.Cells[1, 12] as Excel.Range).Value = "Р/Н исх.";
                (range.Cells[1, 13] as Excel.Range).Value = "Дата исх.";
                (range.Cells[1, 14] as Excel.Range).Value = "Орг. получатель";
                (range.Cells[1, 15] as Excel.Range).Value = "Р/Н вх.";
                (range.Cells[1, 16] as Excel.Range).Value = "Дата вх.";
                (range.Cells[1, 17] as Excel.Range).Value = "Примечание";
                (range.Cells[1, 18] as Excel.Range).Value = "Контакты";

                int rowout = 2;
                int numTKP = 0;

                foreach (Hashtable zadTKP in TKP)
                {
                    numTKP = numTKP + 1;

                    if (zadTKP.Contains("Mail"))
                    {
                        foreach (Hashtable mail in (List<Hashtable>)zadTKP["Mail"])
                        {
                            this.WriteInExcelInfoZadTKP(zadTKP, range, rowout, numTKP);

                            this.WriteInExcelMailZadTKP(mail, range, rowout);


                            

                            rowout++;
                        }

                        this.WriteInExcelSetFormatTKP(wbs, rowout, ((List<Hashtable>)zadTKP["Mail"]).Count);

                    }
                    else
                    {
                        this.WriteInExcelInfoZadTKP(zadTKP, range, rowout, numTKP);
                        this.WriteInExcelSetFormatTKP(wbs, rowout, 0);
                        rowout++;
                    }

                    PB.Value++;
                }


                this.WriteInExcelResizeColumn(range);
                this.WriteInExcelSetBodyFormat(wbs, rowout);


                //настройки предварительного просмотра
                wbs.PageSetup.LeftMargin = 20;
                wbs.PageSetup.RightMargin = 20;
                wbs.PageSetup.TopMargin = 20;
                wbs.PageSetup.BottomMargin = 20;
                wbs.PageSetup.Zoom = false;
                wbs.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                wbs.PageSetup.FitToPagesTall = false;
                wbs.PageSetup.FitToPagesWide = 1;
                wbs.PageSetup.CenterHorizontally = true;
                wbs.PageSetup.PrintTitleRows = "$1:$1";
                wbs.PageSetup.RightFooter = "&P из &N";

                //закрепляем верхнюю строку
                app.ActiveWindow.SplitRow = 1;
                app.ActiveWindow.FreezePanes = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка выполнения экспорта в Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.WriteLine(ex);
            }

            app.Visible = true;
        }

        private void WriteInExcelSetFormatTKP(Excel.Worksheet wbs, int rowout, int countMail)
        {

            if (countMail > 1)
                wbs.Range[wbs.Cells[rowout - countMail + 1, 1], wbs.Cells[rowout - 1, 11]].Font.Colorindex = 2;
            //else if (countMail == 0) 
            //   rowout--;
            int CountCol = 18;

            (wbs.Range[wbs.Cells[rowout - countMail , 1], wbs.Cells[rowout - countMail , 11]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail , 1], wbs.Cells[rowout - countMail , 11]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail , 1], wbs.Cells[rowout - countMail , 11]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail , 1], wbs.Cells[rowout - countMail , 11]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail , 1], wbs.Cells[rowout - countMail , 11]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail , 1], wbs.Cells[rowout - countMail , 11]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideVertical].LineStyle = 1;

            (wbs.Range[wbs.Cells[rowout - countMail, 12], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail, 12], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail, 12], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail, 12], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail, 12], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout - countMail, 12], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideVertical].LineStyle = 1;

            if (countMail == 0) rowout++;
            //верхняя жирная линия
            (wbs.Range[wbs.Cells[rowout, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            (wbs.Range[wbs.Cells[rowout, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlMedium;
            (wbs.Range[wbs.Cells[rowout, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;

        }

        private void WriteInExcelSetBodyFormat(Excel.Worksheet wbs, int rowout)
        {
            int CountCol = 18;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Font.Name = "Franklin Gothic Book";
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Font.Size = 8;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].WrapText = true;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //шапка
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[1, CountCol]].Font.Bold = true;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[1, CountCol]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            (wbs.Range[wbs.Cells[2, 1], wbs.Cells[2, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            (wbs.Range[wbs.Cells[2, 1], wbs.Cells[2, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            (wbs.Range[wbs.Cells[2, 1], wbs.Cells[2, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlMedium;
            (wbs.Range[wbs.Cells[2, 1], wbs.Cells[2, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
            //сетка
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;

            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideVertical].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;

         
        }

        private void WriteInExcelResizeColumn(Excel.Range range)
        {
            (range.Columns[1] as Excel.Range).ColumnWidth = 5;
            (range.Columns[2] as Excel.Range).ColumnWidth = 5;
            (range.Columns[3] as Excel.Range).ColumnWidth = 16;
            (range.Columns[4] as Excel.Range).ColumnWidth = 20;
            (range.Columns[5] as Excel.Range).ColumnWidth = 13;
            (range.Columns[6] as Excel.Range).ColumnWidth = 8;
            (range.Columns[7] as Excel.Range).ColumnWidth = 8;
            (range.Columns[8] as Excel.Range).ColumnWidth = 13;
            (range.Columns[9] as Excel.Range).ColumnWidth = 10;
            (range.Columns[10] as Excel.Range).ColumnWidth = 12;
            (range.Columns[11] as Excel.Range).ColumnWidth = 8;
            (range.Columns[12] as Excel.Range).ColumnWidth = 8;
            (range.Columns[13] as Excel.Range).ColumnWidth = 8;
            (range.Columns[14] as Excel.Range).ColumnWidth = 12;
            (range.Columns[15] as Excel.Range).ColumnWidth = 8;
            (range.Columns[16] as Excel.Range).ColumnWidth = 8;
            (range.Columns[17] as Excel.Range).ColumnWidth = 13;
            (range.Columns[18] as Excel.Range).ColumnWidth = 20;
        }

        private void WriteInExcelMailZadTKP(Hashtable mail, Excel.Range range, int rowout)
        {
            //исходящие письмо
            if (mail.Contains("rn_DocOut"))
            {
                if (mail["rn_DocOut"] != null)
                    (range.Cells[rowout, 12] as Excel.Range).Value = mail["rn_DocOut"].ToString();

                if (mail["date_DocOut"] != null)
                    (range.Cells[rowout, 13] as Excel.Range).Value = mail["date_DocOut"].ToString();

                if (mail["org_DocOut"] != null)
                    (range.Cells[rowout, 14] as Excel.Range).Value = mail["org_DocOut"].ToString();

                if (mail["contacts_DocOut"] != null)
                    (range.Cells[rowout, 18] as Excel.Range).Value = mail["contacts_DocOut"].ToString();
                
            }

            //входящее письмо
            if (mail.Contains("rn_DocInp"))
            {
                if (mail["rn_DocInp"] != null)
                    (range.Cells[rowout, 15] as Excel.Range).Value = mail["rn_DocInp"].ToString();

                if (mail["date_DocInp"] != null)
                    (range.Cells[rowout, 16] as Excel.Range).Value = mail["date_DocInp"].ToString();

            }

            if (mail["Mail_Note"] != null)
                (range.Cells[rowout, 17] as Excel.Range).Value = mail["Mail_Note"].ToString();

        }

        private void WriteInExcelInfoZadTKP(Hashtable zadTKP, Excel.Range range, int rowout, int numTKP)
        {
            (range.Cells[rowout, 1] as Excel.Range).Value = numTKP;
            
            if (zadTKP["NZ"] != null) 
                (range.Cells[rowout, 2] as Excel.Range).Value = zadTKP["NZ"].ToString();
            
            if (zadTKP["ShOl"] != null) 
                (range.Cells[rowout, 3] as Excel.Range).Value = zadTKP["ShOl"].ToString();

            if (zadTKP["NamePrj"] != null) 
                (range.Cells[rowout, 4] as Excel.Range).Value = zadTKP["NamePrj"].ToString();

            if (zadTKP["Equip"] != null) 
                (range.Cells[rowout, 5] as Excel.Range).Value = zadTKP["Equip"].ToString();

            if (zadTKP["DatePrj"] != null) 
                (range.Cells[rowout, 6] as Excel.Range).Value = zadTKP["DatePrj"].ToString();

            if (zadTKP["OtdelZad"] != null) 
                (range.Cells[rowout, 7] as Excel.Range).Value = zadTKP["OtdelZad"].ToString();

            if (zadTKP["DateZad"] != null) 
                (range.Cells[rowout, 8] as Excel.Range).Value = zadTKP["DateZad"].ToString();

            if (zadTKP["GIP"] != null) 
                (range.Cells[rowout, 9] as Excel.Range).Value = zadTKP["GIP"].ToString();

            if (zadTKP["Status"] != null) 
                (range.Cells[rowout, 10] as Excel.Range).Value = zadTKP["Status"].ToString();

            if (zadTKP["DateFinish"] != null) 
                (range.Cells[rowout, 11] as Excel.Range).Value = zadTKP["DateFinish"].ToString();


        }



        /// <summary>
        /// Функция формирования массива данных по заданиям ТКП
        /// </summary>
        /// <param name="DGV">Элемент со списком заданий</param>
        /// <param name="frmProgress">Форма для вывода прогресса выполнения</param>
        /// <returns></returns>
        private List<Hashtable> CreateHash(DataGridView DGV, Form frmProgress)
        {
            List<Hashtable> arrTKP = new List<Hashtable>();

            
            frmProgress.Show();
            //прогресс бар
            ProgressBar PB = ((ProgressBar)frmProgress.Controls[0]);
            PB.Maximum = DGV.Rows.Count * 2;

            //сортируем по номеру задания
            //DGV.Sort(DGV.Columns[0], System.ComponentModel.ListSortDirection.Descending);

            foreach(DataGridViewRow DGVR in DGV.Rows) {

                Hashtable zadTKP = new Hashtable();
                zadTKP.Add("NZ", DGVR.Cells["NZ"].Value);
                zadTKP.Add("ShOl", DGVR.Cells["ShOl"].Value);
                zadTKP.Add("NamePrj", DGVR.Cells["NamePrj"].Value);
                zadTKP.Add("Equip", DGVR.Cells["Equip"].Value);
                zadTKP.Add("DatePrj", DGVR.Cells["DatePrj"].Value);
                zadTKP.Add("OtdelZad", DGVR.Cells["OtdelZad"].Value);
                zadTKP.Add("DateZad", DGVR.Cells["DateZad"].Value);
                zadTKP.Add("GIP", DGVR.Cells["GIP"].Value);
                zadTKP.Add("Status", DGVR.Cells["Status"].Value);
                zadTKP.Add("DateFinish", DGVR.Cells["DateFinish"].Value);

                var rs = LocalDB.LoadData("SELECT ID_OutDoc, ID_InpDoc, Mail_Note, DateStartTKP, DateFinishTKP FROM КонтрольТКП_Письма WHERE ID_TKP = " + ((Hashtable)DGVR.Tag)["ID_TKP"].ToString() + " ORDER BY ID_OutDoc ASC");
                if (rs != null && rs.Count > 0)
                {
                    List<Hashtable> arrMail = new List<Hashtable>();

                    foreach (DataRow dr in rs)
                    {
                        int idOut = 0; int idInp = 0;

                        if (dr["ID_OutDoc"].ToString() != "") idOut = (int)dr["ID_OutDoc"];
                        if (dr["ID_InpDoc"].ToString() != "") idInp = (int)dr["ID_InpDoc"];
                        
                        Hashtable h = new Hashtable();

                        h = this.getDataMail(idOut, idInp);
                        h.Add("Mail_Note", dr["Mail_Note"].ToString());
                        //h.Add("DateStartTKP", dr["DateStartTKP"].ToString());
                        //h.Add("DateFinishTKP", dr["DateFinishTKP"].ToString());

                        arrMail.Add(h);

                        h = null;
                    }
                    zadTKP.Add("Mail", arrMail);
                    arrMail = null;
                }
                PB.Value ++;

                arrTKP.Add(zadTKP);
                zadTKP = null;
            }

            return arrTKP;
        }


        /// <summary>
        /// Получает данные по письмам из базы ССПД
        /// </summary>
        /// <param name="id_DocOut">ID - исходящего письма</param>
        /// <param name="id_DocInp">ID - входящего письма</param>
        /// <returns>Хэшкод</returns>
        private Hashtable getDataMail(int id_DocOut, int id_DocInp)
        {
            Hashtable h = new Hashtable();
            string sql = "";

            //данные исходящего письма
            if (id_DocOut > 0)
            {
                sql = "SELECT DocsOutput.RN_DocOut,  DocsOutput.Date_DocOut,  Orgs.Name_Br, Orgs.ID_Org ";
                sql += " FROM DocsOutput INNER JOIN DocsOutputRec ON  DocsOutput.ID_DocOut =  DocsOutputRec.ID_DocOut INNER JOIN";
                sql += " Orgs ON  DocsOutputRec.ID_Org =  Orgs.ID_Org WHERE  DocsOutput.ID_DocOut = " + id_DocOut.ToString();
                var rs = SSPD.DB.GetFields(sql);
                if (rs != null && rs.Count > 0)
                {
                    h.Add("rn_DocOut", rs[0]["RN_DocOut"].ToString());
                    h.Add("date_DocOut", rs[0]["Date_DocOut"].ToString());
                    h.Add("org_DocOut", rs[0]["Name_Br"].ToString());
                    h.Add("contacts_DocOut", getContacts(rs[0]["ID_Org"].ToString()));
                }
                rs = null;
            }

            //данные входящего письма
            if (id_DocInp > 0)
            {
                sql = "Select RN_DocInp, Date_DocInp  FROM DocsInput WHERE ID_DocInp = " + id_DocInp.ToString();
                var rs = SSPD.DB.GetFields(sql);
                if (rs != null && rs.Count > 0)
                {
                    h.Add("rn_DocInp", rs[0]["RN_DocInp"].ToString());
                    h.Add("date_DocInp", rs[0]["Date_DocInp"].ToString());
                }
            }


            return h;
        }

        /// <summary>
        /// Создаем форму для вывода визуальной информации о выполнении экспорта
        /// </summary>
        /// <returns>Форма</returns>
        private Form initFormProgress()
        {
            Form frm = new Form();

            frm.Text = "Экспорт";
            frm.Size = new System.Drawing.Size(300, 50);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ControlBox = false;
            
            ProgressBar pb = new ProgressBar();
            pb.Name = "PB";
            pb.Dock = DockStyle.Fill;
            pb.Style = ProgressBarStyle.Continuous;

            frm.Controls.Add(pb);

            return frm;
        }

        /// <summary>
        /// Закрытие и уничтожение формы 
        /// </summary>
        /// <param name="frm">Форма</param>
        private void diposeFormProgress(Form frm)
        {
            frm.Close();
            frm.Dispose();
        }

        /// <summary>
        /// Запрос контактов по организации
        /// </summary>
        /// <param name="Org">ID организации</param>
        /// <returns>Строку контактов</returns>
        private string getContacts(string Org)
        {
            var rs = LocalDB.LoadData("SELECT Contacts FROM КонтрольТКП_Контакты WHERE ID_Org = " + Org);
            if (rs != null)
                if (rs.Count > 0) return rs[0]["Contacts"].ToString();
            return "";
        }
    }
}
