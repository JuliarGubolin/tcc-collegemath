using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeMathServices.Services
{
    public class SolutionService : ServiceBase
    {
        public SolutionService(string token) : base(token)
        {

        }

        #region GetAll de Soluções
        //Método GET dos conteúdos para a tela da HOME
        public IEnumerable<SolutionDTO> GetAllByQuestionId(int questionId)
        {
            var result = HttpClient.GetStringAsync(urlApi + "Solutions");
            result.Wait();
            var response = result.Result;
            IEnumerable<SolutionDTO> allSolutionQuestionId = JsonConvert.DeserializeObject<IEnumerable<SolutionDTO>>(response);
            return allSolutionQuestionId.Where(c => c.QuestionId == questionId);
        }
        #endregion
    }
}
