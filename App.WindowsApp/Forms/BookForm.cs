using App.Core.Contracts;
using App.Core.Models;
using App.Core.Utilities;
using System.Text.RegularExpressions;

namespace App.WindowsApp.Forms
{
    public partial class BookForm : Form
    {
        private BookFormModeEnum _mode;
        private Book _book;
        private IBookService _service;
        private IBookIssueService _issueService;

        public BookForm(BookFormModeEnum mode, Book? book, IBookService service, IBookIssueService issueService)
        {
            InitializeComponent();

            numStock.Maximum = int.MaxValue;

            cmbCategory.Items.Clear();
            cmbCategory.DataSource = Enum.GetValues(typeof(BookCategoryEnum));
            cmbCategory.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.DataSource = Enum.GetValues(typeof(BookStatusEnum));
            cmbStatus.SelectedIndex = 0;

            _mode = mode;
            _book = book;
            _service = service;
            _issueService = issueService;

            if (mode == BookFormModeEnum.Edit)
            {
                btnSave.Text = "Update";
                this.Text = "Edit Book";
            }
            else if (mode == BookFormModeEnum.View)
            {
                btnSave.Visible = false;
                this.Text = "View Book";
            }
            else
            {
                this.Text = "Add Book";
                lblId.Visible = false;
                txtId.Visible = false;
            }

            if (mode == BookFormModeEnum.Edit || mode == BookFormModeEnum.View)
            {
                txtId.Text = book.Id;
                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                txtISBN.Text = book.ISBN;
                cmbCategory.SelectedItem = book.Category;
                numStock.Value = book.Stock;
                cmbStatus.SelectedItem = book.Status;
            }

            if (mode == BookFormModeEnum.View)
            {
                txtTitle.ReadOnly = true;
                txtAuthor.ReadOnly = true;
                txtISBN.ReadOnly = true;
                cmbCategory.Enabled = false;
                cmbStatus.Enabled = false;
                numStock.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Author cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthor.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                string isbnClean = txtISBN.Text.Replace("-", "").Replace(" ", "").Trim();
                if (!Regex.IsMatch(isbnClean, @"^[0-9]{10}([0-9]{3})?$"))
                {
                    MessageBox.Show("ISBN must be 10 or 13 digits.\nExample: 978-3-16-148410-0",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtISBN.Focus();
                    return false;
                }
            }
            if (numStock.Value < 0)
            {
                MessageBox.Show("Stock cannot be negative.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numStock.Focus();
                return false;
            }

            var status = (BookStatusEnum)cmbStatus.SelectedItem;
            int stock = (int)numStock.Value;

            // ── Add mode validations ──────────────────────────────────────────
            if (_mode == BookFormModeEnum.Add)
            {
                if (stock == 0)
                {
                    MessageBox.Show("Stock must be at least 1 when adding a book.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numStock.Focus();
                    return false;
                }
                if (status == BookStatusEnum.Issued)
                {
                    MessageBox.Show("Status cannot be Issued for a new book.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return false;
                }
            }

            // ── Edit mode validations ─────────────────────────────────────────
            if (_mode == BookFormModeEnum.Edit)
            {
                var activeIssues = _issueService.GetAll()
                    .Where(i => i.BookId == _book.Id &&
                                (i.Status == IssueStatusEnum.Issued || i.Status == IssueStatusEnum.Overdue))
                    .ToList();

                if (stock == 0)
                {
                    if (activeIssues.Count > 0)
                    {
                        // Copies are still out — status must be Issued
                        // 1 or more book is issued and we are setting stock to 0
                        if (status != BookStatusEnum.Issued)
                        {
                            MessageBox.Show(
                                $"{activeIssues.Count} copy/copies still issued to members. Status must be Issued, or return the book first.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbStatus.Focus();
                            return false;
                        }
                        // Confirm removing remaining copies
                        int remaining = (int)_book.Stock - activeIssues.Count;
                        if (remaining > 0)
                        {
                            var confirm = MessageBox.Show(
                                $"{activeIssues.Count} issued, {remaining} will be removed. Continue?",
                                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (confirm != DialogResult.Yes) return false;
                        }
                    }
                    else
                    {
                        // No copies issued — Issued status makes no sense
                        if (status == BookStatusEnum.Issued)
                        {
                            MessageBox.Show("Stock is 0 and no copies are issued. Status cannot be Issued.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbStatus.Focus();
                            return false;
                        }
                        // Available makes no sense either with 0 stock
                        if (status == BookStatusEnum.Available)
                        {
                            MessageBox.Show("Stock is 0, status cannot be Available.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbStatus.Focus();
                            return false;
                        }
                        // Only Lost is valid here — confirm
                        var confirm = MessageBox.Show(
                            "No copies issued. Mark as Lost?",
                            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirm != DialogResult.Yes) return false;
                    }
                }
                else
                {
                    // Stock > 0 — Issued is not allowed manually
                    if (status == BookStatusEnum.Issued)
                    {
                        MessageBox.Show("Stock is available, cannot set status to Issued.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbStatus.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            try
            {
                if (_mode == BookFormModeEnum.Add)
                {
                    Book newBook = new Book();
                    newBook.Title = txtTitle.Text.Trim();
                    newBook.Author = txtAuthor.Text.Trim();
                    newBook.ISBN = txtISBN.Text.Trim();
                    newBook.Category = (BookCategoryEnum)cmbCategory.SelectedItem;
                    newBook.Stock = (int)numStock.Value;
                    newBook.Status = (BookStatusEnum)cmbStatus.SelectedItem;

                    Book temp = _service.Add(newBook);
                    txtId.Text = temp?.Id ?? "";
                    MessageBox.Show("Book added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_mode == BookFormModeEnum.Edit)
                {
                    _book.Title = txtTitle.Text.Trim();
                    _book.Author = txtAuthor.Text.Trim();
                    _book.ISBN = txtISBN.Text.Trim();
                    _book.Category = (BookCategoryEnum)cmbCategory.SelectedItem;
                    _book.Stock = (int)numStock.Value;
                    _book.Status = (BookStatusEnum)cmbStatus.SelectedItem;

                    _service.Update(_book);
                    MessageBox.Show("Book updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving book: {ex.Message}", "Error",
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