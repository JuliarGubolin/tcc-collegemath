using CollegeMath.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.Interfaces
{
    public interface IContentApplication
    {
        void Insert(ContentDTO contentDTO);

        void Update(ContentDTO contentDTO);
        IEnumerable<ContentDTO> GetAll();
    }
}
