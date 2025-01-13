using AuroPay.Routes;
using AuroPay.Models;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class SettlementEditController
    {
        public static void ShowSettlementEditScreen(Form currentForm, int userId, int  transactionId)
        {
            User? currentUser = AuthService.GetCurrentUser();
            Transaction? currentTransaction = TransactionService.GetTransactionById(transactionId, userId);

            var settlementProps = new Dictionary<string, object>
            {
                { "currentUser", currentUser ?? new User() },
                { "currentTransaction", currentTransaction ?? new Transaction() }
            };

            var settlementEditScreenForm = SettlementEditRoute.GetForm();          
            RouterService.NavigateTo(currentForm, settlementEditScreenForm.GetType(), settlementProps);
        }

        public static void NavigateToSettlementEdit(Form currentForm, int userId, int  transactionId){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowSettlementEditScreen(currentForm, userId, transactionId),
                "default"
            );            
        }
    }
}