using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
using CollegeMath.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMath.Application.Applications
{
    public class UserQuestionHistoryApplication : IUserQuestionHistoryApplication
    {
        private readonly IUserQuestionHistoryRepository _userQuestionHistoryRepository;

        private readonly IQuestionRepository _questionRepository;

        public UserQuestionHistoryApplication(IUserQuestionHistoryRepository userQuestionHistoryRepository, IQuestionRepository questionRepository)
        {
            _userQuestionHistoryRepository = userQuestionHistoryRepository;
            _questionRepository = questionRepository;
        }

        public void Delete(int id)
        {
            var userQuestionHistory = _userQuestionHistoryRepository.Find(id);
            _userQuestionHistoryRepository.Delete(userQuestionHistory);
        }

        public IEnumerable<UserQuestionHistoryDTO> GetAll()
        {
            return _userQuestionHistoryRepository.GetAll().Select(c => new UserQuestionHistoryDTO
            {
                UserId = c.UserId,
                AlternativeId = c.AlternativeId,
                AnsweredIn = c.AnsweredIn
            });
        }

        public UserScoreDTO GetUserScore(string userId)
        {
            var history = _userQuestionHistoryRepository.GetUserQuestionHistory(userId);
            var userScoreDto = new UserScoreDTO();
            userScoreDto.UserQuestionHistory = history.Select(c => new UserQuestionHistoryDTO { 
                AlternativeId = c.AlternativeId, AnsweredIn = c.AnsweredIn, UserId = c.UserId }).ToList();

            var alternatives = history.Select(c => c.Alternative);
            var pontuacao = 0;
            foreach (Alternative alternative in alternatives)
            {
                var questionId = alternative.QuestionId;
                var question = _questionRepository.Find(questionId);
                var level = question.LevelId;
                if(alternative.IsCorrectAlternative == true && level == 1)
                {
                    pontuacao = pontuacao + 2;
                }else if (alternative.IsCorrectAlternative == true && level == 2)
                {
                    pontuacao = pontuacao + 3;
                }
                else if (alternative.IsCorrectAlternative == true && level == 3)
                {
                    pontuacao = pontuacao + 5;
                }
            }
            userScoreDto.UserScore = pontuacao;
            return userScoreDto;
        }

        public List<UserRankingDTO> GetUsersRanking(int quantity)
        {
            var usersCorrectQuestions = _userQuestionHistoryRepository.GetUsersRanking().OrderByDescending(c => c.UserScore).Take(quantity);
            var usersRanking = usersCorrectQuestions.Select(c => new UserRankingDTO
            {
                UserName = c.UserName,
                UserScore = c.UserScore
            }).ToList();
            return usersRanking;
        }

        public void Insert(UserQuestionHistoryDTO userQuestionHistoryDTO)
        {
            var alternative = new UserQuestionHistory
            {
                CreatedDate = DateTime.Now,
                AlternativeId = userQuestionHistoryDTO.AlternativeId,
                UserId = userQuestionHistoryDTO.UserId,
                AnsweredIn = userQuestionHistoryDTO.AnsweredIn,
                IsDeleted = false
            };
            _userQuestionHistoryRepository.Insert(alternative);
        }

        public void Update(UserQuestionHistoryDTO userQuestionHistoryDTO)
        {
            var userQuestionHistory = _userQuestionHistoryRepository.Find(userQuestionHistoryDTO.Id);
            userQuestionHistory.AnsweredIn = userQuestionHistoryDTO.AnsweredIn;
            userQuestionHistory.UserId = userQuestionHistoryDTO.UserId;
            userQuestionHistory.AlternativeId = userQuestionHistoryDTO.AlternativeId;
            _userQuestionHistoryRepository.Update(userQuestionHistory);
        }
    }
}
