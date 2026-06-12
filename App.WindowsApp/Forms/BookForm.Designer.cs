namespace App.WindowsApp.Forms
{
    partial class BookForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblId = new Label();
            txtId = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblAuthor = new Label();
            txtAuthor = new TextBox();
            lblISBN = new Label();
            txtISBN = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblStock = new Label();
            numStock = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(30, 25);
            lblId.Name = "lblId";
            lblId.Size = new Size(31, 23);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Location = new Point(130, 22);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(250, 30);
            txtId.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 65);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(46, 23);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(130, 62);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(250, 30);
            txtTitle.TabIndex = 3;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(30, 105);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(67, 23);
            lblAuthor.TabIndex = 4;
            lblAuthor.Text = "Author:";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(130, 102);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(250, 30);
            txtAuthor.TabIndex = 5;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(30, 145);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(51, 23);
            lblISBN.TabIndex = 6;
            lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(130, 142);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(250, 30);
            txtISBN.TabIndex = 7;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(30, 185);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(83, 23);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(130, 182);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(250, 31);
            cmbCategory.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 225);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 23);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(130, 222);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(250, 31);
            cmbStatus.TabIndex = 11;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(30, 265);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(54, 23);
            lblStock.TabIndex = 12;
            lblStock.Text = "Stock:";
            // 
            // numStock
            // 
            numStock.Location = new Point(130, 262);
            numStock.Name = "numStock";
            numStock.Size = new Size(250, 30);
            numStock.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(22, 33, 62);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.save;
            btnSave.Location = new Point(130, 310);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.Location = new Point(250, 310);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.Click += btnCancel_Click;
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 370);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblAuthor);
            Controls.Add(txtAuthor);
            Controls.Add(lblISBN);
            Controls.Add(txtISBN);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(lblStock);
            Controls.Add(numStock);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Book Form";
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblId, lblTitle, lblAuthor, lblISBN, lblCategory, lblStatus, lblStock;
        private TextBox txtId, txtTitle, txtAuthor, txtISBN;
        private ComboBox cmbCategory, cmbStatus;
        private NumericUpDown numStock;
        private Button btnSave, btnCancel;
    }
}
