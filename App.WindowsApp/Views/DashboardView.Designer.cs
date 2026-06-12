namespace App.WindowsApp.Views
{
    partial class DashboardView
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            btnRefresh = new Button();
            flpCards = new FlowLayoutPanel();
            pnlBooks = new Panel();
            pnlMembers = new Panel();
            pnlIssued = new Panel();
            pnlReturned = new Panel();
            pnlOverdue = new Panel();
            pnlAvailable = new Panel();
            lblBooksLabel = new Label();
            lblTotalBooks = new Label();
            lblMembersLabel = new Label();
            lblTotalMembers = new Label();
            lblIssuedLabel = new Label();
            lblTotalIssued = new Label();
            lblReturnedLabel = new Label();
            lblTotalReturned = new Label();
            lblOverdueLabel = new Label();
            lblTotalOverdue = new Label();
            lblAvailableLabel = new Label();
            lblAvailableBooks = new Label();
            pnlAnnouncements = new Panel();
            lblAnnouncementsHeader = new Label();
            lstAnnouncements = new ListBox();
            flpCards.SuspendLayout();
            SuspendLayout();
            //
            // lblWelcome
            //
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Location = new Point(20, 15);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Dashboard";
            //
            // btnRefresh
            //
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(588, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(92, 30);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.Image = Properties.Resources.refresh;
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.Click += btnRefresh_Click;
            //
            // flpCards
            //
            flpCards.AutoScroll = true;
            flpCards.Controls.Add(pnlBooks);
            flpCards.Controls.Add(pnlMembers);
            flpCards.Controls.Add(pnlIssued);
            flpCards.Controls.Add(pnlReturned);
            flpCards.Controls.Add(pnlOverdue);
            flpCards.Controls.Add(pnlAvailable);
            flpCards.Location = new Point(20, 60);
            flpCards.Name = "flpCards";
            flpCards.Size = new Size(660, 300);
            flpCards.TabIndex = 2;
            flpCards.WrapContents = true;
            //
            // pnlBooks
            //
            pnlBooks.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            pnlBooks.Controls.Add(lblBooksLabel);
            pnlBooks.Controls.Add(lblTotalBooks);
            pnlBooks.Margin = new Padding(10);
            pnlBooks.Name = "pnlBooks";
            pnlBooks.Padding = new Padding(15);
            pnlBooks.Size = new Size(185, 120);
            pnlBooks.TabIndex = 0;
            //
            // lblBooksLabel
            //
            lblBooksLabel.AutoSize = true;
            lblBooksLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblBooksLabel.ForeColor = System.Drawing.Color.White;
            lblBooksLabel.Location = new System.Drawing.Point(15, 15);
            lblBooksLabel.Name = "lblBooksLabel";
            lblBooksLabel.Text = "Total Books";
            //
            // lblTotalBooks
            //
            lblTotalBooks.AutoSize = true;
            lblTotalBooks.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblTotalBooks.ForeColor = System.Drawing.Color.White;
            lblTotalBooks.Location = new System.Drawing.Point(15, 50);
            lblTotalBooks.Name = "lblTotalBooks";
            lblTotalBooks.Text = "0";
            //
            // pnlMembers
            //
            pnlMembers.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            pnlMembers.Controls.Add(lblMembersLabel);
            pnlMembers.Controls.Add(lblTotalMembers);
            pnlMembers.Margin = new Padding(10);
            pnlMembers.Name = "pnlMembers";
            pnlMembers.Padding = new Padding(15);
            pnlMembers.Size = new Size(185, 120);
            pnlMembers.TabIndex = 1;
            //
            // lblMembersLabel
            //
            lblMembersLabel.AutoSize = true;
            lblMembersLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblMembersLabel.ForeColor = System.Drawing.Color.White;
            lblMembersLabel.Location = new System.Drawing.Point(15, 15);
            lblMembersLabel.Name = "lblMembersLabel";
            lblMembersLabel.Text = "Total Members";
            //
            // lblTotalMembers
            //
            lblTotalMembers.AutoSize = true;
            lblTotalMembers.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblTotalMembers.ForeColor = System.Drawing.Color.White;
            lblTotalMembers.Location = new System.Drawing.Point(15, 50);
            lblTotalMembers.Name = "lblTotalMembers";
            lblTotalMembers.Text = "0";
            //
            // pnlIssued
            //
            pnlIssued.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            pnlIssued.Controls.Add(lblIssuedLabel);
            pnlIssued.Controls.Add(lblTotalIssued);
            pnlIssued.Margin = new Padding(10);
            pnlIssued.Name = "pnlIssued";
            pnlIssued.Padding = new Padding(15);
            pnlIssued.Size = new Size(185, 120);
            pnlIssued.TabIndex = 2;
            //
            // lblIssuedLabel
            //
            lblIssuedLabel.AutoSize = true;
            lblIssuedLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblIssuedLabel.ForeColor = System.Drawing.Color.White;
            lblIssuedLabel.Location = new System.Drawing.Point(15, 15);
            lblIssuedLabel.Name = "lblIssuedLabel";
            lblIssuedLabel.Text = "Books Issued";
            //
            // lblTotalIssued
            //
            lblTotalIssued.AutoSize = true;
            lblTotalIssued.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblTotalIssued.ForeColor = System.Drawing.Color.White;
            lblTotalIssued.Location = new System.Drawing.Point(15, 50);
            lblTotalIssued.Name = "lblTotalIssued";
            lblTotalIssued.Text = "0";
            //
            // pnlReturned
            //
            pnlReturned.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            pnlReturned.Controls.Add(lblReturnedLabel);
            pnlReturned.Controls.Add(lblTotalReturned);
            pnlReturned.Margin = new Padding(10);
            pnlReturned.Name = "pnlReturned";
            pnlReturned.Padding = new Padding(15);
            pnlReturned.Size = new Size(185, 120);
            pnlReturned.TabIndex = 3;
            //
            // lblReturnedLabel
            //
            lblReturnedLabel.AutoSize = true;
            lblReturnedLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblReturnedLabel.ForeColor = System.Drawing.Color.White;
            lblReturnedLabel.Location = new System.Drawing.Point(15, 15);
            lblReturnedLabel.Name = "lblReturnedLabel";
            lblReturnedLabel.Text = "Books Returned";
            //
            // lblTotalReturned
            //
            lblTotalReturned.AutoSize = true;
            lblTotalReturned.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblTotalReturned.ForeColor = System.Drawing.Color.White;
            lblTotalReturned.Location = new System.Drawing.Point(15, 50);
            lblTotalReturned.Name = "lblTotalReturned";
            lblTotalReturned.Text = "0";
            //
            // pnlOverdue
            //
            pnlOverdue.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            pnlOverdue.Controls.Add(lblOverdueLabel);
            pnlOverdue.Controls.Add(lblTotalOverdue);
            pnlOverdue.Margin = new Padding(10);
            pnlOverdue.Name = "pnlOverdue";
            pnlOverdue.Padding = new Padding(15);
            pnlOverdue.Size = new Size(185, 120);
            pnlOverdue.TabIndex = 4;
            //
            // lblOverdueLabel
            //
            lblOverdueLabel.AutoSize = true;
            lblOverdueLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblOverdueLabel.ForeColor = System.Drawing.Color.White;
            lblOverdueLabel.Location = new System.Drawing.Point(15, 15);
            lblOverdueLabel.Name = "lblOverdueLabel";
            lblOverdueLabel.Text = "Overdue";
            //
            // lblTotalOverdue
            //
            lblTotalOverdue.AutoSize = true;
            lblTotalOverdue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblTotalOverdue.ForeColor = System.Drawing.Color.White;
            lblTotalOverdue.Location = new System.Drawing.Point(15, 50);
            lblTotalOverdue.Name = "lblTotalOverdue";
            lblTotalOverdue.Text = "0";
            //
            // pnlAvailable
            //
            pnlAvailable.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            pnlAvailable.Controls.Add(lblAvailableLabel);
            pnlAvailable.Controls.Add(lblAvailableBooks);
            pnlAvailable.Margin = new Padding(10);
            pnlAvailable.Name = "pnlAvailable";
            pnlAvailable.Padding = new Padding(15);
            pnlAvailable.Size = new Size(185, 120);
            pnlAvailable.TabIndex = 5;
            //
            // lblAvailableLabel
            //
            lblAvailableLabel.AutoSize = true;
            lblAvailableLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblAvailableLabel.ForeColor = System.Drawing.Color.White;
            lblAvailableLabel.Location = new System.Drawing.Point(15, 15);
            lblAvailableLabel.Name = "lblAvailableLabel";
            lblAvailableLabel.Text = "Available Books";
            //
            // lblAvailableBooks
            //
            lblAvailableBooks.AutoSize = true;
            lblAvailableBooks.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblAvailableBooks.ForeColor = System.Drawing.Color.White;
            lblAvailableBooks.Location = new System.Drawing.Point(15, 50);
            lblAvailableBooks.Name = "lblAvailableBooks";
            lblAvailableBooks.Text = "0";
            //
            // pnlAnnouncements
            //
            pnlAnnouncements.Location = new Point(20, 375);
            pnlAnnouncements.Name = "pnlAnnouncements";
            pnlAnnouncements.Size = new Size(660, 220);
            pnlAnnouncements.TabIndex = 3;
            pnlAnnouncements.BorderStyle = BorderStyle.FixedSingle;
            pnlAnnouncements.BackColor = System.Drawing.Color.White;
            pnlAnnouncements.Controls.Add(lblAnnouncementsHeader);
            pnlAnnouncements.Controls.Add(lstAnnouncements);
            //
            // lblAnnouncementsHeader
            //
            lblAnnouncementsHeader.AutoSize = true;
            lblAnnouncementsHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAnnouncementsHeader.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            lblAnnouncementsHeader.Location = new Point(10, 10);
            lblAnnouncementsHeader.Name = "lblAnnouncementsHeader";
            lblAnnouncementsHeader.Text = "📢  Active Announcements";
            //
            // lstAnnouncements
            //
            lstAnnouncements.BorderStyle = BorderStyle.None;
            lstAnnouncements.Font = new Font("Segoe UI", 9.5F);
            lstAnnouncements.Location = new Point(10, 45);
            lstAnnouncements.Name = "lstAnnouncements";
            lstAnnouncements.Size = new Size(636, 165);
            lstAnnouncements.TabIndex = 0;
            lstAnnouncements.ItemHeight = 22;
            //
            // DashboardView
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(lblWelcome);
            Controls.Add(btnRefresh);
            Controls.Add(flpCards);
            Controls.Add(pnlAnnouncements);
            Font = new Font("Segoe UI", 9F);
            Name = "DashboardView";
            Size = new Size(700, 620);
            Load += DashboardView_Load;
            flpCards.ResumeLayout(true);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblWelcome;
        private Button btnRefresh;
        private FlowLayoutPanel flpCards;
        private Panel pnlBooks, pnlMembers, pnlIssued, pnlReturned, pnlOverdue, pnlAvailable;
        private Label lblBooksLabel, lblTotalBooks;
        private Label lblMembersLabel, lblTotalMembers;
        private Label lblIssuedLabel, lblTotalIssued;
        private Label lblReturnedLabel, lblTotalReturned;
        private Label lblOverdueLabel, lblTotalOverdue;
        private Label lblAvailableLabel, lblAvailableBooks;
        private Panel pnlAnnouncements;
        private Label lblAnnouncementsHeader;
        private ListBox lstAnnouncements;
    }
}