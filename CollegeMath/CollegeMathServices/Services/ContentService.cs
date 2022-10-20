using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CollegeMathServices.Services
{
    public class ContentService : ServiceBase
    {
        public ContentService(string token) : base(token)
        {

        }

        #region GetAll de Contents
        //Método GET dos conteúdos para a tela da HOME
        public IEnumerable<ContentDTO> GetAll()
        {
            var result = HttpClient.GetStringAsync(urlApi + "Contents");
            result.Wait();
            var response = result.Result;
            return JsonConvert.DeserializeObject<IEnumerable<ContentDTO>>(response);
        }
        #endregion
    }
}