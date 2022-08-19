using CollegeMathServices.Services;
using CollegeMathServices.DTOs;
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
        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2NjA5NDc4NTEsImV4cCI6MTY2MTAzNDI1MSwiaWF0IjoxNjYwOTQ3ODUxLCJpc3MiOiJNZXVTaXN0ZW1hIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3QifQ.LlOijo5y6XN6tvu8-iqoH53Bh-guHjEF6XJGhPRP7B8";
        public HomeView()
        {
            InitializeComponent();
            var contents = GetContents();
            CreateContents(contents);
        }

        private void CreateContents(IEnumerable<ContentDTO> contents) 
        {
            foreach (var content in contents)
            {
                var button = new Button
                {
                    Text = content.Name,
                };
                button.Style = (Style)Application.Current.Resources["btnConteudo"];

                if (content.Name.Equals("Funções")) 
                    button.Clicked += btnFuncoes_Clicked;

                if (content.Name.Equals("Lógica"))
                    button.Clicked += btnLogica_Clicked;

                if (content.Name.Equals("Conjuntos"))
                    button.Clicked += btnConjuntos_Clicked;

                stkButtons.Children.Add(button);
            }
        }

        

        private IEnumerable<ContentDTO> GetContents()
        {
            var contentService = new ContentService(token);
            return contentService.GetAll();
        }

        private async void btnFuncoes_Clicked(object sender, EventArgs e)
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

        private void btnRankingHome_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new RankingView());
        }
    }
}