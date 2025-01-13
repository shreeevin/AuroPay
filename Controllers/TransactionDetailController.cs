using AuroPay.Routes;
using AuroPay.Models;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class TransactionDetailController
    {
        public static void ShowTransactionDetailScreen(Form currentForm, int userId, int transactionId)
        {
            User? currentUser = AuthService.GetCurrentUser();
            Transaction? currentTransaction = TransactionService.GetTransactionById(transactionId, userId);

            var transactionProps = new Dictionary<string, object>
            {
                { "currentUser", currentUser ?? new User() },
                { "currentTransaction", currentTransaction ?? new Transaction() }
            };

            var transactionDetailScreenForm = TransactionDetailRoute.GetForm();          
            RouterService.NavigateTo(currentForm, transactionDetailScreenForm.GetType(), transactionProps);
        }

        public static void NavigateToTransactionDetail(Form currentForm, int userId, int transactionId){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowTransactionDetailScreen(currentForm, userId, transactionId),
                "default"
            );            
        }
    }
}