using App.Core.Contracts;
using App.Core.Utilities;

namespace App.WindowsApp.Views
{
    public partial class DashboardView : UserControl
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly IBookIssueService _issueService;
        private readonly IAnnouncementService _announcementService;

        public DashboardView(IBookService bookService, IMemberService memberService, IBookIssueService issueService, IAnnouncementService announcementService)
        {
            _bookService = bookService;
            _memberService = memberService;
            _issueService = issueService;
            _announcementService = announcementService;
            InitializeComponent();
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            RefreshStats();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshStats();
        }

        private void RefreshStats()
        {
            try
            {
                var allBooks = _bookService.GetAll();
                var allMembers = _memberService.GetAll();
                var allIssues = _issueService.GetAll();

                lblTotalBooks.Text = allBooks.Count.ToString();
                lblTotalMembers.Text = allMembers.Count.ToString();
                lblTotalIssued.Text = allIssues.Count(i => i.Status == IssueStatusEnum.Issued).ToString();
                lblTotalReturned.Text = allIssues.Count(i => i.Status == IssueStatusEnum.Returned).ToString();
                lblTotalOverdue.Text = allIssues.Count(i => i.Status == IssueStatusEnum.Overdue).ToString();
                lblAvailableBooks.Text = allBooks.Count(b => b.Status == BookStatusEnum.Available).ToString();

                lstAnnouncements.Items.Clear();
                var announcements = _announcementService.GetActive();

                if (announcements.Count == 0)
                {
                    lstAnnouncements.Items.Add("No active announcements at this time.");
                }
                else
                {
                    foreach (var a in announcements.OrderByDescending(x => x.PostedDate))
                        lstAnnouncements.Items.Add($"[{a.PostedDate:dd MMM yyyy}]  {a.Title} — {a.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}