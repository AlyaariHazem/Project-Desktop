namespace Myschool.Forms
{
    partial class Dashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TreeNode treeNode1 = new TreeNode("معلومات المدرسة");
            TreeNode treeNode2 = new TreeNode("السنوات الدراسية");
            TreeNode treeNode3 = new TreeNode("المراحل و الصفوف");
            TreeNode treeNode4 = new TreeNode("الإعدادات", new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            TreeNode treeNode5 = new TreeNode("جميع المدرسين");
            TreeNode treeNode6 = new TreeNode("إضافة مدرس");
            TreeNode treeNode7 = new TreeNode("تعديل مدرس");
            TreeNode treeNode8 = new TreeNode("عن المدرسين");
            TreeNode treeNode9 = new TreeNode("المدرسين", new TreeNode[] { treeNode5, treeNode6, treeNode7, treeNode8 });
            TreeNode treeNode10 = new TreeNode("إضافة طالب");
            TreeNode treeNode11 = new TreeNode("عرض الطلاب");
            TreeNode treeNode12 = new TreeNode("تعديل طالب");
            TreeNode treeNode13 = new TreeNode("الطلاب الجدد");
            TreeNode treeNode14 = new TreeNode("الطلاب", new TreeNode[] { treeNode10, treeNode11, treeNode12, treeNode13 });
            TreeNode treeNode15 = new TreeNode("عرض أولياء الأمور");
            TreeNode treeNode16 = new TreeNode("تعديل ولي أمر");
            TreeNode treeNode17 = new TreeNode("إضافة ولي أمر");
            TreeNode treeNode18 = new TreeNode("عن أولياء الأمور");
            TreeNode treeNode19 = new TreeNode("أولياء الأمور", new TreeNode[] { treeNode15, treeNode16, treeNode17, treeNode18 });
            TreeNode treeNode20 = new TreeNode("التقويم");
            TreeNode treeNode21 = new TreeNode("الأختبارات");
            TreeNode treeNode22 = new TreeNode("العطل");
            TreeNode treeNode23 = new TreeNode("الحسابات");
            TreeNode treeNode24 = new TreeNode("المدونات");
            TreeNode treeNode25 = new TreeNode("الإدارة");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            panel2 = new Panel();
            treeView1 = new TreeView();
            imageList1 = new ImageList(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBox3 = new PictureBox();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            label4 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            guna2CustomGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(4, 6);
            label1.Name = "label1";
            label1.Size = new Size(1321, 59);
            label1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo1;
            pictureBox1.Location = new Point(142, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(74, 18);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 3;
            label2.Text = "مدرستي";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(3, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(227, 59);
            panel1.TabIndex = 4;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.img_2;
            pictureBox2.Location = new Point(1264, 14);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 44);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(1203, 25);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 6;
            label3.Text = "Admin";
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.Location = new Point(234, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(1100, 686);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.White;
            treeView1.ImageIndex = 0;
            treeView1.ImageList = imageList1;
            treeView1.Location = new Point(4, 127);
            treeView1.Name = "treeView1";
            treeNode1.Name = "Node2";
            treeNode1.Text = "معلومات المدرسة";
            treeNode2.Name = "Node3";
            treeNode2.Text = "السنوات الدراسية";
            treeNode3.Name = "Node5";
            treeNode3.Text = "المراحل و الصفوف";
            treeNode4.ImageKey = "icon-14.png";
            treeNode4.Name = "Node0";
            treeNode4.Text = "الإعدادات";
            treeNode5.Name = "Node6";
            treeNode5.Text = "جميع المدرسين";
            treeNode6.Name = "Node7";
            treeNode6.Text = "إضافة مدرس";
            treeNode7.Name = "Node8";
            treeNode7.Text = "تعديل مدرس";
            treeNode8.Name = "Node9";
            treeNode8.Text = "عن المدرسين";
            treeNode9.ImageKey = "icon-3.png";
            treeNode9.Name = "Node1";
            treeNode9.Text = "المدرسين";
            treeNode10.Name = "Node10";
            treeNode10.Text = "إضافة طالب";
            treeNode11.Name = "Node11";
            treeNode11.Text = "عرض الطلاب";
            treeNode12.Name = "Node12";
            treeNode12.Text = "تعديل طالب";
            treeNode13.Name = "Node13";
            treeNode13.Text = "الطلاب الجدد";
            treeNode14.ImageKey = "icon-3.png";
            treeNode14.Name = "Node4";
            treeNode14.Text = "الطلاب";
            treeNode15.Name = "Node15";
            treeNode15.Text = "عرض أولياء الأمور";
            treeNode16.Name = "Node16";
            treeNode16.Text = "تعديل ولي أمر";
            treeNode17.Name = "Node17";
            treeNode17.Text = "إضافة ولي أمر";
            treeNode18.Name = "Node18";
            treeNode18.Text = "عن أولياء الأمور";
            treeNode19.ImageKey = "icon-4.png";
            treeNode19.Name = "Node14";
            treeNode19.Text = "أولياء الأمور";
            treeNode20.ImageKey = "icon-6.png";
            treeNode20.Name = "Node19";
            treeNode20.Text = "التقويم";
            treeNode21.ImageKey = "icon-7.png";
            treeNode21.Name = "Node20";
            treeNode21.Text = "الأختبارات";
            treeNode22.ImageKey = "icon-8.png";
            treeNode22.Name = "Node21";
            treeNode22.Text = "العطل";
            treeNode23.ImageKey = "icon-10.png";
            treeNode23.Name = "Node23";
            treeNode23.Text = "الحسابات";
            treeNode24.ImageKey = "icon-17.png";
            treeNode24.Name = "Node22";
            treeNode24.Text = "المدونات";
            treeNode25.ImageKey = "icon-20.png";
            treeNode25.Name = "Node24";
            treeNode25.Text = "الإدارة";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode4, treeNode9, treeNode14, treeNode19, treeNode20, treeNode21, treeNode22, treeNode23, treeNode24, treeNode25 });
            treeView1.RightToLeft = RightToLeft.Yes;
            treeView1.RightToLeftLayout = true;
            treeView1.SelectedImageIndex = 0;
            treeView1.Size = new Size(226, 622);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "icon-1.png");
            imageList1.Images.SetKeyName(1, "icon-2.png");
            imageList1.Images.SetKeyName(2, "icon-3.png");
            imageList1.Images.SetKeyName(3, "icon-4.png");
            imageList1.Images.SetKeyName(4, "icon-5.png");
            imageList1.Images.SetKeyName(5, "icon-6.png");
            imageList1.Images.SetKeyName(6, "icon-7.png");
            imageList1.Images.SetKeyName(7, "icon-8.png");
            imageList1.Images.SetKeyName(8, "icon-9.png");
            imageList1.Images.SetKeyName(9, "icon-10.png");
            imageList1.Images.SetKeyName(10, "icon-11.png");
            imageList1.Images.SetKeyName(11, "icon-12.png");
            imageList1.Images.SetKeyName(12, "icon-13.png");
            imageList1.Images.SetKeyName(13, "icon-14.png");
            imageList1.Images.SetKeyName(14, "icon-15.png");
            imageList1.Images.SetKeyName(15, "icon-17.png");
            imageList1.Images.SetKeyName(16, "icon-18.png");
            imageList1.Images.SetKeyName(17, "icon-19.png");
            imageList1.Images.SetKeyName(18, "icon-20.png");
            imageList1.Images.SetKeyName(19, "icon-21.png");
            imageList1.Images.SetKeyName(20, "icon-22.png");
            imageList1.Images.SetKeyName(21, "icon-23.png");
            imageList1.Images.SetKeyName(22, "icon-26.png");
            imageList1.Images.SetKeyName(23, "icon-27.png");
            imageList1.Images.SetKeyName(24, "icon-28.png");
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icon_1;
            pictureBox3.Location = new Point(179, 11);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(36, 37);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.BorderColor = Color.Black;
            guna2CustomGradientPanel1.BorderRadius = 5;
            guna2CustomGradientPanel1.BorderThickness = 1;
            guna2CustomGradientPanel1.Controls.Add(label4);
            guna2CustomGradientPanel1.Controls.Add(pictureBox3);
            guna2CustomGradientPanel1.Controls.Add(button1);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges1;
            guna2CustomGradientPanel1.Location = new Point(4, 66);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CustomGradientPanel1.Size = new Size(226, 59);
            guna2CustomGradientPanel1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(56, 18);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 6;
            label4.Text = "الصفحة الرئيسية";
            // 
            // button1
            // 
            button1.Location = new Point(0, 2);
            button1.Name = "button1";
            button1.Size = new Size(223, 57);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1329, 753);
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(treeView1);
            MaximizeBox = false;
            Name = "Dashboard";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "الصفحة الرئيسية";
            Load += Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Label label3;
        private Panel panel2;
        private TreeView treeView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox3;
        private ImageList imageList1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Label label4;
        private Button button1;
    }
}