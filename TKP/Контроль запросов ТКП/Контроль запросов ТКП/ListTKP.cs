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
using System.IO;

namespace Контроль_запросов_ТКП
{
    public partial class ListTKP : Form
    {
        #region [Переменные]

        /// Коллекция строк записей ТКП
        DataRowCollection dra = null;
        // Данные из ССПД:
        DataRowCollection draZP = null;
        DataRowCollection draZPGIP = null;

        //bool flPOtdel; // флаг производственного отдела
        bool flAdmin;   //флаг привелегий администратора

        #endregion

        public ListTKP()
        {
            InitializeComponent();

            TKP_Log.add("Login", "Workers", Params.UserInfo.ID_Worker);

            InitForm();
        }

        private void InitForm()
        {

            //размер окна:
            //this.Width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width / 1.1);
            //this.Height = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height / 1.1);

            //17 дюймов:
            this.Width = 1380;
            this.Height = 1024;

            this.Text = string.Format("Контроль запросов ТКП ({0})", Params.UserInfo.FIO);

            ФОтсутствует.Checked = false;
            ФСтатусВсе.Checked = false;
            ФСтатусВработе.Checked = true;

            //проверка привелегий
            if (Params.UserInfo.ID_Otdel != TKP_Conf.AdminIDOtdel && !flAdmin)
            {
                МенюЗадания.Visible = false;
                реестрМТР.Visible = false;
                МенюАдмин.Visible = false;
                //МенюЭкспортТКП
            }
            else
                flAdmin = true;

            //если обычный отдел
            if (Params.UserInfo.ID_Otdel != TKP_Conf.SMIDOtdel &&
                Params.UserInfo.ID_Otdel != TKP_Conf.AdminIDOtdel &&
                Params.UserInfo.ID_Otdel != TKP_Conf.BGIPIDOtdel &&
                Params.UserInfo.ID_Otdel != TKP_Conf.RukIDOtdel)
            {
                //flPOtdel = true;

                МенюЭкспортДокументов.Visible = false;

                if (checkExchangeZad(Params.UserInfo.ID_MOtdel, "ID_OtdelOut"))
                {
                    //показывать запросы только отдела - ставим фильтр по отделу
                    ФОтдел.Tag = Params.UserInfo.NBMOtdel;
                    ФОтдел.Text = "Отдел - " + Params.UserInfo.NBMOtdel;
                    ФОтдел.Checked = true;
                    ФОтделВсе.Checked = false;

                    //если не начальник отдела - показываем только задания автора
                    if (Params.UserInfo.ID_Post != TKP_Conf.IDPostHeadOtdel && checkExchangeZad(Params.UserInfo.ID_Worker, "ID_WorkerOut"))
                    {
                        //показывать только запросы автора
                        ФАвтор.Text = "Автор - " + Params.UserInfo.FIO;
                        ФАвтор.Tag = Params.UserInfo.ID_Worker;
                        ФАвтор.Checked = true;
                        ФАвторВсе.Checked = false;
                    }
                }
            }

            //Если ГИП
            if (Params.UserInfo.ID_Post == TKP_Conf.GIPIDPost)
            {
                ФГИП.Tag = Params.UserInfo.FIO;
                ФГИП.Text = "ГИП - " + Params.UserInfo.FIO;
                ФГИП.Checked = true;
                ФГИПВсе.Checked = false;
            }

            //индивидуальная настройка фильтра для сотрудников
            if (Params.UserInfo.ID_Worker == "5196")  //Постников - задания за последние два месяца
            {
                List<DateTime> FDateZad = new List<DateTime>();
                FDateZad.Add(DateTime.Now.AddMonths(-2));
                FDateZad.Add(DateTime.Now);
                ФДатаВыдачиЗаданияПериод.Tag = FDateZad;
                ФДатаВыдачиЗаданияПериод.Text = string.Format("c {0} по {1}", UI.GetDate(FDateZad[0].ToString()), UI.GetDate(FDateZad[1].ToString()));
                ФДатаВыдачиЗаданияПериод.Checked = true;
                ФДатаВыдачиЗаданияВсе.Checked = false;
            }
            else if (Params.UserInfo.ID_Worker == "6774")  //Шадров - задания за последний месяц
            {
                List<DateTime> FDateZad = new List<DateTime>();
                FDateZad.Add(DateTime.Now.AddMonths(-1));
                FDateZad.Add(DateTime.Now);
                ФДатаВыдачиЗаданияПериод.Tag = FDateZad;
                ФДатаВыдачиЗаданияПериод.Text = string.Format("c {0} по {1}", UI.GetDate(FDateZad[0].ToString()), UI.GetDate(FDateZad[1].ToString()));
                ФДатаВыдачиЗаданияПериод.Checked = true;
                ФДатаВыдачиЗаданияВсе.Checked = false;
            }
        }

        private void ListTKP_Load(object sender, EventArgs e)
        {

        }

        private void ListTKP_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();           
            GetListTKP();
        }



        #region [Работа с данными]

        /// <summary>
        /// Формирование списка ТКП
        /// </summary>
        private void GetListTKP()
        {
            LoadListTKP();

            Cursor.Current = Cursors.WaitCursor;

            DGV.Visible = false;
            DGV.Rows.Clear();

            if (dra != null && dra.Count > 0)
            {
                UI.ProcessPB(PB, 1, dra.Count);
                foreach (DataRow dr in dra)
                {
                    DataRow drSSPD = GetDataZP(Convert.ToByte(dr["TypeZad"]), dr["ID_Zad"].ToString());

                    if (drSSPD != null)
                    {
                        if (CheckFilter(dr, drSSPD)) // фильтр
                        {
                            DGV.Rows.Add();
                            DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                            SetDataInRow(DGVR, dr, drSSPD);

                        }
                    }
                    UI.ProcessPB(PB, 2);
                }
                UI.SetBgRowInDGV(DGV);
                UI.ProcessPB(PB, 0);
                CountRowLabel.Text = "Найдено записей: " + DGV.Rows.Count;

                getLabelFilter();

            }

            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGV.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Заполняем строку (DataGridViewRow) данными
        /// </summary>
        /// <param name="DGVR">Строка из DGV</param>
        /// <param name="drZad">Данные по ТКП</param>
        /// <param name="drSSPD">Данные по заданию</param>
        private void SetDataInRow(DataGridViewRow DGVR, DataRow drZad, DataRow drSSPD)
        {
            DGVR.Cells["NZ"].Value = string.Format("{0:000000}", drZad["ID_Zad"]);

            if (drZad["OlSh"].ToString() == "")
                DGVR.Cells["ShOl"].Value = drSSPD["Sh_project"].ToString();
            else
                DGVR.Cells["ShOl"].Value = drZad["OlSh"].ToString();

            DGVR.Cells["Equip"].Value = drZad["Equipment"].ToString();
            DGVR.Cells["GIP"].Value = drSSPD["GIP"].ToString();
            DGVR.Cells["NamePrj"].Value = drSSPD["Name_Project"].ToString();
            DGVR.Cells["OtdelZad"].Value = drSSPD["NB_Otdel"].ToString();

            if (drSSPD["DT_Out"].ToString() != "")
                DGVR.Cells["DateZad"].Value = UI.GetDate(drSSPD["DT_Out"].ToString(),1);

            if (drSSPD["DateExpPlan"].ToString() != "")
                DGVR.Cells["DatePrj"].Value = UI.GetDate(drSSPD["DateExpPlan"].ToString());

            //DGVR.Cells["Status"].Value = GetStatus(drZad["Status"].ToString(),
            //                                       drZad["CntOutDoc"].ToString(),
            //                                       drZad["CntInpDoc"].ToString());
            DGVR.Cells["DateFinish"].Value = GetStatus(drZad["Status"].ToString());

            if (drZad["DateEnd"].ToString() != "")
                DGVR.Cells["DateFinish"].Value += "\n" + UI.GetDate(drZad["DateEnd"].ToString());

            setCountStatus(DGVR.Cells["Status"],
                Convert.ToInt32(drZad["CntOutDoc"]),
                Convert.ToInt32(drZad["CntInpDoc"]),
                Convert.ToInt32(drZad["CntCancelDoc"]),
                Convert.ToInt32(drZad["CntTrueDoc"]),
                Convert.ToInt32(drZad["CntRecDoc"])
                );

            Hashtable Detail = new Hashtable();
            Detail.Add("ID_TKP", drZad["ID_TKP"].ToString());
            Detail.Add("FPath", drSSPD["PathFiles"].ToString());
            Detail.Add("PathFilesPril", drSSPD["PathFilesPril"].ToString());
            Detail.Add("Sh_project", drSSPD["Sh_project"].ToString());
            Detail.Add("ID_Otdel", drSSPD["Sh_project"].ToString());

            if (drZad["DateOut"].ToString() != "")
                DGVR.Cells["DateOut"].Value = UI.GetDate(drZad["DateOut"].ToString());
            else
                if (drSSPD["DatePZakPlan"].ToString() != "")
                {
                    drZad["DateOut"] = drSSPD["DatePZakPlan"];
                    DGVR.Cells["DateOut"].Value = UI.GetDate(drSSPD["DatePZakPlan"].ToString());
                    DGVR.Cells["DateOut"].Tag = DGVR.Cells["DateOut"].Value;
                }


            DGVR.Tag = Detail;

            //выставляем цветовой статус
            //if (drZad["Status"].ToString() == "0")
            //    GetColorStatusDate(DGVR.Cells[0], drSSPD["DT_Out"].ToString(), drZad["DateOut"].ToString());

            ////красим статус если ткп используется в сметах
            if (drZad["CntUseTKP"].ToString() != "0")
                SetStatusUseTKP(DGVR);

            if (drSSPD["Status"].ToString() != "")
                setColorPIRStatus(DGVR.Cells[0], Convert.ToInt32(drSSPD["Status"]));

        }

        /// <summary>
        /// Загрузка данных по ТКП
        /// </summary>
        private void LoadListTKP()
        {
            Cursor.Current = Cursors.WaitCursor;

            string SqlStr = "";
            SqlStr = "SELECT  КонтрольТКП.ID_TKP, КонтрольТКП.ID_Zad, КонтрольТКП.TypeZad, КонтрольТКП.Status, КонтрольТКП.DateStart, КонтрольТКП.DateEnd, КонтрольТКП.Equipment, КонтрольТКП.OlSh, ";
            SqlStr += " (SELECT Count(ID_TKP) AS Cnt FROM КонтрольТКП_Письма WHERE КонтрольТКП_Письма.ID_TKP = КонтрольТКП.ID_TKP AND КонтрольТКП_Письма.ID_OutDoc Is Not Null) as CntOutDoc,";
            SqlStr += " (SELECT Count(ID_TKP) AS Cnt FROM КонтрольТКП_Письма WHERE КонтрольТКП_Письма.ID_TKP = КонтрольТКП.ID_TKP AND КонтрольТКП_Письма.ID_InpDoc Is Not Null) as CntInpDoc,";
            SqlStr += " (SELECT Count(ID_TKP) AS Cnt FROM КонтрольТКП_Письма WHERE КонтрольТКП_Письма.ID_TKP = КонтрольТКП.ID_TKP AND КонтрольТКП_Письма.StatusDoc = 0) as CntCancelDoc,";
            SqlStr += " (SELECT Count(ID_TKP) AS Cnt FROM КонтрольТКП_Письма WHERE КонтрольТКП_Письма.ID_TKP = КонтрольТКП.ID_TKP AND КонтрольТКП_Письма.StatusDoc = 1) as CntTrueDoc,";
            SqlStr += " (SELECT Count(ID_TKP) AS Cnt FROM КонтрольТКП_Письма WHERE КонтрольТКП_Письма.ID_TKP = КонтрольТКП.ID_TKP AND КонтрольТКП_Письма.StatusDoc = 2) as CntRecDoc,";
            SqlStr += " (SELECT Count(ID_TKP) AS Cnt FROM КонтрольТКП_Письма WHERE КонтрольТКП_Письма.ID_TKP = КонтрольТКП.ID_TKP AND КонтрольТКП_Письма.UseTKP = 1) as CntUseTKP,";
            SqlStr += " ГруппыМТР.Code, КонтрольТКП.DateOut ";
            SqlStr += " FROM КонтрольТКП LEFT OUTER JOIN ГруппыМТР ON ГруппыМТР.ID_Rec = КонтрольТКП.ID_MTR";
            SqlStr += " ORDER BY КонтрольТКП.ID_TKP DESC";

            dra = LocalDB.LoadData(SqlStr);
           
            draZP = LoadDataSSPD(0);
            draZPGIP = LoadDataSSPD(1);

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Возврат данных по заданию
        /// </summary>
        /// <param name="TypeZP">Тип задания</param>
        /// <param name="ID_Rec">Индекс задания</param>
        private DataRow GetDataZP(byte TypeZP, string ID_Rec)
        {
            DataRowCollection drc = null;

            if (TypeZP == 0) 
                drc = draZP;
            else
                drc = draZPGIP;

            if (drc == null) return null;

            foreach (DataRow dr in drc) 
                if (dr["ID_Rec"].ToString() == ID_Rec)
                    return dr;

            return null;
        }

        /// <summary>
        /// Загрузка данных по заданиям из ССПД
        /// </summary>
        /// <param name="TypeZP">Тип задания</param>
        private DataRowCollection LoadDataSSPD(byte TypeZP) //, string ID_Zad)
        {
            string SqlStr = "";
            if (TypeZP == 0) 
            {
                SqlStr = "SELECT ExchandeZadReestr.ID_Rec, ExchandeZadReestr.PathFilesPril, Projects.Sh_project, Projects.Name_Project, Otdels.NB_Otdel, ";
                SqlStr += " ExchandeZadReestr.DT_Out AS DT_Out, ExchandeZadReestr.Node, ExchandeZadReestr.PathFiles, ";
                SqlStr += " Workers.F_Worker + ' ' + Workers.I_Worker AS GIP, PIRPlan.Status, PIRPlan.DateExpPlan, PIRPlan.DatePZakPlan, ";
                SqlStr += " Projects.ID_GIP, ExchandeZadReestr.ID_WorkerOut AS IDW_Autor, Workers_1.F_Worker + ' ' + Workers_1.I_Worker AS AutorFIO";
                SqlStr += " FROM Workers RIGHT OUTER JOIN";
                SqlStr += " Projects ON Workers.ID_Worker = Projects.ID_GIP RIGHT OUTER JOIN";
                SqlStr += " Otdels RIGHT OUTER JOIN";
                SqlStr += " ExchandeZadReestr INNER JOIN";
                SqlStr += " Workers Workers_1 ON ExchandeZadReestr.ID_WorkerOut = Workers_1.ID_Worker ON ";
                SqlStr += " Otdels.ID_Otdel = ExchandeZadReestr.ID_OtdelOut ON Projects.ID_Project = ExchandeZadReestr.ID_Project LEFT OUTER JOIN";
                SqlStr += " Dogovors LEFT OUTER JOIN";
                SqlStr += " PIRPlan ON Dogovors.ID_RecPIRPlan = PIRPlan.ID_Rec RIGHT OUTER JOIN";
                SqlStr += " DogovorsProjects ON Dogovors.ID_Dog = DogovorsProjects.ID_Dog ON ";
                SqlStr += " Projects.ID_Project = DogovorsProjects.ID_Project";
                SqlStr += " WHERE (ExchandeZadReestr.ID_OtdelInp = " + TKP_Conf.AdminIDOtdel + ") AND (ExchandeZadReestr.Status = 1)";
            }
            else 
            {
                SqlStr = "SELECT ZadFromGIPReestr.ID_Rec, ZadFromGIPReestr.PathFilesPril, Projects.Sh_project, Projects.Name_Project, Workers.F_Worker + ' ' + Workers.I_Worker AS GIP, ";
                SqlStr += " PIRPlan.Status, PIRPlan.DateExpPlan, PIRPlan.DatePZakPlan, ZadFromGIPReestr.Node, ZadFromGIPReestr.DT_Out as DT_Out, 'БГИП' AS NB_Otdel, ZadFromGIPReestr.PathFiles, ";
                SqlStr += " ZadFromGIPReestr.ID_GIP as IDW_Autor, Workers_1.F_Worker + ' ' + Workers_1.I_Worker AS AutorFIO";
                SqlStr += " FROM Dogovors LEFT OUTER JOIN";
                SqlStr += " PIRPlan ON Dogovors.ID_RecPIRPlan = PIRPlan.ID_Rec RIGHT OUTER JOIN";
                SqlStr += " DogovorsProjects ON Dogovors.ID_Dog = DogovorsProjects.ID_Dog RIGHT OUTER JOIN";
                SqlStr += " ZadFromGIPReestr INNER JOIN";
                SqlStr += " ZadFromGIPReestrAdr ON ZadFromGIPReestr.ID_Rec = ZadFromGIPReestrAdr.ID_RecZadGip INNER JOIN";
                SqlStr += " Projects ON ZadFromGIPReestr.ID_Project = Projects.ID_Project INNER JOIN";
                SqlStr += " Workers ON Projects.ID_GIP = Workers.ID_Worker ON DogovorsProjects.ID_Project = Projects.ID_Project ";
                SqlStr += " INNER JOIN Workers Workers_1 ON ZadFromGIPReestr.ID_GIP = Workers_1.ID_Worker ";
                SqlStr += " WHERE  (ZadFromGIPReestrAdr.ID_OtdelInp = " + TKP_Conf.AdminIDOtdel + ") "; 
            }

            var rs = SSPD.DB.GetFields(SqlStr);

            return rs;
        }

        /// <summary>
        /// Добавить новое задание
        /// </summary>
        /// <param name="dr">Строка данных</param>
        /// <param name="TypeZad">Тип задания</param>
        private void AddNewZad(DataRow dr, string TypeZad)
        {
            Cursor.Current = Cursors.WaitCursor;
            Dictionary<string, object> DS = new Dictionary<string, object>();
            DS.Add("ID_ZAD", dr["ID_Rec"].ToString());
            DS.Add("TypeZad", TypeZad);
            DS.Add("Status", "0");
            DS.Add("DateStart", DateTime.Now.ToShortDateString());
            DS.Add("OlSh", dr["Sh_project"].ToString());
            
            LocalDB.InsertData(DS, "КонтрольТКП");

            LoadListTKP();

            DGV.Rows.Insert(0);
            DataGridViewRow DGVR = DGV.Rows[0];

            DataRow drZad = null;
            foreach (DataRow drtmp in dra)
            {
                if (drtmp["ID_Zad"].ToString() == dr["ID_Rec"].ToString())
                {
                    drZad = drtmp;
                    break;
                }
            }

            DataRow drSSPD = GetDataZP(Convert.ToByte(drZad["TypeZad"]), drZad["ID_Zad"].ToString());

            //создаем папку на L
            setPathOnL(drSSPD["Sh_project"].ToString(), drSSPD["NB_Otdel"].ToString());

            //добавляем строку в Дата Грид Вью
            SetDataInRow(DGVR, drZad, drSSPD);

            UI.SetBgRowInDGV(DGV);

            DGV.Rows[0].Selected = true;
            DGV.Rows[0].Cells[0].Selected = true;

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Открыть карточку запроса ТКП
        /// </summary>
        private void OpenCard()
        {
            if (DGV.SelectedRows.Count == 0) return;
            Card c = new Card();
            c.ID_TKP = ((Hashtable)DGV.SelectedRows[0].Tag)["ID_TKP"].ToString();
            c.ShowDialog();

            if (c.FlDelete)
            {
                foreach (DataRow dr in dra)
                {
                    if (dr["ID_TKP"].ToString() == c.ID_TKP)
                    {
                        dra.Remove(dr);
                        break;
                    }
                }
                DGV.Rows.RemoveAt(DGV.SelectedRows[0].Index);
            }
            else if (c.FlSave)
            {
                DGV.SelectedRows[0].Cells["ShOl"].Value = c.OlSh.Text;
                DGV.SelectedRows[0].Cells["Equip"].Value = c.Equipment.Text;


                setCountStatus(DGV.SelectedRows[0].Cells["Status"],
                    Convert.ToInt32(c.CntDocOut),
                    Convert.ToInt32(c.CntDocInp),
                    Convert.ToInt32(c.CntCancelDoc),
                    Convert.ToInt32(c.CntTrueDoc),
                    Convert.ToInt32(c.CntRecDoc)
                    );

                DGV.SelectedRows[0].Cells["DateFinish"].Value = GetStatus(c.Status.Tag.ToString());

                if (c.Status.Tag.ToString() == "1")
                    DGV.SelectedRows[0].Cells["DateFinish"].Value += "\n" + c.DateEnd.Text;

                if (c.CntUseTKP > 0)
                    SetStatusUseTKP(DGV.SelectedRows[0]);
                else
                    SetStatusUseTKP(DGV.SelectedRows[0], 1);

                DGV.SelectedRows[0].Cells["DateOut"].Value = c.DateOut.Text;

                //обновляем данные в массиве
                foreach (DataRow dr in dra)
                {
                    if (dr["ID_TKP"].ToString() == c.ID_TKP)
                    {
                        dr["OlSh"] = c.OlSh.Text;
                        dr["Equipment"] = c.Equipment.Text;
                        dr["CntOutDoc"] = c.CntDocOut;
                        dr["CntInpDoc"] = c.CntDocInp;

                        dr["CntTrueDoc"] = c.CntDocInp;
                        dr["CntCancelDoc"] = c.CntDocInp;
                        dr["CntRecDoc"] = c.CntDocInp;

                        dr["Status"] = c.Status.Tag.ToString();

                        if (c.DateOut.Text != "")
                            dr["DateOut"] = c.DateOut.Text;
                        else
                        {
                            
                            dr["DateOut"] = DBNull.Value;

                            if (DGV.SelectedRows[0].Cells["DateOut"].Tag != null)
                            {
                                DGV.SelectedRows[0].Cells["DateOut"].Value = DGV.SelectedRows[0].Cells["DateOut"].Tag;
                            }
                        }

                        break;
                    }
                }

            }
        }

        #endregion

        #region [Фильтр]

        private bool CheckFilter(DataRow drTKP, DataRow drSSPD)
        {
            bool ret = true;

            if (ФОтсутствует.Checked == true) return true;

            //По статусу
            if (ФСтатусВсе.Checked == false)
            {
                if (ФСтатусВработе.Checked == true && drTKP["Status"].ToString() != "0") ret =  false;
                if (ФСтатусВыполненные.Checked == true && drTKP["Status"].ToString() != "1") ret = false;
                if (ФСтатусОтмененные.Checked == true && drTKP["Status"].ToString() != "2") ret = false;
                if (ФСтатусНеАктуально.Checked == true && drTKP["Status"].ToString() != "3") ret = false;
            }

            //по оборудованию
            if (ФОборудованиеВсе.Checked == false && ret == true)
            {
                if (ФОборудование.Tag != null && drTKP["Equipment"].ToString().ToLower().IndexOf(ФОборудование.Tag.ToString().ToLower()) == -1) 
                    ret = false;
            }

            //по проекту
            if (ФПроектВсе.Checked == false && ret == true)
            {
                if (ФПроект.Tag != null && drSSPD["Sh_project"].ToString().ToLower().IndexOf(ФПроект.Tag.ToString().ToLower()) ==-1)
                    ret = false;
            }

            //по организации
            if (ФОргВсе.Checked == false && ret == true)
            {
                if (ФОрг.Tag != null && ((List<string>)ФОрг.Tag).IndexOf(drTKP["ID_TKP"].ToString()) == -1)
                    ret = false;
            }

            //по отделу
            if (ФОтделВсе.Checked == false && ret == true)
            {
                //OtdelZad
                if (ФОтдел.Tag != null && drSSPD["NB_Otdel"].ToString().ToLower().IndexOf(ФОтдел.Tag.ToString().ToLower()) == -1)
                    ret = false;
            }


            //по дате выдачи задания
            if (ФДатаВыдачиЗаданияПериод.Checked && ret == true)
            {
                if (ФДатаВыдачиЗаданияПериод.Tag != null)
                {
                    DateTime D1 = (DateTime)((List<DateTime>)ФДатаВыдачиЗаданияПериод.Tag)[0];
                    DateTime D2 = (DateTime)((List<DateTime>)ФДатаВыдачиЗаданияПериод.Tag)[1];

                    if (D1 == D2) D2.AddHours(23);

                    DateTime D_ZP = Convert.ToDateTime(drSSPD["DT_Out"]).Date;

                    //если дата начала больше 
                    if (D1 > D_ZP)
                        ret = false;
                    else
                        if (D2 < D_ZP)
                            ret = false;
                }
            }


            //по гипу
            if (ФГИПВсе.Checked == false && ret == true)
            {
                if (ФГИП.Tag != null && drSSPD["GIP"].ToString().ToLower().IndexOf(ФГИП.Tag.ToString().ToLower()) == -1)
                    ret = false;
            }

            //по автору задания
            if (ФАвторВсе.Checked == false && ret == true)
            {
                if (ФАвтор.Tag != null && drSSPD["IDW_Autor"].ToString() != ФАвтор.Tag.ToString())
                    ret = false;
            }


            //быстрый поиск
            if (FastSearch.Text.Trim() != "" && ret)
            {
                string fs = FastSearch.Text.Trim().ToLower();

                ret = false;

                if (drTKP["ID_Zad"].ToString().ToLower().IndexOf(fs) != -1)
                    ret = true;

                if (drTKP["Equipment"].ToString().ToLower().IndexOf(fs) != -1)
                    ret = true;

                if (drTKP["OlSh"].ToString() == "")
                    if (drTKP["OlSh"].ToString().ToLower().IndexOf(fs) != -1)
                        ret = true;

                if (drSSPD["Sh_project"].ToString().ToLower().IndexOf(fs) != -1)
                    ret = true;

                if (drSSPD["Name_Project"].ToString().ToLower().IndexOf(fs) != -1)
                    ret = true;

                if (drSSPD["NB_Otdel"].ToString().ToLower().IndexOf(fs) != -1)
                    ret = true;

                if (drSSPD["GIP"].ToString().ToLower().IndexOf(fs) != -1)
                    ret = true;

                if (drSSPD["AutorFIO"].ToString().ToLower().IndexOf(fs) != -1)
                    ret = true;

            }

            return ret;
        }
        

        private void ФОтсутствует_Click(object sender, EventArgs e)
        {
            ФильтрОтсутствует();
        }

        private void ФСтатусВработе_Click(object sender, EventArgs e)
        {
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
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

        private void ФСтатусВыполненные_Click(object sender, EventArgs e)
        {
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        private void ФСтатусВсе_Click(object sender, EventArgs e)
        {
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }
        
        private void ФОборудование_Click(object sender, EventArgs e)
        {
            SelectForm.ListEquip LE = new SelectForm.ListEquip();
            LE.ShowDialog();
            if (LE.SelEq != "")
            {
                doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
                ФОборудование.Text = "Оборудование - " + LE.SelEq;
                ФОборудование.Tag = LE.SelEq;
                GetListTKP();
            }
        }

        private void ФОборудованиеВсе_Click(object sender, EventArgs e)
        {
            ФОборудование.Text = "Оборудование - ...";
            ФОборудование.Tag = null;
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        private void ФПроект_Click(object sender, EventArgs e)
        {
            SelectForm.ListProject LP = new SelectForm.ListProject();
            LP.ShowDialog();
            if (LP.SelID != "")
            {
                doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
                ФПроект.Text = "Проект - " + LP.SelShPrj;
                ФПроект.Tag = LP.SelShPrj;
                GetListTKP();
            }
        }

        private void ФПроектВсе_Click(object sender, EventArgs e)
        {
            ФПроект.Text = "Проект - ...";
            ФПроект.Tag = null;
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        #endregion

        #region [События]


        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            OpenCard();
        }

        private void открытьКарточкуТКПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCard();
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }

        private void реестрМТР_Click(object sender, EventArgs e)
        {
            ListMTR LMTR = new ListMTR();
            LMTR.ShowDialog();
        }

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            ExportExl.ExportTKP(DGV);
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ФСтатусОтмененные_Click(object sender, EventArgs e)
        {
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

            if (e.KeyCode == Keys.Enter) OpenCard();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileZadTKP();
        }

        private void добавитьЗаданиеОтОтделаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectForm.ListZadOtdels LZO = new SelectForm.ListZadOtdels();
            LZO.ShowDialog();
            if (LZO.flSel)
                AddNewZad(LZO.drSel, "0");
        }

        private void добавитьЗаданиеОтГИПаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectForm.ListZadGip LZG = new SelectForm.ListZadGip();
            LZG.ShowDialog();
            if (LZG.flSel)
                AddNewZad(LZG.drSel, "1");
        }
        
        private void ФОргВсе_Click(object sender, EventArgs e)
        {
            ФОрг.Text = "Организация - ...";
            ФОрг.Tag = null;
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        private void ФОрг_Click(object sender, EventArgs e)
        {
            SelectForm.ListOrg LOrg = new SelectForm.ListOrg();
            LOrg.ShowDialog();
            if (LOrg.SelIDOrg != "")
            {
                doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
                ФОрг.Text = "Организация - " + LOrg.SelNameOrg;
                //ФПроект.Tag = LOrg.SelIDOrg;

                //1. создать лист подходящих ID_TKP
                string SqlStr = "SELECT DISTINCT КонтрольТКП_Письма.ID_TKP";
                SqlStr += " FROM КонтрольТКП_Письма ";
                SqlStr += " WHERE КонтрольТКП_Письма.ID_OrgOut=" + LOrg.SelIDOrg + " OR КонтрольТКП_Письма.ID_OrgInp=" + LOrg.SelIDOrg;
                DataRowCollection drc_tkp_org = LocalDB.LoadData(SqlStr);

                List<string> TKPOrgFilter = new List<string>();
                foreach (DataRow dr in drc_tkp_org)
                    TKPOrgFilter.Add(dr["ID_TKP"].ToString());
                drc_tkp_org = null;

                //Console.WriteLine(TKPOrgFilter.Count);

                ФОрг.Tag = TKPOrgFilter;
                //2. проверять по каждому о_О

                //3. изменить запрос о_О


                GetListTKP();
            }
        }

        private void ФСтатусНеАктуально_Click(object sender, EventArgs e)
        {
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        private void МенюЭкспортТКП_Click(object sender, EventArgs e)
        {
            ExportTKP ExpTKP = new ExportTKP();
            ExpTKP.DGV = this.DGV;
            ExpTKP.ShowDialog();
        }

        private void ФОтделВсе_Click(object sender, EventArgs e)
        {
            ФОтдел.Text = "Отдел - ...";
            ФОтдел.Tag = null;
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        private void ФОтдел_Click(object sender, EventArgs e)
        {
            SelectForm.SelectOtdel SelOtdel = new SelectForm.SelectOtdel();
            SelOtdel.ShowDialog();
            if (SelOtdel.SelNBOtdel != "")
            {
                doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
                ФОтдел.Text = "Отдел - " + SelOtdel.SelNBOtdel;
                ФОтдел.Tag = SelOtdel.SelNBOtdel;
                GetListTKP();
            }
        }
        
        private void экспортДокументовToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ExportScanDoc expFrm = new ExportScanDoc();
            expFrm.DGV = DGV;
            expFrm.ShowDialog();

        }

        private void ФДатаВыдачиЗаданияВсе_Click(object sender, EventArgs e)
        {
            ФДатаВыдачиЗаданияПериод.Text = "Период - ...";
            ФДатаВыдачиЗаданияПериод.Tag = null;
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        private void ФДатаВыдачиЗаданияПериод_Click(object sender, EventArgs e)
        {
            SelectForm.SelectPeriod SP = new SelectForm.SelectPeriod();

            if (ФДатаВыдачиЗаданияПериод.Tag != null)
            {
                DateTime D1 = (DateTime)((List<DateTime>)ФДатаВыдачиЗаданияПериод.Tag)[0];
                DateTime D2 = (DateTime)((List<DateTime>)ФДатаВыдачиЗаданияПериод.Tag)[1];
                SP.D1 = D1;
                SP.D2 = D2;
            }

            SP.ShowDialog();

            if (SP.flSel)
            {
                List<DateTime> FDateZad = new List<DateTime>();
                FDateZad.Add(SP.D1);
                FDateZad.Add(SP.D2);
                ФДатаВыдачиЗаданияПериод.Tag = FDateZad;
                ФДатаВыдачиЗаданияПериод.Text = string.Format("c {0} по {1}", UI.GetDate(FDateZad[0].ToString()), UI.GetDate(FDateZad[1].ToString()));
                doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
                GetListTKP();
            }

            SP.Dispose();
        }

        private void открытьЗаданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileZadTKP();
        }

        private void открытьКарточкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCard();
        }

        private void открытьПриложениеКЗаданиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFilePrilZadTKP();
        }

        private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && DGV.Rows.Count > 0) UI.SetBgRowInDGV(DGV);
        }

        private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex != -1)
            {
                КонтекстноеМенюЗапросТКП.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void таблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectForm.ListProject LP = new SelectForm.ListProject();
            LP.ShowDialog();
            if (LP.SelID != "")
            {
                ReportTable rt = new ReportTable(LP.SelID, LP.SelNamePrj, LP.SelShPrj);
                rt.ExportReportTable();

                //PrjSh.Text = LP.SelShPrj;
                //PrjSh.Tag = LP.SelID;
            }
        }

        private void ФАвторВсе_Click(object sender, EventArgs e)
        {
            ФАвтор.Text = "Автор - ...";
            ФАвтор.Tag = null;
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        private void ФАвтор_Click(object sender, EventArgs e)
        {
            SelectForm.SelectWorker SW = new SelectForm.SelectWorker();

            SW.Text = "Выбор автора задания";

            //if (flPOtdel)
            //    SW.SqlQuery = "SELECT ID_Worker, F_Worker, I_Worker, N_Worker, P_Worker FROM Workers WHERE Fl_Rel = 0 AND ID_Otdel = " + Params.UserInfo.ID_MOtdel;
            //else
            //SW.SqlQuery = "SELECT ID_Worker, F_Worker, I_Worker, N_Worker, P_Worker FROM Workers WHERE Fl_Rel = 0 ";
            SW.SqlQuery = "SELECT DISTINCT Workers.ID_Worker, Workers.F_Worker, Workers.I_Worker, Workers.N_Worker, Workers.P_Worker FROM Workers INNER JOIN";
            SW.SqlQuery += " ExchandeZadReestr ON ExchandeZadReestr.ID_WorkerOut = Workers.ID_Worker";
            SW.SqlQuery += string.Format(" WHERE Workers.Fl_Rel = 0 AND ExchandeZadReestr.ID_OtdelInp = {0}", TKP_Conf.AdminIDOtdel);

            SW.ShowDialog();

            if (SW.SelIDWorker != "")
            {
                doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
                ФАвтор.Text = "Автор - " + SW.SelNBFIO;
                ФАвтор.Tag = SW.SelIDWorker;
                GetListTKP();
            }
        }

        private void запускСИнтерфейсомПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectForm.SelectWorker SW = new SelectForm.SelectWorker();
            SW.Text = "Выбор пользователя";
            SW.SqlQuery = "SELECT ID_Worker, F_Worker, I_Worker, N_Worker, P_Worker FROM Workers WHERE Fl_Rel = 0 ";

            SW.ShowDialog();
            if (SW.SelIDWorker != "")
            {
                string sql = string.Format("SELECT Login FROM Workers WHERE ID_Worker = {0}", SW.SelIDWorker);
                string Login = DB.GetFields(sql)[0][0].ToString();

                User.LoadUserInfo(Login);


                ФильтрОтсутствует(false);
                InitForm();

                GetListTKP();

                //doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
                //ФАвтор.Text = "Автор - " + SW.SelNBFIO;
                //ФАвтор.Tag = SW.SelIDWorker;

            }
        }

        private void ФГИП_Click(object sender, EventArgs e)
        {
            SelectForm.SelectWorker SW = new SelectForm.SelectWorker();
            SW.ShowDialog();
            if (SW.SelIDWorker != "")
            {
                doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
                ФГИП.Text = "ГИП - " + SW.SelNBFIO;
                ФГИП.Tag = SW.SelNBFIO;
                GetListTKP();
            }
        }

        private void ФГИПВсе_Click(object sender, EventArgs e)
        {
            ФГИП.Text = "ГИП - ...";
            ФГИП.Tag = null;
            doCheck((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem, (ToolStripMenuItem)sender);
            GetListTKP();
        }

        private void приложениеКПисьмуВОСТToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForOST RFO = new ReportForOST();

            //RFO.dra = this.dra;
            //RFO.draZP = this.draZP;
            //RFO.draZPGIP = this.draZPGIP;

            RFO.ShowDialog();
        }

        private void FastSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetListTKP();
            }
        }

        private void FastSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListTKP_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (LocalDB.LocalConn.State == ConnectionState.Open)
                LocalDB.LocalConn.Close();

        }


        #endregion

        #region [Вспомогательные процедуры]


        /// <summary>
        /// Возвращает статус запроса ТКП
        /// </summary>
        /// <param name="Status">Параметр статуса</param>
        /// <returns>Возвращает статус</returns>
        private string GetStatus(string Status)
        {
            string retStatus = "";

            switch (Convert.ToInt32(Status))
            {
                case 0:
                    retStatus = "В работе";
                    break;
                case 1:
                    retStatus = "Выполнено";
                    break;
                case 2:
                    retStatus = "Отменено";
                    break;
                case 3:
                    retStatus = "Не актуально";
                    break;
            }

            return retStatus;
        }

        /// <summary>
        /// Статус запроса ТКП по кол-ву
        /// </summary>
        /// <param name="dgvc">Ячейка</param>
        /// <param name="cntOut">Кол-во входящих</param>
        /// <param name="cntInp">Кол-во исхдящих</param>
        /// <param name="cntCancel">Кол-во отмененных</param>
        /// <param name="cntTrue">Кол-во положительных</param>
        /// <param name="cntRec">Всего записей</param>
        private void setCountStatus(DataGridViewCell dgvc, int cntOut, int cntInp, int cntCancel, int cntTrue, int cntRec)
        {
            string s = "Полож-ых: " + cntTrue.ToString() + " из " + cntOut.ToString();
            s += "\n";
            s += "Отказов: " + cntCancel.ToString();
            dgvc.Value = s;

            string t = "Отправлено: " + cntOut.ToString() + "\n";
            t += "Всего получено: " + cntInp.ToString() + "\n\n";
            t += "из них: \n";
            t += "Положительных: " + cntTrue.ToString() + "\n";
            t += "Отказов: " + cntCancel.ToString() + "\n";
            t += "Уточнений: " + cntRec.ToString();
            dgvc.ToolTipText = t;
        }

        /// <summary>
        /// Закрашивает ячейку в соответствии с датами
        /// </summary>
        /// <param name="DGVC">Ячейка для закраски</param>
        /// <param name="DateOut">Дата выдачи задания</param>
        /// <param name="DatePrj">Дата выпуска проекта</param>
        private void setColorStatusDate(DataGridViewCell DGVC, string DateOut, string DatePrj)
        {
            DateTime DO = Convert.ToDateTime(DateOut);
            if (DatePrj != "")
            {
                DateTime DP = Convert.ToDateTime(DatePrj);

                //прошло 5 дней с даты выдачи задания 
                if (DP.AddDays(-5) < DateTime.Now)
                {
                    if (DP.AddDays(-1) < DateTime.Now)
                    {
                        DGVC.Style.BackColor = Color.DarkRed;
                        DGVC.Style.ForeColor = Color.White;
                    }
                    else
                        DGVC.Style.BackColor = Color.LightCoral;
                }
                else
                {
                    //прошло 5 дней с даты выдачи задания 
                    if (DO.AddDays(5) < DateTime.Now)
                    {
                        DGVC.Style.BackColor = Color.Khaki;
                    }
                }
            }
            else
            {
                //прошло 5 дней с даты выдачи задания 
                if (DO.AddDays(5) < DateTime.Now)
                {
                    DGVC.Style.BackColor = Color.Khaki;
                }
            }
        }

        /// <summary>
        /// Закрашивает ячейку в соответствии со статусом объекта в Плане ПИР
        /// </summary>
        /// <param name="DGVC">Ячейка для закраски</param>
        /// <param name="Status">Статус объекта в Плане ПИР</param>
        private void setColorPIRStatus(DataGridViewCell DGVC, int Status)
        {
            if (Status == 1 || Status == 2)
                DGVC.Style.BackColor = UI.bgFailPir;
        }


        //подсвечиваем статус если ткп в работе 
        private void SetStatusUseTKP(DataGridViewRow DGVR, byte mean = 0)
        {
            if (mean == 0)
            {
                DGVR.Cells["Status"].Style.BackColor = UI.bgUseTKP;
                DGVR.Cells["Status"].Style.SelectionBackColor = UI.bgUseTKP;
                DGVR.Cells["Status"].Style.SelectionForeColor = Color.Black;
            }
            else
            {
                DGVR.Cells["Status"].Style.BackColor = DGVR.Cells[2].Style.BackColor;
                DGVR.Cells["Status"].Style.SelectionBackColor = DGVR.Cells[2].Style.SelectionBackColor;
                DGVR.Cells["Status"].Style.SelectionForeColor = DGVR.Cells[2].Style.SelectionForeColor;
            }
        }


        /// <summary>
        /// Выводит информацию о выбранных фильтрах
        /// </summary>
        private void getLabelFilter()
        {
            string LabelFilter = " | Фильтр: ";
            if (ФОтсутствует.Checked)
                LabelFilter += ФОтсутствует.Text;
            else
            {
                if (ФСтатусВработе.Checked)
                    LabelFilter += ФПоСтатусу.Text + " - " + ФСтатусВработе.Text;
                else if (ФСтатусВыполненные.Checked)
                    LabelFilter += ФПоСтатусу.Text + " - " + ФСтатусВыполненные.Text;
                else if (ФСтатусОтмененные.Checked)
                    LabelFilter += ФПоСтатусу.Text + " - " + ФСтатусОтмененные.Text;
                else if (ФСтатусНеАктуально.Checked)
                    LabelFilter += ФПоСтатусу.Text + " - " + ФСтатусНеАктуально.Text;
                else if (ФСтатусВсе.Checked)
                    LabelFilter += ФПоСтатусу.Text + " - " + ФСтатусВсе.Text;


                if (ФОборудование.Checked)
                {
                    if (LabelFilter != " | Фильтр: ") LabelFilter += "; ";
                    LabelFilter += ФОборудование.Text;
                }


                if (ФПроект.Checked)
                {
                    if (LabelFilter.LastIndexOf("; ") != LabelFilter.Length - 2) LabelFilter += "; ";
                    LabelFilter += ФПроект.Text;
                }


                if (ФГИП.Checked)
                {
                    if (LabelFilter.LastIndexOf("; ") != LabelFilter.Length - 2) LabelFilter += "; ";
                    LabelFilter += ФГИП.Text;
                }
                

                if (ФОрг.Checked)
                {
                    if (LabelFilter.LastIndexOf("; ") != LabelFilter.Length - 2) LabelFilter += "; ";
                    LabelFilter += ФОрг.Text;
                }


                if (ФОтдел.Checked)
                {
                    if (LabelFilter.LastIndexOf("; ") != LabelFilter.Length - 2) LabelFilter += "; ";
                    LabelFilter += ФОтдел.Text;
                }

                if (ФДатаВыдачиЗаданияПериод.Checked)
                {
                    if (LabelFilter.LastIndexOf("; ") != LabelFilter.Length - 2) LabelFilter += "; ";
                    LabelFilter += string.Format("По дате выдачи задания: {0}", ФДатаВыдачиЗаданияПериод.Text);
                }

                if (ФАвтор.Checked)
                {
                    if (LabelFilter.LastIndexOf("; ") != LabelFilter.Length - 2) LabelFilter += "; ";
                    LabelFilter += string.Format("По автору задания: {0}", ФАвтор.Text.Substring(8,ФАвтор.Text.Length - 8));
                }

            }

           CountRowLabel.Text += LabelFilter; 
        }

        /// <summary>
        /// Формирование структуры папок на диске L в каталоке ТКП
        /// </summary>
        /// <param name="ShPrj">Шифр проекта</param>
        /// <param name="NBOtdel">Сокращенное наименование отдела</param>
        private void setPathOnL(string ShPrj, string NBOtdel = "")
        {
            string Lpath = @"\\10.105.21.53\Проекты\ТКП";

            if (!Directory.Exists(Lpath))
                return;

            if (ShPrj != "")
                createPath(string.Format("{0}\\{1}", Lpath, ConvertFileName(ShPrj)));

            if (NBOtdel != "")
                createPath(string.Format("{0}\\{1}\\{2}", Lpath, ConvertFileName(ShPrj), ConvertFileName(NBOtdel)));

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

        /// <summary>
        /// Создание папки
        /// </summary>
        /// <param name="PathOut">Путь до папки</param>
        private void createPath(string PathOut)
        {
            //PathOut = ConvertFileName(PathOut);
            if (!Directory.Exists(PathOut)) // "!" забыл поставить
            {
                Directory.CreateDirectory(PathOut);
            }
        }

        /// <summary>
        /// Открыть файл задания
        /// </summary>
        private void OpenFileZadTKP()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                FTP.DonwloadFile(((Hashtable)DGV.SelectedRows[0].Tag)["FPath"].ToString(),
                             DGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        /// <summary>
        /// Открыть файл задания
        /// </summary>
        private void OpenFilePrilZadTKP()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                if (((Hashtable)DGV.SelectedRows[0].Tag)["PathFilesPril"].ToString() !="")
                    FTP.DonwloadFile(((Hashtable)DGV.SelectedRows[0].Tag)["PathFilesPril"].ToString(),
                                 DGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void ФильтрОтсутствует(bool flUpdateList = true)
        {
            foreach (object obj in Фильтр.DropDownItems)
            {
                if (obj.GetType() == ФОтсутствует.GetType())
                {
                    if (((ToolStripMenuItem)obj).DropDownItems.Count > 0)
                    {
                        foreach (object subobj in ((ToolStripMenuItem)obj).DropDownItems)
                        {
                            if (subobj.GetType() == ФОтсутствует.GetType())
                            {
                                ((ToolStripMenuItem)subobj).Checked = false;
                            }
                        }
                    }
                }
            }

            ФГИПВсе.Checked = true;
            ФСтатусВсе.Checked = true;
            ФПроектВсе.Checked = true;
            ФОборудованиеВсе.Checked = true;
            ФОтсутствует.Checked = true;
            ФОргВсе.Checked = true;
            ФОтделВсе.Checked = true;
            ФДатаВыдачиЗаданияВсе.Checked = true;
            ФАвторВсе.Checked = true;

            ФОборудование.Text = "Оборудование - ...";
            ФОборудование.Tag = null;

            ФПроект.Tag = null;
            ФПроект.Text = "Проект - ...";

            ФОрг.Tag = null;
            ФОрг.Text = "Организация - ...";

            ФОтдел.Tag = null;
            ФОтдел.Text = "Отдел - ...";

            ФДатаВыдачиЗаданияПериод.Tag = null;
            ФДатаВыдачиЗаданияПериод.Text = "Период - ...";

            ФАвтор.Tag = null;
            ФАвтор.Text = "Автор - ...";

            //если стоит флаг обновления списка (по умолчанию)
            if (flUpdateList)
                GetListTKP();
        }

        /// <summary>
        /// Возвращает флаг наличия записей в таблице заданий
        /// </summary>
        /// <param name="ID">Параметр</param>
        /// <param name="NameField">Наименование поля</param>
        /// <returns></returns>
        private bool checkExchangeZad(string ID, string NameField)
        {
            string sql = string.Format("SELECT TOP 1 ID_Rec FROM ExchandeZadReestr WHERE {0} = {1} AND ID_OtdelInp = {2}", NameField, ID, TKP_Conf.AdminIDOtdel);

            if (DB.GetFields(sql).Count == 0)
                return false;
            else
                return true;
            //if (TypeField == "ID_WorkerOut")
        }


        #endregion

        private void просмотрЛогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogViewer lv = new LogViewer();
            lv.ShowDialog();
            lv.Dispose();
        }

    }
}