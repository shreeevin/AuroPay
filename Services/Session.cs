namespace AuroPay.Services
{
    public class Session
    {
        public string? Username { get; private set; }

        private Session() { }

        private static Session? _instance;

        public static Session GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Session();
            }
            return _instance;
        }

        public void LogIn(string username)
        {
            Username = username;
        }

        public void LogOut()
        {
            Username = null;
        }

        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Username);
        }
    }
}
