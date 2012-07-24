using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SSPD
{
    public partial class WorkersSpravCard : Form
    {
        //ID сотрудника
        public string IDW = "";
        //флаг успешного сохранения данных
        public bool FlSave = false;

        //указатели для сохранения данных
        private bool doSaveDetails = false;
        private bool doSavePhones = false;
        private bool doSaveFoto = false;

        //массив табов
        private TabPage[] myTabPage = null;

        public WorkersSpravCard(string IDWorker)
        {
            InitializeComponent();

            //события:
            this.KeyDown +=new KeyEventHandler(WorkersSpravCard_KeyDown);
            Foto.MouseDoubleClick +=new MouseEventHandler(Foto_MouseDoubleClick);
            //----
            if (IDWorker != null) IDW = IDWorker;
        }


        private void WorkersSpravCard_Load(object sender, EventArgs e)
        {

            //сохраняем закладки в массив
            myTabPage = new TabPage[tabControl1.TabPages.Count];
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
                myTabPage[i] = tabControl1.TabPages[i];

            //Должности
            LoadNPost();
            //Отделы
            LoadOtdels();
            //Статусы
            SetStatus();

            if (IDW != "")
            { //редактирование карточки
                //статус
                LoadStatus();
                //основные сведения
                LoadMainDetails();

                if (Params.UserInfo.RightUser.ToUpper() == "ADMINKADR")
                {
                    //удаляем вкладки
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                }
                else
                {
                    //телефоны
                    LoadPhones();
                    //сеть
                    LoadNetSettings();
                }

                ViewFoto();

                doSaveDetails = false;
                doSaveFoto = false;
                doSavePhones = false;
            }
            else
            { // новый сотрудник
                ID_WorkerLabel.Visible = false;
                ID_Worker.Visible = false;
                Foto.Visible = false;
                FotoAdd.Visible = false;
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
            } 
        }

        private void WorkersSpravCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close(); 
            if (e.KeyCode == Keys.F2) SaveCard();
        }


        private void SaveCard()
        {
            if (CheckFields() == false) return;

            Dictionary<string, string> DataSet;

            if (doSaveDetails == true)
            {   //основные данные:
                DataSet = new Dictionary<string, string>();
                DataSet.Add("F_Worker", FWorker.Text);
                DataSet.Add("N_Worker", NWorker.Text);
                DataSet.Add("P_Worker", PWorker.Text);
                DataSet.Add("I_Worker", IWorker.Text);
                DataSet.Add("ID_Post", ((SSPDUI.ComboType)Posts.SelectedItem).ID_Item.ToString());
                DataSet.Add("ID_Otdel", ((SSPDUI.ComboType)Otdel.SelectedItem).ID_Item.ToString());
                DataSet.Add("Fl_Rel", Status.SelectedIndex.ToString());
                DataSet.Add("PersonIndexDP", IndexDP.Text);
                DataSet.Add("Login", Login.Text);   //сетевые настройки:
                if (IDW != "")
                    //обновляем основные данные
                    DB.SetFields(DataSet, "Workers", "ID_Worker = " + IDW);
                else
                {
                    //новый сотрудник
                    var rs = DB.GetFields("SELECT MAX(ID_Worker) + 1 AS NewID From Workers");
                    IDW =(Convert.ToInt32(rs[0]["NewID"]) + 1).ToString();
                    DataSet.Add("ID_Worker", IDW);
                    DB.InsertRow(DataSet, "Workers");
                    if (Params.UserInfo.RightUser.ToUpper() != "ADMINKADR")
                    {
                        tabControl1.TabPages.Clear();
                        tabControl1.TabPages.AddRange(myTabPage);
                    }
                    Foto.Visible = true;
                    FotoAdd.Visible = true;
                    ID_Worker.Text = IDW;
                    ID_Worker.Visible = true;
                    ID_WorkerLabel.Visible = true;
                    return;
                }
                doSaveDetails = false;
            }

            if (doSavePhones == true)
            {   //телефоны:
                //если имеются данные о выбранном IP Phone у других сотрудников, очищаем
                if (IPPhoneNamber.Tag != null)
                {
                    if (IPPhoneNamber.Tag.ToString() != "0")
                    {
                        DataSet = new Dictionary<string, string>();
                        DataSet.Add("ID_IPPhone", "");
                        DB.SetFields(DataSet, "WorkersExt", "ID_IPPhone = " + IPPhoneNamber.Tag.ToString());
                    }
                }
                //удаление записи сотрудника из таблицы WorkersExt
                DB.DeleteRow("WorkersExt", "ID_Worker = " + IDW);
                //сохраняем данные телефонов
                if (PhoneInnerM.Tag != null || PhoneInnerA.Tag != null || IPPhoneNamber.Tag != null)
                {
                    DataSet = new Dictionary<string, string>();
                    DataSet.Add("ID_Worker", IDW);

                    if (PhoneInnerM.Tag == null)
                    {
                        if (PhoneInnerA.Tag != null) DataSet.Add("PhoneInner", PhoneInnerA.Tag.ToString());
                    }
                    else
                    {
                        if (PhoneInnerM.Tag != null) DataSet.Add("PhoneInner", PhoneInnerM.Tag.ToString());
                        if (PhoneInnerA.Tag != null) DataSet.Add("PhoneInnerAdd", PhoneInnerA.Tag.ToString());
                    }
                    if (IPPhoneNamber.Tag != null) DataSet.Add("ID_IPPhone", IPPhoneNamber.Tag.ToString());
                    DB.InsertRow(DataSet, "WorkersExt");
                }
                doSavePhones = false;
            }


            //фотография
            if (doSaveFoto == true)
            {
                if (Foto.Image==Foto.ErrorImage)
                {
                    DB.DeleteRow("WorkersPhoto", "ID_Worker = " + IDW);
                }
                else
                {
                    byte[] imageArray;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        //сохраняем изображение в массив байтов
                        Foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageArray = ms.ToArray();
                    }

                    var rs = DB.GetFields("SELECT ID_Worker, Photo_Worker From WorkersPhoto Where ID_Worker = " + IDW);
                    if (rs.Count > 0)
                    {
                        //обновление
                        DB.SetByteField(imageArray, "WorkersPhoto", "Photo_Worker", "ID_Worker = " + IDW);
                    }
                    else
                    {
                        //создание
                        DataSet = new Dictionary<string, string>();
                        DataSet.Add("ID_Worker", IDW);
                        DB.InsertByteRow(DataSet, imageArray, "Photo_Worker", "WorkersPhoto");
                    }
                }
                doSaveFoto = false;
            }

            FlSave = true;
            this.Close();
        }


        /// <summary>
        /// Проверка заполнения обязательных полей
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            if (FWorker.Text.Length == 0)
            {
                SSPDUI.MsgEx("Не указана фамилия сотрудника", "Остановка сохранения");
                tabControl1.SelectedTab = tabPage1;
                FWorker.Focus();
                return false;
            } else if (NWorker.Text.Length == 0) {
                SSPDUI.MsgEx("Не указано имя сотрудника", "Остановка сохранения");
                tabControl1.SelectedTab = tabPage1;
                NWorker.Focus();
                return false;
            }
            else if (IWorker.Text.Length == 0)
            {
                SSPDUI.MsgEx("Не указаны инициалы сотрудника", "Остановка сохранения");
                tabControl1.SelectedTab = tabPage1;
                IWorker.Focus();
                return false;
            }
            else if (Otdel.SelectedIndex == -1)
            {
                SSPDUI.MsgEx("Не выбран отдел", "Остановка сохранения");
                tabControl1.SelectedTab = tabPage1;
                Otdel.Focus();
                return false;
            }
            else if (Posts.SelectedIndex == -1)
            {
                SSPDUI.MsgEx("Не выбрана должность сотрудника", "Остановка сохранения");
                tabControl1.SelectedTab = tabPage1;
                Posts.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Загрузка сетевых настроек
        /// </summary>
        private void LoadNetSettings()
        {
            var rs = DB.GetFields("SELECT Login From Workers Where ID_Worker = " + IDW);
            if (rs.Count == 0) return;
            DataRow dr = rs[0];
            Login.Text = dr["Login"].ToString();
        }

        /// <summary>
        /// Загрузка телефонных номеров
        /// </summary>
        private void LoadPhones()
        {
            string SqlStr = "SELECT dbo.Workers.ID_Worker, dbo.Workers.F_Worker, dbo.Workers.N_Worker, dbo.Workers.P_Worker, dbo.Otdels.NB_Otdel, dbo.Otdels.Name_Otdel,"
                            + " dbo.Posts.N_Post, PhoneInner.NamberPInner, PhoneTown.NamberPTown, PhoneMATS.NamberPMATS, PhoneGroup.NamberGroup,"
                            + " PhoneInner_1.NamberPInner AS NamberPInnerAdd, PhoneInner_1.ID_PTown, PhoneTown_1.NamberPTown AS NamberPTownAdd,"
                            + " PhoneMATS_1.NamberPMATS AS NamberPMATSAdd, PhoneGroup_1.NamberGroup AS NamberGroupAdd, PhoneInner.Room,"
                            + " PhoneInner_1.Room AS RoomAdd, PhoneTown.Input_Cross AS InputCrossTown, PhoneTown.ATS_Cross AS ATSCrossTown,"
                            + " PhoneMATS.Input_Cross AS InputCrossMATS, PhoneMATS.ATS_Cross AS ATSCrossMATS, PhoneTown_1.Input_Cross AS InputCrossTownAdd,"
                            + " PhoneTown_1.ATS_Cross AS ATSCrossTownAdd, PhoneMATS_1.Input_Cross AS InputCrossMATSAdd, PhoneMATS_1.ATS_Cross AS ATSCrossMATSAdd,"
                            + " PhoneInner.ID_PInner, PhoneInner_1.ID_PInner AS ID_PInnerAdd, dbo.WorkersExt.ID_IPPhone, dbo.PhoneIP.IPPhoneNamber"
                            + " FROM         dbo.PhoneIP RIGHT OUTER JOIN"
                            + " dbo.WorkersExt ON dbo.PhoneIP.ID_IPPhone = dbo.WorkersExt.ID_IPPhone LEFT OUTER JOIN"
                            + " dbo.PhoneInner PhoneInner_1 LEFT OUTER JOIN"
                            + " dbo.PhoneGroup PhoneGroup_1 ON PhoneInner_1.ID_PGroup = PhoneGroup_1.ID_PGroup LEFT OUTER JOIN"
                            + " dbo.PhoneMATS PhoneMATS_1 ON PhoneInner_1.ID_PMATS = PhoneMATS_1.ID_PMATS LEFT OUTER JOIN"
                            + " dbo.PhoneTown PhoneTown_1 ON PhoneInner_1.ID_PTown = PhoneTown_1.ID_PTown ON"
                            + " dbo.WorkersExt.PhoneInnerAdd = PhoneInner_1.ID_PInner LEFT OUTER JOIN"
                            + " dbo.PhoneInner LEFT OUTER JOIN"
                            + " dbo.PhoneGroup ON PhoneInner.ID_PGroup = PhoneGroup.ID_PGroup LEFT OUTER JOIN"
                            + " dbo.PhoneMATS ON PhoneInner.ID_PMATS = PhoneMATS.ID_PMATS LEFT OUTER JOIN"
                            + " dbo.PhoneTown ON PhoneInner.ID_PTown = PhoneTown.ID_PTown ON"
                            + " dbo.WorkersExt.PhoneInner = PhoneInner.ID_PInner RIGHT OUTER JOIN"
                            + " dbo.Workers INNER JOIN"
                            + " dbo.Otdels ON dbo.Workers.ID_Otdel = dbo.Otdels.ID_Otdel INNER JOIN"
                            + " dbo.Posts ON dbo.Workers.ID_Post = dbo.Posts.ID_Post ON dbo.WorkersExt.ID_Worker = dbo.Workers.ID_Worker"
                            + " Where (WorkersExt.ID_Worker = " + IDW + ")";
            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;
            DataRow dr = rs[0];

            PhoneInnerM.Tag = dr["ID_PInner"].ToString();
            PhoneInnerM.Text = dr["NamberPInner"].ToString();
            PhoneTownM.Text = dr["NamberPTown"].ToString();
            InputCrossTownM.Text = dr["InputCrossTown"].ToString();
            ATSCrossTownM.Text = dr["ATSCrossTown"].ToString();
            PhoneMATSM.Text = dr["NamberPMATS"].ToString();
            InputCrossMATSM.Text = dr["InputCrossMATS"].ToString();
            ATSCrossMATSM.Text = dr["ATSCrossMATS"].ToString();
            PhoneGroupM.Text = dr["NamberGroup"].ToString();

            if (dr["ID_PInnerAdd"].ToString().Length > 0)
            {
              PhoneInnerA.Tag = dr["ID_PInnerAdd"].ToString();
              PhoneInnerA.Text = dr["NamberPInnerAdd"].ToString();
              PhoneTownA.Text = dr["NamberPTownAdd"].ToString();
              InputCrossTownA.Text = dr["InputCrossTownAdd"].ToString();
              ATSCrossTownA.Text = dr["ATSCrossTownAdd"].ToString();
              PhoneMATSA.Text = dr["NamberPMATSAdd"].ToString();
              InputCrossMATSA.Text = dr["InputCrossMATSAdd"].ToString();
              ATSCrossMATSA.Text = dr["ATSCrossMATSAdd"].ToString();
              PhoneGroupA.Text = dr["NamberGroupAdd"].ToString();
            }

            IPPhoneNamber.Tag = dr["ID_IPPhone"].ToString();
            IPPhoneNamber.Text  = dr["IPPhoneNamber"].ToString();

            SqlStr = "SELECT PhoneMov.ID_Sim, PhoneSim.ANamber, PhoneMov.TUse"
                    + " FROM PhoneMov INNER JOIN"
                    + " PhoneSim ON PhoneMov.ID_Sim = PhoneSim.ID_Sim"
                    + " Where (PhoneMov.DateTimeInp Is Null) And (PhoneMov.ID_Worker = " + IDW + ")";
            rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;
            dr = rs[0];
            ANamber.Text = dr["ANamber"].ToString();
            TUse.Text = dr["TUse"].ToString() == "1" ? "Постоянно" : "Временно";

        }   


        /// <summary>
        /// Загрузка основных сведений сотрудника
        /// </summary>
        private void LoadMainDetails()
        {
            var rs = DB.GetFields("SELECT F_Worker, N_Worker, P_Worker, I_Worker, ID_Post, ID_Otdel, PersonIndexDP From Workers Where ID_Worker = " + IDW);
            if (rs.Count == 0) return;
            DataRow dr = rs[0];

            FWorker.Text = dr["F_Worker"].ToString();
            NWorker.Text = dr["N_Worker"].ToString();
            PWorker.Text = dr["P_Worker"].ToString();
            IWorker.Text = dr["I_Worker"].ToString();

            //выбор из списка отдел
            for (int i =0; i<Otdel.Items.Count;i++) {
                if (((SSPDUI.ComboType)Otdel.Items[i]).ID_Item == Convert.ToInt32(dr["ID_Otdel"]))
                { Otdel.SelectedIndex = i; break; }
            }
            //выбор из списка должности
            for (int i = 0; i < Posts.Items.Count; i++)
            {
                if (((SSPDUI.ComboType)Posts.Items[i]).ID_Item == Convert.ToInt32(dr["ID_Post"]))
                { Posts.SelectedIndex = i; break; }
            }

            //код сотрудника
            ID_Worker.Text = IDW;

            //персональный индекс делопроизводства
            IndexDP.Text = dr["PersonIndexDP"].ToString();
        }

        /// <summary>
        /// Установка статуса сотрудника
        /// </summary>
        private void LoadStatus()
        {
            var rs = DB.GetFields("SELECT Fl_Rel From Workers Where ID_Worker = " + IDW);
            if (rs.Count == 0) return;
            Status.SelectedIndex = Convert.ToInt32(rs[0]["Fl_Rel"].ToString());
        }


        /// <summary>
        /// Загрузка списка статусов
        /// </summary>
        private void SetStatus(){
            Status.Items.Add("Работает");
            Status.Items.Add("Уволен");
            Status.Items.Add("Командировка");
            Status.Items.Add("Отпуск");
            Status.Items.Add("Больничный");
            Status.Items.Add("Декрет");
            Status.Items.Add("Прочее");
            Status.SelectedIndex = 0;
        }

        /// <summary>
        /// Загрузка списка отделов
        /// </summary>
        private void LoadOtdels()
        {
            string SqlStr = "SELECT ID_Otdel, Name_Otdel From Otdels ORDER BY Name_Otdel";
            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;

            SSPDUI.ComboType CBItem;

            foreach (DataRow dr in rs)
            {
                CBItem = new SSPDUI.ComboType();
                CBItem.ID_Item = (int)dr["ID_Otdel"];
                CBItem.Name_Item = dr["Name_Otdel"].ToString();
                Otdel.Items.Add(CBItem);
            }
        }


        /// <summary>
        /// Загрузка списка должностей
        /// </summary>
        private void LoadNPost()
        {
            string SqlStr = "SELECT ID_Post, N_Post From Posts ORDER BY N_Post";
            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;

            SSPDUI.ComboType CBItem;

            foreach (DataRow dr in rs)
            {
                CBItem = new SSPDUI.ComboType();
                CBItem.ID_Item = (int)dr["ID_Post"];
                CBItem.Name_Item = dr["N_Post"].ToString();
                Posts.Items.Add(CBItem);
            }
        }


        /// <summary>
        /// Запись в файла фотографии и показ на форме
        /// </summary>
        private void ViewFoto()
        {
            FotoDelete.Visible = false;
            var rs = DB.GetFields("SELECT ID_Worker, Photo_Worker From WorkersPhoto Where ID_Worker = " + IDW);
            if (rs.Count == 0) return;
            DataRow dr = rs[0];
            var arrByte = (byte[])dr["Photo_Worker"];

            using (MemoryStream ms = new MemoryStream(arrByte, 0, arrByte.Length))
            {
                ms.Write(arrByte, 0, arrByte.Length);
                Foto.Image = Image.FromStream(ms, true);
                FotoAdd.Text = "изменить фотографию";
                FotoDelete.Visible = true;
            }
        }


        /// <summary>
        /// Выбор фотографии
        /// </summary>
        private void SetFoto()
        {
            OpenFileDialog OFD = new OpenFileDialog();

            OFD.Title = "Файл с фотографией сотрудника";
            OFD.Filter = "Изображение JPG (размер 175х130)|*.jpg;*.jpeg";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                //превью:
                Image image = Image.FromFile(OFD.FileName);
                Image thumb = image.GetThumbnailImage(260, 350, () => false, IntPtr.Zero);
                thumb.Save(Path.ChangeExtension(OFD.FileName, "thumb"));

                Foto.Image = thumb;
                FotoAdd.Text = "изменить фотографию";
                FotoDelete.Visible = true;
                doSaveFoto = true;
            }

        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FotoAdd_Click(object sender, EventArgs e)
        {
            SetFoto();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            SaveCard();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCard();
        }

        private void FWorker_TextChanged(object sender, EventArgs e)
        {
            doSaveDetails = true;
        }

        private void NWorker_TextChanged(object sender, EventArgs e)
        {
            doSaveDetails = true;
        }

        private void PWorker_TextChanged(object sender, EventArgs e)
        {
            doSaveDetails = true;
        }

        private void IWorker_TextChanged(object sender, EventArgs e)
        {
            doSaveDetails = true;
        }

        private void Otdel_SelectedIndexChanged(object sender, EventArgs e)
        {
            doSaveDetails = true;
        }

        private void Posts_SelectedIndexChanged(object sender, EventArgs e)
        {
            doSaveDetails = true;
        }

        private void Status_Click(object sender, EventArgs e)
        {
            doSaveDetails = true;
        }

        private void IndexDP_TextChanged(object sender, EventArgs e)
        {
            doSaveDetails = true;
        }

        private void Login_TextChanged(object sender, EventArgs e)
        {
            doSaveDetails = true;
        }


        private void FotoDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить фотографию сотрудника?", "Удаление фотографии", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No) return;
            Foto.Image = Foto.ErrorImage;
            Foto.ImageLocation = null;
            FotoAdd.Text = "добавить фотографию";
            FotoDelete.Visible = false;
            doSaveFoto = true;
        }

        private void Foto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetFoto();
        }

        private void WorkersSpravCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (doSaveDetails == true || doSaveFoto == true || doSavePhones == true)
            {
                if (MessageBox.Show("Сохранить изменения?", "Карточка работника", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SaveCard();
                    this.Close();
                }
            }
        }

        private void AddPhoneInner_Click(object sender, EventArgs e)
        {
            PhoneInnerList PIL = new PhoneInnerList(true);
            PIL.ShowDialog();
            if (PIL.SelID != "")
            {
                  PhoneInnerM.Tag = PIL.SelID;
                  PhoneInnerM.Text  = PIL.SelPhoneInner;
                  PhoneTownM.Text  = PIL.SelPhoneTown;
                  PhoneMATSM.Text  = PIL.SelPhoneMATS;
                  PhoneGroupM.Text = PIL.SelPhoneGroup;
                  doSavePhones = true;
            }
        }


        private void DelPhoneInn_Click(object sender, EventArgs e)
        {
            PhoneInnerM.Tag = 0;
            PhoneInnerM.Text = "";
            PhoneTownM.Text = "";
            PhoneMATSM.Text = "";
            PhoneGroupM.Text = "";
            doSavePhones = true;
        }

        private void DelPhoneInnerA_Click(object sender, EventArgs e)
        {
            PhoneInnerA.Tag = 0;
            PhoneInnerA.Text = "";
            PhoneTownA.Text = "";
            PhoneMATSA.Text = "";
            PhoneGroupA.Text = "";
            doSavePhones = true;
        }

        private void AddPhoneInnerA_Click(object sender, EventArgs e)
        {
            PhoneInnerList PIL = new PhoneInnerList(true);
            PIL.ShowDialog();
            if (PIL.SelID != "")
            {
                PhoneInnerA.Tag = PIL.SelID;
                PhoneInnerA.Text = PIL.SelPhoneInner;
                PhoneTownA.Text = PIL.SelPhoneTown;
                PhoneMATSA.Text = PIL.SelPhoneMATS;
                PhoneGroupA.Text = PIL.SelPhoneGroup;
                doSavePhones = true;
            }
        }

        private void DelIPPhone_Click(object sender, EventArgs e)
        {
            IPPhoneNamber.Tag = "";
            IPPhoneNamber.Text  = "";
            doSavePhones = true;
        }

        private void AddIPPhone_Click(object sender, EventArgs e)
        {
            PhoneIPList PIPL = new PhoneIPList();
            PIPL.ShowDialog();
            if (PIPL.SelIDIPPhone.Length > 0)
            {
                IPPhoneNamber.Tag = PIPL.SelIDIPPhone;
                IPPhoneNamber.Text = PIPL.SelIPPhone;
                doSavePhones = true;
            }
        }



    }
}
