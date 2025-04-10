using PGMate.Models;

namespace PGMate.Services
{
    public interface IPGMemberService
    {
        Task<IEnumerable<PGMemberDTO>> GetAllWithRoomsAsync();
        Task<IEnumerable<PGMemberDTO>> GetAllWithCleaningTasksAsync();
        Task<PGMemberDTO> GetByIdAsync(int id);
        Task AddAsync(PGMemberDTO dto);
        Task UpdateAsync(int id, PGMemberDTO dto);
        Task DeleteAsync(int id);
    }
}
