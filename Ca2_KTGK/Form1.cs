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

namespace Ca2_KTGK
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLBanHang;Integrated Security=True";
        string query = "";

        Dictionary<string, int> hangTT = new Dictionary<string, int>();
        
        Dictionary<string, int> hangSGK = new Dictionary<string, int>();

        public Form1()
        {
            ClearData();

            InitializeComponent();
            LoadData();

            hangTT.Add("Doraemon",20000);
            hangTT.Add("Shin",16000);
            hangTT.Add("Conan",22000);  

            hangSGK.Add("Ngữ văn 12",7000);
            hangSGK.Add("Giaỉ tích 10",5000);
            hangSGK.Add("Ngoại ngữ 3",20000);

            label1.MouseDown += new MouseEventHandler(label1_MouseDown);
        }

        public void LoadData()
        {
            DataTable dt = new DataTable();
            query = "select tenHang,soLuong,donGia,thanhTien from hoaDon";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Close();

                apt.Fill(dt);
            }    

            dataGridView2.DataSource = dt;

            int stt3 = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                stt3++;
                dataGridView2.Rows[i].Cells["stt2"].Value = stt3;
            }
        }

        public void EditData(string query)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

        public void ClearData()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            label2.Text = "Các hàng thuộc loại " + comboBox1.Text.ToString();
            if (comboBox1.Text == "Truyện tranh") 
            {
                int stt = 1;
                foreach(var item in hangTT)
                {
                    dataGridView1.Rows.Add(stt++, item.Key, item.Value);
                }
            }
            else if (comboBox1.Text == "Sách giáo khoa")
            {
                int stt = 1;
                foreach(var item in hangSGK)
                {
                    dataGridView1.Rows.Add(stt++, item.Key, item.Value);
                }    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count >= 0)
            {
                ClearData();
            }
            else
            {
                MessageBox.Show("Chưa chọn mặt hàng");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count==0 || comboBox1.Text == "")
            {
                MessageBox.Show("Vui lòng chọn mặt hàng");
            }
            else if ((int)numericUpDown1.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng");
            }   
            else
            {
                
                string tenHang = dataGridView1.SelectedRows[0].Cells["tenHang"].Value.ToString();
                int donGia = (int)dataGridView1.SelectedRows[0].Cells["donGia"].Value;

                int thanhTien = donGia * (int)numericUpDown1.Value;   

                query = "insert into hoaDon(tenHang,soLuong,donGia,thanhTien) values(N'"+tenHang+"','"+numericUpDown1.Value.ToString()+"',"+donGia+","+thanhTien+")";

                EditData(query);
    
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTenKhach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên");
                txtTenKhach.Focus();
            }
            else
            {
                 int total = 0;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    total += Convert.ToInt32(row.Cells["thanhTien2"].Value);
                }

                txtTongTien.Text = total.ToString();               
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                string tenHang = dataGridView2.SelectedRows[0].Cells["tenHang2"].Value.ToString();
                query= "delete from hoaDon where tenHang='"+tenHang+"'";
                EditData(query);
            }    
              
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            sender = sender as object;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Đổi màu",null,Option1_Click);

                Control control = (Control)sender;
                menu.Show(control, new Point(e.X, e.Y));
            }
        }

        private void Option1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            Color selectedColor = colorDialog.Color;

            ContextMenuStrip contextMenu = (sender as ToolStripItem)?.GetCurrentParent() as ContextMenuStrip;
            if (contextMenu != null)
            {
                Control control = contextMenu.SourceControl;

                if (control.GetType()==typeof(DataGridView))
                {
                    DataGridView dgv = (DataGridView)control;
                    if (dgv.SelectedCells.Count > 0)
                    {
                        foreach (DataGridViewCell cell in dgv.SelectedCells)
                        {
                            cell.Style.BackColor = selectedColor;
                        }
                    }
                }
                else control.BackColor = selectedColor;

            }
        }
    }
}
