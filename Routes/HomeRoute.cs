using AuroPay.Common;
using AuroPay.Views.Home;

namespace AuroPay.Routes
{
    public class HomeRoute
    {
        public static Form GetForm(object? data = null)
        {
            var homeScreen = new HomeScreen();

            if (data != null && homeScreen is IViewData viewDataForm)
            {
                viewDataForm.SetData(data);
            }

            return homeScreen;
        }
    }
}
