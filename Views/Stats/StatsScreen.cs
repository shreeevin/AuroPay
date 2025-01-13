using AuroPay.Models;
using AuroPay.Common;
using AuroPay.Services;

namespace AuroPay.Views.Stats
{
    public partial class StatsScreen : Form, IViewData
    {
        public StatsScreen()
        {
            InitializeComponent();            
        }

        public void SetData(object data)
        {
            if (data is User currentUser)
            {
                this.currentUser = currentUser;
            }
            
            GetLatestStats();

            PopulateBadges("balance");
            PopulateBadges("stat");
            PopulateBadges("debt");
            PopulateBadges("debt_balance");          
        }
        private void CreateBadge(string title, int count, FlowLayoutPanel container, Color color, bool balance = false)
        {
            Panel badgePanel = new Panel
            {
                AutoSize = true,
                Height = 40,
                Margin = new Padding(5),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label titleLabel = new Label
            {
                Text = title,
                AutoSize = false,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5),
                Font = new Font("Inter", 10, FontStyle.Regular)
                
            };

            Label countLabel = new Label
            {
                Text = balance ? $"{currentUser.Currency} {(decimal)count}": count.ToString(),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Inter", 10, FontStyle.Bold),
                Padding =  new Padding(15, 5, 15, 5),
                ForeColor = Color.White,
                BackColor = color,
                BorderStyle = BorderStyle.None
            };

            countLabel.Location = new Point(badgePanel.Width - countLabel.Width - 5, 7);

            badgePanel.Controls.Add(titleLabel);
            badgePanel.Controls.Add(countLabel);

            container.Controls.Add(badgePanel);
        }

        private void PopulateBadges(string target)
        {
            int yPosition = (target == "balance") ? 130
                        : (target == "debt") ? 230
                        : (target == "stat") ? 330
                        : (target == "debt_balance") ? 430                        
                        : 0; 

            FlowLayoutPanel badgeContainer = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Location = new Point(40, yPosition)
            };

            contentPanel.Controls.Add(badgeContainer);

            if(target == "stat")
            {
                CreateBadge("All", allTransactionCount, badgeContainer, Color.Black);
                CreateBadge("Income", incomeCount, badgeContainer, Color.Green);
                CreateBadge("Expense", expenseCount,badgeContainer,  Color.Orange);
                CreateBadge("Debt", debtCount, badgeContainer, Color.Red);
            }

            if(target == "debt")
            {
                CreateBadge("Cleared", debtCompletedCount, badgeContainer, Color.Green);
                CreateBadge("Remaning", debtPendingCount, badgeContainer, Color.Red);
            }

            if(target == "balance")
            {
                CreateBadge("Balance", (int)totalBalance, badgeContainer, Color.Black, true);
                CreateBadge("Income", (int)incomeBalance, badgeContainer, Color.Green, true);
                CreateBadge("Expense", (int)expenseBalance,badgeContainer,  Color.Orange, true);
                CreateBadge("Debt", (int)debtBalance, badgeContainer, Color.Red, true);
            }

            if(target == "debt_balance")
            {
                CreateBadge("Cleared", (int)totalDebtClearedBalance, badgeContainer, Color.Green, true);
                CreateBadge("Remaning", (int)incomeDebtRemaningBalance, badgeContainer, Color.Red, true);
            }
        }

        private void GetLatestStats()
        {
            allTransactionCount = TransactionService.GetTransactionCount(currentUser.Id, "all_transaction");
            incomeCount = TransactionService.GetTransactionCount(currentUser.Id, "income");
            expenseCount = TransactionService.GetTransactionCount(currentUser.Id, "expense");
            debtCount = TransactionService.GetTransactionCount(currentUser.Id, "debt");

            debtCompletedCount = TransactionService.GetTransactionCount(currentUser.Id, "debt_completed");
            debtPendingCount = TransactionService.GetTransactionCount(currentUser.Id, "debt_pending");

            totalBalance = TransactionService.GetTransactionBalance(currentUser.Id, "balance");
            incomeBalance = TransactionService.GetTransactionBalance(currentUser.Id, "income");
            expenseBalance = TransactionService.GetTransactionBalance(currentUser.Id, "expense");
            debtBalance = TransactionService.GetTransactionBalance(currentUser.Id, "debt");

            totalDebtClearedBalance = TransactionService.GetTransactionBalance(currentUser.Id, "debt_completed");
            incomeDebtRemaningBalance = TransactionService.GetTransactionBalance(currentUser.Id, "debt_pending");
        }
        private void AdjustLayout(object sender, EventArgs e)
        {
            sidebarPanel.Width = (int)(this.ClientSize.Width * 0.25);
            contentPanel.Width = (int)(this.ClientSize.Width * 0.75);
            
            logoPictureBox.Location = new Point(
                (sidebarPanel.Width - logoPictureBox.Width) / 2,
                40
            );

            staticsTitleLabel.Width = contentPanel.Width - 80;
            debtsTitleLabel.Width = contentPanel.Width - 80;
            balanceTitleLabel.Width = contentPanel.Width - 80;

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
