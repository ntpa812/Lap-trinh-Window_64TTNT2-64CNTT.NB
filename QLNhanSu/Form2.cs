using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class Form2 : Form
    {
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLNhanSu;Integrated Security=True";
        string query = "";
        public Form2()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            query = "select hoTen,gioiTinh,queQuan,donVi,hocHam from NhanSu";
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cbbDonVi.Text=="" && cbbHocHam.Text=="" && cbbQue.Text=="")
            {
                MessageBox.Show("Nhập nội dung tìm kiếm");
            }
            else
            {
                string dv = cbbDonVi.Text.ToString(), hh = cbbHocHam.Text.ToString(), qq = cbbQue.Text.ToString();
                query = "select hoTen,gioiTinh,queQuan,donVi,hocHam from NhanSu where queQuan=N'" + qq + "' or donVi=N'" + dv + "' or hocHam=N'" + hh + "' ";
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
                
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
