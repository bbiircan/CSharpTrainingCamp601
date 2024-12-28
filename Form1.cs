using CSharpTrainingCamp601.Entities;
using CSharpTrainingCamp601.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSharpTrainingCamp601
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerOperations customerOperations = new CustomerOperations();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerCity = txtCustomerCity.Text,
                Balance = decimal.Parse(txtBalance.Text),
                TotalShopping = int.Parse(txtTotalShopping.Text),
            };

            customerOperations.AddCustomer(customer);
            MessageBox.Show("Customer successfully added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();
            dataGridView1.DataSource = customers;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("The customer has been deleted.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            var updateCustomer = new Customer()
            {
                CustomerId = id,
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerCity = txtCustomerCity.Text,
                Balance = decimal.Parse(txtBalance.Text),
                TotalShopping = int.Parse(txtTotalShopping.Text)
            };
            customerOperations.UpdateCustomer(updateCustomer);
            MessageBox.Show("The customer has been updated.");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            Customer customers = customerOperations.GetCustomerById(id);
            dataGridView1.DataSource= new List<Customer>() { customers };
        }
    }
}
