using Xamarin.Forms;

namespace CollegeMath.App.Helpers
{
    public static class StoreVarsHelper
    {
        private static string _token;
        public static string UserToken
        {
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
