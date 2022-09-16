using CollegeMath.App.Helpers;
using CollegeMathServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        #region Cadastro do usuário
        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            //Verifica a conexão com a internet
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                await this.DisplayAlert("Aviso", "Sem acesso à internet. Faça conexão para continuar.", "OK");
                return;
            }
            //Se campo de email for vazio
            if(string.IsNullOrEmpty(txtEmail.Text))
            {
                await DisplayAlert("Aviso", "Por favor, preencha o e-mail.", "OK");
                return;
            }
            //Se campo de senha for vazio
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                await DisplayAlert("Aviso", "Por favor, preencha a senha.", "OK");
                return;
            }
            //Se campo de nome for vazio
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                await DisplayAlert("Aviso", "Por favor, preencha o nome", "OK");
                return;
            }
            //Se o campo de senha for diferente do campo de confirmação de senha
            if ((txtSenha.Text != null && txtSenhaConfirma.Text != null))
            {
                if (!txtSenha.Text.Equals(txtSenhaConfirma.Text))
                {
                    await DisplayAlert("Aviso", "As senhas não coincidem.", "OK");
                    return;
                }
                
            }
            //Se tudo estiver correto, cadastra o usuário e já faz seu Login salvando o token de acesso
            var userService = new UserService();
            bool registerSuccess = await userService.RegisterAsync(txtEmail.Text, txtSenha.Text, txtNome.Text);
            if (registerSuccess)
            {
                var token = await userService.LoginAsync(txtEmail.Text, txtSenha.Text);
                if (token != null) 
                {
                    //Salva o token do usuário
                    Interfaces.ISharedPreferences sharedPreferences = DependencyService.Get<Interfaces.ISharedPreferences>();
                    sharedPreferences.SaveUserToken(token);
                    StoreVarsHelper.UserToken = token;
                    App.Current.MainPage = new NavigationPage(new HomeView());
                }
                else
                    await DisplayAlert("Aviso", "Erro ao efetuar acesso.", "OK");
            }
            else 
            {
                await DisplayAlert("Aviso", "Erro ao cadastrar usuário.", "OK");
            }
        }
        #endregion
    }
}