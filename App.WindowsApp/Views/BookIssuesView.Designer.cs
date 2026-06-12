namespace App.WindowsApp.Views
{
    partial class BookIssuesView
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            toolStrip = new ToolStrip();
            tsbIssueBook = new ToolStripButton();
            tsbReturnBook = new ToolStripButton();
            tsbEdit = new ToolStripButton();
            tsbView = new ToolStripButton();
            tsbDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbRefresh = new ToolStripButton();
            pnlFilter = new Panel();
            lblStatus = new Label();
            cmbStatusFilter = new ComboBox();
            dgvIssues = new DataGridView();
            chartIssues = new System.Windows.Forms.DataVisualization.Charting.Chart();
            toolStrip.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIssues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartIssues).BeginInit();
            SuspendLayout();
            //
            // toolStrip
            //
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbIssueBook, tsbReturnBook, tsbEdit, tsbView, tsbDelete, toolStripSeparator2, tsbRefresh });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(700, 27);
            toolStrip.TabIndex = 2;
            //
            // tsbIssueBook
            //
            tsbIssueBook.Image = Properties.Resources.book_issue;
            tsbIssueBook.Name = "tsbIssueBook";
            tsbIssueBook.Size = new Size(103, 24);
            tsbIssueBook.Text = "Issue Book";
            tsbIssueBook.Click += tsbIssueBook_Click;
            //
            // tsbReturnBook
            //
            tsbReturnBook.Image = Properties.Resources.book_return;
            tsbReturnBook.Name = "tsbReturnBook";
            tsbReturnBook.Size = new Size(114, 24);
            tsbReturnBook.Text = "Return Book";
            tsbReturnBook.Click += tsbReturnBook_Click;
            //
            // tsbEdit
            //
            tsbEdit.Image = Properties.Resources.edit;
            tsbEdit.Name = "tsbEdit";
            tsbEdit.Size = new Size(59, 24);
            tsbEdit.Text = "Edit";
            tsbEdit.Click += tsbEdit_Click;
            //
            // tsbView
            //
            tsbView.Image = Properties.Resources.view;
            tsbView.Name = "tsbView";
            tsbView.Size = new Size(65, 24);
            tsbView.Text = "View";
            tsbView.Click += tsbView_Click;
            //
            // tsbDelete
            //
            tsbDelete.Image = Properties.Resources.delete;
            tsbDelete.Name = "tsbDelete";
            tsbDelete.Size = new Size(77, 24);
            tsbDelete.Text = "Delete";
            tsbDelete.Click += tsbDelete_Click;
            //
            // toolStripSeparator2
            //
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            //
            // tsbRefresh
            //
            tsbRefresh.Image = Properties.Resources.refresh;
            tsbRefresh.Name = "tsbRefresh";
            tsbRefresh.Size = new Size(82, 24);
            tsbRefresh.Text = "Refresh";
            tsbRefresh.Click += tsbRefresh_Click;
            //
            // pnlFilter
            //
            pnlFilter.Controls.Add(lblStatus);
            pnlFilter.Controls.Add(cmbStatusFilter);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 27);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(700, 45);
            pnlFilter.TabIndex = 1;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 13);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(89, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Filter Status:";
            //
            // cmbStatusFilter
            //
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Location = new Point(100, 10);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(180, 28);
            cmbStatusFilter.TabIndex = 1;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            //
            // dgvIssues
            //
            dgvIssues.AllowUserToAddRows = false;
            dgvIssues.AllowUserToDeleteRows = false;
            dgvIssues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIssues.BackgroundColor = Color.White;
            dgvIssues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIssues.Location = new Point(0, 72);
            dgvIssues.Name = "dgvIssues";
            dgvIssues.ReadOnly = true;
            dgvIssues.RowHeadersVisible = false;
            dgvIssues.RowHeadersWidth = 51;
            dgvIssues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIssues.Size = new Size(700, 280);
            dgvIssues.TabIndex = 0;
            //
            // chartIssues
            //
            chartIssues.Location = new Point(0, 355);
            chartIssues.Name = "chartIssues";
            chartIssues.Size = new Size(700, 280);
            chartIssues.TabIndex = 3;
            chartIssues.BackColor = System.Drawing.Color.White;
            //
            // BookIssuesView
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(chartIssues);
            Controls.Add(dgvIssues);
            Controls.Add(pnlFilter);
            Controls.Add(toolStrip);
            Font = new Font("Segoe UI", 9F);
            Name = "BookIssuesView";
            Size = new Size(700, 650);
            this.Load += new System.EventHandler(this.BookIssuesView_Load);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIssues).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartIssues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton tsbIssueBook, tsbReturnBook, tsbEdit, tsbView, tsbDelete, tsbRefresh;
        private Panel pnlFilter;
        private Label lblStatus;
        private ComboBox cmbStatusFilter;
        private DataGridView dgvIssues;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIssues;
        private ToolStripSeparator toolStripSeparator2;
    }
}