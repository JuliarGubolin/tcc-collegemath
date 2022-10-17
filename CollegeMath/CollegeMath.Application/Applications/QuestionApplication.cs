using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Interfaces;

namespace CollegeMath.Application.Applications
{
    public class QuestionApplication : IQuestionApplication
    {
        IQuestionRepository _questionRepository;

        public QuestionApplication(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void Delete(int id)
        {
            var question = _questionRepository.Find(id);
            _questionRepository.Delete(question);
        }

        public IEnumerable<QuestionDTO> GetAll()
        {
            return _questionRepository.GetAll().Select(c=> new QuestionDTO 
            {
                ContentId = c.ContentId,
                Id = c.Id,
                LevelId = c.LevelId,
                QuestionTypeId = c.QuestionTypeId,
                Text = c.Text,
                Title = c.Title
            });
        }

        public IEnumerable<QuestionDTO> GetAllByContentAndLevel(GetAllQuestionDTO getAllQuestionDTO, string userId)
        {
            var questions = _questionRepository.GetAllByContentAndLevel(getAllQuestionDTO.LevelId, getAllQuestionDTO.ContentId, userId);
            return questions.Select(c => new QuestionDTO
            {
                ContentId = c.ContentId,
                Id = c.Id,
                LevelId = c.LevelId,
                QuestionTypeId = c.QuestionTypeId,
                Text = c.Text,
                Title = c.Title
            });
        }

        public void Insert(QuestionDTO questionDTO)
        {
            var question = new Question(questionDTO.Title, questionDTO.LevelId, questionDTO.ContentId, questionDTO.QuestionTypeId);
            question.Text = questionDTO.Text;
            _questionRepository.Insert(question);
        }

        public void Update(QuestionDTO questionDTO)
        {
            var question = _questionRepository.Find(questionDTO.Id);
            question.Text = questionDTO.Text;
            question.LevelId = questionDTO.LevelId;
            question.ContentId = questionDTO.ContentId;
            question.Title = questionDTO.Title;
            question.QuestionTypeId = questionDTO.QuestionTypeId;
            _questionRepository.Update(question);
        }
    }
}
