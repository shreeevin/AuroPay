using AuroPay.Common;
using AuroPay.Views.Transaction;

namespace AuroPay.Routes
{
    public class TransactionDetailRoute
    {
        public static Form GetForm(object? data = null)
        {
            var transactionDetailScreen = new TransactionDetailScreen();

            if (data != null && transactionDetailScreen is IViewData viewDataForm)
            {
                viewDataForm.SetData(data);
            }

            return transactionDetailScreen;
        }
    }
}
