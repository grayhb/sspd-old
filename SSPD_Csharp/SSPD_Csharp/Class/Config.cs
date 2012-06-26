using System;
using System.Collections.Generic;
using System.Text;

namespace SSPD
{
    class Config
    {
        /// <summary>
        /// Считывание конфигурации из файла
        /// </summary>
        public void ReadCFG()
        {
            string StrPar = "";

            int LenStrPar = 0;
            int BegPos = 0;

            byte[] fileData; //массив 

            using (System.IO.FileStream fs = System.IO.File.OpenRead(Params.CfgPath))
            {
                fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
            }

            BegPos = 0;
            LenStrPar = 90 - fileData[fileData.Length - 1] - 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerSQL.DataSource = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerSQL.database = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerSQL.SERVERProvider = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerSQL.uid = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerSQL.pwd = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerFTP.Adress = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerFTP.Port = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerFTP.UserNameWrite = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerFTP.PasswordWrite = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerFTP.UserNameRead = StrPar;

            BegPos += LenStrPar + 1;

            LenStrPar = 90 - fileData[BegPos] - 1;
            BegPos += 1;
            StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
            Params.ServerFTP.PasswordRead = StrPar;



            if (BegPos < fileData.Length)
            {
                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerSQLPCD.DataSource = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerSQLPCD.database = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerSQLPCD.SERVERProvider = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerSQLPCD.uid = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerSQLPCD.pwd = StrPar;
            }


            if (BegPos < fileData.Length)
            {
                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFSO.Adress = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFSO.Port = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFSO.UserNameWrite = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFSO.PasswordWrite = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFSO.UserNameRead = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFSO.PasswordRead = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFR.Adress = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFR.Port = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFR.UserNameWrite = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFR.PasswordWrite = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFR.UserNameRead = StrPar;

                BegPos += LenStrPar + 1;
                LenStrPar = 90 - fileData[BegPos] - 1;
                BegPos += 1;
                StrPar = ret(fileData, BegPos, LenStrPar, Params.Mask);
                Params.ServerFTPFR.PasswordRead = StrPar;
            }

            Params.ConString = "Data Source=" + Params.ServerSQL.DataSource
                                    + ";database=" + Params.ServerSQL.database + ";User Id=" + Params.ServerSQL.uid + ";Password="
                                    + Params.ServerSQL.pwd + ";";


        }

        /// <summary>
        /// Расшифровка параметров конфигурации
        /// </summary>
        /// <param name="fileData">массив байт</param>
        /// <param name="BegPos">начальная позиция</param>
        /// <param name="LenParam">длина параметра</param>
        /// <param name="psw">маска (соль)</param>
        /// <returns></returns>
        public string ret(byte[] fileData, int BegPos, int LenParam, string psw)
        {
            string Res = "";
            Int32 yy;

            // создаем цикличный ключ
            while (psw.Length <= LenParam)
            {
                psw += psw;
            }

            ASCIIEncoding ascii = new ASCIIEncoding();

            byte[] PswByte = ascii.GetBytes(psw);
            byte[] tmpbyte = new byte[LenParam + 1];

            for (int i = 0; i <= LenParam; i++)
            {
                yy = (fileData[i + BegPos] + 256) - PswByte[i];
                tmpbyte[i] = Convert.ToByte(yy % 256);
            }

            Res = ascii.GetString(tmpbyte);

            return Res;
        }


        /// <summary>
        /// Шифрование параметров конфигурации
        /// </summary>
        /// <param name="text">строка для шифрования</param>
        /// <param name="password">маска (соль)</param>
        /// <returns></returns>
        public string Code(string text, string password)
        {
            string Res = null;
            Int32 yy = 0;

            // создаем цикличный ключ
            while (password.Length < text.Length)
            {
                password += password;
            }

            Encoding enc = Encoding.GetEncoding(1251);
            byte[] arrByte = new byte[text.Length];

            for (int i = 0; i <= text.Length-1; i++)
            {
                yy = Convert.ToInt32(enc.GetBytes(text.Substring(i, 1).ToCharArray(), 0, 1)[0]) + 256 +
                     Convert.ToInt32(enc.GetBytes(password.Substring(i, 1).ToCharArray(), 0, 1)[0]);
                arrByte[i] = Convert.ToByte(yy % 256 );
            }

            Res = enc.GetString(arrByte, 0, arrByte.Length);

            return Res;
        }

    }
}
