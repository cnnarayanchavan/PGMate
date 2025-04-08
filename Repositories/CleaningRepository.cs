using Microsoft.EntityFrameworkCore;
using PGMate.Data;
using PGMate.Models;

namespace PGMate.Repositories
{
    public class CleaningRepository : ICleaningRepository
    {
        private readonly ApplicationDbContext _context;

        public CleaningRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CleaningTask>> GetAllAsync()
            => await _context.CleaningTasks.ToListAsync();

        public async Task<CleaningTask> GetByIdAsync(int id)
            => await _context.CleaningTasks.FindAsync(id);

        public async Task AddAsync(CleaningTask task)
        {
            await _context.CleaningTasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CleaningTask task)
        {
            _context.CleaningTasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.CleaningTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }

}
