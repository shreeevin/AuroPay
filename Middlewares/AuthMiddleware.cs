using AuroPay.Routes;
using AuroPay.Services;

namespace AuroPay.Middleware
{
    public class AuthMiddleware
    {
        public static void Handel(Form currentForm, Action next, string scope = "default")
        {
            bool isLoggedIn =  Session.GetInstance().IsLoggedIn();

            var loginScreenForm = LoginRoute.GetForm();
            var homeScreenForm = HomeRoute.GetForm();
            var onboardScreenForm = OnboardRoute.GetForm();

            if(scope == "auth")
            {
                if(isLoggedIn)
                {
                    bool isConfigured = AuthService.IsConfigured();

                    if(isConfigured)
                    {
                        RouterService.NavigateTo(currentForm, homeScreenForm.GetType());
                    } 
                    else 
                    {
                        RouterService.NavigateTo(currentForm, onboardScreenForm.GetType());
                    }

                } else {
                    next();
                }                
            }

            if(scope == "default"){
                if(!isLoggedIn)
                {
                    RouterService.NavigateTo(currentForm, loginScreenForm.GetType());
                } else
                {
                    next();
                }                
            }
        }
    }
}
