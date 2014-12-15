using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSPD;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Контроль_запросов_ТКП
{
    public partial class ReportForOST : Form
    {
        
        object DateFrom;
        object DateTo;
        string OSTFullName;

        public ReportForOST()
        {
            InitializeComponent();
        }

        private void ReportForOST_Load(object sender, EventArgs e)
        {
            DateFrom = null;
            DateFrom = null;

            OST.Tag = null;
            Period.Tag = null;
            OSTFullName = null;

            //по умолчанию папка - мои документы
            if (Properties.Settings.Default.ReportSaveDoc.Length == 0)
                textPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                textPath.Text = Properties.Settings.Default.ReportSaveDoc;

            //выбранная организация
            if (Properties.Settings.Default.ReportNameOrg.Length != 0)
            {
                OST.Text = Properties.Settings.Default.ReportNameOrg;
                OST.Tag = Properties.Settings.Default.ReportIDOrg;
                OSTFullName = Properties.Settings.Default.ReportFullNameOrg;
            }

            //период
            if (Properties.Settings.Default.ReportDateFrom.ToString() != "")
            {
                DateFrom = Convert.ToDateTime(Properties.Settings.Default.ReportDateFrom);
                DateTo = Convert.ToDateTime(Properties.Settings.Default.ReportDateTo);
                Period.Text = string.Format("с {0} по {1}", 
                                ((DateTime)DateFrom).ToShortDateString(),
                                ((DateTime)DateTo).ToShortDateString());
                Period.Tag = 1;
            }


            //Проект
            if (Properties.Settings.Default.ReportIDP.Length != 0)
            {
                PrjSh.Text = Properties.Settings.Default.ReportPrjSh;
                PrjSh.Tag = Properties.Settings.Default.ReportIDP;
                cmdSelProject.Text = "X";
            }

            textPath.Enabled = false;
            cmdSelPath.Enabled = false;

        }

        
        private void cmdSelOrg_Click(object sender, EventArgs e)
        {
            SelectForm.ListOrg LO = new SelectForm.ListOrg();
            LO.ShowDialog();
            if (LO.SelIDOrg != "")
            {
                OST.Tag = LO.SelIDOrg;
                OST.Text = LO.SelNameOrg;
                OSTFullName = LO.SelFullNameOrg;

                Properties.Settings.Default.ReportIDOrg = LO.SelIDOrg;
                Properties.Settings.Default.ReportNameOrg = LO.SelNameOrg;
                Properties.Settings.Default.ReportFullNameOrg = LO.SelFullNameOrg;
                Properties.Settings.Default.Save();
            }
        }


        private void cmdSelPeriod_Click(object sender, EventArgs e)
        {
            SelectForm.SelectPeriod SP = new SelectForm.SelectPeriod();

            if (DateFrom != null)
            {
                SP.D1 = ((DateTime)DateFrom);
                SP.D2 = ((DateTime)DateTo);
            }

            SP.ShowDialog();
            if (SP.flSel)
            {
                DateFrom = SP.D1;
                DateTo = SP.D2;
                Period.Text = string.Format("с {0} по {1}", ((DateTime)DateFrom).ToShortDateString(), 
                    ((DateTime)DateTo).ToShortDateString());
                Period.Tag = 1;

                Properties.Settings.Default.ReportDateFrom = ((DateTime)DateFrom).ToShortDateString();
                Properties.Settings.Default.ReportDateTo = ((DateTime)DateTo).ToShortDateString();
                Properties.Settings.Default.Save();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSelPath_Click(object sender, EventArgs e)
        {
            DialogResult result = fBDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textPath.Text = fBDialog.SelectedPath;

                Properties.Settings.Default.ReportSaveDoc = fBDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            LoadDocOut();
        }


        private void LoadDocOut()
        {
            if (OST.Tag == null) return;
            if (Period.Tag == null) return;
            if (flExpDoc.Checked && textPath.Text == "") return;

            //перечень всех отправленных писем за период
            string sql;
            sql = "SELECT DocsOutput.ID_DocOut, DocsOutput.RN_DocOut, DocsOutput.Date_DocOut, DocsOutput.Note_DocOut, ";
            sql += " DocsOutput.PathToImage";
            sql += " FROM DocsOutput INNER JOIN";
            sql += " Workers ON DocsOutput.ID_Worker = Workers.ID_Worker";
            sql += string.Format(" WHERE (dbo.MainOtdel(Workers.ID_Otdel) = {0}) ", TKP_Conf.AdminIDOtdel);
            sql += string.Format(" AND (DocsOutput.Date_DocOut >= CONVERT(DATETIME, '{0} 00:00:00', 102)) ", UI.GetDate(DateFrom.ToString()));
            sql += string.Format(" AND (DocsOutput.Date_DocOut <= CONVERT(DATETIME, '{0} 00:00:00', 102))", UI.GetDate(DateTo.ToString()));
            sql += " ORDER BY DocsOutput.ID_DocOut";

            //Clipboard.Clear();
            //Clipboard.SetText(sql);

            DataRowCollection draAllDocOut = DB.GetFields(sql);

            //перечень всех исходящих писем на контроле в работе
            sql = "SELECT  КонтрольТКП_Письма.ID_OutDoc, КонтрольТКП.Equipment, КонтрольТКП_Организации.Name_Full, ";
            sql += " КонтрольТКП.ID_Zad, КонтрольТКП_Организации.ID_Org";
            sql += " FROM (КонтрольТКП_Письма INNER JOIN КонтрольТКП ON КонтрольТКП_Письма.ID_TKP = КонтрольТКП.ID_TKP) INNER JOIN ";
            sql += " КонтрольТКП_Организации ON КонтрольТКП_Письма.ID_OrgOut = КонтрольТКП_Организации.ID_Org";
            sql += " WHERE (КонтрольТКП_Письма.ID_InpDoc Is Null OR КонтрольТКП_Письма.ID_InpDoc = -1) AND КонтрольТКП_Письма.StatusDoc Is Null ";
            sql += " AND КонтрольТКП.Status <= 0 ";
            sql += " ORDER BY КонтрольТКП_Письма.ID_OutDoc";

            DataRowCollection draAllDocOutTKP = LocalDB.LoadData(sql);
            Clipboard.Clear();
            Clipboard.SetText(sql);


            //перечень проектов по указанной организации
            sql = "SELECT ExchandeZadReestr.ID_Rec, Projects.ID_Project, Projects.Sh_project, Projects.Name_Project, Projects.ID_Zak";
            sql += " FROM ExchandeZadReestr INNER JOIN";
            sql += " Projects ON ExchandeZadReestr.ID_Project = Projects.ID_Project";
            sql += string.Format(" WHERE (ExchandeZadReestr.ID_OtdelInp = {0})", TKP_Conf.AdminIDOtdel);
            sql += string.Format(" AND (Projects.ID_Zak = {0})", OST.Tag);

            DataRowCollection draZadProjects = DB.GetFields(sql);


            //перечень писем не имеющих ответа и в работе
            List<Hashtable> ListExpDocs = new List<Hashtable>();
            List<Hashtable> ListExpPrj = new List<Hashtable>();

            foreach(DataRow dr in draAllDocOut)
            {

                //возвращать список если было несколько видов оборудования
                DataRow drDocTKP = getDataRowDocTKP(dr["ID_DocOut"].ToString(), draAllDocOutTKP);

                //ищем письмо
                if (drDocTKP != null)
                {

                    //ищем проект
                    DataRow drPrjTKP = getDataProject(drDocTKP["ID_Zad"].ToString(), draZadProjects);

                    if (drPrjTKP != null)
                    {
                        if (checkPrjInList(drPrjTKP["ID_Project"].ToString(), ListExpPrj))
                        {
                            Hashtable HashPrj = new Hashtable();
                            HashPrj.Add("Sh_project", drPrjTKP["Sh_project"].ToString());
                            HashPrj.Add("Name_Project", drPrjTKP["Name_Project"].ToString());
                            HashPrj.Add("ID_Project", drPrjTKP["ID_Project"].ToString());
                            ListExpPrj.Add(HashPrj);
                        }


                        Hashtable HashDoc = new Hashtable();

                        HashDoc.Add("RN_DocOut", dr["RN_DocOut"].ToString());
                        HashDoc.Add("Date_DocOut", dr["Date_DocOut"].ToString());
                        HashDoc.Add("Note_DocOut", dr["Note_DocOut"].ToString());
                        HashDoc.Add("PathToImage", dr["PathToImage"].ToString());

                        HashDoc.Add("Equipment", drDocTKP["Equipment"].ToString());
                        HashDoc.Add("Org_Name_Full", drDocTKP["Name_Full"].ToString());

                        HashDoc.Add("Sh_project", drPrjTKP["Sh_project"].ToString());
                        HashDoc.Add("Name_Project", drPrjTKP["Name_Project"].ToString());
                        HashDoc.Add("ID_Project", drPrjTKP["ID_Project"].ToString());
                        

                        ListExpDocs.Add(HashDoc);
                    }
                }
            }

            //экспорт куда-нибудь

            Form frm = initFormProgress();
            WriteInExcel(ListExpDocs, ListExpPrj, frm);

            frm.Close();
            frm.Dispose();
            


            ///очистка мусора
            frm = null;
            draAllDocOut = null;
            draAllDocOutTKP = null;
            draZadProjects = null;
            ListExpDocs = null;
            ListExpPrj = null;
        }


        /// <summary>
        /// Функция проверки наличия проекта в списке уникальных проектов
        /// </summary>
        /// <param name="IDP">ID проекта</param>
        /// <param name="ListPrj">Лист проектов</param>
        /// <returns>true - нет в списке, false - уже в списке</returns>
        private bool checkPrjInList(string IDP, List<Hashtable> ListPrj)
        {
            foreach (Hashtable h in ListPrj)
                if (IDP == h["ID_Project"].ToString())
                    return false;
            return true;
        }


        /// <summary>
        /// Функция поиска задания и возврата проекта
        /// </summary>
        /// <param name="IDZad">Номер задания</param>
        /// <param name="dra">коллекция заданий с данными проекта</param>
        /// <returns>строка задания</returns>
        private DataRow getDataProject(string IDZad, DataRowCollection dra)
        {
            foreach (DataRow dr in dra)
                if (IDZad == dr["ID_Rec"].ToString())
                    return dr;
            return null;
        }


        /// <summary>
        /// Функция возврата строки по письму
        /// </summary>
        /// <param name="IDDocOut">ID письма</param>
        /// <param name="dra">коллекция строк из контроля ткп</param>
        /// <returns>строка письма</returns>
        private DataRow getDataRowDocTKP(string IDDocOut, DataRowCollection dra)
        {
            if (IDDocOut == "85675")
                Console.WriteLine("HERE");

            DataRow dr_ret = null;

            foreach (DataRow dr in dra)
            {
                if (IDDocOut == dr["ID_OutDoc"].ToString())
                {
                    if (dr_ret == null)
                        dr_ret = dr;
                    else
                    {
                        dr_ret["Equipment"] += string.Format("\n{0}", dr["Equipment"]);
                    }


                }
            }
            return dr_ret;
        }

        /// <summary>
        /// Вывод данных в Экзель
        /// </summary>
        /// <param name="ListDoc">Массив данных</param>
        private void WriteInExcel(List<Hashtable> ListDoc, List<Hashtable> ListPrj, Form frmProgress)
        {
            //прогресс бар
            ProgressBar PB = ((ProgressBar)frmProgress.Controls[0]);
            PB.Maximum = ListPrj.Count;
            frmProgress.Show();

            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet wbs = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            wb.Sheets[2].Delete();
            wb.Sheets[2].Delete();

            Excel.Range range = wbs.UsedRange;

            try
            {
                this.WriteInExcelResizeColumn(range);

                int rowout = 1;
                (range.Cells[rowout, 1] as Excel.Range).Value = string.Format("Запросы ТКП оставшиеся без ответа за период {0} по проектам {1}", 
                                                                Period.Text,
                                                                OSTFullName);

                
                range.Range[range.Cells[rowout, 1], range.Cells[rowout, 5]].Merge();
                range.Range[range.Cells[rowout, 1], range.Cells[rowout, 5]].RowHeight = 20;

                rowout = 2;
                (range.Cells[rowout, 1] as Excel.Range).Value = "Проект";
                (range.Cells[rowout, 2] as Excel.Range).Value = "Оборудования";
                (range.Cells[rowout, 3] as Excel.Range).Value = "Организация";
                (range.Cells[rowout, 4] as Excel.Range).Value = "№ исх.";
                (range.Cells[rowout, 5] as Excel.Range).Value = "Дата";

                rowout++;
                //int doc_rowout = 0;
                //int numTKP = 0;
                

                foreach (Hashtable prjOut in ListPrj)
                {
                    bool flWrite = true;

                    if (PrjSh.Text != "")
                        if (PrjSh.Tag.ToString() != prjOut["ID_Project"].ToString())
                            flWrite = false;

                    if (flWrite)
                    {
                        WriteInExcelSetFormatTKP(wbs, rowout);
                        rowout = WriteInExcelOnPrj(range, rowout, prjOut["ID_Project"].ToString(), ListDoc);
                    }

                    PB.Value++;
                }


                
                this.WriteInExcelSetBodyFormat(wbs, rowout);


                //настройки предварительного просмотра
                wbs.PageSetup.LeftMargin = 20;
                wbs.PageSetup.RightMargin = 20;
                wbs.PageSetup.TopMargin = 20;
                wbs.PageSetup.BottomMargin = 35;
                wbs.PageSetup.Zoom = false;
                wbs.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                wbs.PageSetup.FitToPagesTall = false;
                wbs.PageSetup.FitToPagesWide = 1;
                wbs.PageSetup.CenterHorizontally = true;
                wbs.PageSetup.PrintTitleRows = "$2:$2";
                wbs.PageSetup.RightFooter = "&8&P из &N";

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


        private int WriteInExcelOnPrj(Excel.Range range, int rowout, string IDPrj, List<Hashtable> ListDoc)
        {
            int cnt_rowout = 0;
            
            foreach (Hashtable Doc in ListDoc)
                if (Doc["ID_Project"].ToString() == IDPrj)
                {
                    //HashDoc.Add("RN_DocOut", dr["RN_DocOut"].ToString());
                    //HashDoc.Add("Date_DocOut", dr["Date_DocOut"].ToString());
                    //HashDoc.Add("Note_DocOut", dr["Note_DocOut"].ToString());
                    //HashDoc.Add("PathToImage", dr["PathToImage"].ToString());

                    //HashDoc.Add("Equipment", drDocTKP["Equipment"].ToString());
                    //HashDoc.Add("Org_Name_Full", drDocTKP["Name_Full"].ToString());

                    //HashDoc.Add("Sh_project", drPrjTKP["Sh_project"].ToString());
                    //HashDoc.Add("Name_Project", drPrjTKP["Name_Project"].ToString());
                    //HashDoc.Add("ID_Project", drPrjTKP["ID_Project"].ToString());

                    if (cnt_rowout == 0)
                    {
                        string prjName = string.Format("{0}\n{1}", Doc["Sh_project"], Doc["Name_Project"]);
                        (range.Cells[rowout, 1] as Excel.Range).Value = prjName;
                    }

                    (range.Cells[rowout, 2] as Excel.Range).Value = Doc["Equipment"].ToString();
                    (range.Cells[rowout, 3] as Excel.Range).Value = Doc["Org_Name_Full"].ToString();
                    (range.Cells[rowout, 4] as Excel.Range).Value = Doc["RN_DocOut"].ToString();

                    (range.Cells[rowout, 5] as Excel.Range).NumberFormat = "m/d/yyyy"; 
                    (range.Cells[rowout, 5] as Excel.Range).Value = UI.GetDate(Doc["Date_DocOut"].ToString());

                    if (flExpDoc.Checked == true)
                    {

                        string FNameOut = textPath.Text + @"\";

                        FNameOut += ConvertFileName(string.Format("{0}_{1}_{2}.pdf", Doc["RN_DocOut"],
                            UI.GetDate(Doc["Date_DocOut"].ToString()),
                            Doc["Note_DocOut"]));

                        FTP.DonwloadFile(
                            Doc["PathToImage"].ToString(), "", FNameOut, false);
                    }

                    cnt_rowout++;
                    rowout++;
                }

            if (cnt_rowout > 1)
            {
                //объединить строки проекта
                //Excel.Range prjRange = range.ce
                    //Excel.Range(range.Cells(rowout - cnt_rowout, 1), range.Cells(rowout, 1));
                range.Range[range.Cells[rowout - cnt_rowout, 1], range.Cells[rowout-1, 1]].Merge();

                //eWSheet.Range[eWSheet.Cells[1, 1], eWSheet.Cells[4, 1]].Merge();

            }
            return rowout;
        }

        private void WriteInExcelSetFormatTKP(Excel.Worksheet wbs, int rowout)
        {
            int CountCol = 5;
            //верхняя жирная линия
            rowout++;
            (wbs.Range[wbs.Cells[rowout, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            (wbs.Range[wbs.Cells[rowout, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            (wbs.Range[wbs.Cells[rowout, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlMedium;
            (wbs.Range[wbs.Cells[rowout, 1], wbs.Cells[rowout, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;

        }

        private void WriteInExcelSetBodyFormat(Excel.Worksheet wbs, int rowout)
        {
            int CountCol = 5;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Font.Name = "Franklin Gothic Book";
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].Font.Size = 8;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].WrapText = true;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout, CountCol]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            //шапка
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[2, CountCol]].Font.Bold = true;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[2, CountCol]].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            wbs.Range[wbs.Cells[1, 1], wbs.Cells[2, CountCol]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            (wbs.Range[wbs.Cells[2, 1], wbs.Cells[3, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            (wbs.Range[wbs.Cells[2, 1], wbs.Cells[3, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            (wbs.Range[wbs.Cells[2, 1], wbs.Cells[3, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlMedium;
            (wbs.Range[wbs.Cells[2, 1], wbs.Cells[3, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
            //сетка
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[rowout - 1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideVertical].LineStyle = 1;

            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideVertical].LineStyle = 1;
            (wbs.Range[wbs.Cells[1, 1], wbs.Cells[1, CountCol]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;


        }

        private void WriteInExcelResizeColumn(Excel.Range range)
        {
            (range.Columns[1] as Excel.Range).ColumnWidth = 70;
            (range.Columns[2] as Excel.Range).ColumnWidth = 25;
            (range.Columns[3] as Excel.Range).ColumnWidth = 28;
            (range.Columns[4] as Excel.Range).ColumnWidth = 11;
            (range.Columns[5] as Excel.Range).ColumnWidth = 12;
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
        /// Конвертация символов
        /// </summary>
        /// <param name="FName">Наименование папки</param>
        private string ConvertFileName(string FName)
        {
            FName = FName.Replace("/", "_");
            FName = FName.Replace(@"\", "_");

            return FName;
        }



        private void flExpDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (flExpDoc.Checked)
            {
                textPath.Enabled = true;
                cmdSelPath.Enabled = true;
            }
            else
            {
                textPath.Enabled = false;
                cmdSelPath.Enabled = false;
            }
        }

        private void cmdSelProject_Click(object sender, EventArgs e)
        {
            if (cmdSelProject.Text == "X")
            {
                PrjSh.Text = "";
                PrjSh.Tag = null;
                cmdSelProject.Text = "...";

                Properties.Settings.Default.ReportIDP = "";
                Properties.Settings.Default.ReportPrjSh = "";
                Properties.Settings.Default.Save();
            }
            else
            {
                SelectForm.ListProject LP = new SelectForm.ListProject();
                LP.ShowDialog();
                if (LP.SelID != "")
                {
                    PrjSh.Text = LP.SelShPrj;
                    PrjSh.Tag = LP.SelID;
                    cmdSelProject.Text = "X";

                    Properties.Settings.Default.ReportIDP = LP.SelID;
                    Properties.Settings.Default.ReportPrjSh = LP.SelShPrj;


                    string sql = "SELECT Orgs.ID_Org, Orgs.Name_Br, Orgs.Name ";
                    sql += "FROM Orgs INNER JOIN Projects ON Projects.ID_Zak = Orgs.ID_Org ";
                    sql += string.Format(" WHERE Projects.ID_Project = {0}", LP.SelID);

                    DataRowCollection draOrgs = DB.GetFields(sql);
                    if (draOrgs.Count > 0)
                    {
                        OST.Tag = draOrgs[0]["ID_Org"].ToString();
                        OST.Text = draOrgs[0]["Name_Br"].ToString();
                        OSTFullName = draOrgs[0]["Name"].ToString();

                        Properties.Settings.Default.ReportIDOrg = OST.Tag.ToString();
                        Properties.Settings.Default.ReportNameOrg = OST.Text;
                        Properties.Settings.Default.ReportFullNameOrg = OSTFullName;
                    }

                    Properties.Settings.Default.Save();
                }
                LP.Dispose();
            }
        }



    }
}
