using AuroPay.Models;
using AuroPay.Helpers;

using Microsoft.Data.Sqlite;

namespace AuroPay.Services
{
    public static class AuthService
    {
        private static string DatabaseFolderPath => Path.Combine(Directory.GetCurrentDirectory(), "Database");
        private static string DatabaseFilePath => Path.Combine(DatabaseFolderPath, "AuroPayDatabase.db");

        public static User? GetCurrentUser()
        {
            string? username = Session.GetInstance().Username;

            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT id, name, email, phone, username, password, wallet, currency, status, blocked, created_at, updated_at
                        FROM users
                        WHERE username = $username;
                    ";
                    command.Parameters.AddWithValue("$username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                                Email = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Phone = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Username = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Password = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Wallet = reader.GetDecimal(6),
                                Currency = reader.IsDBNull(7) ? "USD" : reader.GetString(7),
                                Status = reader.IsDBNull(8) ? "active" : reader.GetString(8),
                                Blocked = reader.GetBoolean(9),
                                CreatedAt = reader.GetDateTime(10),
                                UpdatedAt = reader.GetDateTime(11)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching user data: {ex.Message}");
            }

            return null;
        }
        public static bool Register(string username, string password, string currency)
        {
            try
            {
                if (IsUsernameDuplicate(username))
                {
                    MessageBox.Show(
                        $"Oops! we have some problem here, seems like user with username ({username}) already exists.", 
                        "Duplicate Username", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                    );

                    return false;
                }

                string hashedPassword = AuthHelper.GenerateHash(password);

                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    command.CommandText = @"
                        INSERT INTO users (username, password, currency)
                        VALUES ($username, $password, $currency);
                    ";

                    command.Parameters.AddWithValue("$username", username);
                    command.Parameters.AddWithValue("$password", hashedPassword);
                    command.Parameters.AddWithValue("$currency", currency);  

                    var result = command.ExecuteNonQuery();
                    if (result > 0){
                        Session.GetInstance().LogIn(username);
                        return true;
                    } else {
                        MessageBox.Show(
                            "Oops! we have some problem here, seems like invalid username or password.", 
                            "Registration Failed", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error
                        );

                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during registration: {ex.Message}");

                return false;
            }
        }

        public static bool Login(string username, string password)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT password, blocked FROM users
                        WHERE username = $username;
                    ";
                    command.Parameters.AddWithValue("$username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = reader.GetString(0);
                            bool isBlocked = reader.GetBoolean(1); 

                            if (isBlocked)
                            {
                                MessageBox.Show(
                                    $"Oops! we have some problem here, seems like username {username} is blocked.",
                                    "Login Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );

                                return false;
                            }

                            if (AuthHelper.CheckPassword(password, hashedPassword))
                            {
                                Session.GetInstance().LogIn(username);
                                return true;
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Oops! we have some problem here, seems like invalid username or password.",
                                    "Login Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );

                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                $"Oops! User not found with username {username}. Please try creating AuroPay account.",
                                "Login Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );

                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}");
                return false;
            }
        }
        public static bool UpdateOnboard(string name, string email, string phone)
        {
            string? username = Session.GetInstance().Username;

            try
            {
                if (IsEmailDuplicate(email, username))
                {
                    MessageBox.Show("The email address is already in use by another account.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (IsPhoneDuplicate(phone, username))
                {
                    MessageBox.Show("The phone number is already in use by another account.", "Duplicate Phone", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE users
                        SET name = $name, email = $email, phone = $phone
                        WHERE username = $username;
                    ";
                    command.Parameters.AddWithValue("$username", username);
                    command.Parameters.AddWithValue("$name", name);
                    command.Parameters.AddWithValue("$email", email);
                    command.Parameters.AddWithValue("$phone", phone);

                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("There was a problem updating your details. Please try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating onboard details: {ex.Message}");
                return false;
            }
        }

        public static bool UpdatePassword(string oldPassword, string newPassword)
        {
            string? username = Session.GetInstance().Username;
            string hashedPassword = AuthHelper.GenerateHash(newPassword);

            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT password
                        FROM users
                        WHERE username = $username;
                    ";
                    command.Parameters.AddWithValue("$username", username);

                    string? oldHashedPassword = null;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            oldHashedPassword = reader.GetString(0);
                        }
                    }

                    if (oldHashedPassword == null || !AuthHelper.CheckPassword(oldPassword, oldHashedPassword))
                    {
                        MessageBox.Show("Oops! We have some issue here. The old password is incorrect.", "Password Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE users
                        SET password = $password
                        WHERE username = $username;
                    ";
                    command.Parameters.AddWithValue("$username", username);
                    command.Parameters.AddWithValue("$password", hashedPassword);

                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("There was a problem updating your details. Please try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating onboard details: {ex.Message}");
                return false;
            }
        }
        public static decimal GetWalletBalance(int userId)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT wallet
                        FROM users
                        WHERE id = $userId;
                    ";
                    command.Parameters.AddWithValue("$userId", userId);

                    decimal? wallet = null;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            wallet = reader.GetDecimal(0);
                        }
                    }

                    if (wallet == null)
                    {
                        MessageBox.Show("User not found. Please check the user ID.", "Wallet Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0; 
                    }

                    return wallet.Value; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking wallet balance: {ex.Message}");
                return 0; 
            }
        }
        public static bool UpdateWalletBalance(int userId, decimal amount, string action)
        {
            try
            {
                if (action != "add" && action != "reduce")
                {
                    MessageBox.Show("Invalid action. Use 'add' or 'reduce'.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (action == "reduce")
                {
                    amount = -Math.Abs(amount); 
                }

                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT wallet
                        FROM users
                        WHERE id = $userId;
                    ";
                    command.Parameters.AddWithValue("$userId", userId);

                    decimal? currentWallet = null;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentWallet = reader.GetDecimal(0);
                        }
                    }

                    if (currentWallet == null)
                    {
                        MessageBox.Show("User not found. Please check the user ID.", "Wallet Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    decimal newWalletBalance = currentWallet.Value + amount;

                    command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE users
                        SET wallet = $newWalletBalance
                        WHERE id = $userId;
                    ";
                    command.Parameters.AddWithValue("$userId", userId);
                    command.Parameters.AddWithValue("$newWalletBalance", newWalletBalance);

                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("There was a problem updating your wallet balance. Please try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating wallet balance: {ex.Message}");
                return false;
            }
        }

        public static bool IsConfigured()
        {
            try
            {
                if (!Session.GetInstance().IsLoggedIn())
                {
                    return false;
                }

                string? loggedInUser = Session.GetInstance().Username;

                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    command.CommandText = @"
                        SELECT name, email, phone FROM users
                        WHERE username = $username;
                    ";

                    command.Parameters.AddWithValue("$username", loggedInUser);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string? name = reader.IsDBNull(0) ? null : reader.GetString(0);
                            string? email = reader.IsDBNull(1) ? null : reader.GetString(1);
                            string? phone = reader.IsDBNull(2) ? null : reader.GetString(2);

                            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
                            {
                                return false;
                            }

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking if user is configured: {ex.Message}");
                return false;
            }
        }
        public static bool IsUsernameDuplicate(string username)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    command.CommandText = @"
                        SELECT COUNT(*) FROM users
                        WHERE username = $username;
                    ";

                    command.Parameters.AddWithValue("$username", username);

                    var count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking if user exists: {ex.Message}");
                return false;
            }
        }
        public static bool IsEmailDuplicate(string email, string? username)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT COUNT(*) FROM users 
                        WHERE email = $email AND username != $username;
                    ";
                    command.Parameters.AddWithValue("$email", email);
                    command.Parameters.AddWithValue("$username", username);

                    var count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking email: {ex.Message}");
                return false;
            }
        }

        public static bool IsPhoneDuplicate(string phone, string? username)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT COUNT(*) FROM users 
                        WHERE phone = $phone AND username != $username;
                    ";
                    command.Parameters.AddWithValue("$phone", phone);
                    command.Parameters.AddWithValue("$username", username);

                    var count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking phone: {ex.Message}");
                return false;
            }
        }
    }
}
