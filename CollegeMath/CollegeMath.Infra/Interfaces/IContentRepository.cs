using CollegeMath.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Infra.Interfaces
{
    public interface IContentRepository
    {
        void Insert(Content content);

        void Update(Content content);
        Content Find(int id);
        IEnumerable<Content> GetAll();
    }
}
