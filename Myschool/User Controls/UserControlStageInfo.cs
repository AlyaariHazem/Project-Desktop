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

                    // Clear existing rows before adding new data
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear(); // Clear existing columns

                    // Add columns explicitly
                    dataGridView1.Columns.Add("StageID", "#");
                    dataGridView1.Columns.Add("StageName", "اسم المرحلة");
                    dataGridView1.Columns.Add("ClassInfo", "الصفوف");
                    dataGridView1.Columns.Add("TotalStudents", "إجمالي الطلاب");
                    dataGridView1.Columns.Add("Note", "ملاحظة");
                    dataGridView1.Columns.Add("Active", "الحالة");

                    // Add Edit and Delete buttons 
                    DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
                    editColumn.Name = "Edit";
                    editColumn.HeaderText = "تعديل";
                    editColumn.Text = "تعديل";
                    editColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(editColumn);

                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                    deleteColumn.Name = "Delete";
                    deleteColumn.HeaderText = "حـذف";
                    deleteColumn.Text = "حـذف";
                    deleteColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(deleteColumn);

                    // Populate rows with data
                    foreach (DataRow row in dataTable.Rows)
                    {
                        dataGridView1.Rows.Add(
                            row["StageID"],
                            row["StageName"],
                            "Class Info", // Placeholder for class info
                            30, // Placeholder for total students
                            row["Note"],
                            row["Active"]
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
                string query = "INSERT INTO Stages (StageName, Note, Active, HireDate, YearID) VALUES (@stageName, @note, @active, @hireDate, @yearID)";
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Ensure the StageID column exists
                string selectedStageID = dataGridView1.Rows[e.RowIndex].Cells["StageID"].Value.ToString();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    // Open the edit form and pass the selected StageID
                    EditStage(selectedStageID);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    // Prompt to confirm and delete the selected record
                    DeleteStage(selectedStageID);
                }
            }
        }


        private void EditStage(string stageID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StageName, Note FROM Stages WHERE StageID = @stageID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@stageID", stageID);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Populate the text boxes with the data from the database
                        textBox1.Text = reader["StageName"].ToString();
                        textBox2.Text = reader["Note"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Record not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }


        private void DeleteStage(string stageID)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this stage?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Stages WHERE StageID = @stageID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@stageID", stageID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        
                        // Refresh data
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void UserControlStageClass_Load_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
            // Load data when the control is loaded
            LoadData();
        }

        private void UserControlStageClass_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
