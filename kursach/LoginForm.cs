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
using System.Windows.Input;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;

namespace kursach
{
    public partial class LoginForm : Form
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-URNQAK1\SQLEXPRESS;Initial Catalog=crm;Integrated Security=True;TrustServerCertificate=True");
        public LoginForm()
        {
            InitializeComponent();
        }

        

        private bool ValidateLogin()
        {
            if (string.IsNullOrWhiteSpace(txtBoxLogin.Text))
            {
                MessageBox.Show("Введите логин!");
                txtBoxLogin.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxPassword.Text))
            {
                MessageBox.Show("Введите пароль!");
                txtBoxPassword.Focus();
                return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateLogin())
            {
                return;
            }
            string login = txtBoxLogin.Text;
            string password = txtBoxPassword.Text;
            
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT position FROM users WHERE login=@login AND password=@password", connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                string position = (string)command.ExecuteScalar();
                if (position != null)
                {
                    MessageBox.Show($"Добро пожаловать!");
                    MainDashboard dashboard = new MainDashboard(position);
                    dashboard.Show();
                    this.Hide();
                }
                
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        
    }
}
