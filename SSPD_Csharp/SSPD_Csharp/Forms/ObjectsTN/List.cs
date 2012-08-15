using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SSPD.ObjectsTN
{
    public partial class List : Form
    {

        #region [Объявление переменных]

        //режим выбора объектов
        public bool SelectMode = false;
        public string SelectType = "";
        public bool FlSel = false;
        public Hashtable SelectData;

        //Данные объектов
        private DataRowCollection DRC_MN = null;
        private DataRowCollection DRC_RNU = null;
        private DataRowCollection DRC_Place = null;
        private DataRowCollection DRC_LPDS = null;

        //кол-во
        private int CntMN = 0;
        private int CntRNU = 0;
        private int CntPlace = 0;
        private int CntLPDS = 0;

        //флаг поиска
        private bool FlSearchStop = true;
        //индекс последнего найденного работника
        private int IndexFind = -1;
        //общий индекс нодов
        private int IndexCnt = 0;   

        #endregion

        #region [Инициализация и загрузка формы]

        public List()
        {
            InitializeComponent();

            StrFind.GotFocus += new EventHandler(StrFind_GotFocus);
            StrFind.LostFocus += new EventHandler(StrFind_LostFocus);
            StrFind.KeyDown += new KeyEventHandler(StrFind_KeyDown);

            this.Opacity = 0;
        }

        private void List_Load(object sender, EventArgs e)
        {

            if (SelectMode == true)
            {
                mbtnSelect.Visible = true;
                mbtnSepor1.Visible = true;
            }

            LoadData();
            GetObject();
            SetCntLabel();
            
            this.Opacity = 1;
        }

        #endregion

        #region [Построение дерева объектов]

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;

            string SqlStr = "SELECT dbo.ObjectMN.ID as ID_MN, dbo.Orgs.Name"
                          + " FROM dbo.ObjectMN INNER JOIN "
                          + " dbo.Orgs ON dbo.ObjectMN.ID_Org = dbo.Orgs.ID_Org"
                          + " ORDER BY dbo.ObjectMN.Ord";
            DRC_MN = DB.GetFields(SqlStr);

            SqlStr = "SELECT ID AS ID_RNU, ID_MN, Status, RNU_Name FROM ObjectRNU ORDER BY Ord";
            DRC_RNU = DB.GetFields(SqlStr);

            SqlStr = "SELECT ID AS ID_LPDS, ID_RNU, LPDS_Name, Status FROM ObjectLPDS ORDER BY Ord ";
            DRC_LPDS = DB.GetFields(SqlStr);

            SqlStr = "SELECT ID AS ID_Place, ID_RNU, Place_Name, Status, ID_LPDS, Place_RN, "
                   + " (SELECT Count(*) FROM ProjectsObjectPlace WHERE ID_Place=ObjectPlace.ID) as CntLinksPrj, "
                   + " (SELECT Count(*) FROM ObjectFiles WHERE ID_Object=ObjectPlace.ID AND ObjectType='Place') as CntLinksFiles "
                   + " FROM ObjectPlace  "
                   + " ORDER BY Ord";
            DRC_Place = DB.GetFields(SqlStr);

            CntMN = 0;
            CntLPDS = 0;
            CntRNU = 0;
            CntPlace = 0;

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Добавление объектов
        /// </summary>
        private void GetObject()
        {
            TreeObj.Nodes.Clear();
            IndexCnt = 0;

            TreeNode TN = new TreeNode();
            TN.Text ="ОАО \"АК \"Транснефть\"";
            AddMN(TN);

            TN.ExpandAll();
            TreeObj.Nodes.Add(TN);
        }

        /// <summary>
        /// Добавление МН
        /// </summary>
        /// <param name="TN">Родительская ветка</param>
        private void AddMN(TreeNode TN)
        {
            TreeNode subTN = null;
            Hashtable Detail = null;
            foreach (DataRow dr in DRC_MN)
            {
                subTN = new TreeNode();
                Detail = new Hashtable();
                subTN.Text = dr["Name"].ToString();

                Detail.Add("Type", "MN");
                Detail.Add("ID", dr["ID_MN"].ToString());
                IndexCnt++;
                Detail.Add("Index", IndexCnt);
                subTN.Tag = Detail;

                AddRNU(subTN);
                TN.Nodes.Add(subTN);
                CntMN++;
            }
        }

        /// <summary>
        /// Добавление РНУ
        /// </summary>
        /// <param name="TN">Родительская ветка</param>
        private void AddRNU(TreeNode TN)
        {
            TreeNode subTN = null;
            Hashtable Detail = null;
            foreach (DataRow dr in DRC_RNU)
            {
                if (((Hashtable)TN.Tag)["ID"].ToString() == dr["ID_MN"].ToString())
                {
                    subTN = new TreeNode();
                    Detail = new Hashtable();
                    subTN.Text = dr["RNU_Name"].ToString();

                    Detail.Add("Type", "RNU");
                    Detail.Add("ID", dr["ID_RNU"].ToString());
                    IndexCnt++;
                    Detail.Add("Index", IndexCnt);
                    subTN.Tag = Detail;

                    subTN.ImageIndex = dr["Status"].ToString()=="1" ? 1:2;
                    subTN.SelectedImageIndex = subTN.ImageIndex;
                    
                    AddLPDS(subTN);
                    AddPlaceInRNU(subTN);

                    TN.Nodes.Add(subTN);
                    CntRNU++;
                }
            }
        }

        /// <summary>
        /// Добавление ЛПДС
        /// </summary>
        /// <param name="TN">Родительская ветка</param>
        private void AddLPDS(TreeNode TN)
        {
            TreeNode subTN = null;
            Hashtable Detail = null;
            foreach (DataRow dr in DRC_LPDS)
            {
                if (((Hashtable)TN.Tag)["ID"].ToString() == dr["ID_RNU"].ToString())
                {
                    subTN = new TreeNode();
                    Detail = new Hashtable();
                    subTN.Text = dr["LPDS_Name"].ToString();

                    Detail.Add("Type", "LPDS");
                    Detail.Add("ID", dr["ID_LPDS"].ToString());
                    Detail.Add("ID_RNU", dr["ID_RNU"].ToString());
                    IndexCnt++;
                    Detail.Add("Index", IndexCnt);
                    
                    subTN.Tag = Detail;

                    subTN.ImageIndex = dr["Status"].ToString() == "1" ? 3 : 4;
                    subTN.SelectedImageIndex = subTN.ImageIndex;
                    
                    AddPlaceInLPDS(subTN);
                    TN.Nodes.Add(subTN);
                    CntLPDS ++;
                }
            }
        }

        /// <summary>
        /// Добавление площадки в ЛПДС
        /// </summary>
        /// <param name="TN">Родительская ветка</param>
        private void AddPlaceInLPDS(TreeNode TN)
        {
            TreeNode subTN;
            Hashtable Detail = null;
            foreach (DataRow dr in DRC_Place)
            {
                if (((Hashtable)TN.Tag)["ID"].ToString() == dr["ID_LPDS"].ToString())
                {
                    subTN = new TreeNode();
                    Detail = new Hashtable();
                    subTN.Text = dr["Place_Name"].ToString();

                    if (dr["Place_RN"].ToString().Length > 0)
                        subTN.Text += " [номер площадки: " + dr["Place_RN"].ToString() + "]";

                    Detail.Add("Type", "Place");
                    Detail.Add("ID", dr["ID_Place"].ToString());
                    Detail.Add("ID_RNU", dr["ID_RNU"].ToString());
                    IndexCnt++;
                    Detail.Add("Index", IndexCnt);
                    subTN.Tag = Detail;

                    subTN.ImageIndex = dr["Status"].ToString() == "1" ? 5 : 6;

                    if (Convert.ToInt32(dr["CntLinksPrj"]) > 0)
                        subTN.ImageIndex = 7;

                    if (Convert.ToInt32(dr["CntLinksFiles"]) > 0)
                        subTN.ImageIndex = 8;

                    if (Convert.ToInt32(dr["CntLinksFiles"]) > 0 && Convert.ToInt32(dr["CntLinksPrj"]) > 0)
                        subTN.ImageIndex = 9;

                    subTN.SelectedImageIndex = subTN.ImageIndex;

                    TN.Nodes.Add(subTN);
                    CntPlace++;
                }
            }
        }

        /// <summary>
        /// Добавление площадки в РНУ
        /// </summary>
        /// <param name="TN">Родительская ветка</param>
        private void AddPlaceInRNU(TreeNode TN)
        {
            TreeNode subTN;
            Hashtable Detail = null;
            foreach (DataRow dr in DRC_Place)
            {
                if (((Hashtable)TN.Tag)["ID"].ToString() == dr["ID_RNU"].ToString() && (dr["ID_LPDS"].ToString().Length == 0 || dr["ID_LPDS"].ToString()=="0"))
                {
                    subTN = new TreeNode();
                    Detail = new Hashtable();
                    subTN.Text = dr["Place_Name"].ToString();

                    if (dr["Place_RN"].ToString().Length > 0)
                        subTN.Text += " [номер площадки: " + dr["Place_RN"].ToString() + "]";

                    Detail.Add("Type", "Place");
                    Detail.Add("ID", dr["ID_Place"].ToString());
                    Detail.Add("ID_RNU", dr["ID_RNU"].ToString());
                    IndexCnt++;
                    Detail.Add("Index", IndexCnt);
                    subTN.Tag = Detail;

                    subTN.ImageIndex = dr["Status"].ToString() == "1" ? 5 : 6;

                    if (Convert.ToInt32(dr["CntLinksPrj"]) > 0)
                        subTN.ImageIndex = 7;

                    if (Convert.ToInt32(dr["CntLinksFiles"]) > 0)
                        subTN.ImageIndex = 8;

                    if (Convert.ToInt32(dr["CntLinksFiles"]) > 0 && Convert.ToInt32(dr["CntLinksPrj"]) > 0)
                        subTN.ImageIndex = 9;

                    subTN.SelectedImageIndex = subTN.ImageIndex;

                    TN.Nodes.Add(subTN);
                    CntPlace++;
                }
            }
        }

        /// <summary>
        /// Информация о количестве объектов
        /// </summary>
        private void SetCntLabel()
        {
            CntMNLabel.Text = "Всего ОСТ: " + CntMN.ToString();
            CntRNULabel.Text = "Всего РНУ: " + CntRNU.ToString();
            CntLPDSLabel.Text = "Всего ЛПДС: " + CntLPDS.ToString();
            CntPlaceLabel.Text = "Всего площадок: " + CntPlace.ToString();
        }

        #endregion

        #region [Управление деревом]

        /// <summary>
        /// Отправка на обработку сворачивания веток
        /// </summary>
        /// <param name="TypeNode">Тип ветки (МН, РНУ, ЛПДС)</param>
        private void GetCollapse(string TypeNode)
        {
            Cursor.Current = Cursors.WaitCursor;
            TreeObj.Visible = false;
            CollapseTree(TypeNode, TreeObj.Nodes[0]);
            TreeObj.SelectedNode = TreeObj.Nodes[0];
            TreeObj.Nodes[0].EnsureVisible();
            TreeObj.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Свернуть указанную ветку
        /// </summary>
        /// <param name="TypeNode">Тип ветки (МН, РНУ, ЛПДС)</param>
        /// /// <param name="TN">Ветка</param>
        private void CollapseTree(string TypeNode, TreeNode TN) {
            foreach(TreeNode subTN in TN.Nodes) {
                if (((Hashtable)subTN.Tag)["Type"].ToString() == TypeNode)
                    subTN.Collapse();
                if (subTN.Nodes.Count > 0) CollapseTree(TypeNode, subTN);
            }
        }

        /// <summary>
        /// Выбор нода по ID
        /// </summary>
        /// <param name="TypeNode">Тип объекта</param>
        /// <param name="IDNode">ID нужного объекта</param>
        /// <param name="TN">Выбранная нода</param>
        /// <returns>true-объект найден и выбран, false - объект не найден</returns>
        private bool SelectNode(string TypeNode, string IDNode, TreeNode TN)
        {
            foreach (TreeNode subTN in TN.Nodes)
            {
                if (((Hashtable)subTN.Tag)["Type"].ToString() == TypeNode && ((Hashtable)subTN.Tag)["ID"].ToString() == IDNode)
                {
                    TreeObj.SelectedNode = subTN;
                    return true;
                }
                if (subTN.Nodes.Count > 0)
                {
                    if (SelectNode(TypeNode, IDNode, subTN) == true) return true;
                }
            }
            return false;
        }

        private void свернутьВеткиМНToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCollapse("MN");
        }

        private void свернутьВеткиРНУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCollapse("RNU");
        }

        private void свернутьВеткиЛПДСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCollapse("LPDS");
        }

        private void раскрытьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeObj.Visible = false;
            TreeObj.ExpandAll();
            TreeObj.SelectedNode = TreeObj.Nodes[0];
            TreeObj.Nodes[0].EnsureVisible();
            TreeObj.Visible = true;
        }

        #endregion

        #region [Поиск в дереве]

        /// <summary>
        /// Цикл по нодам дерева
        /// </summary>
        /// <param name="TV"></param>
        private void searchInTree(TreeView TV)
        {
            if (TV.Nodes.Count == 0) return;
            if (TV.SelectedNode == null) TV.SelectedNode = TV.Nodes[0];

            FlSearchStop = false;
            foreach (TreeNode TN in TV.Nodes)
            {
                if (FlSearchStop == true) return;
                if (TN.Nodes.Count > 0) searchInTreeNode(TN);
            }

            if (IndexFind > -1 && FlSearchStop != true)
            {
                IndexFind = -1;
                searchInTree(TV);
            }
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="TN">выбранная нода</param>
        private void searchInTreeNode(TreeNode TN)
        {
            Hashtable tmpHash;
            foreach (TreeNode subTN in TN.Nodes)
            {
                if (FlSearchStop == true) return;

                tmpHash = (Hashtable)subTN.Tag;
                if (subTN.Text.ToString().ToLower().IndexOf(StrFind.Text.ToLower()) > -1)
                {
                    if ((int)tmpHash["Index"] > IndexFind)
                    {
                        TreeObj.SelectedNode = subTN;
                        subTN.EnsureVisible();
                        FlSearchStop = true;
                        IndexFind = (int)tmpHash["Index"];
                        return;
                    }
                }
                if (subTN.Nodes.Count > 0) searchInTreeNode(subTN);
            }
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
            if (e.KeyCode == Keys.Enter) searchInTree(TreeObj);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            searchInTree(TreeObj);
        }

        #endregion

        #region [Управление объектами]

        /// <summary>
        /// Редактирование объекта
        /// </summary>
        private void EditObj()
        {
            if (TreeObj.SelectedNode == null) return;
            if (TreeObj.SelectedNode.Tag == null) return;
            EditCard EC = new EditCard();
            EC.IDObj = ((Hashtable)TreeObj.SelectedNode.Tag)["ID"].ToString();
            EC.TypeObj = ((Hashtable)TreeObj.SelectedNode.Tag)["Type"].ToString();
            EC.ShowDialog();
            if (EC.FlSave == true && EC.IDObj != null && EC.NameObject != null)
            {
                if (EC.TypeObj == "Place")
                {
                    LoadData();
                    GetObject();
                    SetCntLabel();
                    SelectNode(EC.TypeObj, EC.IDObj, TreeObj.Nodes[0]);
                }
                else 
                    TreeObj.SelectedNode.Text = EC.NameObject; 
            }
        }

        /// <summary>
        /// Создание объекта
        /// </summary>
        private void AddObj()
        {
            if (TreeObj.SelectedNode == null) return;
            string TypeObj = null;
            string IDParent = null;

            if (TreeObj.SelectedNode.Tag != null)
            {
                TypeObj = ((Hashtable)TreeObj.SelectedNode.Tag)["Type"].ToString();
                IDParent = ((Hashtable)TreeObj.SelectedNode.Tag)["ID"].ToString();
            }
            switch (TypeObj)
            {
                case "MN":
                    TypeObj = "RNU";
                    break;
                case "RNU":
                    TypeObj = "Place";
                    break;
                case "LPDS":
                    TypeObj = "Place";
                    IDParent = ((Hashtable)TreeObj.SelectedNode.Tag)["ID_RNU"].ToString();
                    break;
                case "Place":
                    TypeObj = "Place";
                    IDParent = ((Hashtable)TreeObj.SelectedNode.Tag)["ID_RNU"].ToString();
                    break;
                default:
                    TypeObj = "MN";
                    IDParent = null;
                    break;
            }

            EditCard EC = new EditCard();
            EC.INew = true;
            EC.IDObj = IDParent;
            EC.TypeObj = TypeObj;
            EC.ShowDialog();

            //объект создан - добавляем в дерево
            if (EC.FlSave == true && EC.IDObj != "")
            {
                if (EC.TypeObj == "Place")
                {
                    LoadData();
                    GetObject();
                    SetCntLabel();
                    SelectNode(EC.TypeObj, EC.IDObj, TreeObj.Nodes[0]);
                }
                else
                {
                    TreeNode TN = new TreeNode();
                    Hashtable Detail = new Hashtable();
                    Detail.Add("Type", EC.TypeObj);
                    Detail.Add("ID", EC.IDObj);
                    TN.Text = EC.NameObject;
                    TN.Tag = Detail;
                    if (EC.TypeObj == "MN")
                    {
                        TN.ImageIndex = 0; TN.SelectedImageIndex = TN.ImageIndex;
                        CntMN++;
                    }
                    else if (EC.TypeObj == "RNU")
                    {
                        TN.ImageIndex = 1; TN.SelectedImageIndex = TN.ImageIndex;
                        CntRNU++;
                    }
                    else if (EC.TypeObj == "LPDS")
                    {
                        TN.ImageIndex = 3; TN.SelectedImageIndex = TN.ImageIndex;
                        CntLPDS++;
                    }
                    else if (EC.TypeObj == "Place")
                    {
                        TN.ImageIndex = 5; TN.SelectedImageIndex = TN.ImageIndex;
                        CntPlace++;
                    }
                    TreeObj.SelectedNode.Nodes.Add(TN);
                    TreeObj.SelectedNode = TN;
                    TreeObj.SelectedNode.EnsureVisible();
                    SetCntLabel();
                }
            }
        }

        /// <summary>
        /// Удаление объекта
        /// </summary>
        private void DeleteObj()
        {
            if (TreeObj.SelectedNode == null) return;
            if (TreeObj.SelectedNode.Tag == null) return;

            string ErrMsg = "";
            TreeNode TN = TreeObj.SelectedNode;

            //проверка наличия вспомогательных файлов
            if (CheckData("ObjectFiles", string.Format(" ObjectType='{0}' AND ID_Object = {1}", 
                                                        ((Hashtable)TN.Tag)["Type"].ToString(), 
                                                        ((Hashtable)TN.Tag)["ID"].ToString())) == true)
                ErrMsg = "\r\n- вспомогательный материал";

            //проверка дочерних объектов
            if (((Hashtable)TN.Tag)["Type"].ToString() == "MN")
                if (CheckData("ObjectRNU", string.Format(" ID_MN='{0}'",
                                                        ((Hashtable)TN.Tag)["ID"].ToString())) == true)
                    ErrMsg += "\r\n- дочерние РНУ";

            if (((Hashtable)TN.Tag)["Type"].ToString() == "RNU")
                if (CheckData("ObjectPlace", string.Format(" ID_RNU='{0}'",
                                                        ((Hashtable)TN.Tag)["ID"].ToString())) == true)
                    ErrMsg += "\r\n- дочерние площадки";

            if (((Hashtable)TN.Tag)["Type"].ToString() == "RNU")
                if (CheckData("ObjectLPDS", string.Format(" ID_RNU='{0}'",
                                                        ((Hashtable)TN.Tag)["ID"].ToString())) == true)
                    ErrMsg += "\r\n- дочерние ЛПДС";

            if (((Hashtable)TN.Tag)["Type"].ToString() == "LPDS")
                if (CheckData("ObjectPlace", string.Format(" ID_LPDS='{0}'",
                                                        ((Hashtable)TN.Tag)["ID"].ToString())) == true)
                    ErrMsg += "\r\n- дочерние площадки";

            if (((Hashtable)TN.Tag)["Type"].ToString() == "Place")
                if (CheckData("ProjectsObjectPlace", string.Format(" ID_Place='{0}'",
                                                        ((Hashtable)TN.Tag)["ID"].ToString())) == true)
                    ErrMsg += "\r\n- связанные проекты";

            if (ErrMsg.Length > 0)
            {
                SSPDUI.MsgEx("Выбранный объект содержит: \r\n"+ ErrMsg, "Остановка удаления объекта");
                return;
            }

            //операция удаления
            if (MessageBox.Show("Удалить объект [" + TN.Text+"]?","Удаление объекта",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) {
                DB.DeleteRow("Object" + ((Hashtable)TN.Tag)["Type"].ToString(),"ID = "+ ((Hashtable)TN.Tag)["ID"].ToString());
            }

            TN.Remove();
        }

        /// <summary>
        /// Проверка наличия данных в таблице
        /// </summary>
        /// <param name="TableName">Имя таблицы</param>
        /// <param name="WhereStr">Условие выборки</param>
        /// <returns>true - есть данные, false - нету данных</returns>
        private bool CheckData(string TableName, string WhereStr)
        {
            var rs = DB.GetFields("SELECT COUNT(*) as MaxRec FROM " + TableName + (WhereStr.Length > 0 ? " WHERE " + WhereStr : ""));
            if (Convert.ToInt32(rs[0]["MaxRec"]) > 0) return true;
            return false;
        }

        /// <summary>
        /// Выбор объекта
        /// </summary>
        private void doSelectItem()
        {
            if (TreeObj.SelectedNode == null) return;
            if (TreeObj.SelectedNode.Tag == null) return;

            if (SelectType.Length > 0)
            {
                if (SelectType != ((Hashtable)TreeObj.SelectedNode.Tag)["Type"].ToString())
                {
                    return;
                }
            }

            FlSel = true;
            SelectData = (Hashtable)TreeObj.SelectedNode.Tag;
            SelectData.Add("Name", TreeObj.SelectedNode.Text);
            this.Close();
        }

        #endregion

        #region [События элементов формы]

        private void List_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.F7) searchInTree(TreeObj);
        }

        private void mbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbtnExplorer_Click(object sender, EventArgs e)
        {
            if (TreeObj.SelectedNode == null) return;
            if (TreeObj.SelectedNode.Tag == null) return;

            SSPD.ObjectsTN.Explorer Exp = new SSPD.ObjectsTN.Explorer();
            Exp.IDObj = ((Hashtable)TreeObj.SelectedNode.Tag)["ID"].ToString();
            Exp.TypeObj = ((Hashtable)TreeObj.SelectedNode.Tag)["Type"].ToString();
            Exp.NameObj = TreeObj.SelectedNode.Text;
            Exp.ShowDialog();
            Exp.Dispose();
        }

        private void mbtnEdit_Click(object sender, EventArgs e)
        {
            EditObj();
        }

        private void mbtnAdd_Click(object sender, EventArgs e)
        {
            AddObj();
        }

        private void mbtnDel_Click(object sender, EventArgs e)
        {
            DeleteObj();
        }

        private void mbtnFiles_Click(object sender, EventArgs e)
        {
            if (TreeObj.SelectedNode == null) return;
            if (TreeObj.SelectedNode.Tag == null) return;

            FileList FL = new FileList();
            FL.IDObj = ((Hashtable)TreeObj.SelectedNode.Tag)["ID"].ToString();
            FL.TypeObj = ((Hashtable)TreeObj.SelectedNode.Tag)["Type"].ToString();
            FL.NameObj = TreeObj.SelectedNode.Text;
            FL.ShowDialog();
        }

        private void TreeObj_KeyDown(object sender, KeyEventArgs e)
        {
            if (SelectMode == true)
            {
                if (e.KeyCode == Keys.Enter)
                    doSelectItem();
            }
        }

        private void mbtnSelect_Click(object sender, EventArgs e)
        {
            doSelectItem();
        }

        #endregion



    }
}
