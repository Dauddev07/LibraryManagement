using App.Core.Contracts;
using App.Core.Models;

namespace App.WindowsApp.Views
{
    public partial class AnnouncementsView : UserControl
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementsView(IAnnouncementService announcementService)
        {
            InitializeComponent();
            _announcementService = announcementService;
        }

        private void AnnouncementsView_Load(object sender, EventArgs e)
        {
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("All");
            cmbFilter.Items.Add("Active Only");
            cmbFilter.SelectedIndex = 0;
            LoadAnnouncements();

        }

        private void LoadAnnouncements()
        {
            var list = _announcementService.GetAll();
            dgvAnnouncements.DataSource = list;
            lblCount.Text = $"Total: {list.Count}  |  Active: {list.FindAll(a => a.IsActive).Count}";
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem?.ToString() == "Active Only")
            {
                var list = _announcementService.GetActive();
                dgvAnnouncements.DataSource = list;
                lblCount.Text = $"Showing Active: {list.Count}";
            }
            else
            {
                LoadAnnouncements();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlForm.Visible = true;
            btnSave.Tag = "Add";
            txtTitle.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAnnouncements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an announcement to edit.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dgvAnnouncements.SelectedRows[0].DataBoundItem as Announcement;
            if (selected == null) return;

            txtId.Text = selected.Id;
            txtTitle.Text = selected.Title;
            txtMessage.Text = selected.Message;
            chkIsActive.Checked = selected.IsActive;
            pnlForm.Visible = true;
            btnSave.Tag = "Edit";
            txtTitle.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnnouncements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an announcement to delete.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dgvAnnouncements.SelectedRows[0].DataBoundItem as Announcement;
            if (selected == null) return;

            var confirm = MessageBox.Show($"Delete announcement: \"{selected.Title}\"?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                _announcementService.Delete(selected.Id);
                MessageBox.Show("Announcement deleted.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAnnouncements();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Message cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMessage.Focus();
                return;
            }

            string mode = btnSave.Tag?.ToString();

            if (mode == "Add")
            {
                var a = new Announcement
                {
                    Title = txtTitle.Text.Trim(),
                    Message = txtMessage.Text.Trim(),
                    IsActive = chkIsActive.Checked
                };
                _announcementService.Add(a);
                MessageBox.Show("Announcement added!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var a = new Announcement
                {
                    Id = txtId.Text,
                    Title = txtTitle.Text.Trim(),
                    Message = txtMessage.Text.Trim(),
                    IsActive = chkIsActive.Checked
                };
                _announcementService.Update(a);
                MessageBox.Show("Announcement updated!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            pnlForm.Visible = false;
            LoadAnnouncements();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            ClearForm();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAnnouncements();
        }

        private void ClearForm()
        {
            txtId.Text = "";
            txtTitle.Text = "";
            txtMessage.Text = "";
            chkIsActive.Checked = true;
        }
    }
}