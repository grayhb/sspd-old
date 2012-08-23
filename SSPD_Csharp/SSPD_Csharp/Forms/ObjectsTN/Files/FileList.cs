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
    public partial class FileList : Form
    {

        #region [Объявление переменных]

        public string IDObj;
        public string TypeObj;
        public string NameObj;

        private string SqlFltr = "";
        private string SqlStr = "";
        #endregion

        #region [Инициализация и загрузка формы]

        public FileList()
        {
            InitializeComponent();

            StrFind.GotFocus += new EventHandler(StrFind_GotFocus);
            StrFind.LostFocus += new EventHandler(StrFind_LostFocus);
            StrFind.KeyDown += new KeyEventHandler(StrFind_KeyDown);
        }

        private void FileList_Load(object sender, EventArgs e)
        {
            SqlStr = " SELECT ObjectFilesType.Name_FT, ObjectFiles.Name_F, dbo.Workers.F_Worker + ' ' + dbo.Workers.I_Worker AS IDWCreator, "
                    + " ObjectFiles.Date_Creation, ObjectFiles.PathToImage, ObjectFiles.CRC, ObjectFiles.ID_Rec, ObjectFiles.ID_Object, "
                    + " ObjectFiles.ObjectType, Orgs.Name_Br, ObjectFiles.DateA, Workers.ID_Otdel, "
                    + " (SELECT Place_Name FROM ObjectPlace WHERE ID = ObjectFiles.ID_Object) as PlaceName, "
                    + " (SELECT RNU_Name FROM ObjectRNU WHERE ID = ObjectFiles.ID_Object) as RNUName, "
                    + " (SELECT LPDS_Name FROM ObjectLPDS WHERE ID = ObjectFiles.ID_Object) as LPDSName, "
                    + " (SELECT Orgs.Name_br FROM Orgs INNER JOIN ObjectMN ON Orgs.ID_Org = ObjectMN.ID_Org WHERE ObjectMN.ID = ObjectFiles.ID_Object) as MNName "
                    + " FROM          ObjectFiles LEFT OUTER JOIN"
                    + " ObjectFilesType ON ObjectFiles.IDT_F = ObjectFilesType.ID_Rec LEFT OUTER JOIN"
                    + " dbo.Workers ON ObjectFiles.ID_WorkerCreator = dbo.Workers.ID_Worker LEFT OUTER JOIN"
                    + " dbo.Orgs ON ObjectFiles.ID_Org = dbo.Orgs.ID_Org";

            if (IDObj != null)
                SetFilter(1, IDObj, TypeObj, mbtnFilterObj);
            else
                SetFilter(0, null, null, mbtnFilterNone);

            LoadData();

            LoadTypeFile();

            FillWidthDGVColumn();
        }

        /// <summary>
        /// Проверка доступа на запись
        /// </summary>
        private void CheckAccess()
        {
            mbtnFileDel.Visible = false;
            var rs = DB.GetFields("SELECT Val_Par FROM Params WHERE ID_Par = 212");
            if (rs.Count > 0)
            {
                if (rs[0]["Val_Par"].ToString() == Params.UserInfo.ID_Otdel)
                {
                    mbtnFileDel.Visible = true;
                }
            }

            if (Params.UserInfo.RightUser.ToUpper() == "ADMIN")
                mbtnFileDel.Visible = true;
        }

        #endregion

        #region [Загрузка и управление данными]

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            var rs = DB.GetFields(SqlStr + SqlFltr);
            DGV.Rows.Clear();
            DataGridViewRow DGVR;
            if (rs.Count > 0)
            {
                foreach (DataRow dr in rs)
                {
                    DGV.Rows.Add();
                    DGVR = DGV.Rows[DGV.Rows.GetLastRow(DataGridViewElementStates.Visible)];
                    DGVR.Tag = dr["ID_Rec"];
                    DGVR.Cells[0].Value = string.Format("{0:00000}",dr["ID_Rec"]);
                    DGVR.Cells[1].Value = dr["Name_F"];
                    DGVR.Cells[2].Value = dr["Name_FT"];
                    
                    switch (dr["ObjectType"].ToString())
                    {
                        case "MN":
                            DGVR.Cells[3].Value = dr["MNName"];
                            break;
                        case "RNU":
                            DGVR.Cells[3].Value = dr["RNUName"];
                            break;
                        case "LPDS":
                            DGVR.Cells[3].Value = dr["LPDSName"];
                            break;
                        case "Place":
                            DGVR.Cells[3].Value = dr["PlaceName"];
                            break;
                    }

                    DGVR.Cells[4].Value = dr["Name_Br"];
                    DGVR.Cells[5].Value = dr["IDWCreator"];
                    DGVR.Cells[6].Value = dr["Date_Creation"];
                    DGVR.Cells[7].Value = dr["CRC"];
                }
            }

            //красим строки
            SSPDUI.SetBgRowInDGV(DGV);

            Cursor.Current = Cursors.Default;
        }

        private void LoadTypeFile()
        {
            var rs = DB.GetFields("SELECT ID_Rec, Name_FT From ObjectFilesType");
            ToolStripMenuItem mitem;

            if (rs.Count > 0)
            {
                foreach (DataRow dr in rs)
                {
                    mitem = new ToolStripMenuItem();
                    mitem.Tag = dr["ID_Rec"];
                    mitem.Text = dr["Name_FT"].ToString();
                    mitem.Click += new EventHandler(mbtnFilterTypeItems_Click);
                    mbtnFilterType.DropDownItems.Add(mitem);
                }
            }
        }

        /// <summary>
        /// Установка фильтра
        /// </summary>
        /// <param name="TypeF">Тип фильтра</param>
        /// <param name="Par1">Параметр 1</param>
        /// <param name="Par2">Параметр 2</param>
        private void SetFilter(int TypeF, string Par1, string Par2, object MenuItem)
        {
            foreach (ToolStripItem mi in mbtnFilter.DropDownItems)
            {
                if (mi.GetType() == mbtnFilter.GetType())
                    ((ToolStripMenuItem)mi).Checked = false;
            }

            switch (TypeF) 
            {
                case 1:
                    SqlFltr = " WHERE ObjectFiles.ID_Object = " + Par1 + " AND  ObjectFiles.ObjectType = '" + Par2 + "'";
                    break;
                case 3:
                    foreach (ToolStripItem mi in mbtnFilterType.DropDownItems)
                    {
                        if (mi.GetType() == mbtnFilterType.GetType())
                            ((ToolStripMenuItem)mi).Checked = false;
                    }
                    SqlFltr = " WHERE ObjectFiles.IDT_F = " + ((ToolStripMenuItem)MenuItem).Tag.ToString();
                    break;
                case 4:
                    SqlFltr = " WHERE CHARINDEX('" + DB.SetQuotes(Par1) + "', ObjectFiles.Name_F) <> 0";
                    break;
                case 0:
                    SqlFltr = "";
                    break;
            }

            ((ToolStripMenuItem)MenuItem).Checked = true;
        }

        /// <summary>
        /// Открытие карточки материала
        /// </summary>
        /// <param name="IDFile">ID файла</param>
        private void OpenCard(string IDFile)
        {
            FileCard FC = new FileCard();
            FC.IDFile = IDFile;
            FC.ShowDialog();
            if (FC.FlSave == true)
            {
                DataGridViewRow DGVR = DGV.CurrentRow;
                DGVR.Cells[1].Value = FC.FileName.Text;
                DGVR.Cells[2].Value = FC.TypeM.Text;
                DGVR.Cells[3].Value = FC.ObjectName.Text;
                DGVR.Cells[4].Value = FC.Org.Text;
            }
        }

        /// <summary>
        /// Скачивание и открытие файла
        /// </summary>
        private void OpenFile()
        {
            if (DGV.SelectedRows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                FTP.FtpDownload(Params.ServerFTP.Adress, FTP.GetFileName(27, DGV.SelectedRows[0].Tag.ToString()), true);
            }
        }

        /// <summary>
        /// Добавление нового файла
        /// </summary>
        private void AddNewFile()
        {
            FileAdd FA = new FileAdd();
            FA.ShowDialog();

        }

        #endregion

        #region [События элементов формы]

        private void FileList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.F7) SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
        }

        private void FileList_SizeChanged(object sender, EventArgs e)
        {
            FillWidthDGVColumn();
        }

        /// <summary>
        /// Подгон столбца на всю ширину формы
        /// </summary>
        private void FillWidthDGVColumn()
        {
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Application.DoEvents();
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        }

        private void DGV_Sorted(object sender, EventArgs e)
        {
            //красим строки
            SSPDUI.SetBgRowInDGV(DGV);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
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
            if (e.KeyCode == Keys.Enter) SSPDUI.SearchInDGV(DGV, StrFind.Text, DGV.CurrentRow.Index);
        }

        private void mbtnFilterNone_Click(object sender, EventArgs e)
        {
            SetFilter(0, null, null, mbtnFilterNone);
            LoadData();
        }

        private void mbtnFilterTypeItems_Click(object sender, EventArgs e)
        {
            SetFilter(3, null, null, sender);
            LoadData();
        }

        private void mbtnFilterName_Click(object sender, EventArgs e)
        {
            SSPD.Input.InputPar Inp = new SSPD.Input.InputPar("Фильтр по вхождению в наименование материала", "", "Строка вхождения в наименование материала");
            Inp.ShowDialog();
            if (Inp.GetPar.Length > 0)
            {
                SetFilter(4, Inp.GetPar, null, mbtnFilterName);
                LoadData();
            }
        }

        private void mbtnFileOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }


        private void mbtnFileCard_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
                OpenCard(DGV.SelectedRows[0].Tag.ToString());
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1) 
                OpenCard(DGV.CurrentRow.Tag.ToString());
        }

        private void mbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbtnOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void cmbtnCard_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
                OpenCard(DGV.SelectedRows[0].Tag.ToString());
        }

        private void mbtnFileAdd_Click(object sender, EventArgs e)
        {
            AddNewFile();
        }

        private void mbtnFilterObj_Click(object sender, EventArgs e)
        {
            ObjectsTN.List ObjList = new ObjectsTN.List();
            ObjList.SelectMode = true;
            ObjList.ShowDialog();
            if (ObjList.FlSel == true)
            {
                SetFilter(1, ((Hashtable)ObjList.SelectData)["ID"].ToString(), ((Hashtable)ObjList.SelectData)["Type"].ToString(), mbtnFilterObj);
                LoadData();
            }
            ObjList.Dispose();
        }

        #endregion



    }
}
