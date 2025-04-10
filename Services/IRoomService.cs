using PGMate.Models;

namespace PGMate.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetAllAsync();
        Task<IEnumerable<RoomDTO>> GetByIdWithMembersAndTasksAsync(int id);
        Task<RoomDTO> GetByIdAsync(int id);
        Task AddAsync(RoomDTO dto);
        Task UpdateAsync(int id, RoomDTO dto);
        Task DeleteAsync(int id);
    }
}
