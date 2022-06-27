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
    public partial class SolutionView : ContentPage
    {
        public SolutionView()
        {
            InitializeComponent();
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new EndLevelView());
        }
    }
}