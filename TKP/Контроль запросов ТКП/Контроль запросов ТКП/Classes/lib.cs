using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Контроль_запросов_ТКП
{
    public static class lib
    {

        /// <summary>
        /// Конвертация символов
        /// </summary>
        /// <param name="FName">Наименование папки</param>
        public static string ConvertFileName(string FName)
        {
            FName = FName.Replace("/", "_");
            FName = FName.Replace(@"\", "_");

            return FName;
        }


        /// <summary>
        /// Возвращает данные пользователя выдавшего задания
        /// </summary>
        /// <param name="IDW">ID сотрудника</param>
        /// <returns>Фамилия_Отдел</returns>
        public static Dictionary<string, string> getInfoAuthorZad(string IDW)
        {
            //string InfoAuthor = "";
            Dictionary<string, string> DictInfo = new Dictionary<string, string>();


            string sql = "SELECT Workers.F_Worker, Otdels.NB_Otdel";
            sql += " FROM Otdels INNER JOIN";
            sql += " Workers ON Otdels.ID_Otdel = dbo.MainOtdel(Workers.ID_Otdel) ";
            sql += " WHERE Workers.ID_Worker = " + Convert.ToInt32(IDW).ToString();

            var rs = SSPD.DB.GetFields(sql);
            if (rs != null && rs.Count > 0)
            {
                DictInfo.Add("NB_Otdel", rs[0]["NB_Otdel"].ToString());
                DictInfo.Add("F_Worker", rs[0]["F_Worker"].ToString());
            }

            return DictInfo;
        }

        /// <summary>
        /// Возварат сокращенного наименования отдела по ID
        /// </summary>
        /// <param name="IDO">ID отдела</param>
        /// <returns> сокращенное наименование отдела</returns>
        public static string getNBOtdelIDO(string IDO)
        {
            string ret = "";
            var drc = SSPD.DB.GetFields("SELECT NB_Otdel FROM Otdels WHERE ID_Otdel = "+ IDO);
            
            if (drc != null)
                if (drc.Count > 0)
                    ret = drc[0][0].ToString();
            drc = null;

            return ret;
        }

        /// <summary>
        /// Формирование структуры папок на диске L в каталоке ТКП
        /// </summary>
        /// <param name="ShPrj">Шифр проекта</param>
        /// <param name="NBOtdel">Сокращенное наименование отдела</param>
        public static void createDirResource(ref bool flCreate, string ShPrj, string NBOtdel = "")
        {
            string Lpath = TKP_Conf.ResourceTKP;

            flCreate = false;

            if (!Directory.Exists(Lpath))
                return;

            try
            {
                if (ShPrj != "")
                    createPath(string.Format("{0}\\{1}", Lpath, ConvertFileName(ShPrj)));

                if (NBOtdel != "")
                    createPath(string.Format("{0}\\{1}\\{2}", Lpath, ConvertFileName(ShPrj), ConvertFileName(NBOtdel)));
            }
            catch
            {
                flCreate = false;
            }
            finally
            {
                flCreate = true;
            }
        }

        /// <summary>
        /// Создание папки
        /// </summary>
        /// <param name="PathOut">Путь до папки</param>
        private static void createPath(string PathOut)
        {
            //PathOut = ConvertFileName(PathOut);
            if (!Directory.Exists(PathOut)) // "!" забыл поставить
            {
                Directory.CreateDirectory(PathOut);
            }
        }


    }
}
