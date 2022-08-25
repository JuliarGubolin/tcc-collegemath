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

        #region Verifica se existe token já salvo
        private void VerifyUserSession()
        {
            //Verifica se existe token salvo na aplicação para já logar automaticamente. Senão, abre o Login
            Interfaces.ISharedPreferences sharedPreferences = DependencyService.Get<Interfaces.ISharedPreferences>();
            string token = sharedPreferences.GetUserToken();
            //Se o token for vazio, usuário não está logado
            if (string.IsNullOrEmpty(token)) 
            {
                StoreVarsHelper.UserToken = token;
                MainPage = new NavigationPage(new LoginView());
            }
            //Se já está autenticado
            else
                MainPage = new NavigationPage(new HomeView());
        }
        #endregion

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
