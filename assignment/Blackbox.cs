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
    public partial class Blackbox : Form
    {
        SqlConnection mySqlConnection;
        public Blackbox()
        {
            InitializeComponent();
            //generates a list of bugs reported
            populateListBox();
            
        }
        
        public void cleartxtBoxes() 
        {
            txtId.Text = txtName.Text = txtAddress.Text = Cause.Text = "";
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
                MessageBox.Show("Bug Reported, Thank you", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ID + " .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        
        
        public void populateListBox()
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helen\Downloads\buglist.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");

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
