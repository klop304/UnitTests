using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace kursach
{
    public partial class ClientsForm : Form
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-URNQAK1\SQLEXPRESS;Initial Catalog=crm;Integrated Security=True;TrustServerCertificate=True");
        public ClientsForm()
        {
            InitializeComponent();
            LoadClients();
        }
        private bool ValidateClients()
        {
            if (string.IsNullOrWhiteSpace(txtClientId.Text))
            {
                MessageBox.Show("Введите идентификатор клиента!");
                txtClientId.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО клиента!");
                txtFullName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassportData.Text))
            {
                MessageBox.Show("Введите паспортные данные клиента!");
                txtFullName.Focus();
                return false;
            }
            return true;
        }
        private void LoadClients()
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM clients", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewClients.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
            connection.Close();
        }
        
        private void btnAddClients_Click(object sender, EventArgs e)
        {
            if (!ValidateClients())
            {
                return;
            }
            string query = "INSERT INTO clients(client_id,full_name,phone,email,address,passport_data) " + "VALUES(@client_id,@full_name,@phone,@email,@address,@passport_data)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@client_id", txtClientId.Text);
            command.Parameters.AddWithValue("@full_name", txtFullName.Text);
            command.Parameters.AddWithValue("@phone", txtPhone.Text);
            command.Parameters.AddWithValue("@email", txtEmail.Text);
            command.Parameters.AddWithValue("@address", txtAddress.Text);
            command.Parameters.AddWithValue("@passport_data", txtPassportData.Text);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Клиент добавлен");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            connection.Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            (dataGridViewClients.DataSource as DataTable).DefaultView.RowFilter = $"full_name LIKE '%{txtFilter.Text}%'";
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "crmDataSet.clients". При необходимости она может быть перемещена или удалена.
            ;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
