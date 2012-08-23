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
    public partial class FileCard : Form
    {
        #region [Объявление переменных]

        public string IDFile;

        // флаг возможности сохранения карточки
        private bool doSave = false;

        //флаг изменения данных в карточке
        public bool FlSave = false;

        #endregion

        #region [Инициализация и загрузка формы]

        public FileCard()
        {
            InitializeComponent();
        }

        private void FileCard_Load(object sender, EventArgs e)
        {
            LoadData();
            CheckAccess();
        }

        #endregion



        #region [Загрузка и управление данными]

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            string SQLStr = " SELECT ObjectFilesType.Name_FT, ObjectFiles.Name_F, dbo.Workers.F_Worker + ' ' + dbo.Workers.I_Worker AS IDWCreator, W2.F_Worker + ' ' + W2.I_Worker AS WorkerA,"
                        + " ObjectFiles.Date_Creation, ObjectFiles.PathToImage, ObjectFiles.CRC, ObjectFiles.ID_Rec, ObjectFiles.ID_Object, ObjectFiles.IDT_F, "
                        + " ObjectFiles.ObjectType, Orgs.Name, ObjectFiles.DateA, Workers.ID_Otdel, ObjectFiles.ID_Org, ObjectFiles.IDT_F, "
                        + " (SELECT Place_Name FROM ObjectPlace WHERE ID = ObjectFiles.ID_Object) as PlaceName, "
                        + " (SELECT RNU_Name FROM ObjectRNU WHERE ID = ObjectFiles.ID_Object) as RNUName, "
                        + " (SELECT LPDS_Name FROM ObjectLPDS WHERE ID = ObjectFiles.ID_Object) as LPDSName, "
                        + " (SELECT Orgs.Name_br FROM Orgs INNER JOIN ObjectMN ON Orgs.ID_Org = ObjectMN.ID_Org WHERE ObjectMN.ID = ObjectFiles.ID_Object) as MNName "
                        + " FROM          ObjectFiles LEFT OUTER JOIN"
                        + " ObjectFilesType ON ObjectFiles.IDT_F = ObjectFilesType.ID_Rec LEFT OUTER JOIN"
                        + " dbo.Workers ON ObjectFiles.ID_WorkerCreator = dbo.Workers.ID_Worker LEFT OUTER JOIN"
                        + " dbo.Workers W2 ON ObjectFiles.ID_WorkerA = W2.ID_Worker LEFT OUTER JOIN"
                        + " dbo.Orgs ON ObjectFiles.ID_Org = dbo.Orgs.ID_Org"
                        + " WHERE ObjectFiles.ID_Rec = " + IDFile;

            var rs = DB.GetFields(SQLStr);
            if (rs.Count > 0)
            {
                DataRow dr = rs[0];

                RegN.Text = string.Format("{00000}",dr["ID_Rec"].ToString());
                TypeM.Text = dr["Name_FT"].ToString();
                TypeM.Tag = dr["IDT_F"];
                FileName.Text = dr["Name_F"].ToString();
                Org.Text = dr["Name"].ToString();
                Org.Tag = dr["ID_Org"].ToString();

                switch (dr["ObjectType"].ToString())
                {
                    case "MN":
                        ObjectName.Text  = dr["MNName"].ToString();
                        break;
                    case "RNU":
                        ObjectName.Text = dr["RNUName"].ToString();
                        break;
                    case "LPDS":
                        ObjectName.Text = dr["LPDSName"].ToString();
                        break;
                    case "Place":
                        ObjectName.Text = dr["PlaceName"].ToString();
                        break;
                }

                DateAdd.Text = string.Format("{0:yyyy-MM-dd}",dr["Date_Creation"].ToString());
                WorkerAdd.Text = dr["IDWCreator"].ToString();

                DateArch.Text = dr["DateA"].ToString();
                WorkerArch.Text = dr["WorkerA"].ToString();
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Проверка доступа на запись
        /// </summary>
        private void CheckAccess()
        {
            var rs = DB.GetFields("SELECT Val_Par FROM Params WHERE ID_Par = 212");
            if (rs.Count > 0)
            {
                if (rs[0]["Val_Par"].ToString() == Params.UserInfo.ID_Otdel)
                {
                    doSave = true;
                    return;
                }
            }

            if (Params.UserInfo.RightUser.ToUpper() == "ADMIN")
            {
                doSave = true;
                return;
            }

            doSave = false;
            btnSelType.Enabled = false;
            btnSelObj.Enabled = false;
            btnSelOrg.Enabled = false;
            FileName.ReadOnly = true;
        }

        #endregion

        #region [События элементов формы]

        private void FileCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FTP.FtpDownload(Params.ServerFTP.Adress, FTP.GetFileName(27, IDFile), true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSelType_Click(object sender, EventArgs e)
        {
            var rs = DB.GetFields("SELECT ID_Rec, Name_FT From ObjectFilesType");
            if (rs.Count>0) {
                Dictionary<int, string> CT = new Dictionary<int,string>();
                foreach (DataRow dr in rs)
                    CT.Add((int)dr["ID_Rec"], dr["Name_FT"].ToString());
                SSPD.Select.SelectPar SP = new SSPD.Select.SelectPar("Выбор параметра", "Тип материала");
                SP.SetPar = CT;
                SP.IDSel = Convert.ToInt32(TypeM.Tag);
                SP.ShowDialog();
                if (SP.FlSel == true)
                {
                    TypeM.Tag = ((SSPDUI.ComboType)SP.Par.SelectedItem).ID_Item;
                    TypeM.Text = ((SSPDUI.ComboType)SP.Par.SelectedItem).Name_Item;
                    Dictionary<string, string> DS = new Dictionary<string, string>();
                    DS.Add("IDT_F", TypeM.Tag.ToString());
                    DB.SetFields(DS,"ObjectFiles","ID_Rec = " + IDFile);
                    FlSave = true;
                }
                SP.Dispose();
            }
        }

        private void btnSelOrg_Click(object sender, EventArgs e)
        {
            SSPD.Select.Orgs SelOrg = new SSPD.Select.Orgs();
            SelOrg.means = 5;
            SelOrg.SelRow = Org.Tag.ToString();
            SelOrg.ShowDialog();
            if (SelOrg.FlSel == true)
            {
                Org.Text = SelOrg.SelectValue;
                Org.Tag = SelOrg.SelectID;
                Dictionary<string, string> DS = new Dictionary<string, string>();
                DS.Add("ID_Org", SelOrg.SelectID);
                DB.SetFields(DS, "ObjectFiles", "ID_Rec = " + IDFile);
                FlSave = true;
            }
            SelOrg.Dispose();
        }

        private void btnSelObj_Click(object sender, EventArgs e)
        {
            ObjectsTN.List ObjList = new ObjectsTN.List();
            ObjList.SelectMode = true;
            ObjList.ShowDialog();
            if (ObjList.FlSel == true)
            {
                ObjectName.Text = ((Hashtable)ObjList.SelectData)["Name"].ToString();

                Dictionary<string, string> DS = new Dictionary<string, string>();
                DS.Add("ObjectType", ((Hashtable)ObjList.SelectData)["Type"].ToString());
                DS.Add("ID_Object", ((Hashtable)ObjList.SelectData)["ID"].ToString());
                DB.SetFields(DS, "ObjectFiles", "ID_Rec = " + IDFile);
                FlSave = true;
            }
            ObjList.Dispose();
        }

        #endregion

        private void FileName_TextChanged(object sender, EventArgs e)
        {
            if (doSave == true)
            {
                Dictionary<string, string> DS = new Dictionary<string, string>();
                DS.Add("Name_F", FileName.Text);
                DB.SetFields(DS, "ObjectFiles", "ID_Rec = " + IDFile);
                FlSave = true;
            }
        }
        
    }
}
