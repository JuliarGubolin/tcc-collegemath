using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.Services
{
    public class UserQuestionHistoryService  :ServiceBase
    {
        public UserQuestionHistoryService(string token) : base(token)
        {

        }

        public IEnumerable<UserQuestionHistoryDTO> GetAll()
        {
            var result = HttpClient.GetStringAsync(urlApi + "UserQuestionHistory");
            result.Wait();
            var response = result.Result;
            return JsonConvert.DeserializeObject<IEnumerable<UserQuestionHistoryDTO>>(response);
        }

        public UserScoreDTO GetUserScore()
        {
            var result = HttpClient.GetStringAsync(urlApi + "UserQuestionHistory/user-score");
            result.Wait();
            var response = result.Result;
            return JsonConvert.DeserializeObject<UserScoreDTO> (response);
        }

        public List<UserRankingDTO> GetUsersRanking(int quantity)
        {
            var result = HttpClient.GetStringAsync(urlApi + $"UserQuestionHistory/users-ranking/{quantity}");
            result.Wait();
            var response = result.Result;
            return JsonConvert.DeserializeObject<List<UserRankingDTO>>(response);
        }
    }
}
