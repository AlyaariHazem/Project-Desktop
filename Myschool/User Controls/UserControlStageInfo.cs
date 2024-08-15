using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Myschool.User_Controls
{
    public partial class UserControlStageClass : UserControl
    {
        public UserControlStageClass()
        {
            InitializeComponent();
        }

        private void UserControlStageClass_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Connection with Database
            string connectionString = "Data source=HAZEM; initial catalog=SchoolDB; Integrated security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StageName,  Note FROM Stage";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    // Clear existing items if using a ListBox or similar control
                    // listBox1.Items.Clear(); 

                    while (dr.Read())
                    {
                        // Assuming you have TextBox or other controls to display data
                        textBox1.Text = dr["StageName"].ToString();
                        textBox2.Text = dr["Note"].ToString();
                        

                        // Or if using a ListBox, DataGridView, etc.
                        // listBox1.Items.Add(dr["StageName"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add new record to the database
            string stageName = textBox1.Text;
            string note = textBox2.Text;

            string connectionString = "Data source=HAZEM; initial catalog=SchoolDB; Integrated security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Stage (StageName, Note) VALUES (@stageName, @note)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@stageName", stageName);
                cmd.Parameters.AddWithValue("@note", note);
                
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record added successfully!");

                    // Refresh data if needed
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
