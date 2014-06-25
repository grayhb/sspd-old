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

            //загружаем параметры конфигурации
            Config.ReadCFG();


            string UName = Environment.UserName;

            //UName = "AbrashkinaKP";
            UName = "TafincevNA";

            //загружаем данные пользователя
            Config.LoadDataUser(Application.ProductName, UName);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ListTKP());

        }
    }
}
