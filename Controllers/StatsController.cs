using AuroPay.Routes;
using AuroPay.Models;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class StatsController
    {
        public static void ShowStatsScreen(Form currentForm)
        {
            User? currentUser = AuthService.GetCurrentUser();

            var statsScreenForm = StatsRoute.GetForm();          
            RouterService.NavigateTo(currentForm, statsScreenForm.GetType(), currentUser);
        }

        public static void NavigateToStats(Form currentForm){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowStatsScreen(currentForm),
                "default"
            );            
        }
    }
}