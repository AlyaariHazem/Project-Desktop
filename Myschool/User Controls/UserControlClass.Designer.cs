﻿namespace Myschool.User_Controls
{
    partial class UserControlClass
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            button1 = new Guna.UI2.WinForms.Guna2Button();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            ClassID = new DataGridViewTextBoxColumn();
            ClassName = new DataGridViewTextBoxColumn();
            StageName = new DataGridViewTextBoxColumn();
            Division = new DataGridViewTextBoxColumn();
            Active = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(5, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(1048, 115);
            panel1.TabIndex = 0;
            panel1.Click += panel1_Click1;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BorderColor = Color.FromArgb(192, 255, 192);
            button1.BorderRadius = 15;
            button1.CustomizableEdges = customizableEdges1;
            button1.DisabledState.BorderColor = Color.DarkGray;
            button1.DisabledState.CustomBorderColor = Color.DarkGray;
            button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            button1.FillColor = Color.LimeGreen;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(29, 32);
            button1.Name = "button1";
            button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            button1.Size = new Size(111, 36);
            button1.TabIndex = 18;
            button1.Text = "+إضافة ";
            button1.Click += button1_Click_1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(791, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.RightToLeft = RightToLeft.Yes;
            comboBox1.Size = new Size(230, 28);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(442, 53);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(233, 27);
            textBox2.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(595, 19);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 9;
            label2.Text = "اسم الصف";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(936, 16);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 10;
            label1.Text = "اسم المرحلة";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ClassID, ClassName, StageName, Division, Active });
            dataGridView1.Location = new Point(9, 129);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RightToLeft = RightToLeft.Yes;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1037, 389);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ClassID
            // 
            ClassID.HeaderText = "#";
            ClassID.MinimumWidth = 6;
            ClassID.Name = "ClassID";
            ClassID.ReadOnly = true;
            // 
            // ClassName
            // 
            ClassName.HeaderText = "اسم الصف";
            ClassName.MinimumWidth = 6;
            ClassName.Name = "ClassName";
            ClassName.ReadOnly = true;
            // 
            // StageName
            // 
            StageName.HeaderText = "المرحلة";
            StageName.MinimumWidth = 6;
            StageName.Name = "StageName";
            StageName.ReadOnly = true;
            // 
            // Division
            // 
            Division.HeaderText = "شعب الصف";
            Division.MinimumWidth = 6;
            Division.Name = "Division";
            Division.ReadOnly = true;
            // 
            // Active
            // 
            Active.HeaderText = "الحالة";
            Active.MinimumWidth = 6;
            Active.Name = "Active";
            Active.ReadOnly = true;
            // 
            // UserControlClass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "UserControlClass";
            Size = new Size(1056, 521);
            Load += UserControlClass_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Guna.UI2.WinForms.Guna2Button button1;
        private DataGridViewTextBoxColumn ClassID;
        private DataGridViewTextBoxColumn ClassName;
        private DataGridViewTextBoxColumn StageName;
        private DataGridViewTextBoxColumn Division;
        private DataGridViewTextBoxColumn Active;
    }
}
