using AuroPay.Helpers;
using AuroPay.Components;
using AuroPay.Controllers;
using AuroPay.Components.Assistants;

namespace AuroPay.Views.Login
{
    partial class LoginScreen
    {
        private Panel loginPanel;
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

        private void InitializeComponent()
        {
            loginPanel = new Panel();
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

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this, "AuroPay - Login");

            loginPanel.SuspendLayout();

            loginPanel.Dock = DockStyle.Right;
            loginPanel.Width = (int)(this.ClientSize.Width * 0.4);
            loginPanel.BackColor = Color.White;
            loginPanel.Padding = new Padding(40);

            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.Size = new Size(150, 75);
            logoPictureBox.Image = Image.FromFile("Resources/Images/logo.color.png");
            logoPictureBox.Location = new Point(
                (loginPanel.Width - logoPictureBox.Width) / 2,
                60
            );

            descriptionLabel.AutoSize = true;
            descriptionLabel.Text = "Sign in to access your account";
            descriptionLabel.Font = new Font("Inter", 12F);
            descriptionLabel.Location = new Point(
                (loginPanel.Width - descriptionLabel.Width) / 2,
                180
            );            

            usernameLabel.AutoSize = true;
            usernameLabel.Text = "Username";
            usernameLabel.Font = new Font("Inter", 10F);
            usernameLabel.Location = new Point(40, 240);

            usernameTextBox.Size = new Size(loginPanel.Width - 80, 55);
            usernameTextBox.Location = new Point(40, 270);
            usernameTextBox.Font = new Font("Inter", 12F);
            usernameTextBox.BackColor = Color.White;
            usernameTextBox.Height = 55;
            usernameTextBox.CornerRadius = 15;
            usernameTextBox.Padding = new Padding(10, 15, 10, 15);

            passwordLabel.AutoSize = true;
            passwordLabel.Text = "Password";
            passwordLabel.Font = new Font("Inter", 10F);
            passwordLabel.Location = new Point(40, 330);

            passwordTextBox.Size = new Size(loginPanel.Width - 80, 55);
            passwordTextBox.Location = new Point(40, 360);
            passwordTextBox.Font = new Font("Inter", 12F);
            passwordTextBox.UseSystemPasswordChar = true; 
            passwordTextBox.BackColor = Color.White;
            passwordTextBox.Height = 55;
            passwordTextBox.Padding = new Padding(10, 15, 10, 15);

            loginButton.Size = new Size(loginPanel.Width - 80, 55);
            loginButton.Location = new Point(40, 430);
            loginButton.Text = "Login";
            loginButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            loginButton.BackColor = Color.Black;
            loginButton.ForeColor = Color.White;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Cursor = Cursors.Hand;
            loginButton.Region = System.Drawing.Region.FromHrgn(LayoutHelper.CreateRoundRectRgn(0, 0, loginButton.Width, loginButton.Height, 12, 12));  
            loginButton.Click += new EventHandler(LoginButtonClick);

            signUpTextLabel.AutoSize = true;
            signUpTextLabel.Text = "Don't have an account yet? Sign up";
            signUpTextLabel.Font = new Font("Inter", 12F);
            signUpTextLabel.ForeColor = Color.Gray;
            signUpTextLabel.Cursor = Cursors.Hand;
            signUpTextLabel.Location = new Point(
                (loginPanel.Width - signUpTextLabel.Width) / 2, 
                loginButton.Bottom + 30 
            );

            signUpTextLabel.Click += (sender, e) => RegisterController.NavigateToRegister(this);

            bannerPanel.Dock = DockStyle.Fill;
            bannerPanel.BackgroundImage = Image.FromFile("Resources/Images/login.banner.png");
            bannerPanel.BackgroundImageLayout = ImageLayout.Stretch;

            loginPanel.Controls.Add(logoPictureBox);
            loginPanel.Controls.Add(descriptionLabel);
            loginPanel.Controls.Add(usernameLabel);
            loginPanel.Controls.Add(usernameTextBox);
            loginPanel.Controls.Add(passwordLabel);
            loginPanel.Controls.Add(passwordTextBox);
            loginPanel.Controls.Add(loginButton);

            loginPanel.Controls.Add(signUpTextLabel);

            this.Controls.Add(loginPanel);
            this.Controls.Add(bannerPanel);

            this.Resize += new EventHandler(AdjustLayout);

            loginPanel.ResumeLayout();
            this.ResumeLayout();
        }
    }
}