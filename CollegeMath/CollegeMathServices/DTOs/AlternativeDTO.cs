using CollegeMath.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.DTOs
{
    public class AlternativeDTO
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public bool IsCorrectAlternative { get; set; }
    }
}
