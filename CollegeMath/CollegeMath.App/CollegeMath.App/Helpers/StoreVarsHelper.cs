using Xamarin.Forms;

namespace CollegeMath.App.Helpers
{
    public static class StoreVarsHelper
    {
        //Criando uma classe para generalizar a chamada do Token
        //Já verifica se é nulo ou se possui informações
        private static string _token;
        public static string UserToken
        {
            //Editando o get e o set do atributo da classe
            get
            {
                if (string.IsNullOrEmpty(_token))
                {
                    Interfaces.ISharedPreferences sharedPreferences = DependencyService.Get<Interfaces.ISharedPreferences>();
                    string token = sharedPreferences.GetUserToken();
                    return token;
                }
                else
                    return _token;
            }
            set 
            {
                _token = value;
            }
        }
    }
}
