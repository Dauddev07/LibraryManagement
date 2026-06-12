using App.Core.Contracts;
using App.Core.Models;
using System.Text.RegularExpressions;

namespace App.WindowsApp.Forms
{
    public partial class MemberForm : Form
    {
        private IMemberService _memberService;
        private MemberFormModeEnum _mode;
        private Member _member;

        public MemberForm(IMemberService service, MemberFormModeEnum mode, Member member = null)
        {
            InitializeComponent();
            _memberService = service;
            _mode = mode;
            _member = member ?? new Member();
            PopulateFields();
            SetupMode();
        }

        private void PopulateFields()
        {
            txtId.Text = _member.Id;
            txtName.Text = _member.Name;
            txtPhone.Text = _member.Phone;
            txtEmail.Text = _member.Email;
            txtAddress.Text = _member.Address;
        }

        private void SetupMode()
        {
            switch (_mode)
            {
                case MemberFormModeEnum.Add:
                    this.Text = "Add Member";
                    lblId.Visible = false;
                    txtId.Visible = false;
                    break;
                case MemberFormModeEnum.Edit:
                    this.Text = "Edit Member";
                    btnSave.Text = "Update";
                    break;
                case MemberFormModeEnum.View:
                    this.Text = "View Member";
                    txtName.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtAddress.ReadOnly = true;
                    btnSave.Visible = false;
                    break;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Name must be at least 2 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^\+?[0-9]{7,15}$"))
            {
                MessageBox.Show("Phone must be 7-15 digits only.\nExample: 03001234567",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email format is invalid.\nExample: user@example.com",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    _member.Name = txtName.Text.Trim();
                    _member.Phone = txtPhone.Text.Trim();
                    _member.Email = txtEmail.Text.Trim();
                    _member.Address = txtAddress.Text.Trim();

                    if (_mode == MemberFormModeEnum.Add)
                    {
                        _memberService.Add(_member);
                        MessageBox.Show("Member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _memberService.Update(_member);
                        MessageBox.Show("Member updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}