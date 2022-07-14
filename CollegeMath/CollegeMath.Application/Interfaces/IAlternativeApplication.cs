using CollegeMath.Application.DTO;

namespace CollegeMath.Application.Interfaces
{
    public interface IAlternativeApplication
    {
        void Insert(AlternativeDTO alternativeDTO);

        void Update(AlternativeDTO alternativeDTO);
        IEnumerable<AlternativeDTO> GetAll();
        void Delete(int id);
    }
}
