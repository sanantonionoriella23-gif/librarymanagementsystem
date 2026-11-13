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

            numDays.ValueChanged += (s, e) => UpdateDueDatePreview();
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
            DateTime due = DateTime.Now.AddDays((double)numDays.Value);
            lblDueDatePreview.Text = $"Calculated Due Date: {due:MMM dd, yyyy}";
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
                MessageBox.Show("Please verify a valid member before issuing.", "Verification Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIssueMemberCode.Focus();
                return;
            }

            if (_verifiedBook == null)
            {
                MessageBox.Show("Please verify a valid book before issuing.", "Verification Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIssueIsbn.Focus();
                return;
            }

            int userId = Session.CurrentUser?.Id ?? 1;
            int days = (int)numDays.Value;
            string notes = txtIssueNotes.Text.Trim();

            // Cache data for slip generation
            string memberName = _verifiedMember.FullName;
            string memberCode = _verifiedMember.MemberCode;
            string bookTitle = _verifiedBook.Title;
            string isbn = _verifiedBook.ISBN;
            string shelf = _verifiedBook.ShelfLocation;
            DateTime dueDate = DateTime.Now.AddDays(days);

            var (success, message) = Database.IssueBook(_verifiedBook.Id, _verifiedMember.Id, userId, days, notes);
            if (success)
            {
                // Offer circulation receipt
                if (MessageBox.Show($"{message}\n\nWould you like to print/save the official University Circulation Loan Slip?", "Loan Issued", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GenerateCirculationSlip(memberName, memberCode, bookTitle, isbn, shelf, dueDate);
                }
                
                // Clear inputs
                _verifiedMember = null;
                _verifiedBook = null;
                txtIssueMemberCode.Clear();
                txtIssueIsbn.Clear();
                txtIssueNotes.Clear();
                lblMemberInfo.Text = "No member selected. Enter Member Code and click Verify.";
                lblMemberInfo.ForeColor = Theme.TextSecondary;
                lblBookInfo.Text = "No book selected. Enter ISBN and click Verify.";
                lblBookInfo.ForeColor = Theme.TextSecondary;

                LoadActiveLoans();
            }
            else
            {
                MessageBox.Show(message, "Issue Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GenerateCirculationSlip(string memberName, string memberCode, string bookTitle, string isbn, string shelf, DateTime dueDate)
        {
            int width = 380;
            int height = 500;
            Bitmap slip = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(slip))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen borderPen = new Pen(Theme.PrimaryDark, 2))
                {
                    g.DrawRectangle(borderPen, 6, 6, width - 12, height - 12);
                }

                // Header
                using (SolidBrush headerBg = new SolidBrush(Theme.PrimaryLight))
                {
                    g.FillRectangle(headerBg, 8, 8, width - 16, 55);
                }

                using (Font uFont = new Font("Segoe UI", 10F, FontStyle.Bold))
                using (SolidBrush pinkBrush = new SolidBrush(Theme.PrimaryDark))
                {
                    g.DrawString("ATHENA STATE UNIVERSITY", uFont, pinkBrush, new PointF(18, 14));
                }

                using (Font subFont = new Font("Segoe UI", 7.5F))
                using (SolidBrush subBrush = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString("CIRCULATION DESK • OFFICIAL DATE-DUE SLIP", subFont, subBrush, new PointF(18, 34));
                }

                // Borrower Info
                int y = 75;
                using (Font lblF = new Font("Segoe UI", 8F, FontStyle.Bold))
                using (Font valF = new Font("Segoe UI", 9F))
                using (SolidBrush darkB = new SolidBrush(Theme.TextPrimary))
                using (SolidBrush mutB = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString("BORROWER:", lblF, mutB, 18, y);
                    g.DrawString($"{memberName} ({memberCode})", valF, darkB, 18, y + 16);

                    y += 42;
                    g.DrawString("BOOK TITLE:", lblF, mutB, 18, y);
                    g.DrawString(bookTitle, valF, darkB, new RectangleF(18, y + 16, width - 36, 38));

                    y += 56;
                    g.DrawString($"ISBN: {isbn}   |   CALL NO: {shelf}", lblF, darkB, 18, y);

                    // Due Date Box
                    y += 30;
                    Rectangle dueBox = new Rectangle(18, y, width - 36, 75);
                    using (SolidBrush dueBg = new SolidBrush(Color.FromArgb(254, 250, 252)))
                    using (Pen duePen = new Pen(Theme.PrimaryDark, 2))
                    {
                        g.FillRectangle(dueBg, dueBox);
                        g.DrawRectangle(duePen, dueBox);
                    }

                    using (Font dueLblF = new Font("Segoe UI", 8F, FontStyle.Bold))
                    using (SolidBrush redB = new SolidBrush(Theme.Danger))
                    {
                        g.DrawString("OFFICIAL DATE TO RETURN (DUE DATE):", dueLblF, redB, 26, y + 10);
                    }

                    using (Font dateF = new Font("Segoe UI", 16F, FontStyle.Bold))
                    {
                        g.DrawString(dueDate.ToString("MMMM dd, yyyy"), dateF, darkB, 26, y + 30);
                    }

                    // QR Code of Transaction
                    y += 90;
                    Bitmap qr = QrCodes.GenerateQrCode($"LOAN:{memberCode}:{isbn}:{dueDate:yyyyMMdd}", 3);
                    g.DrawImage(qr, (width - 100) / 2, y, 100, 100);

                    // Policy footer
                    y += 110;
                    using (Font footF = new Font("Segoe UI", 7F))
                    {
                        g.DrawString("Books must be returned or renewed on or before the due date.", footF, mutB, 18, y);
                    }
                }
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image (*.png)|*.png";
                sfd.FileName = $"LOAN_SLIP_{memberCode}_{DateTime.Now:MMdd_HHmm}.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    slip.Save(sfd.FileName, ImageFormat.Png);
                    MessageBox.Show("Circulation loan slip saved to:\n" + sfd.FileName, "Loan Slip Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LoadActiveLoans()
        {
            try
            {
                Database.UpdateOverdueStatuses();
                string search = txtReturnSearch.Text.Trim();
                var all = Database.GetTransactions(search) ?? new System.Collections.Generic.List<TransactionDetailView>();

                // Filter for active loans only (Borrowed or Overdue)
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
                        col.HeaderText = "Due Date";
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
                MessageBox.Show("Please select an active loan from the list to return.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
