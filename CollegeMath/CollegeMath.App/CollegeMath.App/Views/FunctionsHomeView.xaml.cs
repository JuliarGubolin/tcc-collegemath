using CollegeMath.App.Helpers;
using CollegeMath.App.Views.ClassesContentPage;
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
    public partial class FunctionsHomeView : ContentPage
    {
        IEnumerable<QuestionDTO> infoQuestion;
        IEnumerable<AlternativeDTO> infoAlt;
        int i;

        public FunctionsHomeView()
        {
            InitializeComponent();
            var levels = GetLevels();
            CreateLevels(levels);
        }

        private void CreateLevels(IEnumerable<LevelDTO> levels)
        {
            foreach (var level in levels)
            {
                Button button = new Button
                {
                    Text = level.Name,
                    Style = (Style)Application.Current.Resources["btnNiveis"]
                };
                if (level.Name.Equals("Nível 1"))
                    button.Clicked += btnNivel1_Clicked;

                if (level.Name.Equals("Nível 2"))
                    button.Clicked += btnNivel2_Clicked;

                if (level.Name.Equals("Nível 3"))
                    button.Clicked += btnNivel3_Clicked;

                stkLevelsFunction.Children.Add(button);
            }
        }

        private IEnumerable<LevelDTO> GetLevels()
        {
            return new LevelService(StoreVarsHelper.UserToken).GetAll();
        }
        private async void btnAjudaFunctions_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new FunctionsHelpView());
        }
        private void btnNivel1_Clicked(object sender, EventArgs e)
        {
            infoQuestion = GetQuestions();
            i = 0;
            infoAlt = GetAlternatives();
            //CreateViewQuestion(infoQuestion, infoAlt, 0);
            App.Current.MainPage = new NavigationPage(new QuestionPage(infoQuestion, infoAlt, 0));
        }

        #region GetQuestions (QuestionService)
        private IEnumerable<QuestionDTO> GetQuestions()
        {
            var questionService = new QuestionService(StoreVarsHelper.UserToken);
            return questionService.GetAll();
        }
        #endregion

        #region GetAlternatives (AlternativeService)
        private IEnumerable<AlternativeDTO> GetAlternatives()
        {
            var alternativeService = new AlternativeService(StoreVarsHelper.UserToken);
            return alternativeService.GetAll();
        }
        #endregion

        private void btnNivel2_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new NavigationPage(new Level1_FunctionView());
        }
        private void btnNivel3_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new NavigationPage(new Level1_FunctionView());
        }
    }
}