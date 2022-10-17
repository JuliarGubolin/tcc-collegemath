using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.Services
{
    public class UserScoreService : ServiceBase
    {
        public UserScoreService(string token) : base(token)
        {

        }
        public IEnumerable<UserScoreDTO> GetAll()
        {
            var result = HttpClient.GetStringAsync(urlApi + "UserQuestionHistory/user-score");
            result.Wait();
            var response = result.Result;
            IEnumerable<UserScoreDTO> score = JsonConvert.DeserializeObject<IEnumerable<UserScoreDTO>>(response);
            return score;
        }
    }
}
