using App.Core.Contracts;
using App.Core.Models;

namespace App.WindowsApp.Forms
{
    public partial class MemberPicker : Form
    {
        private readonly IMemberService _memberService;
        private BindingSource _bindingSource;
        public Member SelectedMember { get; private set; }

        public MemberPicker(IMemberService service)
        {
            InitializeComponent();
            _memberService = service;
            _bindingSource = new BindingSource();
            lsMembers.DataSource = _bindingSource;
            LoadMembers(string.Empty);
        }

        private void LoadMembers(string query)
        {
            var members = string.IsNullOrWhiteSpace(query)
                ? _memberService.GetAll()
                : _memberService.Search(query);
            _bindingSource.DataSource = members;
            lsMembers.DisplayMember = "Name";
            lsMembers.ValueMember = "Id";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMembers(txtSearch.Text);
        }

        private void SelectMember()
        {
            if (lsMembers.SelectedItem != null && lsMembers.SelectedItem is Member)
            {
                SelectedMember = (Member)lsMembers.SelectedItem;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a member", "Member Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e) => SelectMember();
        private void lsMembers_DoubleClick(object sender, EventArgs e) => SelectMember();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
