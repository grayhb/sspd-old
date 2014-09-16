using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Контроль_запросов_ТКП.SelectForm
{
    public partial class SelectPeriod : Form
    {

        public bool flSel = false;
        public DateTime D1;
        public DateTime D2;


        public SelectPeriod()
        {
            InitializeComponent();
        }

        private void SelectPeriod_Load(object sender, EventArgs e)
        {
            if (D1.ToString() != "01.01.0001 0:00:00")
                DFrom.Text = UI.GetDate(D1.ToString()); 
            else
                DFrom.Text = UI.GetDate(DateTime.Now.ToString());

            if (D2.ToString() != "01.01.0001 0:00:00")
                DTo.Text = UI.GetDate(D2.ToString());
            else
                DTo.Text = UI.GetDate(DateTime.Now.ToString());  
            
        }



        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelDate1_Click(object sender, EventArgs e)
        {
            SelectDate SD = new SelectDate();
            SD.Top = MousePosition.Y - SD.Height / 2;
            SD.Left = MousePosition.X - SD.Width / 2;
            SD.mCalendar.MaxSelectionCount = 1;
            SD.mCalendar.SetDate(Convert.ToDateTime(DFrom.Text));
            SD.ShowDialog();

            if (SD.flSel)
                DFrom.Text = UI.GetDate(SD.SelDate.ToString());

            SD.Dispose();
        }

        private void btnSelDate2_Click(object sender, EventArgs e)
        {
            SelectDate SD = new SelectDate();
            SD.Top = MousePosition.Y - SD.Height / 2;
            SD.Left = MousePosition.X - SD.Width / 2;
            SD.mCalendar.MaxSelectionCount = 1;
            SD.mCalendar.SetDate(Convert.ToDateTime(DTo.Text));
            SD.ShowDialog();

            if (SD.flSel)
                DTo.Text = UI.GetDate(SD.SelDate.ToString());

            SD.Dispose();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            D1 = Convert.ToDateTime(DFrom.Text);
            D2 = Convert.ToDateTime(DTo.Text);
            flSel = true;
            this.Close();
        }
    }
}
