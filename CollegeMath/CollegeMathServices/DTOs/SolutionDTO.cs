﻿using CollegeMath.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.DTOs
{
    public class SolutionDTO
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public virtual ICollection<ImageSolution> Images { get; set; }
        
    }
}
