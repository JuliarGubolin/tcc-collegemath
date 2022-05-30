namespace CollegeMath.Domain.Entities
{
    public class Content : EntityBase
    {
        public Content(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string? Description { get; set; } = null!;
    }
}
