namespace LibraryManagementSystem
{
    partial class UsersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvUsers;
        private LibraryManagementSystem.SectionBox secUserDetails;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblRoleGuide;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            dgvUsers = new DataGridView();
            secUserDetails = new SectionBox();
            lblRoleGuide = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnResetPassword = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            chkIsActive = new CheckBox();
            cmbRole = new ComboBox();
            lblRole = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            secUserDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.BackgroundImage = Properties.Resources.lib;
            pnlTop.Controls.Add(btnClose);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(4, 5, 4, 5);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1714, 100);
            pnlTop.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.PapayaWhip;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(194, 24, 91);
            btnClose.Location = new Point(1557, 20);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 60);
            btnClose.TabIndex = 1;
            btnClose.Text = "← Back";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.FlatStyle = FlatStyle.Popup;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 224, 192);
            lblTitle.Location = new Point(400, 35);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(637, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "User Account Management (Admin Only)";
            lblTitle.Click += lblTitle_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(29, 133);
            dgvUsers.Margin = new Padding(4, 5, 4, 5);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(1086, 1033);
            dgvUsers.TabIndex = 1;
            // 
            // secUserDetails
            // 
            secUserDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            secUserDetails.BackColor = Color.White;
            secUserDetails.BorderRadius = 12;
            secUserDetails.Controls.Add(lblRoleGuide);
            secUserDetails.Controls.Add(btnClear);
            secUserDetails.Controls.Add(btnDelete);
            secUserDetails.Controls.Add(btnResetPassword);
            secUserDetails.Controls.Add(btnUpdate);
            secUserDetails.Controls.Add(btnAdd);
            secUserDetails.Controls.Add(txtPassword);
            secUserDetails.Controls.Add(lblPassword);
            secUserDetails.Controls.Add(chkIsActive);
            secUserDetails.Controls.Add(cmbRole);
            secUserDetails.Controls.Add(lblRole);
            secUserDetails.Controls.Add(txtEmail);
            secUserDetails.Controls.Add(lblEmail);
            secUserDetails.Controls.Add(txtFullName);
            secUserDetails.Controls.Add(lblFullName);
            secUserDetails.Controls.Add(txtUsername);
            secUserDetails.Controls.Add(lblUsername);
            secUserDetails.HeaderColor = Color.FromArgb(233, 30, 99);
            secUserDetails.Location = new Point(1136, 133);
            secUserDetails.Margin = new Padding(4, 5, 4, 5);
            secUserDetails.Name = "secUserDetails";
            secUserDetails.Padding = new Padding(23, 75, 23, 27);
            secUserDetails.ShowHeaderBar = true;
            secUserDetails.Size = new Size(550, 1033);
            secUserDetails.TabIndex = 2;
            secUserDetails.Title = "User Account Credentials & Roles";
            secUserDetails.Paint += secUserDetails_Paint;
            // 
            // lblRoleGuide
            // 
            lblRoleGuide.BackColor = Color.FromArgb(255, 247, 250);
            lblRoleGuide.BorderStyle = BorderStyle.FixedSingle;
            lblRoleGuide.Font = new Font("Segoe UI", 8.5F);
            lblRoleGuide.ForeColor = Color.FromArgb(108, 117, 125);
            lblRoleGuide.Location = new Point(29, 808);
            lblRoleGuide.Margin = new Padding(4, 0, 4, 0);
            lblRoleGuide.Name = "lblRoleGuide";
            lblRoleGuide.Padding = new Padding(11, 13, 11, 13);
            lblRoleGuide.Size = new Size(492, 165);
            lblRoleGuide.TabIndex = 16;
            lblRoleGuide.Text = "ROLE HIERARCHY GUIDE:\n• Admin: Full system control, users & config.\n• Librarian: Catalog management, circulation, returns.\n• User: Self-service catalog search & my loans.";
            lblRoleGuide.Click += lblRoleGuide_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(108, 117, 125);
            btnClear.Location = new Point(29, 725);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(493, 50);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 235, 238);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(198, 40, 40);
            btnDelete.Location = new Point(286, 650);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(236, 57);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete User";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.White;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnResetPassword.ForeColor = Color.FromArgb(194, 24, 91);
            btnResetPassword.Location = new Point(29, 650);
            btnResetPassword.Margin = new Padding(4, 5, 4, 5);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(236, 57);
            btnResetPassword.TabIndex = 13;
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.FromArgb(233, 30, 99);
            btnUpdate.Location = new Point(286, 575);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(236, 60);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update User";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(233, 30, 99);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(29, 575);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(236, 60);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "+ Add User";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9.5F);
            txtPassword.Location = new Point(29, 433);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(491, 33);
            txtPassword.TabIndex = 10;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(43, 45, 66);
            lblPassword.Location = new Point(29, 400);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(182, 23);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password / New Pass:";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkIsActive.ForeColor = Color.FromArgb(46, 125, 50);
            chkIsActive.Location = new Point(29, 508);
            chkIsActive.Margin = new Padding(4, 5, 4, 5);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(261, 29);
            chkIsActive.TabIndex = 8;
            chkIsActive.Text = "Account Active && Enabled";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 9.5F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Librarian", "User" });
            cmbRole.Location = new Point(29, 333);
            cmbRole.Margin = new Padding(4, 5, 4, 5);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(491, 33);
            cmbRole.TabIndex = 7;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(43, 45, 66);
            lblRole.Location = new Point(29, 300);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(132, 23);
            lblRole.TabIndex = 6;
            lblRole.Text = "Hierarchy Role:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(29, 242);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(491, 33);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(43, 45, 66);
            lblEmail.Location = new Point(29, 212);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 23);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9.5F);
            txtFullName.Location = new Point(29, 158);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(491, 33);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(43, 45, 66);
            lblFullName.Location = new Point(29, 128);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(96, 23);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Full Name:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9.5F);
            txtUsername.Location = new Point(29, 80);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(491, 33);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(43, 45, 66);
            lblUsername.Location = new Point(29, 50);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(94, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 247, 250);
            BackgroundImage = Properties.Resources.lib;
            ClientSize = new Size(1714, 1170);
            Controls.Add(secUserDetails);
            Controls.Add(dgvUsers);
            Controls.Add(pnlTop);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1419, 963);
            Name = "UsersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management System - User Accounts";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            secUserDetails.ResumeLayout(false);
            secUserDetails.PerformLayout();
            ResumeLayout(false);
        }
    }
}

