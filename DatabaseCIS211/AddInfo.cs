using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DatabaseCIS211
{
    public partial class AddInfo : Form
    {

        // NOTE ** YOU MUST PICK AN EMPLOYEE WHO DOES ---NOT--- HAVE THE LATTER 3 FIELDS ALREADY FILLED OUT 
        // For grading purposes, "Kayla Owens" will work if you pick to add additional information


        private OleDbConnection connection = new OleDbConnection();

        public AddInfo()
        {
            InitializeComponent();
              connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\matth\OneDrive\Documents\CIS211Database.accdb";
            try
            {

                label1.Text += $"{Form1.employeename}";

                if(Form1.employeename == null || Form1.employeename == "")
                {
                    MessageBox.Show("You have not selected a user to move forward", "Select a user", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch(Exception)
            {
               
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // command.CommandText = $"UPDATE Employees SET CompanyTime = '{textBox2.Text}', PromotionEligibility = '{textBox3.Text}', EmployeeBank = '{textBox4.Text}' WHERE Name = '{Form1.employeename}'";

            try
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"UPDATE Employees SET CompanyTime = ?, PromotionEligibility = ?, EmployeeBank = ? WHERE NAME = ?";


                    command.Parameters.AddWithValue("CompanyTime", textBox2.Text);
                    command.Parameters.AddWithValue("PromotionEligibility", textBox3.Text);
                    command.Parameters.AddWithValue("EmployeeBank", textBox3.Text);
                    command.Parameters.AddWithValue("Name", Form1.employeename);

                    command.ExecuteNonQuery();





                    MessageBox.Show("Data Saved", "Successful Entry", MessageBoxButtons.OK);

                    this.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
             textBox3.Clear();
               textBox4.Clear();
        }
    }
}
