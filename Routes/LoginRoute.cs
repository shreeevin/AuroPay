using AuroPay.Views.Login;

namespace AuroPay.Routes
{
    public class LoginRoute
    {
        public static Form GetForm()
        {
            return new LoginScreen();
        }
    }
}
