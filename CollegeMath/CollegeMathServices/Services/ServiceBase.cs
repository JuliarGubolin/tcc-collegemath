using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CollegeMathServices.Services
{
    //Base para chamar as APIs
    public class ServiceBase
    {
        #region Variáveis da Classe
        //URL da API
        protected string urlApi = "http://juliadev-001-site1.itempurl.com/api/";
        protected string _token;
        //Faz as requisições
        private HttpClient _httpClient;
        #endregion

        #region Construtor vazio
        public ServiceBase()
        {

        }
        #endregion

        #region Contrutor que recebe Token
        public ServiceBase(string token)
        {
            _token = token;
        }
        #endregion

        #region Requisição da WebAPI
        public HttpClient HttpClient
        {
            get
            {
                _httpClient = _httpClient ?? new HttpClient
                (
                    new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                        {
                            //bypass
                            return true;
                        },
                    }
                    , false
                )
                {
                    BaseAddress = new Uri("http://juliadev-001-site1.itempurl.com/api/"),
                };

                if (!string.IsNullOrWhiteSpace(_token))
                {
                    this.SetToken(_token);
                }

                // In case you need to send an auth token...
                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "YOUR_TOKEN");
                return _httpClient;
            }
        }
        #endregion

        #region Setar Token
        //Método para settar o token
        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
        #endregion
    }
}