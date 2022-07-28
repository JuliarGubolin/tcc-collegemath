using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Infra.Repositories
{
    public class ImageQuestionRepository : IImageQuestionRepository
    {
        private readonly CollegeMathContext _collegeMathContext;

        public ImageQuestionRepository(CollegeMathContext collegeMathContext)
        {
            _collegeMathContext = collegeMathContext;
        }

        public ImageQuestion Find(int id)
        {
            return _collegeMathContext.ImageQuestion.Find(id);
        }

        public IEnumerable<ImageQuestion> GetAll()
        {
            return _collegeMathContext.ImageQuestion.Where(c => !c.IsDeleted).ToList();
        }

        public void Insert(ImageQuestion imageQuestion)
        {
            _collegeMathContext.Add(imageQuestion);
            _collegeMathContext.SaveChanges();
        }

        public void Update(ImageQuestion imageQuestion)
        {
            _collegeMathContext.Update(imageQuestion);
            _collegeMathContext.SaveChanges();
        }
    }
}
