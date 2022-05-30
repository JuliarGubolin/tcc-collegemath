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
            var usuarioCadastroView = new UsuarioCadastroView();
            this.Navigation.PushAsync(usuarioCadastroView);
        }
    }
}