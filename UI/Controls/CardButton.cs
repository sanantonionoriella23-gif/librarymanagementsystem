using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interactive Dashboard Card with statistics, icon, and hover states.
    /// Perfectly suited for the enterprise Pink & White aesthetic.
    /// </summary>
    public class CardButton : Control
    {
        private string _title = "Card Title";
        private string _value = "0";
        private string _subtitle = "Detail text";
        private string _iconName = "dashboard";
        private Color _accentColor = Theme.Primary;
        private bool _isHovered = false;
        private bool _isPressed = false;
        private int _borderRadius = 12;

        public CardButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.White;
            Size = new Size(200, 100);
            Cursor = Cursors.Hand;
        }

        [Category("Appearance")]
        public string Title
        {
            get => _title;
            set { _title = value; Invalidate(); }
        }

        [Category("Appearance")]
        public string Value
        {
            get => _value;
            set { _value = value; Invalidate(); }
        }

        [Category("Appearance")]
        public string Subtitle
        {
            get => _subtitle;
            set { _subtitle = value; Invalidate(); }
        }

        [Category("Appearance")]
        public string IconName
        {
            get => _iconName;
            set { _iconName = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color AccentColor
        {
            get => _accentColor;
            set { _accentColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = Math.Max(0, value); Invalidate(); }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _isPressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isPressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // Background card fill
            Color bgColor = _isPressed ? Color.FromArgb(254, 240, 244) :
                            _isHovered ? Color.FromArgb(255, 248, 250) : Color.White;

            using (GraphicsPath path = Theme.CreateRoundedRectangle(rect, _borderRadius))
            {
                using (SolidBrush bgBrush = new SolidBrush(bgColor))
                {
                    g.FillPath(bgBrush, path);
                }

                // Border
                Color borderColor = _isHovered ? _accentColor : Theme.BorderSubtle;
                float borderWidth = _isHovered ? 2.0f : 1.2f;
                using (Pen borderPen = new Pen(borderColor, borderWidth))
                {
                    g.DrawPath(borderPen, path);
                }

                // Left Accent Indicator Pill
                using (SolidBrush accentBrush = new SolidBrush(_accentColor))
                {
                    Rectangle accentPill = new Rectangle(0, 10, 5, Height - 20);
                    using (GraphicsPath pillPath = Theme.CreateRoundedRectangle(accentPill, 2))
                    {
                        g.FillPath(accentBrush, pillPath);
                    }
                }
            }

            // Draw Icon at top-right
            if (!string.IsNullOrEmpty(_iconName))
            {
                int iconSize = 32;
                int iconX = Width - iconSize - 16;
                int iconY = 16;

                // Circular tinted icon background
                using (SolidBrush iconBg = new SolidBrush(Color.FromArgb(25, _accentColor.R, _accentColor.G, _accentColor.B)))
                {
                    g.FillEllipse(iconBg, iconX - 6, iconY - 6, iconSize + 12, iconSize + 12);
                }

                using (Bitmap ico = Icons.CreateIcon(_iconName, iconSize, _accentColor))
                {
                    g.DrawImage(ico, iconX, iconY);
                }
            }

            // Draw Title (small muted bold)
            using (SolidBrush titleBrush = new SolidBrush(Theme.TextSecondary))
            {
                g.DrawString(_title.ToUpperInvariant(), Theme.SmallRegular, titleBrush, new PointF(18, 14));
            }

            // Draw KPI Value
            using (SolidBrush valBrush = new SolidBrush(Theme.TextPrimary))
            {
                g.DrawString(_value, Theme.KpiFont, valBrush, new PointF(16, 32));
            }

            // Draw Subtitle / Status Tag
            using (SolidBrush subBrush = new SolidBrush(_accentColor))
            {
                g.DrawString(_subtitle, Theme.SmallRegular, subBrush, new PointF(18, Height - 24));
            }
        }
    }
}

