using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Enterprise Section Box container with rounded borders and header bar.
    /// Provides crisp visual hierarchy for form controls and tables.
    /// </summary>
    public class SectionBox : Panel
    {
        private string _title = "";
        private int _borderRadius = 12;
        private Color _headerColor = Theme.Primary;
        private bool _showHeaderBar = false;

        public SectionBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.White;
            Padding = new Padding(16);
        }

        [Category("Appearance")]
        public string Title
        {
            get => _title;
            set { _title = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = Math.Max(0, value); Invalidate(); }
        }

        [Category("Appearance")]
        public bool ShowHeaderBar
        {
            get => _showHeaderBar;
            set { _showHeaderBar = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color HeaderColor
        {
            get => _headerColor;
            set { _headerColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = Theme.CreateRoundedRectangle(rect, _borderRadius))
            {
                // Fill panel
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    g.FillPath(brush, path);
                }

                // Header bar if enabled
                if (_showHeaderBar)
                {
                    Rectangle headerRect = new Rectangle(0, 0, Width - 1, 38);
                    using (GraphicsPath headerPath = Theme.CreateRoundedRectangle(headerRect, _borderRadius))
                    {
                        using (SolidBrush hBrush = new SolidBrush(Theme.PrimaryLight))
                        {
                            g.FillPath(hBrush, headerPath);
                        }
                    }
                    if (!string.IsNullOrEmpty(_title))
                    {
                        using (SolidBrush tBrush = new SolidBrush(Theme.PrimaryDark))
                        {
                            g.DrawString(_title, Theme.Subheader, tBrush, new PointF(14, 10));
                        }
                    }
                }

                // Border
                using (Pen pen = new Pen(Theme.BorderSubtle, 1.2f))
                {
                    g.DrawPath(pen, path);
                }
            }
        }
    }
}

