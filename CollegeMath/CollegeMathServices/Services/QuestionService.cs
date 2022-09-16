using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollegeMathServices.Services
{
    public class QuestionService : ServiceBase
    {
        public QuestionService(string token) : base(token)
        {

        }

        #region GetAll de Questions
        //Método GET dos conteúdos para a tela da HOME
        public IEnumerable<QuestionDTO> GetAll()
        {
            var result = HttpClient.GetStringAsync(urlApi + "Questions");
            result.Wait();
            var response = result.Result;
            return JsonConvert.DeserializeObject<IEnumerable<QuestionDTO>>(response);
        }
        #endregion

        #region GetAllById de questões
        public IEnumerable<QuestionDTO> GetAllById(int contentId, int levelId)
        {
            var result = HttpClient.GetStringAsync(urlApi + "Questions");
            result.Wait();
            var response = result.Result;
            IEnumerable<QuestionDTO> allQuestions = JsonConvert.DeserializeObject<IEnumerable<QuestionDTO>>(response);
            return allQuestions.Where(c => c.LevelId == levelId && c.ContentId == contentId);
        }
        #endregion
    }
}
