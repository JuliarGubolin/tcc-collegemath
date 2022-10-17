using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;

namespace CollegeMath.Infra.Repositories
{
    public class ImageSolutionRepository : IImageSolutionRepository
    {
        private readonly CollegeMathContext _collegeMathContext;
        public ImageSolutionRepository(CollegeMathContext collegeMathContext)
        {
            _collegeMathContext = collegeMathContext;
        }
        public void Insert(ImageSolution imageSolution)
        {
            _collegeMathContext.ImageSolution.Add(imageSolution);
        }
        public IEnumerable<ImageSolution> GetAll()
        {
            return _collegeMathContext.ImageSolution.Where(c => !c.IsDeleted).ToList();
        }
    }
}
