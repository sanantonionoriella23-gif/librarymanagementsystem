using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    /// <summary>
    /// University Academic Library Design System (Pink & White Institutional Theme)
    /// Dignified, scholarly, and professional with high contrast for university accreditation.
    /// </summary>
    public static class Theme
    {
        // Core Academic Palette (University Rose & White)
        public static readonly Color Primary = Color.FromArgb(216, 27, 96);        // University Rose (#D81B60)
        public static readonly Color PrimaryDark = Color.FromArgb(173, 20, 87);    // Deep Scholarly Crimson-Rose (#AD1457)
        public static readonly Color PrimaryLight = Color.FromArgb(253, 237, 242); // Soft Academic Blush (#FDEDF2)
        public static readonly Color PrimarySoft = Color.FromArgb(248, 187, 208);  // Rose 100 (#F8BBD0)
        public static readonly Color Accent = Color.FromArgb(233, 30, 99);         // Rose Accent (#E91E63)

        // Surfaces & Backgrounds
        public static readonly Color Background = Color.FromArgb(254, 250, 252);   // Academic Parchment Rose-White
        public static readonly Color CardBackground = Color.FromArgb(255, 255, 255);// Pure White (#FFFFFF)
        public static readonly Color SidebarBackground = Color.FromArgb(255, 255, 255);
        public static readonly Color BorderColor = Color.FromArgb(244, 143, 177);  // Soft Pink Border
        public static readonly Color BorderSubtle = Color.FromArgb(242, 215, 225);

        // Academic Typography Colors (14:1 High Contrast)
        public static readonly Color TextPrimary = Color.FromArgb(30, 41, 59);     // Deep Slate Navy (#1E293B)
        public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139);// Slate Charcoal (#64748B)
        public static readonly Color TextPink = Color.FromArgb(173, 20, 87);       // Deep Rose for highlights
        public static readonly Color TextOnPink = Color.White;

        // University Institutional Feedback / Status
        public static readonly Color Success = Color.FromArgb(22, 101, 52);       // Academic Forest Green (#166534)
        public static readonly Color SuccessBg = Color.FromArgb(240, 253, 244);
        public static readonly Color Warning = Color.FromArgb(180, 83, 9);         // Amber Gold (#B45309)
        public static readonly Color WarningBg = Color.FromArgb(254, 243, 199);
        public static readonly Color Danger = Color.FromArgb(185, 28, 28);         // Crimson Alert (#B91C1C)
        public static readonly Color DangerBg = Color.FromArgb(254, 242, 242);

        // Institutional Fonts
        public static readonly Font KpiFont = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
        public static readonly Font HeaderLarge = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        public static readonly Font HeaderMedium = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
        public static readonly Font Subheader = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
        public static readonly Font BodyRegular = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        public static readonly Font BodyBold = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        public static readonly Font SmallRegular = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);

        /// <summary>
        /// Styles a DataGridView into a clean institutional catalog table.
        /// </summary>
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(245, 230, 235);
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 36;

            // University Column Header Style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDark;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = Subheader;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Row Styles
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = BodyRegular;
            dgv.DefaultCellStyle.SelectionBackColor = PrimaryLight;
            dgv.DefaultCellStyle.SelectionForeColor = PrimaryDark;
            dgv.DefaultCellStyle.Padding = new Padding(8, 2, 8, 2);

            // Alternating Row Style (subtle academic blush tint)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = PrimaryLight;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = PrimaryDark;
        }

        public static void StylePrimaryButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = PrimaryDark;
            btn.ForeColor = Color.White;
            btn.Font = BodyBold;
            btn.Cursor = Cursors.Hand;
            btn.Height = Math.Max(btn.Height, 36);

            btn.MouseEnter += (s, e) => btn.BackColor = Primary;
            btn.MouseLeave += (s, e) => btn.BackColor = PrimaryDark;
        }

        public static void StyleSecondaryButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Primary;
            btn.BackColor = Color.White;
            btn.ForeColor = PrimaryDark;
            btn.Font = BodyBold;
            btn.Cursor = Cursors.Hand;
            btn.Height = Math.Max(btn.Height, 36);

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = PrimaryLight;
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.White;
            };
        }

        public static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
