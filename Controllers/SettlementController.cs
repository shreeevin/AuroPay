using AuroPay.Routes;
using AuroPay.Models;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class SettlementController
    {
        public static void ShowSettlementScreen(Form currentForm, string? scope = "income")
        {
            string? settlementScope = scope;
            User? currentUser = AuthService.GetCurrentUser();

            var settlementProps = new Dictionary<string, object>
            {
                { "settlementScope", settlementScope ?? "income" },
                { "currentUser", currentUser ?? new User() } 
            };

            var settlementScreenForm = SettlementRoute.GetForm();          
            RouterService.NavigateTo(currentForm, settlementScreenForm.GetType(), settlementProps);
        }

        public static void NavigateToSettlement(Form currentForm, string? scope){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowSettlementScreen(currentForm, scope),
                "default"
            );            
        }
    }
}