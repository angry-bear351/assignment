using System.Data.SqlClient;
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
    public partial class Advancedbox : Form
    {
        SqlConnection mySqlConnection;
        public Advancedbox()
        {
            InitializeComponent();
        }
        public void insertRecord(String Fixed, String commandString)
        {

            try
            {
                SqlCommand cmdInsert = new SqlCommand(commandString, mySqlConnection);

                cmdInsert.Parameters.AddWithValue("@Fixed", Fixed);
            }
            catch (SqlException ex)
            {
                MessageBox.Show( " .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Advancedbox_FormClosed(object sender, FormClosedEventArgs e)
        {
            launcher lc = new launcher();
            lc.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            String commandString = "INSERT INTO bugList([Class]) VALUES (@Fixed,)";


            insertRecord("Y", commandString);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            String commandString = "INSERT INTO bugList([Class]) VALUES (@Fixed,)";


            insertRecord("N", commandString);
        }
    }
}
