using Microsoft.EntityFrameworkCore;
using PGMate.Data;
using PGMate.Models;

namespace PGMate.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
            => await _context.Rooms.Include(r => r.PGMembers).ToListAsync();

        public async Task<Room> GetByIdAsync(int id)
            => await _context.Rooms.Include(r => r.PGMembers).FirstOrDefaultAsync(r => r.RoomId == id);

        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var room = await GetByIdAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
    }

}
