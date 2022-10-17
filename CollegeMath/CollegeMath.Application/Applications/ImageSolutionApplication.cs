using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Interfaces;

namespace CollegeMath.Application.Applications
{
    public class ImageSolutionApplication : IImageSolutionApplication
    {
        private readonly IImageSolutionRepository _imageSolutionRepository;
        public ImageSolutionApplication(IImageSolutionRepository imageSolutionRepository)
        {
            _imageSolutionRepository = imageSolutionRepository;
        }
        public void Insert(ImageSolutionDTO imageSolutionDTO)
        {
            var imageSolution = new ImageSolution
            {
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                SolutionId = imageSolutionDTO.SolutionId,
                Url = imageSolutionDTO.Url
            };
            _imageSolutionRepository.Insert(imageSolution);
        }
        public IEnumerable<ImageSolutionDTO> GetAll()
        {
            return _imageSolutionRepository.GetAll().Select(c => new ImageSolutionDTO
            {
                Id = c.Id,
                CreatedDate = c.CreatedDate,
                SolutionId = c.SolutionId,
                Url = c.Url
            });
        }
    }
}
