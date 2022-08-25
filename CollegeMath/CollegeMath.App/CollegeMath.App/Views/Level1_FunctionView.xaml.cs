using CollegeMath.App.Helpers;
using CollegeMathServices.DTOs;
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
    public partial class Level1_FunctionView : ContentPage
    {
        public Level1_FunctionView()
        {
            InitializeComponent();
            var infoQuestion = GetQuestions();
            CreateViewQuestion(infoQuestion);
        }

        private IEnumerable<QuestionDTO> GetQuestions()
        {
            var questionService = new QuestionService(StoreVarsHelper.UserToken);
            return questionService.GetAll();
        }

        #region Criação da questão na tela
        //Cria os conteúdos na tela com os botões
        private void CreateViewQuestion(IEnumerable<QuestionDTO> questions)
        {
            foreach (var question in questions)
            {
                var title = new Label
                {
                    Text = question.Title,
                };
                title.Style = (Style)Application.Current.Resources["lblQuestaoTitulo"];
                var text = new Label
                {
                    Text = question.Text,
                };
                text.Style = (Style)Application.Current.Resources["lblQuestaoTexto"];
                stkQuestao.Children.Add(title);
                stkTextoQuestao.Children.Add(text);
            }
        }
        #endregion
        private async void btnVerificar_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new SolutionView());
        }
    }
}