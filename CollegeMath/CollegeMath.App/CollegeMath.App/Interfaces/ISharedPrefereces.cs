namespace CollegeMath.App.Interfaces
{
    public interface ISharedPreferences
    {
        string GetUserToken();

        void SaveUserToken(string token);
    }
}
