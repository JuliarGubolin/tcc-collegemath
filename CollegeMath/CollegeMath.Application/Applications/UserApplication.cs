using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            return _userRepository.GetAll().Select(c => new UsuarioDTO
            {
                CreatedDate = c.CreatedDate,
                Name = c.Name,
                UserName = c.UserName,
                Email = c.Email,
                Password = c.Password,
                Id = c.Id,
                IsDeleted = c.IsDeleted,
            });
        }

        public void Insert(UsuarioDTO usuarioDTO)
        {
            var user = new User(usuarioDTO.Name, usuarioDTO.Email, usuarioDTO.Password)
            {
                CreatedDate = DateTime.Now,
                UserName = usuarioDTO.UserName,
                IsDeleted = false,
            };

            _userRepository.Insert(user);
        }

        public void Update(UsuarioDTO usuarioDTO)
        {
            var user = _userRepository.Find(usuarioDTO.Id);
            user.Name = usuarioDTO.Name;
            user.UserName = usuarioDTO.UserName;
            user.Email = usuarioDTO.Email;
            user.Password = usuarioDTO.Password;
            _userRepository.Update(user);
        }
    }
}
