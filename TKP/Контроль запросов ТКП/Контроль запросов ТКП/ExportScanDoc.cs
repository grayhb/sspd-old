using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Контроль_запросов_ТКП
{
    public partial class ExportScanDoc : Form
    {

        public DataGridView DGV;

        private bool flStop = false;
        private DateTime dt_start;
        private int countDocOut;
        private int countDocInp;

        public ExportScanDoc()
        {
            InitializeComponent();
        }

        private void ExportScanDoc_Load(object sender, EventArgs e)
        {
            //Параметры формы:
            this.Size = new Size(500, 180);
            //по умолчанию папка - мои документы
            textPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            //textPath.Text = @"D:\_TEST_\";

        }

        private void ExportScanDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) flStop = true;
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
                textPath.Text = fBDialog.SelectedPath;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            this.Size = new Size(500,220);
            Application.DoEvents();

            
            flStop = false;
            countDocInp = 0;
            countDocOut = 0;
            dt_start = DateTime.Now;
            
            doExport();

            Application.DoEvents();
            this.Size = new Size(500, 180);


            TimeSpan ts = DateTime.Now - dt_start;
            MessageBox.Show("Экспорт завершен!\nВремя выполнения: " + ts.ToString(@"hh\:mm\:ss")
                        + "\n\nЭкспортировано:\n"
                        + "Исходящих документов - " + countDocOut.ToString()
                        + "\nВходящих документов - " + countDocInp.ToString()
                        ,"Экспорт документов"
                        ,MessageBoxButtons.OK
                        , MessageBoxIcon.Information);


            if (MessageBox.Show("Открыть папку экспорта?","Экспорт документов",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("explorer", textPath.Text);
            }
        }


        /// <summary>
        /// Процедура экспорта документов
        /// </summary>
        private void doExport()
        {
            PB.Maximum = DGV.Rows.Count;
            PB.Visible = true;
            PB.Value = 0;

            foreach (DataGridViewRow DGVR in DGV.Rows)
            {

                var rs = LocalDB.LoadData("SELECT ID_OutDoc, ID_InpDoc, Mail_Note, DateStartTKP, DateFinishTKP FROM КонтрольТКП_Письма WHERE ID_TKP = " + ((Hashtable)DGVR.Tag)["ID_TKP"].ToString() + " ORDER BY ID_OutDoc ASC");
                if (rs != null && rs.Count > 0)
                {
                    foreach (DataRow dr in rs)
                    {
                        int idOut = 0; int idInp = 0;

                        if (dr["ID_OutDoc"].ToString() != "") idOut = (int)dr["ID_OutDoc"];
                        if (dr["ID_InpDoc"].ToString() != "") idInp = (int)dr["ID_InpDoc"];

                        Hashtable h = new Hashtable();

                        h = this.getDataMail(idOut, idInp);

                        
                        string FName = textPath.Text;
                        string FNameOut = "";
                        string FNameInp = "";

                        //группировка по проектам
                        if (checkProject.Checked)
                        {
                            FName += "\\" + ConvertFileName(((Hashtable)DGVR.Tag)["Sh_project"].ToString()) + "\\";
                            createPath(FName);
                        }

                        //группировка по заданиям
                        if (checkZad.Checked) 
                        {
                            FName += ConvertFileName(DGVR.Cells["NZ"].Value.ToString()) + "\\";
                            createPath(FName);
                        }


                        //скачиваем исходящий документ
                        if (h.Contains("rn_DocOut") && checkOutDoc.Checked)
                        {
                            FNameOut = FName + "Исходящие\\";
                            createPath(FNameOut);

                            FNameOut += string.Format("{0:yyyy_MM_dd}", Convert.ToDateTime(h["date_DocOut"])) + " №" + ConvertFileName(h["rn_DocOut"].ToString());
                            if (!h.Contains("rn_DocInp")) 
                                FNameOut += " [без ответа]";
                            else
                                FNameOut += " [вх - " + string.Format("{0:yyyy_MM_dd}", Convert.ToDateTime(h["date_DocInp"])) + " №" + ConvertFileName(h["rn_DocInp"].ToString()) + "]";
                            FNameOut += ".pdf";

                            FTP.DonwloadFile(h["PathToImg_DocOut"].ToString(), "", FNameOut, false);
                            countDocOut++;
                        }

                        //скачиваем входящий документ
                        if (h.Contains("rn_DocInp") && checkInpDoc.Checked) 
                        {
                            FNameInp = FName + "Входящие\\";
                            createPath(FNameInp);

                            FNameInp += string.Format("{0:yyyy_MM_dd}", Convert.ToDateTime(h["date_DocInp"])) + " №" + ConvertFileName(h["rn_DocInp"].ToString()) + ".pdf";
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
                //dt_start
                Application.DoEvents();
            }

            PB.Visible = false;
        }


        /// <summary>
        /// Функция формирования массива данных по заданиям ТКП
        /// </summary>
        /// <param name="DGV">Элемент со списком заданий</param>
        /// <returns></returns>
        private List<Hashtable> CreateHash(DataGridView DGV)
        {
            List<Hashtable> arrTKP = new List<Hashtable>();

            PB.Maximum = DGV.Rows.Count * 2;


            foreach (DataGridViewRow DGVR in DGV.Rows)
            {

                Hashtable zadTKP = new Hashtable();
                zadTKP.Add("NZ", DGVR.Cells["NZ"].Value);


                var rs = LocalDB.LoadData("SELECT ID_OutDoc, ID_InpDoc, Mail_Note, DateStartTKP, DateFinishTKP FROM КонтрольТКП_Письма WHERE ID_TKP = " + ((Hashtable)DGVR.Tag)["ID_TKP"].ToString() + " ORDER BY ID_OutDoc ASC");
                if (rs != null && rs.Count > 0)
                {
                    List<Hashtable> arrMail = new List<Hashtable>();

                    foreach (DataRow dr in rs)
                    {
                        int idOut = 0; int idInp = 0;

                        if (dr["ID_OutDoc"].ToString() != "") idOut = (int)dr["ID_OutDoc"];
                        if (dr["ID_InpDoc"].ToString() != "") idInp = (int)dr["ID_InpDoc"];

                        Hashtable h = new Hashtable();

                        h = this.getDataMail(idOut, idInp);
                        //h.Add("Mail_Note", dr["Mail_Note"].ToString());

                        arrMail.Add(h);

                        h = null;
                    }
                    zadTKP.Add("Mail", arrMail);
                    arrMail = null;
                }
                PB.Value++;

                arrTKP.Add(zadTKP);
                zadTKP = null;
            }

            return arrTKP;
        }


        /// <summary>
        /// Получает данные по письмам из базы ССПД
        /// </summary>
        /// <param name="id_DocOut">ID - исходящего письма</param>
        /// <param name="id_DocInp">ID - входящего письма</param>
        /// <returns>Хэшкод</returns>
        private Hashtable getDataMail(int id_DocOut, int id_DocInp)
        {
            Hashtable h = new Hashtable();
            string sql = "";

            //данные исходящего письма
            if (id_DocOut > 0)
            {
                sql = "SELECT RN_DocOut,  Date_DocOut, PathToImage ";
                sql += " FROM DocsOutput ";
                sql += " WHERE  ID_DocOut = " + id_DocOut.ToString();
                var rs = SSPD.DB.GetFields(sql);
                if (rs != null && rs.Count > 0)
                {
                    h.Add("rn_DocOut", rs[0]["RN_DocOut"].ToString());
                    h.Add("date_DocOut", rs[0]["Date_DocOut"].ToString());
                    h.Add("PathToImg_DocOut", rs[0]["PathToImage"].ToString());
                }
                rs = null;
            }

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
