using CollegeMath.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.Interfaces
{
    public interface IImageQuestionApplication
    {
        void Insert(ImageQuestionDTO imageQuestionDTO);

        void Update(ImageQuestionDTO imageQuestionDTO);
        IEnumerable<ImageQuestionDTO> GetAll();
    }
}
