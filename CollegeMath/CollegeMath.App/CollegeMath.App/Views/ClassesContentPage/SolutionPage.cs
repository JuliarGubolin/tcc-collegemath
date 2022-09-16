using CollegeMath.App.Helpers;
using CollegeMathServices.DTOs;
using CollegeMathServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
           var images = GetImageSolution(solution.Id);
           var imageSize = images.Count();

            Label title = GetTitleLabel(solution);
            Label text = GetTextLabel(solution);
            BoxView boxView = GetBoxView();
            ScrollView scrollView = new ScrollView();

            stkTitle.Children.Add(title);
            stkTitle.Children.Add(boxView);
            solutionText.Children.Add(text);
            stkPrincipal.Children.Add(stkTitle);
            stkPrincipal.Children.Add(solutionText);

            if (imageSize > 0)
            {
                foreach (var image in images)
                {
                    StackLayout imageLayout = new StackLayout();
                    imageLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    var imageItem = new ImageButton();
                    imageItem.WidthRequest = 50;
                    imageItem.HeightRequest = 50;
                    imageItem.Source = image.Url;
                    imageLayout.Children.Add(imageItem);
                    stkPrincipal.Children.Add(imageLayout);
                }

            }

            scrollView.Content = stkPrincipal;
            BackgroundColor = Color.FromHex("#202060");
            Content = scrollView;

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
