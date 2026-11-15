using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class BorrowReturnForm : Form
    {
        private Member? _verifiedMember = null;
        private Book? _verifiedBook = null;
        private int _selectedReturnTrxId = 0;

        public BorrowReturnForm()
        {
            InitializeComponent();
            ApplyCustomStyling();
            WireEvents();

            Load += (s, e) =>
            {
                dtpOverdueDate.Value = DateTime.Today.AddDays(14);
                UpdateDueDatePreview();
                LoadActiveLoans();
            };
        }

        private void ApplyCustomStyling()
        {
            Theme.StyleDataGridView(dgvActiveLoans);
            Theme.StylePrimaryButton(btnIssueConfirm);
            Theme.StylePrimaryButton(btnProcessReturn);
            Theme.StyleSecondaryButton(btnFindMember);
            Theme.StyleSecondaryButton(btnFindBook);

            pnlTop.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.BorderSubtle))
                {
                    e.Graphics.DrawLine(p, 0, pnlTop.Height - 1, pnlTop.Width, pnlTop.Height - 1);
                }
            };
        }

        private void WireEvents()
        {
            btnClose.Click += (s, e) => Close();

            // Issue Tab Events
            btnFindMember.Click += (s, e) => VerifyMember();
            txtIssueMemberCode.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) VerifyMember(); };

            btnFindBook.Click += (s, e) => VerifyBook();
            txtIssueIsbn.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) VerifyBook(); };

            dtpOverdueDate.ValueChanged += (s, e) => UpdateDueDatePreview();
            btnIssueConfirm.Click += (s, e) => PerformIssueBook();

            // Return Tab Events
            txtReturnSearch.TextChanged += (s, e) => LoadActiveLoans();
            dgvActiveLoans.SelectionChanged += (s, e) =>
            {
                if (dgvActiveLoans.CurrentRow != null && dgvActiveLoans.CurrentRow.DataBoundItem is TransactionDetailView item)
                {
                    PopulateReturnFields(item);
                }
            };
            btnProcessReturn.Click += (s, e) => PerformReturnBook();
        }

        private void UpdateDueDatePreview()
        {
            DateTime due = dtpOverdueDate.Value;
            int days = (int)(due.Date - DateTime.Today).TotalDays;
            if (days > 0)
                lblDueDatePreview.Text = $"({days} days until overdue)";
            else if (days == 0)
                lblDueDatePreview.Text = "(Overdue today)";
            else
                lblDueDatePreview.Text = $"({Math.Abs(days)} days overdue)";
        }

        private void VerifyMember()
        {
            string input = txtIssueMemberCode.Text.Trim();
            if (input.StartsWith("MEMBER:", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Substring("MEMBER:".Length).Trim();
            }

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a member code.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _verifiedMember = Database.GetMemberByCode(input);
            if (_verifiedMember != null)
            {
                lblMemberInfo.ForeColor = Theme.TextPrimary;
                lblMemberInfo.Text = $"✓ {_verifiedMember.FullName} ({_verifiedMember.MemberCode})\nType: {_verifiedMember.MemberType} | Status: {_verifiedMember.Status} | {_verifiedMember.Email}";
            }
            else
            {
                lblMemberInfo.ForeColor = Theme.Danger;
                lblMemberInfo.Text = $"✗ Member '{input}' not found. Please register or verify the code.";
            }
        }

        private void VerifyBook()
        {
            string input = txtIssueIsbn.Text.Trim();
            if (input.StartsWith("ISBN:", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Substring("ISBN:".Length).Trim();
            }

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter an ISBN.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _verifiedBook = Database.GetBookByIsbn(input);
            if (_verifiedBook != null)
            {
                Color statusColor = _verifiedBook.AvailableCopies > 0 ? Theme.Success : Theme.Danger;
                lblBookInfo.ForeColor = statusColor;
                lblBookInfo.Text = $"✓ {_verifiedBook.Title} by {_verifiedBook.Author}\nISBN: {_verifiedBook.ISBN} | Available: {_verifiedBook.AvailableCopies} of {_verifiedBook.TotalCopies} | Shelf: {_verifiedBook.ShelfLocation}";
            }
            else
            {
                lblBookInfo.ForeColor = Theme.Danger;
                lblBookInfo.Text = $"✗ Book with ISBN '{input}' not found in catalog.";
            }
        }

        private void PerformIssueBook()
        {
            if (_verifiedMember == null)
            {
                MessageBox.Show("Please verify a valid member before borrowing.", "Verification Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIssueMemberCode.Focus();
                return;
            }

            if (_verifiedBook == null)
            {
                MessageBox.Show("Please verify a valid book before borrowing.", "Verification Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIssueIsbn.Focus();
                return;
            }

            int userId = Session.CurrentUser?.Id ?? 1;
            DateTime dueDate = dtpOverdueDate.Value.Date;
            int days = Math.Max(1, (int)(dueDate - DateTime.Today).TotalDays);
            string notes = txtIssueNotes.Text.Trim();

            string memberName = _verifiedMember.FullName;
            string bookTitle = _verifiedBook.Title;

            var (success, message) = Database.IssueBook(_verifiedBook.Id, _verifiedMember.Id, userId, days, notes, dueDate);
            if (success)
            {
                MessageBox.Show($"Success! '{bookTitle}' has been borrowed by {memberName}.\n\nOverdue Date: {dueDate:MMMM dd, yyyy}", "Book Borrowed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear inputs
                _verifiedMember = null;
                _verifiedBook = null;
                txtIssueMemberCode.Clear();
                txtIssueIsbn.Clear();
                txtIssueNotes.Clear();
                dtpOverdueDate.Value = DateTime.Today.AddDays(14);
                UpdateDueDatePreview();
                lblMemberInfo.Text = "No member selected. Enter Member Code and click Verify.";
                lblMemberInfo.ForeColor = Theme.TextSecondary;
                lblBookInfo.Text = "No book selected. Enter ISBN and click Verify.";
                lblBookInfo.ForeColor = Theme.TextSecondary;

                LoadActiveLoans();
            }
            else
            {
                MessageBox.Show(message, "Borrow Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadActiveLoans()
        {
            try
            {
                Database.UpdateOverdueStatuses();
                string search = txtReturnSearch.Text.Trim();
                var all = Database.GetTransactions(search) ?? new System.Collections.Generic.List<TransactionDetailView>();

                // Filter for active records only (Borrowed or Overdue)
                var activeLoans = all.FindAll(t => t != null && (t.Status == "Borrowed" || t.Status == "Overdue"));
                dgvActiveLoans.DataSource = null;
                dgvActiveLoans.DataSource = activeLoans;

                foreach (DataGridViewColumn col in dgvActiveLoans.Columns)
                {
                    string prop = col.DataPropertyName ?? col.Name ?? "";
                    if (string.Equals(prop, "Id", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(prop, "ReturnDate", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(prop, "IssuerName", StringComparison.OrdinalIgnoreCase))
                    {
                        col.Visible = false;
                    }
                    else if (string.Equals(prop, "TransactionCode", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Code";
                        col.Width = 120;
                    }
                    else if (string.Equals(prop, "BookTitle", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Book Title";
                        col.Width = 200;
                    }
                    else if (string.Equals(prop, "ISBN", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "ISBN";
                        col.Width = 130;
                    }
                    else if (string.Equals(prop, "MemberName", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Borrower";
                        col.Width = 150;
                    }
                    else if (string.Equals(prop, "DueDate", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Overdue Date";
                        col.Width = 130;
                    }
                    else if (string.Equals(prop, "Status", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Status";
                        col.Width = 90;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in LoadActiveLoans: " + ex.Message);
            }
        }

        private void PopulateReturnFields(TransactionDetailView item)
        {
            _selectedReturnTrxId = item.Id;
            txtRetTrxCode.Text = item.TransactionCode;
            txtRetBook.Text = $"{item.BookTitle} ({item.ISBN})";
            txtRetMember.Text = $"{item.MemberName} ({item.MemberCode})";
            txtRetDue.Text = $"{item.DueDate} [Status: {item.Status}]";
        }

        private void PerformReturnBook()
        {
            if (_selectedReturnTrxId <= 0)
            {
                MessageBox.Show("Please select a borrowed book from the list to return.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string notes = txtRetNotes.Text.Trim();
            var (success, message) = Database.ReturnBook(_selectedReturnTrxId, notes);

            if (success)
            {
                MessageBox.Show(message, "Return Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _selectedReturnTrxId = 0;
                txtRetTrxCode.Clear();
                txtRetBook.Clear();
                txtRetMember.Clear();
                txtRetDue.Clear();
                txtRetNotes.Clear();

                LoadActiveLoans();
            }
            else
            {
                MessageBox.Show(message, "Return Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
