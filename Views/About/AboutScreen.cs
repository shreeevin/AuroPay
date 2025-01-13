namespace AuroPay.Views.About
{
    public partial class AboutScreen : Form
    {
        public AboutScreen()
        {
            InitializeComponent();
        }       

        private void AdjustLayout(object sender, EventArgs e)
        {
            sidebarPanel.Width = (int)(this.ClientSize.Width * 0.25);
            contentPanel.Width = (int)(this.ClientSize.Width * 0.75);
            
            logoPictureBox.Location = new Point(
                (sidebarPanel.Width - logoPictureBox.Width) / 2,
                40
            );
            

            firstParaLabel.Width = contentPanel.Width - 80;
            secondParaLabel.Width = contentPanel.Width - 80;
            thirdParaLabel.Width = contentPanel.Width - 80;
            
            aboutTitleLabel.Width = contentPanel.Width - 80;

            homeButton.Size = new Size(sidebarPanel.Width - 40, 40);
            statsButton.Size = new Size(sidebarPanel.Width - 40, 40);
            aboutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            transactionButton.Size = new Size(sidebarPanel.Width - 40, 40);
            profileButton.Size = new Size(sidebarPanel.Width - 40, 40);
            settingButton.Size = new Size(sidebarPanel.Width - 40, 40);
            logoutButton.Size = new Size(sidebarPanel.Width - 40, 40);
        }
    }
}
