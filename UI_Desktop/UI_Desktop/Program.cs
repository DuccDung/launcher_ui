using UI_Desktop.Auth;
using UI_Desktop.Store;

namespace UI_Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new LoginForm());
            Application.Run(new StoreForm());
        }
    }
}
