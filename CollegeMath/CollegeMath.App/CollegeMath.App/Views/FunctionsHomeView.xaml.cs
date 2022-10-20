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
        int levelId = 0;
        int contentId = 1;
        public FunctionsHomeView(int level)
        {
            InitializeComponent();
            var levels = GetLevels();
            CreateLevels(levels, level);
        }

        private void CreateLevels(IEnumerable<LevelDTO> levels, int lvl)
        {
            foreach (var level in levels)
            {
                Button button = new Button
                {
                    Text = level.Name,
                    Style = (Style)Application.Current.Resources["btnNiveis"]
                };
                if (level.Name.Equals("Nível 1"))
                {
                    button.Clicked += btnNivel1_Clicked;
                    if (lvl == 1)
                    {
                        button.IsEnabled = false;
                    }
                }

                if (level.Name.Equals("Nível 2"))
                {
                    button.Clicked += btnNivel2_Clicked;
                    if (lvl == 2)
                    {
                        button.IsEnabled = false;
                    }
                }
                if (level.Name.Equals("Nível 3"))
                {
                    button.Clicked += btnNivel3_Clicked;
                    if (lvl == 3)
                    {
                        button.IsEnabled = false;
                    }
                }
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
        private async void btnNivel1_Clicked(object sender, EventArgs e)
        {
            levelId = 1;
            infoQuestion = await GetQuestions(levelId);
            App.Current.MainPage = new NavigationPage(new QuestionPage(infoQuestion, 0));

        }

        #region GetQuestions (QuestionService)
        private async Task<IEnumerable<QuestionDTO>> GetQuestions(int levelId)
        {
            var questionService = new QuestionService(StoreVarsHelper.UserToken);
            var quest = await questionService.GetAllById(contentId, levelId);
            return quest;
        }
        #endregion

        private async void btnNivel2_Clicked(object sender, EventArgs e)
        {
            levelId = 2;
            infoQuestion = await GetQuestions(levelId);
            App.Current.MainPage = new NavigationPage(new QuestionPage(infoQuestion, 0));
        }
        private async void btnNivel3_Clicked(object sender, EventArgs e)
        {
            levelId = 3;
            infoQuestion = await GetQuestions(levelId);
            App.Current.MainPage = new NavigationPage(new QuestionPage(infoQuestion, 0));
        }
    }
}