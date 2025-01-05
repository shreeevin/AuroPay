using AuroPay.Models;
using AuroPay.Common; 
using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;

namespace AuroPay.Views.Profile
{
    public partial class ProfileScreen : Form, IViewData
    {
        public ProfileScreen()
        {
            InitializeComponent();
        }

        public void SetData(object data)
        {
            if (data is User currentUser)
            {
                this.currentUser = currentUser;

                fullnameTextBox.Text = $"{currentUser.Name}";
                emailTextBox.Text = $"{currentUser.Email}";
                phoneTextBox.Text = $"{currentUser.Phone}";                
            }
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
                    MessageBox.Show(
                        "Hurry! User info has been updated successfully.",
                        "Profile Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    
                    HomeController.NavigateToHome(this);
                }
            }

            fullnameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();

        }
        private void AdjustLayout(object sender, EventArgs e)
        {
            profilePanel.Width = (int)(this.ClientSize.Width * 0.4);
            
            logoPictureBox.Location = new Point(
                (profilePanel.Width - logoPictureBox.Width) / 2,
                60
            );
            
            descriptionLabel.Location = new Point(
                (profilePanel.Width - descriptionLabel.Width) / 2,
                180
            );

            fullnameTextBox.Width = profilePanel.Width - 80;
            emailTextBox.Width = profilePanel.Width - 80;
            phoneTextBox.Width = profilePanel.Width - 80;
            saveButton.Width = profilePanel.Width - 80;
            
            saveButton.Region = System.Drawing.Region.FromHrgn(LayoutHelper.CreateRoundRectRgn(0, 0, saveButton.Width, saveButton.Height, 12, 12));
        }
    }    
}
