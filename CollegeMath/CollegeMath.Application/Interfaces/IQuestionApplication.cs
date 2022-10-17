using CollegeMath.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.Interfaces
{
    public interface IQuestionApplication
    {
        void Insert(QuestionDTO questionDTO);

        void Update(QuestionDTO questionDTO);
        IEnumerable<QuestionDTO> GetAll();
        void Delete(int id);
        IEnumerable<QuestionDTO> GetAllByContentAndLevel(GetAllQuestionDTO getAllQuestionDTO, string userId);
    }
}
