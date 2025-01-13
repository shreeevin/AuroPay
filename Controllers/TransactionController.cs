using AuroPay.Routes;
using AuroPay.Models;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class TransactionController
    {
        public static void ShowTransactionScreen(Form currentForm)
        {
            User? currentUser = AuthService.GetCurrentUser();

            var transactionScreenForm = TransactionRoute.GetForm();          
            RouterService.NavigateTo(currentForm, transactionScreenForm.GetType(), currentUser);
        }

        public static void NavigateToTransaction(Form currentForm){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowTransactionScreen(currentForm),
                "default"
            );            
        }
    }
}