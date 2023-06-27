﻿using CollegeMath.App.Helpers;
using CollegeMathServices.DTOs;
using CollegeMathServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMath.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndLevelView : ContentPage
    {
        public EndLevelView(int level, int content)
        {
            InitializeComponent();
            //var scoreDTO = GetUserScore();
            Button finish = getButtonFinish(level, content);
            //var scores = g
            //var score = scores.ElementAt(0);
            //Label lblPontos = new Label();
            //lblPontos.Text = "Pontuação atual: "+score.UserScore;
            //tkButonFinish.Children.Add(lblPontos);
            stkButonFinish.Children.Add(finish);
        }
        //private IEnumerable<UserScoreDTO> GetScore()
        //{
        //    var scoreService = new UserScoreService(StoreVarsHelper.UserToken);
        //    return scoreService.GetAll();
        //}
        private Button getButtonFinish(int level, int content)
        {
            var finish = new Button
            {
                FontSize = 16,
                Text = "Finalizar",
                BorderColor = Color.FromHex("#502080"),
                Style = (Style)Application.Current.Resources["btnNiveis"],

            };
            finish.Clicked += (sender, args) => btnFinish_Clicked(sender, args, level, content);
            return finish;
        }
        #region GetSolution
        private void GetUserScore()
        {
            var scoreService = new UserScoreService(StoreVarsHelper.UserToken).GetAll();
            var score = scoreService.ToString();
            lblPoints.Text = score;
            //lblPoints.Text = $"Sua pontuação atual é {scoreService.ToString().}";
        }
        #endregion

        private void btnFinish_Clicked(object sender, EventArgs e, int level, int content)
        {
            App.Current.MainPage = new NavigationPage(new HomeView());
        }
    }
}