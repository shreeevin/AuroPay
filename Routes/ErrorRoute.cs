using AuroPay.Views.Error;

namespace AuroPay.Routes
{
    public class ErrorRoute
    {
        public static Form GetForm()
        {
            return new ErrorScreen();
        }
    }
}
