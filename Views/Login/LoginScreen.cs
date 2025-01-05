using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;

namespace AuroPay.Views.Login
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (AuthHelper.ValidateAuthInput(username, password))
            {
                bool isLoginSuccess = LoginController.LoginAccount(username, password);
                
                if(isLoginSuccess){
                    bool isConfigured = AuthService.IsConfigured();
                    if(isConfigured){
                        HomeController.NavigateToHome(this);
                    } else {
                        OnboardController.NavigateToOnboard(this);
                    }
                }
            }

            usernameTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void AdjustLayout(object sender, EventArgs e)
        {
            loginPanel.Width = (int)(this.ClientSize.Width * 0.4);
            
            logoPictureBox.Location = new Point(
                (loginPanel.Width - logoPictureBox.Width) / 2,
                60
            );
            
            descriptionLabel.Location = new Point(
                (loginPanel.Width - descriptionLabel.Width) / 2,
                180
            );

            usernameTextBox.Width = loginPanel.Width - 80;
            passwordTextBox.Width = loginPanel.Width - 80;
            loginButton.Width = loginPanel.Width - 80;
            
            loginButton.Region = System.Drawing.Region.FromHrgn(LayoutHelper.CreateRoundRectRgn(0, 0, loginButton.Width, loginButton.Height, 12, 12));
        }
    }
}
