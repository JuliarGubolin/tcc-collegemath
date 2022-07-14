using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;

namespace CollegeMath.Infra.Repositories
{
    public class AlternativeRepository : IAlternativeRepository
    {
        private readonly CollegeMathContext _collegeMathContext;
        public AlternativeRepository(CollegeMathContext collegeMathContext)
        {
            _collegeMathContext = collegeMathContext;
        }

        public void Delete(Alternative alternative)
        {
            alternative.IsDeleted = true;
            _collegeMathContext.Update(alternative);
            _collegeMathContext.SaveChanges();
        }

        public Alternative Find(int id)
        {
            return _collegeMathContext.Alternatives.Find(id);
        }

        public IEnumerable<Alternative> GetAll()
        {
            return _collegeMathContext.Alternatives.Where(c=> !c.IsDeleted);
        }

        public void Insert(Alternative alternative)
        {
            _collegeMathContext.Alternatives.Add(alternative);
            _collegeMathContext.SaveChanges();
        }

        public void Update(Alternative alternative)
        {
            _collegeMathContext.Alternatives.Update(alternative);
            _collegeMathContext.SaveChanges();
        }
    }
}