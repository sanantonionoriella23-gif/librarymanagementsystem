using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Vector Icon Engine: Draws high-DPI crisp icons dynamically using GDI+
    /// without relying on external image asset paths.
    /// </summary>
    public static class Icons
    {
        public static Bitmap CreateIcon(string name, int size, Color color)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                float scale = size / 24f;
                using (Pen pen = new Pen(color, Math.Max(1.8f * scale, 1.5f)))
                using (Brush brush = new SolidBrush(color))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    switch (name.ToLowerInvariant())
                    {
                        case "dashboard":
                            // 4 neat tiles
                            g.FillRectangle(brush, 3 * scale, 3 * scale, 7 * scale, 7 * scale);
                            g.FillRectangle(brush, 14 * scale, 3 * scale, 7 * scale, 7 * scale);
                            g.FillRectangle(brush, 3 * scale, 14 * scale, 7 * scale, 7 * scale);
                            g.FillRectangle(brush, 14 * scale, 14 * scale, 7 * scale, 7 * scale);
                            break;

                        case "books":
                            // Open book or book spine
                            g.DrawRectangle(pen, 4 * scale, 4 * scale, 16 * scale, 16 * scale);
                            g.DrawLine(pen, 9 * scale, 4 * scale, 9 * scale, 20 * scale);
                            g.DrawLine(pen, 12 * scale, 8 * scale, 17 * scale, 8 * scale);
                            g.DrawLine(pen, 12 * scale, 12 * scale, 17 * scale, 12 * scale);
                            break;

                        case "members":
                            // User card / avatar
                            g.DrawEllipse(pen, 8 * scale, 4 * scale, 8 * scale, 8 * scale);
                            g.DrawArc(pen, 4 * scale, 13 * scale, 16 * scale, 9 * scale, 180, 180);
                            break;

                        case "borrowreturn":
                            // Two circulation arrows
                            g.DrawArc(pen, 4 * scale, 5 * scale, 16 * scale, 14 * scale, 45, 180);
                            g.DrawLine(pen, 4 * scale, 10 * scale, 4 * scale, 14 * scale);
                            g.DrawLine(pen, 4 * scale, 14 * scale, 8 * scale, 14 * scale);

                            g.DrawArc(pen, 4 * scale, 5 * scale, 16 * scale, 14 * scale, 225, 180);
                            g.DrawLine(pen, 20 * scale, 14 * scale, 20 * scale, 10 * scale);
                            g.DrawLine(pen, 20 * scale, 10 * scale, 16 * scale, 10 * scale);
                            break;

                        case "history":
                            // Clock / Audit
                            g.DrawEllipse(pen, 3 * scale, 3 * scale, 18 * scale, 18 * scale);
                            g.DrawLine(pen, 12 * scale, 6 * scale, 12 * scale, 12 * scale);
                            g.DrawLine(pen, 12 * scale, 12 * scale, 16 * scale, 14 * scale);
                            break;

                        case "users":
                            // Team / Admin users
                            g.DrawEllipse(pen, 6 * scale, 5 * scale, 6 * scale, 6 * scale);
                            g.DrawArc(pen, 3 * scale, 12 * scale, 12 * scale, 8 * scale, 180, 180);
                            g.DrawEllipse(pen, 14 * scale, 7 * scale, 5 * scale, 5 * scale);
                            g.DrawArc(pen, 12 * scale, 13 * scale, 9 * scale, 7 * scale, 180, 180);
                            break;

                        case "logout":
                            // Power or arrow-exit
                            g.DrawArc(pen, 5 * scale, 6 * scale, 14 * scale, 14 * scale, 300, 300);
                            g.DrawLine(pen, 12 * scale, 3 * scale, 12 * scale, 12 * scale);
                            break;

                        case "search":
                            // Magnifier
                            g.DrawEllipse(pen, 4 * scale, 4 * scale, 10 * scale, 10 * scale);
                            g.DrawLine(pen, 12 * scale, 12 * scale, 19 * scale, 19 * scale);
                            break;

                        case "add":
                            // Plus
                            g.DrawLine(pen, 12 * scale, 5 * scale, 12 * scale, 19 * scale);
                            g.DrawLine(pen, 5 * scale, 12 * scale, 19 * scale, 12 * scale);
                            break;

                        case "qrcode":
                            // QR icon
                            g.DrawRectangle(pen, 4 * scale, 4 * scale, 6 * scale, 6 * scale);
                            g.DrawRectangle(pen, 14 * scale, 4 * scale, 6 * scale, 6 * scale);
                            g.DrawRectangle(pen, 4 * scale, 14 * scale, 6 * scale, 6 * scale);
                            g.FillRectangle(brush, 6 * scale, 6 * scale, 2 * scale, 2 * scale);
                            g.FillRectangle(brush, 16 * scale, 6 * scale, 2 * scale, 2 * scale);
                            g.FillRectangle(brush, 6 * scale, 16 * scale, 2 * scale, 2 * scale);
                            g.FillRectangle(brush, 14 * scale, 14 * scale, 3 * scale, 3 * scale);
                            g.FillRectangle(brush, 17 * scale, 17 * scale, 3 * scale, 3 * scale);
                            break;

                        case "export":
                            // Download / CSV export icon
                            g.DrawLine(pen, 12 * scale, 4 * scale, 12 * scale, 15 * scale);
                            g.DrawLine(pen, 8 * scale, 11 * scale, 12 * scale, 15 * scale);
                            g.DrawLine(pen, 16 * scale, 11 * scale, 12 * scale, 15 * scale);
                            g.DrawLine(pen, 4 * scale, 19 * scale, 20 * scale, 19 * scale);
                            break;

                        case "warning":
                            // Overdue warning
                            PointF[] triangle = {
                                new PointF(12 * scale, 3 * scale),
                                new PointF(21 * scale, 20 * scale),
                                new PointF(3 * scale, 20 * scale)
                            };
                            g.DrawPolygon(pen, triangle);
                            g.DrawLine(pen, 12 * scale, 9 * scale, 12 * scale, 14 * scale);
                            g.FillEllipse(brush, 11 * scale, 16.5f * scale, 2 * scale, 2 * scale);
                            break;

                        default:
                            // Generic circle
                            g.DrawEllipse(pen, 4 * scale, 4 * scale, 16 * scale, 16 * scale);
                            break;
                    }
                }
            }
            return bmp;
        }
    }
}

