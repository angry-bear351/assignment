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
            SqlCommand sc = new SqlCommand("select Id, App from Buglist", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("App", typeof(string));
            dt.Load(reader);

            comboBox1.ValueMember = "App";
            comboBox1.DisplayMember = "App";
            comboBox1.DataSource = dt;

            
        }
        public void cleartxtBoxes()
        {
            classBox.Text = methodBox.Text = codeBox.Text = lineBox.Text = "";
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
        public void insertRecord(String Class, String Method, String Block, String Line, String Author, String App, String commandString)
            
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helen\Downloads\buglist.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");

            mySqlConnection.Open();
            try
            {
                SqlCommand cmdInsert = new SqlCommand(commandString, mySqlConnection);

                cmdInsert.Parameters.AddWithValue("@Class", Class);
                cmdInsert.Parameters.AddWithValue("@Method", Method);
                cmdInsert.Parameters.AddWithValue("@Code", Block);
                cmdInsert.Parameters.AddWithValue("@Line", Line);
                cmdInsert.Parameters.AddWithValue("@Author", Author);
                cmdInsert.Parameters.AddWithValue("@App", App);
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("Bug details commited, Thank you", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show( Class +" .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        private void Button2_Click(object sender, EventArgs e)
        { if (checkInputs())
            {

                String commandString = "UPDATE bugList SET [Class] = @Class, [Method] = @Method, [Code Block] = @Code, [Line Number] = @Line, [Code Author] = @Author  WHERE App = @App";


            insertRecord(classBox.Text, methodBox.Text, codeBox.Text, lineBox.Text, authorName.Text, comboBox1.Text, commandString);
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
            //label4.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
