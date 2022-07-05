using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeMath.Domain.Entities;

namespace CollegeMath.Infra.Interfaces
{
    public interface IUserRepository
    {
        void Insert(User user);
        void Update(User user);
        User Find(int id);
        IEnumerable<User> GetAll();
    }
}
