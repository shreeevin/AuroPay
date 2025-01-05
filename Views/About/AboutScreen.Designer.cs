using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;

namespace AuroPay.Views.About
{
    partial class AboutScreen
    {
        private Panel sidebarPanel;
        private Panel contentPanel;
        private PictureBox logoPictureBox;
        private RichTextBox firstParaLabel;
        private RichTextBox secondParaLabel;
        private RichTextBox thirdParaLabel;
        private Label aboutTitleLabel;
        private Button logoutButton;
        private Button homeButton;
        private Button aboutButton;
        private Button transactionButton;
        private Button profileButton;
        private Button settingButton;
        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            contentPanel = new Panel();

            logoPictureBox = new PictureBox();

            firstParaLabel = new RichTextBox();
            secondParaLabel = new RichTextBox();
            thirdParaLabel = new RichTextBox();

            aboutTitleLabel = new Label();

            logoutButton = new Button();
            homeButton = new Button();
            aboutButton = new Button();
            transactionButton = new Button();
            profileButton = new Button();
            settingButton = new Button();

            this.SuspendLayout();

            sidebarPanel.SuspendLayout();
            contentPanel.SuspendLayout();

            this.MinimumSize = new Size(800, 450);
            this.ClientSize = new Size(800, 450);
            this.WindowState = FormWindowState.Maximized;
            this.Name = "AuroPay - About";
            this.Text = "AuroPay - About";
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

            aboutButton.Size = new Size(sidebarPanel.Width - 40, 40);
            aboutButton.Location = new Point(20, homeButton.Bottom + 10);
            aboutButton.Text = "About";
            aboutButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            aboutButton.BackColor = Color.Black;
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

            aboutTitleLabel.AutoSize = true;
            aboutTitleLabel.Font = new Font("Inter", 14F, FontStyle.Regular);
            aboutTitleLabel.Text = "About AuroPay";
            aboutTitleLabel.Location = new Point(40, 40);

            firstParaLabel.AutoSize = true;
            firstParaLabel.Font = new Font("Inter", 10F);
            firstParaLabel.Location = new Point(40, 100);
            firstParaLabel.ReadOnly = true; 
            firstParaLabel.ForeColor = Color.Black;
            firstParaLabel.BackColor = Color.White;
            firstParaLabel.BorderStyle = BorderStyle.None;  
            firstParaLabel.SelectionAlignment = HorizontalAlignment.Left;
            firstParaLabel.Text = "AuroPay is an innovative personal finance management platform designed to help individuals take control of their financial journey. Whether you’re looking to track your expenses, set up budgets, or monitor your income, AuroPay provides all the tools you need in one place. With an easy-to-use interface and powerful features, AuroPay helps you make informed decisions and maintain financial stability. By categorizing your transactions, AuroPay gives you a clear overview of your spending habits, helping you optimize your finances effectively.";

            secondParaLabel.AutoSize = true;  
            secondParaLabel.ReadOnly = true; 
            secondParaLabel.ForeColor = Color.Black;
            secondParaLabel.BackColor = Color.White;
            secondParaLabel.BorderStyle = BorderStyle.None;  
            secondParaLabel.SelectionAlignment = HorizontalAlignment.Left;
            secondParaLabel.Font = new Font("Inter", 10F);
            secondParaLabel.Location = new Point(40, firstParaLabel.Bottom + 30);
            secondParaLabel.Text = "Tracking your daily expenses can be overwhelming, but AuroPay makes it simple. The platform automatically categorizes your spending and helps you create customized budgets based on your income. AuroPay’s intuitive dashboard provides a clear breakdown of your financial activity, making it easier to visualize your progress. With real-time updates, you’ll always know exactly where your money is going, enabling you to set realistic financial goals and stick to them.";           

            thirdParaLabel.AutoSize = true;
            thirdParaLabel.Font = new Font("Inter", 10F);
            thirdParaLabel.Location = new Point(40, secondParaLabel.Bottom + 30); 
            thirdParaLabel.ReadOnly = true; 
            thirdParaLabel.ForeColor = Color.Black;
            thirdParaLabel.BackColor = Color.White;
            thirdParaLabel.BorderStyle = BorderStyle.None;  
            thirdParaLabel.SelectionAlignment = HorizontalAlignment.Left;           
            thirdParaLabel.Text = "AuroPay prioritizes the security of your financial data. Using state-of-the-art encryption technology, your sensitive information is safe and protected at all times. Whether you're at home or on the go, AuroPay ensures that you have access to your finances whenever you need it. With cloud synchronization, your financial information is always up to date across all devices, so you can monitor your budget, track your expenses, and make smart financial decisions no matter where life takes you.";                                

            contentPanel.Controls.Add(aboutTitleLabel);
            contentPanel.Controls.Add(firstParaLabel);
            contentPanel.Controls.Add(secondParaLabel);
            contentPanel.Controls.Add(thirdParaLabel);

            this.Controls.Add(sidebarPanel);
            this.Controls.Add(contentPanel);

            this.Resize += new EventHandler(AdjustLayout);
            
            sidebarPanel.ResumeLayout();
            contentPanel.ResumeLayout();

            this.ResumeLayout();
        }
    }
}
