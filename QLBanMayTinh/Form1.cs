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
using System.Security.Cryptography;

namespace QLBanMayTinh
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLBanMT;Integrated Security=True";
        string query = "";
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        public void LoadData()
        {
            DataTable dt = new DataTable();
            query = "select * from hoaDon";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Close();

                apt.Fill(dt);
            }
            dataGridView1.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string loai = "";
            if (radioButton1.Checked == true)
            {
                loai = "Để bàn";
            }
            else if (radioButton2.Checked == true)
            {
                loai = "Xách tay";
            }

            int donGia = int.Parse(txtGia.Text.ToString());
            int soLuong = int.Parse(numericUpDown1.Value.ToString());

            if (donGia < 0 || donGia > 100000000||soLuong < 0)
            {
                
                MessageBox.Show("Thông tin không hợp lệ.");
            }
            else
            {
                float tong = donGia * soLuong;

                query = "insert into hoaDon(maHD,tenKH,ngayBan,loaiMay,tenMay,donGia,soLuong,thanhTien) values(@maHD,@tenKH,@ngayBan,@loaiMay,@tenMay,@donGia,@soLuong,@thanhTien)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maHD",txtMaHD.Text);
                    cmd.Parameters.AddWithValue("@tenKH",txtTenKH.Text);
                    cmd.Parameters.AddWithValue("@ngayBan", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@loaiMay", loai);
                    cmd.Parameters.AddWithValue("@tenMay",txtTenMay.Text);
                    cmd.Parameters.AddWithValue("@donGia",donGia);
                    cmd.Parameters.AddWithValue("@soLuong",soLuong);
                    cmd.Parameters.AddWithValue("@thanhTien", tong);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                LoadData();                
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string loai = "";
            if (radioButton1.Checked == true)
            {
                loai = "Để bàn";
            }
            else if (radioButton2.Checked == true)
            {
                loai = "Xách tay";
            }

            int donGia = int.Parse(txtGia.Text.ToString());
            int soLuong = int.Parse(numericUpDown1.Value.ToString());

            if (donGia < 0 || donGia > 100000000 || soLuong < 0)
            {

                MessageBox.Show("Thông tin không hợp lệ.");
            }
            else
            {
                float tong = donGia * soLuong;

                query = "update hoaDon set maHD=@maHD,tenKH=@tenKH,ngayBan=@ngayBan,loaiMay=@loaiMay,tenMay=@tenMay,donGia=@donGia,soLuong=@soLuong,thanhTien=@thanhTien where maHD='" + txtMaHD.Text + "'";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maHD", txtMaHD.Text);
                    cmd.Parameters.AddWithValue("@tenKH", txtTenKH.Text);
                    cmd.Parameters.AddWithValue("@ngayBan", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@loaiMay", loai);
                    cmd.Parameters.AddWithValue("@tenMay", txtTenMay.Text);
                    cmd.Parameters.AddWithValue("@donGia", donGia);
                    cmd.Parameters.AddWithValue("@soLuong", soLuong);
                    cmd.Parameters.AddWithValue("@thanhTien", tong);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                LoadData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string checkLoai = dataGridView1.SelectedRows[0].Cells["loaiMay"].Value.ToString();
                if (checkLoai=="Để bàn")
                {
                    radioButton1.Checked = true;
                }    
                else radioButton2.Checked = true;
                txtGia.Text = dataGridView1.SelectedRows[0].Cells["donGia"].Value.ToString();
                txtMaHD.Text = dataGridView1.SelectedRows[0].Cells["maHD"].Value.ToString();
                txtTenKH.Text = dataGridView1.SelectedRows[0].Cells["tenKH"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells["ngayBan"].Value.ToString();
                txtTenMay.Text = dataGridView1.SelectedRows[0].Cells["tenMay"].Value.ToString();
                numericUpDown1.Value = int.Parse(dataGridView1.SelectedRows[0].Cells["soLuong"].Value.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                query = "delete from hoaDon";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            LoadData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            //this.Close();

            //Nếu muốn thoát toàn bộ ứng dụng: dùng
            Application.Exit();
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
