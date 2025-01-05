using AuroPay.Helpers;
using AuroPay.Controllers;

using AuroPay.Models;
using AuroPay.Components;

namespace AuroPay.Views.Register
{
    partial class RegisterScreen
    {
        private Panel registerPanel;
        private Panel bannerPanel;
        private PictureBox logoPictureBox;
        private Label descriptionLabel;        
        private Label signUpTextLabel;
        private Label signUpLinkLabel;
        private RoundedTextBox usernameTextBox;  
        private RoundedTextBox passwordTextBox;  
        private Button loginButton;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label currencyLabel;
        private ComboBox currencyComboBox;
        private void InitializeComponent()
        {
            registerPanel = new Panel();
            bannerPanel = new Panel();
            
            logoPictureBox = new PictureBox();
            descriptionLabel = new Label();
            
            usernameTextBox = new RoundedTextBox(); 
            passwordTextBox = new RoundedTextBox(); 

            loginButton = new Button();
            
            usernameLabel = new Label();
            passwordLabel = new Label();

            signUpTextLabel = new Label();
            signUpLinkLabel = new LinkLabel();

            currencyLabel = new Label();
            currencyComboBox = new ComboBox();

            var systemCurrencies = CurrencyHelper.GetCurrencies();

            this.SuspendLayout();
            registerPanel.SuspendLayout();

            this.MinimumSize = new Size(800, 450);
            this.ClientSize = new Size(800, 450);
            this.WindowState = FormWindowState.Maximized;
            this.Name = "AuroPay - Register";
            this.Text = "AuroPay - Register";
            this.BackColor = Color.White;
            this.Icon = new Icon("Resources/AppIcon/icon.ico");

            registerPanel.Dock = DockStyle.Right;
            registerPanel.Width = (int)(this.ClientSize.Width * 0.4);
            registerPanel.BackColor = Color.White;
            registerPanel.Padding = new Padding(40);

            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.Size = new Size(150, 75);
            logoPictureBox.Image = Image.FromFile("Resources/Images/logo.color.png");
            logoPictureBox.Location = new Point(
                (registerPanel.Width - logoPictureBox.Width) / 2,
                60
            );

            descriptionLabel.AutoSize = true;
            descriptionLabel.Text = "Create your account on AuroPay";
            descriptionLabel.Font = new Font("Inter", 12F);
            descriptionLabel.Location = new Point(
                (registerPanel.Width - descriptionLabel.Width) / 2,
                180
            );            

            usernameLabel.AutoSize = true;
            usernameLabel.Text = "Username";
            usernameLabel.Font = new Font("Inter", 10F);
            usernameLabel.Location = new Point(40, 240);

            usernameTextBox.Size = new Size(registerPanel.Width - 80, 55);
            usernameTextBox.Location = new Point(40, 270);
            usernameTextBox.Font = new Font("Inter", 12F);
            usernameTextBox.BackColor = Color.White;
            usernameTextBox.Height = 55;
            usernameTextBox.Padding = new Padding(10, 15, 10, 15);

            passwordLabel.AutoSize = true;
            passwordLabel.Text = "Password";
            passwordLabel.Font = new Font("Inter", 10F);
            passwordLabel.Location = new Point(40, 330);

            passwordTextBox.Size = new Size(registerPanel.Width - 80, 55);
            passwordTextBox.Location = new Point(40, 360);
            passwordTextBox.Font = new Font("Inter", 12F);
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.BackColor = Color.White;
            passwordTextBox.Height = 55;
            passwordTextBox.Padding = new Padding(10, 15, 10, 15);

            currencyLabel.AutoSize = true;
            currencyLabel.Text = "Currency";
            currencyLabel.Font = new Font("Inter", 10F);
            currencyLabel.Location = new Point(40, 430);

            currencyComboBox.Size = new Size(registerPanel.Width - 80, 55);
            currencyComboBox.Location = new Point(40, 460);
            currencyComboBox.Font = new Font("Inter", 12F);
            currencyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            currencyComboBox.DataSource = systemCurrencies;
            currencyComboBox.DisplayMember = "United States Dollar"; 
            currencyComboBox.ValueMember = "USD";    
            currencyComboBox.ForeColor = Color.Black;
            currencyComboBox.BackColor = Color.White;

            loginButton.Size = new Size(registerPanel.Width - 80, 55);
            loginButton.Location = new Point(40, currencyComboBox.Bottom + 30);
            loginButton.Text = "Sign up";
            loginButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            loginButton.BackColor = Color.Black;
            loginButton.ForeColor = Color.White;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Cursor = Cursors.Hand;
            loginButton.Region = System.Drawing.Region.FromHrgn(LayoutHelper.CreateRoundRectRgn(0, 0, loginButton.Width, loginButton.Height, 12, 12));  
            loginButton.Click += new EventHandler(RegisterButtonClick);

            signUpTextLabel.AutoSize = true;
            signUpTextLabel.Text = "Already have an account? Sign in";
            signUpTextLabel.Font = new Font("Inter", 12F);
            signUpTextLabel.ForeColor = Color.Gray;
            signUpTextLabel.Cursor = Cursors.Hand;
            signUpTextLabel.Location = new Point(
                (registerPanel.Width - signUpTextLabel.Width) / 2, 
                loginButton.Bottom + 30 
            );

            signUpTextLabel.Click += (sender, e) => LoginController.NavigateToLogin(this);

            bannerPanel.Dock = DockStyle.Fill;
            bannerPanel.BackgroundImage = Image.FromFile("Resources/Images/register.banner.png");
            bannerPanel.BackgroundImageLayout = ImageLayout.Stretch;

            registerPanel.Controls.Add(logoPictureBox);
            registerPanel.Controls.Add(descriptionLabel);
            registerPanel.Controls.Add(usernameLabel);
            registerPanel.Controls.Add(usernameTextBox);
            registerPanel.Controls.Add(passwordLabel);
            registerPanel.Controls.Add(passwordTextBox);            
            registerPanel.Controls.Add(currencyLabel);
            registerPanel.Controls.Add(currencyComboBox);   
            registerPanel.Controls.Add(loginButton);
            registerPanel.Controls.Add(signUpTextLabel);

            this.Controls.Add(registerPanel);
            this.Controls.Add(bannerPanel);

            this.Resize += new EventHandler(AdjustLayout);

            registerPanel.ResumeLayout();
            this.ResumeLayout();
        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            var selectedCurrency = (Currency)currencyComboBox.SelectedItem;
            string currency = selectedCurrency.Code;

            if (AuthHelper.ValidateAuthInput(username, password))
            {                
                bool isRegisterSuccess = RegisterController.CreateAccount(username, password, currency);

                if(isRegisterSuccess){
                    OnboardController.NavigateToOnboard(this);
                } 
            }

            usernameTextBox.Clear();
            passwordTextBox.Clear();
        }
    }
}