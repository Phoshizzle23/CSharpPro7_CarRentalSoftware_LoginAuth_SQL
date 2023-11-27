using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CarRentalApp
{
    public partial class FrmNewUser : Form
    {
        public FrmNewUser()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("insert into Users(UserName, Password)values(@UserName, @Password)",db.cn);
            db.cm.Parameters.AddWithValue("@UserName", TextUserName.Text);
            db.cm.Parameters.AddWithValue("@Password", TextPass.Text);
            db.cm.ExecuteNonQuery();
            TextUserName.Clear();
            TextPass.Clear();
            MessageBox.Show("User has been saved!");
            db.cn.Close();

            FrmLogin f = new FrmLogin();
            f.Show();
            this.Dispose();
        }
    }
}
