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
    //public class UserRepository : IUserRepository
    //{

    //    private readonly CollegeMathContext _collegeMathContext;

    //    public UserRepository(CollegeMathContext collegeMathContext)
    //    {
    //        _collegeMathContext = collegeMathContext;
    //    }
    //    public User Find(int id)
    //    {
    //        return _collegeMathContext.Usuarios.Find(id);
    //    }

    //    public IEnumerable<User> GetAll()
    //    {
    //        return _collegeMathContext.Usuarios.Where(c => !c.IsDeleted).ToList();
    //    }

    //    public void Insert(User user)
    //    {
    //        _collegeMathContext.Add(user);
    //        _collegeMathContext.SaveChanges();
    //    }

    //    public void Update(User user)
    //    {
    //        _collegeMathContext.Update(user);
    //        _collegeMathContext.SaveChanges();
    //    }
    //}
}
