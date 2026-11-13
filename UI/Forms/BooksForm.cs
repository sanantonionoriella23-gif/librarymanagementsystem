using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class BooksForm : Form
    {
        private int _selectedBookId = 0;
        private int _initialBookId = 0;

        public BooksForm(int initialBookId = 0)
        {
            _initialBookId = initialBookId;
            InitializeComponent();
            ApplyCustomStyling();
            WireEvents();

            Load += (s, e) =>
            {
                LoadCategories();
                LoadBooks();
                ApplyRolePermissions();
                if (_initialBookId > 0)
                {
                    SelectBookInGrid(_initialBookId);
                }
            };
        }


        private void ApplyCustomStyling()
        {
            Theme.StyleDataGridView(dgvBooks);
            Theme.StylePrimaryButton(btnAdd);
            Theme.StylePrimaryButton(btnBorrowBook);
            Theme.StylePrimaryButton(btnScanQr);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleSecondaryButton(btnClear);
            Theme.StyleSecondaryButton(btnSaveQr);
            Theme.StyleSecondaryButton(btnPrintSpine);

            pnlTop.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.BorderSubtle))
                {
                    e.Graphics.DrawLine(p, 0, pnlTop.Height - 1, pnlTop.Width, pnlTop.Height - 1);
                }
            };

            pnlFilter.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.BorderSubtle))
                {
                    e.Graphics.DrawLine(p, 0, pnlFilter.Height - 1, pnlFilter.Width, pnlFilter.Height - 1);
                }
            };
        }

        private void ApplyRolePermissions()
        {
            var role = Session.CurrentUser?.Role ?? UserRole.User;
            bool canManage = Access.CanManageBooks(role);
            bool canDelete = Access.CanDeleteBooks(role);

            if (role == UserRole.User)
            {
                
                btnAdd.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnClear.Visible = false;
                btnBorrowBook.Visible = true;

                
                txtIsbn.ReadOnly = true;
                txtBookTitle.ReadOnly = true;
                txtAuthor.ReadOnly = true;
                txtPublisher.ReadOnly = true;
                txtShelf.ReadOnly = true;
                numYear.Enabled = false;
                numTotalCopies.Enabled = false;
                numAvailableCopies.Enabled = false;
                cmbCategory.Enabled = false;
                secBookDetails.Title = "Select a Book to Borrow";
            }
            else
            {
                
                btnAdd.Visible = canManage;
                btnUpdate.Visible = canManage;
                btnClear.Visible = canManage;
                btnDelete.Visible = canDelete;
                btnBorrowBook.Visible = false;
                secBookDetails.Title = "Book Details & Shelf Location";
            }
        }

        private void LoadCategories()
        {
            var categories = Database.GetCategories();

            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");
            foreach (var cat in categories)
            {
                cmbCategoryFilter.Items.Add(cat);
            }
            cmbCategoryFilter.SelectedIndex = 0;

            cmbCategory.Items.Clear();
            foreach (var cat in categories)
            {
                cmbCategory.Items.Add(cat);
            }
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
        }

        private void LoadBooks()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                string category = cmbCategoryFilter.SelectedItem?.ToString() ?? "All Categories";

                var books = Database.GetBooks(search, category);
                dgvBooks.DataSource = null;
                dgvBooks.DataSource = books;

                foreach (DataGridViewColumn col in dgvBooks.Columns)
                {
                    string prop = col.DataPropertyName ?? col.Name ?? "";
                    if (string.Equals(prop, "Id", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(prop, "CreatedAt", StringComparison.OrdinalIgnoreCase))
                    {
                        col.Visible = false;
                    }
                    else if (string.Equals(prop, "ISBN", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "ISBN";
                        col.Width = 120;
                    }
                    else if (string.Equals(prop, "Title", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Title";
                        col.Width = 220;
                    }
                    else if (string.Equals(prop, "Author", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Author";
                        col.Width = 140;
                    }
                    else if (string.Equals(prop, "Category", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Category";
                        col.Width = 130;
                    }
                    else if (string.Equals(prop, "AvailableCopies", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Available";
                        col.Width = 70;
                    }
                    else if (string.Equals(prop, "TotalCopies", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Total";
                        col.Width = 60;
                    }
                    else if (string.Equals(prop, "ShelfLocation", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Shelf";
                        col.Width = 100;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in LoadBooks: " + ex.Message);
            }
        }

        private void WireEvents()
        {
            btnClose.Click += (s, e) => Close();
            txtSearch.TextChanged += (s, e) => LoadBooks();
            cmbCategoryFilter.SelectedIndexChanged += (s, e) => LoadBooks();

            dgvBooks.SelectionChanged += (s, e) =>
            {
                if (dgvBooks.CurrentRow != null && dgvBooks.CurrentRow.DataBoundItem is Book book)
                {
                    PopulateFields(book);
                }
            };

            btnAdd.Click += (s, e) => PerformAddBook();
            btnBorrowBook.Click += BtnBorrowBook_Click;
            btnUpdate.Click += (s, e) => PerformUpdateBook();
            btnDelete.Click += (s, e) => PerformDeleteBook();
            btnClear.Click += (s, e) => ClearFields();

            txtIsbn.TextChanged += (s, e) => RefreshQrCode();
            btnSaveQr.Click += (s, e) => SaveQrImage();
            btnPrintSpine.Click += (s, e) => PrintSpineLabel();

            // QR Scanner Integration
            btnScanQr.Click += (s, e) =>
            {
                using (var scanner = new QrScannerForm())
                {
                    if (scanner.ShowDialog() == DialogResult.OK && scanner.SelectedBook != null)
                    {
                        SelectBookInGrid(scanner.SelectedBook.Id);
                    }
                }
            };
        }

        private void SelectBookInGrid(int bookId)
        {
            txtSearch.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            LoadBooks();

            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (row.DataBoundItem is Book b && b.Id == bookId)
                {
                    row.Selected = true;
                    dgvBooks.CurrentCell = row.Cells["Title"];
                    PopulateFields(b);
                    break;
                }
            }
        }

        private void PopulateFields(Book book)
        {
            _selectedBookId = book.Id;
            txtIsbn.Text = book.ISBN;
            txtBookTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtPublisher.Text = book.Publisher;
            txtShelf.Text = book.ShelfLocation;
            numYear.Value = Math.Min(Math.Max(book.PublishYear, numYear.Minimum), numYear.Maximum);
            numTotalCopies.Value = Math.Min(Math.Max(book.TotalCopies, numTotalCopies.Minimum), numTotalCopies.Maximum);
            numAvailableCopies.Value = Math.Min(Math.Max(book.AvailableCopies, numAvailableCopies.Minimum), numAvailableCopies.Maximum);

            if (cmbCategory.Items.Contains(book.Category))
            {
                cmbCategory.SelectedItem = book.Category;
            }
            else
            {
                cmbCategory.Items.Add(book.Category);
                cmbCategory.SelectedItem = book.Category;
            }

            RefreshQrCode();

            if (Session.IsUser)
            {
                if (book.AvailableCopies > 0)
                {
                    btnBorrowBook.Enabled = true;
                    btnBorrowBook.Text = $"📖 Borrow \"{book.Title}\"";
                    btnBorrowBook.BackColor = Theme.Primary;
                }
                else
                {
                    btnBorrowBook.Enabled = false;
                    btnBorrowBook.Text = "✗ All Copies Checked Out";
                    btnBorrowBook.BackColor = Color.FromArgb(156, 163, 175);
                }
            }
        }

        private void RefreshQrCode()
        {
            string isbn = txtIsbn.Text.Trim();
            if (!string.IsNullOrEmpty(isbn))
            {
                picQr.Image?.Dispose();
                picQr.Image = QrCodes.GenerateQrCode($"ISBN:{isbn}");
            }
            else
            {
                picQr.Image?.Dispose();
                picQr.Image = null;
            }
        }

        private void SaveQrImage()
        {
            if (picQr.Image == null)
            {
                MessageBox.Show("No QR code available to save.", "Save QR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg";
                sfd.FileName = $"QR_ISBN_{txtIsbn.Text.Trim().Replace("-", "_")}.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    picQr.Image.Save(sfd.FileName, ImageFormat.Png);
                    MessageBox.Show("QR code successfully saved to:\n" + sfd.FileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void PrintSpineLabel()
        {
            if (string.IsNullOrWhiteSpace(txtIsbn.Text) || string.IsNullOrWhiteSpace(txtBookTitle.Text))
            {
                MessageBox.Show("Please select or enter book information before creating a spine label.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            int width = 360;
            int height = 500;
            Bitmap label = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(label))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                
                using (Pen borderPen = new Pen(Theme.PrimaryDark, 3))
                {
                    g.DrawRectangle(borderPen, 6, 6, width - 12, height - 12);
                }

                
                using (SolidBrush headerBg = new SolidBrush(Theme.PrimaryLight))
                {
                    g.FillRectangle(headerBg, 8, 8, width - 16, 50);
                }

                using (Font schoolFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (SolidBrush pinkBrush = new SolidBrush(Theme.PrimaryDark))
                {
                    g.DrawString("ATHENA STATE UNIVERSITY", schoolFont, pinkBrush, new PointF(18, 14));
                }

                using (Font subFont = new Font("Segoe UI", 7.5F))
                using (SolidBrush subBrush = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString("LIBRARY & LEARNING RESOURCE CENTER", subFont, subBrush, new PointF(18, 32));
                }

               
                using (Font titleFont = new Font("Segoe UI", 10F, FontStyle.Bold))
                using (SolidBrush darkBrush = new SolidBrush(Theme.TextPrimary))
                {
                    g.DrawString(txtBookTitle.Text, titleFont, darkBrush, new RectangleF(18, 68, width - 36, 45));
                }

                
                using (Font authFont = new Font("Segoe UI", 8.5F))
                using (SolidBrush authBrush = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString($"By: {txtAuthor.Text}", authFont, authBrush, new PointF(18, 118));
                }

               
                using (SolidBrush boxBg = new SolidBrush(Color.FromArgb(255, 247, 250)))
                using (Pen boxPen = new Pen(Theme.BorderSubtle, 1.5f))
                {
                    Rectangle box = new Rectangle(18, 145, width - 36, 60);
                    g.FillRectangle(boxBg, box);
                    g.DrawRectangle(boxPen, box);
                }

                using (Font callHeaderFont = new Font("Segoe UI", 7.5F, FontStyle.Bold))
                using (SolidBrush callHeaderBrush = new SolidBrush(Theme.PrimaryDark))
                {
                    g.DrawString("CALL NO. / ACCESSION LOCATION:", callHeaderFont, callHeaderBrush, new PointF(26, 152));
                }

                using (Font callFont = new Font("Segoe UI", 12F, FontStyle.Bold))
                using (SolidBrush callBrush = new SolidBrush(Theme.TextPrimary))
                {
                    g.DrawString(string.IsNullOrWhiteSpace(txtShelf.Text) ? "CIRC-GENERAL" : txtShelf.Text, callFont, callBrush, new PointF(26, 170));
                }

               
                Bitmap qr = QrCodes.GenerateQrCode($"ISBN:{txtIsbn.Text.Trim()}", 4);
                g.DrawImage(qr, (width - 160) / 2, 220, 160, 160);

                
                using (Font isbnFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (SolidBrush isbnBrush = new SolidBrush(Theme.TextPrimary))
                {
                    string isbnStr = $"ISBN: {txtIsbn.Text.Trim()}";
                    SizeF sz = g.MeasureString(isbnStr, isbnFont);
                    g.DrawString(isbnStr, isbnFont, isbnBrush, (width - sz.Width) / 2, 395);
                }

               
                using (Font footFont = new Font("Segoe UI", 7.5F))
                using (SolidBrush footBrush = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString("PROPERTY OF UNIVERSITY LIBRARY • DO NOT REMOVE", footFont, footBrush, new PointF(24, 455));
                }
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image (*.png)|*.png";
                sfd.FileName = $"SPINE_LABEL_{txtIsbn.Text.Trim().Replace("-", "_")}.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    label.Save(sfd.FileName, ImageFormat.Png);
                    MessageBox.Show("Official Library Book Spine Label created and saved to:\n" + sfd.FileName, "Spine Label Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ClearFields()
        {
            _selectedBookId = 0;
            txtIsbn.Clear();
            txtBookTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtShelf.Clear();
            numYear.Value = DateTime.Now.Year;
            numTotalCopies.Value = 1;
            numAvailableCopies.Value = 1;
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            picQr.Image?.Dispose();
            picQr.Image = null;

            if (Session.IsUser)
            {
                btnBorrowBook.Enabled = false;
                btnBorrowBook.Text = "📖 Select a Book to Borrow";
            }
        }

        private void BtnBorrowBook_Click(object? sender, EventArgs e)
        {
            if (_selectedBookId <= 0)
            {
                MessageBox.Show("Please select a book from the catalog list to borrow.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var book = Database.GetBookById(_selectedBookId);
            if (book == null)
            {
                MessageBox.Show("Book record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (book.AvailableCopies <= 0)
            {
                MessageBox.Show($"Sorry! All copies of '{book.Title}' are currently borrowed by other students.\n\nPlease check back once a copy is returned to shelf {book.ShelfLocation}.", "Zero Copies Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            string email = Session.CurrentUser?.Email ?? "";
            var member = Database.GetMemberByEmail(email) ?? Database.GetMemberByCode("LIB-M1001");
            if (member == null)
            {
                MessageBox.Show("Member account not found in system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Confirm loan request:\n\n📖 \"{book.Title}\"\nAuthor: {book.Author}\nISBN: {book.ISBN}\nShelf Location: {book.ShelfLocation}\n\nStandard student loan period is 14 days (Due: {DateTime.Now.AddDays(14):MMMM dd, yyyy}).\n\nWould you like to borrow this book?", "Confirm Book Borrowing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int userId = Session.CurrentUser?.Id ?? 1;
            var (success, msg) = Database.IssueBook(book.Id, member.Id, userId, 14, "Student Self-Service Borrow");

            if (success)
            {
                MessageBox.Show($"Success! You have borrowed \"{book.Title}\".\n\nOfficial Due Date: {DateTime.Now.AddDays(14):MMMM dd, yyyy}\n\nThis book is now listed in 'My Current Active Loans & Due Dates' on your dashboard.", "Book Borrowed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
                var updated = Database.GetBookById(book.Id);
                if (updated != null) PopulateFields(updated);
            }
            else
            {
                MessageBox.Show(msg, "Borrow Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PerformAddBook()
        {
            if (!Access.CanAddBooks(Session.CurrentUser?.Role ?? UserRole.User))
            {
                MessageBox.Show("Access Denied: You do not have permission to add books.", "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            var existing = Database.GetBookByIsbn(txtIsbn.Text.Trim());
            if (existing != null)
            {
                MessageBox.Show("A book with this ISBN already exists in the catalog.", "Duplicate ISBN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = new Book
            {
                ISBN = txtIsbn.Text.Trim(),
                Title = txtBookTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Category = cmbCategory.SelectedItem?.ToString() ?? "General",
                Publisher = txtPublisher.Text.Trim(),
                PublishYear = (int)numYear.Value,
                TotalCopies = (int)numTotalCopies.Value,
                AvailableCopies = (int)numAvailableCopies.Value,
                ShelfLocation = txtShelf.Text.Trim()
            };

            if (Database.AddBook(book))
            {
                MessageBox.Show("Book added successfully to academic catalog!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to add book.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformUpdateBook()
        {
            if (!Access.CanManageBooks(Session.CurrentUser?.Role ?? UserRole.User))
            {
                MessageBox.Show("Access Denied: Only Library Staff and Administrators can update book records.", "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedBookId <= 0)
            {
                MessageBox.Show("Please select a book from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInputs()) return;

            var book = new Book
            {
                Id = _selectedBookId,
                ISBN = txtIsbn.Text.Trim(),
                Title = txtBookTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Category = cmbCategory.SelectedItem?.ToString() ?? "General",
                Publisher = txtPublisher.Text.Trim(),
                PublishYear = (int)numYear.Value,
                TotalCopies = (int)numTotalCopies.Value,
                AvailableCopies = (int)numAvailableCopies.Value,
                ShelfLocation = txtShelf.Text.Trim()
            };

            if (Database.UpdateBook(book))
            {
                MessageBox.Show("Book details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Failed to update book.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformDeleteBook()
        {
            if (!Access.CanDeleteBooks(Session.CurrentUser?.Role ?? UserRole.User))
            {
                MessageBox.Show("Access Denied: Only System Administrators can permanently delete books from the catalog.", "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedBookId <= 0)
            {
                MessageBox.Show("Please select a book to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete '{txtBookTitle.Text}' from the university catalog?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Database.DeleteBook(_selectedBookId))
                {
                    MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to delete book.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtIsbn.Text))
            {
                MessageBox.Show("ISBN cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIsbn.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
            {
                MessageBox.Show("Book title cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBookTitle.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Author cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthor.Focus();
                return false;
            }
            if (numAvailableCopies.Value > numTotalCopies.Value)
            {
                MessageBox.Show("Available copies cannot exceed total copies.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAvailableCopies.Focus();
                return false;
            }
            return true;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
