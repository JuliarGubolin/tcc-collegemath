using CollegeMath.App.Helpers;
using CollegeMathServices.DTOs;
using CollegeMathServices.Services;
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
    public partial class RankingView : ContentPage
    {
        //ObservableCollection<Users> _listUsers;
        public RankingView()
        {
            InitializeComponent();
            //_listUsers = new ObservableCollection<Users>();
            //listUser.Add(usuario da lista)
        }

        //private void CreateListUsers(IEnumerable<ContentDTO> contents)
        //{
            
        //}

        //Recebe da classe ContentServices os conteúdos baseados no token de autenticação
        //private IEnumerable<ContentDTO> GetUser()
        //{
            
        //}
    }
}