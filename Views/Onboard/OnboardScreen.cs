using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;


namespace AuroPay.Views.Onboard
{
    public partial class OnboardScreen : Form
    {
        public OnboardScreen()
        {
            InitializeComponent();
        }
        private void ValidatePhoneNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void saveButtonClick(object sender, EventArgs e)
        {
            string name = fullnameTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;

            if(AuthHelper.ValidateOnboardInput(name, email, phone)){
                if(AuthService.UpdateOnboard(name, email, phone)){
                    HomeController.NavigateToHome(this);
                }
            }

            fullnameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();

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

            fullnameTextBox.Width = registerPanel.Width - 80;
            emailTextBox.Width = registerPanel.Width - 80;
            phoneTextBox.Width = registerPanel.Width - 80;
            saveButton.Width = registerPanel.Width - 80;
            
            saveButton.Region = System.Drawing.Region.FromHrgn(LayoutHelper.CreateRoundRectRgn(0, 0, saveButton.Width, saveButton.Height, 12, 12));
        }
    }    
}
