namespace CollegeMath.Domain.Entities
{
    public class QuestionType : EntityBase
    {
        public QuestionType(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
