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
            return _collegeMathContext.UserQuestionHistory.Include(c=>c.Alternative).Where(c => !c.IsDeleted && c.UserId == userId).ToList();
        }

        public List<UserRankingHelper> GetUsersRanking()
        {
            var users = _collegeMathContext.Users.ToList();
            var usersCorrectQuestions = new List<UserRankingHelper>();
            foreach (var user in users)
            {
                usersCorrectQuestions.Add(new UserRankingHelper
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    CorrectQuestionsCount = _collegeMathContext.UserQuestionHistory.Include(c => c.Alternative).Where(c => c.Alternative.IsCorrectAlternative && c.UserId == user.Id).Count()
                });
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
