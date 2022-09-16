using System.Collections.Generic;

namespace CollegeMathServices.DTOs
{
    public class UserScoreDTO
    {
        public List<UserQuestionHistoryDTO> UserQuestionHistory { get; set; }

        public int UserScore { get; set; }
    }
}
