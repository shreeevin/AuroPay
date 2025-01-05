using System.Drawing.Drawing2D;

namespace AuroPay.Helpers
{
    public static class LayoutHelper
    {
        public static void CreateRoundedCorners(Button button, int cornerRadius = 12)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); 
            path.AddArc(button.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); 
            path.AddArc(button.Width - cornerRadius, button.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); 
            path.AddArc(0, button.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); 
            path.CloseFigure();
            button.Region = new Region(path);
        }
        public static void ApplyRoundedCornersAndBackground(PaintEventArgs e, Control control, int cornerRadius, Color backgroundColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = control.ClientRectangle;
                rect.Inflate(-1, -1); 

                path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90); 
                path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90); 
                path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90); 
                path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90); 
                path.CloseFigure();

                using (Brush brush = new SolidBrush(backgroundColor))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }

                var borderColor = (control is Button) ? control.ForeColor : Color.Gray; 
                using (Pen pen = new Pen(borderColor, 1.5f)) 
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        public static void AddPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholderText;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
    }
}
