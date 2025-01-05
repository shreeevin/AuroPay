using AuroPay.Models;
using AuroPay.Helpers;

using Newtonsoft.Json;
using Microsoft.Data.Sqlite;

namespace AuroPay.Services
{
    public static class TransactionService
    {
        private static string DatabaseFolderPath => Path.Combine(Directory.GetCurrentDirectory(), "Database");
        private static string DatabaseFilePath => Path.Combine(DatabaseFolderPath, "AuroPayDatabase.db");

        public static bool CreateTransactionByModel(Transaction transaction)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO transactions (user_id, tnx, type, scope, source, tags, note, fee, amount, status, created_at, updated_at)
                        VALUES ($userId, $tnx, $type, $scope, $source, $tags, $note, $fee, $amount, $status, $createdAt, $updatedAt);
                    ";

                    command.Parameters.AddWithValue("$userId", transaction.UserId);
                    command.Parameters.AddWithValue("$tnx", transaction.Tnx);
                    command.Parameters.AddWithValue("$type", transaction.Type);
                    command.Parameters.AddWithValue("$scope", transaction.Scope);
                    command.Parameters.AddWithValue("$source", transaction.Source);
                    command.Parameters.AddWithValue("$tags", string.Join(",", transaction.Tags));
                    command.Parameters.AddWithValue("$note", transaction.Note);
                    command.Parameters.AddWithValue("$fee", transaction.Fee);
                    command.Parameters.AddWithValue("$amount", transaction.Amount);
                    command.Parameters.AddWithValue("$status", transaction.Status);
                    command.Parameters.AddWithValue("$createdAt", transaction.CreatedAt);
                    command.Parameters.AddWithValue("$updatedAt", transaction.UpdatedAt);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating transaction: {ex.Message}");
                return false;
            }
        }
        public static bool CreateTransaction(
            int userId, 
            string tnx, 
            string type, 
            string scope, 
            string source, 
            List<string> tags, 
            string note, 
            decimal fee, 
            decimal amount, 
            string status)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    
                    string tagsJson = JsonConvert.SerializeObject(tags);
                    
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO transactions (user_id, tnx, type, scope, source, tags, note, fee, amount, status, created_at, updated_at)
                        VALUES ($userId, $tnx, $type, $scope, $source, $tags, $note, $fee, $amount, $status, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
                    ";
                    
                    command.Parameters.AddWithValue("$userId", userId);
                    command.Parameters.AddWithValue("$tnx", tnx);
                    command.Parameters.AddWithValue("$type", type);
                    command.Parameters.AddWithValue("$scope", scope);
                    command.Parameters.AddWithValue("$source", source);
                    command.Parameters.AddWithValue("$tags", tagsJson);  
                    command.Parameters.AddWithValue("$note", note);
                    command.Parameters.AddWithValue("$fee", fee);
                    command.Parameters.AddWithValue("$amount", amount);
                    command.Parameters.AddWithValue("$status", status);

                    var result = command.ExecuteNonQuery();

                    return result > 0;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating transaction: {ex.Message}", "Create Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Transaction? GetTransactionById(int transactionId, int userId)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT id, user_id, tnx, type, scope, source, tags, note, fee, amount, status, created_at, updated_at
                        FROM transactions
                        WHERE id = $id AND user_id = $userId;
                    ";
                    command.Parameters.AddWithValue("$id", transactionId);
                    command.Parameters.AddWithValue("$userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var tagsColumn = reader.IsDBNull(6) ? "[]" : reader.GetString(6); 
                            List<string> tags = new List<string>();

                            try
                            {
                                tags = JsonConvert.DeserializeObject<List<string>>(tagsColumn) ?? new List<string>();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error deserializing tags: {ex.Message}", "Deserialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            return new Transaction
                            {
                                Id = reader.GetInt32(0),
                                UserId = reader.GetInt32(1),
                                Tnx = reader.GetString(2),
                                Type = reader.GetString(3),
                                Scope = reader.GetString(4),
                                Source = reader.GetString(5),
                                Tags = tags, 
                                Note = reader.GetString(7),
                                Fee = reader.GetDecimal(8),
                                Amount = reader.GetDecimal(9),
                                Status = reader.GetString(10),
                                CreatedAt = reader.GetDateTime(11),
                                UpdatedAt = reader.GetDateTime(12)
                            };
                        }
                        else
                        {
                            MessageBox.Show("Transaction not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching transaction: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<Transaction> GetTransactionsByScope(int userId, string scope)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT id, user_id, tnx, type, scope, source, tags, note, fee, amount, status, created_at, updated_at
                        FROM transactions
                        WHERE user_id = $userId AND scope = $scope;
                    ";

                    command.Parameters.AddWithValue("$userId", userId);
                    command.Parameters.AddWithValue("$scope", scope);

                    var reader = command.ExecuteReader();
                    var transactions = new List<Transaction>();

                    while (reader.Read())
                    {
                        var transaction = new Transaction
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Tnx = reader.GetString(2),
                            Type = reader.GetString(3),
                            Scope = reader.GetString(4),
                            Source = reader.GetString(5),
                            Tags = JsonConvert.DeserializeObject<List<string>>(reader.GetString(6)) ?? new List<string>(),
                            Note = reader.GetString(7),
                            Fee = reader.GetDecimal(8),
                            Amount = reader.GetDecimal(9),
                            Status = reader.GetString(10),
                            CreatedAt = reader.GetDateTime(11),
                            UpdatedAt = reader.GetDateTime(12)
                        };
                        transactions.Add(transaction);
                    }

                    return transactions;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving transactions by scope: {ex.Message}", "Retrieve Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Transaction>();
            }
        }
        public static List<Transaction> GetTransactionsBySource(int userId, string source)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT id, user_id, tnx, type, scope, source, tags, note, fee, amount, status, created_at, updated_at
                        FROM transactions
                        WHERE user_id = $userId AND source = $source;
                    ";

                    command.Parameters.AddWithValue("$userId", userId);
                    command.Parameters.AddWithValue("$source", source);

                    var reader = command.ExecuteReader();
                    var transactions = new List<Transaction>();

                    while (reader.Read())
                    {
                        var transaction = new Transaction
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Tnx = reader.GetString(2),
                            Type = reader.GetString(3),
                            Scope = reader.GetString(4),
                            Source = reader.GetString(5),
                            Tags = JsonConvert.DeserializeObject<List<string>>(reader.GetString(6)) ?? new List<string>(),
                            Note = reader.GetString(7),
                            Fee = reader.GetDecimal(8),
                            Amount = reader.GetDecimal(9),
                            Status = reader.GetString(10),
                            CreatedAt = reader.GetDateTime(11),
                            UpdatedAt = reader.GetDateTime(12)
                        };
                        transactions.Add(transaction);
                    }

                    return transactions;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving transactions by source: {ex.Message}", "Retrieve Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Transaction>();
            }
        }

        public static List<Transaction> GetTransactionsByType(int userId, string type)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT id, user_id, tnx, type, scope, source, tags, note, fee, amount, status, created_at, updated_at
                        FROM transactions
                        WHERE user_id = $userId AND type = $type;
                    ";

                    command.Parameters.AddWithValue("$userId", userId);
                    command.Parameters.AddWithValue("$type", type);

                    var reader = command.ExecuteReader();
                    var transactions = new List<Transaction>();

                    while (reader.Read())
                    {
                        var transaction = new Transaction
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Tnx = reader.GetString(2),
                            Type = reader.GetString(3),
                            Scope = reader.GetString(4),
                            Source = reader.GetString(5),
                            Tags = JsonConvert.DeserializeObject<List<string>>(reader.GetString(6)) ?? new List<string>(),
                            Note = reader.GetString(7),
                            Fee = reader.GetDecimal(8),
                            Amount = reader.GetDecimal(9),
                            Status = reader.GetString(10),
                            CreatedAt = reader.GetDateTime(11),
                            UpdatedAt = reader.GetDateTime(12)
                        };
                        transactions.Add(transaction);
                    }

                    return transactions;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving transactions by type: {ex.Message}", "Retrieve Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Transaction>();
            }
        }

        public static List<Transaction> GetAllTransactions(int userId)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT id, user_id, tnx, type, scope, source, tags, note, fee, amount, status, created_at, updated_at
                        FROM transactions
                        WHERE user_id = $userId;
                    ";

                    command.Parameters.AddWithValue("$userId", userId);

                    var reader = command.ExecuteReader();
                    var transactions = new List<Transaction>();

                    while (reader.Read())
                    {
                        var transaction = new Transaction
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Tnx = reader.GetString(2),
                            Type = reader.GetString(3),
                            Scope = reader.GetString(4),
                            Source = reader.GetString(5),
                            Tags = JsonConvert.DeserializeObject<List<string>>(reader.GetString(6)) ?? new List<string>(),
                            Note = reader.GetString(7),
                            Fee = reader.GetDecimal(8),
                            Amount = reader.GetDecimal(9),
                            Status = reader.GetString(10),
                            CreatedAt = reader.GetDateTime(11),
                            UpdatedAt = reader.GetDateTime(12)
                        };
                        transactions.Add(transaction);
                    }

                    return transactions;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving all transactions: {ex.Message}", "Retrieve Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Transaction>();
            }
        }
        public static List<Transaction> GetTransactionsByMixedFilter(
            int userId, 
            string? scope = null, 
            string? source = null, 
            string? type = null, 
            string? tnx = null, 
            string? note = null,
            string? tags = null)  
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    
                    var query = "SELECT id, user_id, tnx, type, scope, source, tags, note, fee, amount, status, created_at, updated_at FROM transactions WHERE user_id = $userId";
                    
                    if (!string.IsNullOrEmpty(scope))
                    {
                        query += " AND scope = $scope";
                    }
                    if (!string.IsNullOrEmpty(source))
                    {
                        query += " AND source = $source";
                    }
                    if (!string.IsNullOrEmpty(type))
                    {
                        query += " AND type = $type";
                    }
                    if (!string.IsNullOrEmpty(tnx))
                    {
                        query += " AND tnx LIKE $tnx";  
                    }
                    if (!string.IsNullOrEmpty(note))
                    {
                        query += " AND note LIKE $note";  
                    }
                    if (!string.IsNullOrEmpty(tags))
                    {
                        query += " AND tags LIKE $tags";  
                    }

                    var command = connection.CreateCommand();
                    command.CommandText = query;

                    command.Parameters.AddWithValue("$userId", userId);
                    if (!string.IsNullOrEmpty(scope)) command.Parameters.AddWithValue("$scope", scope);
                    if (!string.IsNullOrEmpty(source)) command.Parameters.AddWithValue("$source", source);
                    if (!string.IsNullOrEmpty(type)) command.Parameters.AddWithValue("$type", type);
                    if (!string.IsNullOrEmpty(tnx)) command.Parameters.AddWithValue("$tnx", "%" + tnx + "%");  
                    if (!string.IsNullOrEmpty(note)) command.Parameters.AddWithValue("$note", "%" + note + "%");  
                    if (!string.IsNullOrEmpty(tags)) command.Parameters.AddWithValue("$tags", "%" + tags + "%");  

                    var reader = command.ExecuteReader();
                    var transactions = new List<Transaction>();

                    while (reader.Read())
                    {
                        var transaction = new Transaction
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Tnx = reader.GetString(2),
                            Type = reader.GetString(3),
                            Scope = reader.GetString(4),
                            Source = reader.GetString(5),
                            Tags = JsonConvert.DeserializeObject<List<string>>(reader.GetString(6)) ?? new List<string>(),
                            Note = reader.GetString(7),
                            Fee = reader.GetDecimal(8),
                            Amount = reader.GetDecimal(9),
                            Status = reader.GetString(10),
                            CreatedAt = reader.GetDateTime(11),
                            UpdatedAt = reader.GetDateTime(12)
                        };
                        transactions.Add(transaction);
                    }

                    return transactions;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving transactions with filters: {ex.Message}", "Retrieve Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Transaction>();
            }
        }

        public static bool UpdateTransactionById(int transactionId, int userId, string type, string scope, string source, List<string> tags, string note, decimal fee, decimal amount, string status)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();

                    string serializedTags = JsonConvert.SerializeObject(tags);

                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE transactions
                        SET type = $type, scope = $scope, source = $source, tags = $tags, note = $note, fee = $fee, amount = $amount, status = $status, updated_at = CURRENT_TIMESTAMP
                        WHERE id = $id AND user_id = $userId;
                    ";

                    command.Parameters.AddWithValue("$id", transactionId);
                    command.Parameters.AddWithValue("$userId", userId);
                    command.Parameters.AddWithValue("$type", type);
                    command.Parameters.AddWithValue("$scope", scope);
                    command.Parameters.AddWithValue("$source", source);
                    command.Parameters.AddWithValue("$tags", serializedTags); 
                    command.Parameters.AddWithValue("$note", note);
                    command.Parameters.AddWithValue("$fee", fee);
                    command.Parameters.AddWithValue("$amount", amount);
                    command.Parameters.AddWithValue("$status", status);

                    var result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return true; 
                    }
                    else
                    {
                        MessageBox.Show("No transaction found or no changes made.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating transaction: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
        }


        public static bool DeleteTransaction(int transactionId, int userId)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabaseFilePath}"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM transactions WHERE id = $id AND user_id = $userId;";
                    command.Parameters.AddWithValue("$id", transactionId);
                    command.Parameters.AddWithValue("$userId", userId);

                    var rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Transaction deleted successfully.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Transaction not found or does not belong to the user.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting transaction: {ex.Message}");
                return false;
            }
        }
    }
}
