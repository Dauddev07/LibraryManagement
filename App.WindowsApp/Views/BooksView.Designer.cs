namespace App.WindowsApp.Views
{
    partial class BooksView
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
            tsbAdd = new ToolStripButton();
            tsbEdit = new ToolStripButton();
            tsbView = new ToolStripButton();
            tsbDelete = new ToolStripButton();
            tsbRefresh = new ToolStripButton();
            pnlFilter = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            dgvBooks = new DataGridView();
            chartBooks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStrip.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartBooks).BeginInit();
            SuspendLayout();
            //
            // toolStrip
            //
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbAdd, tsbEdit, tsbView, tsbDelete, toolStripSeparator1, tsbRefresh });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(700, 27);
            toolStrip.TabIndex = 2;
            //
            // tsbAdd
            //
            tsbAdd.Image = Properties.Resources.add;
            tsbAdd.Name = "tsbAdd";
            tsbAdd.Size = new Size(61, 24);
            tsbAdd.Text = "Add";
            tsbAdd.Click += tsbAdd_Click;
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
            pnlFilter.Controls.Add(lblSearch);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(lblCategory);
            pnlFilter.Controls.Add(cmbCategory);
            pnlFilter.Controls.Add(lblStatus);
            pnlFilter.Controls.Add(cmbStatus);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 27);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(5);
            pnlFilter.Size = new Size(700, 45);
            pnlFilter.TabIndex = 1;
            //
            // lblSearch
            //
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 13);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            //
            // txtSearch
            //
            txtSearch.Location = new Point(65, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(180, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            //
            // lblCategory
            //
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(260, 13);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            //
            // cmbCategory
            //
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(330, 10);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(140, 28);
            cmbCategory.TabIndex = 3;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(485, 13);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status:";
            //
            // cmbStatus
            //
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(540, 10);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(140, 28);
            cmbStatus.TabIndex = 5;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            //
            // dgvBooks
            //
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(0, 72);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(700, 280);
            dgvBooks.TabIndex = 0;
            //
            // chartBooks
            //
            chartBooks.Location = new Point(0, 355);
            chartBooks.Name = "chartBooks";
            chartBooks.Size = new Size(700, 280);
            chartBooks.TabIndex = 3;
            chartBooks.BackColor = System.Drawing.Color.White;
            //
            // toolStripSeparator1
            //
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            //
            // BooksView
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(chartBooks);
            Controls.Add(dgvBooks);
            Controls.Add(pnlFilter);
            Controls.Add(toolStrip);
            Font = new Font("Segoe UI", 9F);
            Name = "BooksView";
            Size = new Size(700, 650);
            Load += BooksView_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton tsbAdd, tsbEdit, tsbView, tsbDelete, tsbRefresh;
        private Panel pnlFilter;
        private Label lblSearch, lblCategory, lblStatus;
        private TextBox txtSearch;
        private ComboBox cmbCategory, cmbStatus;
        private DataGridView dgvBooks;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBooks;
        private ToolStripSeparator toolStripSeparator1;
    }
}