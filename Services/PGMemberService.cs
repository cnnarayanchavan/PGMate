using AutoMapper;
using PGMate.Models;
using PGMate.Repositories;

namespace PGMate.Services
{
    public class PGMemberService : IPGMemberService
    {
        private readonly IPGMemberRepository _repo;
        private readonly IMapper _mapper;

        public PGMemberService(IPGMemberRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PGMemberDTO>> GetAllWithRoomsAsync()
        {
            var members = await _repo.GetAllWithRoomsAsync();
            return _mapper.Map<IEnumerable<PGMemberDTO>>(members);
        }

        public async Task<IEnumerable<PGMemberDTO>> GetAllWithCleaningTasksAsync()
        { 
            var result = await _repo.GetAllWithCleaningTasksAsync();
            return _mapper.Map<IEnumerable<PGMemberDTO>>(result);
        }

        public async Task<PGMemberDTO> GetByIdAsync(int id)
        {
            var member = await _repo.GetByIdAsync(id);
            return _mapper.Map<PGMemberDTO>(member);
        }

        public async Task AddAsync(PGMemberDTO dto)
        {
            var entity = _mapper.Map<PGMember>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, PGMemberDTO dto)
        {
            var member = await _repo.GetByIdAsync(id);
            if (member == null) return;

            _mapper.Map(dto, member);
            await _repo.UpdateAsync(member);
        }

        public async Task DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }

}
