using CollegeMath.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.Interfaces
{
    public interface IImageSolutionApplication
    {
        void Insert(ImageSolutionDTO imageSolutionDTO);
        IEnumerable<ImageSolutionDTO> GetAll();
    }
}
