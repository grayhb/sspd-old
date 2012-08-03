using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class MainForm  : Form
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
            
            foreach(Control ctl in this.Controls) 
            {
                if (ctl is MdiClient == true )  {
                    ctl.BackColor = this.BackColor;
                    break;
                }
            }

            this.Opacity = 1;
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

        private bool CheckOpenForm(string FName)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == FName)
                {
                    f.WindowState = FormWindowState.Normal;
                    f.Activate();
                    return false;
                }
            }
            return true;
        }


        private void списокРаботниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkersSprav WS = new WorkersSprav();
            if (CheckOpenForm(WS.Name))
            {
                WS.ShowInTaskbar = true;
                WS.MdiParent = this;
                WS.Show();
            }
        }

        private void списокРаботниковадминистрированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkersSpravEdit WSE = new WorkersSpravEdit();
            if (CheckOpenForm(WSE.Name))
            {
                WSE.ShowInTaskbar = true;
                WSE.MdiParent = this;
                WSE.Show();
            }
        }

        private void МенюСправочникСИМКарт_Click(object sender, EventArgs e)
        {
            PhoneSIMList PSIML = new PhoneSIMList(false);
            if (CheckOpenForm(PSIML.Name))
            {
                PSIML.MdiParent = this;
                PSIML.Show();
            }
        }

        private void справочникМобильныхТелефоновToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhoneApList PAL = new PhoneApList(false);
            if (CheckOpenForm(PAL.Name))
            {
                PAL.MdiParent = this;
                PAL.Show();
            }
        }

        private void справочникТелефонныхТочекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhoneInnerList PIL = new PhoneInnerList(false);
            if (CheckOpenForm(PIL.Name))
            {
                PIL.MdiParent = this;
                PIL.Show();
            }
        }

        private void справочникIPНомеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhoneIPList PIPL = new PhoneIPList();
            if (CheckOpenForm(PIPL.Name))
            {
                PIPL.MdiParent = this;
                PIPL.Show();
            }
        }

        private void MenuListObjKTN_Click(object sender, EventArgs e)
        {
            SSPD.ObjectsTN.List ListKTN = new SSPD.ObjectsTN.List();
            if (CheckOpenForm(ListKTN.Name))
            {
                ListKTN.MdiParent = this;
                ListKTN.Show();
            }
        }

        private void каскадомToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void вертикальноToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void горизонтальноToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void свернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form tmpFrm in this.MdiChildren)
                tmpFrm.WindowState = FormWindowState.Minimized;
        }

        private void развернутьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form tmpFrm in this.MdiChildren)
                tmpFrm.WindowState = FormWindowState.Normal ;
        }

        private void закрытьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form tmpFrm in this.MdiChildren)
            {
                tmpFrm.Close();
                tmpFrm.Dispose();
            }
        }

    }
}
