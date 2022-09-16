using CollegeMath.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.DTO
{
    public class UserQuestionHistoryDTO : DTOBase
    {
        public string UserId { get; set; }

        //public IdentityUser User { get; set; }

        public int? AlternativeId { get; set; } = null!;

        //public virtual Alternative Alternative { get; set; }

        public DateTime AnsweredIn { get; set; }
    }
}
