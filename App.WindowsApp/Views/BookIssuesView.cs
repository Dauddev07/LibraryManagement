using App.Core.Contracts;
using App.Core.Models;
using App.Core.Utilities;
using App.WindowsApp.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace App.WindowsApp.Views
{
    public partial class BookIssuesView : UserControl
    {
        private readonly IBookIssueService _issueService;
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private BindingSource _bindingSource = new BindingSource();

        public BookIssuesView(IBookIssueService issueService, IBookService bookService,
            IMemberService memberService)
        {
            _issueService = issueService;
            _bookService = bookService;
            _memberService = memberService;
            InitializeComponent();
            dgvIssues.DataSource = _bindingSource;

            dgvIssues.DataBindingComplete += (s, e) =>
            {
                if (dgvIssues.Columns.Contains("ReturnDate"))
                    dgvIssues.Columns["ReturnDate"].DefaultCellStyle.NullValue = "N/A";
            };

            cmbStatusFilter.Items.Clear();
            var statuses = new List<object> { "--ALL--" };
            statuses.AddRange(Enum.GetValues(typeof(IssueStatusEnum)).Cast<object>());
            cmbStatusFilter.DataSource = statuses;
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void BookIssuesView_Load(object sender, EventArgs e)
        {
            LoadIssues();
        }

        private void LoadIssues()
        {
            try
            {
                var issues = _issueService.GetAll();
                _bindingSource.DataSource = issues;
                RefreshChart(issues);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading issues: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshChart(List<BookIssue> issues)
        {
            chartIssues.Series.Clear();
            chartIssues.ChartAreas.Clear();
            chartIssues.Titles.Clear();
            chartIssues.Legends.Clear();

            var chartArea = new ChartArea("MainArea");
            chartArea.BackColor = System.Drawing.Color.White;
            chartArea.InnerPlotPosition = new ElementPosition(5, 5, 70, 80);
            chartIssues.ChartAreas.Add(chartArea);

            chartIssues.Titles.Add(new Title(
                "Book Issue Status Distribution",
                Docking.Top,
                new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                System.Drawing.Color.FromArgb(52, 73, 94)));

            var legend = new Legend("MainLegend");
            legend.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend.Docking = Docking.Bottom;
            chartIssues.Legends.Add(legend);

            var series = new Series("IssueStatus");
            series.ChartType = SeriesChartType.Pie;
            series.Legend = "MainLegend";
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0} ({P0})";
            series.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";

            int issued = issues.Count(i => i.Status == IssueStatusEnum.Issued);
            int returned = issues.Count(i => i.Status == IssueStatusEnum.Returned);
            int overdue = issues.Count(i => i.Status == IssueStatusEnum.Overdue);

            if (issued > 0) { var pt = series.Points.Add(issued); pt.LegendText = $"Issued ({issued})"; pt.Color = System.Drawing.Color.FromArgb(155, 89, 182); }
            if (returned > 0) { var pt = series.Points.Add(returned); pt.LegendText = $"Returned ({returned})"; pt.Color = System.Drawing.Color.FromArgb(46, 204, 113); }
            if (overdue > 0) { var pt = series.Points.Add(overdue); pt.LegendText = $"Overdue ({overdue})"; pt.Color = System.Drawing.Color.FromArgb(231, 76, 60); }

            if (issued == 0 && returned == 0 && overdue == 0)
            {
                var pt = series.Points.Add(1);
                pt.LegendText = "No Data";
                pt.Color = System.Drawing.Color.LightGray;
                pt.Label = "No issue records yet";
            }

            chartIssues.Series.Add(series);
        }

        private void tsbIssueBook_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new BookIssueForm(_issueService, _bookService, _memberService);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadIssues();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error issuing book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbReturnBook_Click(object sender, EventArgs e)
        {
            BookIssue selected = _bindingSource.Current as BookIssue;
            if (selected == null)
            {
                MessageBox.Show("Please select an issue record.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selected.Status == IssueStatusEnum.Returned)
            {
                MessageBox.Show("This book is already returned.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var confirm = MessageBox.Show($"Mark \"{selected.BookTitle}\" as Returned?",
                    "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    selected.Status = IssueStatusEnum.Returned;
                    selected.ReturnDate = DateTime.Now;
                    _issueService.Update(selected);
                    MessageBox.Show("Book returned successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadIssues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                BookIssue selected = _bindingSource.Current as BookIssue;
                if (selected != null)
                {
                    var form = new BookIssueForm(_issueService, _bookService, _memberService, selected);
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadIssues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing issue: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            try
            {
                BookIssue selected = _bindingSource.Current as BookIssue;
                if (selected == null)
                {
                    MessageBox.Show("Please select an issue record.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var form = new BookIssueForm(_issueService, _bookService, _memberService, selected, isViewOnly: true);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing issue: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            BookIssue selected = _bindingSource.Current as BookIssue;
            if (selected == null) return;

            try
            {
                if (selected.Status == IssueStatusEnum.Issued || selected.Status == IssueStatusEnum.Overdue)
                {
                    MessageBox.Show(
                        $"Cannot delete this record — \"{selected.BookTitle}\" is currently {selected.Status}.\n" +
                        "Please return the book first before deleting the record.",
                        "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Delete this issue record?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    _issueService.Delete(selected.Id);
                    LoadIssues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting issue: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e) => LoadIssues();

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbStatusFilter.SelectedItem == null || cmbStatusFilter.SelectedItem.ToString() == "--ALL--")
                {
                    LoadIssues();
                }
                else
                {
                    var issues = _issueService.GetByStatus((IssueStatusEnum)cmbStatusFilter.SelectedItem);
                    _bindingSource.DataSource = issues;
                    RefreshChart(issues);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering issues: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}