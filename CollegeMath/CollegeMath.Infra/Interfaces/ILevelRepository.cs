using CollegeMath.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Infra.Interfaces
{
    public interface ILevelRepository
    {
        void Insert(Level level);
        void Update(Level level);
        Level Find(int id);
        IEnumerable<Level> GetAll();
    }
}
