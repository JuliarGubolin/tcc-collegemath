using CollegeMath.Domain.Entities;

namespace CollegeMath.Infra.Interfaces
{
    public interface IQuestionRepository
    {
        void Insert(Question question);
        void Update(Question question);
        Question Find(int id);
        IEnumerable<Question> GetAll();
        void Delete(Question question);
    }
}
