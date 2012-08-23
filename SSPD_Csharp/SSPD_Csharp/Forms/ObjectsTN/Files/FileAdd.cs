using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SSPD.ObjectsTN
{
    public partial class FileAdd : Form
    {
        #region [Объявление переменных]

        //текущий этап
        private int NowStep = 0;

        private Panel[] ArrPanel;

        #endregion

        #region [Инициализация и загрузка формы]

        public FileAdd()
        {
            InitializeComponent();
        }

        #endregion

        private void FileAdd_Load(object sender, EventArgs e)
        {
            ArrPanel = new Panel[listSteps.Items.Count];

            int i = 0;
            foreach (Control frmC in this.Controls)
            {
                if (frmC.GetType() == panelSelectObject.GetType())
                {
                    ArrPanel[Convert.ToInt32(frmC.Tag)] = (Panel)frmC;
                    i++;
                }
            }

            foreach (Panel panel in ArrPanel)
            {
                panel.Visible = false;
                panel.Location = new Point(205, 12);
                panel.Size = new Size(376, 262);
                panel.BackColor = SystemColors.Control;
            }

            ShowStep();
        }

        #region [Загрузка и управление данными]




        #endregion

        #region [События элементов формы]
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Отмена")
                CloseForm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CheckStep(1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            CheckStep(-1);
        }

        private void CheckStep(int k)
        {
            if (CheckInputData() == true)
            {
                NowStep += k;

                if (NowStep == 0)
                    btnPrev.Enabled = false;
                else btnPrev.Enabled = true;

                if (NowStep == ArrPanel.Length - 1)
                {
                    btnNext.Enabled = false;
                    btnCancel.Text = "Готово";
                }
                else
                {
                    btnNext.Enabled = true;
                    btnCancel.Text = "Отмена";
                }

                ShowStep();
            }
        }

        private void ShowStep()
        {
            //панели
            foreach (Panel panel in ArrPanel)
                panel.Visible = false;
            ArrPanel[NowStep].Visible = true;

            //шаги
            foreach (ListViewItem LVI in listSteps.Items)
            {
                LVI.BackColor = Color.White;
                LVI.ForeColor = Color.Black;
                if (LVI.Index <= NowStep)
                    LVI.ForeColor = Color.Gray;
            }
            listSteps.Items[NowStep].BackColor = Color.Navy;
            listSteps.Items[NowStep].ForeColor = Color.White;
        }

        /// <summary>
        /// Проверка вводимых данных
        /// </summary>
        private bool CheckInputData()
        {
            if(NowStep == 0)
            {
                if (Object.Text.Length == 0)
                {
                    SSPDUI.MsgEx("Не выбран объект!", this.Text);
                    btnSelObj.Focus();
                    return false;
                }
            }
            else if(NowStep == 1)
            {

                return true;
            }
            else if (NowStep == 2)
            {

                return true;
            }
            return true;
        }

        /// <summary>
        /// Запрос на закрытие формы
        /// </summary>
        private void CloseForm()
        {
            if (MessageBox.Show("Отменить добавление вспомогательного материала?", "Запрос на отмену", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listSteps.SelectedItems.Count > 0)
                listSteps.SelectedItems.Clear();
        }

        private void btnSelObj_Click(object sender, EventArgs e)
        {
            ObjectsTN.List ObjList = new ObjectsTN.List();
            ObjList.SelectMode = true;
            ObjList.ShowDialog();
            if (ObjList.FlSel == true)
            {
                Object.Tag = (Hashtable)ObjList.SelectData;
                Object.Text = ((Hashtable)ObjList.SelectData)["Name"].ToString();
            }
            ObjList.Dispose();
          }

        #endregion




    }
}
