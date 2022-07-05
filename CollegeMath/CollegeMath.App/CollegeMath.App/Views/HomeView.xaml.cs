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
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void btnFuncoes_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new FunctionsHomeView());
            //App.Current.MainPage = new FunctionsHomeView();
        }

        private async void btnAjudaHome_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Ajuda", "Escolha entre um dos 3 conteúdos disponíveis:\n\nFunções; \nLógica Matemática; \nConjuntos. \n\nCada um possui 3 níveis com questões para responder.", "OK");
        }

        private void btnLogica_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new LogicHomeView());
        }

        private void btnConjuntos_Clicked(object sender, EventArgs e)
        {

        }
    }
}