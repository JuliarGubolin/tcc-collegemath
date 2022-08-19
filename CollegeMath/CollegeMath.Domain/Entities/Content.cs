namespace CollegeMath.Domain.Entities
{
    public class Content : EntityBase
    {
        public string Name { get; set; }

        public string? Description { get; set; } = null!;
    }
}
