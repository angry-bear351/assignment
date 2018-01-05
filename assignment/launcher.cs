using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment
{
    public partial class launcher : Form
    {
        public launcher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Blackbox bb = new Blackbox();
            bb.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Whitebox wb = new Whitebox();
            wb.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Advancedbox ab = new Advancedbox();
            ab.Show();
            this.Close();
        }
    }
}
