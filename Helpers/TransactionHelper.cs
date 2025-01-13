using AuroPay.Models;

namespace AuroPay.Helpers
{
    public static class TransactionHelper
    {
        public static List<Filter> GetTransactionTypes()
        {
            return new List<Filter>
            {
                new Filter { Code = "default", Name = "Default" },                
                new Filter { Code = "debit", Name = "Debit" },
                new Filter { Code = "credit", Name = "Credit" }                
            };
        }
        public static List<Filter> GetTransactionScopes()
        {
            return new List<Filter>
            {
                new Filter { Code = "default", Name = "Default" },                
                new Filter { Code = "income", Name = "Income" },
                new Filter { Code = "expense", Name = "Expense" },
                new Filter { Code = "debt", Name = "Debt" }                
            };
        }
        public static List<Filter> GetTransactionStatus()
        {
            return new List<Filter>
            {
                new Filter { Code = "default", Name = "Default" },                
                new Filter { Code = "completed", Name = "Completed" },
                new Filter { Code = "pending", Name = "Pending" }                
            };
        }
        public static bool ValidateSettlementInput(string amountText, string note)
        {
            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0 || amount.ToString().Length > 10)
            {
                MessageBox.Show(
                    "Amount is required, should be a positive number, and can be a maximum of 10 digits.",
                    "Validation Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );

                return false;
            }

            if (note != null && note.Length > 60)
            {
                MessageBox.Show(
                    "Note cannot exceed 60 characters.",
                    "Validation Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
                
                return false;
            }

            return true;
        }
    }
}