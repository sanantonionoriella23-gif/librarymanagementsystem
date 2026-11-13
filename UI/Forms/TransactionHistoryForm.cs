using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class TransactionHistoryForm : Form
    {
        public TransactionHistoryForm()
        {
            InitializeComponent();
            ApplyCustomStyling();
            WireEvents();

            Load += (s, e) =>
            {
                cmbStatusFilter.SelectedIndex = 0;
                dtpFrom.Value = DateTime.Now.AddMonths(-1);
                dtpTo.Value = DateTime.Now;
                LoadHistory();
            };
        }

        private void ApplyCustomStyling()
        {
            Theme.StyleDataGridView(dgvHistory);
            Theme.StylePrimaryButton(btnExport);
            Theme.StyleSecondaryButton(btnFilter);

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

            pnlSummary.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.BorderSubtle))
                {
                    e.Graphics.DrawLine(p, 0, 0, pnlSummary.Width, 0);
                }
            };
        }

        private void WireEvents()
        {
            btnClose.Click += (s, e) => Close();
            chkEnableDateFilter.CheckedChanged += (s, e) =>
            {
                dtpFrom.Enabled = chkEnableDateFilter.Checked;
                dtpTo.Enabled = chkEnableDateFilter.Checked;
            };

            btnFilter.Click += (s, e) => LoadHistory();
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadHistory(); };
            cmbStatusFilter.SelectedIndexChanged += (s, e) => LoadHistory();
            btnExport.Click += (s, e) => ReportExporter.ExportToCsv(dgvHistory, $"Circulation_Report_{DateTime.Now:yyyyMMdd_HHmm}.csv");
        }

        private void LoadHistory()
        {
            try
            {
                Database.UpdateOverdueStatuses();

                string search = txtSearch.Text.Trim();
                string status = cmbStatusFilter.SelectedItem?.ToString() ?? "All Statuses";
                DateTime? from = chkEnableDateFilter.Checked ? dtpFrom.Value.Date : null;
                DateTime? to = chkEnableDateFilter.Checked ? dtpTo.Value.Date : null;

                int? memberId = null;
                if (Session.IsUser)
                {
                    var member = Database.GetMemberByEmail(Session.CurrentUser?.Email ?? "")
                                 ?? Database.GetMemberByCode("LIB-M1001");
                    memberId = member?.Id;
                }

                var list = Database.GetTransactions(search, status, from, to, memberId);
                dgvHistory.DataSource = null;
                dgvHistory.DataSource = list;

                foreach (DataGridViewColumn col in dgvHistory.Columns)
                {
                    string prop = col.DataPropertyName ?? col.Name ?? "";
                    if (string.Equals(prop, "Id", StringComparison.OrdinalIgnoreCase))
                        col.Visible = false;
                    else if (string.Equals(prop, "TransactionCode", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "Code";
                    else if (string.Equals(prop, "BookTitle", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "Book Title";
                    else if (string.Equals(prop, "ISBN", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "ISBN";
                    else if (string.Equals(prop, "MemberName", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "Member";
                    else if (string.Equals(prop, "MemberCode", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "Member ID";
                    else if (string.Equals(prop, "IssueDate", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "Issued Date";
                    else if (string.Equals(prop, "DueDate", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "Due Date";
                    else if (string.Equals(prop, "ReturnDate", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "Returned Date";
                    else if (string.Equals(prop, "Status", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "Status";
                    else if (string.Equals(prop, "IssuerName", StringComparison.OrdinalIgnoreCase))
                        col.HeaderText = "Processed By";
                }

                // Update summary footer
                int total = list.Count;
                int active = list.Count(t => t.Status == "Borrowed");
                int overdue = list.Count(t => t.Status == "Overdue");
                int returned = list.Count(t => t.Status == "Returned");

                lblSummaryInfo.Text = $"Total Transactions: {total:N0}   |   Active Loans: {active:N0}   |   Overdue: {overdue:N0}   |   Returned: {returned:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transaction history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

