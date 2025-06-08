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

namespace QLSinhVien
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLSinhVien;Integrated Security=True";
        string query = "";
        public Form1()
        {
            InitializeComponent();

            LoadData();
        }
        public void LoadData()
        {
            query = "select * from SV";
            DataSet dt = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Close();

                apt.Fill(dt);
            }
            dataGridView1.DataSource = dt.Tables[0];
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rbtnNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gioiTinh;
            if (rbtnNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else if (rbtnNu.Checked) { }
            {
                gioiTinh = "Nữ";
            }
            query = "insert into SV(maSV,hoTen,ngaySinh,noiSinh,gioiTinh) values(N'" + txtMa.Text + "',N'" + txtTen.Text + "','" + dateTimePicker1.Text.ToString() + "',N'" + comboBox1.Text + "',N'" + gioiTinh + "')";

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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtMa.Text = dataGridView1.SelectedRows[0].Cells["maSV"].Value.ToString();
                txtTen.Text = dataGridView1.SelectedRows[0].Cells["hoTen"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells["ngaySinh"].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells["noiSinh"].Value.ToString();
                string gt = dataGridView1.SelectedRows[0].Cells["gioiTinh"].Value.ToString();
                if (gt == "Nam") rbtnNam.Checked = true;
                else rbtnNu.Checked = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string checkMa=txtMa.Text;
            query = "UPDATE SV SET maSV=@maSV,hoTen=@hoTen,ngaySinh=@ngaySinh,gioiTinh=@gt,noiSinh=@noiSinh where maSV='"+checkMa+"'";

            string gioiTinh;
            if (rbtnNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else if (rbtnNu.Checked) { }
            {
                gioiTinh = "Nữ";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maSV", txtMa.Text);
                cmd.Parameters.AddWithValue("@hoTen",txtTen.Text);
                cmd.Parameters.AddWithValue("@ngaySinh", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@gt", gioiTinh);
                cmd.Parameters.AddWithValue("noiSinh",comboBox1.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string checkMa = txtMa.Text;
            query = "delete from SV where maSV='" + checkMa + "'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd=new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();            
        }
    }
}
