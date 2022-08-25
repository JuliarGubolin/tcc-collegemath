using AndroidX.Preference;
using CollegeMath.App.Droid.Helpers;
using CollegeMath.App.Helpers;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;

//??
[assembly: Dependency(typeof(SharedPreferencesHelper))]
namespace CollegeMath.App.Droid.Helpers
{
    //Lê o armazenamento local do aplicativo para devolver o token
    //Inplementa a interface que está no CollegeMath.App
    public class SharedPreferencesHelper : Interfaces.ISharedPreferences
    {
        #region ObterToken
        public string GetUserToken()
        {
            Android.Content.ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);

            var json = prefs.GetString("accessToken", null);

            //Se não houver token, retorna nullo para ir para Login e não para Home
            if (json == null)
                return null;

            prefs.Dispose();
            var accessObject = JsonConvert.DeserializeObject<AccessTokenHelper>(json);
            if (accessObject == null)
                return null;

            //Se já tiver passado do tempo de expiração, retorna nullo para ir para Login e não para Home
            if(DateTime.Now > accessObject.ExpirationDate)
                return null;

            return accessObject.Token;
        }
        #endregion

        #region LogOut
        public void Logout()
        {
            //Irá colocar o token atual como nulo
            Android.Content.ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            Android.Content.ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("accessToken", string.Empty);
            editor.Apply();
            editor.Commit();

            editor.Dispose();
            prefs.Dispose();
        }
        #endregion

        #region Armazenar token
        public void SaveUserToken(string token)
        {
            //Objeto da classe AcessTokenHelper (possui o token e a data de expiração)
            var accessObject = new AccessTokenHelper
            {
                Token = token,
                //Aumenta a data de expiração do token
                ExpirationDate = DateTime.Now.AddDays(14)
            };
            //JSON atual do usuário
            var json = JsonConvert.SerializeObject(accessObject);
            //AndroidX pois estava obsoleto o Android só
            Android.Content.ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            Android.Content.ISharedPreferencesEditor editor = prefs.Edit();
            //Atualiza o token
            editor.PutString("accessToken", json);
            editor.Apply();
            editor.Commit();

            editor.Dispose();
            prefs.Dispose();
        }
        #endregion
    }
}