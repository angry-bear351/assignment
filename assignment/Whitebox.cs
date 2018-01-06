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
    public partial class Whitebox : Form
    {
        SqlConnection mySqlConnection;
        public Whitebox()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helen\Downloads\buglist.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");
            conn.Open();
            SqlCommand sc = new SqlCommand("select App from Buglist", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("App", typeof(string));
            dt.Load(reader);

            comboBox1.ValueMember = "App";
            comboBox1.DisplayMember = "App";
            comboBox1.DataSource = dt;

            conn.Close();
        }
        public void cleartxtBoxes()
        {
            classBox.Text = methodBox.Text = codeBox.Text = "";
        }

        public bool checkInputs()
        {
            bool rtnvalue = true;

            if (string.IsNullOrEmpty(classBox.Text) ||
                string.IsNullOrEmpty(methodBox.Text) ||
                string.IsNullOrEmpty(codeBox.Text) ||
                string.IsNullOrEmpty(lineBox.Text))
            {
                MessageBox.Show("Error: Please check your inputs");
                rtnvalue = false;
            }

            return (rtnvalue);

        }
        public void insertRecord(String Class, String Method, String Block, String Line, String commandString)
        {

            try
            {
                SqlCommand cmdInsert = new SqlCommand(commandString, mySqlConnection);

                cmdInsert.Parameters.AddWithValue("@Class", Class);
                cmdInsert.Parameters.AddWithValue("@Method", Method);
                cmdInsert.Parameters.AddWithValue("@Code Block", Block);
                cmdInsert.Parameters.AddWithValue("@Line Number", Line);
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("Bug details commited, Thank you", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show( " .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        { if (checkInputs())
            {

                String commandString = "INSERT INTO bugList([Class], [Method], [Code Block], [Line Number]) VALUES (@Class, @Method, @Code Block, @Line Number)";


        insertRecord(classBox.Text, methodBox.Text, codeBox.Text, lineBox.Text, commandString);
         cleartxtBoxes();
    }
    }

        private void Whitebox_FormClosed(object sender, FormClosedEventArgs e)
        {
            launcher lc = new launcher();
            lc.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
