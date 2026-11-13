using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class MembersForm : Form
    {
        private int _selectedMemberId = 0;

        public MembersForm()
        {
            InitializeComponent();
            ApplyCustomStyling();
            WireEvents();

            Load += (s, e) =>
            {
                cmbMemberType.SelectedIndex = 0;
                cmbStatus.SelectedIndex = 0;
                LoadMembers();
                ApplyRolePermissions();
            };
        }

        private void ApplyCustomStyling()
        {
            Theme.StyleDataGridView(dgvMembers);
            Theme.StylePrimaryButton(btnAdd);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleSecondaryButton(btnClear);
            Theme.StyleSecondaryButton(btnSaveBadge);
            Theme.StyleSecondaryButton(btnGenerateCode);

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
            bool canManage = Access.CanManageMembers(role);
            bool canDelete = Access.CanManageUsers(role); // Delete member reserved for admin

            btnAdd.Visible = canManage;
            btnUpdate.Visible = canManage;
            btnClear.Visible = canManage;
            btnDelete.Visible = canDelete;
        }

        private void LoadMembers()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                var members = Database.GetMembers(search);
                dgvMembers.DataSource = null;
                dgvMembers.DataSource = members;

                foreach (DataGridViewColumn col in dgvMembers.Columns)
                {
                    string prop = col.DataPropertyName ?? col.Name ?? "";
                    if (string.Equals(prop, "Id", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(prop, "RegisteredAt", StringComparison.OrdinalIgnoreCase))
                    {
                        col.Visible = false;
                    }
                    else if (string.Equals(prop, "MemberCode", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Member Code";
                        col.Width = 110;
                    }
                    else if (string.Equals(prop, "FullName", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Full Name";
                        col.Width = 180;
                    }
                    else if (string.Equals(prop, "Email", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Email";
                        col.Width = 170;
                    }
                    else if (string.Equals(prop, "Phone", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Phone";
                        col.Width = 110;
                    }
                    else if (string.Equals(prop, "MemberType", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Type";
                        col.Width = 90;
                    }
                    else if (string.Equals(prop, "Status", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Status";
                        col.Width = 80;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in LoadMembers: " + ex.Message);
            }
        }

        private void WireEvents()
        {
            btnClose.Click += (s, e) => Close();
            txtSearch.TextChanged += (s, e) => LoadMembers();

            dgvMembers.SelectionChanged += (s, e) =>
            {
                if (dgvMembers.CurrentRow != null && dgvMembers.CurrentRow.DataBoundItem is Member member)
                {
                    PopulateFields(member);
                }
            };

            btnAdd.Click += (s, e) => PerformAddMember();
            btnUpdate.Click += (s, e) => PerformUpdateMember();
            btnDelete.Click += (s, e) => PerformDeleteMember();
            btnClear.Click += (s, e) => ClearFields();

            btnGenerateCode.Click += (s, e) =>
            {
                txtMemberCode.Text = $"LIB-M{DateTime.Now:MMddHHmm}";
                RefreshQrBadge();
            };

            txtMemberCode.TextChanged += (s, e) => RefreshQrBadge();
            btnSaveBadge.Click += (s, e) => SaveBadgeImage();
        }

        private void PopulateFields(Member member)
        {
            _selectedMemberId = member.Id;
            txtMemberCode.Text = member.MemberCode;
            txtFullName.Text = member.FullName;
            txtEmail.Text = member.Email;
            txtPhone.Text = member.Phone;
            txtAddress.Text = member.Address;

            if (cmbMemberType.Items.Contains(member.MemberType)) cmbMemberType.SelectedItem = member.MemberType;
            if (cmbStatus.Items.Contains(member.Status)) cmbStatus.SelectedItem = member.Status;

            RefreshQrBadge();
        }

        private void RefreshQrBadge()
        {
            string code = txtMemberCode.Text.Trim();
            if (!string.IsNullOrEmpty(code))
            {
                picMemberQr.Image?.Dispose();
                picMemberQr.Image = QrCodes.GenerateQrCode($"MEMBER:{code}");
            }
            else
            {
                picMemberQr.Image?.Dispose();
                picMemberQr.Image = null;
            }
        }

        private void SaveBadgeImage()
        {
            if (string.IsNullOrWhiteSpace(txtMemberCode.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please select or enter member information to generate a library card.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Generate an official University Student / Faculty Library Card (PVC Aspect Ratio)
            int width = 520;
            int height = 310;
            Bitmap card = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(card))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Border
                using (Pen borderPen = new Pen(Theme.PrimaryDark, 2.5f))
                {
                    g.DrawRectangle(borderPen, 5, 5, width - 10, height - 10);
                }

                // Header Banner (University Crimson-Rose)
                using (SolidBrush headerBrush = new SolidBrush(Theme.PrimaryDark))
                {
                    g.FillRectangle(headerBrush, 6, 6, width - 12, 54);
                }

                // University Name
                using (Font univFont = new Font("Segoe UI", 12F, FontStyle.Bold))
                using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                {
                    g.DrawString("ATHENA STATE UNIVERSITY", univFont, whiteBrush, new PointF(18, 12));
                }

                using (Font subFont = new Font("Segoe UI", 7.5F))
                using (SolidBrush lightPinkBrush = new SolidBrush(Theme.PrimaryLight))
                {
                    g.DrawString("OFFICIAL STUDENT & FACULTY LIBRARY ACCESS CARD • A.Y. 2026-2027", subFont, lightPinkBrush, new PointF(18, 34));
                }

                // Student Avatar Photo Box
                Rectangle photoRect = new Rectangle(20, 75, 95, 115);
                using (SolidBrush photoBg = new SolidBrush(Color.FromArgb(254, 250, 252)))
                using (Pen photoBorder = new Pen(Theme.BorderSubtle, 1.5f))
                {
                    g.FillRectangle(photoBg, photoRect);
                    g.DrawRectangle(photoBorder, photoRect);
                }

                // Draw Avatar Icon inside Photo Box
                using (Bitmap avatarIco = Icons.CreateIcon("members", 48, Theme.PrimaryDark))
                {
                    g.DrawImage(avatarIco, 44, 100);
                }

                using (Font photoLblFont = new Font("Segoe UI", 7F, FontStyle.Bold))
                using (SolidBrush darkMuted = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString("PHOTO ID", photoLblFont, darkMuted, new PointF(42, 160));
                }

                // Member Name
                using (Font nameFont = new Font("Segoe UI", 12F, FontStyle.Bold))
                using (SolidBrush darkBrush = new SolidBrush(Theme.TextPrimary))
                {
                    g.DrawString(txtFullName.Text, nameFont, darkBrush, new PointF(130, 75));
                }

                // Member Type & Academic Dept
                using (Font deptFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                using (SolidBrush pinkTxt = new SolidBrush(Theme.PrimaryDark))
                {
                    string mType = cmbMemberType.SelectedItem?.ToString() ?? "Student";
                    g.DrawString($"CLASSIFICATION: {mType.ToUpperInvariant()} (ACTIVE PATRON)", deptFont, pinkTxt, new PointF(130, 102));
                }

                // Student ID Code
                using (Font idFont = new Font("Segoe UI", 10F, FontStyle.Bold))
                using (SolidBrush idBrush = new SolidBrush(Theme.TextPrimary))
                {
                    g.DrawString($"PATRON ID: {txtMemberCode.Text.Trim()}", idFont, idBrush, new PointF(130, 126));
                }

                // Email & Phone
                using (Font contactFont = new Font("Segoe UI", 8F))
                using (SolidBrush contactBrush = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString($"Email: {txtEmail.Text.Trim()}", contactFont, contactBrush, new PointF(130, 150));
                    g.DrawString($"Phone: {txtPhone.Text.Trim()}", contactFont, contactBrush, new PointF(130, 168));
                }

                // Member QR Code at right side
                Bitmap qr = QrCodes.GenerateQrCode($"MEMBER:{txtMemberCode.Text.Trim()}", 3);
                g.DrawImage(qr, width - 135, 75, 115, 115);

                using (Font qrLblFont = new Font("Segoe UI", 7F, FontStyle.Bold))
                using (SolidBrush qrLblBrush = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString("SCAN AT DESK", qrLblFont, qrLblBrush, new PointF(width - 120, 195));
                }

                // Magnetic / Barcode Footer Stripe
                using (SolidBrush stripBrush = new SolidBrush(Color.FromArgb(245, 230, 235)))
                {
                    g.FillRectangle(stripBrush, 6, 225, width - 12, 75);
                }

                using (Pen dividerPen = new Pen(Theme.BorderSubtle, 1))
                {
                    g.DrawLine(dividerPen, 6, 225, width - 6, 225);
                }

                // Security disclaimer
                using (Font footerFont = new Font("Segoe UI", 7F))
                using (SolidBrush footerBrush = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString("This card is non-transferable and must be presented when borrowing academic volumes.", footerFont, footerBrush, new PointF(18, 235));
                    g.DrawString("If found, please return to the Office of the University Librarian.", footerFont, footerBrush, new PointF(18, 252));
                }

                // Authorized Signature Line
                using (Pen sigPen = new Pen(Theme.TextSecondary, 1))
                {
                    g.DrawLine(sigPen, width - 160, 275, width - 20, 275);
                }

                using (Font sigFont = new Font("Segoe UI", 6.5F, FontStyle.Bold))
                using (SolidBrush sigBrush = new SolidBrush(Theme.TextSecondary))
                {
                    g.DrawString("CHIEF LIBRARIAN SIGNATURE", sigFont, sigBrush, new PointF(width - 155, 278));
                }
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image (*.png)|*.png";
                sfd.FileName = $"STUDENT_LIBRARY_CARD_{txtMemberCode.Text.Trim()}.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    card.Save(sfd.FileName, ImageFormat.Png);
                    MessageBox.Show("Official University Student Library Card generated and saved to:\n" + sfd.FileName, "Library Card Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ClearFields()
        {
            _selectedMemberId = 0;
            txtMemberCode.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            cmbMemberType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            picMemberQr.Image?.Dispose();
            picMemberQr.Image = null;
        }

        private void PerformAddMember()
        {
            if (!ValidateInputs()) return;

            var existing = Database.GetMemberByCode(txtMemberCode.Text.Trim());
            if (existing != null)
            {
                MessageBox.Show("A member with this code already exists in student records.", "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var member = new Member
            {
                MemberCode = txtMemberCode.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                MemberType = cmbMemberType.SelectedItem?.ToString() ?? "Student",
                Status = cmbStatus.SelectedItem?.ToString() ?? "Active"
            };

            if (Database.AddMember(member))
            {
                MessageBox.Show("Student/Faculty member registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to register member.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformUpdateMember()
        {
            if (_selectedMemberId <= 0)
            {
                MessageBox.Show("Please select a member to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInputs()) return;

            var member = new Member
            {
                Id = _selectedMemberId,
                MemberCode = txtMemberCode.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                MemberType = cmbMemberType.SelectedItem?.ToString() ?? "Student",
                Status = cmbStatus.SelectedItem?.ToString() ?? "Active"
            };

            if (Database.UpdateMember(member))
            {
                MessageBox.Show("Member details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
            }
            else
            {
                MessageBox.Show("Failed to update member.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformDeleteMember()
        {
            if (_selectedMemberId <= 0)
            {
                MessageBox.Show("Please select a member to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to remove member '{txtFullName.Text}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Database.DeleteMember(_selectedMemberId))
                {
                    MessageBox.Show("Member deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMembers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to delete member.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMemberCode.Text))
            {
                MessageBox.Show("Member code cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberCode.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Member full name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }
            return true;
        }
    }
}
