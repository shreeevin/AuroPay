using System.ComponentModel.DataAnnotations;

namespace AuroPay.Helpers
{
    public static class AuthHelper
    {
        public static bool ValidateOnboardInput(string name, string email, string phone)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 4 || name.Length > 30)
            {
                MessageBox.Show(
                    "Name must be between 4 and 30 characters.", 
                    "Input Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );

                return false;
            }

            if (string.IsNullOrEmpty(email) || email.Length > 60 || !ValidateEmail(email))
            {
                MessageBox.Show(
                    "Email must be less than 60 characters.", 
                    "Input Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );

                return false;
            }

            if (string.IsNullOrEmpty(phone) || phone.Length != 10 || !phone.All(char.IsDigit))
            {
                MessageBox.Show(
                    "Phone number must be exactly 10 digits.", 
                    "Input Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );

                return false;
            }

            return true;
        }

        public static bool ValidatePasswordInput(string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || oldPassword.Length < 8 || oldPassword.Length > 12)
            {
                MessageBox.Show(
                    "Old Password must be between 8 and 12 characters. Please try again.", 
                    "Input Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
                
                return false;
            }

            if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 8 || newPassword.Length > 12)
            {
                MessageBox.Show(
                    "New Password must be between 8 and 12 characters. Please try again.", 
                    "Input Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
                
                return false;
            }

            if(newPassword == oldPassword)
            {
                MessageBox.Show(
                    "New Password must be diffrent then old password. Please try again.", 
                    "Input Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
                
                return false;
            }
            return true;
        }

        public static bool ValidateAuthInput(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 4 || username.Length > 12)
            {
                MessageBox.Show(
                    "Username must be between 4 and 12 characters.", 
                    "Input Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );

                return false;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 8 || password.Length > 12)
            {
                MessageBox.Show(
                    "Password must be between 8 and 12 characters.", 
                    "Input Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
                
                return false;
            }

            return true;
        }

        public static string GenerateHash(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public static bool CheckPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
        public static bool ValidateEmail(string email)
        {
            var emailAddress = new EmailAddressAttribute();
            return emailAddress.IsValid(email);
        }
    }
}
