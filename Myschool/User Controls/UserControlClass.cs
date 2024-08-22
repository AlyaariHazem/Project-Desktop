using Myschool.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Myschool.User_Controls
{
    public partial class UserControlClass : UserControl
    {
        private string hiddenClassID;

        public UserControlClass()
        {
            InitializeComponent();

            // Change header color for DataGridView
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Load stages into the ComboBox
            LoadStagesIntoComboBox();
        }

        private void LoadData()
        {
            using (var db = new DatabaseHelper())
            {
                string query = @"
                    SELECT c.ClassID, c.ClassName, s.StageName, s.Note, s.Active 
                    FROM Classes c 
                    INNER JOIN Stages s ON c.StageID = s.StageID";

                try
                {
                    DataTable dataTable = db.Select(query);

                    // Clear rows and columns
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    // Add columns
                    dataGridView1.Columns.Add("ClassID", "#");
                    dataGridView1.Columns.Add("ClassName", "اسم الصف");
                    dataGridView1.Columns.Add("StageName", "اسم المرحلة");
                    dataGridView1.Columns.Add("Note", "ملاحظة");
                    dataGridView1.Columns.Add("Active", "الحالة");

                    // Add Edit and Delete button columns
                    AddButtonColumn("Edit", "تعديل", "تعديل");
                    AddButtonColumn("Delete", "حـذف", "حـذف");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        dataGridView1.Rows.Add(
                            row["ClassID"],
                            row["ClassName"],
                            row["StageName"],
                            row["Note"],
                            row["Active"]
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading data: " + ex.Message);
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

        private void LoadStagesIntoComboBox()
        {
            using (var db = new DatabaseHelper())
            {
                string query = "SELECT StageID, StageName FROM Stages";
                try
                {
                    DataTable dataTable = db.Select(query);

                    comboBox1.Items.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Use an anonymous object for StageID and StageName
                        comboBox1.Items.Add(new { StageID = row["StageID"], StageName = row["StageName"].ToString() });
                    }

                    // Set the ComboBox to display StageName
                    comboBox1.DisplayMember = "StageName";
                    comboBox1.ValueMember = "StageID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading stages: " + ex.Message);
                }
            }
        }

        // Button click handler (Add or Edit)
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "حفظ")
            {
                AddClass();
            }
            else if (button1.Text == "تعديل")
            {
                SaveChanges();
            }
            else
            {
                AddClass();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string selectedClassID = dataGridView1.Rows[e.RowIndex].Cells["ClassID"].Value.ToString();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    button1.Text = "تعديل";
                    EditClass(selectedClassID);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    button1.Text = "حذف";
                    DeleteClass(selectedClassID);
                }
                else
                {
                    comboBox1.SelectedIndex = -1;
                    textBox2.Clear();
                    button1.Text = "إضافة+";
                }
            }
        }

        private void AddClass()
        {
            dynamic selectedItem = comboBox1.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Please select a stage.");
                return;
            }

            int stageID = selectedItem.StageID;
            string className = textBox2.Text;

            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show("Please enter class name.");
                return;
            }

            using (var db = new DatabaseHelper())
            {
                var values = new Dictionary<string, object>
                {
                    { "ClassName", className },
                    { "ClassYear", DateTime.Now.Year },
                    { "IsActive", 1 },
                    { "StageID", stageID }
                };

                try
                {
                    db.Insert("Classes", values);
                    MessageBox.Show("Record added successfully!");

                    // Refresh the data
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the class: " + ex.Message);
                }
            }
        }

        private void EditClass(string classID)
        {
            using (var db = new DatabaseHelper())
            {
                string query = @"
                    SELECT c.ClassID, c.ClassName, s.StageID, s.StageName 
                    FROM Classes c 
                    INNER JOIN Stages s ON c.StageID = s.StageID
                    WHERE c.ClassID = @ClassID";
                SqlParameter[] parameters = { new SqlParameter("@ClassID", classID) };

                try
                {
                    SqlDataReader reader = db.ExecuteReader(query, parameters);

                    if (reader.Read())
                    {
                        hiddenClassID = classID; // Store ClassID for updating
                        comboBox1.Text = reader["StageName"].ToString();
                        textBox2.Text = reader["ClassName"].ToString();
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

        private void SaveChanges()
        {
            dynamic selectedItem = comboBox1.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Please select a stage.");
                return;
            }

            int stageID = selectedItem.StageID;
            string className = textBox2.Text;

            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show("Please enter class name.");
                return;
            }

            using (var db = new DatabaseHelper())
            {
                string query = "UPDATE Classes SET ClassName = @ClassName, StageID = @StageID WHERE ClassID = @ClassID";
                SqlParameter[] parameters = {
                    new SqlParameter("@ClassName", className),
                    new SqlParameter("@StageID", stageID),
                    new SqlParameter("@ClassID", hiddenClassID)
                };

                try
                {
                    db.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Record updated successfully!");

                    // Refresh the data
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the class: " + ex.Message);
                }
            }
        }

        private void DeleteClass(string classID)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this class?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var db = new DatabaseHelper())
                {
                    try
                    {
                        db.Delete("Classes", $"ClassID = {classID}");

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

        private void UserControlClass_Load(object sender, EventArgs e)
        {
            // Load data when the control is loaded
            LoadData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click1(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            button1.Text = "إضافة+";
        }
    }
}
