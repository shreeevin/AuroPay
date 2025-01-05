namespace AuroPay.Views.Error
{
    partial class ErrorScreen
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.MinimumSize = new Size(800, 450);
            this.ClientSize = new Size(800, 450);

            this.WindowState = FormWindowState.Maximized; 

            this.Name = "AuroPay";
            this.Text = "AuroPay";
            this.BackColor = Color.White;
            this.Icon = new Icon("Resources/AppIcon/icon.ico");

            PictureBox logoPictureBox = new PictureBox();
            logoPictureBox.Image = Image.FromFile("Resources/Images/error.png");
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(logoPictureBox);

            Label appNameLabel = new Label();
            appNameLabel.Text = "Oops! We broke the server.";
            appNameLabel.Font = new Font("Inter", 16, FontStyle.Regular);
            appNameLabel.AutoSize = true;
            this.Controls.Add(appNameLabel);


            Label copyrightLabel = new Label();
            copyrightLabel.Text = $"© {DateTime.Now.Year} AuroPay. All rights reserved.";
            copyrightLabel.Font = new Font("Inter", 10, FontStyle.Regular);
            copyrightLabel.ForeColor = Color.Gray;
            copyrightLabel.AutoSize = true;
            this.Controls.Add(copyrightLabel);

            this.Resize += (sender, e) => AdjustLayout(logoPictureBox, appNameLabel, copyrightLabel);


            this.ResumeLayout(false);

            AdjustLayout(logoPictureBox, appNameLabel, copyrightLabel);
        }
    }
}
