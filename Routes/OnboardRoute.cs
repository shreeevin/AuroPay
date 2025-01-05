using AuroPay.Views.Onboard;

namespace AuroPay.Routes
{
    public class OnboardRoute
    {
        public static Form GetForm()
        {
            return new OnboardScreen();
        }
    }
}
