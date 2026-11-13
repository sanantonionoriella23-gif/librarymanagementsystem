namespace LibraryManagementSystem
{
    partial class BorrowReturnForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;

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
            tabReturn = new TabPage();
            pnlReturnFilter = new Panel();
            lblReturnSearch = new Label();
            txtReturnSearch = new TextBox();
            dgvActiveLoans = new DataGridView();
            secReturnDetails = new SectionBox();
            lblRetTrxCode = new Label();
            txtRetTrxCode = new TextBox();
            lblRetBook = new Label();
            txtRetBook = new TextBox();
            lblRetMember = new Label();
            txtRetMember = new TextBox();
            lblRetDue = new Label();
            txtRetDue = new TextBox();
            lblRetNotes = new Label();
            txtRetNotes = new TextBox();
            btnProcessReturn = new Button();
            tabIssue = new TabPage();
            secIssue = new SectionBox();
            lblIssueMember = new Label();
            txtIssueMemberCode = new TextBox();
            btnFindMember = new Button();
            lblMemberInfo = new Label();
            lblIssueBook = new Label();
            txtIssueIsbn = new TextBox();
            btnFindBook = new Button();
            lblBookInfo = new Label();
            lblDays = new Label();
            numDays = new NumericUpDown();
            lblDueDatePreview = new Label();
            lblIssueNotes = new Label();
            txtIssueNotes = new TextBox();
            btnIssueConfirm = new Button();
            tabCirculation = new TabControl();
            pnlTop.SuspendLayout();
            tabReturn.SuspendLayout();
            pnlReturnFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActiveLoans).BeginInit();
            secReturnDetails.SuspendLayout();
            tabIssue.SuspendLayout();
            secIssue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDays).BeginInit();
            tabCirculation.SuspendLayout();
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
            btnClose.Text = "Back";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 224, 192);
            lblTitle.Location = new Point(454, 35);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(541, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Circulation Desk: Borrow && Return";
            // 
            // tabReturn
            // 
            tabReturn.BackColor = Color.FromArgb(255, 247, 250);
            tabReturn.BackgroundImage = Properties.Resources.lib;
            tabReturn.Controls.Add(secReturnDetails);
            tabReturn.Controls.Add(dgvActiveLoans);
            tabReturn.Controls.Add(pnlReturnFilter);
            tabReturn.Location = new Point(4, 37);
            tabReturn.Margin = new Padding(4, 5, 4, 5);
            tabReturn.Name = "tabReturn";
            tabReturn.Padding = new Padding(23, 27, 23, 27);
            tabReturn.Size = new Size(1706, 1029);
            tabReturn.TabIndex = 1;
            tabReturn.Text = "  Return Book  ";
            // 
            // pnlReturnFilter
            // 
            pnlReturnFilter.BackColor = Color.PapayaWhip;
            pnlReturnFilter.Controls.Add(txtReturnSearch);
            pnlReturnFilter.Controls.Add(lblReturnSearch);
            pnlReturnFilter.Dock = DockStyle.Top;
            pnlReturnFilter.Location = new Point(23, 27);
            pnlReturnFilter.Margin = new Padding(4, 5, 4, 5);
            pnlReturnFilter.Name = "pnlReturnFilter";
            pnlReturnFilter.Size = new Size(1660, 73);
            pnlReturnFilter.TabIndex = 0;
            // 
            // lblReturnSearch
            // 
            lblReturnSearch.AutoSize = true;
            lblReturnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReturnSearch.ForeColor = Color.FromArgb(43, 45, 66);
            lblReturnSearch.Location = new Point(21, 23);
            lblReturnSearch.Margin = new Padding(4, 0, 4, 0);
            lblReturnSearch.Name = "lblReturnSearch";
            lblReturnSearch.Size = new Size(192, 25);
            lblReturnSearch.TabIndex = 0;
            lblReturnSearch.Text = "\u008d Search Active Loans:";
            // 
            // txtReturnSearch
            // 
            txtReturnSearch.Font = new Font("Segoe UI", 9.5F);
            txtReturnSearch.Location = new Point(236, 17);
            txtReturnSearch.Margin = new Padding(4, 5, 4, 5);
            txtReturnSearch.Name = "txtReturnSearch";
            txtReturnSearch.PlaceholderText = "Search by Transaction Code, Member, or Title...";
            txtReturnSearch.Size = new Size(598, 33);
            txtReturnSearch.TabIndex = 1;
            // 
            // dgvActiveLoans
            // 
            dgvActiveLoans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvActiveLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveLoans.GridColor = Color.PapayaWhip;
            dgvActiveLoans.Location = new Point(23, 113);
            dgvActiveLoans.Margin = new Padding(4, 5, 4, 5);
            dgvActiveLoans.Name = "dgvActiveLoans";
            dgvActiveLoans.RowHeadersWidth = 62;
            dgvActiveLoans.Size = new Size(1036, 880);
            dgvActiveLoans.TabIndex = 1;
            // 
            // secReturnDetails
            // 
            secReturnDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            secReturnDetails.BackColor = Color.White;
            secReturnDetails.BorderRadius = 12;
            secReturnDetails.Controls.Add(btnProcessReturn);
            secReturnDetails.Controls.Add(txtRetNotes);
            secReturnDetails.Controls.Add(lblRetNotes);
            secReturnDetails.Controls.Add(txtRetDue);
            secReturnDetails.Controls.Add(lblRetDue);
            secReturnDetails.Controls.Add(txtRetMember);
            secReturnDetails.Controls.Add(lblRetMember);
            secReturnDetails.Controls.Add(txtRetBook);
            secReturnDetails.Controls.Add(lblRetBook);
            secReturnDetails.Controls.Add(txtRetTrxCode);
            secReturnDetails.Controls.Add(lblRetTrxCode);
            secReturnDetails.HeaderColor = Color.FromArgb(233, 30, 99);
            secReturnDetails.Location = new Point(1086, 113);
            secReturnDetails.Margin = new Padding(4, 5, 4, 5);
            secReturnDetails.Name = "secReturnDetails";
            secReturnDetails.Padding = new Padding(23, 75, 23, 27);
            secReturnDetails.ShowHeaderBar = true;
            secReturnDetails.Size = new Size(594, 880);
            secReturnDetails.TabIndex = 2;
            secReturnDetails.Title = "Process Book Return";
            // 
            // lblRetTrxCode
            // 
            lblRetTrxCode.AutoSize = true;
            lblRetTrxCode.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblRetTrxCode.ForeColor = Color.FromArgb(43, 45, 66);
            lblRetTrxCode.Location = new Point(29, 145);
            lblRetTrxCode.Margin = new Padding(4, 0, 4, 0);
            lblRetTrxCode.Name = "lblRetTrxCode";
            lblRetTrxCode.Size = new Size(152, 23);
            lblRetTrxCode.TabIndex = 0;
            lblRetTrxCode.Text = "Transaction Code:";
            // 
            // txtRetTrxCode
            // 
            txtRetTrxCode.Font = new Font("Segoe UI", 9F);
            txtRetTrxCode.Location = new Point(29, 175);
            txtRetTrxCode.Margin = new Padding(4, 5, 4, 5);
            txtRetTrxCode.Name = "txtRetTrxCode";
            txtRetTrxCode.ReadOnly = true;
            txtRetTrxCode.Size = new Size(535, 31);
            txtRetTrxCode.TabIndex = 1;
            // 
            // lblRetBook
            // 
            lblRetBook.AutoSize = true;
            lblRetBook.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblRetBook.ForeColor = Color.FromArgb(43, 45, 66);
            lblRetBook.Location = new Point(29, 245);
            lblRetBook.Margin = new Padding(4, 0, 4, 0);
            lblRetBook.Name = "lblRetBook";
            lblRetBook.Size = new Size(97, 23);
            lblRetBook.TabIndex = 2;
            lblRetBook.Text = "Book Title:";
            // 
            // txtRetBook
            // 
            txtRetBook.Font = new Font("Segoe UI", 9F);
            txtRetBook.Location = new Point(29, 275);
            txtRetBook.Margin = new Padding(4, 5, 4, 5);
            txtRetBook.Name = "txtRetBook";
            txtRetBook.ReadOnly = true;
            txtRetBook.Size = new Size(535, 31);
            txtRetBook.TabIndex = 3;
            // 
            // lblRetMember
            // 
            lblRetMember.AutoSize = true;
            lblRetMember.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblRetMember.ForeColor = Color.FromArgb(43, 45, 66);
            lblRetMember.Location = new Point(29, 345);
            lblRetMember.Margin = new Padding(4, 0, 4, 0);
            lblRetMember.Name = "lblRetMember";
            lblRetMember.Size = new Size(84, 23);
            lblRetMember.TabIndex = 4;
            lblRetMember.Text = "Member:";
            // 
            // txtRetMember
            // 
            txtRetMember.Font = new Font("Segoe UI", 9F);
            txtRetMember.Location = new Point(29, 375);
            txtRetMember.Margin = new Padding(4, 5, 4, 5);
            txtRetMember.Name = "txtRetMember";
            txtRetMember.ReadOnly = true;
            txtRetMember.Size = new Size(535, 31);
            txtRetMember.TabIndex = 5;
            // 
            // lblRetDue
            // 
            lblRetDue.AutoSize = true;
            lblRetDue.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblRetDue.ForeColor = Color.FromArgb(43, 45, 66);
            lblRetDue.Location = new Point(29, 445);
            lblRetDue.Margin = new Padding(4, 0, 4, 0);
            lblRetDue.Name = "lblRetDue";
            lblRetDue.Size = new Size(90, 23);
            lblRetDue.TabIndex = 6;
            lblRetDue.Text = "Due Date:";
            // 
            // txtRetDue
            // 
            txtRetDue.Font = new Font("Segoe UI", 9F);
            txtRetDue.Location = new Point(29, 475);
            txtRetDue.Margin = new Padding(4, 5, 4, 5);
            txtRetDue.Name = "txtRetDue";
            txtRetDue.ReadOnly = true;
            txtRetDue.Size = new Size(535, 31);
            txtRetDue.TabIndex = 7;
            // 
            // lblRetNotes
            // 
            lblRetNotes.AutoSize = true;
            lblRetNotes.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblRetNotes.ForeColor = Color.FromArgb(43, 45, 66);
            lblRetNotes.Location = new Point(29, 550);
            lblRetNotes.Margin = new Padding(4, 0, 4, 0);
            lblRetNotes.Name = "lblRetNotes";
            lblRetNotes.Size = new Size(120, 23);
            lblRetNotes.TabIndex = 12;
            lblRetNotes.Text = "Return Notes:";
            // 
            // txtRetNotes
            // 
            txtRetNotes.Font = new Font("Segoe UI", 9F);
            txtRetNotes.Location = new Point(29, 583);
            txtRetNotes.Margin = new Padding(4, 5, 4, 5);
            txtRetNotes.Multiline = true;
            txtRetNotes.Name = "txtRetNotes";
            txtRetNotes.Size = new Size(535, 139);
            txtRetNotes.TabIndex = 13;
            // 
            // btnProcessReturn
            // 
            btnProcessReturn.BackColor = Color.FromArgb(233, 30, 99);
            btnProcessReturn.FlatStyle = FlatStyle.Flat;
            btnProcessReturn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcessReturn.ForeColor = Color.White;
            btnProcessReturn.Location = new Point(29, 767);
            btnProcessReturn.Margin = new Padding(4, 5, 4, 5);
            btnProcessReturn.Name = "btnProcessReturn";
            btnProcessReturn.Size = new Size(537, 70);
            btnProcessReturn.TabIndex = 14;
            btnProcessReturn.Text = "Complete Return && Update Inventory";
            btnProcessReturn.UseVisualStyleBackColor = false;
            // 
            // tabIssue
            // 
            tabIssue.BackColor = Color.FromArgb(255, 247, 250);
            tabIssue.BackgroundImage = Properties.Resources.lib;
            tabIssue.Controls.Add(secIssue);
            tabIssue.Location = new Point(4, 37);
            tabIssue.Margin = new Padding(4, 5, 4, 5);
            tabIssue.Name = "tabIssue";
            tabIssue.Padding = new Padding(29, 33, 29, 33);
            tabIssue.Size = new Size(1706, 1029);
            tabIssue.TabIndex = 0;
            tabIssue.Text = "  Issue Book ";
            // 
            // secIssue
            // 
            secIssue.BackColor = Color.Transparent;
            secIssue.BorderRadius = 12;
            secIssue.Controls.Add(btnIssueConfirm);
            secIssue.Controls.Add(txtIssueNotes);
            secIssue.Controls.Add(lblIssueNotes);
            secIssue.Controls.Add(lblDueDatePreview);
            secIssue.Controls.Add(numDays);
            secIssue.Controls.Add(lblDays);
            secIssue.Controls.Add(lblBookInfo);
            secIssue.Controls.Add(btnFindBook);
            secIssue.Controls.Add(txtIssueIsbn);
            secIssue.Controls.Add(lblIssueBook);
            secIssue.Controls.Add(lblMemberInfo);
            secIssue.Controls.Add(btnFindMember);
            secIssue.Controls.Add(txtIssueMemberCode);
            secIssue.Controls.Add(lblIssueMember);
            secIssue.HeaderColor = Color.FromArgb(233, 30, 99);
            secIssue.Location = new Point(329, 33);
            secIssue.Margin = new Padding(4, 5, 4, 5);
            secIssue.Name = "secIssue";
            secIssue.Padding = new Padding(34, 83, 34, 40);
            secIssue.ShowHeaderBar = true;
            secIssue.Size = new Size(1043, 933);
            secIssue.TabIndex = 0;
            secIssue.Title = "Issue Book to Registered Member";
            // 
            // lblIssueMember
            // 
            lblIssueMember.AutoSize = true;
            lblIssueMember.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIssueMember.ForeColor = Color.FromArgb(43, 45, 66);
            lblIssueMember.Location = new Point(43, 80);
            lblIssueMember.Margin = new Padding(4, 0, 4, 0);
            lblIssueMember.Name = "lblIssueMember";
            lblIssueMember.Size = new Size(235, 25);
            lblIssueMember.TabIndex = 0;
            lblIssueMember.Text = "Member Code or QR Scan:";
            // 
            // txtIssueMemberCode
            // 
            txtIssueMemberCode.Font = new Font("Segoe UI", 10F);
            txtIssueMemberCode.Location = new Point(43, 117);
            txtIssueMemberCode.Margin = new Padding(4, 5, 4, 5);
            txtIssueMemberCode.Name = "txtIssueMemberCode";
            txtIssueMemberCode.PlaceholderText = "Enter or scan Member Code";
            txtIssueMemberCode.Size = new Size(698, 34);
            txtIssueMemberCode.TabIndex = 1;
            // 
            // btnFindMember
            // 
            btnFindMember.BackColor = Color.FromArgb(252, 228, 236);
            btnFindMember.FlatStyle = FlatStyle.Flat;
            btnFindMember.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFindMember.ForeColor = Color.FromArgb(194, 24, 91);
            btnFindMember.Location = new Point(771, 113);
            btnFindMember.Margin = new Padding(4, 5, 4, 5);
            btnFindMember.Name = "btnFindMember";
            btnFindMember.Size = new Size(229, 47);
            btnFindMember.TabIndex = 2;
            btnFindMember.Text = "Verify Member";
            btnFindMember.UseVisualStyleBackColor = false;
            // 
            // lblMemberInfo
            // 
            lblMemberInfo.BackColor = Color.FromArgb(255, 247, 250);
            lblMemberInfo.BorderStyle = BorderStyle.FixedSingle;
            lblMemberInfo.Font = new Font("Segoe UI", 9.5F);
            lblMemberInfo.ForeColor = Color.FromArgb(108, 117, 125);
            lblMemberInfo.Location = new Point(43, 175);
            lblMemberInfo.Margin = new Padding(4, 0, 4, 0);
            lblMemberInfo.Name = "lblMemberInfo";
            lblMemberInfo.Padding = new Padding(14, 17, 14, 17);
            lblMemberInfo.Size = new Size(956, 90);
            lblMemberInfo.TabIndex = 3;
            lblMemberInfo.Text = "No member selected. Enter Member Code and click Verify.";
            // 
            // lblIssueBook
            // 
            lblIssueBook.AutoSize = true;
            lblIssueBook.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIssueBook.ForeColor = Color.FromArgb(43, 45, 66);
            lblIssueBook.Location = new Point(43, 300);
            lblIssueBook.Margin = new Padding(4, 0, 4, 0);
            lblIssueBook.Name = "lblIssueBook";
            lblIssueBook.Size = new Size(206, 25);
            lblIssueBook.TabIndex = 4;
            lblIssueBook.Text = "Book ISBN or Barcode:";
            // 
            // txtIssueIsbn
            // 
            txtIssueIsbn.Font = new Font("Segoe UI", 10F);
            txtIssueIsbn.Location = new Point(43, 337);
            txtIssueIsbn.Margin = new Padding(4, 5, 4, 5);
            txtIssueIsbn.Name = "txtIssueIsbn";
            txtIssueIsbn.PlaceholderText = "Enter or scan Book ISBN ";
            txtIssueIsbn.Size = new Size(698, 34);
            txtIssueIsbn.TabIndex = 5;
            // 
            // btnFindBook
            // 
            btnFindBook.BackColor = Color.FromArgb(252, 228, 236);
            btnFindBook.FlatStyle = FlatStyle.Flat;
            btnFindBook.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFindBook.ForeColor = Color.FromArgb(194, 24, 91);
            btnFindBook.Location = new Point(771, 333);
            btnFindBook.Margin = new Padding(4, 5, 4, 5);
            btnFindBook.Name = "btnFindBook";
            btnFindBook.Size = new Size(229, 47);
            btnFindBook.TabIndex = 6;
            btnFindBook.Text = "Verify Book";
            btnFindBook.UseVisualStyleBackColor = false;
            // 
            // lblBookInfo
            // 
            lblBookInfo.BackColor = Color.FromArgb(255, 247, 250);
            lblBookInfo.BorderStyle = BorderStyle.FixedSingle;
            lblBookInfo.Font = new Font("Segoe UI", 9.5F);
            lblBookInfo.ForeColor = Color.FromArgb(108, 117, 125);
            lblBookInfo.Location = new Point(43, 400);
            lblBookInfo.Margin = new Padding(4, 0, 4, 0);
            lblBookInfo.Name = "lblBookInfo";
            lblBookInfo.Padding = new Padding(14, 17, 14, 17);
            lblBookInfo.Size = new Size(956, 90);
            lblBookInfo.TabIndex = 7;
            lblBookInfo.Text = "No book selected. Enter ISBN and click Verify.";
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDays.ForeColor = Color.FromArgb(43, 45, 66);
            lblDays.Location = new Point(43, 525);
            lblDays.Margin = new Padding(4, 0, 4, 0);
            lblDays.Name = "lblDays";
            lblDays.Size = new Size(177, 25);
            lblDays.TabIndex = 8;
            lblDays.Text = "Loan Period (Days):";
            // 
            // numDays
            // 
            numDays.Font = new Font("Segoe UI", 10F);
            numDays.Location = new Point(43, 560);
            numDays.Margin = new Padding(4, 5, 4, 5);
            numDays.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            numDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDays.Name = "numDays";
            numDays.Size = new Size(229, 34);
            numDays.TabIndex = 9;
            numDays.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // lblDueDatePreview
            // 
            lblDueDatePreview.AutoSize = true;
            lblDueDatePreview.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDueDatePreview.ForeColor = Color.FromArgb(46, 125, 50);
            lblDueDatePreview.Location = new Point(314, 567);
            lblDueDatePreview.Margin = new Padding(4, 0, 4, 0);
            lblDueDatePreview.Name = "lblDueDatePreview";
            lblDueDatePreview.Size = new Size(176, 25);
            lblDueDatePreview.TabIndex = 10;
            lblDueDatePreview.Text = "Due: Nov 22, 2026";
            // 
            // lblIssueNotes
            // 
            lblIssueNotes.AutoSize = true;
            lblIssueNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIssueNotes.ForeColor = Color.FromArgb(43, 45, 66);
            lblIssueNotes.Location = new Point(43, 633);
            lblIssueNotes.Margin = new Padding(4, 0, 4, 0);
            lblIssueNotes.Name = "lblIssueNotes";
            lblIssueNotes.Size = new Size(67, 25);
            lblIssueNotes.TabIndex = 11;
            lblIssueNotes.Text = "Notes:";
            // 
            // txtIssueNotes
            // 
            txtIssueNotes.Font = new Font("Segoe UI", 9.5F);
            txtIssueNotes.Location = new Point(43, 667);
            txtIssueNotes.Margin = new Padding(4, 5, 4, 5);
            txtIssueNotes.Multiline = true;
            txtIssueNotes.Name = "txtIssueNotes";
            txtIssueNotes.PlaceholderText = "Optional loan notes or conditions...";
            txtIssueNotes.Size = new Size(955, 89);
            txtIssueNotes.TabIndex = 12;
            // 
            // btnIssueConfirm
            // 
            btnIssueConfirm.BackColor = Color.FromArgb(233, 30, 99);
            btnIssueConfirm.FlatStyle = FlatStyle.Flat;
            btnIssueConfirm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIssueConfirm.ForeColor = Color.White;
            btnIssueConfirm.Location = new Point(43, 800);
            btnIssueConfirm.Margin = new Padding(4, 5, 4, 5);
            btnIssueConfirm.Name = "btnIssueConfirm";
            btnIssueConfirm.Size = new Size(957, 73);
            btnIssueConfirm.TabIndex = 13;
            btnIssueConfirm.Text = "Confirm Loan && Issue Book";
            btnIssueConfirm.UseVisualStyleBackColor = false;
            // 
            // tabCirculation
            // 
            tabCirculation.Controls.Add(tabIssue);
            tabCirculation.Controls.Add(tabReturn);
            tabCirculation.Dock = DockStyle.Fill;
            tabCirculation.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabCirculation.Location = new Point(0, 100);
            tabCirculation.Margin = new Padding(4, 5, 4, 5);
            tabCirculation.Name = "tabCirculation";
            tabCirculation.SelectedIndex = 0;
            tabCirculation.Size = new Size(1714, 1070);
            tabCirculation.TabIndex = 1;
            // 
            // BorrowReturnForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 247, 250);
            ClientSize = new Size(1714, 1170);
            Controls.Add(tabCirculation);
            Controls.Add(pnlTop);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1419, 963);
            Name = "BorrowReturnForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management System - Circulation Desk";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            tabReturn.ResumeLayout(false);
            pnlReturnFilter.ResumeLayout(false);
            pnlReturnFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActiveLoans).EndInit();
            secReturnDetails.ResumeLayout(false);
            secReturnDetails.PerformLayout();
            tabIssue.ResumeLayout(false);
            secIssue.ResumeLayout(false);
            secIssue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDays).EndInit();
            tabCirculation.ResumeLayout(false);
            ResumeLayout(false);
        }
        private TabPage tabReturn;
        private SectionBox secReturnDetails;
        private Button btnProcessReturn;
        private TextBox txtRetNotes;
        private Label lblRetNotes;
        private TextBox txtRetDue;
        private Label lblRetDue;
        private TextBox txtRetMember;
        private Label lblRetMember;
        private TextBox txtRetBook;
        private Label lblRetBook;
        private TextBox txtRetTrxCode;
        private Label lblRetTrxCode;
        private DataGridView dgvActiveLoans;
        private Panel pnlReturnFilter;
        private TextBox txtReturnSearch;
        private Label lblReturnSearch;
        private TabPage tabIssue;
        private SectionBox secIssue;
        private Button btnIssueConfirm;
        private TextBox txtIssueNotes;
        private Label lblIssueNotes;
        private Label lblDueDatePreview;
        private NumericUpDown numDays;
        private Label lblDays;
        private Label lblBookInfo;
        private Button btnFindBook;
        private TextBox txtIssueIsbn;
        private Label lblIssueBook;
        private Label lblMemberInfo;
        private Button btnFindMember;
        private TextBox txtIssueMemberCode;
        private Label lblIssueMember;
        private TabControl tabCirculation;
    }
}

