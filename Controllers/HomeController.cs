using AuroPay.Routes;
using AuroPay.Models;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class HomeController
    {
        public static void ShowHomeScreen(Form currentForm)
        {
            User? currentUser = AuthService.GetCurrentUser();

            var homeScreenForm = HomeRoute.GetForm();          
            RouterService.NavigateTo(currentForm, homeScreenForm.GetType(), currentUser);
        }

        public static void NavigateToHome(Form currentForm){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowHomeScreen(currentForm),
                "default"
            );            
        }
    }
}