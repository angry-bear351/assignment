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
    /// <summary>
    /// this is the first level of testing, the information from this is of a general level
    /// </summary>
    public partial class Blackbox : Form
    {
        SqlConnection mySqlConnection;
        /// <summary>
        /// this sets the form up
        /// </summary>
        public Blackbox()
        {
            InitializeComponent();
            //generates a list of bugs reported
            populateListBox();
            
        }
        /// <summary>
        /// this clears the text boxes ready for the next set of data
        /// </summary>
        public void cleartxtBoxes() 
        {
            txtId.Text = txtName.Text = txtAddress.Text = Cause.Text = "";
        }
        /// <summary>
        /// this checks the text boxes for data to avoid errors
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// this is the main function to push data from the form to the database
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="App"></param>
        /// <param name="Bug"></param>
        /// <param name="Cause"></param>
        /// <param name="commandString"></param>
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
                MessageBox.Show("Bug Reported, Thank you", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ID + " .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        ///<summary>
        ///this populates the list box with previously reported bugs
        ///</summary> 
        
        public void populateListBox()
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\buglist.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkInputs())
            {

                String commandString = "INSERT INTO bugList([Id], [App], [Bug], [Cause]) VALUES (@ID, @App, @Bug, @Cause)";


                insertRecord(txtId.Text, txtName.Text, txtAddress.Text, Cause.Text, commandString);
                populateListBox();
                cleartxtBoxes();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Whitebox f3 = new Whitebox();
            f3.Show();
            
        }

        private void Blackbox_FormClosed(object sender, FormClosedEventArgs e)
        {
            launcher lc = new launcher();
            lc.Show();
        }
    }
}
