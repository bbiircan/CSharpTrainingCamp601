using CSharpTrainingCamp601.Entities;
using CSharpTrainingCamp601.Services;
using System;
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
    }
}
