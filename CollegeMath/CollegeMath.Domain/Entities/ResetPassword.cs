using Microsoft.AspNetCore.Identity;

namespace CollegeMath.Domain.Entities
{
    public class ResetPassword : EntityBase
    {
        public string Email { get; set; }

        public string Code { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
