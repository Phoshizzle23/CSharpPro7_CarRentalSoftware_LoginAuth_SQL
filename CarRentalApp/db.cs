using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    internal class db
    {
        protected private static string DBName = "RentalCarDb";

        public static string _Access = @"Data Source=DESKTOP-5KJ157N\SQLEXPRESS;Initial Catalog='" + DBName + "';Integrated Security=True";
        public static SqlConnection cn = new SqlConnection(_Access);
        public static SqlCommand cm = new SqlCommand("", cn);
        public SqlDataAdapter da = new SqlDataAdapter();
        public static SqlDataReader dr = null;
        public static DataTable dt = new DataTable();

        public static int _id = 0;
        public static byte[] _img;

        public static void FormatDataGridRow(DataGridView dgv, string TypeFormat, int NumberOfCell)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[NumberOfCell].Value.ToString() == TypeFormat)
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        public static void ConvertImageToSave(PictureBox PictureBoxName)
        {
            MemoryStream ms = new MemoryStream();
            PictureBoxName.Image.Save(ms, PictureBoxName.Image.RawFormat);
            byte[] img = ms.ToArray();
            _img = img;
            ms.Close();
        }

        public static void ClearImage(PictureBox NamePictureBox)
        {
            NamePictureBox.Image = new PictureBox().Image;
        }


        public static void OpenImage(PictureBox NamePictureBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choose image | *.png;*.bmp;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                NamePictureBox.Image = Image.FromFile(ofd.FileName);
            }
        }

        public static void ShowImageinPictureBox(PictureBox PictureBoxName, DataGridView dgv, int NumberCell)
        {
            byte[] img = (byte[])dgv.CurrentRow.Cells[NumberCell].Value;
            MemoryStream ms = new MemoryStream(img);
            PictureBoxName.Image = Image.FromStream(ms);
        }
    }
    
}


