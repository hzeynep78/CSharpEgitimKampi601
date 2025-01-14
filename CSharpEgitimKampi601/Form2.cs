using Npgsql;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;port=5432;Database=Db601Customer;user Id=postgres; Password=12345";

        void GetAllCustomers()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From tbl_customer";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string city = txtCity.Text;

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Insert Into tbl_customer (customername,surname,city) values (@customername,@surname,@city)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customername", name);
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@city", city);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme İşlemi Başarılı");
            connection.Close();
            GetAllCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Delete From tbl_customer where customerid=@customerid";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerid", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Silme İşlemi Başarılı");
            connection.Close();
            GetAllCustomers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string city = txtCity.Text;
            int id = int.Parse(txtId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Update tbl_customer Set customername=@customername,surname=@surname,city=@city where customerid=@customerid";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerid", id);
            command.Parameters.AddWithValue("@customername", name);
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@city", city);
            command.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            connection.Close();
            GetAllCustomers();
        }
    }
}
