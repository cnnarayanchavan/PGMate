using Microsoft.EntityFrameworkCore;
using PGMate.Data;
using PGMate.Models;

namespace PGMate.Repositories
{
    public class PGMemberRepository : IPGMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public PGMemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get all pg membars with their rooms 
        public async Task<IEnumerable<PGMember>> GetAllWithRoomsAsync()
            => await _context.PGMembers.Include(m => m.Room).ToListAsync();

        //Get all pg membars with their cleaning tasks.
        public async Task<IEnumerable<PGMember>> GetAllWithCleaningTasksAsync()
            => await _context.PGMembers.Include(ct => ct.CleaningTasks).ToListAsync();


        public async Task<PGMember> GetByIdAsync(int id)
            => await _context.PGMembers.Include(m => m.Room).FirstOrDefaultAsync(m => m.PGMemberId == id);

        public async Task AddAsync(PGMember member)
        {
            await _context.PGMembers.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PGMember member)
        {
            _context.PGMembers.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var member = await GetByIdAsync(id);
            if (member != null)
            {
                _context.PGMembers.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
    }

}
