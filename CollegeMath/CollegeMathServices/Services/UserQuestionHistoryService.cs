using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> UserScorePost(int alternativeId, string userId)
        {
            bool success = false;
            var requestObject = new
            {
                alternativeId = alternativeId,
                userId = userId,
                answeredIn = DateTime.Now,
                createdDate = DateTime.Now,
                isDeleted = false
            };
            var json = JsonConvert.SerializeObject(requestObject);
            var response = await HttpClient.PostAsync(urlApi + "UserQuestionHistory", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                success = true;

            return success;
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
