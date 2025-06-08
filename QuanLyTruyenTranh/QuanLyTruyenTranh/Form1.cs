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

namespace QuanLyTruyenTranh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-AB5K23N\\SQLEXPRESS; Initial Catalog = QuanLyTruyen; Integrated Security = True ");
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(textBox2.Text);
            }
            catch (FormatException)
            {

                MessageBox.Show("So dien thoai khong phai la so");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
            conn.Open();
            string LayTenTruyen = "SELECT TenTruyen FROM Truyen";
            SqlCommand cmd = new SqlCommand(LayTenTruyen, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr[0].ToString());
            }

            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            string TenTruyen = comboBox1.Text;
            string LayGia = "SELECT DonGia FROM Truyen WHERE TenTruyen = @TenTruyen";
            SqlCommand cmd = new SqlCommand(LayGia, conn);
            cmd.Parameters.AddWithValue("@TenTruyen", TenTruyen);
            string DonGia = cmd.ExecuteScalar().ToString();
            textBox3.Text = DonGia;
            conn.Close();
        }


        public void Display()
        {
            conn.Open();
            string Lay = "SELECT * FROM HoaDon JOIN Truyen ON HoaDon.TenTruyenId = Truyen.TenTruyenId";
            SqlCommand cmd = new SqlCommand(Lay, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow r = dataGridView1.Rows[rowIndex];
                r.Cells["STT"].Value = dr["STT"].ToString();
                r.Cells["TenKhach"].Value = dr["TenKhach"].ToString();
                r.Cells["SoDienThoai"].Value = dr["SoDienThoai"].ToString();
                r.Cells["TenTruyen"].Value = dr["TenTruyen"].ToString();
                r.Cells["NgayMuon"].Value = dr["NgayMuon"].ToString();
                r.Cells["NgayTra"].Value = dr["NgayTra"].ToString();
                r.Cells["ThanhTien"].Value = dr["ThanhTien"].ToString();
                r.Cells["GhiChu"].Value = dr["GhiChu"].ToString();

            }
            conn.Close();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string TenTruyen = comboBox1.Text;
            string Lay = "SELECT TenTruyenId From Truyen WHERE TenTruyen = @TenTruyen";
            SqlCommand cmd = new SqlCommand(Lay, conn);
            cmd.Parameters.AddWithValue("@TenTruyen", TenTruyen);
            string TenTruyenId = cmd.ExecuteScalar().ToString();
            string insert = "Insert Into HoaDon (TenKhach, SoDienThoai, TenTruyenId, NgayMuon, GhiChu) Values (@TenKhach, @SoDienThoai, @TenTruyenId, @NgayMuon, @GhiChu)";
            SqlCommand cmd2 = new SqlCommand(insert, conn);
            cmd2.Parameters.AddWithValue("@TenKhach",textBox1.Text);
            cmd2.Parameters.AddWithValue("@SoDienThoai", textBox2.Text);
            cmd2.Parameters.AddWithValue("@TenTruyenId", TenTruyenId);
            cmd2.Parameters.AddWithValue("@NgayMuon", dateTimePicker1.Value);
            cmd2.Parameters.AddWithValue("@GhiChu", "Chua Tra");
            cmd2.ExecuteNonQuery();
            conn.Close();
            dataGridView1.Rows.Clear();
            Display();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        int rowIndexx;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (DateTime.TryParse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), out DateTime ngayMuon))
                {
                    dateTimePicker1.Value = ngayMuon;
                }
                else
                {

                    dateTimePicker1.Value = DateTime.Now;
                }

                if (DateTime.TryParse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(), out DateTime ngayTra))
                {
                    dateTimePicker2.Value = ngayTra;
                }
                else
                {
                    dateTimePicker2.Value = DateTime.Now;
                }
                rowIndexx = e.RowIndex;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Loi " + ex.Message);
            }
            

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int rowIndex = rowIndexx;
            string STT = dataGridView1.Rows[rowIndexx].Cells[0].Value.ToString();
            TimeSpan SoNgay = dateTimePicker2.Value - dateTimePicker1.Value;
            int SoNgay2 = (int)SoNgay.TotalDays;
            int ThanhTien = SoNgay2 * int.Parse(textBox3.Text);
            string Update2 = "Update HoaDon SET NgayTra = @NgayTra, ThanhTien = @ThanhTien, GhiChu = @GhiChu WHERE STT = @STT";
            SqlCommand cmd = new SqlCommand(Update2, conn);
            cmd.Parameters.AddWithValue("@NgayTra", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@GhiChu", "");
            cmd.Parameters.AddWithValue("@STT", STT);
            cmd.Parameters.AddWithValue("@ThanhTien", ThanhTien);
            cmd.ExecuteNonQuery();
            conn.Close();
            dataGridView1.Rows.Clear();
            Display();
        }
    }
}
