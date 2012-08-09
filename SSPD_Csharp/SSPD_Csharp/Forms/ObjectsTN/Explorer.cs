using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD.ObjectsTN
{
    public partial class Explorer : Form
    {

        #region [Объявление переменных]

        public string IDObj;
        public string TypeObj;
        public string NameObj;

        #endregion

        #region [Инициализация и загрузка формы]

        public Explorer()
        {
            InitializeComponent();
        }

        private void Explorer_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.Text += " [" + NameObj + "]";

            TreeExp.Nodes.Add(NameObj);
            SetMainIco(TreeExp.Nodes[0]);

            if (TypeObj =="Place") LoadPrj();

            LoadFilesGroup();

            TreeExp.Nodes[0].Expand();

            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region [Загрузка данных]

        /// <summary>
        /// Загрузка связанных проектов
        /// </summary>
        private void LoadPrj()
        {
            string SQLStr = " SELECT ProjectsObjectPlace.ID_Project, Projects.Sh_project, Projects.Name_Project, Orgs.Name, Workers.F_Worker + ' '+ Workers.I_Worker as GIP"
                            + " FROM ProjectsObjectPlace INNER JOIN"
                            + " Projects ON ProjectsObjectPlace.ID_Project = Projects.ID_Project INNER JOIN"
                            + " Orgs ON Projects.ID_Zak = Orgs.ID_Org INNER JOIN"
                            + " Workers ON Projects.ID_GIP = Workers.ID_Worker"
                            + " WHERE ProjectsObjectPlace.ID_Place = " + IDObj;

            var rs = DB.GetFields(SQLStr);
            if (rs.Count > 0)
            {
                TreeNode TN = new TreeNode();
                TN.Text = "Связанные проекты";
                TN.Tag = "PRJ";
                SetNodeIco(TN, 4);
                TN.Expand();
                TreeNode subTN;

                foreach (DataRow dr in rs)
                {
                    subTN = new TreeNode();
                    subTN.Tag = dr["ID_Project"];
                    subTN.Text = dr["Name_Project"].ToString();
                    subTN.Nodes.Add(new TreeNode("Шифр - " + dr["Sh_project"]));
                    subTN.Nodes.Add(new TreeNode("Заказчик - " + dr["Name"]));
                    subTN.Nodes.Add(new TreeNode("ГИП - " + dr["GIP"]));
                    SetNodeIco(subTN, 5);
                    TN.Nodes.Add(subTN);
                }

                TreeExp.Nodes[0].Nodes.Add(TN);
            }
        }

        /// <summary>
        /// Загрузка типов вспомогательных файлов
        /// </summary>
        private void LoadFilesGroup()
        {
            string SQLStr = " SELECT ObjectFilesType.Name_FT, ObjectFilesType.ID_Rec"
                         + " FROM ObjectFilesType INNER JOIN"
                         + " ObjectFiles ON ObjectFilesType.ID_Rec = ObjectFiles.IDT_F"
                         + " WHERE (ObjectFiles.ID_Object = " + IDObj + ") AND (ObjectFiles.ObjectType = '" + TypeObj + "')"
                         + " GROUP BY ObjectFilesType.Name_FT, ObjectFilesType.ID_Rec";
            var rs = DB.GetFields(SQLStr);
            if (rs.Count > 0)
            {
                TreeNode TN = new TreeNode();
                TN.Text = "Вспомогательные материалы";
                TN.Tag = "FILE";
                SetNodeIco(TN, 6);
                TN.Expand();
                TreeNode subTN;

                foreach (DataRow dr in rs)
                {
                    subTN = new TreeNode();
                    subTN.Tag = "PATH";
                    subTN.Text = dr["Name_FT"].ToString();
                    SetNodeIco(subTN, 7);
                    LoadFiles(dr["ID_Rec"].ToString(), subTN);
                    TN.Nodes.Add(subTN);
                }

                TreeExp.Nodes[0].Nodes.Add(TN);
            }
        }

        /// <summary>
        /// Загрузка вспомогательных файлов в указанный тип
        /// </summary>
        /// <param name="IDType">ID типа </param>
        /// <param name="TN">Ветка дерева</param>
        private void LoadFiles(string IDType, TreeNode TN)
        {
            string SQLStr = " SELECT ObjectFiles.Name_F, Workers.F_Worker + ' ' + Workers.I_Worker AS IDWCreator, "
            + " ObjectFiles.Date_Creation, ObjectFiles.ID_Rec, Orgs.Name  "
            + " FROM ObjectFiles LEFT OUTER JOIN"
            + " Workers ON ObjectFiles.ID_WorkerCreator = Workers.ID_Worker LEFT OUTER JOIN"
            + " Orgs ON ObjectFiles.ID_Org = Orgs.ID_Org"
            + " WHERE ObjectFiles.ID_Object = " + IDObj + " AND ObjectFiles.ObjectType = '" + TypeObj + "'"
            + " AND ObjectFiles.IDT_F = " + IDType;

            var rs = DB.GetFields(SQLStr);

            TreeNode subTN;

            foreach (DataRow dr in rs)
            {
                subTN = new TreeNode();
                subTN.Tag = dr["ID_Rec"];
                subTN.Text = dr["Name_F"].ToString();
                subTN.Nodes.Add(new TreeNode("Организация источник - " + dr["Name"].ToString()));
                subTN.Nodes.Add(new TreeNode("Добавил - " + dr["IDWCreator"].ToString()));
                subTN.Nodes.Add(new TreeNode("Дата добавления - " + Convert.ToDateTime(dr["Date_Creation"]).ToShortDateString()));
                SetNodeIco(subTN,8);
                TN.Nodes.Add(subTN);
            }

        }

        #endregion

        #region [Управление иконками]

        private void SetMainIco(TreeNode TN)
        {
            switch (TypeObj)
            {
                case "MN":
                    TN.ImageIndex = 0;
                    TN.SelectedImageIndex = TN.ImageIndex;
                    break;
                case "RNU":
                    TN.ImageIndex = 1;
                    TN.SelectedImageIndex = TN.ImageIndex;
                    break;
                case "LPDS":
                    TN.ImageIndex = 2;
                    TN.SelectedImageIndex = TN.ImageIndex;
                    break;
                case "Place":
                    TN.ImageIndex = 3;
                    TN.SelectedImageIndex = TN.ImageIndex;
                    break;
            }
        }

        private void SetNodeIco(TreeNode TN, int IndIco)
        {
            TN.ImageIndex = IndIco;
            TN.SelectedImageIndex = TN.ImageIndex;
        }

        #endregion

        #region [События элементов формы]

        private void Explorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void раскрытьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeExp.ExpandAll();
            TreeExp.SelectedNode = TreeExp.Nodes[0];
            TreeExp.Nodes[0].EnsureVisible();
        }

        private void свернутьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeExp.CollapseAll();
            TreeExp.SelectedNode = TreeExp.Nodes[0];
            TreeExp.Nodes[0].EnsureVisible();
        }

        #endregion


    }
}
