using CollegeMath.Domain;
using CollegeMath.Domain.Entities;

namespace CollegeMath.Infra.Interfaces
{
    public interface IUserQuestionHistoryRepository
    {
        void Insert(UserQuestionHistory userQuestionHistory);
        void Update(UserQuestionHistory userQuestionHistory);
        UserQuestionHistory Find(int id);
        IEnumerable<UserQuestionHistory> GetAll();
        void Delete(UserQuestionHistory userQuestionHistory);
        List<UserQuestionHistory> GetUserQuestionHistory(string userId);
        List<UserRankingHelper> GetUsersRanking();
    }
}
