using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD.ObjectsTN
{
    public partial class EditCard : Form
    {

        #region [Объявление переменных]

        //тип объекта
        public string TypeObj = null;
        //ID объекта
        public string IDObj = null;
        //Название объекта
        public string NameObject = null;

        //флаг новый ли объект
        public bool INew = false;

        //флаг сохранения карточки
        public bool FlSave = false;

        #endregion

        #region [Инициализация и загрузка формы]

        public EditCard()
        {
            InitializeComponent();

        }

        private void EditCard_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //изменяем размеры окна
            switch (TypeObj)
            {
                case "MN":
                    this.Size = new Size(600, 220);
                    this.MaximumSize = new Size(1280, 220);
                    LoadDataMN();
                    break;
                case "RNU":
                    this.Size = new Size(600, 265);
                    this.MaximumSize = new Size(1280, 265);
                    LoadDataRNU();
                    break;
                case "LPDS":
                    this.Size = new Size(600, 265);
                    this.MaximumSize = new Size(1280, 265);
                    LoadLPDS();
                    break;
                case "Place":
                    this.Size = new Size(600, 330);
                    this.MaximumSize = new Size(1280, 330);
                    LoadDataPlace();
                    break;
            }

            //удаляем вкладки
            DeleteTab();

            if (INew == true)
                this.Text = "Карточка создания объекта";
            else
                this.Text = "Карточка редактирования объекта";

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Удаляем лишние вкладки
        /// </summary>
        private void DeleteTab()
        {
            foreach (TabPage TP in TabControl.TabPages)
            {
                if (TP.Name != TypeObj) TabControl.TabPages.Remove(TP);
            }
        }

        #endregion

        #region [Загрузка данных из БД]

        /// <summary>
        /// Загрузка списка ЛПДС
        /// </summary>
        private void LoadListLPDS()
        {
            comboLPDS.Items.Clear();
            string SqlStr = "SELECT LPDS_Name, ID  FROM ObjectLPDS WHERE ID_RNU = " + Place_RNU.Tag.ToString() + " ORDER BY Ord";
            var rs = DB.GetFields(SqlStr);
            if (rs.Count > 0)
            {
                SSPDUI.ComboType CT = new SSPDUI.ComboType();
                foreach (DataRow dr in rs)
                {
                    CT.ID_Item = (int)dr["ID"];
                    CT.Name_Item  = dr["LPDS_Name"].ToString();
                    comboLPDS.Items.Add(CT);
                }
            }
        }

        /// <summary>
        /// Загрузка данных ОСТ
        /// </summary>
        private void LoadDataMN()
        {
            if (INew == true) return;
            string SqlStr = "SELECT dbo.Orgs.ID_Org, dbo.Orgs.Name"
              + " FROM dbo.ObjectMN INNER JOIN "
              + " dbo.Orgs ON dbo.ObjectMN.ID_Org = dbo.Orgs.ID_Org"
              + " WHERE dbo.ObjectMN.ID =" + IDObj;
            var rs = DB.GetFields(SqlStr);
            if (rs.Count > 0)
            {
                MN_Name.Text = rs[0]["Name"].ToString();
                MN_Name.Tag = rs[0]["ID_Org"].ToString();
                btnChangeOrg.Focus();
            }
        }

        /// <summary>
        /// Загрузка данных РНУ
        /// </summary>
        private void LoadDataRNU()
        {
            if (INew == true)
            {
                RNU_MN_Name.Tag = IDObj;
                string SqlStr = "SELECT dbo.Orgs.Name"
                              + " FROM dbo.ObjectMN INNER JOIN "
                              + " dbo.Orgs ON dbo.ObjectMN.ID_Org = dbo.Orgs.ID_Org"
                              + " WHERE dbo.ObjectMN.ID =" + IDObj;
                var rs = DB.GetFields(SqlStr);
                if (rs.Count > 0)
                    RNU_MN_Name.Text = rs[0]["Name"].ToString();
            }
            else
            {
                string SqlStr = "SELECT  dbo.ObjectRNU.ID_MN, dbo.Orgs.Name AS OST, dbo.ObjectRNU.RNU_Name "
                              + " FROM          dbo.ObjectMN INNER JOIN "
                              + " dbo.Orgs ON dbo.ObjectMN.ID_Org = dbo.Orgs.ID_Org INNER JOIN "
                              + " dbo.ObjectRNU ON dbo.ObjectMN.ID = dbo.ObjectRNU.ID_MN"
                              + " WHERE dbo.ObjectRNU.ID = " + IDObj;
                var rs = DB.GetFields(SqlStr);
                if (rs.Count > 0)
                {
                    RNU_MN_Name.Text = rs[0]["OST"].ToString();
                    RNU_MN_Name.Tag = rs[0]["ID_MN"].ToString();
                    RNU_Name.Text = rs[0]["RNU_Name"].ToString();
                    RNU_Name.Select(0, 0);
                    RNU_Name.Focus();
                }
            }
        }

        /// <summary>
        /// Загрузка данных Площадки
        /// </summary>
        private void LoadDataPlace()
        {
            PlaceStatus.Checked = true;
            checkLPDS.Checked = false;
            comboLPDS.Enabled = false;
            btnLPDSAdd.Enabled = false;
            Place_Name.Select(0, 0);
            Place_Name.Focus();

            if (INew == true)
            {
                Place_RNU.Tag = IDObj;
                string SqlStr = "SELECT RNU_Name "
                              + " FROM dbo.ObjectRNU "
                              + " WHERE ID =" + IDObj;
                var rs = DB.GetFields(SqlStr);
                if (rs.Count > 0)
                    Place_RNU.Text = rs[0]["RNU_Name"].ToString();
            }
            else
            {
                string SqlStr = "SELECT dbo.ObjectPlace.ID, dbo.ObjectPlace.ID_RNU, dbo.ObjectRNU.RNU_Name, dbo.ObjectPlace.Place_Name, dbo.ObjectPlace.Status, "
                        + " dbo.ObjectPlace.ID_LPDS, dbo.ObjectPlace.Place_RN "
                        + " FROM          dbo.ObjectPlace INNER JOIN "
                        + " dbo.ObjectRNU ON dbo.ObjectPlace.ID_RNU = dbo.ObjectRNU.ID "
                        + " WHERE dbo.ObjectPlace.ID = " + IDObj;
                var rs = DB.GetFields(SqlStr);
                if (rs.Count > 0)
                {
                    if (rs[0]["Status"].ToString() != "1") PlaceStatus.Checked = false;
                    Place_RNU.Tag = rs[0]["ID_RNU"].ToString();
                    Place_RNU.Text = rs[0]["RNU_Name"].ToString();
                    Place_Name.Text = rs[0]["Place_Name"].ToString();
                    PlaceRN.Text = rs[0]["Place_RN"].ToString();
                    if (rs[0]["ID_LPDS"].ToString().Length > 0)
                    {
                        LoadListLPDS();
                        //ищем нужную площадку
                        if (comboLPDS.Items.Count > 0)
                        {
                            for (int i = 0; i <= comboLPDS.Items.Count - 1; i++)
                            {
                                if (((SSPDUI.ComboType)comboLPDS.Items[i]).ID_Item == (int)rs[0]["ID_LPDS"])
                                {
                                    comboLPDS.SelectedIndex = i;
                                    checkLPDS.Checked = true;
                                    comboLPDS.Enabled = true;
                                    btnLPDSAdd.Enabled = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Загрузка данных ЛПДС
        /// </summary>
        private void LoadLPDS()
        {
            if (INew == true)
            {
                LPDS_RNU.Tag = IDObj;
                string SqlStr = "SELECT RNU_Name "
                              + " FROM dbo.ObjectRNU "
                              + " WHERE ID =" + IDObj;
                var rs = DB.GetFields(SqlStr);
                if (rs.Count > 0)
                    LPDS_RNU.Text = rs[0]["RNU_Name"].ToString();
            }
            else
            {
                string SqlStr = "SELECT dgk.ObjectLPDS.ID_RNU, dgk.ObjectLPDS.LPDS_Name, dgk.ObjectLPDS.ID, dbo.ObjectRNU.RNU_Name "
                              + " FROM  dgk.ObjectLPDS INNER JOIN "
                              + " dbo.ObjectRNU ON dgk.ObjectLPDS.ID_RNU = dbo.ObjectRNU.ID"
                              + " WHERE dgk.ObjectLPDS.ID =" + IDObj;
                var rs = DB.GetFields(SqlStr);
                if (rs.Count > 0)
                {
                    LPDS_RNU.Tag = rs[0]["ID_RNU"].ToString();
                    LPDS_RNU.Text = rs[0]["RNU_Name"].ToString();
                    LPDS_Name.Text = rs[0]["LPDS_Name"].ToString();
                    LPDS_Name.Select(0, 0);
                    LPDS_Name.Focus();
                }
            }
        }

        #endregion

        #region [Сохранение данных]

        /// <summary>
        /// Сохранение 
        /// </summary>
        private void SaveObjects()
        {
            switch (TypeObj)
            {
                case "MN":
                    SaveMN();
                    break;
                case "RNU":
                    SaveRNU();
                    break;
                case "LPDS":
                    SaveLPDS();
                    break;
                case "Place":
                    SavePlace();
                    break;
            }
        }

        /// <summary>
        /// Сохраняем данные МНа
        /// </summary>
        private void SaveMN()
        {
            NameObject = MN_Name.Text;

            Dictionary<string, string> DataSet = new Dictionary<string, string>(); ;
            DataSet.Add("ID_Org", MN_Name.Tag.ToString());

            if (INew == false)
            { //сохраняем изменения
                DB.SetFields(DataSet, "ObjectMN", "ID = " + IDObj);
            }
            else
            { //создаем новый объект
                var rs = DB.GetFields("SELECT ISNULL(MAX(Ord), 0) + 1 AS Ord FROM ObjectMN");
                string Ord = rs[0]["Ord"].ToString();
                DataSet.Add("Ord", Ord);
                DB.InsertRow(DataSet, "ObjectMN");
                rs = DB.GetFields("SELECT ID FROM ObjectMN WHERE Ord = " + Ord + " AND ID_Org = " + MN_Name.Tag.ToString());
                if (rs.Count > 0)
                    IDObj = rs[0]["ID"].ToString();
            }

            FlSave = true;
            this.Close();
        }

        /// <summary>
        /// Сохранение данных РНУ
        /// </summary>
        private void SaveRNU()
        {
            NameObject = RNU_Name.Text;

            Dictionary<string, string> DataSet = new Dictionary<string, string>(); ;
            DataSet.Add("RNU_Name", RNU_Name.Text);

            if (INew == false)
            { //сохраняем изменения
                DB.SetFields(DataSet, "ObjectRNU", "ID = " + IDObj);
            }
            else
            { //создаем новый объект

                DataSet.Add("ID_MN", RNU_MN_Name.Tag.ToString());
                var rs = DB.GetFields("SELECT ISNULL(MAX(Ord), 0) + 1 AS Ord FROM ObjectRNU WHERE ID_MN = " + RNU_MN_Name.Tag.ToString());
                string Ord = rs[0]["Ord"].ToString();
                DataSet.Add("Ord", Ord);
                DB.InsertRow(DataSet, "ObjectRNU");
                rs = DB.GetFields("SELECT ID FROM ObjectRNU WHERE Ord = " + Ord + " AND ID_MN = " + RNU_MN_Name.Tag.ToString());
                if (rs.Count > 0)
                    IDObj = rs[0]["ID"].ToString();
                else IDObj = "";
            }

            FlSave = true;
            this.Close();
        }

        /// <summary>
        /// Сохраняем данные ЛПДС
        /// </summary>
        private void SaveLPDS()
        {
            NameObject = LPDS_Name.Text;
            
            Dictionary<string, string> DataSet = new Dictionary<string, string>(); ;
            DataSet.Add("LPDS_Name", LPDS_Name.Text);

            if (INew == false)
            { //сохраняем изменения
                DB.SetFields(DataSet, "ObjectLPDS", "ID = " + IDObj);
            }
            else
            { //создаем новый объект
                DataSet.Add("ID_RNU", LPDS_RNU.Tag.ToString());
                var rs = DB.GetFields("SELECT ISNULL(MAX(Ord), 0) + 1 AS Ord FROM ObjectLPDS WHERE ID_RNU = " + LPDS_RNU.Tag.ToString());
                string Ord = rs[0]["Ord"].ToString();
                DataSet.Add("Ord", Ord);
                DataSet.Add("Status", "1");
                DB.InsertRow(DataSet, "ObjectLPDS");
                rs = DB.GetFields("SELECT ID FROM ObjectLPDS WHERE Ord = " + Ord + " AND LPDS_Name = '" + LPDS_Name.Text+ "'");
                if (rs.Count > 0)
                    IDObj = rs[0]["ID"].ToString();
                else IDObj = "";
            }

            FlSave = true;
            this.Close();
        }

        /// <summary>
        /// Сохраняем данные площадки
        /// </summary>
        private void SavePlace()
        {
            NameObject = Place_Name.Text;

            Dictionary<string, string> DataSet = new Dictionary<string, string>(); ;
            DataSet.Add("Place_Name", Place_Name.Text);
            DataSet.Add("Place_RN", PlaceRN.Text);
            
            if (PlaceStatus.Checked==true)
                DataSet.Add("Status", "1");
            else
                DataSet.Add("Status", "0");

            
            if (checkLPDS.Checked == true && comboLPDS.Items.Count>=0)
                DataSet.Add("ID_LPDS",((SSPDUI.ComboType)comboLPDS.SelectedItem).ID_Item.ToString());
            else 
                DataSet.Add("ID_LPDS", "");
            
            if (INew == false)
            { //сохраняем изменения
                DB.SetFields(DataSet, "ObjectPlace", "ID = " + IDObj);
            }
            else
            { //создаем новый объект
                DataSet.Add("ID_RNU", Place_RNU.Tag.ToString());
                var rs = DB.GetFields("SELECT ISNULL(MAX(Ord), 0) + 1 AS Ord FROM ObjectPlace WHERE ID_RNU = " + Place_RNU.Tag.ToString());
                string Ord = rs[0]["Ord"].ToString();
                DataSet.Add("Ord", Ord);
                
                DB.InsertRow(DataSet, "ObjectPlace");
                rs = DB.GetFields("SELECT ID FROM ObjectPlace WHERE Ord = " + Ord + " AND Place_Name = '" + Place_Name.Text + "'");
                if (rs.Count > 0)
                    IDObj = rs[0]["ID"].ToString();
                else IDObj = "";
            }

            FlSave = true;
            this.Close();
        }

        #endregion

        #region [Обработка событий элементов формы]

        private void EditCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.F2) SaveObjects();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveObjects();
        }

        private void mbtnSave_Click(object sender, EventArgs e)
        {
            SaveObjects();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnChangeOrg_Click(object sender, EventArgs e)
        {
            SSPD.Select.Orgs Org = new SSPD.Select.Orgs();
            Org.means = 5;
            Org.ShowDialog();
            if (Org.FlSel == true)
            {
                MN_Name.Tag = Org.SelectID;
                MN_Name.Text = Org.SelectValue;
            }
        }

        private void btnLPDSAdd_Click(object sender, EventArgs e)
        {
            EditCard ec = new EditCard();
            ec.IDObj = Place_RNU.Tag.ToString();
            ec.TypeObj = "LPDS";
            ec.INew = true;
            ec.ShowDialog();
            if (ec.FlSave == true)
            {
                SSPDUI.ComboType ct = new SSPDUI.ComboType();
                ct.ID_Item = Convert.ToInt32(ec.IDObj);
                ct.Name_Item = ec.NameObject;
                comboLPDS.Items.Add(ct);
                comboLPDS.SelectedIndex = comboLPDS.Items.Count - 1;
            }
        }
        
        private void checkLPDS_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkLPDS.Checked == true)
            {
                comboLPDS.Enabled = true;
                btnLPDSAdd.Enabled = true;
                if (comboLPDS.Items.Count == 0) LoadListLPDS();
            }
            else
            {
                comboLPDS.Enabled = false;
                btnLPDSAdd.Enabled = false;
            }
        }

        #endregion

    }
}
