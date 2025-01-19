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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSharpEgitimKampi601
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost;port=5432;Database=Db601Customer;user Id=postgres; Password=12345";

        void DepartmentList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From tbl_department";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            DepartmentList();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From tbl_department where departmentid=@departmentid";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentid", id);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "insert into tbl_department (departmentname) values (@departmentname)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("departmentname", name);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme işlemi başarılı");
            connection.Close();
            DepartmentList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Update tbl_department set departmentname=@departmentname where departmentid=@departmentid";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentid", id);
            command.Parameters.AddWithValue("departmentname", name);
            command.ExecuteNonQuery();
            MessageBox.Show("Güncelleme işlemi başarılı");
            connection.Close();
            DepartmentList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Delete from tbl_department where departmentid=@departmentid";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentid", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Silme işlemi başarılı");
            connection.Close();
            DepartmentList();
        }
    }
}
