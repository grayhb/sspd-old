using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace SSPD
{
    static class SSPDUI
    {
        /// <summary>
        /// Структура для хранения данных в ComboBox
        /// </summary>
        public struct ComboType
        {

            public int ID_Item;

            public string Name_Item;
            public ComboType(int _ID_Item, string _Name_Item)
            {
                ID_Item = _ID_Item;
                Name_Item = _Name_Item;
            }

            public override string ToString()
            {
                return this.Name_Item;
            }

        }


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

        /// <summary>
        /// Заливаем четные строки в DataGridView
        /// </summary>
        public static void SetBgRowInDGV(DataGridView DGV)
        {
            bool odd = false;
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                foreach (DataGridViewCell DGVC in DGVR.Cells)
                {
                    if (odd) DGVC.Style.BackColor = Color.FromArgb(240, 240, 240);
                    else DGVC.Style.BackColor = Color.White;
                }
                if (DGVR.Visible) odd = odd == true ? false : true;
            }
        }


        public static void SearchInDGV(DataGridView DGV, string StrFind, int IndexFind)
        {
            if (StrFind.Length == 0) return;
            bool FlSearchStop = false;
            if (IndexFind != DGV.CurrentRow.Index) IndexFind = -1;
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                if (FlSearchStop == true) return;
                foreach (DataGridViewCell DGVC in DGVR.Cells)
                {
                    if (FlSearchStop == true) return;
                    if (DGVC.Value != null && DGVC.Value.ToString().ToLower().IndexOf(StrFind.ToLower()) > -1 && DGVR.Index > IndexFind && DGVR.Visible == true)
                    {
                        DGV.ClearSelection();
                        DGVC.Selected = true;
                        DGVR.Selected = true;
                        FlSearchStop = true;
                        IndexFind = DGVR.Index;
                        return;
                    }
                }
            }

            //не найдено, и поиск начат с середины, повторяем поиск с первой позиции
            if (IndexFind > -1) { IndexFind = -1; SearchInDGV(DGV, StrFind, IndexFind); }

        }


    }
}
