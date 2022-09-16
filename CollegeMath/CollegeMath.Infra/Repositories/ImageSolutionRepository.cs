using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;

namespace CollegeMath.Infra.Repositories
{
    public class ImageSolutionRepository : IImageSolutionRepository
    {
        private readonly CollegeMathContext _context;
        public ImageSolutionRepository(CollegeMathContext collegeMathContext)
        {
            _context = collegeMathContext;
        }
        public void Insert(ImageSolution imageSolution)
        {
            _context.ImageSolution.Add(imageSolution);
        }
    }
}
