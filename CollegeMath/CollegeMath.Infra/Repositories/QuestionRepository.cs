using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;

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
            return _collegeMathContext.Questions.Where(c=> !c.IsDeleted);
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
