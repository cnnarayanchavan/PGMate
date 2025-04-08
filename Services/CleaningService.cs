using AutoMapper;
using PGMate.Models;
using PGMate.Repositories;

namespace PGMate.Services
{
    public class CleaningService : ICleaningService
    {
        private readonly ICleaningRepository _repo;
        private readonly IMapper _mapper;

        public CleaningService(ICleaningRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CleaningTaskDto>> GetAllAsync()
        {
            var tasks = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CleaningTaskDto>>(tasks);
        }

        public async Task<CleaningTaskDto> GetByIdAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            return _mapper.Map<CleaningTaskDto>(task);
        }

        public async Task AddAsync(CleaningTaskDto dto)
        {
            var entity = _mapper.Map<CleaningTask>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, CleaningTaskDto dto)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null) return;

            _mapper.Map(dto, task);
            await _repo.UpdateAsync(task);
        }

        public async Task DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }

}
