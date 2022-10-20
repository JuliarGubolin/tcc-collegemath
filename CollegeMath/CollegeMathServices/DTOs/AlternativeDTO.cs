using System;

namespace CollegeMathServices.DTOs
{
    public class AlternativeDTO
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public int QuestionId { get; set; }

        public QuestionDTO Question { get; set; }

        public bool IsCorrectAlternative { get; set; }
        public string Text { get; set; }
    }
}
