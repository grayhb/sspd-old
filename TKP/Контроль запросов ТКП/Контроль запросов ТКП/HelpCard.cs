using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Контроль_запросов_ТКП
{
    public partial class HelpCard : Form
    {
        public HelpCard()
        {
            InitializeComponent();
        }

        private void HelpCard_Load(object sender, EventArgs e)
        {
            InitDGV();
        }


        private void InitDGV()
        {
            DGV.Rows.Add();
            DataGridViewRow dgvr = DGV.Rows[DGV.Rows.Count - 1];
            dgvr.Cells["Par"].Style.BackColor = UI.bgStatusDocInp1;
            dgvr.Cells["Par"].Value =  Properties.Resources.empty;
            setSelectionCellBg(ref dgvr);
            dgvr.Cells["Note"].Value = "Положительный ответ / ТКП";

            DGV.Rows.Add();
            dgvr = DGV.Rows[DGV.Rows.Count - 1];
            dgvr.Cells["Par"].Style.BackColor = UI.bgStatusDocInp2;
            dgvr.Cells["Par"].Value = Properties.Resources.empty;
            setSelectionCellBg(ref dgvr);
            dgvr.Cells["Note"].Value = "Уточнение данных";

            DGV.Rows.Add();
            dgvr = DGV.Rows[DGV.Rows.Count - 1];
            dgvr.Cells["Par"].Style.BackColor = UI.bgStatusDocInp0;
            dgvr.Cells["Par"].Value = Properties.Resources.empty;
            setSelectionCellBg(ref dgvr);
            dgvr.Cells["Note"].Value = "Отрицательный ответ / Отказ";

            DGV.Rows.Add();
            dgvr = DGV.Rows[DGV.Rows.Count - 1];
            dgvr.Cells["Par"].Style.BackColor = UI.bgUseTKP;
            dgvr.Cells["Par"].Value = Properties.Resources.empty;
            setSelectionCellBg(ref dgvr);
            dgvr.Cells["Note"].Value = "ТКП использовано в сметах";

            DGV.Rows.Add();
            dgvr = DGV.Rows[DGV.Rows.Count - 1];
            dgvr.Cells["Par"].Value = Properties.Resources.tag_green;
            setSelectionCellBg(ref dgvr);
            dgvr.Cells["Note"].Value = "Проверено автором задания - ТКП соответствует заданию";

            DGV.Rows.Add();
            dgvr = DGV.Rows[DGV.Rows.Count - 1];
            dgvr.Cells["Par"].Value = Properties.Resources.tag_yellow;
            setSelectionCellBg(ref dgvr);
            dgvr.Cells["Note"].Value = "Проверено автором задания - ТКП соответствует частично заданию";

            DGV.Rows.Add();
            dgvr = DGV.Rows[DGV.Rows.Count - 1];
            dgvr.Cells["Par"].Value = Properties.Resources.tag_red;
            setSelectionCellBg(ref dgvr);
            dgvr.Cells["Note"].Value = "Проверено автором задания - ТКП не соответствует заданию";

            DGV.Rows.Add();
            dgvr = DGV.Rows[DGV.Rows.Count - 1];
            dgvr.Cells["Par"].Value = Properties.Resources.tag_gray;
            setSelectionCellBg(ref dgvr);
            dgvr.Cells["Note"].Value = "ТКП не проверено автором задания";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void HelpCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void setSelectionCellBg(ref DataGridViewRow dgvr)
        {
            dgvr.Cells["Par"].Style.SelectionBackColor = dgvr.Cells["Par"].Style.BackColor;
            dgvr.Cells["Par"].Style.SelectionForeColor = dgvr.Cells["Par"].Style.ForeColor;
        }




    }
}
