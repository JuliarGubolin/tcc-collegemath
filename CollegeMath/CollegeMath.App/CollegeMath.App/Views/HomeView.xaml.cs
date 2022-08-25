using CollegeMathServices.Services;
using CollegeMathServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CollegeMath.App.Helpers;

namespace CollegeMath.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            //Chamando dos conteúdos da API
            var contents = GetContents();
            CreateContents(contents);
        }

        #region Criação dos botões de conteúdo na tela
        //Cria os conteúdos na tela com os botões
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
        #endregion


        //Recebe da classe ContentServices os conteúdos baseados no token de autenticação
        private IEnumerable<ContentDTO> GetContents()
        {
            //Não preciso mais do token estático, agr uso o token disponível na aplicação
            var contentService = new ContentService(StoreVarsHelper.UserToken);
            return contentService.GetAll();
        }

        #region Botões da Home
        private async void btnFuncoes_Clicked(object sender, EventArgs e)
        {
            //Coloquei o Await aqui
            await this.Navigation.PushAsync(new FunctionsHomeView());
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
            this.Navigation.PushAsync(new SetHomeView());
        }

        private void btnRankingHome_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new RankingView());
        }

        private void btnLogoutHome_Clicked(object sender, EventArgs e)
        {
            //Cria uam nova instancia das preferencias do token e chama o Logout para apagar o token
            Interfaces.ISharedPreferences sharedPreferences = DependencyService.Get<Interfaces.ISharedPreferences>();
            sharedPreferences.Logout();
            //Chama a tela de Login
            App.Current.MainPage = new NavigationPage(new LoginView());
        }
        #endregion


    }
}