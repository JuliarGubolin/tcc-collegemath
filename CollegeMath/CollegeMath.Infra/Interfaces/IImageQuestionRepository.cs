using CollegeMath.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Infra.Interfaces
{
    public interface IImageQuestionRepository
    {
        void Insert(ImageQuestion imageQuestion);
        void Update(ImageQuestion imageQuestion);
        ImageQuestion Find(int id);

        IEnumerable<ImageQuestion> GetAll();
    }
}
