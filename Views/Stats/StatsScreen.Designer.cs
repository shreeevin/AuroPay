using AuroPay.Models;
using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;
using AuroPay.Components.Assistants;

namespace AuroPay.Views.Stats
{
    partial class StatsScreen
    {
        private Panel sidebarPanel;
        private Panel contentPanel;
        private PictureBox logoPictureBox;
        private Label transactionTitleLabel;
        private Label staticsTitleLabel;
        private Label debtsTitleLabel;
        private Label balanceTitleLabel;
        private Label debtStatusTitleLabel;
        private Label dataVisualizationTitleLabel;
        private Button logoutButton;
        private Button homeButton;
        private Button aboutButton;
        private Button statsButton;
        private Button transactionButton;
        private Button profileButton;
        private Button settingButton;
        private User currentUser;
        private int allTransactionCount = 0;
        private int incomeCount = 0;
        private int expenseCount = 0;
        private int debtCount = 0;
        private int debtCompletedCount = 0;
        private int debtPendingCount = 0;
        private decimal incomeBalance = 0;
        private decimal expenseBalance = 0;
        private decimal debtBalance = 0;
        private decimal totalBalance = 0;
        private decimal totalDebtClearedBalance = 0;
        private decimal incomeDebtRemaningBalance = 0;


        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            contentPanel = new Panel();

            logoPictureBox = new PictureBox();

            transactionTitleLabel = new Label();

            staticsTitleLabel = new Label();
            debtsTitleLabel = new Label();
            balanceTitleLabel =  new Label();
            debtStatusTitleLabel =  new Label();
            dataVisualizationTitleLabel = new Label();

            logoutButton = new Button();
            homeButton = new Button();
            aboutButton = new Button();
            statsButton = new Button();
            transactionButton = new Button();
            profileButton = new Button();
            settingButton = new Button();

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this, "AuroPay - Analysis");

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
            statsButton.BackColor = Color.Black;
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
            transactionButton.BackColor = Color.FromArgb(255, 180, 180, 180);
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
            LayoutHelper.CreateRoundedCorners(transactionButton, 16);
            LayoutHelper.CreateRoundedCorners(aboutButton, 16);
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
            transactionTitleLabel.Text = "Transactions";
            transactionTitleLabel.Location = new Point(40, 40);

            balanceTitleLabel.AutoSize = true;
            balanceTitleLabel.Font = new Font("Inter", 12F, FontStyle.Bold);
            balanceTitleLabel.Text = "Balance";
            balanceTitleLabel.Location = new Point(40, 100); 
            
            debtsTitleLabel.AutoSize = true;
            debtsTitleLabel.Font = new Font("Inter", 12F, FontStyle.Bold);
            debtsTitleLabel.Text = "Debts";
            debtsTitleLabel.Location = new Point(40, 200);      

            staticsTitleLabel.AutoSize = true;
            staticsTitleLabel.Font = new Font("Inter", 12F, FontStyle.Bold);
            staticsTitleLabel.Text = "Transaction Count";
            staticsTitleLabel.Location = new Point(40, 300);

            debtStatusTitleLabel.AutoSize = true;
            debtStatusTitleLabel.Font = new Font("Inter", 12F, FontStyle.Bold);
            debtStatusTitleLabel.Text = "Debts Balance";
            debtStatusTitleLabel.Location = new Point(40, 400); 

            dataVisualizationTitleLabel.AutoSize = true;
            dataVisualizationTitleLabel.Font = new Font("Inter", 12F, FontStyle.Bold);
            dataVisualizationTitleLabel.Text = "Visualization";
            dataVisualizationTitleLabel.Location = new Point(40, 500);
            dataVisualizationTitleLabel.Visible = false;


            contentPanel.Controls.Add(transactionTitleLabel);
            contentPanel.Controls.Add(balanceTitleLabel);
            contentPanel.Controls.Add(staticsTitleLabel);
            contentPanel.Controls.Add(debtsTitleLabel);
            contentPanel.Controls.Add(debtStatusTitleLabel);            
            contentPanel.Controls.Add(dataVisualizationTitleLabel);            

            this.Controls.Add(sidebarPanel);
            this.Controls.Add(contentPanel);

            this.Resize += new EventHandler(AdjustLayout);
            
            sidebarPanel.ResumeLayout();
            contentPanel.ResumeLayout();

            this.ResumeLayout();
        }        
    }
}
