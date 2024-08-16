using Myschool.Forms.StageClasses;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Myschool.User_Controls
{
    public partial class UserControlStageClass : UserControl
    {
        string connectionString = "Data source=HAZEM; initial catalog=SchoolDB; Integrated security=true;";

        public UserControlStageClass()
        {
            InitializeComponent();

            // Change header color for DataGridView
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            // Add Action column with a button
            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn();
            actionColumn.Name = "العملية";
            actionColumn.HeaderText = "Action";
            actionColumn.Text = "تعديل/حذف";
            actionColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(actionColumn);
        }


        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StageID, StageName, Note, Active FROM Stages";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);

                    // Add extra columns manually if needed
                    foreach (DataRow row in dataTable.Rows)
                    {
                        dataGridView1.Rows.Add(
                            row["StageID"],
                            row["StageName"],
                            "Class Info",    // Placeholder for class info
                            30,             // Placeholder for total students
                            row["Note"],
                            row["Active"],
                            true            // Placeholder for Active status
                        );
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

            string stageName = textBox1.Text;
            string note = textBox2.Text;

            if (string.IsNullOrEmpty(stageName))
            {
                MessageBox.Show("يجب أن تدخل بيانات", "حدث خطأً", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Stages (StageName, Note,Active,HireDate,YearID) VALUES (@stageName, @note,@active,@hireDate,@yearID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@stageName", stageName);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@active", 1);
                cmd.Parameters.AddWithValue("@hireDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@yearID", 1);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record added successfully!");

                    // Refresh data
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadUserControlDeleteEdite();
        }

        private void LoadUserControlDeleteEdite()
        {
            // Clear the panel before adding a new control
            panel2.Controls.Clear();
            panel2.Visible = true;

            UserControlDeleteEdite userControlDeleteEdite = new UserControlDeleteEdite();

            userControlDeleteEdite.Dock = DockStyle.Fill;

            panel2.Controls.Add(userControlDeleteEdite);
        }

        private void UserControlStageClass_Load_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
            // You can either call LoadData() here or leave it empty
            LoadData();
        }

        private void UserControlStageClass_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
