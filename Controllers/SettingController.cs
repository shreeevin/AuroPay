using AuroPay.Routes;
using AuroPay.Services;
using AuroPay.Middleware;

namespace AuroPay.Controllers
{
    public static class SettingController
    {
        public static void ShowSettingScreen(Form currentForm)
        {
            var settingScreenForm = SettingRoute.GetForm();          
            RouterService.NavigateTo(currentForm, settingScreenForm.GetType());
        }

        public static void NavigateToSetting(Form currentForm){
            AuthMiddleware.Handel(
                currentForm, 
                () => ShowSettingScreen(currentForm),
                "default"
            );            
        }
    }
}