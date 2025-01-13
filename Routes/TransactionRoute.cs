using AuroPay.Common;
using AuroPay.Views.Transaction;

namespace AuroPay.Routes
{
    public class TransactionRoute
    {
        public static Form GetForm(object? data = null)
        {
            var transactionScreen = new TransactionScreen();

            if (data != null && transactionScreen is IViewData viewDataForm)
            {
                viewDataForm.SetData(data);
            }

            return transactionScreen;
        }
    }
}
