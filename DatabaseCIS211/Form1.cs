using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseCIS211
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();

          private DataTable dataTable;
            private OleDbDataAdapter dbAdapter;
                 public static string employeename;

    

        public Form1()
        {
            InitializeComponent();

            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\matth\OneDrive\Documents\CIS211Database.accdb";
                 connection.Open();
            using (OleDbCommand command = new OleDbCommand())
            {
                command.Connection = connection;

                loadData();
            }
        }


        public void loadData()
        {
            // method to call when the form loads to populate DGV with Names

            dbAdapter = new OleDbDataAdapter("SELECT Name FROM Employees", connection);
              dataTable = new DataTable();
                 dbAdapter.Fill(dataTable);
                     dataGridView1.DataSource = dataTable;

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // additional information button to open a new form

            try
            {
                AddInfo form2 = new AddInfo();
                form2.ShowDialog();

                if(employeename == null || employeename == "")
                {
                    form2.Close();
                }
            }
            catch (Exception)
            {

            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DGV click event to show exisitng information about the user who's index clicked 

            employeename = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                 displayInfo(employeename);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // back button to switch the datatable from one specific emoloyee back to the general DT view

            dataGridView1.DataSource = dataTable;
        }

        private void displayInfo(string employeeName)
        {

              string query = $"SELECT * FROM Employees WHERE Name = '{employeeName}'";

                 string qConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\matth\OneDrive\Documents\CIS211Database.accdb";
                      OleDbConnection queryconnection = new OleDbConnection(qConnection);

             
                          OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                               DataTable dt = new DataTable();
                                  adapter.Fill(dt);
                                      dataGridView1.DataSource = dt;
                    
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // search event to prevent scrolling 


            string searchName = textBox1.Text.ToUpper();

            try
            {
                string q = $"SELECT * FROM Employees WHERE Name = '{searchName}'";

                    OleDbCommand com = new OleDbCommand();

     
                       string qConnections = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\matth\OneDrive\Documents\CIS211Database.accdb";

                           OleDbConnection queryconnection = new OleDbConnection(qConnections);

                              OleDbDataAdapter adapt = new OleDbDataAdapter(q, connection);
                                 DataTable newer = new DataTable();
                                     adapt.Fill(newer);
                                         dataGridView1.DataSource = newer;

                     if(newer.Rows.Count ==0) {
                   
                       MessageBox.Show("Employee not found");
                     }

                     else{

                    textBox1.Clear();
                    MessageBox.Show("Employee found");
                     }
            }

            catch(Exception ex) {

                MessageBox.Show(ex.Message);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewEmployee newemp = new NewEmployee();
            newemp.ShowDialog();


        }
    }
}
