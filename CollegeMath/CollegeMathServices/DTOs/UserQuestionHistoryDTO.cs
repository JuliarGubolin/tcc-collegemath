using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.DTOs
{
    public class UserQuestionHistoryDTO
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }
        public string UserId { get; set; }

        //public IdentityUser User { get; set; }

        public int? AlternativeId { get; set; }

        public AlternativeDTO Alternative { get; set; }

        public DateTime AnsweredIn { get; set; }
    }
}
