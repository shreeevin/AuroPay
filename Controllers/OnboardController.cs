using AuroPay.Routes;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class OnboardController
    {
        public static void ShowOnboardScreen(Form currentForm)
        {
            var onboardScreen = OnboardRoute.GetForm();
            RouterService.NavigateTo(currentForm, onboardScreen.GetType());
        }

        public static void NavigateToOnboard(Form currentForm){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowOnboardScreen(currentForm),
                "default"
            );            
        } 
    }
}