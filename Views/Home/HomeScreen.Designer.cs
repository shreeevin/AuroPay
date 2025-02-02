using AuroPay.Models;
using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;
using AuroPay.Components.Assistants;

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
        private Button statsButton;
        private Button transactionButton;
        private Button profileButton;
        private Button settingButton;
        private Button settlementExpenseButton;
        private Button settlementIncomeButton;
        private Button settlementDebtButton;
        private Button appQuitButton;
        private User currentUser;
        private List<AuroPay.Models.Transaction> allTransactionData;
        private DataGridView dataGridViewTransactions;
        private DataGridViewTextBoxColumn actionColumn;
        private Label pendingDebtLabel;
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

            pendingDebtLabel =  new Label();
            dataGridViewTransactions = new DataGridView();
            actionColumn = new DataGridViewTextBoxColumn();

            logoutButton = new Button();
            homeButton = new Button();
            aboutButton = new Button();
            statsButton = new Button();
            transactionButton = new Button();
            profileButton = new Button();
            settingButton = new Button();

            settlementExpenseButton = new Button();
            settlementIncomeButton = new Button();
            settlementDebtButton = new Button();
            appQuitButton = new Button();

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this, "AuroPay - Dashboard");

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
            settlementIncomeButton.Location = new Point(40, joinedOnLabel.Bottom + 50);
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

            appQuitButton.Size = new Size((int)(contentPanel.Width * 0.20), 40);
            appQuitButton.Location = new Point(settlementDebtButton.Right + 20, joinedOnLabel.Bottom + 50);
            appQuitButton.Text = "Quit App";
            appQuitButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            appQuitButton.BackColor = Color.Black;
            appQuitButton.ForeColor = Color.White;
            appQuitButton.FlatStyle = FlatStyle.Flat;
            appQuitButton.FlatAppearance.BorderSize = 0;
            appQuitButton.Cursor = Cursors.Hand;            
            appQuitButton.Click += (sender, e) => SystemQuiteApp();
            appQuitButton.SizeChanged += (sender, e) => LayoutHelper.CreateRoundedCorners(appQuitButton);

            pendingDebtLabel.AutoSize = true;
            pendingDebtLabel.Text = "Pending Debts";
            pendingDebtLabel.Font = new Font("Inter", 10, FontStyle.Bold);
            pendingDebtLabel.TextAlign = ContentAlignment.MiddleCenter;
            pendingDebtLabel.Visible = false;
            pendingDebtLabel.Location = new Point(40, settlementIncomeButton.Bottom + 50);

            dataGridViewTransactions.AutoSize = true;
            dataGridViewTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransactions.Location = new Point(40, pendingDebtLabel.Bottom + 20); 
            dataGridViewTransactions.Size = new Size(contentPanel.Width - 80, contentPanel.Height - pendingDebtLabel.Bottom - 60);
            dataGridViewTransactions.BackgroundColor = Color.White;
            dataGridViewTransactions.BorderStyle = BorderStyle.None;
            dataGridViewTransactions.Visible = false;

            actionColumn.Name = "Action";
            actionColumn.HeaderText = "Action";

            LayoutHelper.CreateRoundedCorners(settlementIncomeButton, 16);
            LayoutHelper.CreateRoundedCorners(settlementExpenseButton, 16);
            LayoutHelper.CreateRoundedCorners(settlementDebtButton, 16);
            LayoutHelper.CreateRoundedCorners(appQuitButton, 16);            

            contentPanel.Controls.Add(greetingMessageLabel);
            contentPanel.Controls.Add(nameLabel);
            contentPanel.Controls.Add(emailLabel);
            contentPanel.Controls.Add(phoneLabel);
            contentPanel.Controls.Add(walletAndCurrencyLabel);
            contentPanel.Controls.Add(joinedOnLabel);
            contentPanel.Controls.Add(settlementExpenseButton);
            contentPanel.Controls.Add(settlementIncomeButton);
            contentPanel.Controls.Add(settlementDebtButton);    
            contentPanel.Controls.Add(appQuitButton);    

            contentPanel.Controls.Add(pendingDebtLabel);             
            contentPanel.Controls.Add(dataGridViewTransactions);

            this.Controls.Add(sidebarPanel);
            this.Controls.Add(contentPanel);

            this.Resize += new EventHandler(AdjustLayout);
            
            sidebarPanel.ResumeLayout();
            contentPanel.ResumeLayout();

            this.ResumeLayout();
        }

        private void PopulateTransaction(string target = "debt", bool isSearch = false)
        {
            int userId = currentUser.Id;
            
            if(!isSearch)
            {

                if(target == "all"){
                    allTransactionData = TransactionService.GetAllTransactions(userId);
                }
                else
                {
                    allTransactionData = TransactionService.GetTransactionsByScope(userId, target, "pending");
                }
            }

            if (allTransactionData == null || !allTransactionData.Any())
            {
                pendingDebtLabel.Visible = false;
                dataGridViewTransactions.Visible = false;
                
            }
            else
            {
                pendingDebtLabel.Visible = true;
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
    }
}
