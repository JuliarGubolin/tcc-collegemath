using CollegeMathServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CollegeMath.App.Views.ClassesContentPage
{
    public partial class QuestionPage : ContentPage
    {
        int i = 0;
        public QuestionPage(IEnumerable<QuestionDTO> questions, IEnumerable<AlternativeDTO> alternatives, int i)
        {
            Title = "ddsd";

            var size = questions.Count();
            var question = questions.ElementAt(i);
            List<AlternativeDTO> questionAlternatives = new List<AlternativeDTO>();
            foreach (AlternativeDTO alternative in alternatives)
            {
                if (alternative.QuestionId == question.Id)
                {
                    alternative.Text = Guid.NewGuid().ToString().Substring(0, 8);
                    questionAlternatives.Add(alternative);
                }
            }

            //Button answerButton = GetAnswerButton();
            BoxView boxView = GetBoxView();

            Label lblTitulo = GetQuestionLabel(question);
            Label lblTexto = GetTextLabel(question);

            var contentStackLayout = new StackLayout();
            contentStackLayout.Children.Add(lblTitulo);
            contentStackLayout.Children.Add(boxView);
            foreach (var alternative in questionAlternatives)
            {
                Button alternativeButton = GetAlternativeButton(alternative.Text, alternative.IsCorrectAlternative);
                contentStackLayout.Children.Add(alternativeButton);
            }

            //contentStackLayout.Children.Add(answerButton);
            Content = contentStackLayout;
        }

        private Button GetAnswerButton()
        {
            var verificarButton = new Button()
            {
                Style = (Style)Application.Current.Resources["btnFuncoes"],
                Text = "Verificar",

            };
            //verificarButton.Clicked += (sender, args) => btn_Verificar(questions, alternatives, i);
            return verificarButton;
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

        private Button GetAlternativeButton(string text, bool isCorrectAlternative)
        {
            var alternativeButton = new Button
            {
                Text = text,
                Style = (Style)Application.Current.Resources["btnAlternativaQuestoesF"],
            };
            if(isCorrectAlternative)
                alternativeButton.Clicked += CorrectAlternativeButton_Clicked;
            else
                alternativeButton.Clicked += IncorrectAlternativeButton_Clicked;

            return alternativeButton;
        }

        private void CorrectAlternativeButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Aviso", "Legal você acertou :)", "OK");
        }

        private void IncorrectAlternativeButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Aviso", "Pô, errou mermão :(", "OK");
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
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
        }

        private Label GetQuestionLabel(QuestionDTO question)
        {
            return new Label
            {
                Text = question.Text,
                FontSize = 32,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = 8,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
        }

        public void btn_Verificar(IEnumerable<QuestionDTO> questions, IEnumerable<AlternativeDTO> alternatives, int i)
        {
            i++;
            //Level1_FunctionView teste = new Level1_FunctionView();
            QuestionPage newPage = new QuestionPage(questions, alternatives, i);
        }
    }
}
