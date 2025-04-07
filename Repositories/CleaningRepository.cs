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
        {
            return await _context.CleaningTasks.ToListAsync();
        }

        public async Task<CleaningTask> GetByIdAsync(int id)
        {
            return await _context.CleaningTasks.FindAsync(id);
        }

        public async Task<CleaningTask> AddAsync(CleaningTask task)
        {
            _context.CleaningTasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateAsync(CleaningTask task)
        {
            _context.CleaningTasks.Update(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(CleaningTask task)
        {
            _context.CleaningTasks.Remove(task);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
