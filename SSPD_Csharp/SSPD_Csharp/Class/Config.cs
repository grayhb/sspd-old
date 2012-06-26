using System;
using System.Collections.Generic;
using System.Text;

namespace SSPD
{
    class Config
    {
        /// <summary>
        /// Загрузка параметров пользователя
        /// </summary>
        public static void LoadDataUser()
        {
            //имя пользователя
            Params.UserInfo.RightUser = Environment.UserName;

            //проверка на соответствие имени пользователя (для разработчиков)
            if (Params.UserInfo.RightUser.ToUpper() == "DGK") Params.UserInfo.RightUser = "IsaevEN";

            string SqlStr = "SELECT Workers.ID_Worker, Workers.F_Worker + ' ' + Workers.I_Worker AS FIO, Workers.ID_Post, Workers.ID_Otdel, Otdels.NB_Otdel AS NBOtdel"
                            + " FROM Workers INNER JOIN"
                            + " Otdels ON Workers.ID_Otdel = Otdels.ID_Otdel"
                            + " WHERE     (Workers.Fl_Rel = 0) AND (Workers.Login = '" + Params.UserInfo.RightUser + "')";

            var rs = DB.GetFields(SqlStr);

            if (rs.Count == 0)
            {
                SSPDUI.MsgEx("Не найден Ваш логин в БД!", "Остановка запуска");
                System.Environment.Exit(0);
            }

            Params.UserInfo.ID_Worker = rs[0]["ID_Worker"].ToString();
            Params.UserInfo.FIO = rs[0]["FIO"].ToString();
            Params.UserInfo.ID_Post = rs[0]["ID_Post"].ToString();

            Params.UserInfo.ID_Otdel = rs[0]["ID_Otdel"].ToString();
            Params.UserInfo.NBOtdel = rs[0]["NBOtdel"].ToString();

        }


        /// <summary>
        /// Считывание параметров конфигурации из зашифрованного файла
        /// </summary>
        public static void ReadCFG()
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
        /// <param name="fileData">массив байтов</param>
        /// <param name="BegPos">начальная позиция</param>
        /// <param name="LenParam">длина параметра</param>
        /// <param name="psw">маска (соль)</param>
        /// <returns></returns>
        public static string ret(byte[] fileData, int BegPos, int LenParam, string psw)
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
        public static string Code(string text, string password)
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
