using System;
using System.Collections.Generic;
using System.Text;

namespace SSPD
{
    static class Security
    {

        /// <summary>
        /// проверка каталога откуда запущено приложение
        /// возвращает true если каталог соответсвтует или имя машины совпадает с исключением
        /// </summary>
        public static bool CheckStartPath()
        {
            //имена машин Администраторов/Разработчиков
            string[] AdminMachineName = {   "OVIAP00-GTPSAM",
                                            "DGK-PC",
                                            "NOTEBOOK-51",
                                            "TO04-GTPSAM" };

            //проверка имени компьютера
            foreach (var MachineName in AdminMachineName)
            {
                if (MachineName == Environment.MachineName) return true;
            }

            //проверка папки - в таблице Params строка с ID_Par = 101 соответствует приложению SSPD
            var rs = DB.GetFields("SELECT Val_Par FROM Params WHERE Params.ID_Par=101");
            if (rs.Count > 0)
            {
                if (rs[0]["Val_Par"].ToString() == Environment.CurrentDirectory.ToString()) return true; else return false;
            }
            else return false; 
        }


        


    }
}
