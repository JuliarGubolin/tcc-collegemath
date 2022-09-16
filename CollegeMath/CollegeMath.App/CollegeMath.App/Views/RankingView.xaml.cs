
using CollegeMath.App.Helpers;
using CollegeMathServices.Services;
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
            GenerateRanking();
            
            //_listUsers = new ObservableCollection<Users>();
            //listUser.Add(usuario da lista)
        }

        public void GenerateRanking()
        {
            var rankring = new UserQuestionHistoryService(StoreVarsHelper.UserToken).GetUsersRanking(3);
            foreach (var userRanking in rankring)
            {
                //userRanking.UserName;
                //userRanking.UserScore
            }
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