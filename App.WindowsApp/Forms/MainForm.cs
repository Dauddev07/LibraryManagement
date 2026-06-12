using App.Core.Contracts;
using App.Core.Services;
using App.WindowsApp.Views;
using System.Configuration;

namespace App.WindowsApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly string _connStr;
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly IBookIssueService _issueService;
        private readonly IAnnouncementService _announcementService;


        public MainForm()
        {
            InitializeComponent();

            // FIX #5 — validate connection string before use
            var connEntry = ConfigurationManager.ConnectionStrings["LibraryDB"];
            if (connEntry == null || string.IsNullOrWhiteSpace(connEntry.ConnectionString))
            {
                MessageBox.Show(
                    "The 'LibraryDB' connection string is missing or empty in App.config.\n" +
                    "Please add it and restart the application.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Load += (_, _) => Close();
                return;
            }

            _connStr = connEntry.ConnectionString;
            _bookService = new DBBookService(_connStr);
            _memberService = new DBMemberService(_connStr);
            _issueService = new DBBookIssueService(_connStr);
            _announcementService = new DBAnnouncementService(_connStr);

            tsLabelStatus.Text = "Ready  |  " + DateTime.Now.ToString("dd MMM yyyy  hh:mm tt");
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowView(() => new DashboardView(_bookService, _memberService, _issueService, _announcementService));
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            ShowView(() => new BooksView(_bookService, _issueService));
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            ShowView(() => new MembersView(_memberService, _issueService));
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            ShowView(() => new BookIssuesView(_issueService, _bookService, _memberService));
        }

        private void btnAnnouncements_Click(object sender, EventArgs e)
        {
            ShowView(() => new AnnouncementsView(_announcementService));
        }

        private void flpNav_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void flpLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void ShowView<T>(Func<T> factory) where T : UserControl
        {
            pnlContent.Controls.Clear();

            var view = factory();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
            view.BringToFront();

            tsLabelStatus.Text = $"Viewing: {typeof(T).Name.Replace("View", "")}  |  {DateTime.Now:dd MMM yyyy  hh:mm tt}";
        }
    }
}