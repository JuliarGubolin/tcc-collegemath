using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Infra.Repositories
{
    public class SolutionRepository : ISolutionRepository
    {
        private readonly CollegeMathContext _collegeMathContext;
        public SolutionRepository(CollegeMathContext collegeMathContext)
        {
            _collegeMathContext = collegeMathContext;
        }
        public void Delete(Solution solution)
        {
            solution.IsDeleted = true;
            _collegeMathContext.Update(solution);
            _collegeMathContext.SaveChanges();
        }

        public Solution Find(int id)
        {
            return _collegeMathContext.Solutions.Find(id);
        }

        public IEnumerable<Solution> GetAll()
        {
            return _collegeMathContext.Solutions.Where(c => !c.IsDeleted);
        }

        public Solution GetSolutionByQuestionId(int questionId)
        {
            return _collegeMathContext.Solutions.Include(c=>c.Images).FirstOrDefault(c => !c.IsDeleted && c.QuestionId == questionId);
        }

        public void Insert(Solution solution)
        {
            _collegeMathContext.Solutions.Add(solution);
            _collegeMathContext.SaveChanges();
        }

        public void Update(Solution solution)
        {
            _collegeMathContext.Solutions.Update(solution);
            _collegeMathContext.SaveChanges();
        }
    }
}
