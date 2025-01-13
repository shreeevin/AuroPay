using AuroPay.Models;
using AuroPay.Common;

namespace AuroPay.Views.Transaction
{
    public partial class TransactionScreen : Form, IViewData
    {
        public TransactionScreen()
        {
            InitializeComponent();
        }

        public void SetData(object data)
        {
            if (data is User currentUser)
            {
                this.currentUser = currentUser;
            }
            
            PopulateTransaction();
        }
        private void ValidateSearchInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
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

            allTransactionTitleLabel.Width = contentPanel.Width - 80;
            filterSearchLabel.Width = contentPanel.Width - 80;

            filterSearchTextBox.Size = new Size(contentPanel.Width - 80, 55);
            filterSearchTextBox.Location = new Point(40, filterSearchLabel.Bottom + 5); 

            noTransactionsPictureBox.Size = new Size((int)(contentPanel.Width * 0.40), (int)(contentPanel.Height * 0.40));
            noTransactionsPictureBox.Location = new Point(
                (contentPanel.Width - noTransactionsPictureBox.Width) / 2,
                filterButton.Bottom + 100
            );

            noTransactionsLabel.Location = new Point(
                (contentPanel.Width - noTransactionsLabel.PreferredWidth) / 2,
                noTransactionsPictureBox.Bottom + 10 
            );

            dataGridViewTransactions.Location = new Point(40, filterButton.Bottom + 20); 
            dataGridViewTransactions.Size = new Size(contentPanel.Width - 80, contentPanel.Height - filterButton.Bottom - 60);

            homeButton.Size = new Size(sidebarPanel.Width - 40, 40);
            statsButton.Size = new Size(sidebarPanel.Width - 40, 40);
            aboutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            transactionButton.Size = new Size(sidebarPanel.Width - 40, 40);
            profileButton.Size = new Size(sidebarPanel.Width - 40, 40);
            settingButton.Size = new Size(sidebarPanel.Width - 40, 40);
            logoutButton.Size = new Size(sidebarPanel.Width - 40, 40);

            filterScopeLabel.Size = new Size((int)(contentPanel.Width * 0.30), 15);
            filterTypeLabel.Size = new Size((int)(contentPanel.Width * 0.30), 15);
            filterStatusLabel.Size = new Size((int)(contentPanel.Width * 0.30), 15);

            filterScopeLabel.Location = new Point(40, filterSearchTextBox.Bottom + 20);
            filterTypeLabel.Location = new Point(filterScopeLabel.Right + 10, filterSearchTextBox.Bottom + 20);
            filterStatusLabel.Location = new Point(filterTypeLabel.Right + 10, filterSearchTextBox.Bottom + 20);

            filterScopeComboBox.Size = new Size((int)(contentPanel.Width * 0.30), 40);
            filterTypeComboBox.Size = new Size((int)(contentPanel.Width * 0.30), 40);
            filterStatusComboBox.Size = new Size((int)(contentPanel.Width * 0.30), 40);

            filterScopeComboBox.Location = new Point(40, filterScopeLabel.Bottom + 5);
            filterTypeComboBox.Location = new Point(filterScopeComboBox.Right + 10, filterTypeLabel.Bottom + 5);
            filterStatusComboBox.Location = new Point(filterTypeComboBox.Right + 10, filterStatusLabel.Bottom + 5);

            filterStartDateTimeLabel.Size = new Size((int)(contentPanel.Width * 0.45), 15);
            filterEndDateTimeLabel.Size = new Size((int)(contentPanel.Width * 0.45), 15);

            filterStartDateTimeLabel.Location = new Point(40, filterStatusComboBox.Bottom + 20); 
            filterEndDateTimeLabel.Location = new Point(filterStartDateTimeLabel.Right + 10, filterStatusComboBox.Bottom + 20); 

            filterStartDateTimePicker.Size = new Size((int)(contentPanel.Width * 0.45), 40);
            filterStartDateTimePicker.Location = new Point(40, filterStartDateTimeLabel.Bottom + 10);

            filterEndDateTimePicker.Size = new Size((int)(contentPanel.Width * 0.45), 40);
            filterEndDateTimePicker.Location = new Point(filterStartDateTimePicker.Right + 10, filterStartDateTimeLabel.Bottom + 10);

            filterButton.Size = new Size((int)(contentPanel.Width * 0.45), 40);
            filterClearButton.Size = new Size((int)(contentPanel.Width * 0.45), 40);

            allTransacrtionButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            incomeTransacrtionButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            expenseTransacrtionButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            debtTransacrtionButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);

            allTransacrtionButton.Location = new Point(40, transactionTitleLabel.Bottom + 20);
            incomeTransacrtionButton.Location = new Point(allTransacrtionButton.Right + 10, transactionTitleLabel.Bottom + 20);
            expenseTransacrtionButton.Location = new Point(incomeTransacrtionButton.Right + 10, transactionTitleLabel.Bottom + 20);
            debtTransacrtionButton.Location = new Point(expenseTransacrtionButton.Right + 10, transactionTitleLabel.Bottom + 20);

            filterButton.Location = new Point(40, filterStartDateTimePicker.Bottom + 20);
            filterClearButton.Location = new Point(filterButton.Right + 10, filterStartDateTimePicker.Bottom + 20);
        }
    }
}
