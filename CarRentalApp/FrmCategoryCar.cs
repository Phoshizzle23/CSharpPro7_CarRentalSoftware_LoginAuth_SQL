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
    public partial class FrmCategoryCar : Form
    {
        
        public FrmCategoryCar()
        {
            InitializeComponent();
        }
        public void LoadCar()
        {
            int i = 0;
            Dgv.Rows.Clear();
            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("select * from Cars", db.cn);
            db.dr = db.cm.ExecuteReader();
            while (db.dr.Read())
            {
                i++;
                Dgv.Rows.Add(db.dr[0],i, db.dr[1], db.dr[2], db.dr[3], db.dr[4]);
            }
            db.cn.Close();

        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmCategoryCar_Load(object sender, EventArgs e)
        {
            LoadCar();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            FrmAddCar f = new FrmAddCar(this);
            f.ShowDialog();
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = Dgv.Columns[e.ColumnIndex].Name;
            if(ColName == "ColEdit")
            {
                FrmAddCar f = new FrmAddCar(this);
                db._id = (int)Dgv.CurrentRow.Cells[0].Value;
                f.textBox1.Text = Dgv.CurrentRow.Cells[2].Value.ToString();
                f.textBox2.Text = Dgv.CurrentRow.Cells[3].Value.ToString();
                f.textBox3.Text = Dgv.CurrentRow.Cells[4].Value.ToString();
                db.ShowImageinPictureBox(f.pic, Dgv, 5);
                f.ShowDialog();

            }
            else if (ColName == "ColDelete")
            {
                db.cn.Open();
                db.cm = new System.Data.SqlClient.SqlCommand("delete from Cars where id like '" + Dgv.CurrentRow.Cells[0].Value + "'", db.cn);
                db.cm.ExecuteNonQuery();
                MessageBox.Show("car has been deleted!");
                db.cn.Close();
                LoadCar();
            }
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
