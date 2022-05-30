namespace CollegeMath.Domain.Entities
{
    public class UserQuestionHistory : EntityBase
    {
        public int UserId { get; set; }

        public int? AlternativeId { get; set; } = null!;

        public virtual Alternative Alternative { get; set; }

        public DateTime AnsweredIn { get; set; }
    }
}