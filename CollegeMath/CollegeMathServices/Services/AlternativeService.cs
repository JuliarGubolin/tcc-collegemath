using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeMathServices.Services
{
    public class AlternativeService : ServiceBase
    {
        public AlternativeService(string token) : base(token)
        {

        }

        #region GetAll de Alternatives
        //Método GET dos conteúdos para a tela da HOME
        public IEnumerable<AlternativeDTO> GetAll()
        {
            var result = HttpClient.GetStringAsync(urlApi + "Alternatives");
            result.Wait();
            var response = result.Result;
            return JsonConvert.DeserializeObject<IEnumerable<AlternativeDTO>>(response);
        }
        #endregion

        #region GetAllById de alternativas
        public IEnumerable<AlternativeDTO> GetAllById(int questionId)
        {
            var result = HttpClient.GetStringAsync(urlApi + "Alternatives");
            result.Wait();
            var response = result.Result;
            IEnumerable<AlternativeDTO> allQuestions = JsonConvert.DeserializeObject<IEnumerable<AlternativeDTO>>(response);
            return allQuestions.Where(c => c.QuestionId == questionId);
        }
        #endregion
    }
}
