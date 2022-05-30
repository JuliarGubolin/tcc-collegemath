using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Domain.Entities
{
    public class Question : EntityBase
    {
        public Question(string title, int levelId, int contentId, int questionTypeId)
        {
            Title = title;
            LevelId = levelId;
            ContentId = contentId;
            QuestionTypeId = questionTypeId;
        }

        public string Title { get; set; }

        public string Text { get; set; }

        public int LevelId { get; set; }
        
        public virtual Level Level { get; set; }

        public int ContentId { get; set; }

        public virtual Content Content { get; set; }

        public int QuestionTypeId { get; set; }

        public virtual QuestionType QuestionType { get; set; }

        public virtual ICollection<ImageQuestion> Images { get; set; }

        public virtual ICollection<Alternative> Alternatives { get; set; }

    }
}
