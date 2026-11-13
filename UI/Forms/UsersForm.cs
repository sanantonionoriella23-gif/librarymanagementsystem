
{
    public partial class UsersForm : Form
    {
        private int _selectedUserId = 0;

        public UsersForm()
        {
            InitializeComponent();
            ApplyCustomStyling();
            WireEvents();

            Load += (s, e) =>
            {
                cmbRole.SelectedIndex = 1; // Default to Librarian
                LoadUsers();
            };
        }

        private void ApplyCustomStyling()
        {
            Theme.StyleDataGridView(dgvUsers);
            Theme.StylePrimaryButton(btnAdd);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleSecondaryButton(btnResetPassword);
            Theme.StyleSecondaryButton(btnClear);

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

            dgvUsers.SelectionChanged += (s, e) =>
            {
                if (dgvUsers.CurrentRow != null && dgvUsers.CurrentRow.DataBoundItem is User user)
                {
                    PopulateFields(user);
                }
            };

            btnAdd.Click += (s, e) => PerformAddUser();
            btnUpdate.Click += (s, e) => PerformUpdateUser();
            btnResetPassword.Click += (s, e) => PerformResetPassword();
            btnDelete.Click += (s, e) => PerformDeleteUser();
            btnClear.Click += (s, e) => ClearFields();
        }

        private void LoadUsers()
        {
            try
            {
                var list = Database.GetUsers();
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = list;

                foreach (DataGridViewColumn col in dgvUsers.Columns)
                {
                    string prop = col.DataPropertyName ?? col.Name ?? "";
                    if (string.Equals(prop, "PasswordHash", StringComparison.OrdinalIgnoreCase))
                    {
                        col.Visible = false;
                    }
                    else if (string.Equals(prop, "Id", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "ID";
                        col.Width = 50;
                    }
                    else if (string.Equals(prop, "Username", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Username";
                        col.Width = 120;
                    }
                    else if (string.Equals(prop, "FullName", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Full Name";
                        col.Width = 180;
                    }
                    else if (string.Equals(prop, "Email", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Email";
                        col.Width = 180;
                    }
                    else if (string.Equals(prop, "Role", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Role";
                        col.Width = 100;
                    }
                    else if (string.Equals(prop, "IsActive", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Active";
                        col.Width = 80;
                    }
                    else if (string.Equals(prop, "CreatedAt", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = "Created Date";
                        col.Width = 130;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in LoadUsers: " + ex.Message);
            }
        }

        private void PopulateFields(User user)
        {
            _selectedUserId = user.Id;
            txtUsername.Text = user.Username;
            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            chkIsActive.Checked = user.IsActive;

            txtUsername.ReadOnly = true; // Username cannot be modified once created
            txtPassword.Clear();

            string roleStr = user.Role.ToString();
            if (cmbRole.Items.Contains(roleStr)) cmbRole.SelectedItem = roleStr;
        }

        private void ClearFields()
        {
            _selectedUserId = 0;
            txtUsername.ReadOnly = false;
            txtUsername.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            chkIsActive.Checked = true;
            cmbRole.SelectedIndex = 1;
        }

        private void PerformAddUser()
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Full Name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required for new accounts.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            UserRole role = Enum.TryParse<UserRole>(cmbRole.SelectedItem?.ToString(), out var r) ? r : UserRole.User;

            var user = new User
            {
                Username = username,
                FullName = fullName,
                Email = txtEmail.Text.Trim(),
                Role = role,
                IsActive = chkIsActive.Checked
            };

            if (Database.AddUser(user, password))
            {
                MessageBox.Show($"User '{username}' created successfully as {role}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to create user. The username might already be in use.", "Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformUpdateUser()
        {

            if (_selectedUserId <= 0)
            {
                MessageBox.Show("Please select a user to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fullName = txtFullName.Text.Trim();
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Full Name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            UserRole role = Enum.TryParse<UserRole>(cmbRole.SelectedItem?.ToString(), out var r) ? r : UserRole.User;

            var user = new User
            {
                Id = _selectedUserId,
                Username = txtUsername.Text.Trim(),
                FullName = fullName,
                Email = txtEmail.Text.Trim(),
                Role = role,
                IsActive = chkIsActive.Checked
            };

            if (Database.UpdateUser(user))
            {
                MessageBox.Show("User profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Failed to update user profile.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformResetPassword()
        {
            if (_selectedUserId <= 0)
            {
                MessageBox.Show("Please select a user to reset password.", "Selection required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string newPassword = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter the new password in the password field.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (Database.ResetUserPassword(_selectedUserId, newPassword))
            {
                MessageBox.Show($"Password for '{txtUsername.Text}' has been reset successfully!", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Failed to reset password.", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformDeleteUser()
        {
            if (_selectedUserId <= 0)
            {
                MessageBox.Show("Please select a user to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_selectedUserId == Session.CurrentUser?.Id)
            {
                MessageBox.Show("You cannot delete your own currently logged-in account.", "Operation Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to permanently delete account '{txtUsername.Text}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Database.DeleteUser(_selectedUserId))
                {
                    MessageBox.Show("User account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to delete user.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblRoleGuide_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void secUserDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}

