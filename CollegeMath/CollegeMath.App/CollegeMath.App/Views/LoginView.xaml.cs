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
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }
        #region Botão tela de cadastro
        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new UserRegistryView());
        }
        #endregion

        #region Login do usuário
        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            //Validar o Login
            try
            {
                //Verifica o Acesso à internet
                var current = Connectivity.NetworkAccess;
                if (current != NetworkAccess.Internet)
                {
                    await this.DisplayAlert("Aviso", "Sem acesso à internet. Faça uma conexão para continuar.", "OK");
                    return;
                }
                //Recebe o token retornado da função de Login do UserService
            
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSenha.Text))
                {
                    await this.DisplayAlert("Aviso", "Digite usuário e senha para continuar", "OK");
                    return;
                }

                var token = await new UserService().LoginAsync(txtEmail.Text, txtSenha.Text);
                if (token != null) 
                {
                    //Salva o Token para não precisar ficar entrando e saindo denovo
                    Interfaces.ISharedPreferences sharedPreferences = DependencyService.Get<Interfaces.ISharedPreferences>();//Captura uma instância de ISharedPreferences
                    sharedPreferences.SaveUserToken(token);
                    StoreVarsHelper.UserToken = token;
                    //Chama a tela principal de conteúdos
                    App.Current.MainPage = new NavigationPage(new HomeView());
                }
                else
                    await this.DisplayAlert("Aviso", "Usuário e/ou senha incorretos.", "OK");
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Aviso", ex.Message, "OK");
            }
        }
        #endregion
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