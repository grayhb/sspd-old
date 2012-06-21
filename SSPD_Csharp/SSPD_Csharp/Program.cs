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
        static void Main()
        {

            //проверяем запущено ли приложение:
            if (System.Diagnostics.Process.GetProcessesByName(Application.ProductName).Length > 1)
            {
                MessageBox.Show("Приложение уже запущено","ССПД",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    Application.Run(new MainForm());
                }
            }

        }
    }
}
