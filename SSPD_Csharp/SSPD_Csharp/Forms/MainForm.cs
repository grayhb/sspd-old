using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class MainForm : Form
    {
        Declarations Declarations = new Declarations();

        public MainForm()
        {
            InitializeComponent();
            //события:
            this.Shown +=new EventHandler(Main_Shown);

            //надстройки формы:
            GetRightUser();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            this.Text = string.Format("Система Сопровождения Проектной Деятельности ({0})",Params.UserInfo.FIO);
            
            //загружаем форму для вывода отчетов мониторинга
            Declarations.MdiParent = this;
            Declarations.Show();
            
            this.Opacity = 100;
            
        }

        /// <summary>
        /// Настройка отображения пользовательских модулей
        /// </summary>
        private void GetRightUser()
        {
            string RightUser = Params.UserInfo.RightUser;

            //закрываем все модули если входит не администратор
            if (RightUser.ToUpper() != "ADMIN")
            {
                //[список работников]:
                МенюСписокРаботниковАдминистрирование.Visible = false;

                МенюСправочникСИМКарт.Visible = false;
            }


            //Кадры
            if (RightUser.ToUpper() == "ADMINKADR")
            {
                //[список работников]:
                МенюСписокРаботниковАдминистрирование.Visible = true;
            }



        }


        private void списокРаботниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkersSprav WS = new WorkersSprav();
            WS.ShowDialog();
        }

        private void списокРаботниковадминистрированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkersSpravEdit WSE = new WorkersSpravEdit();
            WSE.ShowDialog();
        }

        private void МенюСправочникСИМКарт_Click(object sender, EventArgs e)
        {
            PhoneSIMList PSIML = new PhoneSIMList(false);
            PSIML.ShowDialog();
        }
    }
}
