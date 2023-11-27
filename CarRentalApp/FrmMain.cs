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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
            this.Width = width;
            this.Height = height;
            Top = 0;
            Left = 0;
            panel1.Width = width -20;
            panel1.Height = height -20;
        }

        private void BtnCreateCar_Click(object sender, EventArgs e)
        {
            FrmCategoryCar f = new FrmCategoryCar();
            f.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
