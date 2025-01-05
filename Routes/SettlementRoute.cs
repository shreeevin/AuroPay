using AuroPay.Common;
using AuroPay.Views.Settlement;

namespace AuroPay.Routes
{
    public class SettlementRoute
    {
        public static Form GetForm(object? data = null)
        {
            var settlementScreen = new SettlementScreen();

            if (data != null && settlementScreen is IViewData viewDataForm)
            {
                viewDataForm.SetData(data);
            }

            return settlementScreen;
        }
    }
}
