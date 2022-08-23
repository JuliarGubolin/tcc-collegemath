using CollegeMath.App.Helpers;
using CollegeMathServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMath.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new UserRegistryView());
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var token = await new UserService().LoginAsync(txtEmail.Text, txtSenha.Text);
                if (token != null) 
                {
                    Interfaces.ISharedPreferences sharedPreferences = DependencyService.Get<Interfaces.ISharedPreferences>();
                    sharedPreferences.SaveUserToken(token);
                    StoreVarsHelper.UserToken = token;
                    App.Current.MainPage = new NavigationPage(new HomeView());
                }
                else
                    await this.DisplayAlert("Aviso", "Usuário e/ou senha incorretos", "OK");
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Aviso", ex.Message, "OK");
            }
        }

        private void btnEsqueceuSenha_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new ForgotPasswordView());
        }

        private void btninformation_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new InformationView());
        }
    }
}