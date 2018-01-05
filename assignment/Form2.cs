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
    public partial class Form2 : Form
    {
        SqlConnection mySqlConnection;
        public Form2()
        {
            InitializeComponent();
            populateListBox();
        }

        public void cleartxtBoxes()
        {
            txtId.Text = txtName.Text = txtAddress.Text = "";
        }

        public bool checkInputs()
        {
            bool rtnvalue = true;

            if (string.IsNullOrEmpty(txtId.Text) ||
                string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Error: Please check your inputs");
                rtnvalue = false;
            }

            return (rtnvalue);

        }


        public void insertRecord(String ID, String App, String Bug, String Cause, String commandString)
        {

            try
            {
                SqlCommand cmdInsert = new SqlCommand(commandString, mySqlConnection);

                cmdInsert.Parameters.AddWithValue("@ID", ID);
                cmdInsert.Parameters.AddWithValue("@App", App);
                cmdInsert.Parameters.AddWithValue("@Bug", Bug);
                cmdInsert.Parameters.AddWithValue("@Cause", Cause);
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("Bug Reported, Thank you","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ID + " .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void populateListBox()
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\source\buglist.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true");

            String selcmd = "SELECT [Id], [App], [Bug], [Cause] FROM bugList ORDER BY [App]";

            SqlCommand mySqlCommand = new SqlCommand(selcmd, mySqlConnection);

            try
            {
                mySqlConnection.Open();

                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                lbxstudents.Items.Clear();

                while (mySqlDataReader.Read())
                {

                    lbxstudents.Items.Add(mySqlDataReader["App"] + " " +
                           mySqlDataReader["Bug"] + " " + mySqlDataReader["Cause"]);
                    lbxstudents.Items.Add("********************");


                }

            }

            catch (SqlException ex)
            {

                MessageBox.Show(" .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInputs())
            {

                String commandString = "INSERT INTO bugList([Id], [App], [Bug], [Cause]) VALUES (@ID, @App, @Bug, @Cause)";

                insertRecord(txtId.Text, txtName.Text, txtAddress.Text, Cause.Text, commandString);
                populateListBox();
                cleartxtBoxes();
            }
    }
    }
}
