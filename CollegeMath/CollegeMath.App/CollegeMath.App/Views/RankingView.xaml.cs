
using CollegeMath.App.Helpers;
using CollegeMathServices.DTOs;
using CollegeMathServices.Services;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMath.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RankingView : ContentPage
    {
        public RankingView()
        {
            InitializeComponent();
            GenerateRanking();
        }

        public void GenerateRanking()
        {
            var ranking = new UserQuestionHistoryService(StoreVarsHelper.UserToken).GetUsersRanking(5);
            listUser.ItemsSource = ranking;
        }
    }
}