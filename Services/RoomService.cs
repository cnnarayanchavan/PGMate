using AutoMapper;
using PGMate.Models;
using PGMate.Repositories;
using Microsoft.Extensions.Caching.Memory;


namespace PGMate.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public RoomService(IRoomRepository repo, IMapper mapper, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
            _mapper = mapper;
            
        }

        //public async Task<IEnumerable<RoomDTO>> GetAllAsync()
        //{
        //    var rooms = await _repo.GetAllAsync();
        //    return _mapper.Map<IEnumerable<RoomDTO>>(rooms);
        //}
        public async Task<IEnumerable<RoomDTO>> GetAllAsync()
        {
            const string cacheKey = "all_rooms";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<RoomDTO> cachedRooms))
            {
                var rooms = await _repo.GetAllAsync();
                cachedRooms = _mapper.Map<IEnumerable<RoomDTO>>(rooms);

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };

                _cache.Set(cacheKey, cachedRooms, cacheOptions);
            }

            return cachedRooms;
        }

        public async Task<IEnumerable<RoomDTO>> GetByIdWithMembersAndTasksAsync(int id)
        {
            var result = await _repo.GetByIdWithMembersAndTasksAsync(id);
            return _mapper.Map<IEnumerable<RoomDTO>>(result);
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
            _cache.Remove("all_rooms");
        }

        public async Task UpdateAsync(int id, RoomDTO dto)
        {
            var room = await _repo.GetByIdAsync(id);
            if (room == null) return;

            _mapper.Map(dto, room);
            await _repo.UpdateAsync(room);
            _cache.Remove("all_rooms");
        }

        public async Task DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
        _cache.Remove("all_rooms");
    }

}
