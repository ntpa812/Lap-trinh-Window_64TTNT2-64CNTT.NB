using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLCafe
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLCafe;Integrated Security=True";
        string query = "";
        public Form1()
        {
            InitializeComponent();
        }
        public void LoadData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Open();
                apt.Fill(dt);
                conn.Close();
            }
            dataGridView1.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            query = "select SOBAN,DOUONG,SOLUONG,GIA,NGAY from DATHANG";
            LoadData(query);
            
            textBox1.Text = tinhDoanhThu().ToString();
        }

        public double tinhDoanhThu()
        {
            double doanhThu = 0;
            //double tong = 0;
            //int soLg = 0, gia = 0;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    soLg = int.Parse(dataGridView1.Rows[i].Cells["soLuong"].Value.ToString());
            //    gia = int.Parse(dataGridView1.Rows[i].Cells["gia"].Value.ToString());
            //    tong = soLg * gia;
            //    doanhThu += tong;
            //}
            return doanhThu;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
               
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Parse(dateTimePicker1.Value.ToString());
            DateTime date2 = DateTime.Parse(dateTimePicker2.Value.ToString());

            //MessageBox.Show(date1);
            if (checkBox1.Checked == true && checkBox2.Checked==false)
            {
                query = "select SOBAN,DOUONG,SOLUONG,GIA,NGAY from DATHANG where DOUONG='" + comboBox1.Text + "'";
      
            }
            else if (checkBox1.Checked==false && checkBox2.Checked==true)
            {
                
                query = "select SOBAN,DOUONG,SOLUONG,GIA,NGAY from DATHANG where NGAY between " + date1 + " and " + date2 + "";
            }

            LoadData(query);
        }
    }
}
