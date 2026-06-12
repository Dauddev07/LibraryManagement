using App.Core.Contracts;
using App.Core.Models;
using App.Core.Utilities;
using App.WindowsApp.Forms;

namespace App.WindowsApp.Views
{
    public partial class MembersView : UserControl
    {
        private readonly IMemberService _memberService;
        private readonly IBookIssueService _issueService; // FIX #3
        private BindingSource _bindingSource = new BindingSource();

        public MembersView(IMemberService service, IBookIssueService issueService)
        {
            _memberService = service;
            _issueService = issueService;
            InitializeComponent();
            dgvMembers.DataSource = _bindingSource;
            // FIX #4 — LoadMembers() moved to Load event below, not called here
        }

        private void MembersView_Load(object sender, EventArgs e) // FIX #4
        {
            LoadMembers();
        }

        private void LoadMembers() // FIX #1
        {
            try
            {
                _bindingSource.DataSource = _memberService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new MemberForm(_memberService, MemberFormModeEnum.Add);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding member: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Member selected = _bindingSource.Current as Member;
                if (selected != null)
                {
                    var form = new MemberForm(_memberService, MemberFormModeEnum.Edit, selected);
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing member: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            try
            {
                Member selected = _bindingSource.Current as Member;
                if (selected != null)
                {
                    var form = new MemberForm(_memberService, MemberFormModeEnum.View, selected);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing member: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            Member selected = _bindingSource.Current as Member;
            if (selected == null) return;

            try
            {
                // FIX #3 — block delete if member has unreturned books
                var activeIssues = _issueService.GetByMemberId(selected.Id)
                    .Where(i => i.Status == IssueStatusEnum.Issued || i.Status == IssueStatusEnum.Overdue)
                    .ToList();

                if (activeIssues.Count > 0)
                {
                    MessageBox.Show(
                        $"Cannot delete \"{selected.Name}\" — they have {activeIssues.Count} unreturned book(s).\n" +
                        "Please return or close those issues first.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this member?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    _memberService.Delete(selected.Id);
                    LoadMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting member: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e) => LoadMembers();

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = txtSearch.Text;
                if (string.IsNullOrWhiteSpace(query))
                    LoadMembers();
                else
                    _bindingSource.DataSource = _memberService.Search(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching members: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}