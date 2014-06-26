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

namespace Контроль_запросов_ТКП
{
    public partial class Card : Form
    {

        public string ID_TKP;

        public bool FlDelete = false;
        public bool FlSave = false;
        public int CntDocOut;
        public int CntDocInp;
        public int CntUseTKP;
        public int CntCancelDoc;
        public int CntTrueDoc;
        public int CntRecDoc;
        
        private string TypeZad = "";
        private string PathFZad = "";
        private string PathFZadPril = "";
        private bool ReadOnly = false;

        //автофильтр оборудования
        private DataRowCollection drEq = null;

        public Card()
        {
            InitializeComponent();

            this.Width = 1025;
            this.Height = 800;

            if (TKP_Conf.AdminIDOtdel != Params.UserInfo.ID_Otdel)
            {
                МенюУправление.Visible = false;
                МенюСтатус.Visible = false;
                МенюДокументы.Visible = false;
                OlSh.ReadOnly = true;
                Equipment.ReadOnly = true;
                SelMTR.Visible = false;
                ReadOnly = true;
                pПримечание.Visible = false;
                pКонтакты.Visible = false;
                btnSelEq.Visible = false;
                toolStripSeparator9.Visible = false;
                статусВходящего.Visible = false;
            }

        }

        private void Card_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataEq();
        }


        /// <summary>
        /// Общая процедура загрузки данных
        /// </summary>
        private void LoadData()
        {
            LoadDataTKP();
            LoadDataZP();
            LoadDataDocs();
        }

        /// <summary>
        /// Загрузка листа оборудования для выбора
        /// </summary>
        private void LoadDataEq()
        {
            drEq = LocalDB.LoadData("SELECT DISTINCT Equipment FROM КонтрольТКП");
            lbEq.Width = Equipment.Width;
        }

        /// <summary>
        /// Загрузка карточки ТКП
        /// </summary>
        private void LoadDataTKP()
        {
            string SqlStr = "SELECT КонтрольТКП.ID_Zad, КонтрольТКП.TypeZad, КонтрольТКП.Status, КонтрольТКП.DateStart, КонтрольТКП.DateEnd, ";
            SqlStr += " КонтрольТКП.Equipment, КонтрольТКП.OlSh, ГруппыМТР.Code, КонтрольТКП.DateOut ";
            SqlStr += " FROM КонтрольТКП LEFT OUTER JOIN ГруппыМТР ON ГруппыМТР.ID_REC = КонтрольТКП.ID_MTR";
            SqlStr += " WHERE КонтрольТКП.ID_TKP = " + ID_TKP;

            var rs = LocalDB.LoadData(SqlStr);

            if (rs != null)
            {
                DataRow dr = rs[0];

                NumZad.Text = string.Format("{0:000000}", dr["ID_Zad"].ToString());
                NumZad.Tag = dr["ID_Zad"].ToString();

                TypeZad = dr["TypeZad"].ToString();

                //Status.Text = dr["Status"].ToString() == "0" ? "В работе" : "Выполнен";
                СтатусВРаботе.Checked = false;
                СтатусВыполнено.Checked = false;
                if (dr["Status"].ToString() == "0") 
                {
                    СтатусВРаботе.Checked = true;
                    Status.Text = "В работе";
                }
                else if (dr["Status"].ToString() == "1")
                {
                    СтатусВыполнено.Checked = true;
                    Status.Text = "Выполнено";
                }
                else if (dr["Status"].ToString() == "2")
                {
                    СтатусОтменено.Checked = true;
                    Status.Text = "Отменено";
                }
                else if (dr["Status"].ToString() == "3")
                {
                    СтатусНеАктуально.Checked = true;
                    Status.Text = "Не актуально";
                }

                Status.Tag = dr["Status"].ToString();


                if (dr["DateEnd"].ToString() == "")
                    DateEnd.Text = "-";
                else
                    DateEnd.Text = UI.GetDate(dr["DateEnd"].ToString());

                DateEnd.Tag = DateEnd.Text;


                if (dr["DateStart"].ToString() !="") DateStart.Text = UI.GetDate(dr["DateStart"].ToString());

                if (dr["Equipment"].ToString() != "")
                {
                    Equipment.Text = dr["Equipment"].ToString();
                    Equipment.Tag = Equipment.Text;
                }

                if (dr["OlSh"].ToString() != "")
                {
                    OlSh.Text = dr["OlSh"].ToString();
                    OlSh.Tag = OlSh.Text;
                }

                if (dr["Code"].ToString() != "")
                {
                    SelMTR.Text = "очистить";
                    MTRCode.Text = dr["Code"].ToString();
                }

                if (dr["DateOut"].ToString() != "")
                {
                    DateOut.Text = UI.GetDate(dr["DateOut"].ToString());
                    DateOut.Tag = DateOut.Text;
                }
                
            }
        }

        /// <summary>
        /// Загрузка данных по заданию на запрос ТКП
        /// </summary>
        private void LoadDataZP()
        {
            string SqlStr = "";

            if (TypeZad == "0") {
                SqlStr = "SELECT ExchandeZadReestr.ID_Rec,  Projects.Sh_project,  Projects.Name_Project,  Otdels.Name_Otdel,  ExchandeZadReestr.DT_Out, ExchandeZadReestr.Node";
                SqlStr += " , ExchandeZadReestr.PathFiles, ExchandeZadReestr.PathFilesPril, Workers.F_Worker + ' ' + Workers.I_Worker as WorkerOut, Workers.ID_Worker";
                SqlStr += " , W2.F_Worker + ' ' + W2.I_Worker as GIP, Projects.ID_Project";
                SqlStr += " FROM ExchandeZadReestr INNER JOIN ";
                SqlStr += " Projects ON  ExchandeZadReestr.ID_Project =  Projects.ID_Project INNER JOIN ";
                SqlStr += " Otdels ON  ExchandeZadReestr.ID_OtdelOut =  Otdels.ID_Otdel INNER JOIN";
                SqlStr += " Workers ON  Workers.ID_Worker =  ExchandeZadReestr.ID_WorkerOut INNER JOIN";
                SqlStr += " Workers W2 ON  W2.ID_Worker =  Projects.ID_Gip ";
                SqlStr += " WHERE ExchandeZadReestr.ID_Rec = " + NumZad.Tag.ToString();
            } 
            else 
            {
                SqlStr = " SELECT ZadFromGIPReestr.ID_Rec, Workers.F_Worker + ' ' + Workers.I_Worker AS WorkerOut, Projects.Sh_project, Projects.Name_Project, ";
                SqlStr += " ZadFromGIPReestr.PathFiles, ZadFromGIPReestr.PathFilesPril, ZadFromGIPReestr.Node, ZadFromGIPReestr.DT_Out, 'Бюро главных инженеров проектов' as Name_Otdel ";
                SqlStr += " , W2.F_Worker + ' ' + W2.I_Worker as GIP, Projects.ID_Project, Workers.ID_Worker";
                SqlStr += " FROM  ZadFromGIPReestr INNER JOIN";
                SqlStr += " ZadFromGIPReestrAdr ON ZadFromGIPReestr.ID_Rec = ZadFromGIPReestrAdr.ID_RecZadGip INNER JOIN";
                SqlStr += " Projects ON ZadFromGIPReestr.ID_Project = Projects.ID_Project INNER JOIN";
                SqlStr += " Workers ON ZadFromGIPReestr.ID_GIP = Workers.ID_Worker INNER JOIN";
                SqlStr += " Workers W2 ON Projects.ID_GIP = W2.ID_Worker ";
                SqlStr += " WHERE (ZadFromGIPReestrAdr.ID_OtdelInp = " + TKP_Conf.AdminIDOtdel + ") AND (ZadFromGIPReestr.ID_Rec = " + NumZad.Tag.ToString() + ")";
            }
            var rs = SSPD.DB.GetFields(SqlStr);
            if (rs != null)
            {
                DataRow dr = rs[0];
                PathFZad = dr["PathFiles"].ToString();
                PathFZadPril = dr["PathFilesPril"].ToString();

                ShPrj.Text = dr["Sh_project"].ToString();
                ShPrj.Tag = dr["ID_Project"].ToString();
                NamePrj.Text = dr["Name_Project"].ToString();
                OtdelZad.Text = dr["Name_Otdel"].ToString();
                ZadDate.Text = UI.GetDate(dr["DT_Out"].ToString());
                ZadNote.Text = dr["Node"].ToString();
                FIOZad.Text = dr["WorkerOut"].ToString();
                FIOZad.Tag = dr["ID_Worker"].ToString();
                GIP.Text = dr["GIP"].ToString();

                if (DateOut.Text == "")
                {
                    DateOut.Text = LoaDatePZakPlan(ShPrj.Tag.ToString());
                    if (DateOut.Text != "") {
                        DateOut.Text = UI.GetDate(DateOut.Text);
                        DateOut.Tag = DateOut.Text;
                    }
                }
            }
       }

        /// <summary>
        /// Загрузка списка документов к запросу ТКП
        /// </summary>
        private void LoadDataDocs()
        {
            var rs = LocalDB.LoadData("SELECT ID, ID_OutDoc, ID_InpDoc, Mail_Note, DateStartTKP, DateFinishTKP, UseTKP, StatusDoc "
                                     +"FROM КонтрольТКП_Письма WHERE ID_TKP = " + ID_TKP+ " ORDER BY ID DESC");
            DGV.Rows.Clear();
            if (rs != null)
            {
                foreach (DataRow dr in rs)
                {
                    DGV.Rows.Add();
                    DataGridViewRow DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                    DGVR.Tag = dr;

                    if (dr["DateStartTKP"].ToString()!="") 
                        DGVR.Cells["DateStartTKP"].Value = UI.GetDate(dr["DateStartTKP"].ToString());

                    if (dr["DateFinishTKP"].ToString()!="")
                        DGVR.Cells["DateFinishTKP"].Value = UI.GetDate(dr["DateFinishTKP"].ToString());

                    if (dr["Mail_Note"].ToString() != "")
                        DGVR.Cells["Note"].Value = dr["Mail_Note"].ToString();

                    if (dr["ID_OutDoc"].ToString() != "")
                        LoaDataOutDoc(DGVR, dr["ID_OutDoc"].ToString());

                    if (dr["ID_InpDoc"].ToString()!="")
                        LoaDataInpDoc(DGVR, dr["ID_InpDoc"].ToString());

                    //красим если получили ответ
                    SetSelBG(DGVR);

                    if (dr["UseTKP"].ToString() == "1")
                    {
                        //красим ячейку с рег номером входящего если использовали в сметах
                        SetBGUseTKP(DGVR);
                        CntUseTKP++;
                    }
                }

                if (DGV.Rows.Count > 0) DGV.Rows[0].Selected = true;
            }
        }
        
        /// <summary>
        /// Загрузка данных исходящего документа
        /// </summary>
        /// <param name="DGVR">Строка из DGV</param>
        /// <param name="IDDoc">ID исходящего документа</param>
        private void LoaDataOutDoc(DataGridViewRow DGVR, string IDDoc)
        {
            string SqlStr = "SELECT DocsOutput.Date_DocOut,  Orgs.Name AS Org,  DocsOutput.RN_DocOut, Orgs.Name_Br AS NB_Org, DocsOutput.PathToImage, DocsOutputRec.ID_Org";
            SqlStr += " FROM DocsOutput INNER JOIN DocsOutputRec ON  DocsOutput.ID_DocOut =  DocsOutputRec.ID_DocOut INNER JOIN";
            SqlStr += " Orgs ON  DocsOutputRec.ID_Org =  Orgs.ID_Org WHERE DocsOutput.ID_DocOut = " + IDDoc;

            var rs = DB.GetFields(SqlStr);
            if (rs != null)
                if (rs.Count>0)
                {
                    DataRow dr = rs[0];
                    DGVR.Cells["DateDocOut"].Value = UI.GetDate(dr["Date_DocOut"].ToString());
                    DGVR.Cells["Org"].Value = dr["Org"].ToString();
                    DGVR.Cells["Org"].Tag = dr["ID_Org"].ToString();
                    DGVR.Cells["RNDocOut"].Value = dr["RN_DocOut"].ToString();
                    
                    Hashtable Detail = new Hashtable();
                    Detail.Add("IDDoc", IDDoc);
                    Detail.Add("PathToImage", dr["PathToImage"].ToString());
                    DGVR.Cells["RNDocOut"].Tag = Detail;

                    DGVR.Cells["Contacts"].Value = LoadDataOrg(dr["ID_Org"].ToString());
                }
        }

        /// <summary>
        /// Загрузка данных входящего документа
        /// </summary>
        /// <param name="DGVR">Строка из DGV</param>
        /// <param name="IDDoc">ID входящего документа</param>
        private void LoaDataInpDoc(DataGridViewRow DGVR, string IDDoc)
        {
            var rs = DB.GetFields("SELECT RN_DocInp, Date_DocInp, PathToImage FROM  DocsInput WHERE ID_DocInp = " + IDDoc);
            if (rs != null)
                if (rs.Count > 0)
                {
                    DataRow dr = rs[0];

                    DGVR.Cells["DateDocInp"].Value = UI.GetDate(dr["Date_DocInp"].ToString());
                    DGVR.Cells["RNDocInp"].Value = dr["RN_DocInp"].ToString();

                    Hashtable Detail = new Hashtable();
                    Detail.Add("IDDoc", IDDoc);
                    Detail.Add("PathToImage", dr["PathToImage"].ToString());
                    DGVR.Cells["RNDocInp"].Tag = Detail;

                    if ( DGVR.Cells["DateStartTKP"].Value == null)
                        DGVR.Cells["DateStartTKP"].Value = UI.GetDate(dr["Date_DocInp"].ToString());

                    if ( DGVR.Cells["DateFinishTKP"].Value == null)
                        DGVR.Cells["DateFinishTKP"].Value = UI.GetDate(Convert.ToDateTime(dr["Date_DocInp"]).AddMonths(6).ToString());
                }
        }

        /// <summary>
        /// Загрузка контактов
        /// </summary>
        /// <param name="Org">Наименование организации</param>
        /// <returns>Возвращает строку "Контакты"</returns>
        private string LoadDataOrg(string Org)
        {
            var rs = LocalDB.LoadData("SELECT Contacts FROM КонтрольТКП_Контакты WHERE ID_Org = " + Org);
            if (rs != null)
                if (rs.Count>0) return rs[0]["Contacts"].ToString();
            return "";
        }

        /// <summary>
        /// Загрузка плановой даты передачи заказчику из Плана ПИР
        /// </summary>
        /// <param name="IDP">ID проекта</param>
        /// <returns>Дата</returns>
        private string LoaDatePZakPlan(string IDP)
        {
            string SqlStr = "SELECT PIRPlan.DatePZakPlan";
            SqlStr += " FROM Dogovors INNER JOIN";
            SqlStr += " DogovorsProjects ON Dogovors.ID_Dog = DogovorsProjects.ID_Dog INNER JOIN";
            SqlStr += " PIRPlan ON Dogovors.ID_RecPIRPlan = PIRPlan.ID_Rec";
            SqlStr += string.Format(" WHERE DogovorsProjects.ID_Project = {0}", IDP);

            var rs = DB.GetFields(SqlStr);
            if (rs != null)
                if (rs.Count > 0)
                    return rs[0]["DatePZakPlan"].ToString();

            return "";
        }

        /// <summary>
        /// Установка фона строки документа
        /// </summary>
        /// <param name="DGVR">Строка из DGV</param>
        private void SetSelBG(DataGridViewRow DGVR)
        {
            string StatusDoc = ((DataRow)DGVR.Tag)["StatusDoc"].ToString();

            foreach (DataGridViewCell dgvc in DGVR.Cells)
            {
                //обновление цвета статуса
                if (dgvc.Style.BackColor != UI.bgUseTKP)
                {
                    if (StatusDoc == "0")
                        dgvc.Style.BackColor = UI.bgStatusDocInp0;
                    else if (StatusDoc == "1")
                        dgvc.Style.BackColor = UI.bgStatusDocInp1;
                    else if (StatusDoc == "2")
                        dgvc.Style.BackColor = UI.bgStatusDocInp2;
                    else
                        dgvc.Style.BackColor = Color.White;

                    dgvc.Style.SelectionBackColor = dgvc.Style.BackColor;
                }

                dgvc.Style.SelectionForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Установка фона для документа используемого в сметах
        /// </summary>
        /// <param name="DGVR">Строка из DGV</param>
        /// <param name="mean">параметр использования документа</param>
        private void SetBGUseTKP(DataGridViewRow DGVR, byte mean = 0)
        {
            if (mean == 0)
            {
                DGVR.Cells[3].Style.BackColor = UI.bgUseTKP;
                DGVR.Cells[3].Style.SelectionBackColor = UI.bgUseTKP;
            }
            else
            {
                DGVR.Cells[3].Style.BackColor = DGVR.Cells[1].Style.BackColor;
                DGVR.Cells[3].Style.SelectionBackColor = DGVR.Cells[1].Style.SelectionBackColor;
            }
        }

        /// <summary>
        /// Открыть исходящий документ
        /// </summary>
        private void OpenOutDoc()
        {
            if (DGV.SelectedRows.Count == 0) return;

            if (DGV.SelectedRows[0].Cells["RNDocOut"].Tag != null)
                FTP.DonwloadFile(
                    ((Hashtable)DGV.SelectedRows[0].Cells["RNDocOut"].Tag)["PathToImage"].ToString());
        }

        /// <summary>
        /// Открыть входящий документ
        /// </summary>
        private void OpenInpDoc()
        {
            if (DGV.SelectedRows.Count == 0) return;

            if (DGV.SelectedRows[0].Cells["RNDocInp"].Tag != null)
                FTP.DonwloadFile(
                    ((Hashtable)DGV.SelectedRows[0].Cells["RNDocInp"].Tag)["PathToImage"].ToString());
        }

        /// <summary>
        /// Редактирование контактов
        /// </summary>
        private void EditContacts()
        {
            if (DGV.SelectedRows.Count > 0)
                if (DGV.SelectedRows[0].Cells["Org"].Tag != null)
                {
                    Contacts c = new Contacts();
                    c.ID_Org = DGV.SelectedRows[0].Cells["Org"].Tag.ToString();
                    c.ShowDialog();
                    if (c.flSave) DGV.SelectedRows[0].Cells["Contacts"].Value = c.Contact.Text;
                }
        }
        
        /// <summary>
        /// Редактирование примечания
        /// </summary>
        private void EditNote()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                Note n = new Note();
                n.ID_Doc = ((DataRow)DGV.SelectedRows[0].Tag)["ID"].ToString();
                n.ShowDialog();
                if (n.flSave) DGV.SelectedRows[0].Cells["Note"].Value = n.NoteTxt.Text;
            }
        }

        /// <summary>
        /// Сохранение изменений в карточке ТКП
        /// </summary>
        private void SaveChange()
        {
            if (ReadOnly) return;

            Dictionary<string, string> DS = new Dictionary<string, string>();

            if (OlSh.Tag != null)
            {
                if (OlSh.Tag.ToString() != OlSh.Text)
                    DS.Add("OlSh", OlSh.Text);
            }
            else
                if (OlSh.Text != "")
                    DS.Add("OlSh", OlSh.Text);

            if (Equipment.Tag != null)
            {
                if (Equipment.Tag.ToString() != Equipment.Text)
                    DS.Add("Equipment", Equipment.Text);
            }
            else
                if (Equipment.Text != "")
                    DS.Add("Equipment", Equipment.Text);


            if (DateEnd.Tag != null)
            {
                if (DateEnd.Tag.ToString() != DateEnd.Text)
                    DS.Add("DateEnd", DateEnd.Text);
            }
            else
                if (DateEnd.Text != "")
                    DS.Add("DateEnd", DateEnd.Text);


            if (DateOut.Tag != null)
            {
                if (DateOut.Tag.ToString() != DateOut.Text)
                    DS.Add("DateOut", DateOut.Text);
            }
            else
                if (DateOut.Text != "")
                    DS.Add("DateOut", DateOut.Text);


            if (DS.Count > 0)
            {
                LocalDB.UpdateData(DS, "КонтрольТКП", "ID_TKP = " + ID_TKP);
                FlSave = true;
            }
        }


        /// <summary>
        /// Связка документа с группой аналитического учета
        /// </summary>
        /// <param name="IDDOc">ID документа</param>
        /// <param name="TypeDoc">Тип документа</param>
        private void LinkGAU(string IDDOc, byte TypeDoc)
        {
            var rs = DB.GetFields("SELECT COUNT(*) as CntLink FROM LinksDocsA WHERE"
                                + "     ID_Doc = " + IDDOc
                                + " AND TDoc = " + TypeDoc.ToString()
                                + " AND ID_CA = " + TKP_Conf.ID_GAU);
            if (rs != null)
                if (rs[0][0].ToString() == "0")
                {
                    Dictionary<string, string> DS = new Dictionary<string, string>();
                    DS.Add("TDoc", TypeDoc.ToString());
                    DS.Add("ID_CA", TKP_Conf.ID_GAU);
                    DS.Add("ID_Doc", IDDOc);
                    DS.Add("ID_Worker", Params.UserInfo.ID_Worker);
                    DB.InsertRow(DS, "LinksDocsA");
                }
        }

        /// <summary>
        /// Связка документа с проектом
        /// </summary>
        /// <param name="IDDOc">ID документа</param>
        /// <param name="TypeDoc">Тип документа</param>
        private void LinkPrj(string IDDOc, byte TypeDoc)
        {
            var rs = DB.GetFields("SELECT COUNT(*) as CntLink FROM LinksDocs WHERE"
                                + "     ID_Doc = " + IDDOc
                                + " AND TDoc = " + TypeDoc.ToString()
                                + " AND ID_Project = " + ShPrj.Tag.ToString());
            if (rs != null)
                if (rs[0][0].ToString() == "0")
                {
                    Dictionary<string, string> DS = new Dictionary<string, string>();
                    DS.Add("TDoc", TypeDoc.ToString());
                    DS.Add("ID_Project", ShPrj.Tag.ToString());
                    DS.Add("ID_Doc", IDDOc);
                    DS.Add("ID_Worker", Params.UserInfo.ID_Worker);
                    DB.InsertRow(DS, "LinksDocs");
                }
        }

        /// <summary>
        /// Связка входящего документа с исходящим
        /// </summary>
        /// <param name="IDDOc">ID документа</param>
        /// <param name="TypeDoc">Тип документа</param>
        private void LinkDocsInpToOut(string IDDocInp, byte TypeDoc)
        {
            if (TypeDoc != 1) return;
            if (DGV.SelectedRows.Count == 0) return;
            if (DGV.SelectedRows[0].Cells["RNDocOut"].Value == null) return;

            Dictionary<string, string> DS = new Dictionary<string, string>();
            string IDDocOut = ((Hashtable)DGV.SelectedRows[0].Cells["RNDocOut"].Tag)["IDDoc"].ToString();

            //привязка исходящего к входящему!
            var rs = DB.GetFields("SELECT Count(*) as CntLink FROM DocsInputLink "
                                + " WHERE TDoc = 2 AND ID_DocInp = " + IDDocInp +
                                  " AND ID_Doc = " + IDDocOut);
            if (rs != null)
                if (rs[0][0].ToString() == "0")
                {
                    DS.Add("ID_DocInp", IDDocInp);
                    DS.Add("TDoc", "2");
                    DS.Add("ID_Doc", IDDocOut);
                    DS.Add("ID_Worker", Params.UserInfo.ID_Worker);
                    DB.InsertRow(DS, "DocsInputLink");
                }

            //привязка входящего к исходящему!
            rs = DB.GetFields("SELECT Count(*) as CntLink FROM DocsOutputLink "
                                + " WHERE TDoc = 1 AND ID_DocOut = " + IDDocOut +
                                  " AND ID_Doc = " + IDDocInp);
            if (rs != null)
                if (rs[0][0].ToString() == "0")
                {
                    DS = new Dictionary<string, string>();
                    DS.Add("ID_DocOut", IDDocOut);
                    DS.Add("TDoc", "1");
                    DS.Add("ID_Doc", IDDocInp);
                    DS.Add("ID_Worker", Params.UserInfo.ID_Worker);
                    DB.InsertRow(DS, "DocsOutputLink");
                }


        }


        /// <summary>
        /// Установка статуса Карточки запроса ТКП
        /// </summary>
        /// <param name="status">статус запроса</param>
        private void setStatus(string status)
        {
            Dictionary<string, string> DS = new Dictionary<string, string>();
            DS.Add("Status", status);

            СтатусВРаботе.Checked = false;
            СтатусВыполнено.Checked = false;
            СтатусОтменено.Checked = false;
            СтатусНеАктуально.Checked = false;

            if (status == "0")
            {
                DS.Add("DateEnd", "Null");
                СтатусВРаботе.Checked = true;
                Status.Text = "В работе";
                Status.Tag = 0;
                DateEnd.Text = "-";
            }
            else if (status == "1")
            {
                DS.Add("DateEnd", DateTime.Now.ToString());
                СтатусВыполнено.Checked = true;
                Status.Text = "Выполнено";
                Status.Tag = 1;
                DateEnd.Text = UI.GetDate(DateTime.Now.ToString());
            }
            else if (status == "2")
            {
                СтатусОтменено.Checked = true;
                Status.Text = "Отменено";
                Status.Tag = 2;
                DateEnd.Text = "-";
            }
            else if (status == "3")
            {
                СтатусНеАктуально.Checked = true;
                Status.Text = "Не актуально";
                Status.Tag = 3;
                DateEnd.Text = "-";
            }

            LocalDB.UpdateData(DS, "КонтрольТКП", " ID_TKP = " + ID_TKP);
            FlSave = true;
        }

        /// <summary>
        /// Установка статуса документа
        /// </summary>
        /// <param name="DGVR">Строка из DGV</param>
        /// <param name="status">статус документа</param>
        private void setStatusDoc(DataGridViewRow DGVR, string status)
        {
            if (status == "") status = "-1";
            Dictionary<string, string> DS = new Dictionary<string, string>();
            DS.Add("StatusDoc", status);

            //обновляем базу
            LocalDB.UpdateData(DS, "КонтрольТКП_Письма", " ID = " + ((DataRow)DGVR.Tag)["ID"].ToString());

            //обновляем статус в деталях письма
            ((DataRow)DGVR.Tag)["StatusDoc"] = status;
            UpdateStatusDocMenu(DGVR);

            //обновляем фон
            SetSelBG(DGVR);

            FlSave = true;
        }

        /// <summary>
        /// Обновление чекбоксов в меню Статус документа
        /// </summary>
        /// <param name="DGVR"></param>
        private void UpdateStatusDocMenu(DataGridViewRow DGVR)
        {
            if (DGVR.Tag == null) return;

            статусПисьмаОтказ.Checked = false;
            статусПисьмаПоложительный.Checked = false;
            статусПисьмаУточнение.Checked = false;

            switch (((DataRow)DGVR.Tag)["StatusDoc"].ToString())
            {
                case "0":
                    статусПисьмаОтказ.Checked = true;
                    break;
                case "1":
                    статусПисьмаПоложительный.Checked = true;
                    break;
                case "2":
                    статусПисьмаУточнение.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// Добавление документа
        /// </summary>
        /// <param name="IDDoc">Ид документа</param>
        /// <param name="TypeDoc">
        /// 0 - исходящий
        /// 1 - входящий
        /// 2 - входящий без привязки к исходящему
        /// </param>
        private void AddDoc(string IDDoc, byte TypeDoc, string IDOrg)
        {
            Dictionary<string, string> DS = new Dictionary<string, string>();
            if (TypeDoc != 1)
            {
                DS.Add("ID_TKP", ID_TKP);
                if (TypeDoc == 0)
                {
                    DS.Add("ID_OutDoc", IDDoc);
                    DS.Add("ID_OrgOut", IDOrg);
                }
                else
                {
                    DS.Add("ID_InpDoc", IDDoc);
                    DS.Add("ID_OrgInp", IDOrg);
                }
                LocalDB.InsertData(DS, "КонтрольТКП_Письма");
                LoadDataDocs();
            }
            else
            {
                //входящий:
                string ID_DocTkp = ((DataRow)DGV.SelectedRows[0].Tag)["ID"].ToString();
                DS.Add("ID_InpDoc", IDDoc);
                DS.Add("ID_OrgInp", IDOrg);
                LocalDB.UpdateData(DS, "КонтрольТКП_Письма", "ID = " + ID_DocTkp);
                
                //связка документов между собой
                LinkDocsInpToOut(IDDoc, TypeDoc);

                LoadDataDocs();
                if (DGV.Rows.Count > 0)
                    foreach (DataGridViewRow dgvr in DGV.Rows)
                        //if (ID_DocTkp == dgvr.Tag.ToString())
                        if (ID_DocTkp == ((DataRow)dgvr.Tag)["ID"].ToString())
                        {
                            DGV.ClearSelection();
                            dgvr.Selected = true;
                            break;
                        }
            }

            //Типы документов для привязки в ССПД
            if (TypeDoc == 0)
                TypeDoc = 2;
            else TypeDoc = 1;

            //привязка к ГАУ:
            LinkGAU(IDDoc, TypeDoc);

            //привязка к проекту
            LinkPrj(IDDoc, TypeDoc);
                   
            //добавление организации в локальный справочник
            Orgs.addOrg(IDOrg);
        }

        /// <summary>
        /// Фильтр по списку оборудования
        /// </summary>
        /// <param name="fValue"></param>
        private void doFilterEq(string fValue)
        {
            lbEq.Items.Clear();

            if (drEq == null) return;

            foreach (DataRow dr in drEq)
            {
                if (dr[0].ToString().ToLower().IndexOf(fValue) > -1)
                    lbEq.Items.Add(dr[0].ToString());
            }
            if (lbEq.Items.Count > 0)
            {
                if (lbEq.Items.Count < 16)
                    lbEq.Size = new Size(lbEq.Size.Width, lbEq.ItemHeight * (lbEq.Items.Count + 1));
                else
                    lbEq.Size = new Size(lbEq.Size.Width, lbEq.ItemHeight * 16);

                lbEq.Visible = true;
            }
            else
                lbEq.Visible = false;

        }

        /// <summary>
        /// Выбор из списка оборудования
        /// </summary>
        private void doSelectEq()
        {
            Equipment.Text = lbEq.SelectedItem.ToString();
            lbEq.Visible = false;
        }

        /// <summary>
        /// Выбор категории МТР
        /// </summary>
        private void SelectMTR()
        {
            Dictionary<string, string> DS = new Dictionary<string, string>();
            if (SelMTR.Text != "очистить")
            {
                ListMTR MTR = new ListMTR();
                MTR.mean = 1;
                MTR.ShowDialog();
                if (MTR.FlSel)
                {
                    MTRCode.Text = MTR.SelItem["Code"].ToString();

                    DS.Add("ID_MTR", MTR.SelItem["ID_Rec"].ToString());
                    LocalDB.UpdateData(DS, "КонтрольТКП", "ID_TKP = " + ID_TKP);

                    SelMTR.Text = "очистить";
                }
            }
            else
            {
                if (MessageBox.Show("Очистить группу МТР?", "Карточка ТКП", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DS.Add("ID_MTR", "0");
                    LocalDB.UpdateData(DS, "КонтрольТКП", "ID_TKP = " + ID_TKP);
                    MTRCode.Text = "";
                    SelMTR.Text = "выбрать";
                }
            }
        }

        /// <summary>
        /// Экспорт карточки в Excel
        /// </summary>
        private void ExportCard()
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet wbs = wb.Worksheets.get_Item(1);

            Excel.Range range = wbs.UsedRange;

            try
            {

                string strtmp = "";

                strtmp = "№" + NumZad.Text + " от " + ZadDate.Text + "\n";
                strtmp += "Выдал: " + OtdelZad.Text + ", " + FIOZad.Text + "\n";
                strtmp += ZadNote.Text;
                (range.Cells[1, 1] as Excel.Range).Value = "Задание: " + strtmp;
                (range.Cells[1, 7] as Excel.Range).Value = "Статус: " + Status.Text;

                strtmp = ShPrj.Text + "\n" + NamePrj.Text + "\n" + "ГИП: " + GIP.Text;
                (range.Cells[2, 1] as Excel.Range).Value = "Проект: " + strtmp;

                strtmp = Equipment.Text + "\n" + OlSh.Text;
                (range.Cells[3, 1] as Excel.Range).Value = "Оборудование: " + strtmp;

                for (int i = 0; i <= 6; i++)
                    (range.Cells[4, i + 1] as Excel.Range).Value = DGV.Columns[i].HeaderText;

                int c = 5;
                foreach (DataGridViewRow dgvr in DGV.Rows)
                {
                    for (int i = 0; i <= 6; i++)
                    {
                        if (dgvr.Cells[i].Value != null)
                            (range.Cells[c, i + 1] as Excel.Range).Value = dgvr.Cells[i].Value.ToString();
                    }
                    c++;
                }

                (range.Columns[1] as Excel.Range).ColumnWidth = 12;
                (range.Columns[2] as Excel.Range).ColumnWidth = 12;
                (range.Columns[3] as Excel.Range).ColumnWidth = 20;
                (range.Columns[4] as Excel.Range).ColumnWidth = 12;
                (range.Columns[5] as Excel.Range).ColumnWidth = 12;
                (range.Columns[6] as Excel.Range).ColumnWidth = 35;
                (range.Columns[7] as Excel.Range).ColumnWidth = 45;

                wbs.Range[wbs.Cells[1, 1], wbs.Cells[1, 6]].Merge();
                wbs.Range[wbs.Cells[2, 1], wbs.Cells[2, 7]].Merge();
                wbs.Range[wbs.Cells[3, 1], wbs.Cells[3, 7]].Merge();

                (range.Rows[1] as Excel.Range).RowHeight = 65;
                (range.Rows[2] as Excel.Range).RowHeight = 65;
                (range.Rows[3] as Excel.Range).RowHeight = 65;

                wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].WrapText = true;

                (wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].Font as Excel.Font).Size = 10;

                (wbs.Range[wbs.Cells[4, 1], wbs.Cells[4, 7]].Font as Excel.Font).Bold = true;
                wbs.Range[wbs.Cells[4, 1], wbs.Cells[4, 7]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                (wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = 1;
                (wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = 1;
                (wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = 1;
                (wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlEdgeRight].LineStyle = 1;
                (wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = 1;
                (wbs.Range[wbs.Cells[1, 1], wbs.Cells[c - 1, 7]].Borders as Excel.Borders).Item[Excel.XlBordersIndex.xlInsideVertical].LineStyle = 1;

                wbs.PageSetup.LeftMargin = 20;
                wbs.PageSetup.RightMargin = 20;
                wbs.PageSetup.TopMargin = 20;
                wbs.PageSetup.BottomMargin = 20;
                wbs.PageSetup.Zoom = false;
                wbs.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                wbs.PageSetup.FitToPagesTall = false;
                wbs.PageSetup.FitToPagesWide = 1;
                wbs.PageSetup.CenterHorizontally = true;
                wbs.PageSetup.PrintTitleRows = "$4:$4";
                wbs.PageSetup.LeftFooter = "&D &T";
                wbs.PageSetup.RightFooter = "&P из &N";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка экспорта!");
            }

            app.Visible = true;
        }

        /// <summary>
        /// Установка даты окончания действия ТКП у документа
        /// </summary>
        /// <param name="IDDoc">ID документа</param>
        /// <param name="FinishDate">Дата окончания действия</param>
        private void saveDateEndTKP(string IDDoc, string FinishDate)
        {
            Dictionary<string, string> DS = new Dictionary<string, string>();
            DS.Add("DateFinishTKP", FinishDate);
            LocalDB.UpdateData(DS, "КонтрольТКП_Письма", " ID = " + IDDoc);
        }

        /// <summary>
        /// !!!!!!!!!! Загрузка отметки  - ПРОВЕРИТЬ
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private bool LoadUseTKP(string ID)
        {
            var rs = LocalDB.LoadData("SELECT UseTKP FROM КонтрольТКП_Письма WHERE ID = " + ID);
            if (rs != null)
                if (rs[0][0].ToString() == "1")
                    return true;
            return false;
        }

        /// <summary>
        /// Установка отметки использования документа в сметах
        /// </summary>
        /// <param name="IDDoc">ID документа</param>
        /// <param name="FlUseTKP">Отметка</param>
        private void saveUseTKP(string IDDoc, byte FlUseTKP)
        {
            Dictionary<string, string> DS = new Dictionary<string, string>();
            DS.Add("UseTKP", FlUseTKP.ToString());
            LocalDB.UpdateData(DS, "КонтрольТКП_Письма", " ID = " + IDDoc);
        }

        /// <summary>
        /// Подсчет кол-ва документов
        /// </summary>
        private void setCountDocs()
        {
            CntDocOut = 0;
            CntDocInp = 0;
            CntTrueDoc = 0;
            CntCancelDoc = 0;
            CntRecDoc = 0;
            foreach (DataGridViewRow dgvr in DGV.Rows)
            {
                if (dgvr.Cells["RNDocOut"].Value != null)
                    CntDocOut++;

                if (dgvr.Cells["RNDocInp"].Value != null)
                    CntDocInp++;

                if (((DataRow)dgvr.Tag)["StatusDoc"].ToString() == "0")
                    CntCancelDoc++;
                else if (((DataRow)dgvr.Tag)["StatusDoc"].ToString() == "1")
                    CntTrueDoc++;
                else if (((DataRow)dgvr.Tag)["StatusDoc"].ToString() == "2")
                    CntRecDoc++;
            }
        }


        private void Card_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void заданияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTP.DonwloadFile(PathFZad,NumZad.Text);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Card_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveChange();
            setCountDocs();
        }

        private void исходящегоПисьмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOutDoc();
        }
        
        private void входящегоПисьмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenInpDoc();
        }

        private void СтатусВРаботе_Click(object sender, EventArgs e)
        {
            setStatus("0");
        }

        private void СтатусВыполнено_Click(object sender, EventArgs e)
        {
            setStatus("1");
        }

        private void отмененоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setStatus("2");
        }

        #region [Рамка выделенной строки]

        private void DGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (DGV.Rows[e.RowIndex].Selected)
            {
                using (Pen pen = new Pen(Color.Navy))
                {
                    int penWidth = 2;

                    pen.Width = penWidth;
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                    int x = e.RowBounds.Left + (penWidth / 2)+1;
                    int y = e.RowBounds.Top + (penWidth / 2);
                    int width = e.RowBounds.Width - penWidth-1;
                    int height = e.RowBounds.Height - penWidth-1;

                    e.Graphics.DrawRectangle(pen, x, y, width, height);
                }
            }
        }

        #region [Фикс отображения выделения строки]

        private void reSelect()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                int IndSel = DGV.SelectedRows[0].Index;
                DGV.ClearSelection();
                DGV.Rows[IndSel].Selected = true;
            }
        }

        private void Card_SizeChanged(object sender, EventArgs e)
        {
            reSelect();
        }

        private void DGV_Scroll(object sender, ScrollEventArgs e)
        {
            reSelect();
        }

        #endregion

        #endregion

        private void редактироватьКонтактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContacts();
        }

        private void редактироватьПримечаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void добавитьИсходящийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectForm.ListDocsOut LDO = new SelectForm.ListDocsOut();
            LDO.ShowDialog();
            if (LDO.flSel)
                AddDoc(LDO.IDDoc, 0, LDO.IDOrg);
        }

        private void ответНаЗапросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 0) return;

            if (DGV.SelectedRows[0].Cells["RNDocInp"].Value != null)
                if (MessageBox.Show("Входящее письмо уже добавлено. Заменить?",
                    "Добавить ответ на запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No) return;

            SelectForm.ListDocsInp LDI = new SelectForm.ListDocsInp();
            LDI.ShowDialog();
            
            if (LDI.flSel)
                AddDoc(LDI.IDDoc, 1, LDI.IDOrg);
        }

        private void безЗапросаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectForm.ListDocsInp LDI = new SelectForm.ListDocsInp();
            LDI.ShowDialog();
            if (LDI.flSel)
                AddDoc(LDI.IDDoc, 2, LDI.IDOrg);
        }

        private void удалитьДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Удалить выбранный документ?","Удаление записи", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No) return;
            LocalDB.DeleteData("КонтрольТКП_Письма", "ID = " + ((DataRow)DGV.SelectedRows[0].Tag)["ID"].ToString());
            LoadDataDocs();
        }

        private void удалитьКарточкуТКПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить карточку ТКП?", "Удаление карточки ТКП",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No) return;

            LocalDB.DeleteData("КонтрольТКП_Письма", "ID_TKP = " + ID_TKP);
            LocalDB.DeleteData("КонтрольТКП", "ID_TKP = " + ID_TKP);

            FlDelete = true;
            this.Close();
        }

        private void приложениеКЗаданиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PathFZadPril == "")
                MessageBox.Show("Приложение отсутствует", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                FTP.DonwloadFile(PathFZadPril);
        }

        private void ихсодящийДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOutDoc();
        }

        private void входящийДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenInpDoc();
        }

        private void примечаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void контактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContacts();
        }

        private void SelMTR_Click(object sender, EventArgs e)
        {
            SelectMTR();
        }

        private void Equipment_TextChanged(object sender, EventArgs e)
        {
            if (Equipment.Text.Trim().Length > 1)
                doFilterEq(Equipment.Text.ToLower());
            else
                lbEq.Visible = false;
        }

        private void Equipment_Leave(object sender, EventArgs e)
        {
            //lbEq.Visible = false;
        }

        private void lbEq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            doSelectEq();
        }

        private void lbEq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) lbEq.Visible = false;
            if (e.KeyCode == Keys.Enter) doSelectEq();
        }

        private void btnSelEq_Click(object sender, EventArgs e)
        {
            SelectForm.ListEquip LE = new SelectForm.ListEquip();
            LE.ShowDialog();
            if (LE.SelEq != "")
                Equipment.Text = LE.SelEq;
        }

        private void экспортДанныхВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportCard();
        }

        private void DateEnd_DoubleClick(object sender, EventArgs e)
        {
            if (СтатусВыполнено.Checked == true)
            {
                SelectForm.SelectDate SD = new SelectForm.SelectDate();
                SD.Top = MousePosition.Y - SD.Height / 2;
                SD.Left = MousePosition.X - SD.Width / 2;
                SD.mCalendar.MaxSelectionCount = 1;
                SD.mCalendar.SetDate(Convert.ToDateTime(DateEnd.Text));
                SD.ShowDialog();
                
                if (SD.flSel)
                    DateEnd.Text = UI.GetDate(SD.SelDate.ToString());

                SD.Dispose();
            }
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ReadOnly) return;

            if (e.RowIndex > -1 && e.ColumnIndex == 8 && DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                SelectForm.SelectDate SD = new SelectForm.SelectDate();
                SD.Top = MousePosition.Y - SD.Height / 2;
                SD.Left = MousePosition.X - SD.Width / 2;
                SD.mCalendar.MaxSelectionCount = 1;
                SD.mCalendar.SetDate(Convert.ToDateTime(DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                SD.ShowDialog();
                if (SD.flSel)
                {
                    string selDate = SD.SelDate.ToString();
                    DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = UI.GetDate(selDate);
                    saveDateEndTKP(DGV.Rows[e.RowIndex].Tag.ToString(), selDate);
                }
            }
        }

        private void btnUseTKP_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 0) return;

            if (DGV.SelectedRows[0].Cells["RNDocInp"].Tag != null)
            {
                if (btnUseTKP.Checked == false)
                {
                    saveUseTKP(((DataRow)DGV.SelectedRows[0].Tag)["ID"].ToString(), 1);
                    btnUseTKP.Checked = true;
                    SetBGUseTKP(DGV.SelectedRows[0]);
                    CntUseTKP++;
                }
                else
                {
                    saveUseTKP(((DataRow)DGV.SelectedRows[0].Tag)["ID"].ToString(), 0);
                    btnUseTKP.Checked = false;
                    SetBGUseTKP(DGV.SelectedRows[0], 1);
                    CntUseTKP--;
                }

                FlSave = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (DGV.SelectedRows.Count != 0 && Params.UserInfo.ID_Otdel == TKP_Conf.SMIDOtdel)
            {
                btnUseTKP.Checked = LoadUseTKP(((DataRow)DGV.SelectedRows[0].Tag)["ID"].ToString()); //DGV.SelectedRows[0].Tag.ToString()
                btnUseTKP.Visible=true;
            } 
            else 
                btnUseTKP.Visible = false;
        }

        private void btnCardWorker_Click(object sender, EventArgs e)
        {
            CardWorker cw = new CardWorker();
            cw.IDW = FIOZad.Tag.ToString();
            cw.ShowDialog();
        }

        private void СтатусНеАктуально_Click(object sender, EventArgs e)
        {
            setStatus("3");
        }

        private void DateOut_DoubleClick(object sender, EventArgs e)
        {
            SelectForm.SelectDate SD = new SelectForm.SelectDate();
            SD.Top = MousePosition.Y - SD.Height / 2;
            SD.Left = MousePosition.X - SD.Width / 2;
            SD.mCalendar.MaxSelectionCount = 1;

            if (DateOut.Text.Length != 0)
                SD.mCalendar.SetDate(Convert.ToDateTime(DateOut.Text));
            else
                SD.mCalendar.SetDate(DateTime.Now);
            
            SD.ShowDialog();

            if (SD.flSel)
                DateOut.Text = UI.GetDate(SD.SelDate.ToString());

            SD.Dispose();
        }

        private void DateOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DateOut.Text = "";
        }

        private void статусПисьмаПоложительный_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 0) return;

            if (((ToolStripMenuItem)sender).Checked)
                setStatusDoc(DGV.SelectedRows[0], "");
            else
                setStatusDoc(DGV.SelectedRows[0], "1");
        }

        private void статусПисьмаУточнение_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 0) return;

            if (((ToolStripMenuItem)sender).Checked)
                setStatusDoc(DGV.SelectedRows[0], "");
            else
                setStatusDoc(DGV.SelectedRows[0], "2");
        }

        private void статусПисьмаОтказ_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 0) return;

            if (((ToolStripMenuItem)sender).Checked)
                setStatusDoc(DGV.SelectedRows[0], "");
            else
                setStatusDoc(DGV.SelectedRows[0], "0");
            
        }

        /// <summary>
        /// Определение статуса входящего письма
        /// </summary>
        private void DGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            UpdateStatusDocMenu(DGV.Rows[e.RowIndex]);
        }


    }
}
