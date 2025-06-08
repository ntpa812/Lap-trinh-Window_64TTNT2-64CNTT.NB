using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLketQuaMH
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var f in this.MdiChildren)
            {
                f.Close();
            }
            Form1 FO = new Form1();
            FO.MdiParent = this;
            FO.Show();
        }
    }
}
