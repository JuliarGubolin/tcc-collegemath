using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMathServices.DTOs
{
    public class LevelDTO
    {
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
