using Myschool.Dashboard;
using Myschool.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Myschool.Forms.StageClasses
{
    public partial class UserControlStage : UserControl
    {
        public UserControlStage()
        {
            InitializeComponent();
            LoadUserControl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl();
        }
        private void LoadUserControl()
        {
            // Clear the panel before adding a new control
            panel1.Controls.Clear();

            // Create an instance of UserControl1
            UserControlStageClass userControlStageInfo = new UserControlStageClass();

            // Set the UserControl to fill the panel
            userControlStageInfo.Dock = DockStyle.Fill;

            // Add the UserControl to the panel
            panel1.Controls.Add(userControlStageInfo);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadUserControlCLass();
        }

        private void LoadUserControlCLass()
        {
            panel1.Controls.Clear();

            UserControlClass userControlStageClass = new UserControlClass();

            userControlStageClass.Dock = DockStyle.Fill;

            panel1.Controls.Add(userControlStageClass);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadUserControlDivision();
        }

        private void LoadUserControlDivision()
        {
            panel1.Controls.Clear();

            UserControlDivision userControlDivision = new UserControlDivision();

            userControlDivision.Dock = DockStyle.Fill;

            panel1.Controls.Add(userControlDivision);
        }
    }
}
