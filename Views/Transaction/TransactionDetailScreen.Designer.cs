using AuroPay.Models;
using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;
using AuroPay.Components.Assistants;

namespace AuroPay.Views.Transaction
{
    partial class TransactionDetailScreen
    {
        private Panel sidebarPanel;
        private Panel contentPanel;
        private PictureBox logoPictureBox;
        private Label transactionTitleLabel;
        private Label nameLabel;
        private Label emailLabel;
        private Label phoneLabel;
        private Label transactionIdLabel;
        private Label transactionIdentifierLabel;
        private Label transactionCreatedDateLabel;
        private Label transactionAmountLabel;        
        private Label transactionDetailLabel;
        private Button logoutButton;
        private Button homeButton;
        private Button statsButton;
        private Button aboutButton;
        private Button transactionButton;
        private Button profileButton;
        private Button settingButton;
        private User currentUser;
        private Models.Transaction currentTransaction;
        private Label scopeLabel;
        private Label scopeInfoLabel;
        private Label typeLabel;
        private Label typeInfoLabel;
        private Label statusLabel;
        private Label statusInfoLabel;
        private Label sourceLabel;
        private Label sourceInfoLabel;
        private Label tagLabel;
        private Label tagInfoLabel;
        private Label noteLabel;
        private Label noteInfoLabel;
        private Button editButton; 
        private Button deleteButton;
        private Button debtClearButton;
        private  bool isNoteAvailable;
        private  bool isTagsAvailable;
        private  bool isDebtPending;

        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            contentPanel = new Panel();

            logoPictureBox = new PictureBox();

            transactionTitleLabel = new Label();

            nameLabel =  new Label();
            emailLabel = new Label();
            phoneLabel = new Label();

            transactionIdLabel = new Label(); 
            transactionIdentifierLabel = new Label();
            transactionCreatedDateLabel = new Label();
            transactionAmountLabel = new Label();
            transactionDetailLabel = new Label();

            logoutButton = new Button();
            homeButton = new Button();
            aboutButton = new Button();
            statsButton = new Button();
            transactionButton = new Button();
            profileButton = new Button();
            settingButton = new Button();

            editButton = new Button();
            debtClearButton = new Button();
            deleteButton = new Button();
            
            scopeLabel = new Label();
            typeLabel = new Label();
            statusLabel = new Label();
            sourceLabel = new Label();
            tagLabel = new Label();
            noteLabel = new Label();

            scopeInfoLabel = new Label();
            typeInfoLabel = new Label();
            statusInfoLabel = new Label();
            sourceInfoLabel = new Label();
            tagInfoLabel = new Label();     
            noteInfoLabel = new Label();     

            var systemScopes = TransactionHelper.GetTransactionScopes();
            var systemTypes = TransactionHelper.GetTransactionTypes();
            var systemStatus = TransactionHelper.GetTransactionStatus();

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this, "AuroPay - Transaction Detail");

            sidebarPanel.SuspendLayout();
            contentPanel.SuspendLayout();

            sidebarPanel.AutoScroll = true;
            contentPanel.AutoScroll = true;

            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Width = (int)(this.ClientSize.Width * 0.25);
            sidebarPanel.BackColor = Color.White;
            sidebarPanel.Padding = new Padding(20);

            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.Size = new Size(120, 60);
            logoPictureBox.Image = Image.FromFile("Resources/Images/logo.color.png");
            logoPictureBox.Location = new Point(
                (sidebarPanel.Width - logoPictureBox.Width) / 2,
                40
            );

            homeButton.Size = new Size(sidebarPanel.Width - 40, 40);
            homeButton.Location = new Point(20, 120);
            homeButton.Text = "Home";
            homeButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            homeButton.BackColor = Color.FromArgb(255, 180, 180, 180);
            homeButton.ForeColor = Color.White;
            homeButton.FlatStyle = FlatStyle.Flat;
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.Cursor = Cursors.Hand;            
            homeButton.Image = Image.FromFile("Resources/Images/Icons/home.png");
            homeButton.TextAlign = ContentAlignment.MiddleLeft;
            homeButton.ImageAlign = ContentAlignment.MiddleLeft;
            homeButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            homeButton.Click += (sender, e) => HomeController.NavigateToHome(this);
            homeButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(homeButton);

            statsButton.Size = new Size(sidebarPanel.Width - 40, 40);
            statsButton.Location = new Point(20, homeButton.Bottom + 10);
            statsButton.Text = "Analysis";
            statsButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            statsButton.BackColor = Color.FromArgb(255, 180, 180, 180);
            statsButton.ForeColor = Color.White;
            statsButton.FlatStyle = FlatStyle.Flat;
            statsButton.FlatAppearance.BorderSize = 0;
            statsButton.Cursor = Cursors.Hand;
            statsButton.Image = Image.FromFile("Resources/Images/Icons/analysis.png");
            statsButton.TextAlign = ContentAlignment.MiddleLeft;
            statsButton.ImageAlign = ContentAlignment.MiddleLeft;
            statsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            statsButton.Click += (sender, e) => StatsController.NavigateToStats(this);
            statsButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(statsButton);

            transactionButton.Size = new Size(sidebarPanel.Width - 40, 40);
            transactionButton.Location = new Point(20, statsButton.Bottom + 10);
            transactionButton.Text = "Transactions";
            transactionButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            transactionButton.BackColor = Color.Black;
            transactionButton.ForeColor = Color.White;
            transactionButton.FlatStyle = FlatStyle.Flat;
            transactionButton.FlatAppearance.BorderSize = 0;
            transactionButton.Cursor = Cursors.Hand;
            transactionButton.Image = Image.FromFile("Resources/Images/Icons/doller.png");
            transactionButton.TextAlign = ContentAlignment.MiddleLeft;
            transactionButton.ImageAlign = ContentAlignment.MiddleLeft;
            transactionButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            transactionButton.Click += (sender, e) => TransactionController.NavigateToTransaction(this);
            transactionButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(transactionButton);

            aboutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            aboutButton.Location = new Point(20, transactionButton.Bottom + 10);
            aboutButton.Text = "About";
            aboutButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            aboutButton.BackColor = Color.FromArgb(255, 180, 180, 180);
            aboutButton.ForeColor = Color.White;
            aboutButton.FlatStyle = FlatStyle.Flat;
            aboutButton.FlatAppearance.BorderSize = 0;
            aboutButton.Cursor = Cursors.Hand;
            aboutButton.Image = Image.FromFile("Resources/Images/Icons/info.png");
            aboutButton.TextAlign = ContentAlignment.MiddleLeft;
            aboutButton.ImageAlign = ContentAlignment.MiddleLeft;
            aboutButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            aboutButton.Click += (sender, e) => AboutController.NavigateToAbout(this);
            aboutButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(aboutButton);

            profileButton.Size = new Size(sidebarPanel.Width - 40, 40);
            profileButton.Location = new Point(20, aboutButton.Bottom + 10);
            profileButton.Text = "Profile";
            profileButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            profileButton.BackColor = Color.FromArgb(255, 180, 180, 180);
            profileButton.ForeColor = Color.White;
            profileButton.FlatStyle = FlatStyle.Flat;
            profileButton.FlatAppearance.BorderSize = 0;
            profileButton.Cursor = Cursors.Hand;
            profileButton.Image = Image.FromFile("Resources/Images/Icons/profile.png");
            profileButton.TextAlign = ContentAlignment.MiddleLeft;
            profileButton.ImageAlign = ContentAlignment.MiddleLeft;
            profileButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            profileButton.Click += (sender, e) => ProfileController.NavigateToProfile(this);
            profileButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(profileButton);

            settingButton.Size = new Size(sidebarPanel.Width - 40, 40);
            settingButton.Location = new Point(20, profileButton.Bottom + 10);
            settingButton.Text = "Setting";
            settingButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            settingButton.BackColor = Color.FromArgb(255, 180, 180, 180);
            settingButton.ForeColor = Color.White;
            settingButton.FlatStyle = FlatStyle.Flat;
            settingButton.FlatAppearance.BorderSize = 0;
            settingButton.Cursor = Cursors.Hand;
            settingButton.Image = Image.FromFile("Resources/Images/Icons/setting.png");
            settingButton.TextAlign = ContentAlignment.MiddleLeft;
            settingButton.ImageAlign = ContentAlignment.MiddleLeft;
            settingButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            settingButton.Click += (sender, e) => SettingController.NavigateToSetting(this);
            settingButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(settingButton);

            logoutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            logoutButton.Location = new Point(20, settingButton.Bottom + 10);
            logoutButton.Text = "Log out";
            logoutButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            logoutButton.BackColor = Color.Red;
            logoutButton.ForeColor = Color.White;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.FlatAppearance.BorderSize = 0;
            logoutButton.Cursor = Cursors.Hand;            
            logoutButton.Image = Image.FromFile("Resources/Images/Icons/logout.png");
            logoutButton.TextAlign = ContentAlignment.MiddleLeft;
            logoutButton.ImageAlign = ContentAlignment.MiddleLeft;
            logoutButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            logoutButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(logoutButton);
            logoutButton.Click += (sender, e) => {
                Session.GetInstance().LogOut();
                LoginController.NavigateToLogin(this);
            };

            LayoutHelper.CreateRoundedCorners(homeButton, 16);
            LayoutHelper.CreateRoundedCorners(statsButton, 16);
            LayoutHelper.CreateRoundedCorners(aboutButton, 16);
            LayoutHelper.CreateRoundedCorners(transactionButton, 16);
            LayoutHelper.CreateRoundedCorners(profileButton, 16);
            LayoutHelper.CreateRoundedCorners(settingButton, 16);
            LayoutHelper.CreateRoundedCorners(logoutButton, 16);


            sidebarPanel.Controls.Add(logoPictureBox);
            sidebarPanel.Controls.Add(homeButton);
            sidebarPanel.Controls.Add(statsButton);
            sidebarPanel.Controls.Add(transactionButton);
            sidebarPanel.Controls.Add(aboutButton);
            sidebarPanel.Controls.Add(profileButton);
            sidebarPanel.Controls.Add(settingButton);
            sidebarPanel.Controls.Add(logoutButton);

            contentPanel.Dock = DockStyle.Right;
            contentPanel.Width = (int)(this.ClientSize.Width * 0.75);
            contentPanel.BackColor = Color.White;
            contentPanel.Padding = new Padding(40);

            transactionTitleLabel.AutoSize = true;
            transactionTitleLabel.Font = new Font("Inter", 14F, FontStyle.Regular);
            transactionTitleLabel.Text = "Transaction Detail";
            transactionTitleLabel.Location = new Point(40, 40); 

            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Inter", 12F, FontStyle.Bold);
            nameLabel.Text = "Name";
            nameLabel.Location = new Point(40, 100); 

            emailLabel.AutoSize = true;
            emailLabel.Text = "Email";
            emailLabel.Font = new Font("Inter", 9F);
            emailLabel.Location = new Point(40, 130);

            phoneLabel.AutoSize = true;
            phoneLabel.Text = "Phone";
            phoneLabel.Font = new Font("Inter", 9F);
            phoneLabel.Location = new Point(40, 150);

            transactionIdLabel.AutoSize = true;
            transactionIdLabel.Font = new Font("Inter", 12F, FontStyle.Bold);
            transactionIdLabel.Text = "AURO";
            transactionIdLabel.Location = new Point(40, phoneLabel.Bottom + 50);

            transactionIdentifierLabel.AutoSize = true;
            transactionIdentifierLabel.Font = new Font("Inter", 9F);
            transactionIdentifierLabel.Text = "AURO Identifier";
            transactionIdentifierLabel.Location = new Point(40, transactionIdLabel.Bottom + 5);

            transactionCreatedDateLabel.AutoSize = true;
            transactionCreatedDateLabel.Font = new Font("Inter", 9F);
            transactionCreatedDateLabel.Text = "Created on Jan 1, 2000";
            transactionCreatedDateLabel.Location = new Point(40, transactionIdentifierLabel.Bottom - 5);

            transactionAmountLabel.AutoSize = true;
            transactionAmountLabel.Font = new Font("Inter", 9F, FontStyle.Bold);
            transactionAmountLabel.Text = "GBP 000";
            transactionAmountLabel.Location = new Point(40, transactionCreatedDateLabel.Bottom + 20);


            transactionDetailLabel.AutoSize = true;
            transactionDetailLabel.Font = new Font("Inter", 9F, FontStyle.Bold);
            transactionDetailLabel.Text = "Detail";
            transactionDetailLabel.Location = new Point(40, transactionAmountLabel.Bottom + 40);

            scopeLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            scopeLabel.Text = "Scope";
            scopeLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            scopeLabel.Location = new Point(40, transactionDetailLabel.Bottom + 5); 

            scopeInfoLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            scopeInfoLabel.Text = "Scope Info";
            scopeInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            scopeInfoLabel.Location = new Point(scopeLabel.Right + 10, transactionDetailLabel.Bottom + 5);

            typeLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            typeLabel.Text = "Type";
            typeLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            typeLabel.Location = new Point(40, scopeInfoLabel.Bottom + 5); 

            typeInfoLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            typeInfoLabel.Text = "Type Info";
            typeInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            typeInfoLabel.Location = new Point(typeLabel.Right + 10, scopeInfoLabel.Bottom + 5);

            sourceLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            sourceLabel.Text = "Source";
            sourceLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            sourceLabel.Location = new Point(40, typeInfoLabel.Bottom + 5); 

            sourceInfoLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            sourceInfoLabel.Text = "Source Info";
            sourceInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            sourceInfoLabel.Location = new Point(sourceLabel.Right + 10, typeInfoLabel.Bottom + 5);

            statusLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            statusLabel.Text = "Status";
            statusLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            statusLabel.Location = new Point(40, sourceInfoLabel.Bottom + 5); 

            statusInfoLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            statusInfoLabel.Text = "Status Info";
            statusInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            statusInfoLabel.Location = new Point(statusLabel.Right + 10, sourceInfoLabel.Bottom + 5);
            
            tagLabel.Font = new Font("Inter", 9F, FontStyle.Bold);
            tagLabel.Text = "Tag";
            tagLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            tagLabel.Location = new Point(40, statusInfoLabel.Bottom + 20);
            tagLabel.Visible = false;

            tagInfoLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            tagInfoLabel.Text = "Note Detail";
            tagInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            tagInfoLabel.Location = new Point(40, tagLabel.Bottom + 5);
            tagInfoLabel.Visible = false;

            noteLabel.Font = new Font("Inter", 9F, FontStyle.Bold);
            noteLabel.Text = "Note";
            noteLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            noteLabel.Location = new Point(40, statusInfoLabel.Bottom + 20);
            noteLabel.Visible = false;

            noteInfoLabel.AutoSize = true;
            noteInfoLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            noteInfoLabel.Text = "Note Detail";
            noteInfoLabel.Size = new Size((int)(contentPanel.Width * 0.15), 15);
            noteInfoLabel.Location = new Point(40, noteLabel.Bottom + 5);
            noteInfoLabel.Visible = false;

            editButton.Text = "Edit";
            editButton.Font = new Font("Inter", 12F, FontStyle.Bold);
            editButton.BackColor = Color.Black;
            editButton.ForeColor = Color.White;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.FlatAppearance.BorderSize = 0;
            editButton.Cursor = Cursors.Hand;            
            editButton.Click += (sender, e) => editButtonClicked();
            editButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(editButton);


            debtClearButton.Text = "Clear Debt";
            debtClearButton.Font = new Font("Inter", 12F, FontStyle.Bold);
            debtClearButton.BackColor = Color.Orange;
            debtClearButton.ForeColor = Color.White;
            debtClearButton.FlatStyle = FlatStyle.Flat;
            debtClearButton.FlatAppearance.BorderSize = 0;
            debtClearButton.Cursor = Cursors.Hand;            
            debtClearButton.Click += (sender, e) => debtClearButtonClicked();
            debtClearButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(debtClearButton);
            debtClearButton.Visible = false;

            deleteButton.Text = "Delete";
            deleteButton.Font = new Font("Inter", 12F, FontStyle.Bold);
            deleteButton.BackColor = Color.Red;
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Cursor = Cursors.Hand;            
            deleteButton.Click += (sender, e) => deleteButtonClicked();
            deleteButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(deleteButton);

            LayoutHelper.CreateRoundedCorners(editButton, 16);
            LayoutHelper.CreateRoundedCorners(deleteButton, 16);
            LayoutHelper.CreateRoundedCorners(debtClearButton, 16);
            

            contentPanel.Controls.Add(transactionTitleLabel);

            contentPanel.Controls.Add(nameLabel);
            contentPanel.Controls.Add(emailLabel);
            contentPanel.Controls.Add(phoneLabel);

            contentPanel.Controls.Add(transactionIdLabel);
            contentPanel.Controls.Add(transactionIdentifierLabel); 
            contentPanel.Controls.Add(transactionCreatedDateLabel);   
            contentPanel.Controls.Add(transactionAmountLabel);               
            contentPanel.Controls.Add(transactionDetailLabel);                                            

            contentPanel.Controls.Add(scopeLabel);
            contentPanel.Controls.Add(scopeInfoLabel);

            contentPanel.Controls.Add(typeLabel);
            contentPanel.Controls.Add(typeInfoLabel);

            contentPanel.Controls.Add(sourceLabel);
            contentPanel.Controls.Add(sourceInfoLabel);

            contentPanel.Controls.Add(statusLabel);
            contentPanel.Controls.Add(statusInfoLabel);

            contentPanel.Controls.Add(tagLabel);
            contentPanel.Controls.Add(tagInfoLabel);

            contentPanel.Controls.Add(noteLabel);
            contentPanel.Controls.Add(noteInfoLabel);

            contentPanel.Controls.Add(editButton);
            contentPanel.Controls.Add(deleteButton);            
            contentPanel.Controls.Add(debtClearButton);

            this.Controls.Add(sidebarPanel);
            this.Controls.Add(contentPanel);

            this.Resize += new EventHandler(AdjustLayout);
            
            sidebarPanel.ResumeLayout();
            contentPanel.ResumeLayout();

            this.ResumeLayout();
        }
        
        private void editButtonClicked()
        {
            int userId =  currentUser.Id;
            int  transactionId = currentTransaction.Id;

            SettlementEditController.NavigateToSettlementEdit(this, userId, transactionId);
        }
        private void debtClearButtonClicked()
        {
            var balance = AuthService.GetWalletBalance(currentUser.Id);

            if(currentTransaction.Scope == "debt" && currentTransaction.Amount > balance)
            {
                MessageBox.Show(
                    "The transaction could not be cleared. Due to the insufficent balance for debt clearance.",
                    "Debt Clearance Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            bool isDebtClearanceSuccess = TransactionService.ClearDebt(currentTransaction.Id, currentUser.Id);
            if(isDebtClearanceSuccess)
            {
                MessageBox.Show(
                    "The debt has been cleared successfully.",
                    "Debt Clear",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                TransactionController.NavigateToTransaction(this);
            }
            else
            {
                MessageBox.Show(
                    "The debt could not be cleared. Please try again later.",
                    "Debt Clear Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void deleteButtonClicked()
        {
            var balance = AuthService.GetWalletBalance(currentUser.Id);

            if(currentTransaction.Scope == "income" && currentTransaction.Amount > balance)
            {
                MessageBox.Show(
                    "The transaction could not be deleted. Due to the insufficent balance for expense.",
                    "Deletion Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            bool isDeleteSuccess = TransactionService.DeleteTransaction(currentTransaction.Id, currentUser.Id);
            if(isDeleteSuccess)
            {
                TransactionController.NavigateToTransaction(this);
            }
            else
            {
                MessageBox.Show(
                    "The transaction could not be deleted. Please try again later.",
                    "Deletion Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void SetTransactionLabel()
        {
            transactionIdLabel.Text = $"AURO{currentTransaction.Id}";
            transactionIdentifierLabel.Text = currentTransaction.Tnx;
            transactionCreatedDateLabel.Text = $"Payment on {currentTransaction.UpdatedAt.ToString("MMM dd, yyyy")}";
            
            transactionAmountLabel.Text = $"{currentUser.Currency} {currentTransaction.Amount}";
            transactionAmountLabel.ForeColor = currentTransaction.Type == "debit" ? Color.Green : Color.Red;
            
            scopeInfoLabel.Text = char.ToUpper(currentTransaction.Scope[0]) + currentTransaction.Scope.Substring(1).ToLower();
            
            typeInfoLabel.Text = char.ToUpper(currentTransaction.Type[0]) + currentTransaction.Type.Substring(1).ToLower();
            typeInfoLabel.ForeColor = currentTransaction.Type == "debit" ? Color.Green : Color.Red;
            
            sourceInfoLabel.Text = SourceHelper.GetSourceNameByCode(currentTransaction.Source, currentTransaction.Scope);
            
            statusInfoLabel.Text = char.ToUpper(currentTransaction.Status[0]) + currentTransaction.Status.Substring(1).ToLower();
            statusInfoLabel.ForeColor = currentTransaction.Status == "completed" ? Color.Green : Color.Orange;

            if(currentTransaction.Scope == "debt" && currentTransaction.Status == "pending")
            {
                isDebtPending = true;
            }

            if (currentTransaction.Tags != null && currentTransaction.Tags.Any())
            {
                isTagsAvailable = true;
                tagInfoLabel.Text = string.Join(", ", currentTransaction.Tags);

                tagLabel.Visible = true;
                tagInfoLabel.Visible = true;

            }

            if (!string.IsNullOrEmpty(currentTransaction.Note))
            {
                isNoteAvailable = true;
                noteInfoLabel.Text = currentTransaction.Note;

                noteLabel.Visible = true;
                noteInfoLabel.Visible = true;
            }
        }
    }
}
