using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Domain.Entities
{
    public class Alternative : EntityBase
    {
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public bool IsCorrectAlternative { get; set; }
    }
}
