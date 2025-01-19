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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost;port=5432;Database=Db601Customer;user Id=postgres; Password=12345";

        void EmployeeList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From tbl_employee";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
        void DepartmentList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From tbl_department";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DisplayMember = "departmentname";
            comboBox1.ValueMember = "departmentid";
            comboBox1.DataSource = dt;
            connection.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            EmployeeList();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DepartmentList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string employeeName = txtName.Text;
            string employeeSurname = txtSurname.Text;
            decimal employeeSalary = decimal.Parse(txtSalary.Text);
            int departmentId = int.Parse(comboBox1.SelectedValue.ToString());

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "insert into tbl_employee (EmployeeName, EmployeeSurname, EmployeeSalary, Departmentid) values (@employeeName, @employeeSurname, @employeeSalary, @departmentid)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeeName", employeeName);
            command.Parameters.AddWithValue("@employeeSurname", employeeSurname);
            command.Parameters.AddWithValue("@employeeSalary", employeeSalary);
            command.Parameters.AddWithValue("@departmentid", departmentId);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme işlemi başarılı");
            connection.Close();
            EmployeeList();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Delete from tbl_employee where employeeId=@employeeId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeeId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Silme işlemi başarılı");
            connection.Close();
            EmployeeList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string employeeName = txtName.Text;
            string employeeSurname = txtSurname.Text;
            decimal employeeSalary = decimal.Parse(txtSalary.Text);
            int departmentId = int.Parse(comboBox1.SelectedValue.ToString());

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Update tbl_employee set EmployeeName=@employeeName, EmployeeSurname=@employeeSurname, EmployeeSalary=@employeeSalary, Departmentid=@departmentid where employeeId=@employeeId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeeName", employeeName);
            command.Parameters.AddWithValue("@employeeSurname", employeeSurname);
            command.Parameters.AddWithValue("@employeeSalary", employeeSalary);
            command.Parameters.AddWithValue("@departmentid", departmentId);
            command.Parameters.AddWithValue("@employeeId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Güncelleme işlemi başarılı");
            connection.Close();
            EmployeeList();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From tbl_employee where employeeId=@employeeId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeeId", id);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
    }
}
