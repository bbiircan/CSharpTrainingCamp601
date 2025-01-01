using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace CSharpTrainingCamp601
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;port=5432;Database=CustomerDb;user Id=postgres;Password=root";

        void GetAllCustomers()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From Customers";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "insert into Customers (CustomerName, CustomerSurname, CustomerCity) values (@customerName, @customerSurname, @customerCity)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerName", customerName);
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);
            command.ExecuteNonQuery();
            MessageBox.Show("The addition was successful");
            connection.Close();
            GetAllCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCustomerId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Delete From Customers where CustomerId=@customerId";
            var command = new NpgsqlCommand(query,connection);
            command.Parameters.AddWithValue("@customerId", id);
            command.ExecuteNonQuery ();
            MessageBox.Show("The deletion has been completed");
            connection.Close();
            GetAllCustomers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;
            int id = int.Parse(txtCustomerId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Update Customers Set CustomerName=@customerName,CustomerSurname=@customerSurname,CustomerCity=@customerCity where CustomerId=@customerId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("customerName", customerName);
            command.Parameters.AddWithValue("customerSurname", customerSurname);
            command.Parameters.AddWithValue("customerCity", customerCity);
            command.Parameters.AddWithValue("customerId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("The update was successful");
            connection.Close();
            GetAllCustomers();
        }
    }
}
