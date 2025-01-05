namespace AuroPay.Views.Splash
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        private void AdjustLayout(PictureBox logoPictureBox, Label appNameLabel, Label copyrightLabel)
        {
            logoPictureBox.Width = (int)(this.ClientSize.Width * 0.3); 
            logoPictureBox.Height = (int)(logoPictureBox.Width * 0.2); 

            logoPictureBox.Location = new Point(
                (this.ClientSize.Width - logoPictureBox.Width) / 2,
                (this.ClientSize.Height - logoPictureBox.Height) / 2 - 20
            );

            appNameLabel.Location = new Point(
                (this.ClientSize.Width - appNameLabel.Width) / 2,
                logoPictureBox.Bottom + 20
            );

            copyrightLabel.Location = new Point(
                (this.ClientSize.Width - copyrightLabel.Width) / 2,
                this.ClientSize.Height - copyrightLabel.Height - 40
            );
        }
    }
}
