﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMath.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Level1_Function : ContentPage
    {
        public Level1_Function()
        {
            InitializeComponent();
        }

        private async void btnVerificar_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new SolutionView());
        }
    }
}