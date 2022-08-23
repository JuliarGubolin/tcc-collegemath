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
    public partial class UserRegistryView : ContentPage
    {
        public UserRegistryView()
        {
            InitializeComponent();
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail.Text))
            {
                await DisplayAlert("Aviso", "Por favor, preencha o e-mail", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                await DisplayAlert("Aviso", "Por favor, preencha a senha", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                await DisplayAlert("Aviso", "Por favor, preencha o nome", "OK");
                return;
            }

            var userService = new UserService();
            bool registerSuccess = await userService.RegisterAsync(txtEmail.Text, txtSenha.Text, txtNome.Text);
            if (registerSuccess)
            {
                var token = await userService.LoginAsync(txtEmail.Text, txtSenha.Text);
                if (token != null) 
                {
                    Interfaces.ISharedPreferences sharedPreferences = DependencyService.Get<Interfaces.ISharedPreferences>();
                    sharedPreferences.SaveUserToken(token);
                    StoreVarsHelper.UserToken = token;
                    App.Current.MainPage = new NavigationPage(new HomeView());
                }
                else
                    await DisplayAlert("Aviso", "Erro ao efetuar acesso :( ;-;", "OK");
            }
            else 
            {
                await DisplayAlert("Aviso", "Erro ao cadastrar usuário :(", "OK");
            }
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}