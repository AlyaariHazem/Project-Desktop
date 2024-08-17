using Myschool.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Myschool.User_Controls
{
    public partial class UserControlClass : UserControl
    {
        private string connectionString = "Data source=DESKTOP-I31TB94; initial catalog=SchoolDB; Integrated security=true;";

        public UserControlClass()
        {
            InitializeComponent();

            // Change header color for DataGridView
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Load stages into the ComboBox
            LoadStagesIntoComboBox();

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
            using (var db = new DatabaseHelper())
            {
                string query = @"
                    SELECT c.ClassID, c.ClassName, s.StageName, s.Note, s.Active 
                    FROM Classes c 
                    INNER JOIN Stages s ON c.StageID = s.StageID";

                DataTable dataTable = db.Select(query);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["ClassID"],
                        row["ClassName"],
                        row["StageName"],
                        row["Note"],
                        row["Active"],
                        true  // Placeholder for active status
                    );
                }
            }

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    // Correct query to join Classes and Stages tables
            //string query = @"
            //    SELECT c.ClassID, c.ClassName, s.StageName, s.Note, s.Active 
            //    FROM Classes c 
            //    INNER JOIN Stages s ON c.StageID = s.StageID";

            //    SqlCommand cmd = new SqlCommand(query, conn);

            //    try
            //    {
            //        conn.Open();
            //        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            //        DataTable dataTable = new DataTable();
            //        sqlDa.Fill(dataTable);

            //        // Clear existing rows before adding new data
            //        dataGridView1.Rows.Clear();

            //        // Add rows to the DataGridView
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    dataGridView1.Rows.Add(
            //        row["ClassID"],
            //        row["ClassName"],
            //        row["StageName"],
            //        row["Note"],
            //        row["Active"],
            //        true  // Placeholder for active status
            //    );
            //}
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("An error occurred: " + ex.Message);
            //    }
            //}



        }

        private void LoadStagesIntoComboBox()
        {
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    string query = "SELECT StageID, StageName FROM Stages";
            //    SqlCommand cmd = new SqlCommand(query, conn);

            //    try
            //    {
            //        conn.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();

            //        comboBox1.Items.Clear();
            //        while (reader.Read())
            //        {
            //            // Add each StageName to the ComboBox
            //            comboBox1.Items.Add(new { StageID = reader["StageID"], StageName = reader["StageName"].ToString() });
            //        }

            //        // Set the ComboBox to display StageName
            //        comboBox1.DisplayMember = "StageName";
            //        comboBox1.ValueMember = "StageID";
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("An error occurred: " + ex.Message);
            //    }
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dynamic selectedItem = comboBox1.SelectedItem;
            string stageName = selectedItem.StageName;
            string note = textBox2.Text;

            if (string.IsNullOrEmpty(stageName) || string.IsNullOrEmpty(note))
            {
                MessageBox.Show("يجب أن تدخل بيانات", "حدث خطأً", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            using (var db = new DatabaseHelper())
            {
                db.Insert("Classes", new Dictionary<string, object>
    {
        { "ClassName", stageName },
        { "ClassYear", DateTime.Now.Year },
        { "StageID", selectedItem.StageID }
    });
            }





          

        }

        private void UserControlClass_Load(object sender, EventArgs e)
        {
            // Load data when the control is loaded
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle DataGridView cell click events
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
