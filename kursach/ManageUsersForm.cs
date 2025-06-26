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
using System.CodeDom;
namespace kursach
{
    public partial class ManageUsersForm : Form
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-URNQAK1\SQLEXPRESS;Initial Catalog=crm;Integrated Security=True;TrustServerCertificate=True");
        public ManageUsersForm()
        {
            InitializeComponent();
            LoadUsers();
        }
        private bool ValidateUsers()
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Введите идентификатор пользователя!");
                txtUserID.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Введите логин пользователя!");
                txtLogin.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите пароль пользователя!");
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Введите должность пользователя!");
                txtPosition.Focus();
                return false;
            }
            return true;
        }
        private void LoadUsers()
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM users", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewUsers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            if (!ValidateUsers())
            {
                return;
            }
            string query = "INSERT INTO users(user_id,login,password,position)" + "VALUES(@user_id,@login,@password,@position)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@user_id", txtUserID.Text);
            command.Parameters.AddWithValue("@login", txtLogin.Text);
            command.Parameters.AddWithValue("@password", txtPassword.Text);
            command.Parameters.AddWithValue("@position", txtPosition.Text);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Пользователь добавлен!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
