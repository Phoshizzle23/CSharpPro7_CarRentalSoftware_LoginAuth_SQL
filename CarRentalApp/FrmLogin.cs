using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if(TextUserName.Text == "")
            {
                MessageBox.Show("User Name is required!");
                TextUserName.Select();
                return;
            } else if (TextPass.Text == "")
            {
                MessageBox.Show("Password is required!");
                TextPass.Select();
                return;
            }

            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("select * from Users where UserName like '" + TextUserName.Text + "' and Password like '" + TextPass.Text + "'", db.cn);
            db.dr = db.cm.ExecuteReader();
            if (db.dr.HasRows)
            {
                FrmMain f = new FrmMain();
                f.Show();
                this.Hide();
            }
            db.cn.Close();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            FrmNewUser f = new FrmNewUser();
            f.ShowDialog();
            this.Hide();
        }
    }
}
