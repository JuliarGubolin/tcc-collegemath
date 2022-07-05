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
    public class LevelRepository : ILevelRepository
    {
        private readonly CollegeMathContext _collegeMathContext;

        public LevelRepository(CollegeMathContext collegeMathContext)
        {
            _collegeMathContext = collegeMathContext;
        }
        public Level Find(int id)
        {
            return _collegeMathContext.Levels.Find(id);
        }

        public IEnumerable<Level> GetAll()
        {
            return _collegeMathContext.Levels.Where(c => !c.IsDeleted).ToList();
        }

        public void Insert(Level level)
        {
            _collegeMathContext.Add(level);
            _collegeMathContext.SaveChanges();
        }

        public void Update(Level level)
        {
            _collegeMathContext.Update(level);
            _collegeMathContext.SaveChanges();
        }
    }
}
