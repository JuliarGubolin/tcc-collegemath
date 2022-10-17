using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CollegeMath.Infra.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CollegeMathContext _collegeMathContext;

        public QuestionRepository(CollegeMathContext collegeMathContext)
        {
            _collegeMathContext = collegeMathContext;
        }

        public void Delete(Question question)
        {
            question.IsDeleted = true;
            _collegeMathContext.Questions.Update(question);
            _collegeMathContext.SaveChanges();
        }

        public Question Find(int id)
        {
            return _collegeMathContext.Questions.Find(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _collegeMathContext.Questions.Where(c => !c.IsDeleted);
        }

        public IEnumerable<Question> GetAllByContentAndLevel(int levelId, int contentId, string userId)
        {
            var questions = _collegeMathContext.Questions.Where(c => !c.IsDeleted && c.ContentId == contentId && c.LevelId == levelId).ToList();
            var userQuestions = _collegeMathContext.UserQuestionHistory.Include(c => c.Alternative).ThenInclude(c => c.Question)
                .Where(c => !c.IsDeleted && c.UserId == userId).Select(c => c.Alternative.Question).ToList();

            if (userQuestions != null && userQuestions.Count > 0)
                questions.RemoveAll(c => userQuestions.Any(x => x.Id == c.Id));

            return questions;
        }

        public void Insert(Question question)
        {
            _collegeMathContext.Add(question);
            _collegeMathContext.SaveChanges();
        }

        public void Update(Question question)
        {
            _collegeMathContext.Update(question);
            _collegeMathContext.SaveChanges();
        }
    }
}
