using AuroPay.Models;
using AuroPay.Routes;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class ProfileController
    {
        public static void ShowProfileScreen(Form currentForm)
        {
            User? currentUser = AuthService.GetCurrentUser();
            
            var profileScreen = ProfileRoute.GetForm();
            RouterService.NavigateTo(currentForm, profileScreen.GetType(), currentUser);
        }

        public static void NavigateToProfile(Form currentForm){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowProfileScreen(currentForm),
                "default"
            );            
        } 
    }
}