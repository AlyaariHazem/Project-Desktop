﻿using Myschool.Dashboard;
using Myschool.Forms.StageClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Myschool.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Optionally load the UserControl when the form loads
            LoadUserControl();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the UserControl when button1 is clicked
            LoadUserControl();
        }

        private void LoadUserControl()
        {
            // Clear the panel before adding a new control
            panel2.Controls.Clear();

            // Create an instance of UserControl1
            UserControl1 userControl = new UserControl1();

            // Set the UserControl to fill the panel
            userControl.Dock = DockStyle.Fill;

            // Add the UserControl to the panel
            panel2.Controls.Add(userControl);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected node
            TreeNode selectedNode = e.Node;

            // Build a message to display information about the selected node
            string message = selectedNode.Text;

            if (message.ToLower() == "المراحل و الصفوف")
            {
                LoadUserControlStage();
            }

        }
        private void LoadUserControlStage()
        {
            // Clear the panel before adding a new control
            panel2.Controls.Clear();

            UserControlStage userControlStage = new UserControlStage();

            userControlStage.Dock = DockStyle.Fill;

            panel2.Controls.Add(userControlStage);
        }

    }
}
