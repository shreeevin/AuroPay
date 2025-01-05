using AuroPay.Models;

namespace AuroPay.Helpers
{
    public static class TransactionHelper
    {
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