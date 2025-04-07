
using PGMate;
using PGMate.Models;

namespace PGMate.Repositories
{
    public interface ICleaningRepository
    {
        Task<IEnumerable<CleaningTask>> GetAllAsync();

        Task<CleaningTask> GetByIdAsync(int id);

        Task<CleaningTask> AddAsync(CleaningTask task);

        Task<bool> UpdateAsync(CleaningTask task);

        Task<bool> DeleteAsync(CleaningTask task);
    }
}
