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
    public partial class Form1 : Form
    {
        SqlConnection mySqlConnection;
        public Form1()
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


        public void insertRecord(String ID, String name, String address, String commandString)
        {

            try
            {
                SqlCommand cmdInsert = new SqlCommand(commandString, mySqlConnection);

                cmdInsert.Parameters.AddWithValue("@ID", ID);
                cmdInsert.Parameters.AddWithValue("@name", name);
                cmdInsert.Parameters.AddWithValue("@address", address);
                cmdInsert.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ID + " .." + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void populateListBox()
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gareth.DESKTOP-V17I0IV\Documents\Db1.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");

            String selcmd = "SELECT [studentId], [studentName], [studentAddress] FROM tblstudent ORDER BY [studentName]";

            SqlCommand mySqlCommand = new SqlCommand(selcmd, mySqlConnection);

            try
            {
                mySqlConnection.Open();

                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                lbxstudents.Items.Clear();

                while (mySqlDataReader.Read())
                {

                    lbxstudents.Items.Add(mySqlDataReader["studentId"] + " " +
                           mySqlDataReader["studentName"] + mySqlDataReader["studentAddress"]);


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

                String commandString = "INSERT INTO tblstudent([studentId], [studentName], [studentAddress]) VALUES (@ID, @name, @address)";

                insertRecord(txtId.Text, txtName.Text, txtAddress.Text, commandString);
                populateListBox();
                cleartxtBoxes();
            }

        }
    }
}
