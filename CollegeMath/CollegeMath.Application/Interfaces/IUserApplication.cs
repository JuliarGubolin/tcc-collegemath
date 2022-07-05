using CollegeMath.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.Interfaces
{
    public interface IUserApplication
    {
        void Insert(UsuarioDTO usuarioDTO);

        void Update(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> GetAll();
    }
}
