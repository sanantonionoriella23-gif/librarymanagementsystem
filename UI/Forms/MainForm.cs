using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ApplyCustomStyling();
            WireNavigationEvents();
            Load += (s, e) =>
            {
                ShowCurrentUser();
                LoadDashboard();
            };
        }

        private void ApplyCustomStyling()
        {
            Theme.StyleDataGridView(dgvRecent);
            Theme.StyleSecondaryButton(btnScanQrSidebar);

            btnLogout.MouseEnter += (s, e) => btnLogout.BackColor = Color.FromArgb(254, 226, 226);
            btnLogout.MouseLeave += (s, e) => btnLogout.BackColor = Color.FromArgb(254, 242, 242);

            pnlSidebar.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Theme.BorderSubtle, 1))
                {
                    e.Graphics.DrawLine(pen, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
                }
            };

            pnlSidebarBottom.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Theme.BorderSubtle, 1))
                {
                    e.Graphics.DrawLine(pen, pnlSidebarBottom.Width - 1, 0, pnlSidebarBottom.Width - 1, pnlSidebarBottom.Height);
                }
            };
        }

        public void ShowCurrentUser()
        {
            var user = Session.CurrentUser;
            if (user != null)
            {
                lblCurrentUser.Text = $"{user.FullName} ({user.Username})";
                lblUserRoleBadge.Text = Access.GetRoleBadge(user.Role);

                // Enforce 3-Tier Hierarchy Permissions
                btnUsers.Visible = Access.CanManageUsers(user.Role);
                btnMembers.Visible = Access.CanManageMembers(user.Role);
                btnBorrowReturn.Visible = Access.CanIssueAndReturn(user.Role);

                // Header titles hidden per user request; sidebar starts directly with navigation
                pnlTopBar.Visible = true;
                lblBrandTitle.Visible = false;
                lblBrandSubtitle.Visible = false;

                if (user.Role == UserRole.User)
                {
                    lblPageTitle.Text = "Student Library Portal";
                    btnDashboard.Text = "Dashboard";
                    btnBooks.Text = "Borrow Books";
                    btnHistory.Text = "My Borrowed Books";
                    secRecentActivity.Title = "My Current Active Loans & Due Dates";

                    // Vertical positions for patron (clean top margin, no header clutter)
                    btnDashboard.Location = new Point(12, 20);
                    btnBooks.Location = new Point(12, 68);
                    btnHistory.Location = new Point(12, 116);
                    btnScanQrSidebar.Location = new Point(12, 174);
                }
                else if (user.Role == UserRole.Librarian)
                {
                    lblPageTitle.Text = "Circulation & Catalog Dashboard";
                    btnDashboard.Text = "Dashboard";
                    btnBooks.Text = "Books Catalog";
                    btnBorrowReturn.Text = "Borrow & Return";
                    btnMembers.Text = "Members";
                    btnHistory.Text = "Transactions";
                    secRecentActivity.Title = "Circulation Desk Activity & Active Transactions";

                    // Vertical positions for librarian
                    btnDashboard.Location = new Point(12, 20);
                    btnBooks.Location = new Point(12, 68);
                    btnBorrowReturn.Location = new Point(12, 116);
                    btnMembers.Location = new Point(12, 164);
                    btnHistory.Location = new Point(12, 212);
                    btnScanQrSidebar.Location = new Point(12, 270);
                }
                else
                {
                    lblPageTitle.Text = "System Administrator Dashboard";
                    btnDashboard.Text = "Dashboard";
                    btnBooks.Text = "Books Catalog";
                    btnBorrowReturn.Text = "Borrow & Return";
                    btnMembers.Text = "Members";
                    btnHistory.Text = "Transactions";
                    btnUsers.Text = "User Management";
                    secRecentActivity.Title = "Institutional Circulation Activity & Recent Transactions";

                    // Vertical positions for admin
                    btnDashboard.Location = new Point(12, 20);
                    btnBooks.Location = new Point(12, 68);
                    btnBorrowReturn.Location = new Point(12, 116);
                    btnMembers.Location = new Point(12, 164);
                    btnHistory.Location = new Point(12, 212);
                    btnUsers.Location = new Point(12, 260);
                    btnScanQrSidebar.Location = new Point(12, 318);
                }

                ConfigureDashboardLayout(user.Role);
            }
            else
            {
                lblCurrentUser.Text = "Guest";
                lblUserRoleBadge.Text = "Unauthenticated";
            }
        }

        private void ConfigureDashboardLayout(UserRole role)
        {
            tlpMetrics.SuspendLayout();
            tlpMetrics.Controls.Clear();
            tlpMetrics.ColumnStyles.Clear();
            tlpMetrics.RowStyles.Clear();

            if (role == UserRole.User)
            {
                // USER / STUDENT LAYOUT:
                // Single sleek 4-column metric bar customized specifically for student self-service
                tlpMetrics.ColumnCount = 4;
                tlpMetrics.RowCount = 1;
                tlpMetrics.Height = 115;

                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));

                cardTotalBooks.Title = "MY BORROWED BOOKS";
                cardTotalBooks.Subtitle = "Currently in your possession";
                cardTotalBooks.IconName = "borrowreturn";
                cardTotalBooks.AccentColor = Theme.Primary;

                cardAvailableBooks.Title = "MY OVERDUE BOOKS";
                cardAvailableBooks.Subtitle = "Requires return to desk";
                cardAvailableBooks.IconName = "warning";
                cardAvailableBooks.AccentColor = Theme.Danger;

                cardBorrowedBooks.Title = "TOTAL READ & BORROWED";
                cardBorrowedBooks.Subtitle = "Lifetime borrow records";
                cardBorrowedBooks.IconName = "history";
                cardBorrowedBooks.AccentColor = Color.FromArgb(124, 58, 237);

                cardOverdueBooks.Title = "CATALOG AVAILABLE";
                cardOverdueBooks.Subtitle = "Books ready on shelves";
                cardOverdueBooks.IconName = "books";
                cardOverdueBooks.AccentColor = Color.FromArgb(22, 101, 52);

                tlpMetrics.Controls.Add(cardTotalBooks, 0, 0);
                tlpMetrics.Controls.Add(cardAvailableBooks, 1, 0);
                tlpMetrics.Controls.Add(cardBorrowedBooks, 2, 0);
                tlpMetrics.Controls.Add(cardOverdueBooks, 3, 0);
            }
            else if (role == UserRole.Librarian)
            {
                // LIBRARIAN CIRCULATION DESK LAYOUT:
                // 6 circulation & shelf management metrics (3x2)
                tlpMetrics.ColumnCount = 3;
                tlpMetrics.RowCount = 2;
                tlpMetrics.Height = 235;

                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
                tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));
                tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));

                cardTotalBooks.Title = "TOTAL VOLUMES";
                cardTotalBooks.Subtitle = "Collection catalog volume";
                cardTotalBooks.IconName = "books";
                cardTotalBooks.AccentColor = Color.FromArgb(216, 27, 96);

                cardAvailableBooks.Title = "SHELF AVAILABLE";
                cardAvailableBooks.Subtitle = "Ready for patron checkout";
                cardAvailableBooks.IconName = "books";
                cardAvailableBooks.AccentColor = Color.FromArgb(22, 101, 52);

                cardBorrowedBooks.Title = "ON CIRCULATION";
                cardBorrowedBooks.Subtitle = "Currently checked out";
                cardBorrowedBooks.IconName = "borrowreturn";
                cardBorrowedBooks.AccentColor = Color.FromArgb(233, 30, 99);

                cardOverdueBooks.Title = "OVERDUE BOOKS";
                cardOverdueBooks.Subtitle = "Requires return follow-up";
                cardOverdueBooks.IconName = "warning";
                cardOverdueBooks.AccentColor = Color.FromArgb(185, 28, 28);

                cardTotalMembers.Title = "REGISTERED PATRONS";
                cardTotalMembers.Subtitle = "Enrolled library members";
                cardTotalMembers.IconName = "members";
                cardTotalMembers.AccentColor = Color.FromArgb(173, 20, 87);

                cardExtra.Title = "COMPLETED RETURNS";
                cardExtra.Subtitle = "Successfully returned books";
                cardExtra.IconName = "history";
                cardExtra.AccentColor = Color.FromArgb(2, 132, 199);

                tlpMetrics.Controls.Add(cardTotalBooks, 0, 0);
                tlpMetrics.Controls.Add(cardAvailableBooks, 1, 0);
                tlpMetrics.Controls.Add(cardBorrowedBooks, 2, 0);
                tlpMetrics.Controls.Add(cardOverdueBooks, 0, 1);
                tlpMetrics.Controls.Add(cardTotalMembers, 1, 1);
                tlpMetrics.Controls.Add(cardExtra, 2, 1);
            }
            else
            {
                // ADMIN INSTITUTIONAL OVERVIEW LAYOUT:
                // 6 administrative metrics including System User Staff accounts (3x2)
                tlpMetrics.ColumnCount = 3;
                tlpMetrics.RowCount = 2;
                tlpMetrics.Height = 235;

                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                tlpMetrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
                tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));
                tlpMetrics.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));

                cardTotalBooks.Title = "TOTAL VOLUMES";
                cardTotalBooks.Subtitle = "Complete catalog volume";
                cardTotalBooks.IconName = "books";
                cardTotalBooks.AccentColor = Color.FromArgb(216, 27, 96);

                cardAvailableBooks.Title = "SHELF AVAILABLE";
                cardAvailableBooks.Subtitle = "Ready on library shelves";
                cardAvailableBooks.IconName = "books";
                cardAvailableBooks.AccentColor = Color.FromArgb(22, 101, 52);

                cardBorrowedBooks.Title = "ON CIRCULATION";
                cardBorrowedBooks.Subtitle = "Active loans checked out";
                cardBorrowedBooks.IconName = "borrowreturn";
                cardBorrowedBooks.AccentColor = Color.FromArgb(233, 30, 99);

                cardOverdueBooks.Title = "OVERDUE BOOKS";
                cardOverdueBooks.Subtitle = "Requires return follow-up";
                cardOverdueBooks.IconName = "warning";
                cardOverdueBooks.AccentColor = Color.FromArgb(185, 28, 28);

                cardTotalMembers.Title = "REGISTERED PATRONS";
                cardTotalMembers.Subtitle = "Students and faculty";
                cardTotalMembers.IconName = "members";
                cardTotalMembers.AccentColor = Color.FromArgb(173, 20, 87);

                cardExtra.Title = "SYSTEM USERS";
                cardExtra.Subtitle = "Admin & staff accounts";
                cardExtra.IconName = "members";
                cardExtra.AccentColor = Color.FromArgb(79, 70, 229);

                tlpMetrics.Controls.Add(cardTotalBooks, 0, 0);
                tlpMetrics.Controls.Add(cardAvailableBooks, 1, 0);
                tlpMetrics.Controls.Add(cardBorrowedBooks, 2, 0);
                tlpMetrics.Controls.Add(cardOverdueBooks, 0, 1);
                tlpMetrics.Controls.Add(cardTotalMembers, 1, 1);
                tlpMetrics.Controls.Add(cardExtra, 2, 1);
            }

            tlpMetrics.ResumeLayout(true);
        }

        public void LoadDashboard()
        {
            try
            {
                var role = Session.CurrentUser?.Role ?? UserRole.User;

                if (role == UserRole.User)
                {
                    var member = Database.GetMemberByEmail(Session.CurrentUser?.Email ?? "")
                                 ?? Database.GetMemberByCode("LIB-M1001");
                    int memberId = member?.Id ?? 1;
                    var userStats = Database.GetUserDashboardStats(memberId);

                    cardTotalBooks.Value = userStats.MyBorrowedBooks.ToString("N0");
                    cardTotalBooks.Subtitle = userStats.MyBorrowedBooks == 1 ? "1 book currently checked out" : $"{userStats.MyBorrowedBooks} books currently checked out";

                    cardAvailableBooks.Value = userStats.MyOverdueBooks.ToString("N0");
                    cardAvailableBooks.Subtitle = userStats.MyOverdueBooks > 0 ? "Requires return to library" : "All loans within due date";
                    cardAvailableBooks.AccentColor = userStats.MyOverdueBooks > 0 ? Theme.Danger : Theme.Success;

                    cardBorrowedBooks.Value = userStats.MyTotalHistory.ToString("N0");
                    cardBorrowedBooks.Subtitle = "Lifetime borrow records";

                    cardOverdueBooks.Value = userStats.TotalCatalogAvailable.ToString("N0");
                    cardOverdueBooks.Subtitle = "Ready on library shelves";

                    dgvRecent.DataSource = Database.GetTransactions(memberId: memberId);
                }
                else
                {
                    var stats = Database.GetDashboardStats();

                    cardTotalBooks.Value = stats.TotalBooks.ToString("N0");
                    cardAvailableBooks.Value = stats.AvailableBooks.ToString("N0");
                    cardBorrowedBooks.Value = stats.BorrowedBooks.ToString("N0");
                    cardOverdueBooks.Value = stats.OverdueBooks.ToString("N0");
                    cardTotalMembers.Value = stats.TotalMembers.ToString("N0");

                    if (role == UserRole.Admin)
                    {
                        cardExtra.Value = stats.TotalUsers.ToString("N0");
                    }
                    else
                    {
                        cardExtra.Value = stats.TotalReturned.ToString("N0");
                    }

                    dgvRecent.DataSource = Database.GetTransactions();
                }

                FormatRecentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing dashboard metrics: " + ex.Message, "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormatRecentGrid()
        {
            try
            {
                if (dgvRecent.Columns.Count == 0) return;

                bool isStudent = Session.IsUser;

                foreach (DataGridViewColumn col in dgvRecent.Columns)
                {
                    string prop = col.DataPropertyName ?? col.Name ?? "";

                    if (string.Equals(prop, "Id", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(prop, "Status", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(prop, "FineAmount", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(prop, "IssuerName", StringComparison.OrdinalIgnoreCase))
                    {
                        col.Visible = false;
                    }
                    else if (isStudent && (string.Equals(prop, "MemberName", StringComparison.OrdinalIgnoreCase) ||
                                           string.Equals(prop, "MemberCode", StringComparison.OrdinalIgnoreCase)))
                    {
                        col.Visible = false;
                    }
                    else if (string.Equals(prop, "TransactionCode", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Code";
                        col.Width = isStudent ? 130 : 110;
                    }
                    else if (string.Equals(prop, "BookTitle", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Book Title";
                        col.Width = isStudent ? 280 : 220;
                    }
                    else if (string.Equals(prop, "ISBN", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "ISBN";
                        col.Width = isStudent ? 140 : 120;
                    }
                    else if (string.Equals(prop, "MemberName", StringComparison.OrdinalIgnoreCase))
                    {
                        col.Visible = true;
                        col.HeaderText = "Borrower";
                        col.Width = 160;
                    }
                    else if (string.Equals(prop, "MemberCode", StringComparison.OrdinalIgnoreCase))
                    {
                        col.Visible = true;
                        col.HeaderText = "Member ID";
                        col.Width = 110;
                    }
                    else if (string.Equals(prop, "IssueDate", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = isStudent ? "Borrowed Date" : "Issued Date";
                        col.Width = isStudent ? 140 : 120;
                    }
                    else if (string.Equals(prop, "DueDate", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Due Date";
                        col.Width = isStudent ? 140 : 120;
                    }
                    else if (string.Equals(prop, "ReturnDate", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Return Date";
                        col.Width = isStudent ? 130 : 110;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error formatting recent grid: " + ex.Message);
            }
        }

        private void OpenModule(Form module)
        {
            Hide();
            using (module)
            {
                module.ShowDialog();
            }
            Show();
            LoadDashboard();
        }

        private void WireNavigationEvents()
        {
            btnDashboard.Click += (s, e) => LoadDashboard();
            btnBooks.Click += BtnBooks_Click;
            btnMembers.Click += BtnMembers_Click;
            btnBorrowReturn.Click += BtnBorrowReturn_Click;
            btnHistory.Click += BtnHistory_Click;
            btnUsers.Click += BtnUsers_Click;
            btnLogout.Click += BtnLogout_Click;
            btnRefreshStats.Click += (s, e) => LoadDashboard();

            // Quick QR Scanner on Sidebar
            btnScanQrSidebar.Click += (s, e) =>
            {
                using (var scanner = new QrScannerForm())
                {
                    if (scanner.ShowDialog() == DialogResult.OK)
                    {
                        if (scanner.BookWasBorrowed)
                        {
                            LoadDashboard();
                        }
                        else if (scanner.OpenCirculation)
                        {
                            OpenModule(new BorrowReturnForm());
                        }
                        else if (scanner.SelectedBook != null)
                        {
                            OpenModule(new BooksForm(scanner.SelectedBook.Id));
                        }
                    }
                }
            };

            // Interactive card navigation based on role
            cardTotalBooks.Click += (s, e) =>
            {
                if (Session.IsUser) BtnHistory_Click(s, e);
                else BtnBooks_Click(s, e);
            };
            cardAvailableBooks.Click += (s, e) =>
            {
                if (Session.IsUser) BtnHistory_Click(s, e);
                else BtnBooks_Click(s, e);
            };
            cardBorrowedBooks.Click += (s, e) =>
            {
                if (Session.IsUser) BtnHistory_Click(s, e);
                else BtnBorrowReturn_Click(s, e);
            };
            cardOverdueBooks.Click += (s, e) =>
            {
                if (Session.IsUser) BtnBooks_Click(s, e);
                else BtnHistory_Click(s, e);
            };
            cardTotalMembers.Click += (s, e) => { if (!Session.IsUser) BtnMembers_Click(s, e); };
            cardExtra.Click += (s, e) =>
            {
                if (Session.IsAdmin) BtnUsers_Click(s, e);
                else if (Session.IsLibrarian) BtnHistory_Click(s, e);
            };
        }

        private void BtnBooks_Click(object? sender, EventArgs e)
        {
            OpenModule(new BooksForm());
        }

        private void BtnMembers_Click(object? sender, EventArgs e)
        {
            if (!Access.CanManageMembers(Session.CurrentUser?.Role ?? UserRole.User))
            {
                MessageBox.Show("Access Denied: Only Library Personnel and Administrators can manage members.", "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenModule(new MembersForm());
        }

        private void BtnBorrowReturn_Click(object? sender, EventArgs e)
        {
            if (!Access.CanIssueAndReturn(Session.CurrentUser?.Role ?? UserRole.User))
            {
                MessageBox.Show("Access Denied: Only Library Staff can operate the circulation desk.", "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenModule(new BorrowReturnForm());
        }

        private void BtnHistory_Click(object? sender, EventArgs e)
        {
            OpenModule(new TransactionHistoryForm());
        }

        private void BtnUsers_Click(object? sender, EventArgs e)
        {
            if (!Access.CanManageUsers(Session.CurrentUser?.Role ?? UserRole.User))
            {
                MessageBox.Show("Access Denied: Only Administrators can access User Account Management.", "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenModule(new UsersForm());
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Confirm Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cardTotalBooks_Click(object sender, EventArgs e)
        {

        }
    }
}
