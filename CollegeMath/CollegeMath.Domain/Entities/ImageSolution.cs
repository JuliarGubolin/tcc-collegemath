namespace CollegeMath.Domain.Entities
{
    public class ImageSolution : EntityBase
    {
        public int SolutionId { get; set; }

        public virtual Solution Solution { get; set; }

        public string Url { get; set; }
    }
}
