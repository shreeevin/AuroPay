using AuroPay.Views.Register;

namespace AuroPay.Routes
{
    public class RegisterRoute
    {
        public static Form GetForm()
        {
            return new RegisterScreen();
        }
    }
}
