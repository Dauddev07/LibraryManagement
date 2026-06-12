using App.Core.Contracts;
using App.Core.Models;
using App.Core.Utilities;

namespace App.WindowsApp.Forms
{
    public partial class BookPicker : Form
    {
        private readonly IBookService _bookService;
        private BindingSource _bindingSource;
        public Book SelectedBook { get; private set; }

        public BookPicker(IBookService service)
        {
            InitializeComponent();
            _bookService = service;
            _bindingSource = new BindingSource();
            lsBooks.DataSource = _bindingSource;
            LoadBooks(string.Empty);
        }

        private void LoadBooks(string query)
        {
            var books = string.IsNullOrWhiteSpace(query)
                ? _bookService.GetAll()
                : _bookService.Search(query, null, null);

            // Only show Available books with stock > 0
            _bindingSource.DataSource = books
                .Where(b => b.Status == BookStatusEnum.Available && b.Stock > 0)
                .ToList();

            lsBooks.DisplayMember = "Title";
            lsBooks.ValueMember = "Id";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooks(txtSearch.Text);
        }

        private void SelectBook()
        {
            if (lsBooks.SelectedItem != null && lsBooks.SelectedItem is Book)
            {
                SelectedBook = (Book)lsBooks.SelectedItem;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a book", "Book Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e) => SelectBook();
        private void lsBooks_DoubleClick(object sender, EventArgs e) => SelectBook();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}