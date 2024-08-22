using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Myschool.Helpers;

namespace Myschool.User_Controls
{
    public partial class UserControlDivision : UserControl
    {
        private string hiddenDivisionID;

        public UserControlDivision()
        {
            InitializeComponent();

            // Change header color for DataGridView
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Load divisions into the DataGridView
            LoadData();
            LoadClassesIntoComboBox();
        }

        private void LoadData()
        {
            using (var db = new DatabaseHelper())
            {
                string query = @"
                    SELECT D.DivisionID, D.DivisionName, C.ClassName, C.IsActive
                    FROM Divisions D 
                    INNER JOIN Classes C ON D.ClassID = C.ClassID";

                try
                {
                    DataTable dataTable = db.Select(query);

                    // Clear rows and columns
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    // Add columns
                    dataGridView1.Columns.Add("DivisionID", "#");
                    dataGridView1.Columns.Add("DivisionName", "اسم الشعبة");
                    dataGridView1.Columns.Add("ClassName", "اسم الصـف");
                    dataGridView1.Columns.Add("Students", "إجمالي الطلاب");
                    dataGridView1.Columns.Add("Note", "الملاحظة");

                    // Add Edit and Delete button columns
                    AddButtonColumn("Edit", "تعديل", "تعديل");
                    AddButtonColumn("Delete", "حـذف", "حـذف");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        dataGridView1.Rows.Add(
                            row["DivisionID"],
                            row["DivisionName"],
                            row["ClassName"],
                            0, // Ideally this should be dynamically calculated
                            "لا يوجد ملاحظة"
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "حفظ")
            {
                AddDivision();
            }
            else if (button1.Text == "تعديل")
            {
                SaveChanges();
            }
            else
            {
                AddDivision();
            }
        }

        private void AddDivision()
        {
            var selectedItem = comboBox1.SelectedItem as ComboBoxItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Please select a class.");
                return;
            }

            int classID = selectedItem.ClassID;
            string divisionName = textBox2.Text;

            if (string.IsNullOrEmpty(divisionName))
            {
                MessageBox.Show("Please enter Division name.");
                return;
            }

            using (var db = new DatabaseHelper())
            {
                var values = new Dictionary<string, object>
                {
                    { "DivisionName", divisionName },
                    { "ClassID", classID }
                };

                try
                {
                    db.Insert("Divisions", values);
                    MessageBox.Show("Record added successfully!");

                    // Refresh the data
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding the division: " + ex.Message);
                }
            }
        }

        private void EditDivision(string divisionID)
        {
            using (var db = new DatabaseHelper())
            {
                string query = @"
                    SELECT D.DivisionID, D.DivisionName, C.ClassID, C.ClassName
                    FROM Divisions D 
                    INNER JOIN Classes C ON D.ClassID = C.ClassID
                    WHERE D.DivisionID = @DivisionID";
                SqlParameter[] parameters = { new SqlParameter("@DivisionID", divisionID) };

                try
                {
                    using (SqlDataReader reader = db.ExecuteReader(query, parameters))
                    {
                        if (reader.Read())
                        {
                            hiddenDivisionID = divisionID; 
                            comboBox1.Text = reader["DivisionName"].ToString(); 
                            textBox2.Text = reader["ClassName"].ToString(); 
                        }
                        else
                        {
                            MessageBox.Show("Record not found.");
                        }
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
            var selectedItem = comboBox1.SelectedItem as ComboBoxItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Please select a Class.");
                return;
            }

            int classID = selectedItem.ClassID;
            string divisionName = textBox2.Text;

            if (string.IsNullOrEmpty(divisionName))
            {
                MessageBox.Show("Please enter Division name.");
                return;
            }

            using (var db = new DatabaseHelper())
            {
                var values = new Dictionary<string, object>
        {
            { "DivisionName", divisionName },
            { "ClassID", classID }
        };

                try
                {
                    db.Update("Divisions", values, $"DivisionID = {hiddenDivisionID}");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string selectedDivisionID = dataGridView1.Rows[e.RowIndex].Cells["DivisionID"].Value.ToString();

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    button1.Text = "تعديل";
                    EditDivision(selectedDivisionID);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    button1.Text = "حذف";
                    DeleteDivision(selectedDivisionID);
                }
                else
                {
                    comboBox1.SelectedIndex = -1;
                    textBox2.Clear();
                    button1.Text = "إضافة";
                }
            }
        }

        private void DeleteDivision(string divisionID)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this division?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var db = new DatabaseHelper())
                {
                    try
                    {
                        db.Delete("Divisions", $"DivisionID = {divisionID}");

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

        private void LoadClassesIntoComboBox()
        {
            using (var db = new DatabaseHelper())
            {
                string query = "SELECT ClassID, ClassName FROM Classes";
                try
                {
                    DataTable dataTable = db.Select(query);

                    comboBox1.Items.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        comboBox1.Items.Add(new ComboBoxItem { ClassID = (int)row["ClassID"], ClassName = row["ClassName"].ToString() });
                    }

                    // Set the ComboBox to display ClassName
                    comboBox1.DisplayMember = "ClassName";
                    comboBox1.ValueMember = "ClassID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading Classes: " + ex.Message);
                }
            }
        }

        private void UserControlDivision_Load(object sender, EventArgs e)
        {
            // Load data when the control is loaded
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            button1.Text = "إضافة";
            LoadData();
        }
    }

    // Define ComboBoxItem class
    public class ComboBoxItem
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }

        public override string ToString()
        {
            return ClassName;
        }
    }
}
