using AuroPay.Database;

using AuroPay.Controllers;

namespace AuroPay
{
    static class Program
    {
        [STAThread]
        static void Main()
        {       
            DatabaseInitializer.Initialize();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashController.ShowSplashScreen();
        }
    }
}

