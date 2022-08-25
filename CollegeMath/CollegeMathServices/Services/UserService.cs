using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMathServices.Services
{
    //Classe para controle dologin e cadastro do usuário
    public class UserService : ServiceBase
    {
        public UserService()
        {

        }

        #region Login
        //Login chamando a API
        public async Task<string> LoginAsync(string email, string password)
        {
            //Inicializando o Token
            string token = null;
            //Criando um objeto anônimo, ou seja, não é tipado (respeita o que está dentro dele)
            var requestObject = new
            {
                Email = email,
                Password = password
            };
            //Serializando o objeto acima para JSON
            var json = JsonConvert.SerializeObject(requestObject);
            //Passando o JSON para a API
            var response = await HttpClient.PostAsync(urlApi + "auth/entrar", new StringContent(json, Encoding.UTF8, "application/json"));
            //Caso o login aconteça com sucesso, recebo o token e envio para a aplicação
            if (response.IsSuccessStatusCode)
                //Lê o conteúdo da resposta como String
                token = await response.Content.ReadAsStringAsync();

            return token;
        }
        #endregion

        #region Cadastro
        public async Task<bool> RegisterAsync(string email, string password, string name)
        {
            bool success = false;
            //Objeto anonimo com as informações de cadastro
            var requestObject = new
            {
                Email = email,
                Password = password,
                Name = name,
                ConfirmPassword = password
            };
            var json = JsonConvert.SerializeObject(requestObject);
            var response = await HttpClient.PostAsync(urlApi + "auth/nova-conta", new StringContent(json, Encoding.UTF8, "application/json")); // Tem que passar o mediatype pra não dar erro
            if (response.IsSuccessStatusCode)
                success = true;

            return success;
        }
        #endregion

        #region Alteração de senha
        //Validou o email
        public async Task<bool> SendForgotPasswordEmail(string email)
        {
            bool success = false;
            var requestObject = new
            {
                Email = email
            };
            var json = JsonConvert.SerializeObject(requestObject);
            var response = await HttpClient.PostAsync(urlApi + "auth/email-resetar-senha", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                success = true;

            return success;
        }
        //Validou o código enviado por email
        public async Task<bool> ValidateForgotPasswordCode(string code)
        {
            bool success = false;
            var requestObject = new
            {
                Code = code
            };
            var json = JsonConvert.SerializeObject(requestObject);
            var response = await HttpClient.PostAsync(urlApi + "auth/validar-codigo", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                success = true;

            return success;
        }
        //Valida a troca de senha
        public async Task<bool> ChangeUserPassword(string email, string password)
        {
            bool success = false;
            var requestObject = new
            {
                Email = email,
                Password = password
            };
            var json = JsonConvert.SerializeObject(requestObject);
            var response = await HttpClient.PostAsync(urlApi + "auth/alterar-senha", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                success = true;

            return success;
        }
        #endregion


    }

}
