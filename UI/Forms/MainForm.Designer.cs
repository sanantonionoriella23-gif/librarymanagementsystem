namespace LibraryManagementSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlSidebarBottom;
        private System.Windows.Forms.Label lblBrandTitle;
        private System.Windows.Forms.Label lblBrandSubtitle;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnBorrowReturn;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnScanQrSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblUserRoleBadge;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TableLayoutPanel tlpMetrics;
        private LibraryManagementSystem.CardButton cardTotalBooks;
        private LibraryManagementSystem.CardButton cardAvailableBooks;
        private LibraryManagementSystem.CardButton cardBorrowedBooks;
        private LibraryManagementSystem.CardButton cardOverdueBooks;
        private LibraryManagementSystem.CardButton cardTotalMembers;
        private LibraryManagementSystem.CardButton cardExtra;
        private LibraryManagementSystem.SectionBox secRecentActivity;
        private System.Windows.Forms.DataGridView dgvRecent;
        private System.Windows.Forms.Button btnRefreshStats;

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
            pnlSidebar = new Panel();
            btnScanQrSidebar = new Button();
            btnUsers = new Button();
            btnHistory = new Button();
            btnBorrowReturn = new Button();
            btnMembers = new Button();
            btnBooks = new Button();
            btnDashboard = new Button();
            lblBrandSubtitle = new Label();
            lblBrandTitle = new Label();
            pnlSidebarBottom = new Panel();
            btnLogout = new Button();
            pnlTopBar = new Panel();
            btnRefreshStats = new Button();
            lblCurrentUser = new Label();
            lblPageTitle = new Label();
            lblUserRoleBadge = new Label();
            pnlContent = new Panel();
            secRecentActivity = new SectionBox();
            dgvRecent = new DataGridView();
            tlpMetrics = new TableLayoutPanel();
            cardTotalBooks = new CardButton();
            cardAvailableBooks = new CardButton();
            cardBorrowedBooks = new CardButton();
            cardOverdueBooks = new CardButton();
            cardTotalMembers = new CardButton();
            cardExtra = new CardButton();
            pnlSidebar.SuspendLayout();
            pnlSidebarBottom.SuspendLayout();
            pnlTopBar.SuspendLayout();
            pnlContent.SuspendLayout();
            secRecentActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
            tlpMetrics.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(255, 224, 192);
            pnlSidebar.Controls.Add(btnScanQrSidebar);
            pnlSidebar.Controls.Add(btnUsers);
            pnlSidebar.Controls.Add(btnHistory);
            pnlSidebar.Controls.Add(btnBorrowReturn);
            pnlSidebar.Controls.Add(btnMembers);
            pnlSidebar.Controls.Add(btnBooks);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(lblBrandSubtitle);
            pnlSidebar.Controls.Add(lblBrandTitle);
            pnlSidebar.Controls.Add(pnlSidebarBottom);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(4, 5, 4, 5);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(343, 1170);
            pnlSidebar.TabIndex = 0;
            // 
            // btnScanQrSidebar
            // 
            btnScanQrSidebar.BackColor = Color.FromArgb(253, 237, 242);
            btnScanQrSidebar.FlatAppearance.BorderSize = 0;
            btnScanQrSidebar.FlatStyle = FlatStyle.Flat;
            btnScanQrSidebar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnScanQrSidebar.ForeColor = Color.FromArgb(173, 20, 87);
            btnScanQrSidebar.Location = new Point(15, 415);
            btnScanQrSidebar.Margin = new Padding(4, 5, 4, 5);
            btnScanQrSidebar.Name = "btnScanQrSidebar";
            btnScanQrSidebar.Size = new Size(312, 52);
            btnScanQrSidebar.TabIndex = 10;
            btnScanQrSidebar.Text = "📷 Scan Book QR Code";
            btnScanQrSidebar.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.White;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUsers.ForeColor = Color.FromArgb(30, 41, 59);
            btnUsers.Location = new Point(15, 335);
            btnUsers.Margin = new Padding(4, 5, 4, 5);
            btnUsers.Name = "btnUsers";
            btnUsers.Padding = new Padding(23, 0, 0, 0);
            btnUsers.Size = new Size(312, 48);
            btnUsers.TabIndex = 7;
            btnUsers.Text = "User Management";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.White;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnHistory.ForeColor = Color.FromArgb(30, 41, 59);
            btnHistory.Location = new Point(15, 273);
            btnHistory.Margin = new Padding(4, 5, 4, 5);
            btnHistory.Name = "btnHistory";
            btnHistory.Padding = new Padding(23, 0, 0, 0);
            btnHistory.Size = new Size(312, 48);
            btnHistory.TabIndex = 6;
            btnHistory.Text = "Transactions";
            btnHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnHistory.UseVisualStyleBackColor = true;
            // 
            // btnBorrowReturn
            // 
            btnBorrowReturn.BackColor = Color.White;
            btnBorrowReturn.FlatAppearance.BorderSize = 0;
            btnBorrowReturn.FlatStyle = FlatStyle.Flat;
            btnBorrowReturn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBorrowReturn.ForeColor = Color.FromArgb(30, 41, 59);
            btnBorrowReturn.Location = new Point(15, 149);
            btnBorrowReturn.Margin = new Padding(4, 5, 4, 5);
            btnBorrowReturn.Name = "btnBorrowReturn";
            btnBorrowReturn.Padding = new Padding(23, 0, 0, 0);
            btnBorrowReturn.Size = new Size(312, 48);
            btnBorrowReturn.TabIndex = 5;
            btnBorrowReturn.Text = "Borrow & Return";
            btnBorrowReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnBorrowReturn.UseMnemonic = false;
            btnBorrowReturn.UseVisualStyleBackColor = true;
            // 
            // btnMembers
            // 
            btnMembers.BackColor = Color.White;
            btnMembers.FlatAppearance.BorderSize = 0;
            btnMembers.FlatStyle = FlatStyle.Flat;
            btnMembers.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMembers.ForeColor = Color.FromArgb(30, 41, 59);
            btnMembers.Location = new Point(15, 211);
            btnMembers.Margin = new Padding(4, 5, 4, 5);
            btnMembers.Name = "btnMembers";
            btnMembers.Padding = new Padding(23, 0, 0, 0);
            btnMembers.Size = new Size(312, 48);
            btnMembers.TabIndex = 4;
            btnMembers.Text = "Members";
            btnMembers.TextAlign = ContentAlignment.MiddleLeft;
            btnMembers.UseVisualStyleBackColor = true;
            // 
            // btnBooks
            // 
            btnBooks.BackColor = Color.White;
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBooks.ForeColor = Color.FromArgb(30, 41, 59);
            btnBooks.Location = new Point(15, 87);
            btnBooks.Margin = new Padding(4, 5, 4, 5);
            btnBooks.Name = "btnBooks";
            btnBooks.Padding = new Padding(23, 0, 0, 0);
            btnBooks.Size = new Size(312, 48);
            btnBooks.TabIndex = 3;
            btnBooks.Text = "Books Catalog";
            btnBooks.TextAlign = ContentAlignment.MiddleLeft;
            btnBooks.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.White;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.FromArgb(173, 20, 87);
            btnDashboard.Location = new Point(15, 25);
            btnDashboard.Margin = new Padding(4, 5, 4, 5);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(23, 0, 0, 0);
            btnDashboard.Size = new Size(312, 48);
            btnDashboard.TabIndex = 2;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // lblBrandSubtitle
            // 
            lblBrandSubtitle.AutoSize = true;
            lblBrandSubtitle.Font = new Font("Segoe UI", 9F);
            lblBrandSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblBrandSubtitle.Location = new Point(26, 83);
            lblBrandSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(182, 25);
            lblBrandSubtitle.TabIndex = 1;
            lblBrandSubtitle.Text = "Administrative Center";
            lblBrandSubtitle.Visible = false;
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.FromArgb(173, 20, 87);
            lblBrandTitle.Location = new Point(23, 30);
            lblBrandTitle.Margin = new Padding(4, 0, 4, 0);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(211, 38);
            lblBrandTitle.TabIndex = 0;
            lblBrandTitle.Text = "Library System";
            lblBrandTitle.Visible = false;
            // 
            // pnlSidebarBottom
            // 
            pnlSidebarBottom.BackColor = Color.FromArgb(255, 224, 192);
            pnlSidebarBottom.Controls.Add(btnLogout);
            pnlSidebarBottom.Dock = DockStyle.Bottom;
            pnlSidebarBottom.Location = new Point(0, 1063);
            pnlSidebarBottom.Margin = new Padding(4, 5, 4, 5);
            pnlSidebarBottom.Name = "pnlSidebarBottom";
            pnlSidebarBottom.Padding = new Padding(17);
            pnlSidebarBottom.Size = new Size(343, 107);
            pnlSidebarBottom.TabIndex = 8;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(254, 242, 242);
            btnLogout.Dock = DockStyle.Fill;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(185, 28, 28);
            btnLogout.Location = new Point(17, 17);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(309, 73);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Sign Out";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.White;
            pnlTopBar.Controls.Add(btnRefreshStats);
            pnlTopBar.Controls.Add(lblCurrentUser);
            pnlTopBar.Controls.Add(lblPageTitle);
            pnlTopBar.Controls.Add(lblUserRoleBadge);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(343, 0);
            pnlTopBar.Margin = new Padding(4, 5, 4, 5);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1371, 72);
            pnlTopBar.TabIndex = 1;
            // 
            // btnRefreshStats
            // 
            btnRefreshStats.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshStats.BackColor = Color.FromArgb(253, 237, 242);
            btnRefreshStats.FlatAppearance.BorderSize = 0;
            btnRefreshStats.FlatStyle = FlatStyle.Flat;
            btnRefreshStats.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshStats.ForeColor = Color.FromArgb(173, 20, 87);
            btnRefreshStats.Location = new Point(1225, 16);
            btnRefreshStats.Margin = new Padding(4, 5, 4, 5);
            btnRefreshStats.Name = "btnRefreshStats";
            btnRefreshStats.Size = new Size(115, 40);
            btnRefreshStats.TabIndex = 3;
            btnRefreshStats.Text = "↻ Refresh";
            btnRefreshStats.UseVisualStyleBackColor = false;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrentUser.BackColor = Color.Transparent;
            lblCurrentUser.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblCurrentUser.ForeColor = Color.FromArgb(30, 41, 59);
            lblCurrentUser.Location = new Point(780, 22);
            lblCurrentUser.Margin = new Padding(4, 0, 4, 0);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(430, 28);
            lblCurrentUser.TabIndex = 1;
            lblCurrentUser.Text = "Victoria Sterling (Admin)";
            lblCurrentUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.BackColor = Color.Transparent;
            lblPageTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(173, 20, 87);
            lblPageTitle.Location = new Point(25, 17);
            lblPageTitle.Margin = new Padding(4, 0, 4, 0);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(171, 41);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Dashboard";
            // 
            // lblUserRoleBadge
            // 
            lblUserRoleBadge.Location = new Point(0, 0);
            lblUserRoleBadge.Name = "lblUserRoleBadge";
            lblUserRoleBadge.Size = new Size(0, 0);
            lblUserRoleBadge.TabIndex = 4;
            lblUserRoleBadge.Visible = false;
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.BackgroundImage = Properties.Resources.lib;
            pnlContent.BackgroundImageLayout = ImageLayout.Stretch;
            pnlContent.Controls.Add(secRecentActivity);
            pnlContent.Controls.Add(tlpMetrics);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(343, 72);
            pnlContent.Margin = new Padding(4, 5, 4, 5);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(34, 25, 34, 30);
            pnlContent.Size = new Size(1371, 1098);
            pnlContent.TabIndex = 2;
            // 
            // secRecentActivity
            // 
            secRecentActivity.BackColor = Color.White;
            secRecentActivity.BorderRadius = 12;
            secRecentActivity.Controls.Add(dgvRecent);
            secRecentActivity.Dock = DockStyle.Fill;
            secRecentActivity.HeaderColor = Color.FromArgb(173, 20, 87);
            secRecentActivity.Location = new Point(34, 271);
            secRecentActivity.Margin = new Padding(0);
            secRecentActivity.Name = "secRecentActivity";
            secRecentActivity.Padding = new Padding(16, 46, 16, 16);
            secRecentActivity.ShowHeaderBar = true;
            secRecentActivity.Size = new Size(1303, 797);
            secRecentActivity.TabIndex = 1;
            secRecentActivity.Title = "Institutional Circulation Activity & Recent Transactions";
            // 
            // dgvRecent
            // 
            dgvRecent.BackgroundColor = Color.FromArgb(255, 224, 192);
            dgvRecent.BorderStyle = BorderStyle.None;
            dgvRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecent.Dock = DockStyle.Fill;
            dgvRecent.Location = new Point(16, 46);
            dgvRecent.Margin = new Padding(4, 5, 4, 5);
            dgvRecent.Name = "dgvRecent";
            dgvRecent.RowHeadersWidth = 50;
            dgvRecent.Size = new Size(1271, 735);
            dgvRecent.TabIndex = 0;
            // 
            // tlpMetrics
            // 
            tlpMetrics.BackColor = Color.Transparent;
            tlpMetrics.ColumnCount = 3;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpMetrics.Controls.Add(cardTotalBooks, 0, 0);
            tlpMetrics.Controls.Add(cardAvailableBooks, 1, 0);
            tlpMetrics.Controls.Add(cardBorrowedBooks, 2, 0);
            tlpMetrics.Controls.Add(cardOverdueBooks, 0, 1);
            tlpMetrics.Controls.Add(cardTotalMembers, 1, 1);
            tlpMetrics.Controls.Add(cardExtra, 2, 1);
            tlpMetrics.Dock = DockStyle.Top;
            tlpMetrics.Location = new Point(34, 25);
            tlpMetrics.Margin = new Padding(0);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.Padding = new Padding(0, 0, 0, 16);
            tlpMetrics.RowCount = 2;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));
            tlpMetrics.Size = new Size(1303, 246);
            tlpMetrics.TabIndex = 0;
            // 
            // cardTotalBooks
            // 
            cardTotalBooks.AccentColor = Color.FromArgb(216, 27, 96);
            cardTotalBooks.BackColor = Color.White;
            cardTotalBooks.BorderRadius = 12;
            cardTotalBooks.Dock = DockStyle.Fill;
            cardTotalBooks.IconName = "books";
            cardTotalBooks.Location = new Point(8, 8);
            cardTotalBooks.Margin = new Padding(8);
            cardTotalBooks.Name = "cardTotalBooks";
            cardTotalBooks.Size = new Size(418, 99);
            cardTotalBooks.Subtitle = "Complete catalog volume";
            cardTotalBooks.TabIndex = 0;
            cardTotalBooks.Title = "TOTAL VOLUMES";
            cardTotalBooks.Value = "0";
            // 
            // cardAvailableBooks
            // 
            cardAvailableBooks.AccentColor = Color.FromArgb(22, 101, 52);
            cardAvailableBooks.BackColor = Color.White;
            cardAvailableBooks.BorderRadius = 12;
            cardAvailableBooks.Dock = DockStyle.Fill;
            cardAvailableBooks.IconName = "books";
            cardAvailableBooks.Location = new Point(442, 8);
            cardAvailableBooks.Margin = new Padding(8);
            cardAvailableBooks.Name = "cardAvailableBooks";
            cardAvailableBooks.Size = new Size(418, 99);
            cardAvailableBooks.Subtitle = "Ready on library shelves";
            cardAvailableBooks.TabIndex = 1;
            cardAvailableBooks.Title = "SHELF AVAILABLE";
            cardAvailableBooks.Value = "0";
            // 
            // cardBorrowedBooks
            // 
            cardBorrowedBooks.AccentColor = Color.FromArgb(233, 30, 99);
            cardBorrowedBooks.BackColor = Color.White;
            cardBorrowedBooks.BorderRadius = 12;
            cardBorrowedBooks.Dock = DockStyle.Fill;
            cardBorrowedBooks.IconName = "borrowreturn";
            cardBorrowedBooks.Location = new Point(876, 8);
            cardBorrowedBooks.Margin = new Padding(8);
            cardBorrowedBooks.Name = "cardBorrowedBooks";
            cardBorrowedBooks.Size = new Size(419, 99);
            cardBorrowedBooks.Subtitle = "Active loans checked out";
            cardBorrowedBooks.TabIndex = 2;
            cardBorrowedBooks.Title = "ON CIRCULATION";
            cardBorrowedBooks.Value = "0";
            // 
            // cardOverdueBooks
            // 
            cardOverdueBooks.AccentColor = Color.FromArgb(185, 28, 28);
            cardOverdueBooks.BackColor = Color.White;
            cardOverdueBooks.BorderRadius = 12;
            cardOverdueBooks.Dock = DockStyle.Fill;
            cardOverdueBooks.IconName = "warning";
            cardOverdueBooks.Location = new Point(8, 123);
            cardOverdueBooks.Margin = new Padding(8);
            cardOverdueBooks.Name = "cardOverdueBooks";
            cardOverdueBooks.Size = new Size(418, 99);
            cardOverdueBooks.Subtitle = "Requires return follow-up";
            cardOverdueBooks.TabIndex = 3;
            cardOverdueBooks.Title = "OVERDUE BOOKS";
            cardOverdueBooks.Value = "0";
            // 
            // cardTotalMembers
            // 
            cardTotalMembers.AccentColor = Color.FromArgb(173, 20, 87);
            cardTotalMembers.BackColor = Color.White;
            cardTotalMembers.BorderRadius = 12;
            cardTotalMembers.Dock = DockStyle.Fill;
            cardTotalMembers.IconName = "members";
            cardTotalMembers.Location = new Point(442, 123);
            cardTotalMembers.Margin = new Padding(8);
            cardTotalMembers.Name = "cardTotalMembers";
            cardTotalMembers.Size = new Size(418, 99);
            cardTotalMembers.Subtitle = "Students and faculty";
            cardTotalMembers.TabIndex = 4;
            cardTotalMembers.Title = "REGISTERED PATRONS";
            cardTotalMembers.Value = "0";
            // 
            // cardExtra
            // 
            cardExtra.AccentColor = Color.FromArgb(79, 70, 229);
            cardExtra.BackColor = Color.White;
            cardExtra.BorderRadius = 12;
            cardExtra.Dock = DockStyle.Fill;
            cardExtra.IconName = "members";
            cardExtra.Location = new Point(876, 123);
            cardExtra.Margin = new Padding(8);
            cardExtra.Name = "cardExtra";
            cardExtra.Size = new Size(419, 99);
            cardExtra.Subtitle = "Admin & staff accounts";
            cardExtra.TabIndex = 5;
            cardExtra.Title = "SYSTEM USERS";
            cardExtra.Value = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 250, 252);
            ClientSize = new Size(1714, 1170);
            Controls.Add(pnlContent);
            Controls.Add(pnlTopBar);
            Controls.Add(pnlSidebar);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1419, 1046);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management System";
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlSidebarBottom.ResumeLayout(false);
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            pnlContent.ResumeLayout(false);
            secRecentActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
            tlpMetrics.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
