using System.Diagnostics;

namespace HexoBlog
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;

        }

        private void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
            Debug.WriteLine(exception, exception.Message);
        
        }
    }
}
