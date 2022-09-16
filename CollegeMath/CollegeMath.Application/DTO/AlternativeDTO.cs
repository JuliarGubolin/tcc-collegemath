namespace CollegeMath.Application.DTO
{
    public class AlternativeDTO
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrectAlternative { get; set; }

        public string Text { get; set; }
    }
}
