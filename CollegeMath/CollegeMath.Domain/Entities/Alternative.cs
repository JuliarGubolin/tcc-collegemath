namespace CollegeMath.Domain.Entities
{
    public class Alternative : EntityBase
    {
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public bool IsCorrectAlternative { get; set; }

        public string Text { get; set; }
    }
}