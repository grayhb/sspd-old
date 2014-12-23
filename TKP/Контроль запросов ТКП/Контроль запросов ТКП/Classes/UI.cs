using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Контроль_запросов_ТКП
{
    class UI
    {
        //цвет для заданий добавленных в работу
        public static Color bgHaveTKP = Color.FromArgb(198, 255, 199);
        public static Color bgStatusDocInp0 = Color.FromArgb(255, 180, 180);  //светло красный
        public static Color bgStatusDocInp1 = Color.FromArgb(198, 255, 199);  //светло зеленый  
        public static Color bgStatusDocInp2 = Color.FromArgb(240, 240, 240);  //светло серый  

        public static Color bgUseTKP = Color.SkyBlue;
        public static Color bgFailPir = Color.DimGray;
        

        /// <summary>
        /// Управление прогрессбаром
        /// </summary>
        /// <param name="Param">
        /// 0 - скрыть;
        /// 1 - показать и выставить Максимум;
        /// 2 - увелчить значение на 1
        /// </param>
        /// <param name="Val">Значние</param>
        public static void ProcessPB(ToolStripProgressBar PB, byte Param, int Val = 0)
        {
            switch (Param)
            {
                case 0:
                    PB.Visible = false;
                    break;
                case 1:
                    PB.Visible = true;
                    PB.Maximum = Val;
                    PB.Value = 0;
                    break;
                case 2:
                    PB.Value++;
                    break;
            }
        }

        public static void SetBG_DGV(DataGridViewRow DGVR)
        {
            foreach (DataGridViewCell DGVC in DGVR.Cells)
            {
                if (DGVR.Index%2 == 0) DGVC.Style.BackColor = Color.FromArgb(240, 240, 240);
                else DGVC.Style.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Заливаем четные строки в DataGridView
        /// </summary>
        public static void SetBgRowInDGV(DataGridView DGV)
        {
            bool odd = false;
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                if (DGVR.Visible)
                {
                    foreach (DataGridViewCell DGVC in DGVR.Cells)
                    {
                        if (DGVC.ColumnIndex == 0 || DGVC.OwningColumn.Name == "Status")
                        {
                            if (DGVC.Style.BackColor.Name == "0" || DGVC.Style.BackColor == Color.White || DGVC.Style.BackColor == Color.FromArgb(240, 240, 240))
                            {
                                if (odd) DGVC.Style.BackColor = Color.FromArgb(240, 240, 240);
                                else DGVC.Style.BackColor = Color.White;
                            }
                        }
                        else
                            if (odd) DGVC.Style.BackColor = Color.FromArgb(240, 240, 240);
                            else DGVC.Style.BackColor = Color.White;
                    }
                    odd = odd == true ? false : true;
                }
            }
        }

        /// <summary>
        /// Фильтр в таблице данных
        /// </summary>
        /// <param name="DGV">Таблица</param>
        /// <param name="strFind">Строка для фильтра</param>
        public static void FilterInDGV(DataGridView DGV, string strFind, bool SetBG = true)
        {
            if (strFind.Length < 2 && strFind.Length > 0) return;
            foreach (DataGridViewRow dgvr in DGV.Rows)
            {
                if (strFind == "")
                {
                    dgvr.Visible = true;
                }
                else
                {
                    bool flVis = false;

                    foreach (DataGridViewCell dvc in dgvr.Cells)
                    {
                        if (dvc.Value.ToString().ToLower().IndexOf(strFind.ToLower()) > -1)
                        {
                            flVis = true;
                            break;
                        }
                    }

                    dgvr.Visible = flVis;
                }
            }
            if (SetBG) UI.SetBgRowInDGV(DGV);

            if (DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible) > -1)
            {
                DGV.ClearSelection();
                DGV.Rows[DGV.Rows.GetFirstRow(DataGridViewElementStates.Visible)].Selected = true;
            }
        }

        /// <summary>
        /// Возврат даты в строке
        /// </summary>
        public static string GetDate(string DT, byte TypeDate = 0 )
        {
            if (TypeDate == 1)
                return string.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(DT));
            else 
                return string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DT));
        }

        /// <summary>
        /// Возвращает строку с кол-вом видимых строк
        /// </summary>
        public static string GetCountRow(DataGridView DGV)
        {
            return "Найдено записей: " + DGV.Rows.GetRowCount(DataGridViewElementStates.Visible);
        }


        public class CBItem
        {
            public string Name;
            public string Value;
            public CBItem(string Name, string Value)
            {
                this.Name = Name;
                this.Value = Value;
            }
            public override string ToString()
            {
                return this.Name;
            }
        }


    }
}
