using AuroPay.Routes;
using AuroPay.Services;

namespace AuroPay.Middleware
{
    public class AuthMiddleware
    {
        public static void Handel(Form currentForm, Action next, string scope = "default")
        {
            bool isLoggedIn =  Session.GetInstance().IsLoggedIn();

            if(scope == "auth"){
                if(isLoggedIn){
                    bool isConfigured = AuthService.IsConfigured();

                    if(isConfigured){
                        var homeScreenForm = HomeRoute.GetForm();
                        RouterService.NavigateTo(currentForm, homeScreenForm.GetType());
                    } else {
                        var onboardScreenForm = OnboardRoute.GetForm();
                        RouterService.NavigateTo(currentForm, onboardScreenForm.GetType());
                    }

                } else {
                    next();
                }                
            }

            if(scope == "default"){
                if(!isLoggedIn){
                    var loginScreenForm = LoginRoute.GetForm();
                    RouterService.NavigateTo(currentForm, loginScreenForm.GetType());
                } 
                
                next();
            }
        }
    }
}
