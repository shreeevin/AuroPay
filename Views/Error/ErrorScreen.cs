using AuroPay.Controllers;

namespace AuroPay.Views.Error
{
    public partial class ErrorScreen : Form
    {
        public ErrorScreen()
        {
            InitializeComponent();
        }
        private void HomeButtonClicked(object sender, EventArgs e){
            HomeController.NavigateToHome(this);
        }
        private void AdjustLayout(PictureBox logoPictureBox, Label appNameLabel, Label copyrightLabel, Button homeButton)
        {
            logoPictureBox.Width = (int)(this.ClientSize.Width * 0.6); 
            logoPictureBox.Height = (int)(logoPictureBox.Width * 0.4); 

            logoPictureBox.Location = new Point(
                (this.ClientSize.Width - logoPictureBox.Width) / 2,
                (this.ClientSize.Height - logoPictureBox.Height) / 2 - 20
            );

            appNameLabel.Location = new Point(
                (this.ClientSize.Width - appNameLabel.Width) / 2,
                logoPictureBox.Bottom + 20
            );

            homeButton.Size = new Size((int)(contentPanel.Width * 0.8), 40);
            homeButton.Location = new Point(
                (ClientSize.Width - homeButton.Width) / 2,
                appNameLabel.Bottom + 20
            );

            copyrightLabel.Location = new Point(
                (this.ClientSize.Width - copyrightLabel.Width) / 2,
                this.ClientSize.Height - copyrightLabel.Height - 40
            );
        }
    }
}
