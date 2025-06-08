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

namespace QLTruyenTranh
{
    public partial class Form1 : Form
    {
        List<string> truyen = new List<string>()
        {
            "Doraemon", "Shin", "Conan"
        };
        List<string> gia = new List<string>()
        {
            "3000", "4000", "5000"
        };

        int ehe = 0;

        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLTruyen;Integrated Security=True";
        string query = "";

        public Form1()
        {
            ClearData();

            InitializeComponent();
            LoadData();

            comboBox1.DataSource = truyen;

        }

        public void ClearData()
        {
            query = "delete truyenTranh";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void LoadData()
        {
            query = "select * from truyenTranh";
            DataSet dt = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adt = new SqlDataAdapter(query,conn);
                conn.Close();

                adt.Fill(dt);
            }

            dataGridView1.DataSource = dt.Tables[0];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtSDT.Text, out Int32 a))
            {
                if (a < 0)
                {
                    MessageBox.Show("Lỗi sđt");
                    txtSDT.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lỗi sđt");
                txtSDT.Focus();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i=0; i<truyen.Count(); i++)
            {
                if (truyen[i] == comboBox1.Text.ToString())
                {
                    txtGia.Text = gia[i];
                }
            }
        }
        private void btnMuon_Click(object sender, EventArgs e)
        {
            ehe++;
            string tenKhach = txtTenKhach.Text.ToString(), sdt = txtSDT.Text.ToString(), tenTruyen = comboBox1.Text.ToString(), ngayMuon = dateTimePicker1.Text.ToString();
            query = "insert into truyenTranh(stt,tenKhach,sdt,tenTruyen,ngayMuon,ghiChu) values(" + ehe.ToString() + ",'" + tenKhach + "','" + sdt + "','" + tenTruyen + "','" + ngayMuon + "','Chưa trả')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                txtTenKhach.Text = dataGridView1.SelectedRows[0].Cells["tenKhach"].Value.ToString();
                txtSDT.Text= dataGridView1.SelectedRows[0].Cells["sdt"].Value.ToString();
                comboBox1.Text= dataGridView1.SelectedRows[0].Cells["tenTruyen"].Value.ToString();
                dateTimePicker1.Text= dataGridView1.SelectedRows[0].Cells["ngayMuon"].Value.ToString();
            }
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            int tinhTien = 0;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                ehe = int.Parse(dataGridView1.SelectedRows[0].Cells["stt"].Value.ToString());
            }

            TimeSpan soNgay = (dateTimePicker2.Value - dateTimePicker1.Value);
            int ngay = (int)soNgay.TotalDays;
            tinhTien = ngay * int.Parse(txtGia.Text.ToString());

            MessageBox.Show(ngay.ToString());

            query = "update truyenTranh set ngayTra='"+dateTimePicker2.Text.ToString()+"',thanhTien='"+tinhTien+"',ghiChu='' where stt="+ehe+";";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }
    }
}
