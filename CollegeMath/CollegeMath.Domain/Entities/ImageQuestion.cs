namespace CollegeMath.Domain.Entities
{
    public class ImageQuestion : EntityBase
    {
        public ImageQuestion(Question question, int id, string url)
        {
            this.Question = question;
            this.Id = id;   
            this.Url = url;
        }
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public string Url { get; set; }
    }
}
