using Myschool.Helpers;

namespace Myschool.Forms
{
    public partial class Welcome : Form
    {
        private DatabaseHelper dbHelper; // Declare a DatabaseHelper instance

        public Welcome()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Instantiate the DatabaseHelper
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Pass the dbHelper instance to the login form
            login loginForm = new login(dbHelper);
            loginForm.Show();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
