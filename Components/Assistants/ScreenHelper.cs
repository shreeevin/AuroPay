namespace AuroPay.Components.Assistants
{
    public static class ScreenHelper
    {
        public static void SetupScreen(Form currentForm, string? screenName = "AuroPay")
        {
            if (currentForm == null){
                throw new ArgumentNullException(nameof(currentForm));
            }

            currentForm.MinimumSize = new Size(1280, 720); // 1280, 720 
            currentForm.Size = new Size(1280, 720); // 1280, 720
            currentForm.BackColor = Color.White;

            currentForm.Name = screenName;
            currentForm.Text = screenName;
            currentForm.BackColor = Color.White;

            currentForm.WindowState = FormWindowState.Maximized; // Maximized
            currentForm.Icon = new Icon("Resources/AppIcon/icon.ico");

            currentForm.FormClosing += (sender, e) => Application.Exit();
        }
    }
}