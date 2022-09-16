using CollegeMath.Domain.Entities;

namespace CollegeMath.Infra.Interfaces
{
    public interface ISolutionRepository
    {
        void Insert(Solution solution);
        void Update(Solution solution);
        Solution Find(int id);
        IEnumerable<Solution> GetAll();
        void Delete(Solution solution);
        Solution GetSolutionByQuestionId(int questionId);
    }
}
