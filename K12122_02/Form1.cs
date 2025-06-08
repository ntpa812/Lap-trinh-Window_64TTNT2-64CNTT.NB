using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K12122_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public int stt = 1;
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            stt = dataGridView1.Rows.Count;
            dataGridView1.Rows.Add(stt, textTenKhach.Text, comboBoxTenHang.Items, numericSlg.Value, textDonGia.Text);
        }

        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
