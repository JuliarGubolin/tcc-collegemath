using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int LevelId { get; set; }

        public int ContentId { get; set; }

        public int QuestionTypeId { get; set; }
    }
}
