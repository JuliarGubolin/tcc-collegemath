using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.Services
{
    public class QuestionService : ServiceBase
    {
        public QuestionService(string token) : base(token)
        {

        }

        #region GetAll de Contents
        //Método GET dos conteúdos para a tela da HOME
        public IEnumerable<QuestionDTO> GetAll()
        {
            var result = HttpClient.GetStringAsync(urlApi + "Questions");
            result.Wait();
            var response = result.Result;
            return JsonConvert.DeserializeObject<IEnumerable<QuestionDTO>>(response);
        }
        #endregion
    }
}
