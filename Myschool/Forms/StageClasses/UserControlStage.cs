﻿using Myschool.Dashboard;
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
            UserControlStageInfo userControlStageInfo = new UserControlStageInfo();

            // Set the UserControl to fill the panel
            userControlStageInfo.Dock = DockStyle.Fill;

            // Add the UserControl to the panel
            panel1.Controls.Add(userControlStageInfo);
        }
    }
}