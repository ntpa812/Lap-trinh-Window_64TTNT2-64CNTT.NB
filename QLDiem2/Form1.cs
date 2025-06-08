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

namespace QLDiem2
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLDiem2;Integrated Security=True";
        string query = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            query = "select * from Diem";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Open();
                apt.Fill(dt);
                conn.Close();
            }
            dataGridView2.DataSource = dt;
        }

        public void LoadData()
        {
            query = "select * from Diem";
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
        public void EditData(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "SV001") txtTen.Text = "Nguyễn Văn A";
            else if (comboBox1.Text == "SV002") txtTen.Text = "Nguyễn Văn B";
            else if (comboBox1.Text == "SV003") txtTen.Text = "Trần Thị C";
        }

        private void txtToan_Leave(object sender, EventArgs e)
        {
            float d = float.Parse(txtToan.Text.ToString());
            if (d > 10 || d < 0)
            {
                MessageBox.Show("Nhập lại điểm");
                txtToan.Focus();
            }        
        }

        private void txtVan_Leave(object sender, EventArgs e)
        {
            float d = float.Parse(txtVan.Text.ToString());
            if (d > 10 || d < 0)
            {
                MessageBox.Show("Nhập lại điểm");
                txtVan.Focus();
            }
        }

        private void txtNN_Leave(object sender, EventArgs e)
        {
            float d = float.Parse(txtNN.Text.ToString());
            if (d > 10 || d < 0)
            {
                MessageBox.Show("Nhập lại điểm");
                txtNN.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            float toan = float.Parse(txtToan.Text.ToString());
            float van = float.Parse(txtVan.Text.ToString());
            float nn = float.Parse(txtNN.Text.ToString());
            float tb = (float)((toan + van + nn) / 3);
            query = "insert into Diem values(@maSV,@tenSV,@toan,@van,@nn,@tb)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maSV", comboBox1.Text);
                cmd.Parameters.AddWithValue("@tenSV", txtTen.Text);
                cmd.Parameters.AddWithValue("@toan", toan);
                cmd.Parameters.AddWithValue("@van", van);
                cmd.Parameters.AddWithValue("@nn", nn);
                cmd.Parameters.AddWithValue("@tb", tb);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["maSV"].Value.ToString();
            txtTen.Text = dataGridView1.SelectedRows[0].Cells["tenSV"].Value.ToString();
            txtToan.Text= dataGridView1.SelectedRows[0].Cells["diemToan"].Value.ToString();
            txtVan.Text = dataGridView1.SelectedRows[0].Cells["diemVan"].Value.ToString();
            txtNN.Text= dataGridView1.SelectedRows[0].Cells["diemNN"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            float toan = float.Parse(txtToan.Text.ToString());
            float van = float.Parse(txtVan.Text.ToString());
            float nn = float.Parse(txtNN.Text.ToString());
            float tb = ((toan + van + nn) / 3);
            query = "update Diem set maSV=N'" + comboBox1.Text + "',tenSV=N'" + txtTen.Text + "',diemToan='" + toan.ToString() + "',diemVan='" + van.ToString() + "',diemNN='" + nn.ToString() + "',diemTB='" + tb.ToString() + "' where maSV=N'" + comboBox1.Text + "'";
            EditData(query);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            query = "delete from Diem where maSV=N'" + comboBox1.Text + "'";
            EditData(query);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Giỏi")
            {
                query = "select * from Diem where diemTB>8";
            }
            else if (comboBox2.Text == "Khá")
            {
                query = "select * from Diem where diemTB>6.5 and diemTB<8";
            }
            else query = "select * from Diem where diemTB<6.5";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Open();
                apt.Fill(dt);
                conn.Close();
            }
            dataGridView2.DataSource = dt;
        }
    }
}
