﻿using System.Data.SqlClient;
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
        public void insertRecord(String Fixed, String Comments, String App, String commandString)
        {
            mySqlConnection =
                 new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helen\Downloads\buglist.mdf;Integrated Security=True;MultipleActiveResultSets=true;Connect Timeout=30");

            mySqlConnection.Open();
            try
            {
                SqlCommand cmdInsert = new SqlCommand(commandString, mySqlConnection);

                cmdInsert.Parameters.AddWithValue("@Fixed", Fixed);
                cmdInsert.Parameters.AddWithValue("@Comments", Comments);
                cmdInsert.Parameters.AddWithValue("@App", App);
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("Update Sucessful, Thank you", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            label3.Text = comboBox1.SelectedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInputs())
            {

                String commandString = "UPDATE bugList SET [fixed] = @Fixed, [Comments] = @Comments  WHERE App = @App";


                insertRecord(fixedBox.Text, commentBox.Text, label3.Text, commandString);
                cleartxtBoxes();
            }
        }
    }
}
