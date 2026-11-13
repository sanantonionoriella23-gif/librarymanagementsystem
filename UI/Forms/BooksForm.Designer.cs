namespace LibraryManagementSystem
{
    partial class BooksForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.Label lblCatFilter;
        private System.Windows.Forms.Button btnScanQr;
        private System.Windows.Forms.DataGridView dgvBooks;
        private LibraryManagementSystem.SectionBox secBookDetails;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.NumericUpDown numTotalCopies;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.NumericUpDown numAvailableCopies;
        private System.Windows.Forms.Label lblShelf;
        private System.Windows.Forms.TextBox txtShelf;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox picQr;
        private System.Windows.Forms.Label lblQr;
        private System.Windows.Forms.Button btnSaveQr;
        private System.Windows.Forms.Button btnPrintSpine;

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
            pnlFilter = new Panel();
            btnScanQr = new Button();
            cmbCategoryFilter = new ComboBox();
            lblCatFilter = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            dgvBooks = new DataGridView();
            secBookDetails = new SectionBox();
            btnPrintSpine = new Button();
            btnSaveQr = new Button();
            lblQr = new Label();
            picQr = new PictureBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnBorrowBook = new Button();
            txtShelf = new TextBox();
            lblShelf = new Label();
            numAvailableCopies = new NumericUpDown();
            lblAvailable = new Label();
            numTotalCopies = new NumericUpDown();
            lblTotal = new Label();
            numYear = new NumericUpDown();
            lblYear = new Label();
            txtPublisher = new TextBox();
            lblPublisher = new Label();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            txtAuthor = new TextBox();
            lblAuthor = new Label();
            txtBookTitle = new TextBox();
            lblBookTitle = new Label();
            txtIsbn = new TextBox();
            lblIsbn = new Label();
            pnlTop.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            secBookDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAvailableCopies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTotalCopies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
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
            btnClose.BackColor = Color.FromArgb(252, 228, 236);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
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
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(194, 24, 91);
            lblTitle.Location = new Point(31, 22);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(237, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Books Catalog";
            lblTitle.Click += lblTitle_Click;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.White;
            pnlFilter.Controls.Add(btnScanQr);
            pnlFilter.Controls.Add(cmbCategoryFilter);
            pnlFilter.Controls.Add(lblCatFilter);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(lblSearch);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 100);
            pnlFilter.Margin = new Padding(4, 5, 4, 5);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1714, 83);
            pnlFilter.TabIndex = 1;
            // 
            // btnScanQr
            // 
            btnScanQr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScanQr.BackColor = Color.FromArgb(233, 30, 99);
            btnScanQr.FlatAppearance.BorderSize = 0;
            btnScanQr.FlatStyle = FlatStyle.Flat;
            btnScanQr.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnScanQr.ForeColor = Color.White;
            btnScanQr.Location = new Point(1471, 15);
            btnScanQr.Margin = new Padding(4, 5, 4, 5);
            btnScanQr.Name = "btnScanQr";
            btnScanQr.Size = new Size(214, 53);
            btnScanQr.TabIndex = 4;
            btnScanQr.Text = "📷 Scan Book QR";
            btnScanQr.UseVisualStyleBackColor = false;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryFilter.Font = new Font("Segoe UI", 9.5F);
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(743, 20);
            cmbCategoryFilter.Margin = new Padding(4, 5, 4, 5);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(313, 33);
            cmbCategoryFilter.TabIndex = 3;
            // 
            // lblCatFilter
            // 
            lblCatFilter.AutoSize = true;
            lblCatFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCatFilter.ForeColor = Color.FromArgb(43, 45, 66);
            lblCatFilter.Location = new Point(646, 27);
            lblCatFilter.Margin = new Padding(4, 0, 4, 0);
            lblCatFilter.Name = "lblCatFilter";
            lblCatFilter.Size = new Size(95, 25);
            lblCatFilter.TabIndex = 2;
            lblCatFilter.Text = "Category:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.Location = new Point(179, 20);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by title, author, or ISBN...";
            txtSearch.Size = new Size(427, 33);
            txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(43, 45, 66);
            lblSearch.Location = new Point(31, 27);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(162, 25);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "🔍 Search Books:";
            // 
            // dgvBooks
            // 
            dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(29, 207);
            dgvBooks.Margin = new Padding(4, 5, 4, 5);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 62;
            dgvBooks.Size = new Size(1086, 960);
            dgvBooks.TabIndex = 2;
            // 
            // secBookDetails
            // 
            secBookDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            secBookDetails.BackColor = Color.White;
            secBookDetails.BorderRadius = 12;
            secBookDetails.Controls.Add(btnPrintSpine);
            secBookDetails.Controls.Add(btnSaveQr);
            secBookDetails.Controls.Add(lblQr);
            secBookDetails.Controls.Add(picQr);
            secBookDetails.Controls.Add(btnClear);
            secBookDetails.Controls.Add(btnDelete);
            secBookDetails.Controls.Add(btnUpdate);
            secBookDetails.Controls.Add(btnAdd);
            secBookDetails.Controls.Add(btnBorrowBook);
            secBookDetails.Controls.Add(txtShelf);
            secBookDetails.Controls.Add(lblShelf);
            secBookDetails.Controls.Add(numAvailableCopies);
            secBookDetails.Controls.Add(lblAvailable);
            secBookDetails.Controls.Add(numTotalCopies);
            secBookDetails.Controls.Add(lblTotal);
            secBookDetails.Controls.Add(numYear);
            secBookDetails.Controls.Add(lblYear);
            secBookDetails.Controls.Add(txtPublisher);
            secBookDetails.Controls.Add(lblPublisher);
            secBookDetails.Controls.Add(cmbCategory);
            secBookDetails.Controls.Add(lblCategory);
            secBookDetails.Controls.Add(txtAuthor);
            secBookDetails.Controls.Add(lblAuthor);
            secBookDetails.Controls.Add(txtBookTitle);
            secBookDetails.Controls.Add(lblBookTitle);
            secBookDetails.Controls.Add(txtIsbn);
            secBookDetails.Controls.Add(lblIsbn);
            secBookDetails.HeaderColor = Color.FromArgb(233, 30, 99);
            secBookDetails.Location = new Point(1136, 207);
            secBookDetails.Margin = new Padding(4, 5, 4, 5);
            secBookDetails.Name = "secBookDetails";
            secBookDetails.Padding = new Padding(23, 75, 23, 27);
            secBookDetails.ShowHeaderBar = true;
            secBookDetails.Size = new Size(550, 960);
            secBookDetails.TabIndex = 3;
            secBookDetails.Title = "Book Details & Shelf Location";
            // 
            // btnPrintSpine
            // 
            btnPrintSpine.BackColor = Color.FromArgb(255, 247, 250);
            btnPrintSpine.FlatStyle = FlatStyle.Flat;
            btnPrintSpine.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnPrintSpine.ForeColor = Color.FromArgb(194, 24, 91);
            btnPrintSpine.Location = new Point(364, 625);
            btnPrintSpine.Margin = new Padding(4, 5, 4, 5);
            btnPrintSpine.Name = "btnPrintSpine";
            btnPrintSpine.Size = new Size(157, 40);
            btnPrintSpine.TabIndex = 25;
            btnPrintSpine.Text = "🖨️ Spine Label";
            btnPrintSpine.UseVisualStyleBackColor = false;
            // 
            // btnSaveQr
            // 
            btnSaveQr.BackColor = Color.FromArgb(252, 228, 236);
            btnSaveQr.FlatStyle = FlatStyle.Flat;
            btnSaveQr.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnSaveQr.ForeColor = Color.FromArgb(194, 24, 91);
            btnSaveQr.Location = new Point(364, 575);
            btnSaveQr.Margin = new Padding(4, 5, 4, 5);
            btnSaveQr.Name = "btnSaveQr";
            btnSaveQr.Size = new Size(157, 40);
            btnSaveQr.TabIndex = 24;
            btnSaveQr.Text = "Save QR Image";
            btnSaveQr.UseVisualStyleBackColor = false;
            // 
            // lblQr
            // 
            lblQr.AutoSize = true;
            lblQr.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblQr.ForeColor = Color.FromArgb(43, 45, 66);
            lblQr.Location = new Point(371, 367);
            lblQr.Margin = new Padding(4, 0, 4, 0);
            lblQr.Name = "lblQr";
            lblQr.Size = new Size(129, 23);
            lblQr.TabIndex = 23;
            lblQr.Text = "ISBN QR Code:";
            // 
            // picQr
            // 
            picQr.BackColor = Color.White;
            picQr.BorderStyle = BorderStyle.FixedSingle;
            picQr.Location = new Point(371, 400);
            picQr.Margin = new Padding(4, 5, 4, 5);
            picQr.Name = "picQr";
            picQr.Size = new Size(142, 165);
            picQr.SizeMode = PictureBoxSizeMode.Zoom;
            picQr.TabIndex = 22;
            picQr.TabStop = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(108, 117, 125);
            btnClear.Location = new Point(29, 800);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(493, 53);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 235, 238);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(198, 40, 40);
            btnDelete.Location = new Point(350, 725);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(171, 60);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Delete Book";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.FromArgb(233, 30, 99);
            btnUpdate.Location = new Point(186, 725);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 60);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(233, 30, 99);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(29, 725);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(143, 60);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "+ Add Book";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnBorrowBook
            // 
            btnBorrowBook.BackColor = Color.FromArgb(216, 27, 96);
            btnBorrowBook.FlatStyle = FlatStyle.Flat;
            btnBorrowBook.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBorrowBook.ForeColor = Color.White;
            btnBorrowBook.Location = new Point(29, 725);
            btnBorrowBook.Margin = new Padding(4, 5, 4, 5);
            btnBorrowBook.Name = "btnBorrowBook";
            btnBorrowBook.Size = new Size(493, 70);
            btnBorrowBook.TabIndex = 26;
            btnBorrowBook.Text = "📖 Borrow This Book (14 Days)";
            btnBorrowBook.UseVisualStyleBackColor = false;
            // 
            // txtShelf
            // 
            txtShelf.Font = new Font("Segoe UI", 9F);
            txtShelf.Location = new Point(29, 658);
            txtShelf.Margin = new Padding(4, 5, 4, 5);
            txtShelf.Name = "txtShelf";
            txtShelf.Size = new Size(313, 31);
            txtShelf.TabIndex = 17;
            // 
            // lblShelf
            // 
            lblShelf.AutoSize = true;
            lblShelf.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblShelf.ForeColor = Color.FromArgb(43, 45, 66);
            lblShelf.Location = new Point(29, 628);
            lblShelf.Margin = new Padding(4, 0, 4, 0);
            lblShelf.Name = "lblShelf";
            lblShelf.Size = new Size(129, 23);
            lblShelf.TabIndex = 16;
            lblShelf.Text = "Shelf Location:";
            // 
            // numAvailableCopies
            // 
            numAvailableCopies.Font = new Font("Segoe UI", 9F);
            numAvailableCopies.Location = new Point(193, 575);
            numAvailableCopies.Margin = new Padding(4, 5, 4, 5);
            numAvailableCopies.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numAvailableCopies.Name = "numAvailableCopies";
            numAvailableCopies.Size = new Size(150, 31);
            numAvailableCopies.TabIndex = 15;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAvailable.ForeColor = Color.FromArgb(43, 45, 66);
            lblAvailable.Location = new Point(193, 545);
            lblAvailable.Margin = new Padding(4, 0, 4, 0);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(89, 23);
            lblAvailable.TabIndex = 14;
            lblAvailable.Text = "Available:";
            // 
            // numTotalCopies
            // 
            numTotalCopies.Font = new Font("Segoe UI", 9F);
            numTotalCopies.Location = new Point(29, 575);
            numTotalCopies.Margin = new Padding(4, 5, 4, 5);
            numTotalCopies.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numTotalCopies.Name = "numTotalCopies";
            numTotalCopies.Size = new Size(150, 31);
            numTotalCopies.TabIndex = 13;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(43, 45, 66);
            lblTotal.Location = new Point(29, 545);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(112, 23);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "Total Copies:";
            // 
            // numYear
            // 
            numYear.Font = new Font("Segoe UI", 9F);
            numYear.Location = new Point(29, 492);
            numYear.Margin = new Padding(4, 5, 4, 5);
            numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1800, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(314, 31);
            numYear.TabIndex = 11;
            numYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblYear.ForeColor = Color.FromArgb(43, 45, 66);
            lblYear.Location = new Point(29, 462);
            lblYear.Margin = new Padding(4, 0, 4, 0);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(112, 23);
            lblYear.TabIndex = 10;
            lblYear.Text = "Publish Year:";
            // 
            // txtPublisher
            // 
            txtPublisher.Font = new Font("Segoe UI", 9F);
            txtPublisher.Location = new Point(29, 408);
            txtPublisher.Margin = new Padding(4, 5, 4, 5);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(313, 31);
            txtPublisher.TabIndex = 9;
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPublisher.ForeColor = Color.FromArgb(43, 45, 66);
            lblPublisher.Location = new Point(29, 378);
            lblPublisher.Margin = new Padding(4, 0, 4, 0);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(90, 23);
            lblPublisher.TabIndex = 8;
            lblPublisher.Text = "Publisher:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 9F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(29, 325);
            cmbCategory.Margin = new Padding(4, 5, 4, 5);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(491, 33);
            cmbCategory.TabIndex = 7;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(43, 45, 66);
            lblCategory.Location = new Point(29, 295);
            lblCategory.Margin = new Padding(4, 0, 4, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(89, 23);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Category:";
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 9F);
            txtAuthor.Location = new Point(29, 242);
            txtAuthor.Margin = new Padding(4, 5, 4, 5);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(491, 31);
            txtAuthor.TabIndex = 5;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAuthor.ForeColor = Color.FromArgb(43, 45, 66);
            lblAuthor.Location = new Point(29, 212);
            lblAuthor.Margin = new Padding(4, 0, 4, 0);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(90, 23);
            lblAuthor.TabIndex = 4;
            lblAuthor.Text = "Author(s):";
            // 
            // txtBookTitle
            // 
            txtBookTitle.Font = new Font("Segoe UI", 9F);
            txtBookTitle.Location = new Point(29, 158);
            txtBookTitle.Margin = new Padding(4, 5, 4, 5);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(491, 31);
            txtBookTitle.TabIndex = 3;
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblBookTitle.ForeColor = Color.FromArgb(43, 45, 66);
            lblBookTitle.Location = new Point(29, 128);
            lblBookTitle.Margin = new Padding(4, 0, 4, 0);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(97, 23);
            lblBookTitle.TabIndex = 2;
            lblBookTitle.Text = "Book Title:";
            // 
            // txtIsbn
            // 
            txtIsbn.Font = new Font("Segoe UI", 9F);
            txtIsbn.Location = new Point(29, 80);
            txtIsbn.Margin = new Padding(4, 5, 4, 5);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(491, 31);
            txtIsbn.TabIndex = 1;
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblIsbn.ForeColor = Color.FromArgb(43, 45, 66);
            lblIsbn.Location = new Point(29, 50);
            lblIsbn.Margin = new Padding(4, 0, 4, 0);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(54, 23);
            lblIsbn.TabIndex = 0;
            lblIsbn.Text = "ISBN:";
            // 
            // BooksForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 247, 250);
            ClientSize = new Size(1714, 1170);
            Controls.Add(secBookDetails);
            Controls.Add(dgvBooks);
            Controls.Add(pnlFilter);
            Controls.Add(pnlTop);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1419, 963);
            Name = "BooksForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management System - Books Catalog";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            secBookDetails.ResumeLayout(false);
            secBookDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picQr).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAvailableCopies).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTotalCopies).EndInit();
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ResumeLayout(false);
        }
    }
}
