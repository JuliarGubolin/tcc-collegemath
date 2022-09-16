using CollegeMath.Application.DTO;

namespace CollegeMath.Application.Interfaces
{
    public interface IUserQuestionHistoryApplication
    {
        void Insert(UserQuestionHistoryDTO userQuestionHistoryDTO);

        void Update(UserQuestionHistoryDTO userQuestionHistoryDTO);
        IEnumerable<UserQuestionHistoryDTO> GetAll();
        void Delete(int id);
        
        UserScoreDTO GetUserScore(string userId);
        List<UserRankingDTO> GetUsersRanking(int quantity);
    }
}
