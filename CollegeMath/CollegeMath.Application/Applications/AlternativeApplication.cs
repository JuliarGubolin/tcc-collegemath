using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Interfaces;

namespace CollegeMath.Application.Applications
{
    public class AlternativeApplication : IAlternativeApplication
    {
        private readonly IAlternativeRepository _alternativeRepository;

        public AlternativeApplication(IAlternativeRepository alternativeRepository)
        {
            _alternativeRepository = alternativeRepository;
        }

        public void Delete(int id)
        {
            var alternative = _alternativeRepository.Find(id);
            _alternativeRepository.Delete(alternative);
        }

        public IEnumerable<AlternativeDTO> GetAll()
        {
            return _alternativeRepository.GetAll().Select(c => new AlternativeDTO
            {
                Id = c.Id,
                IsCorrectAlternative = c.IsCorrectAlternative,
                QuestionId = c.QuestionId,
                Text = c.Text
            });
        }

        public void Insert(AlternativeDTO alternativeDTO)
        {
            var alternative = new Alternative
            {
                CreatedDate = DateTime.Now,
                IsCorrectAlternative = alternativeDTO.IsCorrectAlternative,
                QuestionId = alternativeDTO.QuestionId,
                IsDeleted = false
            };
            _alternativeRepository.Insert(alternative);
        }

        public void Update(AlternativeDTO alternativeDTO)
        {
            var alternative = _alternativeRepository.Find(alternativeDTO.Id);
            alternative.IsCorrectAlternative = alternativeDTO.IsCorrectAlternative;
            alternative.QuestionId = alternativeDTO.QuestionId;
            _alternativeRepository.Update(alternative);
        }
    }
}
