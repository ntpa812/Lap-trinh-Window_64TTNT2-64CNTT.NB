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

namespace QLhocTap
{
    public partial class Form2 : Form
    {
        Dictionary<string, string> lop64 = new Dictionary<string, string>();
        Dictionary<string, string> lop65 = new Dictionary<string, string>();

        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLkqHT;Integrated Security=True";
        string query = "", ma="";

        public Form2()
        {
            InitializeComponent();

            lop64.Add("64001", "Nguyễn Văn A");
            lop64.Add("64002", "Lê Văn B");
            lop64.Add("64003", "Trần Thị C");
            lop65.Add("65001", "Nguyễn AA");
            lop65.Add("65002", "Lê BB");
            lop65.Add("65003", "Trần CC");
            lop65.Add("65004", "Võ DD");

        }

        public void LoadData(string ma)
        {
            query = "select maSV,monHoc,diemHS1,diemHS2,diemThi,diemTL from kqHT where maSV='"+ma+"'";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Open();
                apt.Fill(dt);
                conn.Close();
            }
            dataGridView2.DataSource = dt;

            labelMon.Text = "Có " + dataGridView2.Rows.Count.ToString() + " điểm môn";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (comboBox1.Text=="64CNTT")
            {
                foreach (var item in lop64)
                {
                    dataGridView1.Rows.Add(item.Key, item.Value,"64CNTT");
                }    
            }
            else if (comboBox1.Text=="65CNTT")
            {
                foreach (var item in lop65)
                {
                    dataGridView1.Rows.Add(item.Key, item.Value, "65CNTT");
                }
            }
            labelSV.Text = "Có " + dataGridView1.Rows.Count.ToString() + " sinh viên";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>=0)
            {
                txtMaSV.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtTen.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                ma = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                LoadData(ma);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count >= 0)
            {
                txtMaSV.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtTen.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtMon.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                txtDiemHS1.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                txtDiemHS2.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                txtDiemThi.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                txtDiemThiLai.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "insert into kqHT(maSV,hoTen,lop,monHoc,diemHS1,diemHS2,diemThi,diemTL) values(@maSV,@tenSV,@lop,@monHoc,@diemHS1,@diemHS2,@diemThi,@diemTL)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maSV", txtMaSV.Text.ToString());
                cmd.Parameters.AddWithValue("@tenSV", txtTen.Text.ToString());
                cmd.Parameters.AddWithValue("@lop", comboBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@monHoc", txtMon.Text.ToString());
                cmd.Parameters.AddWithValue("@diemHS1", txtDiemHS1.Text.ToString());
                cmd.Parameters.AddWithValue("@diemHS2", txtDiemHS2.Text.ToString());
                cmd.Parameters.AddWithValue("@diemThi", txtDiemThi.Text.ToString());
                cmd.Parameters.AddWithValue("@diemTL", txtDiemThiLai.Text.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData(txtMaSV.Text.ToString());

        }
    }
}
