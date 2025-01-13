using AuroPay.Models;
using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;
using AuroPay.Components;
using AuroPay.Components.Assistants;

namespace AuroPay.Views.Transaction
{
    partial class TransactionScreen
    {
        private Panel sidebarPanel;
        private Panel contentPanel;
        private PictureBox logoPictureBox;
        private Label transactionTitleLabel;
        private Label allTransactionTitleLabel;
        private Label noTransactionsLabel;
        private PictureBox noTransactionsPictureBox;
        private Button logoutButton;
        private Button homeButton;
        private Button statsButton;
        private Button aboutButton;
        private Button transactionButton;
        private Button profileButton;
        private Button settingButton;
        private Button allTransacrtionButton;
        private Button incomeTransacrtionButton;
        private Button expenseTransacrtionButton;
        private Button debtTransacrtionButton;
        private DataGridView dataGridViewTransactions;
        private DataGridViewTextBoxColumn actionColumn;
        private User currentUser;
        private List<AuroPay.Models.Transaction> allTransactionData;
        private Label filterSearchLabel;
        private RoundedTextBox filterSearchTextBox;
        private Label filterTypeLabel;
        private Label filterScopeLabel;
        private Label filterStatusLabel;
        private ComboBox filterTypeComboBox;
        private ComboBox filterScopeComboBox;
        private ComboBox filterStatusComboBox;
        private Label filterStartDateTimeLabel;
        private Label filterEndDateTimeLabel;
        private DateTimePicker filterStartDateTimePicker;
        private DateTimePicker filterEndDateTimePicker;
        private Button filterButton;
        private Button filterClearButton;
        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            contentPanel = new Panel();

            logoPictureBox = new PictureBox();

            transactionTitleLabel = new Label();

            allTransactionTitleLabel =  new Label();

            noTransactionsLabel =  new Label();
            noTransactionsPictureBox = new PictureBox();

            dataGridViewTransactions = new DataGridView();
            actionColumn = new DataGridViewTextBoxColumn();

            logoutButton = new Button();
            homeButton = new Button();
            aboutButton = new Button();
            statsButton = new Button();
            transactionButton = new Button();
            profileButton = new Button();
            settingButton = new Button();

            allTransacrtionButton = new Button();
            incomeTransacrtionButton = new Button();
            expenseTransacrtionButton = new Button();
            debtTransacrtionButton = new Button();

            filterButton = new Button();
            filterClearButton = new Button();
            
            filterSearchLabel = new Label();
            filterSearchTextBox =  new RoundedTextBox();

            filterScopeLabel = new Label();
            filterTypeLabel = new Label();
            filterStatusLabel = new Label();

            filterScopeComboBox = new ComboBox();
            filterTypeComboBox = new ComboBox();
            filterStatusComboBox = new ComboBox();

            filterStartDateTimeLabel = new Label();
            filterEndDateTimeLabel = new Label();

            filterStartDateTimePicker = new DateTimePicker();
            filterEndDateTimePicker = new DateTimePicker();            

            var systemScopes = TransactionHelper.GetTransactionScopes();
            var systemTypes = TransactionHelper.GetTransactionTypes();
            var systemStatus = TransactionHelper.GetTransactionStatus();

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this, "AuroPay - Transaction");

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
            transactionTitleLabel.Text = "Transactions";
            transactionTitleLabel.Location = new Point(40, 40); 

            allTransacrtionButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            allTransacrtionButton.Location = new Point(40, transactionTitleLabel.Bottom + 20);
            allTransacrtionButton.Text = "All";
            allTransacrtionButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            allTransacrtionButton.BackColor = Color.Blue;
            allTransacrtionButton.ForeColor = Color.White;
            allTransacrtionButton.FlatStyle = FlatStyle.Flat;
            allTransacrtionButton.FlatAppearance.BorderSize = 0;
            allTransacrtionButton.Cursor = Cursors.Hand;            
            allTransacrtionButton.Click += (sender, e) => PopulateTransaction("all", false);
            allTransacrtionButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(allTransacrtionButton);

            incomeTransacrtionButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            incomeTransacrtionButton.Location = new Point(allTransacrtionButton.Right + 10, transactionTitleLabel.Bottom + 20);
            incomeTransacrtionButton.Text = "Income";
            incomeTransacrtionButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            incomeTransacrtionButton.BackColor = Color.Green;
            incomeTransacrtionButton.ForeColor = Color.White;
            incomeTransacrtionButton.FlatStyle = FlatStyle.Flat;
            incomeTransacrtionButton.FlatAppearance.BorderSize = 0;
            incomeTransacrtionButton.Cursor = Cursors.Hand;            
            incomeTransacrtionButton.Click += (sender, e) => PopulateTransaction("income", false);
            incomeTransacrtionButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(incomeTransacrtionButton);

            expenseTransacrtionButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            expenseTransacrtionButton.Location = new Point(incomeTransacrtionButton.Right + 10, transactionTitleLabel.Bottom + 20);
            expenseTransacrtionButton.Text = "Expense";
            expenseTransacrtionButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            expenseTransacrtionButton.BackColor = Color.Orange;
            expenseTransacrtionButton.ForeColor = Color.White;
            expenseTransacrtionButton.FlatStyle = FlatStyle.Flat;
            expenseTransacrtionButton.FlatAppearance.BorderSize = 0;
            expenseTransacrtionButton.Cursor = Cursors.Hand;            
            expenseTransacrtionButton.Click += (sender, e) => PopulateTransaction("expense", false);
            expenseTransacrtionButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(expenseTransacrtionButton);

            debtTransacrtionButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            debtTransacrtionButton.Location = new Point(expenseTransacrtionButton.Right + 10, transactionTitleLabel.Bottom + 20);
            debtTransacrtionButton.Text = "Debt";
            debtTransacrtionButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            debtTransacrtionButton.BackColor = Color.Red;
            debtTransacrtionButton.ForeColor = Color.White;
            debtTransacrtionButton.FlatStyle = FlatStyle.Flat;
            debtTransacrtionButton.FlatAppearance.BorderSize = 0;
            debtTransacrtionButton.Cursor = Cursors.Hand;            
            debtTransacrtionButton.Click += (sender, e) => PopulateTransaction("debt", false);
            debtTransacrtionButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(debtTransacrtionButton);

            allTransactionTitleLabel.AutoSize = true;
            allTransactionTitleLabel.Font = new Font("Inter", 12F, FontStyle.Bold);
            allTransactionTitleLabel.Text = "All Transaction";
            allTransactionTitleLabel.Location = new Point(40, expenseTransacrtionButton.Bottom + 20); 

            filterSearchLabel.AutoSize = true;
            filterSearchLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            filterSearchLabel.Text = "Search";
            filterSearchLabel.Location = new Point(40, allTransactionTitleLabel.Bottom + 20); 

            filterSearchTextBox.Size = new Size(contentPanel.Width - 80, 55);
            filterSearchTextBox.Height = 55;
            filterSearchTextBox.BackColor = Color.White;
            filterSearchTextBox.Font = new Font("Inter", 8F, FontStyle.Regular);
            filterSearchTextBox.CornerRadius = 15;
            filterSearchTextBox.Padding = new Padding(10, 15, 10, 15);
            filterSearchTextBox.MaxLength = 32;
            filterSearchTextBox.Location = new Point(40, filterSearchLabel.Bottom + 5); 
            filterSearchTextBox.KeyPress += ValidateSearchInput;

            filterScopeLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            filterScopeLabel.Text = "Scope";
            filterScopeLabel.Size = new Size((int)(contentPanel.Width * 0.30), 15);
            filterScopeLabel.Location = new Point(40, filterSearchTextBox.Bottom + 20); 

            filterTypeLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            filterTypeLabel.Text = "Type";
            filterScopeLabel.Size = new Size((int)(contentPanel.Width * 0.30), 15);
            filterTypeLabel.Location = new Point(filterScopeLabel.Right + 10, filterSearchTextBox.Bottom + 20); 

            filterStatusLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            filterStatusLabel.Text = "Status";
            filterScopeLabel.Size = new Size((int)(contentPanel.Width * 0.30), 15);
            filterStatusLabel.Location = new Point(filterTypeLabel.Right + 10, filterSearchTextBox.Bottom + 20); 

            filterScopeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterScopeComboBox.FormattingEnabled = true;
            filterScopeComboBox.Location = new Point(40, filterScopeLabel.Bottom + 5);
            filterScopeComboBox.Size = new Size((int)(contentPanel.Width * 0.30), 40);
            filterScopeComboBox.DataSource = systemScopes;
            filterScopeComboBox.DisplayMember = "Default"; 
            filterScopeComboBox.ValueMember = "default";    
            filterScopeComboBox.ForeColor = Color.Black;
            filterScopeComboBox.BackColor = Color.White;

            filterTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterTypeComboBox.FormattingEnabled = true;
            filterTypeComboBox.Location = new Point(filterScopeComboBox.Right + 10, filterTypeLabel.Bottom + 5);
            filterTypeComboBox.Size = new Size((int)(contentPanel.Width * 0.30), 40);
            filterTypeComboBox.DataSource = systemTypes;
            filterTypeComboBox.DisplayMember = "Default"; 
            filterTypeComboBox.ValueMember = "default";    
            filterTypeComboBox.ForeColor = Color.Black;
            filterTypeComboBox.BackColor = Color.White;

            filterStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterStatusComboBox.FormattingEnabled = true;
            filterStatusComboBox.Location = new Point(filterTypeComboBox.Right + 10, filterStatusLabel.Bottom + 5);
            filterStatusComboBox.Size = new Size((int)(contentPanel.Width * 0.30), 40);
            filterStatusComboBox.DataSource = systemStatus;
            filterStatusComboBox.DisplayMember = "Default"; 
            filterStatusComboBox.ValueMember = "default";    
            filterStatusComboBox.ForeColor = Color.Black;
            filterStatusComboBox.BackColor = Color.White;
            
            filterStartDateTimeLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            filterStartDateTimeLabel.Text = "Start Date";
            filterStartDateTimeLabel.Size = new Size((int)(contentPanel.Width * 0.45), 15);
            filterStartDateTimeLabel.Location = new Point(40, filterStatusComboBox.Bottom + 20); 

            filterEndDateTimeLabel.Font = new Font("Inter", 8F, FontStyle.Regular);
            filterEndDateTimeLabel.Text = "End Date";
            filterEndDateTimeLabel.Size = new Size((int)(contentPanel.Width * 0.45), 15);
            filterEndDateTimeLabel.Location = new Point(filterStartDateTimeLabel.Right + 10, filterStatusComboBox.Bottom + 20); 

            filterStartDateTimePicker.Size = new Size((int)(contentPanel.Width * 0.45), 40);
            filterStartDateTimePicker.Location = new Point(40, filterStartDateTimeLabel.Bottom + 10);
            filterStartDateTimePicker.Value = DateTime.Now.AddYears(-1);

            filterEndDateTimePicker.Size = new Size((int)(contentPanel.Width * 0.45), 40);
            filterEndDateTimePicker.Location = new Point(filterStartDateTimePicker.Right + 10, filterStartDateTimeLabel.Bottom + 10);

            filterButton.Size = new Size((int)(contentPanel.Width * 0.45), 40);
            filterButton.Location = new Point(40, filterStartDateTimePicker.Bottom + 20);
            filterButton.Text = "Filter";
            filterButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            filterButton.BackColor = Color.Black;
            filterButton.ForeColor = Color.White;
            filterButton.FlatStyle = FlatStyle.Flat;
            filterButton.FlatAppearance.BorderSize = 0;
            filterButton.Cursor = Cursors.Hand;            
            filterButton.Click += (sender, e) => FilterButtonClicked();
            filterButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(filterButton);

            filterClearButton.Size = new Size((int)(contentPanel.Width * 0.45), 40);
            filterClearButton.Location = new Point(filterButton.Right + 10, filterStartDateTimePicker.Bottom + 20);
            filterClearButton.Text = "Reset";
            filterClearButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            filterClearButton.BackColor = Color.Red;
            filterClearButton.ForeColor = Color.White;
            filterClearButton.FlatStyle = FlatStyle.Flat;
            filterClearButton.FlatAppearance.BorderSize = 0;
            filterClearButton.Cursor = Cursors.Hand;            
            filterClearButton.Click += (sender, e) => FilterClearButtonClicked();
            filterClearButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(filterClearButton);

            noTransactionsPictureBox.AutoSize = true;
            noTransactionsPictureBox.Image = Image.FromFile("Resources/Images/error.png");
            noTransactionsPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            noTransactionsPictureBox.Visible = false;
            noTransactionsPictureBox.Size = new Size((int)(contentPanel.Width * 0.40), (int)(contentPanel.Height * 0.40));
            noTransactionsPictureBox.Location = new Point(
                (contentPanel.Width - noTransactionsPictureBox.Width) / 2,
                filterButton.Bottom + 100
            );

            noTransactionsLabel.AutoSize = true;
            noTransactionsLabel.Text = "No Transactions";
            noTransactionsLabel.Font = new Font("Inter", 10, FontStyle.Bold);
            noTransactionsLabel.TextAlign = ContentAlignment.MiddleCenter;
            noTransactionsLabel.Visible = false;
            noTransactionsLabel.Padding = new Padding(0, 0, 0, 50);
            noTransactionsLabel.Location = new Point(
                (contentPanel.Width - noTransactionsLabel.PreferredWidth) / 2,
                noTransactionsPictureBox.Bottom + 10 
            );

            
            dataGridViewTransactions.AutoSize = true;
            dataGridViewTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransactions.Location = new Point(40, filterButton.Bottom + 20); 
            dataGridViewTransactions.Size = new Size(contentPanel.Width - 80, contentPanel.Height - filterButton.Bottom - 60);
            dataGridViewTransactions.BackgroundColor = Color.White;
            dataGridViewTransactions.BorderStyle = BorderStyle.None;

            actionColumn.Name = "Action";
            actionColumn.HeaderText = "Action";

            LayoutHelper.CreateRoundedCorners(allTransacrtionButton, 16);
            LayoutHelper.CreateRoundedCorners(incomeTransacrtionButton, 16);
            LayoutHelper.CreateRoundedCorners(expenseTransacrtionButton, 16);
            LayoutHelper.CreateRoundedCorners(debtTransacrtionButton, 16);

            LayoutHelper.CreateRoundedCorners(filterButton, 16);
            LayoutHelper.CreateRoundedCorners(filterClearButton, 16);

            contentPanel.Controls.Add(transactionTitleLabel);

            contentPanel.Controls.Add(allTransacrtionButton);
            contentPanel.Controls.Add(incomeTransacrtionButton);
            contentPanel.Controls.Add(expenseTransacrtionButton);
            contentPanel.Controls.Add(debtTransacrtionButton);

            contentPanel.Controls.Add(allTransactionTitleLabel);

            contentPanel.Controls.Add(filterSearchLabel);
            contentPanel.Controls.Add(filterSearchTextBox);

            contentPanel.Controls.Add(filterScopeLabel);
            contentPanel.Controls.Add(filterTypeLabel);
            contentPanel.Controls.Add(filterStatusLabel);

            contentPanel.Controls.Add(filterScopeComboBox);
            contentPanel.Controls.Add(filterTypeComboBox);
            contentPanel.Controls.Add(filterStatusComboBox);

            contentPanel.Controls.Add(filterStartDateTimeLabel);
            contentPanel.Controls.Add(filterEndDateTimeLabel);

            contentPanel.Controls.Add(filterStartDateTimePicker);
            contentPanel.Controls.Add(filterEndDateTimePicker);

            contentPanel.Controls.Add(filterButton);
            contentPanel.Controls.Add(filterClearButton);            

            contentPanel.Controls.Add(noTransactionsLabel);
            contentPanel.Controls.Add(noTransactionsPictureBox);

            contentPanel.Controls.Add(dataGridViewTransactions);

            this.Controls.Add(sidebarPanel);
            this.Controls.Add(contentPanel);

            this.Resize += new EventHandler(AdjustLayout);
            
            sidebarPanel.ResumeLayout();
            contentPanel.ResumeLayout();

            this.ResumeLayout();
        }
        private void PopulateTransaction(string target = "all", bool isSearch = false)
        {
            int userId = currentUser.Id;
            
            if(!isSearch)
            {

                if(target == "all"){
                    allTransactionData = TransactionService.GetAllTransactions(userId);
                }
                else
                {
                    allTransactionData = TransactionService.GetTransactionsByScope(userId, target);
                }
            }

            if (allTransactionData == null || !allTransactionData.Any())
            {
                noTransactionsLabel.Visible = true;
                noTransactionsPictureBox.Visible = true;

                dataGridViewTransactions.Visible = false;
                
            }
            else
            {
                noTransactionsLabel.Visible = false;
                noTransactionsPictureBox.Visible = false;

                dataGridViewTransactions.Visible = true;
                
                dataGridViewTransactions.DataSource = allTransactionData;
                dataGridViewTransactions.Refresh();
            }

            dataGridViewTransactions.DataSource = allTransactionData;              
            dataGridViewTransactions.ReadOnly = true;
            dataGridViewTransactions.RowHeadersVisible = false;
            dataGridViewTransactions.MultiSelect = false;

            dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTransactions.DefaultCellStyle.SelectionBackColor = dataGridViewTransactions.DefaultCellStyle.BackColor;
            dataGridViewTransactions.DefaultCellStyle.SelectionForeColor = dataGridViewTransactions.DefaultCellStyle.ForeColor;
            dataGridViewTransactions.RowHeadersDefaultCellStyle.SelectionBackColor = dataGridViewTransactions.RowHeadersDefaultCellStyle.BackColor;
            dataGridViewTransactions.RowHeadersDefaultCellStyle.SelectionForeColor = dataGridViewTransactions.RowHeadersDefaultCellStyle.ForeColor;


            dataGridViewTransactions.AllowUserToResizeColumns = false;
            dataGridViewTransactions.AllowUserToResizeRows = false;

            dataGridViewTransactions.Columns["UserId"].Visible = false; 

            dataGridViewTransactions.Columns["Note"].Visible = false; 
            dataGridViewTransactions.Columns["Fee"].Visible = false; 
            dataGridViewTransactions.Columns["Note"].Visible = false; 
            dataGridViewTransactions.Columns["UpdatedAt"].Visible = false; 

            dataGridViewTransactions.Columns["Tnx"].HeaderText = "Identifier"; 
            dataGridViewTransactions.Columns["Amount"].HeaderText = "Amount 🔽"; 
            dataGridViewTransactions.Columns["CreatedAt"].HeaderText = "Date 🔽";
            dataGridViewTransactions.Columns["UpdatedAt"].HeaderText = "Updated At 🔽"; 


            dataGridViewTransactions.Columns["CreatedAt"].DefaultCellStyle.Format = "dd MMM, yyyy"; 
            dataGridViewTransactions.Columns["UpdatedAt"].DefaultCellStyle.Format = "dd MMM, yyyy";

            dataGridViewTransactions.Columns["Amount"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewTransactions.Columns["CreatedAt"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewTransactions.Columns["UpdatedAt"].SortMode = DataGridViewColumnSortMode.Automatic;

            if (!dataGridViewTransactions.Columns.Contains(actionColumn))
            {
                dataGridViewTransactions.Columns.Add(actionColumn);
            }       

            dataGridViewTransactions.SelectionChanged += (sender, e) =>
            {
                dataGridViewTransactions.ClearSelection();
            };

            dataGridViewTransactions.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridViewTransactions.Columns["Id"].Index)
                {
                    var rowsByScope = dataGridViewTransactions.Rows
                        .OfType<DataGridViewRow>()
                        .Where(row => row.Cells["Amount"].Value != null && row.Cells["Scope"].Value != null)
                        .GroupBy(row => row.Cells["Scope"].Value.ToString())
                        .ToDictionary(
                            group => group.Key,
                            group => group
                                .Select(row => new
                                {
                                    Amount = Convert.ToDecimal(row.Cells["Amount"].Value),
                                    Row = row
                                })
                                .ToList()
                        );

                    string currentScope = dataGridViewTransactions.Rows[e.RowIndex].Cells["Scope"].Value?.ToString();
                    if (currentScope != null && rowsByScope.ContainsKey(currentScope))
                    {
                        var scopeGroup = rowsByScope[currentScope];
                        decimal highest = scopeGroup.Max(x => x.Amount);
                        decimal lowest = scopeGroup.Min(x => x.Amount);
                        decimal currentAmount = Convert.ToDecimal(dataGridViewTransactions.Rows[e.RowIndex].Cells["Amount"].Value);

                        if (currentAmount == highest)
                        {
                            e.CellStyle.BackColor = Color.LightGreen; 
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }
                        else if (currentAmount == lowest)
                        {
                            e.CellStyle.BackColor = Color.LightCoral; 
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }
                    }

                    int id = (int)dataGridViewTransactions.Rows[e.RowIndex].Cells["Id"].Value;
                    e.Value = $"AURO{id}";
                }

                if (e.ColumnIndex == dataGridViewTransactions.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    e.Value = "View";
                }

                if (e.ColumnIndex == dataGridViewTransactions.Columns["Amount"].Index)
                {
                    string type = (string)dataGridViewTransactions.Rows[e.RowIndex].Cells["Type"].Value;

                    e.CellStyle.BackColor = (type.ToLower() == "debit") ? Color.LimeGreen : Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }

                if (e.ColumnIndex == dataGridViewTransactions.Columns["Scope"].Index)
                {
                    bool isDebt = (string)e.Value == "debt";
                    string status = (string)dataGridViewTransactions.Rows[e.RowIndex].Cells["Status"].Value;

                    if(isDebt)
                    {
                        e.CellStyle.BackColor = (status == "completed") ? Color.LimeGreen : Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }

                if (e.ColumnIndex == dataGridViewTransactions.Columns["Status"].Index)
                {
                    string status = (string)dataGridViewTransactions.Rows[e.RowIndex].Cells["Status"].Value;

                    e.CellStyle.BackColor = (status == "completed") ? Color.SeaGreen : Color.Orange;
                    e.CellStyle.ForeColor = Color.White;
                }

                if (e.ColumnIndex == dataGridViewTransactions.Columns["Source"].Index)
                {
                    string sourceCode = (string)dataGridViewTransactions.Rows[e.RowIndex].Cells["Source"].Value;
                    
                    string scope = (string)dataGridViewTransactions.Rows[e.RowIndex].Cells["Scope"].Value;

                    e.Value = SourceHelper.GetSourceNameByCode(sourceCode, scope);
                }

                if (e.ColumnIndex == dataGridViewTransactions.Columns["Status"].Index ||
                    e.ColumnIndex == dataGridViewTransactions.Columns["Type"].Index ||
                    e.ColumnIndex == dataGridViewTransactions.Columns["Scope"].Index)
                {
                    if (e.Value != null && e.Value is string)
                    {
                        string value = (string)e.Value;
                        e.Value = char.ToUpper(value[0]) + value.Substring(1).ToLower();
                    }
                }
            };

            dataGridViewTransactions.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex != dataGridViewTransactions.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    dataGridViewTransactions.ClearSelection();
                    return; 
                }

                int rowIndex = e.RowIndex;

                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == dataGridViewTransactions.Columns["Action"].Index)
                    {
                        dataGridViewTransactions.ClearSelection();
                        var transactionId = dataGridViewTransactions.Rows[e.RowIndex].Cells["Id"].Value;

                        if (transactionId != null && transactionId is int)
                        {
                            int transactionIdInt = (int)transactionId;
                            TransactionDetailController.NavigateToTransactionDetail(this, currentUser.Id, transactionIdInt);
                        }
                        else
                        {
                            MessageBox.Show(
                                "Invalid transaction ID. Please try again.", 
                                "Error", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error
                            );

                            dataGridViewTransactions.ClearSelection();
                        }
                    }
                    else
                    {
                        dataGridViewTransactions.ClearSelection();
                    }
                }
            };

            dataGridViewTransactions.ColumnHeaderMouseClick += (sender, e) =>
            {
                var column = dataGridViewTransactions.Columns[e.ColumnIndex];

                var dataSource = (List<AuroPay.Models.Transaction>)dataGridViewTransactions.DataSource;
                bool ascending = dataGridViewTransactions.Tag as string == "AmountAsc" || dataGridViewTransactions.Tag as string == "CreatedAtAsc" || dataGridViewTransactions.Tag as string == "UpdatedAtAsc";

                if (column.Name == "Amount")
                {
                    if (ascending)
                    {
                        dataGridViewTransactions.DataSource = dataSource.OrderByDescending(t => t.Amount).ToList();
                        dataGridViewTransactions.Tag = "AmountDesc";
                        dataGridViewTransactions.Columns["Amount"].HeaderText = "Amount 🔼";

                    }
                    else
                    {
                        dataGridViewTransactions.DataSource = dataSource.OrderBy(t => t.Amount).ToList();
                        dataGridViewTransactions.Tag = "AmountAsc";
                        dataGridViewTransactions.Columns["Amount"].HeaderText = "Amount 🔽";

                    }
                }
                else if (column.Name == "CreatedAt")
                {
                    if (ascending)
                    {
                        dataGridViewTransactions.DataSource = dataSource.OrderByDescending(t => t.CreatedAt).ToList();
                        dataGridViewTransactions.Tag = "CreatedAtDesc";
                        dataGridViewTransactions.Columns["CreatedAt"].HeaderText = "Date 🔼";

                    }
                    else
                    {
                        dataGridViewTransactions.DataSource = dataSource.OrderBy(t => t.CreatedAt).ToList();
                        dataGridViewTransactions.Tag = "CreatedAtAsc";
                        dataGridViewTransactions.Columns["CreatedAt"].HeaderText = "Date 🔽";
                    }
                }
                else if (column.Name == "UpdatedAt")
                {
                    if (ascending)
                    {
                        dataGridViewTransactions.DataSource = dataSource.OrderByDescending(t => t.UpdatedAt).ToList();
                        dataGridViewTransactions.Tag = "UpdatedAtDesc";
                        dataGridViewTransactions.Columns["UpdatedAt"].HeaderText = "Date 🔼";
                    }
                    else
                    {
                        dataGridViewTransactions.DataSource = dataSource.OrderBy(t => t.UpdatedAt).ToList();
                        dataGridViewTransactions.Tag = "UpdatedAtAsc";
                        dataGridViewTransactions.Columns["UpdatedAt"].HeaderText = "Date 🔽";
                    }
                }
            };
        }
        private void FilterButtonClicked()
        {
            int userId = currentUser.Id;

            string searchKeyword = filterSearchTextBox.Text;

            var selectedType = (Filter)filterTypeComboBox.SelectedItem;
            var selectedScope = (Filter)filterScopeComboBox.SelectedItem;
            var selectedStatus = (Filter)filterStatusComboBox.SelectedItem;

            string scope = selectedScope.Code;
            string type = selectedType.Code;
            string status = selectedStatus.Code;          

            DateTime startDateTime = filterStartDateTimePicker.Value;
            DateTime endDateTime = filterEndDateTimePicker.Value;

            DateTime startDate = new DateTime(startDateTime.Year, startDateTime.Month, startDateTime.Day, 0, 0, 0);
            DateTime endDate = new DateTime(endDateTime.Year, endDateTime.Month, endDateTime.Day, 23, 59, 59);


            if (startDateTime > endDateTime)
            {
                MessageBox.Show(
                    "Start date cannot be after end date.", 
                    "Invalid Date Range", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return; 
            }

            var transactions = TransactionService.GetTransactionsByMixedFilter(
                userId: userId,
                searchKeyword: searchKeyword,
                scope: (scope == "default") ? null : scope,
                status: (status == "default") ? null : status,
                type: (type == "default") ? null : type,
                startDate: startDate.ToString("yyyy-MM-dd HH:mm:ss"),
                endDate: endDate.ToString("yyyy-MM-dd HH:mm:ss")
            );

            allTransactionData = transactions;  
            PopulateTransaction(isSearch: true);          
        }
        private void clearSearchFilter()
        {
            filterSearchTextBox.Clear();

            filterTypeComboBox.DisplayMember = "Default"; 
            filterTypeComboBox.ValueMember = "default";   

            filterScopeComboBox.DisplayMember = "Default"; 
            filterScopeComboBox.ValueMember = "default";   

            filterStatusComboBox.DisplayMember = "Default"; 
            filterStatusComboBox.ValueMember = "default";               

            filterStartDateTimePicker.Value = DateTime.Now.AddYears(-1);
            filterEndDateTimePicker.Value = DateTime.Now;
        }
        private void FilterClearButtonClicked()
        {
            clearSearchFilter();
            PopulateTransaction();
        }
    }
}
