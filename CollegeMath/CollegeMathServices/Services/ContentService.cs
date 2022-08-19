using CollegeMath.Domain.Entities;
using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMathServices.Services
{
    public class ContentService : ServiceBase
    {
        public ContentService(string token) : base(token)
        {

        }

        public IEnumerable<ContentDTO> GetAll()
        {
            var result = HttpClient.GetStringAsync(urlApi + "Contents");
            result.Wait();
            var response = result.Result;
            return JsonConvert.DeserializeObject<IEnumerable<ContentDTO>>(response);
        }
    }
}