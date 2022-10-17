using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<QuestionDTO>> GetAllById(int ContentId, int LevelId)
        {
            var request = new
            {
                contentId = ContentId,
                levelId = LevelId,
            };
            var json = JsonConvert.SerializeObject(request);
            var result = await HttpClient.PostAsync(urlApi + "Questions/getall", new StringContent(json, Encoding.UTF8, "application/json"));
            if (!result.IsSuccessStatusCode)
                return null;
            
            var response = await result.Content.ReadAsStringAsync();
            IEnumerable<QuestionDTO> allQuestions = JsonConvert.DeserializeObject<IEnumerable<QuestionDTO>>(response);
            return allQuestions;
        }
        #endregion
    }
}
