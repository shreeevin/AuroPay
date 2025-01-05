using AuroPay.Models;
using AuroPay.Common;
using AuroPay.Helpers;

namespace AuroPay.Views.Settlement
{
    public partial class SettlementScreen : Form, IViewData
    {
        public SettlementScreen()
        {
            InitializeComponent();
        }
        public void SetData(object data)
        {
            if (data is Dictionary<string, object> dataDict)
            {
                if (dataDict.TryGetValue("settlementScope", out var scopeValue))
                {
                    settlementScope = scopeValue?.ToString() ?? "income";
                    settlementTitleLabel.Text = $"Create {char.ToUpper(settlementScope[0])}{settlementScope.Substring(1)} Settlement";
                    createSettlementButton.Text = $"Create {char.ToUpper(settlementScope[0])}{settlementScope.Substring(1)}";

                    UpdateSystemSources();
                }

                if (dataDict.TryGetValue("currentUser", out var userValue) && userValue is User extractedUser)
                {
                    this.currentUser = extractedUser;
                }
            }
            
            if (data is User currentUser)
            {
                this.currentUser = currentUser;
            }
        }

        private void ValidateAmountInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UpdateSystemSources()
        {
            var systemSources = SourceHelper.GetSources(settlementScope);
            sourceComboBox.DataSource = systemSources;   
        }
        private void AdjustLayout(object sender, EventArgs e)
        {
            sidebarPanel.Width = (int)(this.ClientSize.Width * 0.25);
            contentPanel.Width = (int)(this.ClientSize.Width * 0.75);
            
            logoPictureBox.Location = new Point(
                (sidebarPanel.Width - logoPictureBox.Width) / 2,
                40
            );
            

            amountLabel.Width = contentPanel.Width - 80;
            sourceLabel.Width = contentPanel.Width - 80;
            tagLabel.Width = contentPanel.Width - 80;
            noteLabel.Width = contentPanel.Width - 80;
            settlementTitleLabel.Width = contentPanel.Width - 80;

            amountTextBox.Width = contentPanel.Width - 80;
            tagTextBox.Width = contentPanel.Width - 80;
            noteTextBox.Width = contentPanel.Width - 80;
            sourceComboBox.Width = contentPanel.Width - 80;

            homeButton.Size = new Size(sidebarPanel.Width - 40, 40);
            aboutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            transactionButton.Size = new Size(sidebarPanel.Width - 40, 40);
            profileButton.Size = new Size(sidebarPanel.Width - 40, 40);
            settingButton.Size = new Size(sidebarPanel.Width - 40, 40);
            logoutButton.Size = new Size(sidebarPanel.Width - 40, 40);

            createSettlementButton.Size = new Size((int)(contentPanel.Width * 0.2), 40);
        }
    }
}
