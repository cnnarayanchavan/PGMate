﻿using PGMate.Models;

namespace PGMate.Repositories
{
    public interface IPGMemberRepository
    {
        Task<IEnumerable<PGMember>> GetAllWithRoomsAsync();
        Task<IEnumerable<PGMember>> GetAllWithCleaningTasksAsync();
        Task<PGMember> GetByIdAsync(int id);
        Task AddAsync(PGMember member);
        Task UpdateAsync(PGMember member);
        Task DeleteAsync(int id);
    }
}
