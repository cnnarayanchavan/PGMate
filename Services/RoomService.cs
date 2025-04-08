using AutoMapper;
using PGMate.Models;
using PGMate.Repositories;

namespace PGMate.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repo;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllAsync()
        {
            var rooms = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDTO>>(rooms);
        }

        public async Task<RoomDTO> GetByIdAsync(int id)
        {
            var room = await _repo.GetByIdAsync(id);
            return _mapper.Map<RoomDTO>(room);
        }

        public async Task AddAsync(RoomDTO dto)
        {
            var entity = _mapper.Map<Room>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, RoomDTO dto)
        {
            var room = await _repo.GetByIdAsync(id);
            if (room == null) return;

            _mapper.Map(dto, room);
            await _repo.UpdateAsync(room);
        }

        public async Task DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }

}
