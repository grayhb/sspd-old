using System;
using System.Windows.Forms;

namespace SSPD
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //параметры:
            string commandline = "";
            if (args.Length > 0) commandline = args[0].ToString();

            //проверяем запущено ли приложение:
            if (System.Diagnostics.Process.GetProcessesByName(Application.ProductName).Length > 1 && commandline == "")
            {
                SSPDUI.MsgEx("Приложение уже запущено", "Остановка запуска");
                System.Environment.Exit(0);
            }
            else
            {
                //не запущено:
                //проверка конфига
                if (System.IO.File.Exists(Params.CfgPath) == false)
                {
                    SSPDUI.MsgEx("Отсутствует файл конфигурации!", "Остановка запуска");
                    System.Environment.Exit(0);
                }
                else
                {
                    //загружаем параметры конфигурации
                    Config.ReadCFG();

                    //проверяем каталог запуска
                    if (Security.CheckStartPath() == false)
                    {
                        SSPDUI.MsgEx("Несанкционированный запуск!", "Остановка запуска");
                        System.Environment.Exit(0);
                    }

                    //загружаем данные пользователя
                    Config.LoadDataUser();

                    //продолжаем загрузку
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    if (commandline == "")
                    {
                        Application.Run(new MainForm());
                    }
                    else if (commandline == "CFG")
                    {
                        Application.Run(new Cfg());
                    }
                }
            }

        }
    }
}
