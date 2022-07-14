namespace CollegeMath.Domain.Entities
{
    public class ImageQuestion : EntityBase
    {
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public string Url { get; set; }
    }
}
