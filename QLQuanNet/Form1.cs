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
using System.Runtime.InteropServices;

namespace QLQuanNet
{
    public partial class Form1 : Form
    {
        string query = "";
        string connnectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLquanNet;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            query = "select * from quanNet";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connnectionString))
            {
                conn.Open();
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Close();

                apt.Fill(dt);
            }
            dataGridView1.DataSource = dt;

            int stt1 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                stt1++;
                dataGridView1.Rows[i].Cells["stt"].Value = stt1;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.BackColor!=Color.Red)
            {
                control.BackColor = Color.Red;
            }
            else
            {
                MessageBox.Show("Máy đã được chọn");
            }
  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Control control= (Control)sender;
            if (control.Text != "")
            {
                try
                {
                    int check = int.Parse(control.Text.ToString());
                    if (check < 0||check>24)
                    {
                        MessageBox.Show("Vui lòng nhập lại");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Vui lòng nhập số nguyên");
                }
            }
        }

        public float tinhTong(int a,int b)
        {
            float tong;
            tong = (b - a) * 5000;
            return tong;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int vao=int.Parse(textBox1.Text.ToString());
                int ra = int.Parse(textBox6.Text.ToString());
                float tong = tinhTong(vao, ra);
                textBox12.Text = tong.ToString();

                if (button1.BackColor != Color.Red)
                {
                    MessageBox.Show("Máy chưa mở");
                }
                else
                {
                    AddData("1", vao.ToString(), ra.ToString(), (ra - vao), 5000, tong);

                    button1.BackColor = Color.LightSteelBlue;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập giờ");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int vao = int.Parse(textBox2.Text.ToString());
                int ra = int.Parse(textBox7.Text.ToString());
                float tong = tinhTong(vao, ra);
                textBox13.Text = tong.ToString();

                if (button2.BackColor != Color.Red)
                {
                    MessageBox.Show("Máy chưa mở");
                }
                else
                {
                    AddData("2", vao.ToString(), ra.ToString(), (ra - vao), 5000, tong);

                    button2.BackColor = Color.LightSteelBlue;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập giờ");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int vao = int.Parse(textBox3.Text.ToString());
                int ra = int.Parse(textBox8.Text.ToString());
                float tong = tinhTong(vao, ra);
                textBox14.Text = tong.ToString();

                if (button3.BackColor != Color.Red)
                {
                    MessageBox.Show("Máy chưa mở");
                }
                else
                {
                    AddData("3", vao.ToString(), ra.ToString(), (ra - vao), 5000, tong);

                    button3.BackColor = Color.LightSteelBlue;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập giờ");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int vao = int.Parse(textBox4.Text.ToString());
                int ra = int.Parse(textBox9.Text.ToString());
                float tong = tinhTong(vao, ra);
                textBox15.Text = tong.ToString();

                if (button4.BackColor != Color.Red)
                {
                    MessageBox.Show("Máy chưa mở");
                }
                else
                {
                    AddData("4", vao.ToString(), ra.ToString(), (ra - vao), 5000, tong);

                    button4.BackColor = Color.LightSteelBlue;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập giờ");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int vao = int.Parse(textBox5.Text.ToString());
                int ra = int.Parse(textBox17.Text.ToString());
                float tong = tinhTong(vao, ra);
                textBox16.Text = tong.ToString();

                if (button5.BackColor != Color.Red)
                {
                    MessageBox.Show("Máy chưa mở");
                }
                else
                {
                    AddData("5", vao.ToString(), ra.ToString(), (ra - vao), 5000, tong);

                    button5.BackColor = Color.LightSteelBlue;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập giờ");
            }
        }

        public void AddData(string soMay, string gioVao, string gioRa, int soGioSD, int donGia, float thanhTien)
        {
            query = "insert into quanNet(soMay,gioVao,gioRa,soGioSD,donGia,thanhTien) values(@soMay,@gioVao,@gioRa,@soGioSD,@donGia,@thanhTien)";

            using (SqlConnection conn=new SqlConnection(connnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@soMay", soMay);
                cmd.Parameters.AddWithValue("@gioVao", gioVao);
                cmd.Parameters.AddWithValue("@gioRa", gioRa);
                cmd.Parameters.AddWithValue("@soGioSD",soGioSD);
                cmd.Parameters.AddWithValue("@donGia",donGia);
                cmd.Parameters.AddWithValue("@thanhTien",thanhTien);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

    }
}
