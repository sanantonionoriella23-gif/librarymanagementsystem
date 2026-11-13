using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class QrScannerForm : Form
    {
        public Book? SelectedBook { get; private set; }
        public bool BookWasBorrowed { get; private set; } = false;
        public bool OpenCirculation { get; private set; } = false;

        public QrScannerForm()
        {
            InitializeComponent();
            ApplyCustomStyling();
            WireEvents();
        }

        private void ApplyCustomStyling()
        {
            Theme.StylePrimaryButton(btnLookup);
            Theme.StylePrimaryButton(btnGoToBook);
            Theme.StylePrimaryButton(btnBorrowScannedBook);

            pnlHeader.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.BorderSubtle))
                {
                    e.Graphics.DrawLine(p, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
                }
            };
        }

        private void WireEvents()
        {
            btnClose.Click += (s, e) => Close();

            // Auto-focus input when form is displayed so barcode guns can immediately scan
            Shown += (s, e) =>
            {
                txtQrInput.Focus();
                txtQrInput.SelectAll();
            };

            btnLookup.Click += (s, e) => ProcessScan();

            txtQrInput.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ProcessScan();
                }
            };

            btnGoToBook.Click += (s, e) =>
            {
                DialogResult = DialogResult.OK;
                Close();
            };

            btnBorrowScannedBook.Click += (s, e) => PerformScannedBookAction();
        }

        private void ProcessScan()
        {
            string raw = txtQrInput.Text.Trim();
            if (string.IsNullOrEmpty(raw))
            {
                MessageBox.Show("Please scan a book QR code or barcode, or enter an ISBN.", "Scanner Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQrInput.Focus();
                return;
            }

            // Strip prefix tags (e.g. ISBN:xxx, BOOK:xxx, LOAN:member:isbn:date)
            string lookupTerm = raw;
            if (lookupTerm.StartsWith("ISBN:", StringComparison.OrdinalIgnoreCase))
            {
                lookupTerm = lookupTerm.Substring("ISBN:".Length).Trim();
            }
            else if (lookupTerm.StartsWith("BOOK:", StringComparison.OrdinalIgnoreCase))
            {
                lookupTerm = lookupTerm.Substring("BOOK:".Length).Trim();
            }
            else if (lookupTerm.StartsWith("LOAN:", StringComparison.OrdinalIgnoreCase))
            {
                string[] parts = lookupTerm.Split(':');
                if (parts.Length >= 3)
                {
                    lookupTerm = parts[2].Trim();
                }
            }

            // 1. Direct ISBN search (supports with or without hyphens)
            var book = Database.GetBookByIsbn(lookupTerm);

            // 2. Keyword fallback (title, author, shelf location)
            if (book == null)
            {
                var matches = Database.GetBooks(lookupTerm);
                if (matches.Count > 0) book = matches[0];
            }

            if (book != null)
            {
                SelectedBook = book;
                DisplayBook(book);
            }
            else
            {
                SelectedBook = null;
                picBookQr.Image?.Dispose();
                picBookQr.Image = null;

                lblResultTitle.Text = "⚠️ Book Not Found";
                lblResultTitle.ForeColor = Theme.Danger;
                lblResultAuthor.Text = $"No catalog item matches code: '{raw}'";
                lblResultIsbn.Text = "Make sure the barcode or QR code is valid.";
                lblResultCategory.Text = "";
                lblResultShelf.Text = "";
                lblResultAvailability.Text = "Please check with the library front desk or try another scan.";
                lblResultAvailability.ForeColor = Theme.Danger;

                btnGoToBook.Visible = false;
                btnBorrowScannedBook.Visible = false;
            }

            // Keep text selected so the next scanner trigger immediately overwrites
            txtQrInput.Focus();
            txtQrInput.SelectAll();
        }

        private void DisplayBook(Book book)
        {
            lblResultTitle.Text = book.Title;
            lblResultTitle.ForeColor = Theme.TextPrimary;
            lblResultAuthor.Text = $"Author: {book.Author}  •  Published: {book.PublishYear} ({book.Publisher})";
            lblResultIsbn.Text = $"ISBN: {book.ISBN}";
            lblResultCategory.Text = $"Academic Section: {book.Category}";
            lblResultShelf.Text = $"🏛️ Shelf Location / Call No: {book.ShelfLocation}";

            if (book.AvailableCopies > 0)
            {
                lblResultAvailability.Text = $"✓ AVAILABLE: {book.AvailableCopies} of {book.TotalCopies} copies on shelf";
                lblResultAvailability.ForeColor = Theme.Success;
            }
            else
            {
                lblResultAvailability.Text = $"✗ CURRENTLY CHECKED OUT (0 of {book.TotalCopies} available)";
                lblResultAvailability.ForeColor = Theme.Danger;
            }

            // Render live QR Code
            try
            {
                picBookQr.Image?.Dispose();
                picBookQr.Image = QrCodes.GenerateQrCode($"ISBN:{book.ISBN}", 4);
            }
            catch
            {
                picBookQr.Image = null;
            }

            // Button 1: View in Catalog
            btnGoToBook.Visible = true;
            btnGoToBook.Text = "🔍 View in Catalog";

            // Button 2: Action based on role
            btnBorrowScannedBook.Visible = true;
            if (Session.IsUser)
            {
                if (book.AvailableCopies > 0)
                {
                    btnBorrowScannedBook.Enabled = true;
                    btnBorrowScannedBook.Text = "📖 Borrow This Book";
                    btnBorrowScannedBook.BackColor = Theme.Primary;
                }
                else
                {
                    btnBorrowScannedBook.Enabled = false;
                    btnBorrowScannedBook.Text = "✗ All Copies Checked Out";
                    btnBorrowScannedBook.BackColor = Color.FromArgb(156, 163, 175);
                }
            }
            else
            {
                btnBorrowScannedBook.Enabled = true;
                btnBorrowScannedBook.Text = "⚡ Manage in Circulation";
                btnBorrowScannedBook.BackColor = Theme.Primary;
            }
        }

        private void PerformScannedBookAction()
        {
            if (SelectedBook == null) return;

            if (!Session.IsUser)
            {
                // Admin / Librarian: Go to circulation desk to issue/return
                OpenCirculation = true;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            // Student / Patron Self-Service Borrowing
            if (SelectedBook.AvailableCopies <= 0)
            {
                MessageBox.Show($"Sorry! All copies of '{SelectedBook.Title}' are currently borrowed by other students.\n\nPlease check back once a copy is returned to shelf {SelectedBook.ShelfLocation}.", "Zero Copies Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = Session.CurrentUser?.Email ?? "";
            var member = Database.GetMemberByEmail(email) ?? Database.GetMemberByCode("LIB-M1001");
            if (member == null)
            {
                MessageBox.Show("Student patron record not found in system. Please contact the librarian.", "Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Confirm self-service loan:\n\n📖 \"{SelectedBook.Title}\"\nAuthor: {SelectedBook.Author}\nISBN: {SelectedBook.ISBN}\nShelf: {SelectedBook.ShelfLocation}\n\nStandard student loan period is 14 days (Due: {DateTime.Now.AddDays(14):MMMM dd, yyyy}).\n\nWould you like to borrow this book?", "Confirm Book Borrowing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int userId = Session.CurrentUser?.Id ?? 1;
            var (success, msg) = Database.IssueBook(SelectedBook.Id, member.Id, userId, 14, "Student QR Scanner Self-Service Borrow");

            if (success)
            {
                BookWasBorrowed = true;
                MessageBox.Show($"Success! You have borrowed \"{SelectedBook.Title}\".\n\nOfficial Due Date: {DateTime.Now.AddDays(14):MMMM dd, yyyy}\n\nThis book is now listed in 'My Current Active Loans & Due Dates' on your dashboard.", "Book Borrowed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the current displayed book record
                var updated = Database.GetBookById(SelectedBook.Id);
                if (updated != null)
                {
                    SelectedBook = updated;
                    DisplayBook(updated);
                }
            }
            else
            {
                MessageBox.Show(msg, "Borrow Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
