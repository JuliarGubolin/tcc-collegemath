namespace CollegeMath.Domain.Entities
{
    public class ImageQuestion : EntityBase
    {
        public ImageQuestion(int questionId, string url)
        {
            this.QuestionId = questionId;   
            this.Url = url;
        }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public string Url { get; set; }
    }
}
