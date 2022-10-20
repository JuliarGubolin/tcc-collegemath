using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.DTOs
{
    public class ImageQuestionDTO
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public int QuestionId { get; set; }

        public QuestionDTO Question { get; set; }

        public string Url { get; set; }
    }
}
