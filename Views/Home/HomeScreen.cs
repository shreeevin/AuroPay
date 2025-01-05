using AuroPay.Models;
using AuroPay.Common; 

namespace AuroPay.Views.Home
{
    public partial class HomeScreen : Form, IViewData
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        public void SetData(object data)
        {
            if (data is User currentUser)
            {
                this.currentUser = currentUser;

                nameLabel.Text = $"{currentUser.Name}";
                emailLabel.Text = $"{currentUser.Email}";
                phoneLabel.Text = $"{currentUser.Phone}";
                walletAndCurrencyLabel.Text = $"{currentUser.Currency} {currentUser.Wallet}";
                joinedOnLabel.Text = $"Joined on {currentUser.CreatedAt.ToString("MMM dd, yyyy")}";
            }
        }

        private void AdjustLayout(object sender, EventArgs e)
        {
            sidebarPanel.Width = (int)(this.ClientSize.Width * 0.25);
            contentPanel.Width = (int)(this.ClientSize.Width * 0.75);
            
            logoPictureBox.Location = new Point(
                (sidebarPanel.Width - logoPictureBox.Width) / 2,
                40
            );
            

            nameLabel.Width = contentPanel.Width - 80;
            emailLabel.Width = contentPanel.Width - 80;
            phoneLabel.Width = contentPanel.Width - 80;
            walletAndCurrencyLabel.Width = contentPanel.Width - 80;
            joinedOnLabel.Width = contentPanel.Width - 80;
            greetingMessageLabel.Width = contentPanel.Width - 80;

            homeButton.Size = new Size(sidebarPanel.Width - 40, 40);
            aboutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            transactionButton.Size = new Size(sidebarPanel.Width - 40, 40);
            profileButton.Size = new Size(sidebarPanel.Width - 40, 40);
            settingButton.Size = new Size(sidebarPanel.Width - 40, 40);
            logoutButton.Size = new Size(sidebarPanel.Width - 40, 40);

            settlementIncomeButton.Size = new Size((int)(contentPanel.Width * 0.2), 40);
            settlementExpenseButton.Size = new Size((int)(contentPanel.Width * 0.2), 40);
            settlementDebtButton.Size = new Size((int)(contentPanel.Width * 0.2), 40);

            settlementIncomeButton.Location = new Point(20, joinedOnLabel.Bottom + 50);
            settlementExpenseButton.Location = new Point(settlementIncomeButton.Right + 20, joinedOnLabel.Bottom + 50);
            settlementDebtButton.Location = new Point(settlementExpenseButton.Right + 20, joinedOnLabel.Bottom + 50);
        }
    }
}
