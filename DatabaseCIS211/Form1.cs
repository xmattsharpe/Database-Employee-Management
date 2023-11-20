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
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;

            loadData();

        }


        public void loadData()
        {
            dbAdapter = new OleDbDataAdapter("SELECT Name FROM Employees", connection);
            dataTable = new DataTable();
            dbAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddInfo form2 = new AddInfo();
            form2.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            employeename = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            displayInfo(employeename);

        }

        private void button2_Click(object sender, EventArgs e)
        {
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

      


    }
}
