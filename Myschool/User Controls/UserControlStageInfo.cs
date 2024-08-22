using Myschool.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Myschool.User_Controls
{
    public partial class UserControlStageClass : UserControl
    {
        private string hiddenStageID;

        public UserControlStageClass()
        {
            InitializeComponent();

            // Set DataGridView header styles
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        // Method to load data from the database into DataGridView
        private void LoadData()
        {
            using (var db = new DatabaseHelper())
            {
                string query = "SELECT StageID, StageName, Note, Active FROM Stages";
                try
                {
                    DataTable dataTable = db.Select(query);

                    // Clear rows and columns
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    // Add columns
                    dataGridView1.Columns.Add("StageID", "#");
                    dataGridView1.Columns.Add("StageName", "اسم المرحلة");
                    dataGridView1.Columns.Add("ClassInfo", "الصفوف");
                    dataGridView1.Columns.Add("TotalStudents", "إجمالي الطلاب");
                    dataGridView1.Columns.Add("Note", "ملاحظة");
                    dataGridView1.Columns.Add("Active", "الحالة");

                    // Add Edit and Delete button columns
                    AddButtonColumn("Edit", "تعديل", "تعديل");
                    AddButtonColumn("Delete", "حـذف", "حـذف");

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

        // Helper method to add button columns for Edit and Delete
        private void AddButtonColumn(string name, string headerText, string buttonText)
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = name,
                HeaderText = headerText,
                Text = buttonText,
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(buttonColumn);
        }

        // Button click handler (Add or Edit)
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "حفظ")
            {
                AddStage();
            }
            else if (button1.Text == "تعديل")
            {
                SaveChanges();
            }
            else
            {
                AddStage();
            }
        }

        // Method to add a new stage
        private void AddStage()
        {
            string stageName = textBox1.Text;
            string note = textBox2.Text;

            if (string.IsNullOrEmpty(stageName))
            {
                MessageBox.Show("يجب أن تدخل بيانات", "حدث خطأً", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new DatabaseHelper())
            {
                var values = new Dictionary<string, object>
                {
                    { "StageName", stageName },
                    { "Note", note },
                    { "Active", 1 },
                    { "HireDate", DateTime.Now },
                    { "YearID", 1 } // Hardcoded for now, you can replace it with the actual YearID if necessary
                };

                try
                {
                    db.Insert("Stages", values);
                    MessageBox.Show("Record added successfully!");

                    // Refresh the data
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        // Method to edit a stage (load data into text fields)
        private void EditStage(string stageID)
        {
            using (var db = new DatabaseHelper())
            {
                string query = "SELECT StageName, Note FROM Stages WHERE StageID = @stageID";
                SqlParameter[] parameters = { new SqlParameter("@stageID", stageID) };

                try
                {
                    SqlDataReader reader = db.ExecuteReader(query, parameters);

                    if (reader.Read())
                    {
                        hiddenStageID = stageID; // Store StageID for later use in updating
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

        // Method to save changes to an existing stage
        private void SaveChanges()
        {
            string stageName = textBox1.Text;
            string note = textBox2.Text;

            if (string.IsNullOrEmpty(stageName))
            {
                MessageBox.Show("يجب أن تدخل بيانات", "حدث خطأً", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new DatabaseHelper())
            {
                var values = new Dictionary<string, object>
                {
                    { "StageName", stageName },
                    { "Note", note }
                };

                try
                {
                    db.Update("Stages", values, $"StageID = {hiddenStageID}");
                    MessageBox.Show("Record updated successfully!");

                    // Refresh the data
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        // Method to delete a stage
        private void DeleteStage(string stageID)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this stage?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var db = new DatabaseHelper())
                {
                    try
                    {
                        db.Delete("Stages", $"StageID = {stageID}");

                        // Refresh the data
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        // Event handler for DataGridView cell clicks
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string selectedStageID = dataGridView1.Rows[e.RowIndex].Cells["StageID"].Value.ToString();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    button1.Text = "تعديل";
                    EditStage(selectedStageID);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    button1.Text = "حذف";
                    DeleteStage(selectedStageID);
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    button1.Text = "إضافة+";
                    AddStage();
                }
            }
        }
        private void UserControlStageClass_Click_1(object sender, EventArgs e)
        {
            // Add your custom logic here
        }

        // Event handler for loading the UserControl
        private void UserControlStageClass_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Text = "إضافة+";
        }
    }
}
