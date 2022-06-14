using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;

namespace CollegeMath.Infra.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly CollegeMathContext _collegeMathContext;

        public ContentRepository(CollegeMathContext collegeMathContext)
        {
            _collegeMathContext = collegeMathContext;
        }

        public Content Find(int id)
        {
            return _collegeMathContext.Contents.Find(id);
        }

        public IEnumerable<Content> GetAll()
        {
            return _collegeMathContext.Contents.Where(c => !c.IsDeleted).ToList();
        }

        public void Insert(Content content)
        {
            _collegeMathContext.Add(content);
            _collegeMathContext.SaveChanges();
        }

        public void Update(Content content)
        {
            _collegeMathContext.Update(content);
            _collegeMathContext.SaveChanges();
        }
    }
}
