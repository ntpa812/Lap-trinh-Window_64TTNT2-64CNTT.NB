using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace QLDiemSV
{

    public partial class Form1 : Form
    {
        List<string> dsMa = new List<string>()
        {
            "SV001","SV002","SV003"
        };
        List<string> dsTen = new List<string>()
        {
            "Nguyen Van A","Tran Thi B","Le Van C"
        };

        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLDiem;Integrated Security=True";
        string query = "";

        public Form1()
        {
            //ClearData();

            InitializeComponent();
            LoadData();

            comboBox1.DataSource = dsMa;
        }

        public void ClearData()
        {
            query = "delete Diem";
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
            query = "select * from Diem";
            DataSet dt = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adt = new SqlDataAdapter(query, conn);
                conn.Close();

                adt.Fill(dt);
            }

            dataGridView1.DataSource = dt.Tables[0];
            dataGridView2.DataSource = dataGridView1.DataSource;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (dsMa[i] == comboBox1.Text.ToString())
                {
                    txtTenSV.Text = dsTen[i];
                }
            }
        }

        private void txtToan_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            //Int32.TryParse(txtSDT.Text, out Int32 a)
            bool checkDiem = Int16.TryParse(textBox.Text, out Int16 a);
            if (a < 0 || a > 10)
            {
                MessageBox.Show("Lỗi nhập điểm");
                textBox.Focus();
            }
        }

        public float tinhDiemTB()
        {
            //bool d1 = Double.TryParse(txtToan.Text, out Double diem1);
            //bool d2 = Double.TryParse(txtVan.Text, out Double diem2);
            //bool d3 = Double.TryParse(txtNN.Text, out Double diem3);

            float toan= float.Parse(txtToan.Text.ToString()), van=float.Parse(txtVan.Text.ToString()), nn=float.Parse(txtNN.Text.ToString());

            //float tb = (float)((diem1 + diem2 + diem3) / 3);

            float tb=(toan+van+nn)/3;

            return tb;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
             query = "INSERT INTO Diem (maSV, tenSV, diemToan, diemVan, diemNN, diemTB) VALUES (@maSV, @tenSV, @diemToan, @diemVan, @diemNN, @diemTB)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                float tb = tinhDiemTB();

                //query = "insert into Diem(maSV,tenSV,diemToan,diemVan,diemNN,diemTB) values(N'" + comboBox1.Text + "',N'" + txtTenSV.Text + "'," + txtToan.Text + "," + txtVan.Text + "," + txtNN.Text + "," + tb + ")";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maSV", comboBox1.Text);
                cmd.Parameters.AddWithValue("@tenSV", txtTenSV.Text);
                cmd.Parameters.AddWithValue("@diemToan", txtToan.Text);
                cmd.Parameters.AddWithValue("@diemVan", txtVan.Text);
                cmd.Parameters.AddWithValue("@diemNN", txtNN.Text);
                cmd.Parameters.AddWithValue("@diemTB", tb);
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
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells["maSV"].Value.ToString();
                txtTenSV.Text = dataGridView1.SelectedRows[0].Cells["tenSV"].Value.ToString();
                txtToan.Text = dataGridView1.SelectedRows[0].Cells["diemToan"].Value.ToString();
                txtVan.Text = dataGridView1.SelectedRows[0].Cells["diemVan"].Value.ToString();
                txtNN.Text = dataGridView1.SelectedRows[0].Cells["diemNN"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            float tb = tinhDiemTB();
            //string maSV = comboBox1.Text.ToString(), tenSV = txtTenSV.Text.ToString();
            //string toan = txtToan.Text.ToString(), van = txtVan.Text.ToString(), nn = txtNN.Text.ToString();
            
            string checkMa = comboBox1.Text;
            //float toan = float.Parse(txtToan.Text.ToString()), van = float.Parse(txtVan.Text.ToString()), nn = float.Parse(txtNN.Text.ToString());


            query = "update Diem set diemToan=@toan,diemVan=@van,diemNN=@nn,diemTB=@tb where maSV=@checkMa";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@toan",txtToan.Text);
                cmd.Parameters.AddWithValue("@van",txtVan.Text);
                cmd.Parameters.AddWithValue("@nn",txtNN.Text);
                cmd.Parameters.AddWithValue("@tb", tb);
                cmd.Parameters.AddWithValue("@checkMa",checkMa);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string checkMa = comboBox1.Text;
            query = "delete from Diem where maSV='" + checkMa + "'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadData();
        }

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    btnTim_Click(sender, e);
        //}

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            if (comboBox2.Text == "Giỏi")
            {
                query = "select * from Diem where diemTB>=8";
            }
            else if (comboBox2.Text =="Khá")
            {
                query = "select * from Diem where diemTB<8 and diemTB>=6.5";
            }
            else
            {
                query = "select * from Diem where diemTB<6.5";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Clear the previous data in the DataSet (optional)
                dt.Clear();

                // Fill the DataSet with the result of the query
                adapter.Fill(dt);

                // Update the DataGridView with the new data
                dataGridView2.DataSource = dt.Tables[0];

                conn.Close();


            }
            
        }

    }
}
