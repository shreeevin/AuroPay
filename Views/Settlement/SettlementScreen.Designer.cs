using AuroPay.Models;
using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;
using AuroPay.Components;
using AuroPay.Components.Assistants;

namespace AuroPay.Views.Settlement
{
    partial class SettlementScreen
    {
        private Panel sidebarPanel;
        private Panel contentPanel;
        private PictureBox logoPictureBox;
        private Label amountLabel;
        private Label sourceLabel;
        private Label tagLabel;
        private Label noteLabel;
        private RoundedTextBox amountTextBox;        
        private ComboBox sourceComboBox; 
        private RoundedTextBox tagTextBox;
        private RoundedTextBox noteTextBox;
        private Label settlementTitleLabel;
        private Button logoutButton;
        private Button homeButton;
        private Button statsButton;
        private Button aboutButton;
        private Button transactionButton;
        private Button profileButton;
        private Button settingButton;
        private Button saveTagButton;
        private Button removeTagButton;
        private Button clearTagButton;
        private Button createSettlementButton;
        private User currentUser;
        private string settlementScope;    
        private ListBox allTags;
        private List<string> Tags = new List<string>();
        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            contentPanel = new Panel();

            logoPictureBox = new PictureBox();

            amountLabel = new Label();
            sourceLabel = new Label();
            tagLabel = new Label();
            noteLabel = new Label();

            sourceComboBox = new ComboBox();
            amountTextBox = new RoundedTextBox();
            tagTextBox = new RoundedTextBox();
            noteTextBox = new RoundedTextBox();

            settlementTitleLabel = new Label();

            logoutButton = new Button();
            homeButton = new Button();
            statsButton = new Button();
            aboutButton = new Button();
            transactionButton = new Button();
            profileButton = new Button();
            settingButton = new Button();

            createSettlementButton = new Button();

            allTags = new ListBox();
            saveTagButton = new Button();
            removeTagButton = new Button();
            clearTagButton = new Button();

            var systemSources = SourceHelper.GetSources("default");

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this, "AuroPay - Settlement");

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

            settlementTitleLabel.AutoSize = true;
            settlementTitleLabel.Font = new Font("Inter", 14F, FontStyle.Regular);
            settlementTitleLabel.Text = "Create Settlement";
            settlementTitleLabel.Location = new Point(40, 40);

            amountLabel.AutoSize = true;
            amountLabel.Text = "Amount";
            amountLabel.Font = new Font("Inter", 12F, FontStyle.Regular);
            amountLabel.Location = new Point(40, 100);

            amountTextBox.Size = new Size(contentPanel.Width - 80, 55);
            amountTextBox.Height = 55;
            amountTextBox.BackColor = Color.White;
            amountTextBox.Location = new Point(40, amountLabel.Bottom + 20);
            amountTextBox.Font = new Font("Inter", 12F, FontStyle.Regular);
            amountTextBox.CornerRadius = 15;
            amountTextBox.Padding = new Padding(10, 15, 10, 15);
            amountTextBox.MaxLength = 10;
            amountTextBox.KeyPress += ValidateAmountInput;


            sourceLabel.AutoSize = true;
            sourceLabel.Text = "Source";
            sourceLabel.Font = new Font("Inter", 12F, FontStyle.Regular);
            sourceLabel.Location = new Point(40, amountTextBox.Bottom + 20);

            sourceComboBox.Size = new Size(contentPanel.Width - 80, 55);
            sourceComboBox.Location = new Point(40, sourceLabel.Bottom +20);
            sourceComboBox.Font = new Font("Inter", 12F);
            sourceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sourceComboBox.DataSource = systemSources;
            sourceComboBox.ForeColor = Color.Black;
            sourceComboBox.BackColor = Color.White;

            noteLabel.AutoSize = true;
            noteLabel.Text = "Note";
            noteLabel.Font = new Font("Inter", 12F, FontStyle.Regular);
            noteLabel.Location = new Point(40, sourceComboBox.Bottom + 20);

            noteTextBox.Size = new Size(contentPanel.Width - 80, 55);
            noteTextBox.Height = 55;
            noteTextBox.BackColor = Color.White;
            noteTextBox.Location = new Point(40, noteLabel.Bottom + 20);
            noteTextBox.Font = new Font("Inter", 12F, FontStyle.Regular);
            noteTextBox.CornerRadius = 15;
            tagTextBox.MaxLength = 60;
            noteTextBox.Padding = new Padding(10, 15, 10, 15);

            tagLabel.AutoSize = true;
            tagLabel.Text = "Tags";
            tagLabel.Font = new Font("Inter", 12F, FontStyle.Regular);
            tagLabel.Location = new Point(40, noteTextBox.Bottom + 20);

            tagTextBox.Size = new Size(contentPanel.Width - 80, 55);
            tagTextBox.Height = 55;
            tagTextBox.BackColor = Color.White;
            tagTextBox.Location = new Point(40, tagLabel.Bottom + 20);
            tagTextBox.Font = new Font("Inter", 12F, FontStyle.Regular);
            tagTextBox.CornerRadius = 15;
            tagTextBox.Padding = new Padding(10, 15, 10, 15);
            tagTextBox.MaxLength = 10;

            saveTagButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            saveTagButton.Location = new Point(40, tagTextBox.Bottom + 20);
            saveTagButton.Text = "Add Tag";
            saveTagButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            saveTagButton.BackColor = Color.Green;
            saveTagButton.ForeColor = Color.White;
            saveTagButton.FlatStyle = FlatStyle.Flat;
            saveTagButton.FlatAppearance.BorderSize = 0;
            saveTagButton.Cursor = Cursors.Hand; 
            saveTagButton.Click += new EventHandler(AddTagButtonClick);
            saveTagButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(saveTagButton);

            removeTagButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            removeTagButton.Location = new Point(saveTagButton.Right + 20, tagTextBox.Bottom + 20);
            removeTagButton.Text = "Remove Tag";
            removeTagButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            removeTagButton.BackColor = Color.Red;
            removeTagButton.ForeColor = Color.White;
            removeTagButton.FlatStyle = FlatStyle.Flat;
            removeTagButton.FlatAppearance.BorderSize = 0;
            removeTagButton.Cursor = Cursors.Hand; 
            removeTagButton.Click += new EventHandler(RemoveTagButtonClick);
            removeTagButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(removeTagButton);

            clearTagButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            clearTagButton.Location = new Point(removeTagButton.Right + 20, tagTextBox.Bottom + 20);
            clearTagButton.Text = "Clear Tags";
            clearTagButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            clearTagButton.BackColor = Color.Orange;
            clearTagButton.ForeColor = Color.White;
            clearTagButton.FlatStyle = FlatStyle.Flat;
            clearTagButton.FlatAppearance.BorderSize = 0;
            clearTagButton.Cursor = Cursors.Hand; 
            clearTagButton.Click += new EventHandler(ClearTagsButtonClick);
            clearTagButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(clearTagButton);

            allTags.FormattingEnabled = true;
            allTags.ItemHeight = 15;
            allTags.Location = new Point(40, clearTagButton.Bottom + 20);
            allTags.Size = new Size(contentPanel.Width, 90);
            allTags.BorderStyle = BorderStyle.Fixed3D;
            allTags.Visible = false;

            createSettlementButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            createSettlementButton.Location = new Point(40, clearTagButton.Bottom + 50);
            createSettlementButton.Text = "Create Settlement";
            createSettlementButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            createSettlementButton.BackColor = Color.Black;
            createSettlementButton.ForeColor = Color.White;
            createSettlementButton.FlatStyle = FlatStyle.Flat;
            createSettlementButton.FlatAppearance.BorderSize = 0;
            createSettlementButton.Cursor = Cursors.Hand;  
            createSettlementButton.Click += (sender, e) => CreateSettlementButtonClick();
            createSettlementButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(createSettlementButton);

            LayoutHelper.CreateRoundedCorners(saveTagButton, 16);
            LayoutHelper.CreateRoundedCorners(removeTagButton, 16);
            LayoutHelper.CreateRoundedCorners(clearTagButton, 16);
            LayoutHelper.CreateRoundedCorners(createSettlementButton, 16);

            contentPanel.Controls.Add(settlementTitleLabel);
            contentPanel.Controls.Add(amountLabel);
            contentPanel.Controls.Add(amountTextBox);
            contentPanel.Controls.Add(sourceLabel);
            contentPanel.Controls.Add(sourceComboBox);            
            contentPanel.Controls.Add(tagLabel);
            contentPanel.Controls.Add(tagTextBox);

            contentPanel.Controls.Add(saveTagButton);         
            contentPanel.Controls.Add(removeTagButton);         
            contentPanel.Controls.Add(clearTagButton);  
            contentPanel.Controls.Add(allTags);  

            contentPanel.Controls.Add(noteLabel);
            contentPanel.Controls.Add(noteTextBox);            
            contentPanel.Controls.Add(createSettlementButton);
            
            this.Controls.Add(sidebarPanel);
            this.Controls.Add(contentPanel);

            this.Resize += new EventHandler(AdjustLayout);
            
            sidebarPanel.ResumeLayout();
            contentPanel.ResumeLayout();

            this.ResumeLayout();
        }
        private void RemoveTagButtonClick(object sender, EventArgs e)
        {
            if (allTags.SelectedItem != null)
            {
                string selectedTag = allTags.SelectedItem.ToString();
                Tags.Remove(selectedTag);
                allTags.Items.Remove(selectedTag);
                UpdateTagsVisibility();
            }
            else
            {
                MessageBox.Show("Please select a tag to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CreateSettlementButtonClick()
        {
            var selectedSource = (Source)sourceComboBox.SelectedItem;
            string source = selectedSource.Code;

            bool isValidInput = TransactionHelper.ValidateSettlementInput(amountTextBox.Text, noteTextBox.Text);

            if(!isValidInput)
            {
                return;
            }

            int UserId = currentUser.Id;
            string Scope = settlementScope;
            string Source = source;

            string Tnx = Guid.NewGuid().ToString();
            string Type = (settlementScope == "income") ? "debit" : "credit";
            
            decimal Fee = 0;
            decimal Amount = 0;
            decimal.TryParse(amountTextBox.Text, out Amount);

            string Note = noteTextBox.Text;            
            string Status = (settlementScope == "debt") ? "pending" : "completed";

            bool isTransactionCreated = TransactionService.CreateTransaction(
                UserId,
                Tnx,
                Type,
                Scope,
                Source,
                Tags,
                Note,
                Fee,
                Amount,
                Status
            );

            if(isTransactionCreated)
            {
                MessageBox.Show(
                    "Transaction created successfully! Your payment has been processed.",
                    "Transaction Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                amountTextBox.Clear();
                noteTextBox.Clear();

                ClearTags();
                UpdateTagsVisibility();
            }
        }
    }
}
