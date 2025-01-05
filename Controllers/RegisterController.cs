using AuroPay.Routes;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class RegisterController
    {
        public static void ShowRegisterScreen(Form currentForm)
        {
            var registerScreen = RegisterRoute.GetForm();
            RouterService.NavigateTo(currentForm, registerScreen.GetType());
        }

        public static void NavigateToRegister(Form currentForm){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowRegisterScreen(currentForm),
                "auth"
            );            
        } 
        public static bool CreateAccount(string username, string password, string currency)
        {
            bool registerStatus =  AuthService.Register(
                username,
                password,
                currency
            );

            return registerStatus;
        }
    }
}