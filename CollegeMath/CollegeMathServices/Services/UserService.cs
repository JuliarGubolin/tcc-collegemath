using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMathServices.Services
{
    public class UserService : ServiceBase
    {
        public async Task<string> LoginAsync(string email, string password)
        {
            string token = null;
            var requestObject = new
            {
                Email = email,
                Password = password
            };
            var json = JsonConvert.SerializeObject(requestObject);
            var response = await HttpClient.PostAsync(urlApi + "auth/entrar", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                token = await response.Content.ReadAsStringAsync();

            return token;
        }

        public async Task<bool> RegisterAsync(string email, string password, string name)
        {
            bool success = false;
            var requestObject = new
            {
                Email = email,
                Password = password,
                Name = name,
                ConfirmPassword = password
            };
            var json = JsonConvert.SerializeObject(requestObject);
            var response = await HttpClient.PostAsync(urlApi + "auth/nova-conta", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                success = true;

            return success;
        }
    }
}
