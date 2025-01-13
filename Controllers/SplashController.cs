using AuroPay.Routes;
using AuroPay.Services;

using WinFormsTimer = System.Windows.Forms.Timer;

namespace AuroPay.Controllers
{
    public static class SplashController
    {
        public static void ShowSplashScreen()
        {
            var splashScreen = SplashRoute.GetForm();
            splashScreen.Show(); 

            WinFormsTimer timer = new WinFormsTimer();

            timer.Interval = 3000; 
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                splashScreen.Hide();

                var loginScreenForm = LoginRoute.GetForm();
                RouterService.NavigateTo(splashScreen, loginScreenForm.GetType());
            };
            
            timer.Start();         
                
            Application.Run(splashScreen); 
        }

        public static void NavigateToSplash(){
            ShowSplashScreen();          
        }
    }
}
