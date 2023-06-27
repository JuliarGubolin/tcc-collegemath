using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Domain
{
    public class UserRankingHelper
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public int CorrectQuestionsCount { get; set; }

        public int UserScore { get; set; }
    }
}
