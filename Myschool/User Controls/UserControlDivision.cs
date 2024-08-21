using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Myschool.User_Controls
{
    public partial class UserControlDivision : UserControl
    {
        string connectionString = "Data source=HAZEM; initial catalog=SchoolDB; Integrated security=true;";
        public UserControlDivision()
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
                string query = "SELECT DivisionID, DivisionName FROM Divisions";
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
                            row["DivisionID"],
                            row["DivisionName"],
                            "الصفوف",    // Placeholder for class info
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
