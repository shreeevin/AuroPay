using AuroPay.Helpers;

namespace AuroPay.Views.Register
{
    public partial class RegisterScreen : Form
    {
        public RegisterScreen()
        {
            InitializeComponent();
        }

        private void AdjustLayout(object sender, EventArgs e)
        {
            registerPanel.Width = (int)(this.ClientSize.Width * 0.4);
            
            logoPictureBox.Location = new Point(
                (registerPanel.Width - logoPictureBox.Width) / 2,
                60
            );
            
            descriptionLabel.Location = new Point(
                (registerPanel.Width - descriptionLabel.Width) / 2,
                180
            );

            usernameTextBox.Width = registerPanel.Width - 80;
            passwordTextBox.Width = registerPanel.Width - 80;
            currencyComboBox.Width = registerPanel.Width - 80;
            loginButton.Width = registerPanel.Width - 80;
            
            loginButton.Region = System.Drawing.Region.FromHrgn(LayoutHelper.CreateRoundRectRgn(0, 0, loginButton.Width, loginButton.Height, 12, 12));
        }
    }
}
