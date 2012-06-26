using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace SSPD
{
    static class SSPDUI
    {
        /// <summary>
        /// Вывод предупреждающего сообщения
        /// </summary>
        /// <param name="text">текст сообщения или ошибки</param>
        /// <param name="caption">заголовок окна</param>
        public static void MsgEx(string text, string caption)
        {
            if (caption == "" || caption == null) caption = "Остановка операции";
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


    }
}
