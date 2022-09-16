using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.DTO
{
    public class UserScoreDTO
    {
        public List<UserQuestionHistoryDTO> UserQuestionHistory { get; set; }

        public int UserScore { get; set; }
    }
}
