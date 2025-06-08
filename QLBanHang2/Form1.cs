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

namespace QLBanHang2
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> truyenTranh = new Dictionary<string, int>();
        Dictionary<string, int> sgk = new Dictionary<string, int>();
        Dictionary<string, int> doChoi = new Dictionary<string, int>();
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLBanHang2;Integrated Security=True";
        string query = "";
        public Form1()
        {
            InitializeComponent();
            truyenTranh.Add("Doraemon", 16000);
            truyenTranh.Add("Shin", 18000);
            sgk.Add("Tiếng Anh", 10000);
            sgk.Add("Ngữ Văn", 7000);
            doChoi.Add("Ô tô", 25000);
            doChoi.Add("Búp bê", 50000);
        }
        public void LoadData()
        {
            query = "select tenHang,donGia,soLuong,thanhTien from BanHang";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Open();
                apt.Fill(dt);
                conn.Close();
            }
            dataGridView2.DataSource = dt;
            for (int i=0;i<dataGridView2.Rows.Count;i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = (i + 1);
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

        private void btnTao_Click(object sender, EventArgs e)
        {
            query = "delete from BanHang";
            EditData(query);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            label2.Text = "Các hàng thuộc loại " + comboBox1.Text;
            int i = 0;
            if (comboBox1.Text == "Truyện tranh")
            {
                foreach (var item in truyenTranh)
                {
                    i++;
                    dataGridView1.Rows.Add((i), item.Key, item.Value);
                }
            }
            else if (comboBox1.Text == "Sách giáo khoa")
            {
                foreach (var item in sgk)
                {
                    i++;
                    dataGridView1.Rows.Add((i), item.Key, item.Value);
                }
            }
            else if (comboBox1.Text == "Đồ chơi")
            {
                foreach (var item in doChoi)
                {
                    i++;
                    dataGridView1.Rows.Add((i), item.Key, item.Value);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenH = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int donG = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            int soL = (int)numericUpDown1.Value;
            int thanhT = donG * soL;
            query = "insert into BanHang(tenHang,donGia,soLuong,thanhTien) values(N'" + tenH + "'," + donG + "," + soL + "," + thanhT + ")";
            EditData(query);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count>=0)
            {
                string tenH = dataGridView2.SelectedRows[0].Cells["tenHang"].Value.ToString();
                int donG = int.Parse(dataGridView2.SelectedRows[0].Cells["donGia"].Value.ToString());
                int soL = int.Parse(dataGridView2.SelectedRows[0].Cells["soLuong"].Value.ToString());
                query = "delete from BanHang where tenHang=N'" + tenH + "' and donGia=" + donG + " and soLuong=" + soL + "";
                EditData(query);
            }
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            int tongT = 0;
            for (int i=0;i<dataGridView2.Rows.Count;i++)
            {
                tongT += int.Parse(dataGridView2.Rows[i].Cells["thanhTien"].Value.ToString());
            }
            textBox2.Text = tongT.ToString();
        }

        private void đổiMàuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = null;
            ToolStripItem x = ((ToolStripItem)sender);
            ToolStrip y = x.Owner;
            ContextMenuStrip z = ((ContextMenuStrip)y);
            c = z.SourceControl;
            ColorDialog clr = new ColorDialog();
            clr.ShowDialog();
            c.BackColor = clr.Color;

        }
    }
}
