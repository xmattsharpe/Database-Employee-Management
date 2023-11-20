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
        private OleDbConnection connection = new OleDbConnection();

        public AddInfo()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\matth\OneDrive\Documents\CIS211Database.accdb";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
          
            command.CommandText = $"UPDATE Employees SET CompanyTime = '{textBox2.Text}', PromotionEligibility = '{textBox3.Text}', EmployeeBank = '{textBox4.Text}' WHERE Name = '{Form1.employeename}'";
            command.ExecuteNonQuery();

            MessageBox.Show("Data Saved", "Successful Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
