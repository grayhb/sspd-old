using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Контроль_запросов_ТКП
{
    public partial class CardWorker : Form
    {

        //ID сотрудника
        public string IDW = "";

        public CardWorker()
        {
            InitializeComponent();
        }

        private void CardWorker_Load(object sender, EventArgs e)
        {
            LoadData();
            ViewFoto();
        }

        /// <summary>
        /// Запись в файла фотографии и показ на форме
        /// </summary>
        private void ViewFoto()
        {
            var rs = SSPD.DB.GetFields("SELECT ID_Worker, Photo_Worker From WorkersPhoto Where ID_Worker = " + IDW);
            if (rs.Count == 0) return;
            DataRow dr = rs[0];
            var arrByte = (byte[])dr["Photo_Worker"];

            using (MemoryStream ms = new MemoryStream(arrByte, 0, arrByte.Length))
            {
                ms.Write(arrByte, 0, arrByte.Length);
                Foto.Image = Image.FromStream(ms, true);
            }
        }

        private void LoadData()
        {
            string sql= "SELECT Workers.F_Worker, Workers.N_Worker, Workers.P_Worker, Posts.N_Post, Otdels.Name_Otdel, PhoneTown.NamberPTown, ";
            sql += " PhoneInner.NamberPInner " ;
            sql += " FROM Workers INNER JOIN";
            sql += " Otdels ON Workers.ID_Otdel = Otdels.ID_Otdel INNER JOIN";
            sql += " Posts ON Workers.ID_Post = Posts.ID_Post LEFT OUTER JOIN";
            sql += " WorkersExt ON Workers.ID_Worker = WorkersExt.ID_Worker LEFT OUTER JOIN";
            sql += " PhoneInner ON WorkersExt.PhoneInner = PhoneInner.ID_PInner LEFT OUTER JOIN";
            sql += " PhoneTown ON PhoneInner.ID_PTown = PhoneTown.ID_PTown";
            sql += " WHERE Workers.ID_Worker = " + IDW ;
            var rs = SSPD.DB.GetFields(sql);
            if (rs.Count == 0) return;
            DataRow dr = rs[0];

            FIO.Text = dr["F_Worker"].ToString() + " " + dr["N_Worker"].ToString() + " " + dr["P_Worker"].ToString();
            Post.Text = dr["N_Post"].ToString();
            OtdelName.Text = dr["Name_Otdel"].ToString();
            TelInner.Text = dr["NamberPInner"].ToString();
            TelTown.Text = dr["NamberPTown"].ToString();

            FIO.Tag = dr["F_Worker"].ToString() + " " + dr["N_Worker"].ToString() + " " + dr["P_Worker"].ToString();
            Post.Tag = dr["N_Post"].ToString();
            OtdelName.Tag = dr["Name_Otdel"].ToString();
            TelInner.Tag = dr["NamberPInner"].ToString();
            TelTown.Tag = dr["NamberPTown"].ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FIO_TextChanged(object sender, EventArgs e)
        {
            if (FIO.Tag != null && FIO.Text != FIO.Tag.ToString()) FIO.Text = FIO.Tag.ToString();
        }

        private void OtdelName_TextChanged(object sender, EventArgs e)
        {
            if (OtdelName.Tag != null && OtdelName.Text != OtdelName.Tag.ToString()) OtdelName.Text = OtdelName.Tag.ToString();
        }

        private void Post_TextChanged(object sender, EventArgs e)
        {
            if (Post.Tag != null && Post.Text != Post.Tag.ToString()) Post.Text = Post.Tag.ToString();
        }

        private void TelInner_TextChanged(object sender, EventArgs e)
        {
            if (TelInner.Tag != null && TelInner.Text != TelInner.Tag.ToString()) TelInner.Text = TelInner.Tag.ToString();
        }

        private void TelTown_TextChanged(object sender, EventArgs e)
        {
            if (TelTown.Tag != null && TelTown.Text != TelTown.Tag.ToString()) TelTown.Text = TelTown.Tag.ToString();
        }

        private void CardWorker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) this.Close();
        }

    }
}
