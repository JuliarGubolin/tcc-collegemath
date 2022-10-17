using CollegeMath.App.Helpers;
using CollegeMath.App.Models.Custom;
using CollegeMathServices.DTOs;
using CollegeMathServices.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CollegeMath.App.Views.ClassesContentPage
{
    class RankingPage : ContentPage
    {
        public RankingPage()
        {
            StackLayout imageStk = new StackLayout();
            imageStk.HorizontalOptions = LayoutOptions.CenterAndExpand;
            imageStk.Orientation = StackOrientation.Vertical;
            imageStk.Margin = 16;

            Image rankingIcon = new Image();
            rankingIcon.Source = "ranking.png";
            rankingIcon.WidthRequest = 50;
            rankingIcon.HeightRequest = 50;

            BoxView boxView = new BoxView();
            boxView.BackgroundColor = Color.FromHex("#5bc8af");
            boxView.WidthRequest = 380;
            boxView.HeightRequest = 2;

            imageStk.Children.Add(rankingIcon);
            imageStk.Children.Add(boxView);
            Label header = new Label
            {
                Text = "As três maiores pontuações estão aqui!",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                Margin = 8
            };

            List<UserRankingDTO> ranking = new UserQuestionHistoryService(StoreVarsHelper.UserToken).GetUsersRanking(3);


            ListView listView = new ListView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasUnevenRows = true,
                ItemsSource = ranking,
                ItemTemplate = new DataTemplate(() =>
                {
                    StackLayout stk = new StackLayout();
                    //stk.Padding = 2;
                    FlexLayout f = new FlexLayout();
                    f.Direction = FlexDirection.Row;
                    f.AlignItems = FlexAlignItems.Center;
                    f.Children.Add(stk);
                    Label nameLabel = new Label();
                    nameLabel.HorizontalTextAlignment = TextAlignment.Center;
                    CustomEmailConverter cust = new CustomEmailConverter();
                    //nameLabel.SetBinding(Label.TextProperty, "UserName", BindingMode.Default, cust);
                    nameLabel.SetBinding(Label.TextProperty, new Binding("UserName", BindingMode.Default, cust, null, "Usuário: {0:d}"));
                    nameLabel.TextColor = Color.White;
                    Label scoreLabel = new Label();
                    scoreLabel.SetBinding(Label.TextProperty, new Binding("UserScore", BindingMode.OneWay,
                                        null, null, "Pontuação: {0:d} pontos"));
                    scoreLabel.TextColor = Color.White;
                    scoreLabel.HorizontalTextAlignment = TextAlignment.Center;
                    stk.Children.Add(nameLabel);
                    stk.Children.Add(scoreLabel);

                    return new ViewCell
                    {

                        View = new Frame
                        {
                            BackgroundColor = Color.FromHex("#2b2b80"),
                            CornerRadius = 12,
                            BorderColor = Color.FromHex("#5bc8af"),
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Margin = 2,
                            Content = f,
                        }
                    };
                })
            };
            BackgroundColor = Color.FromHex("#202060");
            this.Content = new StackLayout
            {
                Children =
                {
                    imageStk,
                    header,
                    listView
                }
            };
        }
    }
}