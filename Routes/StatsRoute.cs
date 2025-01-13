using AuroPay.Common;
using AuroPay.Views.Stats;

namespace AuroPay.Routes
{
    public class StatsRoute
    {
        public static Form GetForm(object? data = null)
        {
            var statsScreen = new StatsScreen();

            if (data != null && statsScreen is IViewData viewDataForm)
            {
                viewDataForm.SetData(data);
            }

            return statsScreen;
        }
    }
}
