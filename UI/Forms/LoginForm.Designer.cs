namespace LibraryManagementSystem
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnLogin;

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
            pnlCard = new Panel();
            lblError = new Label();
            btnLogin = new Button();
            chkShowPassword = new CheckBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblHeaderSubtitle = new Label();
            lblHeaderTitle = new Label();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.BlanchedAlmond;
            pnlCard.Controls.Add(lblError);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Controls.Add(chkShowPassword);
            pnlCard.Controls.Add(txtPassword);
            pnlCard.Controls.Add(lblPassword);
            pnlCard.Controls.Add(txtUsername);
            pnlCard.Controls.Add(lblUsername);
            pnlCard.Controls.Add(lblHeaderSubtitle);
            pnlCard.Location = new Point(71, 142);
            pnlCard.Margin = new Padding(4, 5, 4, 5);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(657, 565);
            pnlCard.TabIndex = 0;
            // 
            // lblError
            // 
            lblError.BackColor = Color.WhiteSmoke;
            lblError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(255, 192, 128);
            lblError.Location = new Point(64, 484);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(529, 37);
            lblError.TabIndex = 8;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(192, 0, 0);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(64, 409);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(529, 70);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Sign In";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(100, 116, 139);
            chkShowPassword.Location = new Point(60, 347);
            chkShowPassword.Margin = new Padding(4, 5, 4, 5);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(164, 29);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Show password";
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.WhiteSmoke;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(60, 287);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(527, 37);
            txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.Maroon;
            lblPassword.Location = new Point(66, 236);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(97, 25);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.WhiteSmoke;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(60, 156);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(527, 37);
            txtUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.DarkRed;
            lblUsername.Location = new Point(66, 111);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(102, 25);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblHeaderSubtitle.Location = new Point(173, 27);
            lblHeaderSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(309, 25);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Sign in to access your library account.";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.BackColor = Color.Transparent;
            lblHeaderTitle.Font = new Font("Calisto MT", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeaderTitle.ForeColor = Color.Maroon;
            lblHeaderTitle.Location = new Point(203, 97);
            lblHeaderTitle.Margin = new Padding(4, 0, 4, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(396, 40);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "CS LIBRARY SYSTEM";
            lblHeaderTitle.Click += lblHeaderTitle_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 250, 252);
            BackgroundImage = Properties.Resources.lib;
            ClientSize = new Size(800, 750);
            Controls.Add(pnlCard);
            Controls.Add(lblHeaderTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = ",";
            Load += LoginForm_Load;
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lblError;
    }
}
