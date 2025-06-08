using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel1, 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LBirthDate_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string gender = " ";
            if (radioNam.Checked)
            {
                gender = "Nam";
            }
            else if (radioNu.Checked)
            {
                gender = "Nữ";
            }
            dataGridView1.Rows.Add(txtMa.Text, txtHoTen.Text, dateTimePicker1.Text, gender , textBox2.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
        public int indexselected = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Nam")
            {
                radioNam.Checked = true;    
            }
            else 
            {
                radioNu.Checked = true; 
            }

            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            indexselected = e.RowIndex;
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(indexselected);
        }

        private void bCfg_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[indexselected].Cells[4].Value = textBox2.Text;
            dataGridView1.Rows[indexselected].Cells[0].Value = txtMa.Text;
            dataGridView1.Rows[indexselected].Cells[1].Value = txtHoTen.Text;
            dataGridView1.Rows[indexselected].Cells[2].Value = dateTimePicker1.Text;
        }
    }
}
