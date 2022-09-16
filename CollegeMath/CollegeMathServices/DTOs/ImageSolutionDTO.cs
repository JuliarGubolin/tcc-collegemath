using CollegeMath.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.DTOs
{
    public class ImageSolutionDTO
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public int SolutionId { get; set; }

        public virtual Solution solution { get; set; }

        public string Url { get; set; }
    }
}
