using CollegeMath.App.Helpers;
using CollegeMathServices.DTOs;
using CollegeMathServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CollegeMath.App.Views.ClassesContentPage
{
    public partial class QuestionPage : ContentPage
    {
        int size=0;
        StackLayout contentStackLayout = new StackLayout();
        public QuestionPage(IEnumerable<QuestionDTO> questions, int i)
        {
            size = questions.Count();
            var question = questions.ElementAt(i);
            var alternatives = GetAlternatives(question.Id);
            var images = GetImageQuestion(question.Id);
            var imageSize = images.Count();
            
            Title = question.Title;

            BoxView boxView = GetBoxView();
            Label lblTexto = GetTextLabel(question);
            ScrollView scrollView = new ScrollView();
            
            //Geral
            StackLayout buttonsLayout = new StackLayout();
            buttonsLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
            buttonsLayout.VerticalOptions = LayoutOptions.EndAndExpand;
            buttonsLayout.Orientation = StackOrientation.Vertical;
            buttonsLayout.Margin = 4;
            buttonsLayout.Children.Add(boxView);

            StackLayout button1Layout = new StackLayout();
            button1Layout.HorizontalOptions = LayoutOptions.Center;
            button1Layout.Orientation = StackOrientation.Horizontal;

            StackLayout button2Layout = new StackLayout();
            button2Layout.HorizontalOptions = LayoutOptions.Center;
            button2Layout.Orientation = StackOrientation.Horizontal;
            int aux = 0;
            foreach (var alternative in alternatives)
            {
                Button alternativeButton = GetAlternativeButton(alternative.Text, alternative.IsCorrectAlternative, questions, i);
                button1Layout.Children.Add(alternativeButton);

                if (aux > 1)
                {
                    button2Layout.Children.Add(alternativeButton);
                }
                aux++;
            }

            contentStackLayout.Children.Add(lblTexto);
            buttonsLayout.Children.Add(button1Layout);
            buttonsLayout.Children.Add(button2Layout);
            if (imageSize >0)
            {
                foreach(var image in images)
                {
                    StackLayout imageLayout = new StackLayout();
                    imageLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    var imageItem = new Image();
                    imageItem.WidthRequest = 100;
                    imageItem.HeightRequest = 100;
                    //imageItem.Source = $"http://juliadev-001-site1.itempurl.com/images/ask_quest4_easy_logic.png";
                    imageItem.Source = ImageSource.FromUri(new Uri(image.Url));
                    imageLayout.Children.Add(imageItem);
                    contentStackLayout.Children.Add(imageLayout);
                }
                
            }
            contentStackLayout.Children.Add(buttonsLayout);
            scrollView.Content = contentStackLayout;
            Content = scrollView;
        }

        private Button GetSolutionButton(QuestionDTO question)
        {
            var solutionButton = new Button()
            {
                Style = (Style)Application.Current.Resources["btnFuncoes"],
                Text = "Solução",
            };
            solutionButton.Clicked += (sender, args) => SolutionButton_Clicked(sender, args, question);
            return solutionButton;
        }

        private Button GetNextButton(IEnumerable<QuestionDTO> questions, int i)
        {
            var nextButton = new Button()
            {
                Style = (Style)Application.Current.Resources["btnFuncoes"],
                Text = "Próxima questão",
            };
            nextButton.Clicked += (sender, args) => NextButton_Clicked(sender, args, questions, i);

            return nextButton;
        }

        private void SolutionButton_Clicked(object sender, EventArgs e, QuestionDTO question)
        {
            int id = question.Id;
            var solution = GetSolution(id);
            this.Navigation.PushModalAsync(new SolutionPage(solution));
        }

        private void NextButton_Clicked(object sender, EventArgs e, IEnumerable<QuestionDTO> questions, int i)
        {
            
            if (i == size - 1)
            {
                //chama a pagina de finalização
                App.Current.MainPage = new NavigationPage(new EndLevelView());
            }
            else
            {
                i++;
                QuestionPage newPage = new QuestionPage(questions, i);
                App.Current.MainPage = new NavigationPage(newPage);
            }
            
        }

        private BoxView GetBoxView()
        {
            return new BoxView
            {
                BackgroundColor = Color.FromHex("#502080"),
                HeightRequest = 2,
                WidthRequest = 300,
                Margin = 8,
            };
        }

        private Button GetAlternativeButton(string text, bool isCorrectAlternative, IEnumerable<QuestionDTO> questions, int i)
        {
            var alternativeButton = new Button
            {
                Text = text,
                Style = (Style)Application.Current.Resources["btnAlternativaQuestoesF"],
                
            };
            if (isCorrectAlternative)
                alternativeButton.Clicked += (sender, args) => CorrectAlternativeButton_Clicked(sender, args, questions, i);
            else
                alternativeButton.Clicked += IncorrectAlternativeButton_Clicked;

            return alternativeButton;
        }

        private void CorrectAlternativeButton_Clicked(object sender, EventArgs e, IEnumerable<QuestionDTO> questions, int i)
        {
            DisplayAlert("Aviso", "Alternativa Correta. Parabéns!", "OK");
            var question = questions.ElementAt(i);
            Button solution = GetSolutionButton(question);
            Button next = GetNextButton(questions, i);
            contentStackLayout.Children.Add(solution);
            contentStackLayout.Children.Add(next);
        }

        private void IncorrectAlternativeButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Aviso", "Alternativa errada! Tente novamente.", "OK");
        }

        private Label GetTextLabel(QuestionDTO question)
        {
            return new Label
            {
                Text = question.Text,
                FontSize = 16,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = 8,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
        }


        #region GetSolution
        private IEnumerable<SolutionDTO> GetSolution(int questionId)
        {
            var solutionService = new SolutionService(StoreVarsHelper.UserToken);
            return solutionService.GetAllByQuestionId(questionId);
        }
        #endregion

        #region GetAlternatives (AlternativeService)
        private IEnumerable<AlternativeDTO> GetAlternatives(int questionId)
        {
            var alternativeService = new AlternativeService(StoreVarsHelper.UserToken);
            return alternativeService.GetAllById(questionId);
        }
        #endregion

        #region GetImageQuestion
        private IEnumerable<ImageQuestionDTO> GetImageQuestion(int questionId)
        {
            var imageQuestionService = new ImageQuestionService(StoreVarsHelper.UserToken);
            return imageQuestionService.GetAllByQuestionId(questionId);
        }
        #endregion

    }
}
