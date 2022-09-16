namespace CollegeMath.Domain.Entities
{
    public class Solution : EntityBase
    {
   
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public virtual ICollection<ImageSolution> Images { get; set; }
    }
}
