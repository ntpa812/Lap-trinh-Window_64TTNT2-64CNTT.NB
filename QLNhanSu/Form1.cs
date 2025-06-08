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
using System.Security.Cryptography;

namespace QLNhanSu
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-KFA2GB85\\MSSQLSERVER02;Initial Catalog=QLNhanSu;Integrated Security=True";
        string query = "";
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            query = "select hoTen,gioiTinh,queQuan,donVi,hocHam from NhanSu";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter apt = new SqlDataAdapter(query, conn);
                conn.Open();
                apt.Fill(dt);
                conn.Close();
            }
            dataGridView1.DataSource = dt;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gt = "";
            if (radioButton1.Checked == true) gt = "Nam";
            else if (radioButton2.Checked == true) gt = "Nữ";
            int maNS = (int)dataGridView1.Rows.Count + 1;
            query = "insert into NhanSu(maNS,hoTen,gioiTinh,queQuan,donVi,hocHam) values("+maNS+",N'" + txtTen.Text + "',N'" + gt + "',N'" + cbbQue.Text + "',N'" + cbbDonVi.Text + "',N'" + cbbHocHam.Text + "')";
            EditData(query);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTen.Text = dataGridView1.SelectedRows[0].Cells["hoTen"].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells["gioiTinh"].Value.ToString() == "Nam") radioButton1.Checked = true;
            else radioButton2.Checked = true;
            cbbQue.Text= dataGridView1.SelectedRows[0].Cells["queQuan"].Value.ToString();
            cbbDonVi.Text = dataGridView1.SelectedRows[0].Cells["donVi"].Value.ToString();
            cbbHocHam.Text = dataGridView1.SelectedRows[0].Cells["hocHam"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt = "", ten = txtTen.Text.ToString();
            if (radioButton1.Checked == true) gt = "Nam";
            else if (radioButton2.Checked == true) gt = "Nữ";
            int maNS = (int)dataGridView1.SelectedRows.Count + 1;
            query = "update NhanSu set hoTen=N'" + ten + "',gioiTinh=N'" + gt + "',queQuan=N'" + cbbQue.Text + "',donVi=N'" + cbbDonVi.Text + "',hocHam=N'" + cbbHocHam.Text + "' where maNS=" + maNS + "";
            EditData(query);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //int maNS = dataGridView1.SelectedRows.Count + 1;
            //query = "delete from NhanSu where maNS=" + maNS + "";
            string gt = "", ten = txtTen.Text.ToString();
            if (radioButton1.Checked == true) gt = "Nam";
            else if (radioButton2.Checked == true) gt = "Nữ";
            query = "delete from NhanSu where hoTen=N'" + ten + "' and queQuan=N'" + cbbQue.Text + "' and donVi=N'" + cbbDonVi.Text + "' and hocHam=N'" + cbbHocHam.Text + "' and gioiTinh='" + gt + "'";
            EditData(query);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            Form2 frmTK = new Form2();
            frmTK.Show();
        }
    }
}
