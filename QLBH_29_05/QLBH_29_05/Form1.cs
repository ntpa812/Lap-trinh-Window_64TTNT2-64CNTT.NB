using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_29_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                    
                if(comboBox1.Text =="Táo")
                {
                    textBox1.Text = "10";
                }
                if (comboBox1.Text == "Ổi")
                {
                    textBox1.Text = "20";
                }
            }
        }
        public int stt = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            int thanhtien = Convert.ToInt32(numericUpDown1_soluong.Text) * Convert.ToInt32(textBox1.Text);
            dataGridView1.Rows.Add(stt++, comboBox1.Text, numericUpDown1_soluong.Text, textBox1.Text,thanhtien);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int tong = 0;
            for(int i = 0; i < dataGridView1.Rows.Count -1 ; i++)
            {
                tong += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString());


            }
            textBox2.Text = tong.ToString();
        }

        private void đổiMàuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = null;

            ToolStripItem x = ((ToolStripItem)sender);
            ToolStrip y = x.Owner;
            ContextMenuStrip z = (ContextMenuStrip)y;
            c = z.SourceControl;
            if (c is Button) {
                //c.BackColor = Color.Red;
                ColorDialog clr = new ColorDialog();
                clr.ShowDialog();
                c.BackColor = clr.Color;

            }
            else if( c is Label) {
                c.BackColor = Color.Yellow;
            }
            //c = ( (ContextMenuStrip) ((ToolStripItem)sender).Owner).SourceControl;
            
        }

        private void đổiPhôngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
