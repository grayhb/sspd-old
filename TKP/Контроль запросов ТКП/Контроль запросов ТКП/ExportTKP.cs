using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Контроль_запросов_ТКП
{
    public partial class ExportTKP : Form
    {

        public DataGridView DGV;

        private bool flStop = false;
        private DateTime dt_start;
        private int countDocInp;

        public ExportTKP()
        {
            InitializeComponent();
        }

        private void ExportTKP_Load(object sender, EventArgs e)
        {
            //Параметры формы:
            this.Size = new Size(500, 130);

            //по умолчанию папка - мои документы
            if (Properties.Settings.Default.PathExportTKP.Length == 0)
                textPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                textPath.Text = Properties.Settings.Default.PathExportTKP;
            

        }


        /// <summary>
        /// Экспорт документов
        /// </summary>
        private void doExport()
        {
            PB.Maximum = DGV.Rows.Count;
            PB.Visible = true;
            PB.Value = 0;

            foreach (DataGridViewRow DGVR in DGV.Rows)
            {

                var rs = LocalDB.LoadData("SELECT ID_InpDoc, Mail_Note, DateStartTKP, DateFinishTKP FROM КонтрольТКП_Письма WHERE ID_InpDoc IS NOT NULL AND StatusDoc = 1 AND ID_TKP = " + ((Hashtable)DGVR.Tag)["ID_TKP"].ToString() + " ORDER BY ID_InpDoc ASC");
                if (rs != null && rs.Count > 0)
                {
                    foreach (DataRow dr in rs)
                    {
                        int idInp = 0;

                        if (dr["ID_InpDoc"].ToString() != "") idInp = (int)dr["ID_InpDoc"];

                        Hashtable h = new Hashtable();

                        h = this.getDataMail(idInp);

                        string FName = textPath.Text;
                        string FNameInp = "";

                        //группировка по проектам
                        //if (checkProject.Checked)
                        //{
                            FName += "\\" + ConvertFileName(((Hashtable)DGVR.Tag)["Sh_project"].ToString()) + "\\";
                            createPath(FName);
                        //}


                        //скачиваем входящий документ
                        if (h.Contains("rn_DocInp"))
                        {
                            //FNameInp = FName + "Входящие\\";
                            //createPath(FNameInp);

                            FNameInp = FName;

                            //КодМТР в начале файла
                            string CodeMTR = getCodeMTR(((Hashtable)DGVR.Tag)["ID_TKP"].ToString());
                            FNameInp += string.Format("{0}_",CodeMTR);

                            string AuthorInfo = getInfoAuthorZad(DGVR.Cells["NZ"].Value.ToString());
                            FNameInp += string.Format("{0}_", AuthorInfo);

                            FNameInp += string.Format("вх. от {0:yyyy.MM.dd}", Convert.ToDateTime(h["date_DocInp"])) + " №" + ConvertFileName(h["rn_DocInp"].ToString()) + ".pdf";

                            FTP.DonwloadFile(h["PathToImg_DocInp"].ToString(), "", FNameInp, false);
                            countDocInp++;
                        }

                        h = null;
                    }
                }



                if (flStop) break;
                PB.Value++;
                TimeSpan ts = DateTime.Now - dt_start;
                this.Text = "Время выполнения: " + ts.ToString(@"hh\:mm\:ss");  //string.Format("{0:hh:mm:ss}", DateTime.Now - dt_start);
                Application.DoEvents();
            }


            PB.Visible = false;
        }


        private void cmdExport_Click(object sender, EventArgs e)
        {

            //проверка существует ли папка

            if (!Directory.Exists(textPath.Text))
            {
                MessageBox.Show("Выбранная папка не существует :(","Остановка операции",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Size = new Size(500, 165);
            Application.DoEvents();


            flStop = false;
            countDocInp = 0;
            dt_start = DateTime.Now;

            doExport();

            Application.DoEvents();
            this.Size = new Size(500, 130);


            TimeSpan ts = DateTime.Now - dt_start;
            MessageBox.Show("Экспорт завершен!\nВремя выполнения: " + ts.ToString(@"hh\:mm\:ss")
                        + "\n\nЭкспортировано:\n"
                        + "\nВходящих документов - " + countDocInp.ToString()
                        , "Экспорт документов"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);


            if (MessageBox.Show("Открыть папку экспорта?", "Экспорт документов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("explorer", textPath.Text);
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOpenFolder_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = fBDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textPath.Text = fBDialog.SelectedPath;
                Properties.Settings.Default.PathExportTKP = fBDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Возвращает данные пользователя выдавшего задания
        /// </summary>
        /// <param name="NZ">Номер задания</param>
        /// <returns>Фамилия_Отдел</returns>
        private string getInfoAuthorZad(string NZ)
        {
            string InfoAuthor = "";

            string sql = "SELECT Workers.F_Worker, Otdels.NB_Otdel, ExchandeZadReestr.ID_Rec ";
            sql += " FROM Otdels INNER JOIN";
            sql += " Workers ON Otdels.ID_Otdel = dbo.MainOtdel(Workers.ID_Otdel) INNER JOIN";
            sql += " ExchandeZadReestr ON Workers.ID_Worker = ExchandeZadReestr.ID_WorkerOut";
            sql += " WHERE ExchandeZadReestr.ID_Rec = "  + Convert.ToInt32(NZ).ToString();

            var rs = SSPD.DB.GetFields(sql);
            if (rs != null && rs.Count > 0)
            {
                InfoAuthor = string.Format("{0}_{1}", rs[0]["F_Worker"].ToString(), rs[0]["NB_Otdel"].ToString());
            }

            return InfoAuthor;
        }


        /// <summary>
        /// Получение кода МТР из карточки запроса ТКП
        /// </summary>
        /// <param name="ID_TKP">ID карточки ТКП</param>
        /// <returns>Код МТР</returns>
        private string getCodeMTR(string ID_TKP)
        {
            string CodeMTR = "";

            string sql = "SELECT Code FROM ГруппыМТР INNER JOIN ";
            sql += " КонтрольТКП ON КонтрольТКП.ID_MTR = ГруппыМТР.ID_Rec ";
            sql += " WHERE КонтрольТКП.ID_TKP = " + ID_TKP;

            var rs = LocalDB.LoadData(sql);
            if (rs != null && rs.Count > 0)
            {
                CodeMTR = rs[0]["Code"].ToString();
            }

            return CodeMTR;
        }


        /// <summary>
        /// Получает данные по письмам из базы ССПД
        /// </summary>
        /// <param name="id_DocInp">ID - входящего письма</param>
        /// <returns>Хэшкод</returns>
        private Hashtable getDataMail( int id_DocInp)
        {
            Hashtable h = new Hashtable();
            string sql = "";

            ////данные исходящего письма
            //if (id_DocOut > 0)
            //{
            //    sql = "SELECT RN_DocOut,  Date_DocOut, PathToImage ";
            //    sql += " FROM DocsOutput ";
            //    sql += " WHERE  ID_DocOut = " + id_DocOut.ToString();
            //    var rs = SSPD.DB.GetFields(sql);
            //    if (rs != null && rs.Count > 0)
            //    {
            //        h.Add("rn_DocOut", rs[0]["RN_DocOut"].ToString());
            //        h.Add("date_DocOut", rs[0]["Date_DocOut"].ToString());
            //        h.Add("PathToImg_DocOut", rs[0]["PathToImage"].ToString());
            //    }
            //    rs = null;
            //}

            //данные входящего письма
            if (id_DocInp > 0)
            {
                sql = "Select RN_DocInp, Date_DocInp, PathToImage  FROM DocsInput WHERE ID_DocInp = " + id_DocInp.ToString();
                var rs = SSPD.DB.GetFields(sql);
                if (rs != null && rs.Count > 0)
                {
                    h.Add("rn_DocInp", rs[0]["RN_DocInp"].ToString());
                    h.Add("date_DocInp", rs[0]["Date_DocInp"].ToString());
                    h.Add("PathToImg_DocInp", rs[0]["PathToImage"].ToString());
                }
            }


            return h;
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
            if (!Directory.Exists(PathOut)) // "!" забыл поставить
            {
                Directory.CreateDirectory(PathOut);
            }
        }


    }
}
