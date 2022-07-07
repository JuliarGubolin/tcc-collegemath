using Microsoft.AspNetCore.Identity;

namespace CollegeMath.Domain.Entities
{
    public class UserQuestionHistory : EntityBase
    {
        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public int? AlternativeId { get; set; } = null!;

        public virtual Alternative Alternative { get; set; }

        public DateTime AnsweredIn { get; set; }
    }
}