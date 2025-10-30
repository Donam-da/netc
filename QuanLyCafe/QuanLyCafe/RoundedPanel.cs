using System.Runtime.Versioning;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 15;
        public Color BorderColor { get; set; } = Color.FromArgb(180, 180, 180);
        public int BorderThickness { get; set; } = 1;
        public Color GradientStartColor { get; set; } = Color.Empty;
        public Color GradientEndColor { get; set; } = Color.Empty;
        public float GradientAngle { get; set; } = 90f;

        public RoundedPanel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                path.AddArc(rect.X, rect.Y, CornerRadius, CornerRadius, 180, 90);
                path.AddArc(rect.Right - CornerRadius, rect.Y, CornerRadius, CornerRadius, 270, 90);
                path.AddArc(rect.Right - CornerRadius, rect.Bottom - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                path.CloseAllFigures();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Fill background
                if (GradientStartColor != Color.Empty && GradientEndColor != Color.Empty)
                {
                    using (LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, GradientStartColor, GradientEndColor, GradientAngle))
                    {
                        e.Graphics.FillPath(lgb, path);
                    }
                }
                else
                {
                    using (SolidBrush brush = new SolidBrush(this.BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                // Draw border
                using (Pen pen = new Pen(BorderColor, BorderThickness))
                {
                    e.Graphics.DrawPath(pen, path);
                }

                // Set region to clip child controls
                this.Region = new Region(path);
            }
        }
    }
}
