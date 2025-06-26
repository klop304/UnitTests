using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class MainDashboard : Form
    {
        private string _userPosition;
        public MainDashboard(string position)
        {
            
            InitializeComponent();
            _userPosition = position;
            MessageBox.Show($"Должность пользователя: {_userPosition}");
            SetButtonVisibility();
        }
        private void SetButtonVisibility()
        {
            btnManageUsers.Visible = false;
            btnClients.Visible = false;
            btnPolicies.Visible = false;

            if (_userPosition == "Admin")
            {
                btnManageUsers.Visible = true; // Кнопка "Пользователи" видима
                btnClients.Visible = false; // Кнопка "Клиенты" скрыта
                btnPolicies.Visible = false; // Кнопка "Договоры" скрыта
            }
            else if (_userPosition == "Agent")
            {
                btnManageUsers.Visible = false; // Кнопка "Пользователи" скрыта
                btnClients.Visible = true; // Кнопка "Клиенты" видима
                btnPolicies.Visible = true; // Кнопка "Договоры" видима
            }
        }
     

        private void btnClients_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            clientsForm.Show();
        }
        private void btnPolicies_Click(object sender, EventArgs e)
        {
            PoliciesForm policiesForm = new PoliciesForm();
            policiesForm.Show();    
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUsersForm manageUsers = new ManageUsersForm();
            manageUsers.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            SetButtonVisibility();
        }
    }
}
