using CollegeMath.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.Interfaces
{
    public interface ILevelApplication
    {
        void Insert(LevelDTO levelDTO);

        void Update(LevelDTO levelDTO);
        IEnumerable<LevelDTO> GetAll();
    }
}
