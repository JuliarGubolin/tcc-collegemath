using CollegeMath.App.Helpers;
using CollegeMathServices.DTOs;
using CollegeMathServices.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMath.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogicHomeView : ContentPage
    {
        public LogicHomeView()
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
                if(level.Name.Equals("Nível 1"))
                    button.Clicked += btnNivel1_Clicked;

                if (level.Name.Equals("Nível 2"))
                    button.Clicked += btnNivel2_Clicked;

                if (level.Name.Equals("Nível 3"))
                    button.Clicked += btnNivel3_Clicked;

                stkLevels.Children.Add(button);
            }
        }

        private IEnumerable<LevelDTO> GetLevels()
        {
            return new LevelService(StoreVarsHelper.UserToken).GetAll();
        }

        private void btnNivel1_Clicked(object sender, EventArgs e)
        {

        }

        private void btnNivel2_Clicked(object sender, EventArgs e)
        {

        }

        private void btnNivel3_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAjudaLogic_Clicked(object sender, EventArgs e)
        {

        }
    }
}