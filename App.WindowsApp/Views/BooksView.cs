using App.Core.Contracts;
using App.Core.Models;
using App.Core.Utilities;
using App.WindowsApp.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace App.WindowsApp.Views
{
    public partial class BooksView : UserControl
    {
        private readonly IBookService _bookService;
        private readonly IBookIssueService _issueService;
        private BindingSource _bindingSource = new BindingSource();

        public BooksView(IBookService service, IBookIssueService issueService)
        {
            _bookService = service;
            _issueService = issueService;
            InitializeComponent();
            dgvBooks.DataSource = _bindingSource;
        }

        private void BooksView_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Clear();
            var categories = new List<object> { "--ALL--" };
            categories.AddRange(Enum.GetValues(typeof(BookCategoryEnum)).Cast<object>());
            cmbCategory.DataSource = categories;
            cmbCategory.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            var statuses = new List<object> { "--ALL--" };
            statuses.AddRange(Enum.GetValues(typeof(BookStatusEnum)).Cast<object>());
            cmbStatus.DataSource = statuses;
            cmbStatus.SelectedIndex = 0;

            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                var books = _bookService.GetAll();
                _bindingSource.DataSource = books;
                RefreshChart(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            try
            {
                string searchText = txtSearch.Text;

                BookCategoryEnum? selectedCategory = null;
                if (cmbCategory.SelectedItem != null && !cmbCategory.SelectedItem.ToString().Equals("--ALL--"))
                    selectedCategory = (BookCategoryEnum)cmbCategory.SelectedItem;

                BookStatusEnum? selectedStatus = null;
                if (cmbStatus.SelectedItem != null && !cmbStatus.SelectedItem.ToString().Equals("--ALL--"))
                    selectedStatus = (BookStatusEnum)cmbStatus.SelectedItem;

                var books = _bookService.Search(searchText, selectedCategory, selectedStatus);
                _bindingSource.DataSource = books;
                RefreshChart(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching books: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshChart(List<Book> books)
        {
            chartBooks.Series.Clear();
            chartBooks.ChartAreas.Clear();
            chartBooks.Titles.Clear();
            chartBooks.Legends.Clear();

            var chartArea = new ChartArea("MainArea");
            chartArea.BackColor = System.Drawing.Color.White;
            chartArea.InnerPlotPosition = new ElementPosition(5, 5, 70, 80);
            chartBooks.ChartAreas.Add(chartArea);

            chartBooks.Titles.Add(new Title(
                "Book Status Distribution",
                Docking.Top,
                new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                System.Drawing.Color.FromArgb(52, 73, 94)));

            var legend = new Legend("MainLegend");
            legend.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend.Docking = Docking.Bottom;
            chartBooks.Legends.Add(legend);

            var series = new Series("BookStatus");
            series.ChartType = SeriesChartType.Pie;
            series.Legend = "MainLegend";
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0} ({P0})";
            series.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";

            int available = books.Count(b => b.Status == BookStatusEnum.Available);
            int issued = books.Count(b => b.Status == BookStatusEnum.Issued);
            int lost = books.Count(b => b.Status == BookStatusEnum.Lost);

            if (available > 0) { var pt = series.Points.Add(available); pt.LegendText = $"Available ({available})"; pt.Color = System.Drawing.Color.FromArgb(46, 204, 113); }
            if (issued > 0) { var pt = series.Points.Add(issued); pt.LegendText = $"Issued ({issued})"; pt.Color = System.Drawing.Color.FromArgb(155, 89, 182); }
            if (lost > 0) { var pt = series.Points.Add(lost); pt.LegendText = $"Lost ({lost})"; pt.Color = System.Drawing.Color.FromArgb(231, 76, 60); }

            if (available == 0 && issued == 0 && lost == 0)
            {
                var pt = series.Points.Add(1);
                pt.LegendText = "No Data";
                pt.Color = System.Drawing.Color.LightGray;
                pt.Label = "No books yet";
            }

            chartBooks.Series.Add(series);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new BookForm(BookFormModeEnum.Add, null, _bookService, _issueService);
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Book selected = _bindingSource.Current as Book;
                if (selected != null)
                {
                    var form = new BookForm(BookFormModeEnum.Edit, selected, _bookService, _issueService);
                    if (form.ShowDialog() == DialogResult.OK)
                        RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            try
            {
                Book selected = _bindingSource.Current as Book;
                if (selected != null)
                {
                    var form = new BookForm(BookFormModeEnum.View, selected, _bookService, _issueService);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            Book selected = _bindingSource.Current as Book;
            if (selected == null) return;

            try
            {
                var allIssues = _issueService.GetAll()
                    .Where(i => i.BookId == selected.Id)
                    .ToList();

                var activeIssues = allIssues
                    .Where(i => i.Status == IssueStatusEnum.Issued || i.Status == IssueStatusEnum.Overdue)
                    .ToList();

                if (activeIssues.Count > 0)
                {
                    // Book is currently issued — specific warning
                    MessageBox.Show(
                        $"Cannot delete \"{selected.Title}\".\n\n" +
                        $"{activeIssues.Count} copy/copies are currently issued out.\n" +
                        "Please return those books first before deleting.",
                        "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (allIssues.Count > 0)
                {
                    // Book has past/returned issue history — block due to FK
                    MessageBox.Show(
                        $"Cannot delete \"{selected.Title}\".\n\n" +
                        $"This book has {allIssues.Count} issue record(s) in history.\n" +
                        "Please delete those issue records first, then try again.",
                        "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this book?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    _bookService.Delete(selected.Id);
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e) => LoadBooks();
        private void txtSearch_TextChanged(object sender, EventArgs e) => RefreshGrid();
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => RefreshGrid();
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) => RefreshGrid();
    }
}