using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CollegeMathServices.Services
{
    public class LevelService : ServiceBase
    {
        public LevelService(string token) : base(token)
        {

        }

        public IEnumerable<LevelDTO> GetAll()
        {
            var result = HttpClient.GetStringAsync(urlApi + "Level");
            result.Wait();
            var response = result.Result;
            return JsonConvert.DeserializeObject<IEnumerable<LevelDTO>>(response);
        }
    }
}
