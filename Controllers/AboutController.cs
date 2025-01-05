using AuroPay.Routes;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class AboutController
    {
        public static void ShowAboutScreen(Form currentForm)
        {
            var aboutScreenForm = AboutRoute.GetForm();          
            RouterService.NavigateTo(currentForm, aboutScreenForm.GetType());
        }

        public static void NavigateToAbout(Form currentForm){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowAboutScreen(currentForm),
                "default"
            );            
        }
    }
}