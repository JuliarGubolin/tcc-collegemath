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
                var teste = GetUserQuestionHistory(user.Id);

                if (_collegeMathContext.UserQuestionHistory.Any(c => c.UserId == user.Id))
                {
                    var alternatives = teste.Select(c => c.Alternative);
                    var pontuacao = 0;
                    foreach (Alternative alternative in alternatives)
                    {
                        var questionId = alternative.QuestionId;
                        var question = _collegeMathContext.Questions.Find(questionId);
                        var level = question.LevelId;
                        if (alternative.IsCorrectAlternative == true && level == 1)
                        {
                            pontuacao = pontuacao + 2;
                        }
                        else if (alternative.IsCorrectAlternative == true && level == 2)
                        {
                            pontuacao = pontuacao + 3;
                        }
                        else if (alternative.IsCorrectAlternative == true && level == 3)
                        {
                            pontuacao = pontuacao + 5;
                        }
                    }
                    var correctQuestion = new UserRankingHelper
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        CorrectQuestionsCount = 0,
                        UserScore = pontuacao,
                    };
                    usersCorrectQuestions.Add(correctQuestion);

                }
            }
            return usersCorrectQuestions;
        }
        /*public List<UserRankingHelper> GetUsersRanking()
        {
            var users = _collegeMathContext.Users.ToList();
            var usersCorrectQuestions = new List<UserRankingHelper>();
            
            foreach (var user in users)
            {
                var pontos = GetUserQuestionHistory(user.Id);
                pontos.ElementAt(0).
                //-----
                //correctQuestion.UserScore = pontuacao;
                //-----
                if (_collegeMathContext.UserQuestionHistory.Any(c => c.UserId == user.Id))
                {
                    var correctQuestion = new UserRankingHelper
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        CorrectQuestionsCount = 0,
                        UserScore = pontos.,
                    };
                    /*correctQuestion.CorrectQuestionsCount = 0;_collegeMathContext.UserQuestionHistory
                        .Include(c => c.Alternative).Where(c => c.UserId == user.Id && c.Alternative.IsCorrectAlternative &&
                        c.AlternativeId ==
                        _collegeMathContext.UserQuestionHistory.Include(c => c.Alternative)
                        .Where(x => x.Alternative.QuestionId == c.Alternative.QuestionId && x.UserId == user.Id)
                        .OrderBy(c => c.AnsweredIn).FirstOrDefault().AlternativeId).Count();
                    usersCorrectQuestions.Add(correctQuestion);
                }
            }
            return usersCorrectQuestions;
        }*/

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
