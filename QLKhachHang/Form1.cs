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

namespace QLKhachHang
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLKhachHang;Integrated Security=True";
        string query = "";
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            query = "select hoTen,gioiTinh,loaiPhong,soPhongThue from KhachHang";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Open();
                apt.Fill(dt);
                conn.Close();
            }
            dataGridView1.DataSource = dt;

            for (int i=0;i<dataGridView1.Rows.Count;i++)
            {
                dataGridView1.Rows[i].Cells["stt"].Value = i+1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHoten.Text = dataGridView1.SelectedRows[0].Cells["hoTen"].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells["gioiTinh"].Value.ToString() == "Nam")
            {
                radioButton1.Checked = true;
            }
            else radioButton2.Checked = true;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["loaiPhong"].Value.ToString();
            txtSoPhong.Text = dataGridView1.SelectedRows[0].Cells["soPhongThue"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int ma = (int)dataGridView1.Rows.Count + 100;
            string gt = "";
            if (radioButton2.Checked == true) gt = "Nữ";
            else if (radioButton1.Checked == true) gt = "Nam";
            query = "insert into KhachHang(maKH,hoTen,gioiTinh,loaiPhong,soPhongThue) values("+ma+",N'" + txtHoten.Text.ToString() + "',N'" + gt + "',N'" + comboBox1.Text.ToString() + "','" + txtSoPhong.Text.ToString() + "')";

            EditData(query);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select hoTen,gioiTinh,loaiPhong,soPhongThue from KhachHang where hoTen=N'" + txtTim.Text.ToString() + "'";
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                    conn.Open();
                    apt.Fill(dt);
                    conn.Close();
                }
                dataGridView1.DataSource = dt;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["stt"].Value = i + 1;
                }

                if (txtTim.Text == "")
                {
                    MessageBox.Show("Hãy nhập tên cần tìm");
                    txtTim.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ko tim thay");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int makh = (int)dataGridView1.SelectedRows[0].Cells["stt"].Value + 100;
            string gt = "";
            if (radioButton2.Checked == true) gt = "Nữ";
            else if (radioButton1.Checked == true) gt = "Nam";

            query = "update KhachHang set hoTen=N'"+txtHoten.Text.ToString()+"',gioiTinh=N'"+gt+"',loaiPhong=N'"+comboBox1.Text.ToString()+"',soPhongThue="+txtSoPhong.Text.ToString()+" where maKH=" + makh + "";
            EditData(query);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int makh = (int)dataGridView1.SelectedRows[0].Cells["stt"].Value + 100;

            query = "delete from KhachHang where maKH=" + makh + "";
            EditData(query);
        }
    }
}
