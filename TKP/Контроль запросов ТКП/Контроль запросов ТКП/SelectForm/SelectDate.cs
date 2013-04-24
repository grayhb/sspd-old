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
    public partial class SelectDate : Form
    {

        public bool flSel = false;
        public DateTime SelDate;

        private short numClick = 0;
        private long firstClick;

        public SelectDate()
        {
            InitializeComponent();
            
        }

        private void SelectDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Return)
            {
                doSelectDate();
            }
        }

        private void doSelectDate()
        {
            SelDate = mCalendar.SelectionRange.Start;
            flSel = true;
            this.Close();
        }

        private void mCalendar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Return)
                doSelectDate();
        }

        private void mCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (numClick == 2)
            {
                numClick = 0;
                doSelectDate();
            }
        }

        private void mCalendar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (numClick == 0)
                {
                    firstClick = DateTime.Now.Ticks;
                    numClick++;
                }
                else if ((DateTime.Now.Ticks - firstClick) > 3000000)
                    numClick = 0;
                else
                    numClick++;
            }
        }
    }
}
