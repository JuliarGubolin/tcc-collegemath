using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Interfaces;

namespace CollegeMath.Application.Applications
{
    public class SolutionApplication : ISolutionApplication
    {
        private readonly ISolutionRepository _solutionRepository;

        public SolutionApplication(ISolutionRepository solutionRepository)
        {
            _solutionRepository = solutionRepository;
        }
        public void Delete(int id)
        {
            var solution = _solutionRepository.Find(id);
            _solutionRepository.Delete(solution);
        }

        public IEnumerable<SolutionDTO> GetAll()
        {
            return _solutionRepository.GetAll().Select(c => new SolutionDTO
            {
                Id = c.Id,
                //CreatedDate = c.CreatedDate,
                //IsDeleted = c.IsDeleted,
                QuestionId = c.QuestionId,
                Title = c.Title,
                Text = c.Text
            });
        }

        public SolutionDTO GetSolutionByQuestionId(int questionId)
        {
            var solution = _solutionRepository.GetSolutionByQuestionId(questionId);
            var solutionDTO = new SolutionDTO
            {
                Id = solution.Id,
                //CreatedDate = solution.CreatedDate,
                //IsDeleted = solution.IsDeleted,
                QuestionId = solution.QuestionId,
                Title = solution.Title,
                Text = solution.Text
            };

            //if (solution.Images != null && solution.Images.Count > 0)
            //{
            //    solutionDTO.Image = new ImageSolutionDTO 
            //    {
            //       Url = solution?.Images?.FirstOrDefault()?.Url
            //    };
            //}

            return solutionDTO;
        }

        public void Insert(SolutionDTO solutionDTO)
        {
            var solution = new Solution
            {
                CreatedDate = DateTime.Now,
                QuestionId = solutionDTO.QuestionId,
                Title = solutionDTO.Title,
                Text=solutionDTO.Text,
                IsDeleted = false
            };
            _solutionRepository.Insert(solution);
        }

        public void Update(SolutionDTO solutionDTO)
        {
            var solution = _solutionRepository.Find(solutionDTO.Id);
            solution.QuestionId = solutionDTO.QuestionId;
            solution.Title = solutionDTO.Title;
            solution.Text = solutionDTO.Text;
            _solutionRepository.Update(solution);
        }
    }
}
