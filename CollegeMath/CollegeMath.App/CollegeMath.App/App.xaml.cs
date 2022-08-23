using CollegeMath.App.Helpers;
using CollegeMath.App.Views;
using Xamarin.Forms;

namespace CollegeMath.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            VerifyUserSession();
        }

        private void VerifyUserSession()
        {
            Interfaces.ISharedPreferences sharedPreferences = DependencyService.Get<Interfaces.ISharedPreferences>();
            string token = sharedPreferences.GetUserToken();
            if (string.IsNullOrEmpty(token)) 
            {
                StoreVarsHelper.UserToken = token;
                MainPage = new NavigationPage(new LoginView());
            }
            else
                MainPage = new NavigationPage(new HomeView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
