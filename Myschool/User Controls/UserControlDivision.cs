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
        }

        private void LoadData()
        {
            using (var db = new DatabaseHelper())
            {
                string query = @"
                    SELECT D.DivisionID, D.DivisionName,C.ClassName, C.IsActive
                    FROM Divisions D 
                    INNER JOIN Classes C ON D.DivisionID = C.ClassID";

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
                    dataGridView1.Columns.Add("IsActive", "الحالة");

                    // Add Edit and Delete button columns
                    AddButtonColumn("Edit", "تعديل", "تعديل");
                    AddButtonColumn("Delete", "حـذف", "حـذف");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        dataGridView1.Rows.Add(
                            row["DivisionID"],
                            row["DivisionName"],
                            row["ClassName"],
                            row["IsActive"]
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
            string divisionName = textBox1.Text;
            string note = textBox2.Text;

            if (string.IsNullOrEmpty(divisionName))
            {
                MessageBox.Show("يجب أن تدخل بيانات", "حدث خطأً", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddDivision(divisionName, note);
        }

        private void AddDivision(string divisionName, string note)
        {
            using (var db = new DatabaseHelper())
            {
                var values = new Dictionary<string, object>
                {
                    { "DivisionName", divisionName },
                    { "Note", note },
                    { "Active", 1 }
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
                string query = "SELECT DivisionName FROM Divisions WHERE DivisionID = @DivisionID";
                SqlParameter[] parameters = { new SqlParameter("@DivisionID", divisionID) };

                try
                {
                    SqlDataReader reader = db.ExecuteReader(query, parameters);

                    if (reader.Read())
                    {
                        hiddenDivisionID = divisionID; // Store DivisionID for later use in updating
                        textBox1.Text = reader["DivisionName"].ToString();
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

        private void SaveChanges()
        {
            string divisionName = textBox1.Text;
            string note = textBox2.Text;

            if (string.IsNullOrEmpty(divisionName))
            {
                MessageBox.Show("يجب أن تدخل بيانات", "حدث خطأً", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new DatabaseHelper())
            {
                string query = "UPDATE Divisions SET DivisionName = @DivisionName, Note = @Note WHERE DivisionID = @DivisionID";
                SqlParameter[] parameters = {
                    new SqlParameter("@DivisionName", divisionName),
                    new SqlParameter("@Note", note),
                    new SqlParameter("@DivisionID", hiddenDivisionID)
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
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string divisionID = dataGridView1.Rows[e.RowIndex].Cells["DivisionID"].Value.ToString();
                    EditDivision(divisionID);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    string divisionID = dataGridView1.Rows[e.RowIndex].Cells["DivisionID"].Value.ToString();
                    DeleteDivision(divisionID);
                }
            }
        }

        private void DeleteDivision(string divisionID)
        {
            using (var db = new DatabaseHelper())
            {
                string query = "DELETE FROM Divisions WHERE DivisionID = @DivisionID";
                SqlParameter[] parameters = { new SqlParameter("@DivisionID", divisionID) };

                try
                {
                    db.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Record deleted successfully!");

                    // Refresh the data
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the division: " + ex.Message);
                }
            }
        }

        private void UserControlDivision_Load(object sender, EventArgs e)
        {
            // Load data when the control is loaded
            LoadData();
        }
    }
}
