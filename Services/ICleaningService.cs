using PGMate.Models;


namespace PGMate
{
    public interface ICleaningService
    {
        Task<IEnumerable<CleaningTaskDto>> GetAllAsync();
        Task<CleaningTaskDto> GetByIdAsync(int id);
        Task AddAsync(CleaningTaskDto dto);
        Task UpdateAsync(int id, CleaningTaskDto dto);
        Task DeleteAsync(int id);
    }
}
