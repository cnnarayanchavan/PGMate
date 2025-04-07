using PGMate.Models;
using PGMate.Repositories;

namespace PGMate.Services
{
    public class CleaningService : ICleaningService
    {
        private readonly ICleaningRepository _cleaningRepository;

        public CleaningService(ICleaningRepository cleaningRepository)
        {
            _cleaningRepository = cleaningRepository;
        }

        public async Task<IEnumerable<CleaningTask>> GetAllTasksAsync()
        {
            return await _cleaningRepository.GetAllAsync();
        }

        public async Task<CleaningTask> AddTaskAsync(CleaningTaskDto taskDto)
        {
            var task = new CleaningTask
            {
                RoomNumber = taskDto.RoomNumber,
                AssignedTo = taskDto.AssignedTo,
                TaskType = taskDto.TaskType,
                ScheduledTime = taskDto.ScheduledTime,
                IsRecurring = taskDto.IsRecurring,
                CreatedAt = DateTime.UtcNow
            };

            return await _cleaningRepository.AddAsync(task);
        }

        public async Task<bool> UpdateTaskStatusAsync(int taskId, string status)
        {
            var task = await _cleaningRepository.GetByIdAsync(taskId);
            if (task == null) return false;

            task.Status = status;
            task.UpdatedAt = DateTime.UtcNow;

            return await _cleaningRepository.UpdateAsync(task);
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var task = await _cleaningRepository.GetByIdAsync(taskId);
            if (task == null) return false;

            return await _cleaningRepository.DeleteAsync(task);
        }
    }
}
