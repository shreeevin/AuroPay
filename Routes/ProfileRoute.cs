using AuroPay.Common;
using AuroPay.Views.Profile;

namespace AuroPay.Routes
{
    public class ProfileRoute
    {
        public static Form GetForm(object? data = null)
        {
            var profileScreen = new ProfileScreen();

            if (data != null && profileScreen is IViewData viewDataForm)
            {
                viewDataForm.SetData(data);
            }

            return profileScreen;
        }
    }
}
