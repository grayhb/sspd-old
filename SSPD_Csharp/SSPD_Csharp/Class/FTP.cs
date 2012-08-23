using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace SSPD
{
    class FTPClient : WebClient
    {
        protected override WebRequest GetWebRequest(System.Uri address)
        {
            FtpWebRequest req = (FtpWebRequest)base.GetWebRequest(address);
            req.UsePassive = false;
            return req;
        }
    }

    class FTP
    {
        private static Form pb;
        private static ProgressBar progbar;
        private static string LocalFileName;
        private static bool FlStart;

        /// <summary>
        /// Загрузка файла с ФТП сервера
        /// </summary>
        public static void FtpDownload(string host, string pathFtp, bool showpb)
        {
            if (FlStart != false)
            {
                SSPDUI.MsgEx("Операция загрузки файла уже запущена!","Остановка загрузки файла");
                return;
            }

            LocalFileName = System.IO.Path.GetTempFileName() + new System.IO.FileInfo(pathFtp).Extension;

            if (!host.StartsWith("ftp://"))
                host = "ftp://" + host;

            Uri uri = new Uri(host +"/"+ pathFtp);

            if (showpb == true) SetParamPB();

            FlStart = true;
            
            FTPClient request = new FTPClient();
            request.Credentials = new System.Net.NetworkCredential(Params.ServerFTP.UserNameRead, Params.ServerFTP.PasswordRead);
            request.DownloadProgressChanged += UpdateProgress;
            request.DownloadFileAsync(uri, LocalFileName);
            request.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadFileCompleted);

            if (showpb == true)
            {
                pb.Show();
                pb.Text = "Загрузка файла";
            }
        }

        public static void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (pb != null)
            {
                pb.Hide();
                pb.Dispose();
            }

            FlStart = false;

            if (System.IO.File.Exists(LocalFileName))
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = LocalFileName;
                proc.Start();
            }
            else
            {
                SSPDUI.MsgEx("Файл " + new System.IO.FileInfo(LocalFileName).Name + " не найден!", "Ошибка открытия файла");
            }
        }


        /// <summary>
        /// Обновление статуса загрузки файла
        /// </summary>
        private static void UpdateProgress(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            if (pb != null)
            {
                progbar.Value = e.ProgressPercentage;
                pb.Text = "Загрузка файла [" + e.ProgressPercentage.ToString() + "%" + "]";
            }
        }

        /// <summary>
        /// Утсановка параметров формы с ProgressBarом
        /// </summary>
        private static void SetParamPB()
        {
            pb = new Form();
            pb.FormBorderStyle = FormBorderStyle.FixedDialog;
            pb.TopMost = true;
            pb.ShowInTaskbar = false;
            pb.Size = new System.Drawing.Size(250, 30);
            pb.ControlBox = false;
            //pb.StartPosition = FormStartPosition.CenterScreen;
            pb.StartPosition = FormStartPosition.Manual;
            pb.Left = Screen.PrimaryScreen.WorkingArea.Width - 300;
            pb.Top = Screen.PrimaryScreen.WorkingArea.Height - 100;
            pb.Opacity = 0.75;
            
            progbar = new ProgressBar();
            pb.Controls.Add(progbar);
            progbar.Dock = DockStyle.Fill;
            progbar.Value = 0;
            progbar.Maximum = 100;
            progbar.Style = ProgressBarStyle.Continuous;
            
        }

        /// <summary>
        /// Возвращает путь до файла на ФТП сервере
        /// </summary>
        /// <param name="TypeDoc">Тип документа (цифровое обозначение)</param>
        /// <param name="IDDoc">ID документа</param>
        /// <returns></returns>
        public static string GetFileName(int TypeDoc, string IDDoc)
        {
            string TBLName="";
            string CNameID = "";
            string CNamePathFile = "";

            switch (TypeDoc)
            {
                case 10:
                    TBLName = "ZPExp";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathF";
                    break;
                case 11:
                    TBLName = "ZPZadExpZP";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathFAnswer";
                    break;
                case 12:
                    TBLName = "ZPExp";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathFExpRep";
                    break;
                case 13:
                    TBLName = "Nakls";
                    CNameID = "ID_Nakl";
                    CNamePathFile = "PathToImage";
                    break;
                case 14:
                    TBLName = "DocsInput";
                    CNameID = "ID_DocInp";
                    CNamePathFile = "PathToImage";
                    break;
                case 15:
                    TBLName = "DocsOutput";
                    CNameID = "ID_DocOut";
                    CNamePathFile = "PathToImage";
                    break;
                case 16:
                    TBLName = "DocsInner";
                    CNameID = "ID_DocInn";
                    CNamePathFile = "PathToImage";
                    break;
                case 17:
                    TBLName = "DocsDirect";
                    CNameID = "ID_DocDir";
                    CNamePathFile = "PathToImage";
                    break;
                case 18:
                    TBLName = "Dogovors";
                    CNameID = "ID_Dog";
                    CNamePathFile = "PathToImage";
                    break;
                case 21: //Экспертные заключения
                    TBLName = "ExpZak";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathFExpZ";
                    break;
                case 22: //Задание на проектирование из отдела в отдел
                    TBLName = "ExchandeZadReestr";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathFilesPril";
                    break;
                case 23: //Задание на проектирование из отдела в отдел (приложения)
                    TBLName = "ExchandeZadReestr";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathFiles";
                    break;
                case 24: //Задание на проектирование от ГИПов в отдел
                    TBLName = "ZadFromGIPReestr";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathFiles";
                    break;
                case 25: //Задание на проектирование от ГИПов в отдел (приложения)
                    TBLName = "ZadFromGIPReestr";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathFilesPril";
                    break;
                case 26: //Документы к проекту
                    TBLName = "ProjectDoc";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathToImage";
                    break;
                case 27: //Файлы к объекту
                    TBLName = "ObjectFiles";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathToImage";
                    break;
                case 28: //Файлы ВНД
                    TBLName = "VNDReestr";
                    CNameID = "ID_Rec";
                    CNamePathFile = "PathToImage";
                    break;
            }

            //если данные не определены - выходим
            if (TBLName.Length == 0 || CNameID.Length == 0 || CNamePathFile.Length == 0) return "";

            var rs = DB.GetFields("SELECT " + CNamePathFile + " FROM " + TBLName + " WHERE " + CNameID + "=" + IDDoc);

            if (rs.Count == 0)
            {
                SSPDUI.MsgEx("Отсутствует электронный вариант документа!", "Остановка операции");
                return "";
            }
            else if (rs[0][0].ToString().Length ==0 ) 
            {
                SSPDUI.MsgEx("Отсутствует электронный вариант документа!", "Остановка операции");
                return "";
            }

            return rs[0][0].ToString();

        }

        /// <summary>
        /// Вычисление хеша MD5 из файла
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        /// <returns>Хэш MD5 или пустую строку в случае отсутствия файла</returns>
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                MD5 md5 = new MD5CryptoServiceProvider();
                StringBuilder sb = new StringBuilder();
                foreach (byte b in md5.ComputeHash(file))
                {
                    sb.Append(b.ToString("x2").ToUpper());
                }
                file.Close();
                return sb.ToString();
            }
            catch
            {
                return "";
            }
            
        }

    }

}
