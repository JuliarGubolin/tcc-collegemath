namespace CollegeMath.Application.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int LevelId { get; set; }

        public int ContentId { get; set; }

        public int QuestionTypeId { get; set; }
    }
}
