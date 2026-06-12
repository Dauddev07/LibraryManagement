namespace App.WindowsApp.Forms
{
    partial class BookIssueForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblBook = new Label();
            txtBookId = new TextBox();
            txtBookTitle = new TextBox();
            btnPickBook = new Button();
            lblMember = new Label();
            txtMemberId = new TextBox();
            txtMemberName = new TextBox();
            btnPickMember = new Button();
            lblIssueDate = new Label();
            dtpIssueDate = new DateTimePicker();
            lblReturnDate = new Label();
            dtpReturnDate = new DateTimePicker();
            lblReturnDateNA = new Label();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblBook
            // 
            lblBook.AutoSize = true;
            lblBook.Location = new Point(20, 25);
            lblBook.Name = "lblBook";
            lblBook.Size = new Size(52, 23);
            lblBook.TabIndex = 0;
            lblBook.Text = "Book:";
            // 
            // txtBookId
            // 
            txtBookId.Location = new Point(110, 22);
            txtBookId.Name = "txtBookId";
            txtBookId.ReadOnly = true;
            txtBookId.Size = new Size(100, 30);
            txtBookId.TabIndex = 1;
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(220, 22);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.ReadOnly = true;
            txtBookTitle.Size = new Size(170, 30);
            txtBookTitle.TabIndex = 2;
            // 
            // btnPickBook
            // 
            btnPickBook.Location = new Point(400, 20);
            btnPickBook.Name = "btnPickBook";
            btnPickBook.Size = new Size(60, 30);
            btnPickBook.TabIndex = 3;
            btnPickBook.Text = "Pick";
            btnPickBook.Click += btnPickBook_Click;
            // 
            // lblMember
            // 
            lblMember.AutoSize = true;
            lblMember.Location = new Point(20, 65);
            lblMember.Name = "lblMember";
            lblMember.Size = new Size(78, 23);
            lblMember.TabIndex = 4;
            lblMember.Text = "Member:";
            // 
            // txtMemberId
            // 
            txtMemberId.Location = new Point(110, 62);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.ReadOnly = true;
            txtMemberId.Size = new Size(100, 30);
            txtMemberId.TabIndex = 5;
            // 
            // txtMemberName
            // 
            txtMemberName.Location = new Point(220, 62);
            txtMemberName.Name = "txtMemberName";
            txtMemberName.ReadOnly = true;
            txtMemberName.Size = new Size(170, 30);
            txtMemberName.TabIndex = 6;
            // 
            // btnPickMember
            // 
            btnPickMember.Location = new Point(400, 60);
            btnPickMember.Name = "btnPickMember";
            btnPickMember.Size = new Size(60, 30);
            btnPickMember.TabIndex = 7;
            btnPickMember.Text = "Pick";
            btnPickMember.Click += btnPickMember_Click;
            // 
            // lblIssueDate
            // 
            lblIssueDate.AutoSize = true;
            lblIssueDate.Location = new Point(20, 105);
            lblIssueDate.Name = "lblIssueDate";
            lblIssueDate.Size = new Size(93, 23);
            lblIssueDate.TabIndex = 8;
            lblIssueDate.Text = "Issue Date:";
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Location = new Point(123, 105);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new Size(337, 30);
            dtpIssueDate.TabIndex = 9;
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Location = new Point(20, 145);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(106, 23);
            lblReturnDate.TabIndex = 10;
            lblReturnDate.Text = "Return Date:";
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Location = new Point(123, 142);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(337, 30);
            dtpReturnDate.TabIndex = 11;
            // 
            // lblReturnDateNA
            // 
            lblReturnDateNA.AutoSize = true;
            lblReturnDateNA.ForeColor = Color.Gray;
            lblReturnDateNA.Location = new Point(110, 148);
            lblReturnDateNA.Name = "lblReturnDateNA";
            lblReturnDateNA.Size = new Size(41, 23);
            lblReturnDateNA.TabIndex = 16;
            lblReturnDateNA.Text = "N/A";
            lblReturnDateNA.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(20, 185);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 23);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(123, 182);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(337, 31);
            cmbStatus.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(22, 33, 62);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.save;
            btnSave.Location = new Point(123, 230);
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
            btnCancel.Location = new Point(256, 230);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.Click += btnCancel_Click;
            // 
            // BookIssueForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 290);
            Controls.Add(lblBook);
            Controls.Add(txtBookId);
            Controls.Add(txtBookTitle);
            Controls.Add(btnPickBook);
            Controls.Add(lblMember);
            Controls.Add(txtMemberId);
            Controls.Add(txtMemberName);
            Controls.Add(btnPickMember);
            Controls.Add(lblIssueDate);
            Controls.Add(dtpIssueDate);
            Controls.Add(lblReturnDate);
            Controls.Add(dtpReturnDate);
            Controls.Add(lblReturnDateNA);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookIssueForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Issue Book";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblBook, lblMember, lblIssueDate, lblReturnDate, lblStatus;
        private Label lblReturnDateNA;   // FIX #6
        private TextBox txtBookId, txtBookTitle, txtMemberId, txtMemberName;
        private Button btnPickBook, btnPickMember, btnSave, btnCancel;
        private DateTimePicker dtpIssueDate, dtpReturnDate;
        private ComboBox cmbStatus;
    }
}