using AuroPay.Helpers;
using AuroPay.Components.Assistants;

namespace AuroPay.Views.Error
{
    partial class ErrorScreen
    {
        private Button homeButton;
        private Panel contentPanel;
        private PictureBox logoPictureBox;
        private Label appNameLabel;
        private Label copyrightLabel ;

        private void InitializeComponent()
        {
            this.contentPanel = new Panel();

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this, "AuroPay - Error");

            homeButton =  new Button();
            logoPictureBox = new PictureBox();
            appNameLabel = new Label();
            copyrightLabel = new Label();

            logoPictureBox.Image = Image.FromFile("Resources/Images/error.png");
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            appNameLabel.Text = "Oops! We broke the server.";
            appNameLabel.Font = new Font("Inter", 16, FontStyle.Regular);
            appNameLabel.AutoSize = true;

            homeButton.Text = "Go Home";
            homeButton.Font = new Font("Inter", 12F, FontStyle.Bold);
            homeButton.BackColor = Color.Black;
            homeButton.ForeColor = Color.White;
            homeButton.FlatStyle = FlatStyle.Flat;
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.Cursor = Cursors.Hand; 
            homeButton.Click += new EventHandler(HomeButtonClicked);
            homeButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(homeButton);
            homeButton.Size = new Size((int)(contentPanel.Width * 0.8), 40);
            homeButton.Location = new Point(
                (this.ClientSize.Width - homeButton.Width) / 2,
                appNameLabel.Bottom + 20
            );

            copyrightLabel.Text = $"© {DateTime.Now.Year} AuroPay. All rights reserved.";
            copyrightLabel.Font = new Font("Inter", 10, FontStyle.Regular);
            copyrightLabel.ForeColor = Color.Gray;
            copyrightLabel.AutoSize = true;

            LayoutHelper.CreateRoundedCorners(homeButton, 16);

            this.Controls.Add(logoPictureBox);
            this.Controls.Add(appNameLabel);
            this.Controls.Add(homeButton);
            this.Controls.Add(copyrightLabel);

            this.Resize += (sender, e) => AdjustLayout(logoPictureBox, appNameLabel, copyrightLabel, homeButton);


            this.ResumeLayout(false);

            AdjustLayout(logoPictureBox, appNameLabel, copyrightLabel, homeButton);
        }
    }
}
