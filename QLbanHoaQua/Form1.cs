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

namespace QLbanHoaQua
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLhoaQua;Integrated Security=True";
        string query = "";

        public Form1()
        {
            InitializeComponent();
            LoadData();

            txtTong.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {

            query = "select * from HDhoaQua";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Open();
                apt.Fill(dt);
                conn.Close();
            }
            dataGridView1.DataSource = dt;

            //for (int i=0;i<dataGridView1.Rows.Count;i++)
            //{
            //    dataGridView1.Rows[i].Cells["stt"].Value = (i+1);
            //}
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


        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Táo") textBox1.Text = "10000";
            else if (comboBox1.Text == "Lê") textBox1.Text = "13000";
            else if (comboBox1.Text == "Dưa hấu") textBox1.Text = "20000";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value<=0)
            {
                MessageBox.Show("Vui lòng nhập lại số lượng");
                numericUpDown1.Focus();
            }
            else
            {
                int i = dataGridView1.Rows.Count+1;
                int total = int.Parse(textBox1.Text.ToString()) * int.Parse(numericUpDown1.Value.ToString());
                query = "insert into HDhoaQua(stt,tenSP,donGia,soLuong,thanhTien) values("+i+",N'" + comboBox1.Text.ToString() + "',"+ int.Parse(textBox1.Text.ToString()) + "," + int.Parse(numericUpDown1.Value.ToString()) + ","+total+")";
                EditData(query);

                txtTong.Text = Convert.ToString(int.Parse(txtTong.Text.ToString()) + total);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string i = dataGridView1.SelectedRows[0].Cells["stt"].Value.ToString();
                int gia = int.Parse(dataGridView1.SelectedRows[0].Cells["thanhTien"].Value.ToString());
                query = "delete from HDhoaQua where stt=" + i + "";

                EditData(query);
                txtTong.Text = Convert.ToString(int.Parse(txtTong.Text.ToString()) - gia);
            }
            else MessageBox.Show("Lỗi");
        }

        private void txtKhachDua_Leave(object sender, EventArgs e)
        {
            try
            {
                int khach = int.Parse(txtKhachDua.Text.ToString());
                int tong = int.Parse(txtTong.Text.ToString());
                if (khach < tong) MessageBox.Show("Chưa trả đủ tiền");
                else
                {
                    txtTraLai.Text = Convert.ToString(khach - tong);
                } 
                    
            }
            catch (Exception)
            {

                MessageBox.Show("Vui lòng nhập số");
                txtKhachDua.Focus();
            }
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            query = "delete from HDhoaQua";
            EditData(query);
        }
    }
}
