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
    /// <summary>
    /// this is the launcher screen
    /// </summary>
    public partial class launcher : Form
    {
        /// <summary>
        /// this handles the other forms and is the main application
        /// </summary>
        public launcher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Blackbox bb = new Blackbox();
            bb.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Whitebox wb = new Whitebox();
            wb.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Advancedbox ab = new Advancedbox();
            ab.Show();
            this.Hide();
        }

        private void launcher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
