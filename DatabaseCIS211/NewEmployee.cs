using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseCIS211
{
    public partial class NewEmployee : Form
    {

         OleDbConnection connection = new OleDbConnection();
        
              private DataTable dt;
        private Form1 form1;
        // I dont find the company time and promotion eligibility necessary for a new hire so I dont include them here.
        public NewEmployee(Form1 current)
        {
             InitializeComponent();
               connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\matth\OneDrive\Documents\CIS211Database.accdb";
            form1 = current;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            using (OleDbCommand command = new OleDbCommand())
            {

                command.Connection = connection;


                try
                {
                  string name = textBox1.Text;
                    command.Parameters.AddWithValue("Name", textBox1.Text);
                     command.Parameters.AddWithValue("PayRate", textBox2.Text);
                         command.Parameters.AddWithValue("Title", textBox3.Text);
                             command.Parameters.AddWithValue("EmpID", textBox4.Text);
                                  command.Parameters.AddWithValue("Employeebank", textBox5.Text);
    
                    command.CommandText = $"INSERT INTO Employees (Name, PayRate, Title, EmpID, Employeebank) VALUES (@Name, @PayRate, @Title, @EmpID, @Employeebank)";

                          command.ExecuteNonQuery();
                              pictureBox1.Visible = true;


                                      MessageBox.Show($"{name} was successfully added");

                   
                    int updatedCount = form1.loadData();

                }

                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();

            }
        }
    }
}
