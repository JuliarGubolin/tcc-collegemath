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
    public partial class FunctionsHomeView : ContentPage
    {
        public FunctionsHomeView()
        {
            InitializeComponent();
        }

        private async void btnAjudaFunctions_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new AjudaFuncoesView());
        }

        private void btnNivel1_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Level1_Function());
        }
    }
}