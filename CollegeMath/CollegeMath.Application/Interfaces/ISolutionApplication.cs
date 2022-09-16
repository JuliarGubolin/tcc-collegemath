using CollegeMath.Application.DTO;

namespace CollegeMath.Application.Interfaces
{
    public interface ISolutionApplication
    {
        void Insert(SolutionDTO solutionDTO);

        void Update(SolutionDTO solutionDTO);
        IEnumerable<SolutionDTO> GetAll();
        void Delete(int id);
        SolutionDTO GetSolutionByQuestionId(int questionId);
    }
}
