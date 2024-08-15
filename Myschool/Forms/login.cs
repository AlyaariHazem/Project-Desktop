using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Myschool.Helpers;

namespace Myschool.Forms
{
    public partial class login : Form
    {
        private readonly DatabaseHelper _dbHelper;

        public login(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputUsername = textBox1.Text;
            string inputPassword = textBox2.Text;

            try
            {
                if (ValidateUser(inputUsername, inputPassword))
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private bool ValidateUser(string username, string password)
        {
            string query = "SELECT [Password] FROM Users WHERE UserName = @username";
            SqlParameter[] parameters = {
        new SqlParameter("@username", username)
    };

            using (var dr = _dbHelper.ExecuteReader(query, parameters))
            {
                if (dr.Read())
                {
                    return dr["Password"].ToString() == password;
                }
                return false;
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void login_Load(object sender, EventArgs e)
        {
            // Load logic if needed
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle list view selection changed event if needed 
        }
    }
}