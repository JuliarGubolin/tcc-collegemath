using CollegeMath.Domain;
using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Infra.Repositories
{
    public class UserQuestionHistoryRepository : IUserQuestionHistoryRepository
    {
        private readonly CollegeMathContext _collegeMathContext;
        public UserQuestionHistoryRepository(CollegeMathContext collegeMathContext)
        {
            _collegeMathContext = collegeMathContext;
        }
        public void Delete(UserQuestionHistory userQuestionHistory)
        {
            userQuestionHistory.IsDeleted = true;
            _collegeMathContext.Update(userQuestionHistory);
            _collegeMathContext.SaveChanges();
        }

        public UserQuestionHistory Find(int id)
        {
            return _collegeMathContext.UserQuestionHistory.Find(id);
        }

        public IEnumerable<UserQuestionHistory> GetAll()
        {
            return _collegeMathContext.UserQuestionHistory.Where(c => !c.IsDeleted).ToList();
        }

        public List<UserQuestionHistory> GetUserQuestionHistory(string userId)
        {
            return _collegeMathContext.UserQuestionHistory.Include(c => c.Alternative).Where(c => !c.IsDeleted && c.UserId == userId).ToList();
        }

        public List<UserRankingHelper> GetUsersRanking()
        {
            var users = _collegeMathContext.Users.ToList();
            var usersCorrectQuestions = new List<UserRankingHelper>();
            foreach (var user in users)
            {
                //usersCorrectQuestions.Add(new UserRankingHelper
                //{
                //    UserId = user.Id,
                //    UserName = user.UserName,
                //    CorrectQuestionsCount = _collegeMathContext.UserQuestionHistory
                //    .Include(c => c.Alternative).Where(c =>  c.UserId == user.Id &&
                //    _collegeMathContext.UserQuestionHistory.Include(x=>x.Alternative)
                //    .Where(z => z.Alternative.QuestionId == c.Alternative.QuestionId && z.UserId == user.Id)
                //    .OrderBy(c=>c.CreatedDate).Select(x => x.Alternative.IsCorrectAlternative).First() == true).Count()
                //});

                if (_collegeMathContext.UserQuestionHistory.Any(c => c.UserId == user.Id))
                {
                    var correctQuestion = new UserRankingHelper
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                    };

                    correctQuestion.CorrectQuestionsCount = _collegeMathContext.UserQuestionHistory
                        .Include(c => c.Alternative).Where(c => c.UserId == user.Id && c.Alternative.IsCorrectAlternative &&
                        c.AlternativeId ==
                        _collegeMathContext.UserQuestionHistory.Include(c => c.Alternative)
                        .Where(x => x.Alternative.QuestionId == c.Alternative.QuestionId && x.UserId == user.Id)
                        .OrderBy(c => c.AnsweredIn).FirstOrDefault().AlternativeId).Count();

                    usersCorrectQuestions.Add(correctQuestion);
                }

                //var question = new UserRankingHelper
                //{
                //    UserId = user.Id,
                //    UserName = user.UserName,
                //};
                //var correctQuestionsCount = (from uqh in _collegeMathContext.UserQuestionHistory.Include(z=>z.Alternative)
                //join alternative in _collegeMathContext.Alternatives on uqh.AlternativeId equals alternative.Id
                //where !uqh.IsDeleted && uqh.UserId == user.Id
                //&&
                //(from u in _collegeMathContext.UserQuestionHistory.Include(z => z.Alternative)
                // join aa in _collegeMathContext.Alternatives on uqh.AlternativeId equals aa.Id
                // where !u.IsDeleted && uqh.UserId == user.Id
                // orderby u.CreatedDate
                // select u.Alternative.IsCorrectAlternative).FirstOrDefault() == true
                // select uqh.Id).Count();

                //question.CorrectQuestionsCount = correctQuestionsCount;
                //usersCorrectQuestions.Add(question);
            }
            return usersCorrectQuestions;
        }

        public void Insert(UserQuestionHistory userQuestionHistory)
        {
            _collegeMathContext.Add(userQuestionHistory);
            _collegeMathContext.SaveChanges();
        }

        public void Update(UserQuestionHistory userQuestionHistory)
        {
            _collegeMathContext.Update(userQuestionHistory);
            _collegeMathContext.SaveChanges();
        }
    }
}
