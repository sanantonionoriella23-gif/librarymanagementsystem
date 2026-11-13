namespace LibraryManagementSystem
{
    partial class QrScannerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Button btnClose;
        private LibraryManagementSystem.SectionBox secScanner;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtQrInput;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Panel pnlResultCard;
        private System.Windows.Forms.PictureBox picBookQr;
        private System.Windows.Forms.Label lblResultTitle;
        private System.Windows.Forms.Label lblResultAuthor;
        private System.Windows.Forms.Label lblResultIsbn;
        private System.Windows.Forms.Label lblResultCategory;
        private System.Windows.Forms.Label lblResultShelf;
        private System.Windows.Forms.Label lblResultAvailability;
        private System.Windows.Forms.Button btnGoToBook;
        private System.Windows.Forms.Button btnBorrowScannedBook;
        private System.Windows.Forms.Label lblScanHint;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.secScanner = new LibraryManagementSystem.SectionBox();
            this.lblScanHint = new System.Windows.Forms.Label();
            this.btnLookup = new System.Windows.Forms.Button();
            this.txtQrInput = new System.Windows.Forms.TextBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.pnlResultCard = new System.Windows.Forms.Panel();
            this.btnGoToBook = new System.Windows.Forms.Button();
            this.btnBorrowScannedBook = new System.Windows.Forms.Button();
            this.lblResultAvailability = new System.Windows.Forms.Label();
            this.lblResultShelf = new System.Windows.Forms.Label();
            this.lblResultCategory = new System.Windows.Forms.Label();
            this.lblResultIsbn = new System.Windows.Forms.Label();
            this.lblResultAuthor = new System.Windows.Forms.Label();
            this.lblResultTitle = new System.Windows.Forms.Label();
            this.picBookQr = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.secScanner.SuspendLayout();
            this.pnlResultCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBookQr)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(720, 65);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(91)))));
            this.btnClose.Location = new System.Drawing.Point(625, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕ Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 38);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(329, 15);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "University OPAC Interactive Barcode & QR Code Catalog Reader";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(91)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(267, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "📷 School Library QR Scanner";
            // 
            // secScanner
            // 
            this.secScanner.BorderRadius = 12;
            this.secScanner.Controls.Add(this.lblScanHint);
            this.secScanner.Controls.Add(this.btnLookup);
            this.secScanner.Controls.Add(this.txtQrInput);
            this.secScanner.Controls.Add(this.lblPrompt);
            this.secScanner.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.secScanner.Location = new System.Drawing.Point(25, 80);
            this.secScanner.Name = "secScanner";
            this.secScanner.Padding = new System.Windows.Forms.Padding(16, 45, 16, 16);
            this.secScanner.ShowHeaderBar = true;
            this.secScanner.Size = new System.Drawing.Size(670, 140);
            this.secScanner.TabIndex = 1;
            this.secScanner.Title = "Scan Barcode / QR Code Tag";
            // 
            // lblScanHint
            // 
            this.lblScanHint.AutoSize = true;
            this.lblScanHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblScanHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblScanHint.Location = new System.Drawing.Point(20, 112);
            this.lblScanHint.Name = "lblScanHint";
            this.lblScanHint.Size = new System.Drawing.Size(430, 13);
            this.lblScanHint.TabIndex = 3;
            this.lblScanHint.Text = "💡 Tip: Optical barcode & QR scanner guns automatically trigger and load on scan.";
            // 
            // btnLookup
            // 
            this.btnLookup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLookup.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLookup.ForeColor = System.Drawing.Color.White;
            this.btnLookup.Location = new System.Drawing.Point(500, 68);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(150, 36);
            this.btnLookup.TabIndex = 2;
            this.btnLookup.Text = "🔍 Scan / Search";
            this.btnLookup.UseVisualStyleBackColor = false;
            // 
            // txtQrInput
            // 
            this.txtQrInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtQrInput.Location = new System.Drawing.Point(20, 72);
            this.txtQrInput.Name = "txtQrInput";
            this.txtQrInput.PlaceholderText = "Scan barcode with scanner gun or enter ISBN / Book Title...";
            this.txtQrInput.Size = new System.Drawing.Size(465, 27);
            this.txtQrInput.TabIndex = 1;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblPrompt.Location = new System.Drawing.Point(20, 50);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(252, 15);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "Scanner Reader Input (Ready for scanning):";
            // 
            // pnlResultCard
            // 
            this.pnlResultCard.BackColor = System.Drawing.Color.White;
            this.pnlResultCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResultCard.Controls.Add(this.btnGoToBook);
            this.pnlResultCard.Controls.Add(this.btnBorrowScannedBook);
            this.pnlResultCard.Controls.Add(this.lblResultAvailability);
            this.pnlResultCard.Controls.Add(this.lblResultShelf);
            this.pnlResultCard.Controls.Add(this.lblResultCategory);
            this.pnlResultCard.Controls.Add(this.lblResultIsbn);
            this.pnlResultCard.Controls.Add(this.lblResultAuthor);
            this.pnlResultCard.Controls.Add(this.lblResultTitle);
            this.pnlResultCard.Controls.Add(this.picBookQr);
            this.pnlResultCard.Location = new System.Drawing.Point(25, 235);
            this.pnlResultCard.Name = "pnlResultCard";
            this.pnlResultCard.Size = new System.Drawing.Size(670, 260);
            this.pnlResultCard.TabIndex = 2;
            // 
            // btnGoToBook
            // 
            this.btnGoToBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnGoToBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToBook.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGoToBook.ForeColor = System.Drawing.Color.White;
            this.btnGoToBook.Location = new System.Drawing.Point(210, 205);
            this.btnGoToBook.Name = "btnGoToBook";
            this.btnGoToBook.Size = new System.Drawing.Size(220, 36);
            this.btnGoToBook.TabIndex = 7;
            this.btnGoToBook.Text = "🔍 View in Book Catalog";
            this.btnGoToBook.UseVisualStyleBackColor = false;
            this.btnGoToBook.Visible = false;
            // 
            // btnBorrowScannedBook
            // 
            this.btnBorrowScannedBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(27)))), ((int)(((byte)(96)))));
            this.btnBorrowScannedBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowScannedBook.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBorrowScannedBook.ForeColor = System.Drawing.Color.White;
            this.btnBorrowScannedBook.Location = new System.Drawing.Point(440, 205);
            this.btnBorrowScannedBook.Name = "btnBorrowScannedBook";
            this.btnBorrowScannedBook.Size = new System.Drawing.Size(210, 36);
            this.btnBorrowScannedBook.TabIndex = 8;
            this.btnBorrowScannedBook.Text = "📖 Borrow This Book";
            this.btnBorrowScannedBook.UseVisualStyleBackColor = false;
            this.btnBorrowScannedBook.Visible = false;
            // 
            // lblResultAvailability
            // 
            this.lblResultAvailability.AutoSize = true;
            this.lblResultAvailability.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResultAvailability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblResultAvailability.Location = new System.Drawing.Point(210, 168);
            this.lblResultAvailability.Name = "lblResultAvailability";
            this.lblResultAvailability.Size = new System.Drawing.Size(0, 19);
            this.lblResultAvailability.TabIndex = 6;
            // 
            // lblResultShelf
            // 
            this.lblResultShelf.AutoSize = true;
            this.lblResultShelf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResultShelf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(24)))), ((int)(((byte)(91)))));
            this.lblResultShelf.Location = new System.Drawing.Point(210, 138);
            this.lblResultShelf.Name = "lblResultShelf";
            this.lblResultShelf.Size = new System.Drawing.Size(0, 15);
            this.lblResultShelf.TabIndex = 5;
            // 
            // lblResultCategory
            // 
            this.lblResultCategory.AutoSize = true;
            this.lblResultCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResultCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblResultCategory.Location = new System.Drawing.Point(210, 110);
            this.lblResultCategory.Name = "lblResultCategory";
            this.lblResultCategory.Size = new System.Drawing.Size(0, 15);
            this.lblResultCategory.TabIndex = 4;
            // 
            // lblResultIsbn
            // 
            this.lblResultIsbn.AutoSize = true;
            this.lblResultIsbn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResultIsbn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblResultIsbn.Location = new System.Drawing.Point(210, 80);
            this.lblResultIsbn.Name = "lblResultIsbn";
            this.lblResultIsbn.Size = new System.Drawing.Size(0, 15);
            this.lblResultIsbn.TabIndex = 3;
            // 
            // lblResultAuthor
            // 
            this.lblResultAuthor.AutoSize = true;
            this.lblResultAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResultAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblResultAuthor.Location = new System.Drawing.Point(210, 50);
            this.lblResultAuthor.Name = "lblResultAuthor";
            this.lblResultAuthor.Size = new System.Drawing.Size(0, 19);
            this.lblResultAuthor.TabIndex = 2;
            // 
            // lblResultTitle
            // 
            this.lblResultTitle.AutoSize = true;
            this.lblResultTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblResultTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblResultTitle.Location = new System.Drawing.Point(210, 20);
            this.lblResultTitle.MaximumSize = new System.Drawing.Size(430, 0);
            this.lblResultTitle.Name = "lblResultTitle";
            this.lblResultTitle.Size = new System.Drawing.Size(325, 25);
            this.lblResultTitle.TabIndex = 1;
            this.lblResultTitle.Text = "Scan a book QR code to see details...";
            // 
            // picBookQr
            // 
            this.picBookQr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.picBookQr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBookQr.Location = new System.Drawing.Point(20, 20);
            this.picBookQr.Name = "picBookQr";
            this.picBookQr.Size = new System.Drawing.Size(165, 165);
            this.picBookQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBookQr.TabIndex = 0;
            this.picBookQr.TabStop = false;
            // 
            // QrScannerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(720, 520);
            this.Controls.Add(this.pnlResultCard);
            this.Controls.Add(this.secScanner);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "QrScannerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Library - Interactive QR Code Scanner";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.secScanner.ResumeLayout(false);
            this.secScanner.PerformLayout();
            this.pnlResultCard.ResumeLayout(false);
            this.pnlResultCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBookQr)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
