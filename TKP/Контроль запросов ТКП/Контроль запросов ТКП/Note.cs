using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSPD;

namespace Контроль_запросов_ТКП
{
    public partial class Note : Form
    {
        public string ID_Doc;
        public bool flSave = false;

        public Note()
        {
            InitializeComponent();
        }

        private void Note_Load(object sender, EventArgs e)
        {
            LoadData();
            NoteTxt.SelectionStart = 0;
            NoteTxt.SelectionLength = 0;

            //проверка привелегий
            if (Params.UserInfo.ID_Otdel != TKP_Conf.AdminIDOtdel)
            {
                btnSave.Enabled = false;
                NoteTxt.ReadOnly = true;    
            }
        }

        private void LoadData()
        {
            var rs = LocalDB.LoadData("SELECT Mail_Note FROM КонтрольТКП_Письма WHERE ID = " + ID_Doc);
            if (rs != null)
                if (rs.Count > 0)
                    NoteTxt.Text = rs[0]["Mail_Note"].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> DS = new Dictionary<string, string>();
            DS.Add("Mail_Note", NoteTxt.Text);
            LocalDB.UpdateData(DS, "КонтрольТКП_Письма", "ID = " + ID_Doc);
            flSave = true;
            this.Close();
        }

        private void Note_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

    }
}
