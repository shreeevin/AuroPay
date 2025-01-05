using AuroPay.Routes;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class LoginController
    {
        public static void ShowLoginScreen(Form currentForm)
        {
            var loginScreenForm = LoginRoute.GetForm();            
            RouterService.NavigateTo(currentForm, loginScreenForm.GetType());
        }
        public static void NavigateToLogin(Form currentForm){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowLoginScreen(currentForm),
                "auth"
            );        
        }
        public static bool LoginAccount(string username, string password)
        {
            bool loginStatus =  AuthService.Login(
                username,
                password
            );

            return loginStatus;
        }
    }
}