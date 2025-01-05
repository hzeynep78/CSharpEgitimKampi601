using CSharpEgitimKampi601.Entities;
using CSharpEgitimKampi601.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
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
                CustomerName = txtName.Text,
                CustomerSurname = txtSurname.Text,
                CustomerBalance = decimal.Parse(txtBalance.Text),
                CustomerCity = txtCity.Text,
                CustomerShoppingCount = int.Parse(txtShoppingCount.Text),
            };

            customerOperations.AddCustomer(customer);
            MessageBox.Show("Ekleme Başarılı");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();
            dataGridView1.DataSource = customers;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId = txtId.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Silme Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            var updateCustomer = new Customer()
            {
                CustomerName = txtName.Text,
                CustomerSurname = txtSurname.Text,
                CustomerBalance = decimal.Parse(txtBalance.Text),
                CustomerCity = txtCity.Text,
                CustomerShoppingCount = int.Parse(txtShoppingCount.Text),
                CustomerId = txtId.Text
            };
            customerOperations.UpdateCustomer(updateCustomer);
            MessageBox.Show("Güncelleme Başarılı");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            Customer customer = customerOperations.GetCustomerById(id);
            dataGridView1.DataSource= new List<Customer> { customer };
        }
    }
}
