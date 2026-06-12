namespace App.WindowsApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            lblUser = new Label();
            flpLeft = new FlowLayoutPanel();
            pictureBox2 = new PictureBox();
            lblTitle = new Label();
            pnlSidebar = new Panel();
            flpNav = new FlowLayoutPanel();
            btnDashboard = new Button();
            btnBooks = new Button();
            btnMembers = new Button();
            btnIssueBook = new Button();
            btnAnnouncements = new Button();
            statusStrip = new StatusStrip();
            tsLabelStatus = new ToolStripStatusLabel();
            pnlContent = new Panel();
            pnlHeader.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlSidebar.SuspendLayout();
            flpNav.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(22, 33, 62);
            pnlHeader.Controls.Add(flowLayoutPanel1);
            pnlHeader.Controls.Add(flpLeft);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 50);
            pnlHeader.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(lblUser);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.Location = new Point(757, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(143, 50);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 41);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Dock = DockStyle.Right;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.White;
            lblUser.ImageAlign = ContentAlignment.MiddleLeft;
            lblUser.Location = new Point(46, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(60, 47);
            lblUser.TabIndex = 0;
            lblUser.Text = "Admin";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            lblUser.Click += lblUser_Click;
            // 
            // flpLeft
            // 
            flpLeft.Controls.Add(pictureBox2);
            flpLeft.Controls.Add(lblTitle);
            flpLeft.Dock = DockStyle.Left;
            flpLeft.Location = new Point(0, 0);
            flpLeft.Name = "flpLeft";
            flpLeft.Size = new Size(436, 50);
            flpLeft.TabIndex = 2;
            flpLeft.Paint += flpLeft_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.online_library1;
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 41);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Right;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTitle.Location = new Point(43, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblTitle.Size = new Size(340, 47);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Library Management System";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(30, 45, 80);
            pnlSidebar.Controls.Add(flpNav);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 50);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(180, 510);
            pnlSidebar.TabIndex = 1;
            // 
            // flpNav
            // 
            flpNav.BackColor = Color.FromArgb(22, 33, 62);
            flpNav.Controls.Add(btnDashboard);
            flpNav.Controls.Add(btnBooks);
            flpNav.Controls.Add(btnMembers);
            flpNav.Controls.Add(btnIssueBook);
            flpNav.Controls.Add(btnAnnouncements);
            flpNav.Dock = DockStyle.Fill;
            flpNav.FlowDirection = FlowDirection.TopDown;
            flpNav.Location = new Point(0, 0);
            flpNav.Name = "flpNav";
            flpNav.Padding = new Padding(5, 10, 5, 0);
            flpNav.Size = new Size(180, 510);
            flpNav.TabIndex = 0;
            flpNav.Paint += flpNav_Paint;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Image = Properties.Resources.dashboard2;
            btnDashboard.Location = new Point(8, 13);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(165, 42);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "  Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnBooks
            // 
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.Font = new Font("Segoe UI", 10F);
            btnBooks.ForeColor = Color.White;
            btnBooks.Image = Properties.Resources.stack_of_books;
            btnBooks.Location = new Point(8, 61);
            btnBooks.Name = "btnBooks";
            btnBooks.Size = new Size(165, 42);
            btnBooks.TabIndex = 1;
            btnBooks.Text = "  Books";
            btnBooks.TextAlign = ContentAlignment.MiddleLeft;
            btnBooks.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBooks.UseVisualStyleBackColor = true;
            btnBooks.Click += btnBooks_Click;
            // 
            // btnMembers
            // 
            btnMembers.FlatAppearance.BorderSize = 0;
            btnMembers.FlatStyle = FlatStyle.Flat;
            btnMembers.Font = new Font("Segoe UI", 10F);
            btnMembers.ForeColor = Color.White;
            btnMembers.Image = Properties.Resources.group_users;
            btnMembers.Location = new Point(8, 109);
            btnMembers.Name = "btnMembers";
            btnMembers.Size = new Size(165, 42);
            btnMembers.TabIndex = 2;
            btnMembers.Text = "  Members";
            btnMembers.TextAlign = ContentAlignment.MiddleLeft;
            btnMembers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMembers.UseVisualStyleBackColor = true;
            btnMembers.Click += btnMembers_Click;
            // 
            // btnIssueBook
            // 
            btnIssueBook.FlatAppearance.BorderSize = 0;
            btnIssueBook.FlatStyle = FlatStyle.Flat;
            btnIssueBook.Font = new Font("Segoe UI", 10F);
            btnIssueBook.ForeColor = Color.White;
            btnIssueBook.Image = Properties.Resources.reading;
            btnIssueBook.Location = new Point(8, 157);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(166, 42);
            btnIssueBook.TabIndex = 3;
            btnIssueBook.Text = "  Issue / Return";
            btnIssueBook.TextAlign = ContentAlignment.MiddleLeft;
            btnIssueBook.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIssueBook.UseVisualStyleBackColor = true;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // btnAnnouncements
            // 
            btnAnnouncements.FlatAppearance.BorderSize = 0;
            btnAnnouncements.FlatStyle = FlatStyle.Flat;
            btnAnnouncements.Font = new Font("Segoe UI", 10F);
            btnAnnouncements.ForeColor = Color.White;
            btnAnnouncements.Image = Properties.Resources.Announcement;
            btnAnnouncements.Location = new Point(8, 205);
            btnAnnouncements.Name = "btnAnnouncements";
            btnAnnouncements.Size = new Size(179, 42);
            btnAnnouncements.TabIndex = 4;
            btnAnnouncements.Text = "  Announcements";
            btnAnnouncements.TextAlign = ContentAlignment.MiddleLeft;
            btnAnnouncements.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAnnouncements.UseVisualStyleBackColor = true;
            btnAnnouncements.Click += btnAnnouncements_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { tsLabelStatus });
            statusStrip.Location = new Point(0, 560);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(900, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "Ready";
            // 
            // tsLabelStatus
            // 
            tsLabelStatus.Name = "tsLabelStatus";
            tsLabelStatus.Size = new Size(50, 20);
            tsLabelStatus.Text = "Ready";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(180, 50);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(720, 510);
            pnlContent.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 586);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(statusStrip);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management System";
            WindowState = FormWindowState.Maximized;
            pnlHeader.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flpLeft.ResumeLayout(false);
            flpLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlSidebar.ResumeLayout(false);
            flpNav.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblUser;
        private Panel pnlSidebar;
        private FlowLayoutPanel flpNav;
        private Button btnDashboard;
        private Button btnBooks;
        private Button btnMembers;
        private Button btnIssueBook;
        private Button btnAnnouncements;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel tsLabelStatus;
        private Panel pnlContent;
        private FlowLayoutPanel flpLeft;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}