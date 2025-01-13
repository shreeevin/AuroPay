namespace AuroPay.Views.Splash
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        private void AdjustLayout()
        {
            logoPictureBox.Width = (int)(this.ClientSize.Width * 0.075); 
            logoPictureBox.Height = (int)(this.ClientSize.Width * 0.075); 

            logoPictureBox.Location = new Point(
                (this.ClientSize.Width - logoPictureBox.Width) / 2,
                (this.ClientSize.Height - (int)(this.ClientSize.Height * 0.15) - logoPictureBox.Height) / 2 - 20
            );

            appNameLabel.Location = new Point(
                (this.ClientSize.Width - appNameLabel.Width) / 2,
                logoPictureBox.Bottom + 20
            );

            copyrightLabel.Location = new Point(
                (this.ClientSize.Width - copyrightLabel.Width) / 2,
                this.ClientSize.Height - (int)(this.ClientSize.Height * 0.05) - copyrightLabel.Height
            );
        }
    }
}
