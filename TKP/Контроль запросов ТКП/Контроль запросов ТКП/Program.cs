using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SSPD;

namespace Контроль_запросов_ТКП
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Config.Mask = Params.Mask;
            Config.CfgPath = Params.CfgPath;

            //загрузка параметров конфигурации
            Config.ReadCFG();

            //определение параметров подключения к БД
            DB.InitDB();
            
            string UName = Environment.UserName;

            //UName = "AbrashkinaKP";
            //UName = "TafincevDA";

            //загружаем данные пользователя
            //Config.LoadDataUser(Application.ProductName, UName);
            User.LoadUserInfo(UName);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ListTKP());

        }
    }
}
