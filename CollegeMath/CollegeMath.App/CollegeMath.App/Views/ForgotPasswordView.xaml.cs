using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMath.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordView : ContentPage
    {
        public ForgotPasswordView()
        {
            InitializeComponent();
        }

        private async void btnEnviarEmailRec_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                await this.DisplayAlert("Aviso", "Sem acesso à internet.", "OK");
                return;
            }
            //var userService = new UserService();
            //await userService.SendForgotPasswordEmail(txtEmail.Text);
            await this.Navigation.PushModalAsync(new CodeForgotPasswordView());
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {

        }
    }
}