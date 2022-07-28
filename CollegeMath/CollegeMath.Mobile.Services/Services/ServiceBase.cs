using System.Net.Http.Headers;

namespace CollegeMath.Mobile.Services.Services
{
    public class ServiceBase
    {
        protected string urlApi = "http://juliadev-001-site1.itempurl.com/api/";
        protected string _token;
        private HttpClient _httpClient;

        public ServiceBase()
        {

        }

        public ServiceBase(string token)
        {
            _token = token;
        }

        public HttpClient Httplicent
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

        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}