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
using ColorCode;

namespace assignment
{
    /// <summary>
    /// This is the second stage testing screen for more indepth reporting
    /// </summary>
    public partial class Whitebox : Form
    {
        SqlConnection mySqlConnection;
        /// <summary>
        /// These are the initial setup components
        /// </summary>
        public Whitebox()
        {
            InitializeComponent();
            /// <summary>
            /// the following code is used to assign data from the connected database to the drop down boxes used for selecting the application and the bug to ensure the data to be imputted is entered in the correct columns
            /// </summary>

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\buglist.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");
            conn.Open();
            SqlCommand sc = new SqlCommand("select Id, App, Bug from Buglist", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("App", typeof(string));
            dt.Columns.Add("Bug", typeof(string));
            dt.Load(reader);

            comboBox1.ValueMember = "App";
            comboBox1.DisplayMember = "App";
            comboBox1.DataSource = dt;
            comboBox2.ValueMember = "Bug";
            comboBox2.DisplayMember = "Bug";
            comboBox2.DataSource = dt;



        }
        /// <summary>
        /// this is used to make the text boxes empty, ready for the next set of data
        /// </summary>
        public void cleartxtBoxes()
        {
            classBox.Text = methodBox.Text = codeBox.Text = lineBox.Text = "";
        }
        /// <summary>
        /// this ensures the text boxes are populated to ensure there are no error pertaining to null values
        /// </summary>
        /// <returns>
        /// either TRUE or FALSE
        /// </returns>
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
        /// <summary>
        /// this is the main method for this form, it is what pushes the data from the form to the database
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Method"></param>
        /// <param name="Block"></param>
        /// <param name="Line"></param>
        /// <param name="Author"></param>
        /// <param name="Bug"></param>
        /// <param name="commandString"></param>
        public void insertRecord(String Class, String Method, String Block, String Line, String Author, String Bug, String commandString)
            
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\buglist.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");

            mySqlConnection.Open();
            try
            {
                SqlCommand cmdInsert = new SqlCommand(commandString, mySqlConnection);

                cmdInsert.Parameters.AddWithValue("@Class", Class);
                cmdInsert.Parameters.AddWithValue("@Method", Method);
                cmdInsert.Parameters.AddWithValue("@Code", Block);
                cmdInsert.Parameters.AddWithValue("@Line", Line);
                cmdInsert.Parameters.AddWithValue("@Author", Author);
                cmdInsert.Parameters.AddWithValue("@Bug", Bug);
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("Bug details commited, Thank you", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show( Class +" .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// this generates the a view of the code block to identify the errors
        /// </summary>
        public void ColourCodeCSharp()
        {

            string colourizedSourceCode = new CodeColorizer().Colorize(txtSourceCodeView.Text, Languages.CSharp);
            //txtSourceCode.Text = colourizedSourceCode;

            string html = ("<!doctype html><head><meta charset=\"utf-8\" <title> Code Snippet </title> </head> <body>" + colourizedSourceCode + "</body></html>");
            System.IO.File.WriteAllText(@"C:\Users\Gareth.DESKTOP-V17I0IV\source\repos\assignment\assignment\Code.html", html);
        }


        private void Button2_Click(object sender, EventArgs e)
        { if (checkInputs())
            {

                String commandString = "UPDATE bugList SET [Class] = @Class, [Method] = @Method, [Code Block] = @Code, [Line Number] = @Line, [Code Author] = @Author  WHERE Bug = @Bug";


            insertRecord(classBox.Text, methodBox.Text, codeBox.Text, lineBox.Text, authorName.Text, comboBox2.Text, commandString);
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

        private void button1_Click(object sender, EventArgs e)
        {
            ColourCodeCSharp();
            System.Diagnostics.Process.Start(@"C:\Users\Gareth.DESKTOP-V17I0IV\source\repos\assignment\assignment\Code.html");
        }
    }
}
