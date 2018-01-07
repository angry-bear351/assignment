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
            populateListBox();
        }
        public bool checkInputs()
        {
            bool rtnvalue = true;

            if (string.IsNullOrEmpty(commentBox.Text))
            {
                MessageBox.Show("Error: Please check your inputs");
                rtnvalue = false;
            }

            return (rtnvalue);

        }
        public void populateListBox()
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helen\Downloads\buglist.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");
            
            String selcmd = "SELECT  [Bug], [Cause], [Class], [Method], [Code Block], [Line Number], [Code Author] FROM bugList WHERE App = @app";

            SqlCommand mySqlCommand = new SqlCommand(selcmd, mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("@app", comboBox1.Text);
           
            
            

            try
            {
                mySqlConnection.Open();

                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                bugbox.Items.Clear();
                morebox.Items.Clear();

                while (mySqlDataReader.Read())
                {

                    bugbox.Items.Add("Bug: ");
                    bugbox.Items.Add( mySqlDataReader["Bug"]);
                    bugbox.Items.Add("Cause: ");
                    bugbox.Items.Add(mySqlDataReader["Cause"]);
                    bugbox.Items.Add("********************");
                    morebox.Items.Add("Class " + mySqlDataReader["Class"]);
                    morebox.Items.Add("Method " + mySqlDataReader["Method"]);
                    morebox.Items.Add("Code Block " + mySqlDataReader["Code Block"]);
                    morebox.Items.Add("Line Number " + mySqlDataReader["Line Number"]);
                    morebox.Items.Add("Code Author " + mySqlDataReader["Code Author"]);
                    morebox.Items.Add("********************");
                    


                }

            }
            catch (SqlException ex)
            {

                MessageBox.Show(" .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void insertRecord(String Fixed, String Comments, String Name, String Date, String Bug, String commandString)
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helen\Downloads\buglist.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");

            mySqlConnection.Open();
            try
            {
                SqlCommand cmdInsert = new SqlCommand(commandString, mySqlConnection);

                
                cmdInsert.Parameters.AddWithValue("@Fixed", Fixed);
                cmdInsert.Parameters.AddWithValue("@Comments", Comments);
                cmdInsert.Parameters.AddWithValue("@fName", Name);
                cmdInsert.Parameters.AddWithValue("@Date", Date);
                cmdInsert.Parameters.AddWithValue("@Bug", Bug);
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("Update Sucessful, Thank you", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(" .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void archiveRecord(int Id,String App, String Bug, String Name, String Fixed, String Date, String commandString)
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helen\Downloads\bugList.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");

            mySqlConnection.Open();
            try
            {
                SqlCommand cmdInsert = new SqlCommand(commandString, mySqlConnection);

                cmdInsert.Parameters.AddWithValue("@Id", Id);
                cmdInsert.Parameters.AddWithValue("@Fixed", Fixed);
                cmdInsert.Parameters.AddWithValue("@App", App);
                cmdInsert.Parameters.AddWithValue("@Fixedby", Name);
                cmdInsert.Parameters.AddWithValue("@Date", Date);
                cmdInsert.Parameters.AddWithValue("@Bug", Bug);
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("Archive Sucessful, Thank you", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(" .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void cleartxtBoxes()
        {
            commentBox.Text = fixedBox.Text = "";
        }

        private void Advancedbox_FormClosed(object sender, FormClosedEventArgs e)
        {
            launcher lc = new launcher();
            lc.Show();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInputs())
            {

                String commandString = "UPDATE bugList SET [fixed] = @Fixed, [Comments] = @Comments, [Fixed By] = @fName, [Date Fixed] = @Date  WHERE Bug = @Bug";

                String commString = "INSERT INTO Archive([Id], [App], [Bug], [Fixed By], [Date Fixed]) VALUES (@Id, @App, @Bug, @Fixedby, @Date)";
                insertRecord(fixedBox.Text, commentBox.Text, fixedByBox.Text, dateBox.Text, label6.Text, commandString);

                if (fixedBox.Text == "Y")
                {
                    int i = 0;
                    archiveRecord(i++,comboBox1.Text, label6.Text, fixedByBox.Text, fixedBox.Text, dateBox.Text, commString);
                }
                cleartxtBoxes();
            }
        }

        private void bugbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = bugbox.SelectedItem.ToString();
        }
    }
}
