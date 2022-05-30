namespace CollegeMath.Domain.Entities
{
    public class Level : EntityBase
    {
        public Level(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string? Description { get; set; } = null!;
    }
}
