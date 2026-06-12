using App.Core.Contracts;
using App.Core.Models;
using App.Core.Utilities;

namespace App.WindowsApp.Forms
{
    public partial class BookIssueForm : Form
    {
        private readonly IBookIssueService _issueService;
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private BookIssue _issue;
        private bool _isEdit;

        public BookIssueForm(IBookIssueService issueService, IBookService bookService,
            IMemberService memberService, BookIssue issue = null, bool isViewOnly = false)
        {
            InitializeComponent();
            _issueService = issueService;
            _bookService = bookService;
            _memberService = memberService;

            cmbStatus.Items.Clear();

            if (issue != null)
            {
                _issue = issue;
                _isEdit = true;
                this.Text = "Edit Issue / Return Book";
                btnSave.Text = "Update";

                txtBookId.Text = issue.BookId;
                txtBookTitle.Text = issue.BookTitle;
                txtMemberId.Text = issue.MemberId;
                txtMemberName.Text = issue.MemberName;
                dtpIssueDate.Value = issue.IssueDate;

                if (issue.ReturnDate.HasValue)
                    dtpReturnDate.Value = issue.ReturnDate.Value;
                else
                    dtpReturnDate.Value = DateTime.Now;

                if (issue.Status == IssueStatusEnum.Returned)
                {
                    cmbStatus.DataSource = new[] { IssueStatusEnum.Returned };
                    cmbStatus.Enabled = false;
                }
                else
                {
                    cmbStatus.DataSource = Enum.GetValues(typeof(IssueStatusEnum));
                }

                cmbStatus.SelectedItem = issue.Status;

                btnPickBook.Enabled = false;
                btnPickMember.Enabled = false;

                // View-only mode — lock everything down
                if (isViewOnly)
                {
                    this.Text = "View Issue Record";
                    btnSave.Visible = false;
                    dtpIssueDate.Enabled = false;
                    dtpReturnDate.Enabled = false;
                    cmbStatus.Enabled = false;
                }
            }
            else
            {
                cmbStatus.DataSource = new[] { IssueStatusEnum.Issued };
                cmbStatus.SelectedIndex = 0;
                cmbStatus.Enabled = false;

                _issue = new BookIssue();
                _isEdit = false;
                this.Text = "Issue a Book";
                dtpIssueDate.Value = DateTime.Now;
                dtpReturnDate.Value = DateTime.Now;
            }

            // Grey out ReturnDate when status is not Returned
            UpdateReturnDateState();
            cmbStatus.SelectedIndexChanged += (_, _) => UpdateReturnDateState();
        }

        private void UpdateReturnDateState()
        {
            bool isReturned = cmbStatus.SelectedItem is IssueStatusEnum s && s == IssueStatusEnum.Returned;
            dtpReturnDate.Enabled = isReturned;
        }

        private void btnPickBook_Click(object sender, EventArgs e)
        {
            using var picker = new BookPicker(_bookService);
            if (picker.ShowDialog() == DialogResult.OK && picker.SelectedBook != null)
            {
                txtBookId.Text = picker.SelectedBook.Id;
                txtBookTitle.Text = picker.SelectedBook.Title;
            }
        }

        private void btnPickMember_Click(object sender, EventArgs e)
        {
            using var picker = new MemberPicker(_memberService);
            if (picker.ShowDialog() == DialogResult.OK && picker.SelectedMember != null)
            {
                txtMemberId.Text = picker.SelectedMember.Id;
                txtMemberName.Text = picker.SelectedMember.Name;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookId.Text))
            {
                MessageBox.Show("Please select a book.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMemberId.Text))
            {
                MessageBox.Show("Please select a member.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_isEdit && (IssueStatusEnum)cmbStatus.SelectedItem != IssueStatusEnum.Issued)
            {
                MessageBox.Show("A new book issue can only have the status 'Issued'.\n" +
                                "It cannot be Returned or Overdue before it has even been issued.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _issue.BookId = txtBookId.Text;
                _issue.BookTitle = txtBookTitle.Text;
                _issue.MemberId = txtMemberId.Text;
                _issue.MemberName = txtMemberName.Text;
                _issue.IssueDate = dtpIssueDate.Value;
                _issue.Status = (IssueStatusEnum)cmbStatus.SelectedItem;

                _issue.ReturnDate = (_issue.Status == IssueStatusEnum.Returned)
                    ? dtpReturnDate.Value
                    : null;

                if (_isEdit)
                {
                    _issueService.Update(_issue);
                    MessageBox.Show("Issue record updated!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _issueService.Add(_issue);
                    MessageBox.Show("Book issued successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}