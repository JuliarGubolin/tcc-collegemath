using CollegeMath.Domain.Entities;

namespace CollegeMath.Infra.Interfaces
{
    public interface IAlternativeRepository
    {
        void Insert(Alternative alternative);
        void Update(Alternative alternative);
        Alternative Find(int id);
        IEnumerable<Alternative> GetAll();
        void Delete(Alternative alternative);
    }
}