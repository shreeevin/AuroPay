using AuroPay.Helpers;
using AuroPay.Services;
using AuroPay.Controllers;

namespace AuroPay.Views.Setting
{
    public partial class SettingScreen : Form
    {
        public SettingScreen()
        {
            InitializeComponent();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            string oldPassword = oldPasswordTextBox.Text;
            string newPassword = newPasswordTextBox.Text;

            if(AuthHelper.ValidatePasswordInput(oldPassword, newPassword))
            {
                bool isPasswordChangeSuccess = AuthService.UpdatePassword(oldPassword, newPassword);
                if(isPasswordChangeSuccess){
                    MessageBox.Show(
                        "Hurry! Password has been updated successfully.",
                        "Password Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    HomeController.NavigateToHome(this);
                }
            }

            oldPasswordTextBox.Clear();
            newPasswordTextBox.Clear();
        }

        private void AdjustLayout(object sender, EventArgs e)
        {
            settingPanel.Width = (int)(this.ClientSize.Width * 0.4);
            
            logoPictureBox.Location = new Point(
                (settingPanel.Width - logoPictureBox.Width) / 2,
                60
            );
            
            descriptionLabel.Location = new Point(
                (settingPanel.Width - descriptionLabel.Width) / 2,
                180
            );

            oldPasswordTextBox.Width = settingPanel.Width - 80;
            newPasswordTextBox.Width = settingPanel.Width - 80;
            saveButton.Width = settingPanel.Width - 80;
            
            saveButton.Region = System.Drawing.Region.FromHrgn(LayoutHelper.CreateRoundRectRgn(0, 0, saveButton.Width, saveButton.Height, 12, 12));
        }
    }
}
