using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeMathServices.Services
{
    public class ImageQuestionService : ServiceBase
    {
        public ImageQuestionService(string token) : base(token)
        {

        }
        #region GetAllById de imagens
        public IEnumerable<ImageQuestionDTO> GetAllByQuestionId(int questionId)
        {
            var result = HttpClient.GetStringAsync(urlApi + "ImageQuestion");
            result.Wait();
            var response = result.Result;
            IEnumerable<ImageQuestionDTO> allQuestions = JsonConvert.DeserializeObject<IEnumerable<ImageQuestionDTO>>(response);
            return allQuestions.Where(c => c.QuestionId == questionId);
        }
        #endregion
    }
}
