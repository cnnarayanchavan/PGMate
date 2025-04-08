
using PGMate;
using PGMate.Models;

namespace PGMate.Repositories
{
    public interface ICleaningRepository
    {
        Task<IEnumerable<CleaningTask>> GetAllAsync();
        Task<CleaningTask> GetByIdAsync(int id);
        Task AddAsync(CleaningTask task);
        Task UpdateAsync(CleaningTask task);
        Task DeleteAsync(int id);
    }
}
