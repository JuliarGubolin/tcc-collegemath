using CollegeMathServices.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CollegeMathServices.Services
{
    public class ImageSolutionService : ServiceBase
    {
        public ImageSolutionService(string token) : base(token)
        {

        }
        #region GetAllById de imagens
        public IEnumerable<ImageSolutionDTO> GetAllBySolutionId(int solutionId)
        {
            var result = HttpClient.GetStringAsync(urlApi + "ImageSolution");
            result.Wait();
            var response = result.Result;
            IEnumerable<ImageSolutionDTO> allQuestions = JsonConvert.DeserializeObject<IEnumerable<ImageSolutionDTO>>(response);
            return allQuestions.Where(c => c.SolutionId == solutionId);
        }
        #endregion
    }
}
