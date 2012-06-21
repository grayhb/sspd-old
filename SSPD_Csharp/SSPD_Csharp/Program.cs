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
                MessageBox.Show("Приложение уже запущено", "ССПД", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            else
            {
                //не запущено:
                //проверка конфига
                if (System.IO.File.Exists(Params.AppPath) == false)
                {
                    MessageBox.Show("Отсутствует файл конфигурации!", "Остановка запуска", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
                else
                {

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
