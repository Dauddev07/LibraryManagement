namespace App.WindowsApp.Forms
{
    partial class MemberPicker
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSearch = new Label();
            txtSearch = new TextBox();
            lsMembers = new ListBox();
            btnSelect = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(15, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(65, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(80, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(270, 30);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lsMembers
            // 
            lsMembers.Location = new Point(15, 50);
            lsMembers.Name = "lsMembers";
            lsMembers.Size = new Size(335, 234);
            lsMembers.TabIndex = 2;
            lsMembers.DoubleClick += lsMembers_DoubleClick;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.FromArgb(22, 33, 62);
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.ForeColor = Color.White;
            btnSelect.Image = Properties.Resources.add;
            btnSelect.Location = new Point(80, 310);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(100, 35);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "Select";
            btnSelect.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.Location = new Point(200, 310);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.Click += btnCancel_Click;
            // 
            // MemberPicker
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 360);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(lsMembers);
            Controls.Add(btnSelect);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MemberPicker";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Member";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblSearch;
        private TextBox txtSearch;
        private ListBox lsMembers;
        private Button btnSelect, btnCancel;
    }
}
