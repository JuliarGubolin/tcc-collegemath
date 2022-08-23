using AndroidX.Preference;
using CollegeMath.App.Droid.Helpers;
using CollegeMath.App.Helpers;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(SharedPreferencesHelper))]
namespace CollegeMath.App.Droid.Helpers
{
    public class SharedPreferencesHelper : Interfaces.ISharedPreferences
    {
        public string GetUserToken()
        {
            Android.Content.ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);

            var json = prefs.GetString("accessToken", null);

            if (json == null)
                return null;

            prefs.Dispose();
            var accessObject = JsonConvert.DeserializeObject<AccessTokenHelper>(json);
            if(DateTime.Now > accessObject.ExpirationDate)
                return null;

            return accessObject.Token;
        }

        public void SaveUserToken(string token)
        {
            var accessObject = new AccessTokenHelper
            {
                Token = token,
                ExpirationDate = DateTime.Now.AddDays(14)
            };
            var json = JsonConvert.SerializeObject(accessObject);
            Android.Content.ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            Android.Content.ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("accessToken", json);
            editor.Apply();
            editor.Commit();

            editor.Dispose();
            prefs.Dispose();
        }
    }
}