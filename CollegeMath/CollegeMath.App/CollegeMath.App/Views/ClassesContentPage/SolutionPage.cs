using CollegeMath.App.Helpers;
using CollegeMathServices.DTOs;
using CollegeMathServices.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CollegeMath.App.Views.ClassesContentPage
{
    public class SolutionPage : ContentPage
    {
        public SolutionPage(IEnumerable<SolutionDTO> solutions)
        {
            var solution = solutions.ElementAt(0);
            StackLayout stkPrincipal = new StackLayout();
            StackLayout stkTitle = new StackLayout();
            StackLayout solutionText = new StackLayout();
            Label title = GetTitleLabel(solution);
            Label text = GetTextLabel(solution);

            
            BoxView boxView = GetBoxView();
            ScrollView scrollView = new ScrollView();

            stkTitle.Children.Add(title);
            stkTitle.Children.Add(boxView);
            solutionText.Children.Add(text);
            stkPrincipal.Children.Add(stkTitle);
            if (!solution.Text.Contains("https") || !solution.Text.Contains("http"))
            {
                stkPrincipal.Children.Add(solutionText);
            }
            var images = GetImageSolution(solution.Id);
            var imageSize = images.Count();
            if(imageSize > 0)
            {
                foreach (var image in images)
                {
                    StackLayout imageLayout = new StackLayout();
                    imageLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    var imageItem = new ImageButton();
                    imageItem.WidthRequest = 200;
                    imageItem.HeightRequest = 100;
                    imageItem.Source = image.Url;
                    imageLayout.Children.Add(imageItem);
                    stkPrincipal.Children.Add(imageLayout);
                }
            }
            if (solution.Text.Contains("https") || solution.Text.Contains("http"))
            {
                Button btnLink = GetButtonLinkSolution(solution);
                stkPrincipal.Children.Add(btnLink);
            }
            scrollView.Content = stkPrincipal;
            BackgroundColor = Color.FromHex("#202060");
            Content = scrollView;

        }
        private Button GetButtonLinkSolution(SolutionDTO solution)
        {
            Button btnLink = new Button();
            btnLink.BackgroundColor = Color.FromHex("#202060");
            btnLink.BorderColor = Color.FromHex("#2b2b80");
            btnLink.BorderWidth = 2;
            btnLink.CornerRadius = 4;
            btnLink.Text = "Resolução (clique aqui)";
            btnLink.TextTransform = TextTransform.None;
            btnLink.Margin = 16;
            string textBotao = "";
            for (int i = 0; i < solution.Text.Length; i++)
            {
                textBotao = textBotao + String.Concat(solution.Text[i]);
            }
            btnLink.Clicked += (sender, args) => ButtonLink_Clicked(sender, args, textBotao);
            return btnLink;
        }

        private async void ButtonLink_Clicked(object sender, EventArgs args, string textBotao)
        {
            try
            {
                await Browser.OpenAsync(textBotao, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                await DisplayAlert("Aviso", "Erro: não foi possível abrir link com a resolução! Verifique se possui um navegador instalado.", "OK");
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
        private Label GetTitleLabel(SolutionDTO solution)
        {
            return new Label
            {
                Text = solution.Title,
                FontSize = 32,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = 8,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
        }
        private Label GetTextLabel(SolutionDTO solution)
        {
            return new Label
            {
                Text = solution.Text,
                FontSize = 16,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = 8,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
        }
        #region GetImageSolution
        private IEnumerable<ImageSolutionDTO> GetImageSolution(int solutionId)
        {
            var imageSolutionService = new ImageSolutionService(StoreVarsHelper.UserToken);
            return imageSolutionService.GetAllBySolutionId(solutionId);
        }
        #endregion

    }
}
