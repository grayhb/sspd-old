using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System;

namespace Контроль_запросов_ТКП
{
    class ReportTable
    {
        private struct DataTKP
        {
            public string ID_Zad;
            public string Type_Zad;
            public string ID_TKP;
            public string Equipment;    //наименование оборудования
            public string OlSh;         //опросный лист
            public string Orgs;         //наименование организации
            //public string ListRNDoc;    //список рег номеров документов
            public int CountDocOut;     //кол-во отправленных
            //public int CountDocInp;     //кол-во отправленных
            //public int CountDocTKP;     //кол-во полученных ТКП
            //List<string> RNDocInp = new List<string>();     //список Рег номеров полученных ТКП
            public List<string> list_RNDocInp ;     //список Рег номеров полученных ТКП
            public List<string> list_PathDocInp;   //список ссылок на файлы (ФТП) полученных ТКП
            public string NBOtdel;
        }

        string IDP;         //ID проекта
        string PrjName;     //Наименование проекта
        string PrjSh;       //Шифр проекта

        DataRowCollection drc_zad;  //ID_Zad задания выданные по проекту

        List<DataTKP> list_tkp;

        public ReportTable(string prj_id, string prj_name,string prj_sh)
        {
            IDP = prj_id;
            PrjName = prj_name;
            PrjSh = prj_sh;

            list_tkp = new List<DataTKP>();

            LoadZP();
        }

        /// <summary>
        /// Загрузка заданий выданных по проекту
        /// </summary>
        private void LoadZP()
        {
            string sql = "SELECT ID_Rec as ID_Zad, '0' as TypeZad FROM ExchandeZadReestr ";
            sql += string.Format(" WHERE Status = 1 AND ID_Project = {0} AND ID_OtdelInp = {1}", IDP, TKP_Conf.AdminIDOtdel);
            sql += " UNION ";
            sql += "SELECT ZadFromGIPReestr.ID_Rec as ID_Zad, '1' as TypeZad FROM ZadFromGIPReestr ";
            sql += " INNER JOIN ZadFromGIPReestrAdr ON ZadFromGIPReestrAdr.ID_RecZadGIP = ZadFromGIPReestr.ID_Rec";
            sql += string.Format(" WHERE ZadFromGIPReestr.ID_Project = {0} AND ZadFromGIPReestrAdr.ID_OtdelInp = {1}", IDP, TKP_Conf.AdminIDOtdel);
         
            drc_zad = SSPD.DB.GetFields(sql);
        }

        /// <summary>
        /// Загрузка данных карточек запросов ТКП
        /// </summary>
        private void LoadTKP(Form frmProgress)
        {
            if (drc_zad == null) return;

            frmProgress.Show();
            //прогресс бар
            ProgressBar PB = ((ProgressBar)frmProgress.Controls[0]);
            PB.Maximum = drc_zad.Count * 2;

            DataTKP dtkp;
            string sql;

            foreach (DataRow dr in drc_zad)
            {
                //загрузка карточек
                sql = "SELECT ID_TKP, Equipment, OlSh FROM КонтрольТКП";
                sql += string.Format(" WHERE ID_Zad = {0} AND TypeZad = {1}", dr["ID_Zad"].ToString(), dr["TypeZad"].ToString());

                DataRowCollection drc_tkp = LocalDB.LoadData(sql);

                foreach (DataRow dr_tkp in drc_tkp)
                {
                    dtkp = new DataTKP();

                    dtkp.ID_Zad = dr["ID_Zad"].ToString();
                    dtkp.Type_Zad = dr["TypeZad"].ToString();

                    dtkp.ID_TKP = dr_tkp["ID_TKP"].ToString();
                    dtkp.Equipment = dr_tkp["Equipment"].ToString();
                    dtkp.OlSh = dr_tkp["OlSh"].ToString();
                    
                    //загрузка данных по письмам
                    dtkp.list_RNDocInp = new List<string>();
                    dtkp.list_PathDocInp = new List<string>();
                    
                    getDataMail(ref dtkp);
                    getOtdel(ref dtkp);

                    list_tkp.Add(dtkp);
                }

                PB.Value++;
            }

        }

        /// <summary>
        /// Загрузка данных по запросам
        /// </summary>
        /// <param name="dtkp">Структура данных карточки ТКП</param>
        private void getDataMail(ref DataTKP dtkp)
        {
            string sql = "SELECT DISTINCT КонтрольТКП_Письма.ID_OutDoc, КонтрольТКП_Организации.Name_Br, КонтрольТКП_Организации.Name_Full, ";
            sql += " КонтрольТКП_Письма.ID_InpDoc, КонтрольТКП_Письма.StatusDoc";
            sql += " FROM КонтрольТКП_Письма INNER JOIN ";
            sql += " КонтрольТКП_Организации ON КонтрольТКП_Письма.ID_OrgOut = КонтрольТКП_Организации.ID_Org";
            sql += string.Format(" WHERE КонтрольТКП_Письма.ID_TKP = {0}", dtkp.ID_TKP);

            DataRowCollection drc = LocalDB.LoadData(sql);

            foreach (DataRow dr in drc)
            {
                ///есть запрос
                if (dr["ID_OutDoc"].ToString() != "")
                {
                    if (dtkp.Orgs == null || dtkp.Orgs.IndexOf(dr["Name_Br"].ToString()) == -1)
                    {
                        if (dtkp.Orgs != null) dtkp.Orgs += "\n";
                        dtkp.Orgs += dr["Name_Br"].ToString();
                        dtkp.CountDocOut++;

                        if (dr["ID_InpDoc"].ToString() != "")
                            dtkp.Orgs += " (v)";
                    }
                }

                ///есть ответ
                if (dr["ID_InpDoc"].ToString() != "")
                {
                    //статус ответа - положительный
                    if (dr["StatusDoc"].ToString() == "1")
                    {
                        getDocInp(ref dtkp, dr["ID_InpDoc"].ToString());
                    }
                    
                }

            }

        }

        /// <summary>
        /// Данные письма
        /// </summary>
        /// <param name="dtkp">Структура данных карточки ТКП</param>
        /// <param name="IDDocInp">ID входящего письма</param>
        private void getDocInp(ref DataTKP dtkp, string IDDocInp)
        {
            string sql = string.Format("SELECT RN_DocInp, PathToImage FROM DocsInput WHERE ID_DocInp = {0}", IDDocInp);
            DataRowCollection drc = SSPD.DB.GetFields(sql);
            if (drc.Count > 0)
            {
                dtkp.list_RNDocInp.Add(drc[0]["RN_DocInp"].ToString());
                dtkp.list_PathDocInp.Add(drc[0]["PathToImage"].ToString());
            }
        }


        /// <summary>
        /// Возвращает отдел выдавший задание
        /// </summary>
        /// <param name="dtkp"></param>
        private void getOtdel(ref DataTKP dtkp)
        {
            if (dtkp.Type_Zad == "1")
                dtkp.NBOtdel = "БГИП";
            else
            {
                string sql = "SELECT Otdels.NB_Otdel FROM ExchandeZadReestr INNER JOIN";
                sql += " Otdels ON Otdels.ID_Otdel = ExchandeZadReestr.ID_OtdelOut";
                sql += string.Format(" WHERE  ExchandeZadReestr.ID_Rec = {0}", dtkp.ID_Zad);

                DataRowCollection drc = SSPD.DB.GetFields(sql);
                if (drc != null)
                    dtkp.NBOtdel = drc[0]["NB_Otdel"].ToString();

                drc = null;
            }

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
        /// Конвертация символа переноса строки для Excel
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns></returns>
        private string convertReturnStr(string s)
        {
            
            if (s != null && s != "")
                return System.Text.RegularExpressions.Regex.Replace(s, "[" + ((char)13).ToString() + "]", ((char)10).ToString());
            else
                return s;
        }


        /// <summary>
        /// Вывод данных в Экзель
        /// </summary>
        /// <param name="TKP">Массив данных по ТКП</param>
        private void WriteInExcel(Form frmProgress)
        {
            if (drc_zad == null) return;

            //прогресс бар
            ProgressBar PB = ((ProgressBar)frmProgress.Controls[0]);

            PB.Maximum = PB.Maximum / 2 + list_tkp.Count;

            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet wbs = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            Excel.Range range = wbs.UsedRange;
            try
            {
                (range.Cells[1, 1] as Excel.Range).Value = "№ п/п";
                (range.Cells[1, 2] as Excel.Range).Value = "Наименование оборудования (материала)";
                (range.Cells[1, 3] as Excel.Range).Value = "Номер ЛСР";
                (range.Cells[1, 4] as Excel.Range).Value = "Номер пункта ЛСР";
                (range.Cells[1, 5] as Excel.Range).Value = "Кол-во";
                (range.Cells[1, 6] as Excel.Range).Value = "Сметная стоимость (за ед.) ТКП";
                (range.Cells[1, 7] as Excel.Range).Value = "Запрашиваемые организации";
                (range.Cells[1, 8] as Excel.Range).Value = "В реестре";
                (range.Cells[1, 9] as Excel.Range).Value = "Направлено запросов";
                (range.Cells[1, 10] as Excel.Range).Value = "Наличие ответа";
                (range.Cells[1, 11] as Excel.Range).Value = "Количество полученных ТКП";

                (range.Cells[1, 12] as Excel.Range).Value = "Стоимость, получения от организаций (за ед.)";
                (range.Cells[2, 12] as Excel.Range).Value = "Наименьшая (1.)";

                (range.Cells[2, 13] as Excel.Range).Value = "Средняя (2.)";
                (range.Cells[2, 14] as Excel.Range).Value = "Наибольшая (3.)";

                (range.Cells[1, 15] as Excel.Range).Value = "Принятая стоимость";


                (range.Cells[1, 16] as Excel.Range).Value = "Отдел";
                (range.Cells[1, 17] as Excel.Range).Value = "ОЛ";
                (range.Cells[1, 18] as Excel.Range).Value = "Задание";


                for (int i = 1; i <= 11; i++)
                    wbs.Range[wbs.Cells[1, i], wbs.Cells[2, i]].Merge();

                wbs.Range[wbs.Cells[1, 15], wbs.Cells[2, 15]].Merge();

                wbs.Range[wbs.Cells[1, 12], wbs.Cells[1, 14]].Merge();

                for (int i = 1; i <= 15; i++)
                    (range.Cells[3, i] as Excel.Range).Value = string.Format("'{0}", i);

                for (int i = 16; i <= 18; i++)
                    wbs.Range[wbs.Cells[1, i], wbs.Cells[2, i]].Merge();


                int rowout = 4;
                int numTKP = 0;

                foreach (DataTKP dtkp in list_tkp)
                {
                    numTKP++;
                    (range.Cells[rowout, 1] as Excel.Range).Value = numTKP.ToString();
                    (range.Cells[rowout, 2] as Excel.Range).Value = convertReturnStr(dtkp.Equipment);
                    (range.Cells[rowout, 7] as Excel.Range).Value = convertReturnStr(dtkp.Orgs);
                    (range.Cells[rowout, 9] as Excel.Range).Value = dtkp.CountDocOut.ToString();
                    //(range.Cells[rowout, 10] as Excel.Range).Value = dtkp.CountDocInp.ToString();
                    (range.Cells[rowout, 11] as Excel.Range).Value = dtkp.list_RNDocInp.Count.ToString();

                    (range.Cells[rowout, 16] as Excel.Range).Value = dtkp.NBOtdel;
                    (range.Cells[rowout, 17] as Excel.Range).Value = dtkp.OlSh;
                    (range.Cells[rowout, 18] as Excel.Range).Value = dtkp.ID_Zad;

                    if (dtkp.list_RNDocInp.Count > 0)
                    {
                        string s_out_rn = "";
                        foreach (string s_rn in dtkp.list_RNDocInp)
                        {
                            if (s_out_rn != "") s_out_rn += "\n";
                            s_out_rn += s_rn;
                        }

                        if (s_out_rn != "")
                            (range.Cells[rowout, 10] as Excel.Range).Value = convertReturnStr(s_out_rn);
                    }


                    rowout++;
                    PB.Value++;
                }

                //ширина столбцов
                WriteInExcelResizeColumn(range);

                //форматирование общее
                WriteInExcelSetBodyFormat(wbs, rowout--, 18);


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
                app.ActiveWindow.SplitRow = 3;
                app.ActiveWindow.FreezePanes = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка выполнения экспорта в Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.WriteLine(ex);
            }

            app.Visible = true;
        }



        private void WriteInExcelSetBodyFormat(Excel.Worksheet wbs, int rowout, int CountCol)
        {
            //int CountCol = 19;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Font.Name = "Franklin Gothic Book";
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Font.Size = 8;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].WrapText = true;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //шапка
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[3, CountCol]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            //нумерация столбцов
            wbs.Range[wbs.Cells[3, 1], wbs.Cells[3, CountCol]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            wbs.Range[wbs.Cells[3, 1], wbs.Cells[3, CountCol]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            rowout--;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideVertical].LineStyle = 1;
            
            //форматирование столбцов
            wbs.Range[wbs.Cells[4, 2], wbs.Cells[rowout, 2]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        }


        private void WriteInExcelResizeColumn(Excel.Range range)
        {
            (range.Columns[1] as Excel.Range).ColumnWidth = 5;
            (range.Columns[2] as Excel.Range).ColumnWidth = 35;
            (range.Columns[3] as Excel.Range).ColumnWidth = 8;
            (range.Columns[4] as Excel.Range).ColumnWidth = 8;
            (range.Columns[5] as Excel.Range).ColumnWidth = 8;
            (range.Columns[6] as Excel.Range).ColumnWidth = 10;
            (range.Columns[7] as Excel.Range).ColumnWidth = 20;
            (range.Columns[8] as Excel.Range).ColumnWidth = 9;
            (range.Columns[9] as Excel.Range).ColumnWidth = 10;
            (range.Columns[10] as Excel.Range).ColumnWidth = 9;
            (range.Columns[11] as Excel.Range).ColumnWidth = 10;

            (range.Columns[12] as Excel.Range).ColumnWidth = 12;
            (range.Columns[13] as Excel.Range).ColumnWidth = 12;
            (range.Columns[14] as Excel.Range).ColumnWidth = 12;

            (range.Columns[15] as Excel.Range).ColumnWidth = 10;

            (range.Columns[16] as Excel.Range).ColumnWidth = 10;
            (range.Columns[17] as Excel.Range).ColumnWidth = 10;
            (range.Columns[18] as Excel.Range).ColumnWidth = 10;


            (range.Rows[1] as Excel.Range).RowHeight = 22;
            (range.Rows[2] as Excel.Range).RowHeight = 22;
        }


        /// <summary>
        /// Экспорт отчета
        /// </summary>
        public void ExportReportTable()
        {
            Form frm = initFormProgress();

            LoadTKP(frm);
            WriteInExcel(frm);
            diposeFormProgress(frm);

        }

    }
}
