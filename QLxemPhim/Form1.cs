using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLxemPhim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Reset()
        {
            Color clrA = Color.FromArgb(192, 255, 255);
            Color clrB = Color.FromArgb(192, 255, 192);
            Color clrC = Color.FromArgb(255, 255, 192);
            Color crlD = Color.FromArgb(255, 192, 192);
            Color crlE = Color.FromArgb(255, 224, 192);
            Color crlF = Color.FromArgb(255, 192, 255);

            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Control btn = tableLayoutPanel1.GetControlFromPosition(j, i);
                    if (btn is Button)
                    {
                        if (i == 0) btn.BackColor = clrA;
                        else if (i == 1) btn.BackColor = clrB;
                        else if (i == 2) btn.BackColor = clrC;
                        else if (i == 3) btn.BackColor = crlD;
                        else if (i == 4) btn.BackColor = crlE;
                        else btn.BackColor = crlF;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "Mời bạn chọn ghế trong phòng chiếu phim " + comboBox1.Text;
            Reset();
        }
    }
}
