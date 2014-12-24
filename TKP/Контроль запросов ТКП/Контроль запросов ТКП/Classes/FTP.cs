using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SSPD;
using System.IO;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace Контроль_запросов_ТКП
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

        public static void DonwloadFile(string path, string Nzad = "", string sFile = "", bool flOpen = true)
        {
            try
            {
                string tmpFile ="";
                if (sFile.Length == 0)
                    tmpFile = Path.GetTempPath() + GetExt(path);
                else
                    tmpFile = sFile;

                FTPClient request = new FTPClient();
                request.Credentials = new System.Net.NetworkCredential(Config.ServerFTP.UserNameRead, Config.ServerFTP.PasswordRead);
                request.Proxy = null;
                request.DownloadFile("ftp://" + Config.ServerFTP.Adress + "/" + path, tmpFile);
                

                if (Nzad != "") SetNumZadInPDF(tmpFile, Nzad);

                //автооткрытие
                if (flOpen)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = tmpFile;
                    proc.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private static string GetExt(string fname)
        {
            string ext = "";

            int i = fname.Length-1;
            while (true)
            {
                if (fname.Substring(i, 1) == "/")
                    break;
                else
                {
                    ext = fname.Substring(i, 1) + ext;
                }
                i--;  
            }

            return ext;
        }

        
        private static void SetNumZadInPDF(string FPath, string Nzad)
        {
            try
            {
                PdfDocument pdf = PdfReader.Open(FPath, PdfDocumentOpenMode.Modify);
                PdfPage pdfP = pdf.Pages[0];
                pdfP.Orientation = PageOrientation.Portrait;
                XGraphics XG = XGraphics.FromPdfPage(pdfP);
                XFont XF = new XFont("Verdana", 10, XFontStyle.Bold);
                XG.DrawString(Nzad, XF, XBrushes.Black, new XRect(30, 10, pdfP.Height.Point, pdfP.Width.Point), XStringFormats.TopCenter);

                foreach (PdfPage pp in pdf.Pages)
                    pp.Orientation = PageOrientation.Portrait;

                pdf.Save(FPath);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message,"Ошибка!");
                Console.WriteLine(ex.Message);
            }
        }
        

    }
}
