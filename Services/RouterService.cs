using AuroPay.Common;
using AuroPay.Views.Error;

namespace AuroPay.Services
{
    public static class RouterService
    {
        public static void NavigateTo(Form currentForm, Type routeType, object? data = null)
        {
            try
            {
                currentForm.Hide();

                var nextForm = Activator.CreateInstance(routeType) as Form;

                if (nextForm != null)
                {
                    if (data != null && nextForm is IViewData viewDataForm)
                    {
                        viewDataForm.SetData(data);
                    }

                    nextForm.Show();
                }
                else
                {
                    throw new Exception("Route not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                var errorScreen = new ErrorScreen();
                errorScreen.Show();
            }
        }
    }
}

