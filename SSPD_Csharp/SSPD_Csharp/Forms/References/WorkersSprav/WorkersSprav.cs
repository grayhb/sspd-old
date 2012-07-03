using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;



namespace SSPD
{


    public partial class WorkersSprav : Form
    {
        //флаг поиска
        private bool FlSearchStop = true;
        //индекс последнего найденного работника
        private int IndexFind=-1;
        //количество работников
        private int CntAllWorkers;

        public WorkersSprav()
        {
            InitializeComponent();
            this.KeyDown +=new KeyEventHandler(WorkersSprav_KeyDown);
            this.Shown+=new EventHandler(WorkersSprav_Shown);
            StrFind.KeyDown +=new KeyEventHandler(StrFind_KeyDown);
            StrFind.GotFocus += new EventHandler(StrFind_GotFocus);
            StrFind.LostFocus += new EventHandler(StrFind_LostFocus);
        }

        private void WorkersSprav_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.F7) searchInTree(treeSGTP);
        }
        
        private void WorkersSprav_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CntAllWorkers = 0;
            LoadOtdels();
            
            StatusLabel.Text = "Всего отделов: " + treeSGTP.Nodes.Count.ToString() + "    " +
                                "Всего сотрудников: " + CntAllWorkers.ToString();
            StrFind.Focus();
            this.Opacity = 1;
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Событие при потери фокуса из строки поиска
        /// </summary>
        private void StrFind_LostFocus(object sender, EventArgs e)
        {
            if (StrFind.Text == "")
            {
                StrFind.Text = Params.StrFindLabel;
                StrFind.ForeColor = Color.DarkGray;
            }
        }

        /// <summary>
        /// Фокус в строке поиска
        /// </summary>
        private void StrFind_GotFocus(object sender, EventArgs e)
        {
            if (StrFind.Text == Params.StrFindLabel)
            {
                StrFind.Text = "";
                StrFind.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Загрузка название отделов в дерево
        /// </summary>
        private void LoadOtdels()
        {
            string SqlStr = "SELECT Name_Otdel, ID_Otdel, PostHeadUnit, NB_Otdel FROM Otdels WHERE Part IS Null AND Actual = 1";
            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;

            treeSGTP.Nodes.Clear();

            TreeNode TN;

            foreach (DataRow dr in rs)
            {
                TN = new TreeNode();
                TN.Text = dr[0].ToString();
                TN.ImageIndex = 0;
                TN.SelectedImageIndex = 0;

                LoadWorkers(dr["ID_Otdel"].ToString(), TN, dr["PostHeadUnit"].ToString(), dr["NB_Otdel"].ToString());
                LoadGroups(dr["ID_Otdel"].ToString(), TN);

                treeSGTP.Nodes.Add(TN);
            }

        }

        /// <summary>
        /// Ловим нажатия клавиш в поле поиска
        /// </summary>
        /// <param name="e"></param>
        private void StrFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) searchInTree(treeSGTP);
            
        }


        /// <summary>
        /// Загрузка списка работников в указанную Ноду
        /// </summary>
        /// <param name="IDO">ID отдела/группы</param>
        /// <param name="TN">Нода</param>
        /// <param name="IDPostHead">ID постка руководителя отдела/группы</param>
        /// <param name="NBOtdel">сокращенное название отдела</param>
        private void LoadWorkers(string IDO, TreeNode TN, string IDPostHead, string NBOtdel)
        {

            string SqlStr = " SELECT dbo.Workers.ID_Worker, dbo.Workers.F_Worker, dbo.Workers.N_Worker, dbo.Workers.P_Worker, dbo.Posts.N_Post, dbo.PhoneInner.NamberPInner, "
            + " dbo.PhoneTown.NamberPTown, dbo.PhoneMATS.NamberPMATS, dbo.PhoneGroup.NamberGroup, PhoneInner_1.NamberPInner AS NamberPInnerAdd, "
            + " PhoneInner_1.ID_PTown, PhoneTown_1.NamberPTown AS NamberPTownAdd, PhoneMATS_1.NamberPMATS AS NamberPMATSAdd, "
            + " PhoneGroup_1.NamberGroup AS NamberGroupAdd, dbo.PhoneInner.Room, PhoneInner_1.Room AS RoomAdd, dbo.PhoneIP.IPPhoneNamber, "
            + " dbo.Workers.F_Worker + ' ' + dbo.Workers.I_Worker AS FIO, dbo.Workers.ID_Post "
            + " FROM          dbo.PhoneIP RIGHT OUTER JOIN"
            + " dbo.WorkersExt ON dbo.PhoneIP.ID_IPPhone = dbo.WorkersExt.ID_IPPhone LEFT OUTER JOIN"
            + " dbo.PhoneInner PhoneInner_1 LEFT OUTER JOIN"
            + " dbo.PhoneGroup PhoneGroup_1 ON PhoneInner_1.ID_PGroup = PhoneGroup_1.ID_PGroup LEFT OUTER JOIN"
            + " dbo.PhoneMATS PhoneMATS_1 ON PhoneInner_1.ID_PMATS = PhoneMATS_1.ID_PMATS LEFT OUTER JOIN"
            + " dbo.PhoneTown PhoneTown_1 ON PhoneInner_1.ID_PTown = PhoneTown_1.ID_PTown ON "
            + " dbo.WorkersExt.PhoneInnerAdd = PhoneInner_1.ID_PInner LEFT OUTER JOIN"
            + " dbo.PhoneInner LEFT OUTER JOIN"
            + " dbo.PhoneGroup ON dbo.PhoneInner.ID_PGroup = dbo.PhoneGroup.ID_PGroup LEFT OUTER JOIN"
            + " dbo.PhoneMATS ON dbo.PhoneInner.ID_PMATS = dbo.PhoneMATS.ID_PMATS LEFT OUTER JOIN"
            + " dbo.PhoneTown ON dbo.PhoneInner.ID_PTown = dbo.PhoneTown.ID_PTown ON "
            + " dbo.WorkersExt.PhoneInner = dbo.PhoneInner.ID_PInner RIGHT OUTER JOIN"
            + " dbo.Workers INNER JOIN"
            + " dbo.Posts ON dbo.Workers.ID_Post = dbo.Posts.ID_Post ON dbo.WorkersExt.ID_Worker = dbo.Workers.ID_Worker"
            + " WHERE Workers.Fl_Rel = 0 and Workers.ID_Worker <> 1 and Workers.ID_Otdel = " + IDO;

            TreeNode subTN = new TreeNode();
            Hashtable HT;
            var rs = DB.GetFields(SqlStr);

            foreach (DataRow dr in rs)
            {
                subTN = new TreeNode();
                subTN.Text = dr["FIO"].ToString() + " - " + dr["N_Post"].ToString();
                subTN.ImageIndex = 2;
                subTN.SelectedImageIndex = 2;
                //параметры для поиска:
                HT = new Hashtable();
                HT.Add("ID_Worker", dr["ID_Worker"].ToString());
                HT.Add("ID_Post", dr["ID_Post"].ToString());
                HT.Add("SearchStr","");

                HT["SearchStr"] += dr["F_Worker"].ToString() + " ";
                HT["SearchStr"] += dr["N_Worker"].ToString() + " ";
                HT["SearchStr"] += dr["P_Worker"].ToString() + " ";
                HT["SearchStr"] += dr["N_Post"].ToString() + " ";
                HT["SearchStr"] += NBOtdel + " ";

                if (dr["Room"].ToString().Length > 0)
                    HT["SearchStr"] += dr["Room"].ToString() + " ";
                else if (dr["RoomAdd"].ToString().Length > 0)
                    HT["SearchStr"] += dr["RoomAdd"].ToString() + " ";


                //Телефоны
                if (dr["NamberPTown"].ToString().Length > 0)
                    HT["SearchStr"] += dr["NamberPTown"].ToString() + " ";
                else if (dr["NamberPTownAdd"].ToString().Length > 0)
                    HT["SearchStr"] += dr["NamberPTownAdd"].ToString() + " ";

                if (dr["NamberPMATS"].ToString().Length > 0)
                    HT["SearchStr"] += dr["NamberPMATS"].ToString() + " ";
                else if (dr["NamberPMATSAdd"].ToString().Length > 0)
                    HT["SearchStr"] += dr["NamberPMATSAdd"].ToString() + " ";

                if (dr["NamberPInner"].ToString().Length > 0)
                    HT["SearchStr"] += dr["NamberPInner"].ToString() + " ";
                else if (dr["NamberPInnerAdd"].ToString().Length > 0)
                    HT["SearchStr"] += dr["NamberPInnerAdd"].ToString() + " ";

                if (dr["NamberGroup"].ToString().Length > 0)
                    HT["SearchStr"] += dr["NamberGroup"].ToString() + " ";
                else if (dr["NamberGroupAdd"].ToString().Length > 0)
                    HT["SearchStr"] += dr["NamberGroupAdd"].ToString() + " ";

                CntAllWorkers++;
                HT.Add("Index", CntAllWorkers);

                subTN.Tag = HT;
                TN.Nodes.Add(subTN);
            }

            //ищем руководителя и ставим его первым
            if (IDPostHead.Length > 0)
            {
                foreach (TreeNode tmpTn in TN.Nodes)
                {
                    HT = (Hashtable)tmpTn.Tag;
                    if ((string)HT["ID_Post"] == IDPostHead)
                    {
                        TreeNode headTN = new TreeNode();
                        headTN = tmpTn;
                        headTN.ImageIndex = 3;
                        headTN.SelectedImageIndex = 3;
                        tmpTn.Remove();
                        TN.Nodes.Insert(0, headTN);
                        break;
                    }
                }
            }

        }


        /// <summary>
        /// Загрузка групп отдела
        /// </summary>
        /// <param name="IDO">ID отдела</param>
        /// <param name="TN">Нода отдела</param>
        private void LoadGroups(string IDO, TreeNode TN)
        {
            string SqlStr = "SELECT Name_Otdel, ID_Otdel, PostHeadUnit, NB_Otdel FROM Otdels WHERE Actual = 1 and Part = " + IDO;
            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;

            TreeNode subTN;

            foreach (DataRow dr in rs)
            {
                subTN = new TreeNode();
                subTN.Text = dr[0].ToString();
                subTN.ImageIndex = 0;
                subTN.SelectedImageIndex = 0;
                LoadWorkers(dr["ID_Otdel"].ToString(), subTN, dr["PostHeadUnit"].ToString(), dr["NB_Otdel"].ToString());

                TN.Nodes.Add(subTN);
            }

        }

        /// <summary>
        /// Событие после выбора работника в дереве
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeSGTP_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeSGTP.SelectedNode.Tag == null) return;
            Hashtable HT = (Hashtable)treeSGTP.SelectedNode.Tag;
            LoadWorkerDetail(HT["ID_Worker"].ToString());
        }


        /// <summary>
        /// Загрузка сведений о работнике
        /// </summary>
        /// <param name="IDW">ID работника</param>
        private void LoadWorkerDetail(string IDW)
        {
            string SqlStr = "";
            SqlStr = "SELECT Workers.ID_Worker, Workers.F_Worker, Workers.N_Worker, Workers.P_Worker, Otdels.NB_Otdel, Otdels.Name_Otdel, Posts.N_Post,";
            SqlStr += " PhoneInner.NamberPInner, PhoneTown.NamberPTown, PhoneMATS.NamberPMATS, PhoneGroup.NamberGroup,";
            SqlStr += " PhoneInner_1.NamberPInner AS NamberPInnerAdd, PhoneInner_1.ID_PTown, PhoneTown_1.NamberPTown AS NamberPTownAdd,";
            SqlStr += " PhoneMATS_1.NamberPMATS AS NamberPMATSAdd, PhoneGroup_1.NamberGroup AS NamberGroupAdd, PhoneInner.Room,";
            SqlStr += " PhoneInner_1.Room AS RoomAdd, PhoneIP.IPPhoneNamber";
            SqlStr += " FROM PhoneIP RIGHT OUTER JOIN";
            SqlStr += " WorkersExt ON PhoneIP.ID_IPPhone = WorkersExt.ID_IPPhone LEFT OUTER JOIN";
            SqlStr += " PhoneInner PhoneInner_1 LEFT OUTER JOIN";
            SqlStr += " PhoneGroup PhoneGroup_1 ON PhoneInner_1.ID_PGroup = PhoneGroup_1.ID_PGroup LEFT OUTER JOIN";
            SqlStr += " PhoneMATS PhoneMATS_1 ON PhoneInner_1.ID_PMATS = PhoneMATS_1.ID_PMATS LEFT OUTER JOIN";
            SqlStr += " PhoneTown PhoneTown_1 ON PhoneInner_1.ID_PTown = PhoneTown_1.ID_PTown ON";
            SqlStr += " WorkersExt.PhoneInnerAdd = PhoneInner_1.ID_PInner LEFT OUTER JOIN";
            SqlStr += " PhoneInner LEFT OUTER JOIN";
            SqlStr += " PhoneGroup ON PhoneInner.ID_PGroup = PhoneGroup.ID_PGroup LEFT OUTER JOIN";
            SqlStr += " PhoneMATS ON PhoneInner.ID_PMATS = PhoneMATS.ID_PMATS LEFT OUTER JOIN";
            SqlStr += " PhoneTown ON PhoneInner.ID_PTown = PhoneTown.ID_PTown ON WorkersExt.PhoneInner = PhoneInner.ID_PInner RIGHT OUTER JOIN";
            SqlStr += " Workers INNER JOIN";
            SqlStr += " Otdels ON Workers.ID_Otdel = Otdels.ID_Otdel INNER JOIN";
            SqlStr += " Posts ON Workers.ID_Post = Posts.ID_Post ON WorkersExt.ID_Worker = Workers.ID_Worker";
            SqlStr += " Where (Workers.ID_Worker = " + IDW + ")";

            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;

            DataRow dr = rs[0];

            //Основные сведения
            FWorker.Text = dr["F_Worker"].ToString();
            NWorker.Text = dr["N_Worker"].ToString();
            PWorker.Text = dr["P_Worker"].ToString();

            NOtdel.Text = dr["NB_Otdel"].ToString();
            NPost.Text = dr["N_Post"].ToString();

            //Номер комнаты
            if (dr["Room"].ToString().Length > 0)
                Room.Text = dr["Room"].ToString();
            else if (dr["RoomAdd"].ToString().Length > 0)
                Room.Text = dr["RoomAdd"].ToString();
            else Room.Text = "";

            //Телефоны
            if (dr["NamberPTown"].ToString().Length > 0)
                PhoneTown.Text = dr["NamberPTown"].ToString();
            else if (dr["NamberPTownAdd"].ToString().Length > 0)
                PhoneTown.Text = dr["NamberPTownAdd"].ToString();
            else PhoneTown.Text = "";

            if (dr["NamberPMATS"].ToString().Length > 0)
                PhoneMATS.Text = dr["NamberPMATS"].ToString();
            else if (dr["NamberPMATSAdd"].ToString().Length > 0)
                PhoneMATS.Text = dr["NamberPMATSAdd"].ToString();
            else PhoneMATS.Text = "";

            if (dr["NamberPInner"].ToString().Length > 0)
                PhoneInner.Text = dr["NamberPInner"].ToString();
            else if (dr["NamberPInnerAdd"].ToString().Length > 0)
                PhoneInner.Text = dr["NamberPInnerAdd"].ToString();
            else PhoneInner.Text = "";

            if (dr["NamberGroup"].ToString().Length > 0)
                PhoneGroup.Text = dr["NamberGroup"].ToString();
            else if (dr["NamberGroupAdd"].ToString().Length > 0)
                PhoneGroup.Text = dr["NamberGroupAdd"].ToString();
            else PhoneGroup.Text = "";

            IPPhoneNamber.Text = dr["IPPhoneNamber"].ToString().Length > 0 ? dr["IPPhoneNamber"].ToString() : "";

            SqlStr = "SELECT PhoneMov.ID_Sim, PhoneSim.ANamber, PhoneMov.TUse"
                    + " FROM PhoneMov INNER JOIN"
                    + " PhoneSim ON PhoneMov.ID_Sim = PhoneSim.ID_Sim"
                    + " Where (PhoneMov.DateTimeInp Is Null) And (PhoneMov.ID_Worker = " + IDW + ")";
            rs = DB.GetFields(SqlStr);
            if (rs.Count>0)
                ANamber.Text = rs[0]["ANamber"].ToString().Length > 0 ? rs[0]["ANamber"].ToString() : "";

            ViewFoto(dr["ID_Worker"].ToString());
        }

        /// <summary>
        /// Запись в файла фотографии и показ на форме
        /// </summary>
        /// <param name="IDW">ID работника</param>
        private void ViewFoto(string IDW)
        {
            string TempFile = Path.GetTempPath() + IDW + "_foto.tmp";
            //если фотография уже есть
            if (File.Exists(TempFile))
            {
                Bitmap tmp_image1 = new Bitmap(TempFile);
                pictureBox1.Image = tmp_image1;
                return;
            }

            //фотографии нет - грузим
            pictureBox1.Image = null;
            pictureBox1.Invalidate(); 

            var rs = DB.GetFields("SELECT ID_Worker, Photo_Worker From WorkersPhoto Where ID_Worker = " + IDW);
            if (rs.Count == 0)
            {
                pictureBox1.Image = pictureBox1.ErrorImage;
                return;
            }

            DataRow dr = rs[0];
            
            var arrByte = (byte[])dr["Photo_Worker"];

            try
            {
                using (FileStream outStream = File.Open(TempFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    outStream.Write(arrByte, 0, arrByte.Length);
                }
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Bitmap tmp_image2 = new Bitmap(TempFile);
            pictureBox1.Image = tmp_image2;

        }

        // Поиск в дереве
        private void button1_Click(object sender, EventArgs e)
        {
            searchInTree(treeSGTP);
        }

        /// <summary>
        /// Цикл по нодам дерева
        /// </summary>
        /// <param name="TV"></param>
        /// <param name="StrF"></param>
        private void searchInTree(TreeView TV)
        {
            if (treeSGTP.Nodes.Count == 0) return;
            if (treeSGTP.SelectedNode==null) treeSGTP.SelectedNode = treeSGTP.Nodes[0];

            FlSearchStop = false;
            foreach(TreeNode TN in TV.Nodes) {
                if(FlSearchStop==true) return;
                if (TN.Nodes.Count>0)  searchInTreeNode(TN);
            }

            if (IndexFind > -1)
            {
                IndexFind = -1;
                searchInTree(TV);
            }
        }

        private void searchInTreeNode(TreeNode TN){
            Hashtable tmpHash;
            foreach (TreeNode subTN in TN.Nodes)
            {
                if(FlSearchStop==true) return;

                if (subTN.Tag != null)
                {
                    tmpHash = (Hashtable)subTN.Tag;
                    if (tmpHash["SearchStr"].ToString().ToLower().IndexOf(StrFind.Text.ToLower())>-1 ) {
                        if ((int)tmpHash["Index"] > IndexFind)
                        {
                            treeSGTP.SelectedNode = subTN;
                            subTN.EnsureVisible();
                            FlSearchStop = true;
                            IndexFind = (int)tmpHash["Index"];
                            return;
                        }
                    }
                } else if (subTN.Nodes.Count>0) searchInTreeNode(subTN);

            }
        }

        private void StrFind_TextChanged(object sender, EventArgs e)
        {
            IndexFind = -1;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
