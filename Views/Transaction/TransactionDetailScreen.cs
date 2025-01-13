using AuroPay.Models;
using AuroPay.Common;

namespace AuroPay.Views.Transaction
{
    public partial class TransactionDetailScreen : Form, IViewData
    {
        public TransactionDetailScreen()
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

                    nameLabel.Text = extractedUser.Name;
                    emailLabel.Text = extractedUser.Email;
                    phoneLabel.Text = extractedUser.Phone;
                }

                if (dataDict.TryGetValue("currentTransaction", out var transactionValue) && transactionValue is Models.Transaction extractedTransaction)
                {
                    currentTransaction = extractedTransaction;
                    
                    SetTransactionLabel();                    
                }
            }
            
            if (data is User currentUser)
            {
                this.currentUser = currentUser;
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

            scopeLabel.Width = contentPanel.Width - 80;

            homeButton.Size = new Size(sidebarPanel.Width - 40, 40);
            statsButton.Size = new Size(sidebarPanel.Width - 40, 40);
            aboutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            transactionButton.Size = new Size(sidebarPanel.Width - 40, 40);
            profileButton.Size = new Size(sidebarPanel.Width - 40, 40);
            settingButton.Size = new Size(sidebarPanel.Width - 40, 40);
            logoutButton.Size = new Size(sidebarPanel.Width - 40, 40);

            scopeLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            scopeInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            
            scopeLabel.Location = new Point(40, transactionDetailLabel.Bottom + 5); 
            scopeInfoLabel.Location = new Point(scopeLabel.Right + 10, transactionDetailLabel.Bottom + 5);

            typeLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            typeInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);

            typeLabel.Location = new Point(40, scopeLabel.Bottom + 5); 
            typeInfoLabel.Location = new Point(typeLabel.Right + 10, scopeLabel.Bottom + 5);

            sourceLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            sourceInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);

            sourceLabel.Location = new Point(40, typeLabel.Bottom + 5); 
            sourceInfoLabel.Location = new Point(sourceLabel.Right + 10, typeLabel.Bottom + 5);

            statusLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            statusInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);

            statusLabel.Location = new Point(40, sourceLabel.Bottom + 5); 
            statusInfoLabel.Location = new Point(statusLabel.Right + 10, sourceLabel.Bottom + 5);
            
            tagLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            tagInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);

            tagLabel.Location = new Point(40, statusInfoLabel.Bottom + 20);
            tagInfoLabel.Location = new Point(40, tagLabel.Bottom + 5);

            noteLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            noteInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);

            noteLabel.Location = new Point(40, statusInfoLabel.Bottom + 20);
            noteInfoLabel.Location = new Point(40, noteLabel.Bottom + 5);

            AdjustNote();
            AdjustActionButtons();

            contentPanel.AutoScrollMinSize = new Size(0, editButton.Bottom + 50);

        }

        private void AdjustNote()
        {
            noteLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            tagInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);

            if(isTagsAvailable)
            {
                noteLabel.Location = new Point(40, tagInfoLabel.Bottom + 20);
                noteInfoLabel.Location = new Point(40, noteLabel.Bottom + 5);
            }
            else
            {
                noteLabel.Location = new Point(40, statusInfoLabel.Bottom + 20);
                noteInfoLabel.Location = new Point(40, noteLabel.Bottom + 5);
            }
        }
        private void AdjustActionButtons()
        {
            editButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            deleteButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            debtClearButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);


            if(isNoteAvailable || isTagsAvailable)            
            {
                if(isNoteAvailable)
                {
                    editButton.Location = new Point(40, noteInfoLabel.Bottom + 50);
                    deleteButton.Location = new Point(editButton.Right + 10, noteInfoLabel.Bottom + 50);
                } 
                else 
                {
                    editButton.Location = new Point(40, tagInfoLabel.Bottom + 50);
                    deleteButton.Location = new Point(editButton.Right + 10, tagInfoLabel.Bottom + 50);
                }
            }
            else
            {
                editButton.Location = new Point(40, statusLabel.Bottom + 50);
                deleteButton.Location = new Point(editButton.Right + 10, statusLabel.Bottom + 50);
            }

            if(isDebtPending)
            {
                debtClearButton.Visible = true;

                if(isNoteAvailable || isTagsAvailable)            
                {
                    if(isNoteAvailable)
                    {
                        editButton.Location = new Point(40, noteInfoLabel.Bottom + 50);
                        debtClearButton.Location = new Point(editButton.Right + 10, noteInfoLabel.Bottom + 50);
                        deleteButton.Location = new Point(debtClearButton.Right + 10, noteInfoLabel.Bottom + 50);
                    } 
                    else 
                    {
                        editButton.Location = new Point(40, tagInfoLabel.Bottom + 50);
                        debtClearButton.Location = new Point(editButton.Right + 10, tagInfoLabel.Bottom + 50);
                        deleteButton.Location = new Point(debtClearButton.Right + 10, tagInfoLabel.Bottom + 50);
                    }
                }
                else
                {
                    editButton.Location = new Point(40, statusLabel.Bottom + 50);
                    debtClearButton.Location = new Point(editButton.Right + 10, statusLabel.Bottom + 50);
                    deleteButton.Location = new Point(debtClearButton.Right + 10, statusLabel.Bottom + 50);
                }                
            }
            else
            {
                debtClearButton.Visible = false;

                if(isNoteAvailable || isTagsAvailable)            
                {
                    if(isNoteAvailable)
                    {
                        editButton.Location = new Point(40, noteInfoLabel.Bottom + 50);
                        debtClearButton.Location = new Point(editButton.Right + 10, noteInfoLabel.Bottom + 50);
                        deleteButton.Location = new Point(editButton.Right + 10, noteInfoLabel.Bottom + 50);
                    } 
                    else 
                    {
                        editButton.Location = new Point(40, tagInfoLabel.Bottom + 50);
                        debtClearButton.Location = new Point(editButton.Right + 10, tagInfoLabel.Bottom + 50);
                        deleteButton.Location = new Point(editButton.Right + 10, tagInfoLabel.Bottom + 50);
                    }
                }
                else
                {
                    editButton.Location = new Point(40, statusLabel.Bottom + 50);
                    debtClearButton.Location = new Point(editButton.Right + 10, statusLabel.Bottom + 50);
                    deleteButton.Location = new Point(editButton.Right + 10, statusLabel.Bottom + 50);
                }  

            }
        }
    }
}
