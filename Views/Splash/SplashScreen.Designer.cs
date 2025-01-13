using AuroPay.Components.Assistants;

namespace AuroPay.Views.Splash
{
    partial class SplashScreen
    {
        private Panel contentPanel;
        private PictureBox logoPictureBox;
        private Label appNameLabel;
        private Label copyrightLabel;
        private void InitializeComponent()
        {
            this.contentPanel = new Panel();

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this);

            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1280, 720);
            this.contentPanel.TabIndex = 0;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;

            logoPictureBox = new PictureBox();
            appNameLabel = new Label();
            copyrightLabel = new Label();

            logoPictureBox.Image = Image.FromFile("Resources/Images/logo.color.png");
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            appNameLabel.Text = "AuroPay";
            appNameLabel.Font = new Font("Inter", 12, FontStyle.Bold);
            appNameLabel.ForeColor = Color.Black;
            appNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            appNameLabel.AutoSize = true;

            copyrightLabel.Text = $"© {DateTime.Now.Year} AuroPay. All rights reserved.";
            copyrightLabel.Font = new Font("Inter", 8, FontStyle.Regular);
            copyrightLabel.ForeColor = Color.Gray;
            copyrightLabel.TextAlign = ContentAlignment.MiddleCenter;
            copyrightLabel.AutoSize = true;

            this.contentPanel.Controls.Add(logoPictureBox);
            this.contentPanel.Controls.Add(appNameLabel);
            this.contentPanel.Controls.Add(copyrightLabel);            
            
            this.Controls.Add(this.contentPanel);

            this.Load += (sender, e) => AdjustLayout();
            this.Resize += (sender, e) => AdjustLayout();

            this.ResumeLayout(false);
        }       
    }
}