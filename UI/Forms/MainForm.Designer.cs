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
            lblUserRoleBadge = new Label();
            lblCurrentUser = new Label();
            lblPageTitle = new Label();
            pnlContent = new Panel();
            tlpMetrics = new TableLayoutPanel();
            dgvRecent = new DataGridView();
            pnlSidebar.SuspendLayout();
            pnlSidebarBottom.SuspendLayout();
            pnlTopBar.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
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
            btnScanQrSidebar.Location = new Point(17, 530);
            btnScanQrSidebar.Margin = new Padding(4, 5, 4, 5);
            btnScanQrSidebar.Name = "btnScanQrSidebar";
            btnScanQrSidebar.Size = new Size(309, 67);
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
            btnUsers.Location = new Point(17, 433);
            btnUsers.Margin = new Padding(4, 5, 4, 5);
            btnUsers.Name = "btnUsers";
            btnUsers.Padding = new Padding(23, 0, 0, 0);
            btnUsers.Size = new Size(309, 70);
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
            btnHistory.Location = new Point(17, 353);
            btnHistory.Margin = new Padding(4, 5, 4, 5);
            btnHistory.Name = "btnHistory";
            btnHistory.Padding = new Padding(23, 0, 0, 0);
            btnHistory.Size = new Size(309, 70);
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
            btnBorrowReturn.Location = new Point(17, 193);
            btnBorrowReturn.Margin = new Padding(4, 5, 4, 5);
            btnBorrowReturn.Name = "btnBorrowReturn";
            btnBorrowReturn.Padding = new Padding(23, 0, 0, 0);
            btnBorrowReturn.Size = new Size(309, 70);
            btnBorrowReturn.TabIndex = 5;
            btnBorrowReturn.Text = "Borrow & Return";
            btnBorrowReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnBorrowReturn.UseVisualStyleBackColor = true;
            // 
            // btnMembers
            // 
            btnMembers.BackColor = Color.White;
            btnMembers.FlatAppearance.BorderSize = 0;
            btnMembers.FlatStyle = FlatStyle.Flat;
            btnMembers.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMembers.ForeColor = Color.FromArgb(30, 41, 59);
            btnMembers.Location = new Point(17, 273);
            btnMembers.Margin = new Padding(4, 5, 4, 5);
            btnMembers.Name = "btnMembers";
            btnMembers.Padding = new Padding(23, 0, 0, 0);
            btnMembers.Size = new Size(309, 70);
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
            btnBooks.Location = new Point(17, 113);
            btnBooks.Margin = new Padding(4, 5, 4, 5);
            btnBooks.Name = "btnBooks";
            btnBooks.Padding = new Padding(23, 0, 0, 0);
            btnBooks.Size = new Size(309, 70);
            btnBooks.TabIndex = 3;
            btnBooks.Text = "Books Catalog";
            btnBooks.TextAlign = ContentAlignment.MiddleLeft;
            btnBooks.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Popup;
            btnDashboard.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.FromArgb(173, 20, 87);
            btnDashboard.Location = new Point(17, 33);
            btnDashboard.Margin = new Padding(4, 5, 4, 5);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(23, 0, 0, 0);
            btnDashboard.Size = new Size(309, 70);
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
            pnlTopBar.BackgroundImage = Properties.Resources.lib;
            pnlTopBar.Controls.Add(btnRefreshStats);
            pnlTopBar.Controls.Add(lblUserRoleBadge);
            pnlTopBar.Controls.Add(lblCurrentUser);
            pnlTopBar.Controls.Add(lblPageTitle);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(343, 0);
            pnlTopBar.Margin = new Padding(4, 5, 4, 5);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1371, 100);
            pnlTopBar.TabIndex = 1;
            pnlTopBar.Visible = false;
            // 
            // btnRefreshStats
            // 
            btnRefreshStats.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshStats.BackColor = Color.FromArgb(253, 237, 242);
            btnRefreshStats.FlatAppearance.BorderSize = 0;
            btnRefreshStats.FlatStyle = FlatStyle.Flat;
            btnRefreshStats.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshStats.ForeColor = Color.FromArgb(173, 20, 87);
            btnRefreshStats.Location = new Point(1193, 20);
            btnRefreshStats.Margin = new Padding(4, 5, 4, 5);
            btnRefreshStats.Name = "btnRefreshStats";
            btnRefreshStats.Size = new Size(143, 60);
            btnRefreshStats.TabIndex = 3;
            btnRefreshStats.Text = "↻ Refresh";
            btnRefreshStats.UseVisualStyleBackColor = false;
            // 
            // lblUserRoleBadge
            // 
            lblUserRoleBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserRoleBadge.BackColor = Color.Transparent;
            lblUserRoleBadge.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblUserRoleBadge.ForeColor = Color.FromArgb(173, 20, 87);
            lblUserRoleBadge.Location = new Point(764, 55);
            lblUserRoleBadge.Margin = new Padding(4, 0, 4, 0);
            lblUserRoleBadge.Name = "lblUserRoleBadge";
            lblUserRoleBadge.Size = new Size(400, 30);
            lblUserRoleBadge.TabIndex = 2;
            lblUserRoleBadge.Text = "Role Badge";
            lblUserRoleBadge.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrentUser.BackColor = Color.Transparent;
            lblCurrentUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCurrentUser.ForeColor = Color.FromArgb(30, 41, 59);
            lblCurrentUser.Location = new Point(764, 20);
            lblCurrentUser.Margin = new Padding(4, 0, 4, 0);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(400, 33);
            lblCurrentUser.TabIndex = 1;
            lblCurrentUser.Text = "User Name";
            lblCurrentUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.BackColor = Color.Transparent;
            lblPageTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.Maroon;
            lblPageTitle.Location = new Point(31, 23);
            lblPageTitle.Margin = new Padding(4, 0, 4, 0);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(184, 45);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Dashboard";
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.BackgroundImage = Properties.Resources.lib;
            pnlContent.Controls.Add(tlpMetrics);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(343, 100);
            pnlContent.Margin = new Padding(4, 5, 4, 5);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(34, 40, 34, 40);
            pnlContent.Size = new Size(1371, 1070);
            pnlContent.TabIndex = 2;
            // 
            // tlpMetrics
            // 
            tlpMetrics.BackColor = Color.White;
            tlpMetrics.ColumnCount = 3;
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpMetrics.Dock = DockStyle.Top;
            tlpMetrics.Location = new Point(34, 40);
            tlpMetrics.Margin = new Padding(4, 5, 4, 5);
            tlpMetrics.Name = "tlpMetrics";
            tlpMetrics.RowCount = 2;
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Absolute, 192F));
            tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Absolute, 192F));
            tlpMetrics.Size = new Size(1303, 392);
            tlpMetrics.TabIndex = 0;
            // 
            // dgvRecent
            // 
            dgvRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecent.Dock = DockStyle.Fill;
            dgvRecent.Location = new Point(23, 87);
            dgvRecent.Margin = new Padding(4, 5, 4, 5);
            dgvRecent.Name = "dgvRecent";
            dgvRecent.RowHeadersWidth = 62;
            dgvRecent.Size = new Size(1257, 484);
            dgvRecent.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
            ResumeLayout(false);
        }
    }
}
