using AuroPay.Models;
using AuroPay.Common;
using AuroPay.Helpers;

namespace AuroPay.Views.Settlement
{
    public partial class SettlementEditScreen : Form, IViewData
    {
        public SettlementEditScreen()
        {
            InitializeComponent();
        }
        public void SetData(object data)
        {
            if (data is Dictionary<string, object> dataDict)
            {
                if (dataDict.TryGetValue("currentUser", out var userValue) && userValue is User extractedUser)
                {
                    this.currentUser = extractedUser;
                }

                if (dataDict.TryGetValue("currentTransaction", out var transactionValue) && transactionValue is Models.Transaction extractedTransaction)
                {
                    currentTransaction = extractedTransaction;
                }

                settlementScope = currentTransaction.Scope;
                
                UpdateSystemSources();
                UpdateSystemTransactionDependancy();
                InitializeTags();
            }
            
            if (data is User currentUser)
            {
                this.currentUser = currentUser;
            }
        }

        private void AddTagButtonClick(object sender, EventArgs e)
        {
            string tag = tagTextBox.Text.Trim();

            if (string.IsNullOrEmpty(tag))
            {
                tagTextBox.Clear();
                MessageBox.Show("Tag cannot be empty. Please enter a valid tag.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Tags.Contains(tag))
            {
                tagTextBox.Clear();
                MessageBox.Show("Tag already exists. Please try a different one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tag.Length > 10)
            {
                tagTextBox.Clear();
                MessageBox.Show("Tag cannot exceed 10 characters. Please enter a shorter tag.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Tags.Count >= 5)
            {
                tagTextBox.Clear();
                MessageBox.Show("You can only add up to 5 tags.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tags.Add(tag);
            allTags.Items.Add(tag);
            tagTextBox.Clear();

            UpdateTagsVisibility();
        }

        private void ClearTags()
        {
            Tags.Clear();
            allTags.Items.Clear();
        }
        private void ClearTagsButtonClick(object sender, EventArgs e)
        {
            ClearTags();
            UpdateTagsVisibility();
        }
        private void UpdateTagsVisibility()
        {
            allTags.Visible = Tags.Count > 0;  
            UpdateSettlementButtonLocation();     
        }
        private void UpdateSettlementButtonLocation()
        {
            updateSettlementButton.Location = allTags.Visible 
                ? new Point(40, allTags.Bottom + 50) 
                : new Point(40, clearTagButton.Bottom + 50); 

            contentPanel.AutoScrollMinSize = new Size(0, updateSettlementButton.Bottom + 50);
        }

        private void ValidateAmountInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void InitializeTags()
        {
            Tags.Clear();
            allTags.Items.Clear();

            foreach (var tag in currentTransaction.Tags)
            {
                if (!string.IsNullOrWhiteSpace(tag))
                {
                    Tags.Add(tag);
                    allTags.Items.Add(tag);
                }
            }

            UpdateTagsVisibility(); 

            if(currentTransaction.Tags.Count > 0)
            {
                updateSettlementButton.Location = new Point(40, allTags.Bottom + 50);
                contentPanel.AutoScrollMinSize = new Size(0, updateSettlementButton.Bottom + 50);
            }
        }
        private void UpdateSystemSources()
        {
            var systemSources = SourceHelper.GetSources(settlementScope);

            sourceComboBox.DataSource = systemSources;
            sourceComboBox.DisplayMember = "Name"; 
            sourceComboBox.ValueMember = "Code";   

            var selectedSource = systemSources.FirstOrDefault(source => source.Code == currentTransaction.Source || source.Name == currentTransaction.Source);

            if (selectedSource != null)
            {
                sourceComboBox.SelectedItem = selectedSource;
            }
            else
            {
                sourceComboBox.SelectedItem = null;  
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

            amountLabel.Width = contentPanel.Width - 80;
            sourceLabel.Width = contentPanel.Width - 80;
            tagLabel.Width = contentPanel.Width - 80;
            noteLabel.Width = contentPanel.Width - 80;
            settlementTitleLabel.Width = contentPanel.Width - 80;

            amountTextBox.Width = contentPanel.Width - 80;
            tagTextBox.Width = contentPanel.Width - 80;
            noteTextBox.Width = contentPanel.Width - 80;
            sourceComboBox.Width = contentPanel.Width - 80;
            allTags.Width = contentPanel.Width - 80;

            homeButton.Size = new Size(sidebarPanel.Width - 40, 40);
            aboutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            statsButton.Size = new Size(sidebarPanel.Width - 40, 40);
            transactionButton.Size = new Size(sidebarPanel.Width - 40, 40);
            profileButton.Size = new Size(sidebarPanel.Width - 40, 40);
            settingButton.Size = new Size(sidebarPanel.Width - 40, 40);
            logoutButton.Size = new Size(sidebarPanel.Width - 40, 40);

            saveTagButton.Size = new Size((int)(contentPanel.Width * 0.2), 40);
            removeTagButton.Size = new Size((int)(contentPanel.Width * 0.2), 40);
            clearTagButton.Size = new Size((int)(contentPanel.Width * 0.2), 40);

            saveTagButton.Location = new Point(40, tagTextBox.Bottom + 20);
            removeTagButton.Location = new Point(saveTagButton.Right + 20, tagTextBox.Bottom + 20);
            clearTagButton.Location = new Point(removeTagButton.Right + 20, tagTextBox.Bottom + 20);

            updateSettlementButton.Size = new Size((int)(contentPanel.Width * 0.2), 40);
        }
    }
}
