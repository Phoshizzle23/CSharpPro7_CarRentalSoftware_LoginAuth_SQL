using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarRentalApp
{
    public partial class FrmAddCar : Form
    {
        FrmCategoryCar f = new FrmCategoryCar();
        public FrmAddCar(FrmCategoryCar f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //db.OpenImage(pic);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("insert into Cars (CarName,CarColor,CarModel,CarImg) values (@CarName,@CarColor,@CarModel,@CarImg)",db.cn);
            db.cm.Parameters.AddWithValue("@CarName", textBox1.Text);
            db.cm.Parameters.AddWithValue("@CarColor", textBox2.Text);
            db.cm.Parameters.AddWithValue("@CarModel", textBox3.Text);
            db.ConvertImageToSave(pic);
            db.cm.Parameters.AddWithValue("@CarImg", db._img);
            db.cm.ExecuteNonQuery();
            MessageBox.Show("Car has been saved!");
            db.cn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Select();
            f.LoadCar();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            db.cn.Open();
            db.cm = new System.Data.SqlClient.SqlCommand("update Cars set CarName=@CarName,CarColor=@CarColor,CarModel=@CarModel,CarImg=@CarImg where", db.cn);
            db.cm.Parameters.AddWithValue("@CarName", textBox1.Text);
            db.cm.Parameters.AddWithValue("@CarColor", textBox2.Text);
            db.cm.Parameters.AddWithValue("@CarModel", textBox3.Text);
            db.ConvertImageToSave(pic);
            db.cm.Parameters.AddWithValue("@CarImg", db._img);
            db.cm.ExecuteNonQuery();
            MessageBox.Show("Car has been saved!");
            db.cn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Select();
            f.LoadCar();
        }
    }
}
