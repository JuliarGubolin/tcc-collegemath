using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
