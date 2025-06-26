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
    public partial class PoliciesForm : Form
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-URNQAK1\SQLEXPRESS;Initial Catalog=crm;Integrated Security=True;TrustServerCertificate=True");
        public PoliciesForm()
        {
            InitializeComponent();
            LoadPolicies();
        }
        private bool ValidatePolicies()
        {
            if (string.IsNullOrWhiteSpace(txtPoliciesId.Text))
            {
                MessageBox.Show("Введите идентификатор договора!");
                txtPoliciesId.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtClient.Text))
            {
                MessageBox.Show("Введите идентификатор клиента!");
                txtClient.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Введите сумму договора!");
                txtAmount.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Введите статус!");
                txtStatus.Focus();
                return false;
            }
            return true;
        }
        private void LoadPolicies()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM insurancepolicies", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewPolicies.DataSource = dt;

            }
            catch
            {
                MessageBox.Show("Ошибка загрузки");
            }

            finally
            {
                connection.Close();
            }
        }
        

        private void btnAddPolicies_Click(object sender, EventArgs e)
        {
            if (!ValidatePolicies())
            {
                return;
            }
            string query = "INSERT INTO insurancepolicies(policy_id,client_id,policy_number,insurance_type,start_date,end_date,summa_police,status) " +
                "VALUES(@policy_id,@client_id,@policy_number,@insurance_type,@start_date,@end_date,@summa_police,@status)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@policy_id", txtPoliciesId.Text);
            cmd.Parameters.AddWithValue("@client_id", txtClient.Text);
            cmd.Parameters.AddWithValue("@policy_number", txtNumber.Text);
            cmd.Parameters.AddWithValue("@insurance_type", txtType.Text);
            cmd.Parameters.AddWithValue("@start_date", dateTimePickerStart.Value);
            cmd.Parameters.AddWithValue("@end_date", dateTimePickerEnd.Value);
            cmd.Parameters.AddWithValue("@summa_police", txtAmount.Text);
            cmd.Parameters.AddWithValue("@status", txtStatus.Text);
            try
            {
             connection.Open();
             cmd.ExecuteNonQuery();
             MessageBox.Show("Договор создан!");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении договора " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void txtFilterStatus_TextChanged(object sender, EventArgs e)
        {
            (dataGridViewPolicies.DataSource as DataTable).DefaultView.RowFilter = $"status LIKE '%{txtFilterStatus.Text}%'";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }  
}
