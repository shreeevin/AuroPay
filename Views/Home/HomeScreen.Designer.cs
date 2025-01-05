using AuroPay.Models;
using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;

namespace AuroPay.Views.Home
{
    partial class HomeScreen
    {
        private Panel sidebarPanel;
        private Panel contentPanel;
        private PictureBox logoPictureBox;
        private Label nameLabel;
        private Label emailLabel;
        private Label phoneLabel;
        private Label walletAndCurrencyLabel;
        private Label joinedOnLabel;
        private Label greetingMessageLabel;
        private Button logoutButton;
        private Button homeButton;
        private Button aboutButton;
        private Button transactionButton;
        private Button profileButton;
        private Button settingButton;
        private Button settlementExpenseButton;
        private Button settlementIncomeButton;
        private Button settlementDebtButton;
        private User currentUser;

        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            contentPanel = new Panel();

            logoPictureBox = new PictureBox();

            nameLabel = new Label();
            emailLabel = new Label();
            phoneLabel = new Label();
            walletAndCurrencyLabel = new Label();
            joinedOnLabel = new Label();

            greetingMessageLabel = new Label();

            logoutButton = new Button();
            homeButton = new Button();
            aboutButton = new Button();
            transactionButton = new Button();
            profileButton = new Button();
            settingButton = new Button();

            settlementExpenseButton = new Button();
            settlementIncomeButton = new Button();
            settlementDebtButton = new Button();



            this.SuspendLayout();

            sidebarPanel.SuspendLayout();
            contentPanel.SuspendLayout();

            this.MinimumSize = new Size(800, 450);
            this.ClientSize = new Size(800, 450);
            this.WindowState = FormWindowState.Maximized;
            this.Name = "AuroPay - Home";
            this.Text = "AuroPay - Home";
            this.BackColor = Color.White;
            this.Icon = new Icon("Resources/AppIcon/icon.ico");

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
            homeButton.BackColor = Color.Black;
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

            aboutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            aboutButton.Location = new Point(20, homeButton.Bottom + 10);
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

            transactionButton.Size = new Size(sidebarPanel.Width - 40, 40);
            transactionButton.Location = new Point(20, aboutButton.Bottom + 10);
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
            transactionButton.Click += (sender, e) => HomeController.NavigateToHome(this);
            transactionButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(transactionButton);

            profileButton.Size = new Size(sidebarPanel.Width - 40, 40);
            profileButton.Location = new Point(20, transactionButton.Bottom + 10);
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
            LayoutHelper.CreateRoundedCorners(aboutButton, 16);
            LayoutHelper.CreateRoundedCorners(transactionButton, 16);
            LayoutHelper.CreateRoundedCorners(profileButton, 16);
            LayoutHelper.CreateRoundedCorners(settingButton, 16);
            LayoutHelper.CreateRoundedCorners(logoutButton, 16);


            sidebarPanel.Controls.Add(logoPictureBox);
            sidebarPanel.Controls.Add(homeButton);
            sidebarPanel.Controls.Add(aboutButton);
            sidebarPanel.Controls.Add(transactionButton);
            sidebarPanel.Controls.Add(profileButton);
            sidebarPanel.Controls.Add(settingButton);
            sidebarPanel.Controls.Add(logoutButton);

            contentPanel.Dock = DockStyle.Right;
            contentPanel.Width = (int)(this.ClientSize.Width * 0.75);
            contentPanel.BackColor = Color.White;
            contentPanel.Padding = new Padding(40);

            greetingMessageLabel.AutoSize = true;
            greetingMessageLabel.Font = new Font("Inter", 14F, FontStyle.Regular);
            greetingMessageLabel.Text = "Welcome back, User!";
            greetingMessageLabel.Location = new Point(40, 40);

            nameLabel.AutoSize = true;
            nameLabel.Text = "Name";
            nameLabel.Font = new Font("Inter", 12F, FontStyle.Bold);
            nameLabel.Location = new Point(40, 100);

            emailLabel.AutoSize = true;
            emailLabel.Text = "Email";
            emailLabel.Font = new Font("Inter", 9F);
            emailLabel.Location = new Point(40, 130);

            phoneLabel.AutoSize = true;
            phoneLabel.Text = "Phone";
            phoneLabel.Font = new Font("Inter", 9F);
            phoneLabel.Location = new Point(40, 150);

            walletAndCurrencyLabel.AutoSize = true;
            walletAndCurrencyLabel.Text = "Wallet Balance";
            walletAndCurrencyLabel.Font = new Font("Inter", 10F, FontStyle.Bold);
            walletAndCurrencyLabel.Location = new Point(40, 210);

            joinedOnLabel.AutoSize = true;
            joinedOnLabel.Text = "Joined Date";
            joinedOnLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            joinedOnLabel.Location = new Point(40, 240);

            settlementIncomeButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            settlementIncomeButton.Location = new Point(20, joinedOnLabel.Bottom + 50);
            settlementIncomeButton.Text = "Add Saving";
            settlementIncomeButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            settlementIncomeButton.BackColor = Color.Green;
            settlementIncomeButton.ForeColor = Color.White;
            settlementIncomeButton.FlatStyle = FlatStyle.Flat;
            settlementIncomeButton.FlatAppearance.BorderSize = 0;
            settlementIncomeButton.Cursor = Cursors.Hand;            
            settlementIncomeButton.Click += (sender, e) => SettlementController.NavigateToSettlement(this, "income");
            settlementIncomeButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(settlementIncomeButton);

            settlementExpenseButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            settlementExpenseButton.Location = new Point(settlementIncomeButton.Right + 20, joinedOnLabel.Bottom + 50);
            settlementExpenseButton.Text = "Add Expense";
            settlementExpenseButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            settlementExpenseButton.BackColor = Color.Orange;
            settlementExpenseButton.ForeColor = Color.White;
            settlementExpenseButton.FlatStyle = FlatStyle.Flat;
            settlementExpenseButton.FlatAppearance.BorderSize = 0;
            settlementExpenseButton.Cursor = Cursors.Hand;            
            settlementExpenseButton.Click += (sender, e) => SettlementController.NavigateToSettlement(this, "expense");
            settlementExpenseButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(settlementExpenseButton);

            settlementDebtButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            settlementDebtButton.Location = new Point(settlementExpenseButton.Right + 20, joinedOnLabel.Bottom + 50);
            settlementDebtButton.Text = "Add Debt";
            settlementDebtButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            settlementDebtButton.BackColor = Color.Red;
            settlementDebtButton.ForeColor = Color.White;
            settlementDebtButton.FlatStyle = FlatStyle.Flat;
            settlementDebtButton.FlatAppearance.BorderSize = 0;
            settlementDebtButton.Cursor = Cursors.Hand;            
            settlementDebtButton.Click += (sender, e) => SettlementController.NavigateToSettlement(this, "debt");
            settlementDebtButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(settlementDebtButton);

            LayoutHelper.CreateRoundedCorners(settlementIncomeButton, 16);
            LayoutHelper.CreateRoundedCorners(settlementExpenseButton, 16);
            LayoutHelper.CreateRoundedCorners(settlementDebtButton, 16);

            contentPanel.Controls.Add(greetingMessageLabel);
            contentPanel.Controls.Add(nameLabel);
            contentPanel.Controls.Add(emailLabel);
            contentPanel.Controls.Add(phoneLabel);
            contentPanel.Controls.Add(walletAndCurrencyLabel);
            contentPanel.Controls.Add(joinedOnLabel);
            contentPanel.Controls.Add(settlementExpenseButton);
            contentPanel.Controls.Add(settlementIncomeButton);
            contentPanel.Controls.Add(settlementDebtButton);            

            this.Controls.Add(sidebarPanel);
            this.Controls.Add(contentPanel);

            this.Resize += new EventHandler(AdjustLayout);
            
            sidebarPanel.ResumeLayout();
            contentPanel.ResumeLayout();

            this.ResumeLayout();
        }
    }
}
