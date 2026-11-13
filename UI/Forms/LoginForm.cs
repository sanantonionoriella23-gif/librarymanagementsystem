using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ApplyCustomStyling();
            WireEvents();
        }

        private void ApplyCustomStyling()
        {
            Theme.StylePrimaryButton(btnLogin);

            pnlCard.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen borderPen = new Pen(Theme.BorderSubtle, 1.5f))
                {
                    e.Graphics.DrawRectangle(borderPen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
                }
            };
        }

        private void WireEvents()
        {
            chkShowPassword.CheckedChanged += (s, e) =>
            {
                txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
            };

            btnLogin.Click += (s, e) => PerformLogin();

            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) PerformLogin();
            };

            txtUsername.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) txtPassword.Focus();
            };
        }

        private void PerformLogin()
        {
            lblError.Text = "";
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter both username and password.";
                return;
            }

            try
            {
                var user = Database.Authenticate(username, password);
                if (user != null)
                {
                    Session.SetUser(user);
                    Hide();

                    DialogResult result;
                    using (var mainForm = new MainForm())
                    {
                        result = mainForm.ShowDialog();
                    }

                    if (result == DialogResult.OK)
                    {
                        // Clean reset on sign out
                        Session.Clear();
                        txtUsername.Clear();
                        txtPassword.Clear();
                        chkShowPassword.Checked = false;
                        lblError.Text = "";
                        Show();
                        txtUsername.Focus();
                    }
                    else
                    {
                        // Application closed via window close
                        Close();
                    }
                }
                else
                {
                    lblError.Text = "Invalid username or password. Please try again.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Login error: " + ex.Message;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void lblHeaderTitle_Click(object sender, EventArgs e)
        {

        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

