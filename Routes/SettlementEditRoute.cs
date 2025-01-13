using AuroPay.Common;
using AuroPay.Views.Settlement;

namespace AuroPay.Routes
{
    public class SettlementEditRoute
    {
        public static Form GetForm(object? data = null)
        {
            var settlementEditScreen = new SettlementEditScreen();

            if (data != null && settlementEditScreen is IViewData viewDataForm)
            {
                viewDataForm.SetData(data);
            }

            return settlementEditScreen;
        }
    }
}
