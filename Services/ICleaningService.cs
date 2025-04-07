using PGMate.Models;


namespace PGMate
{
    public interface ICleaningService
    {
        Task<IEnumerable<CleaningTask>> GetAllTasksAsync();
        Task<CleaningTask> AddTaskAsync(CleaningTaskDto taskDto);
        Task<bool> UpdateTaskStatusAsync(int taskId, string status);
        Task<bool> DeleteTaskAsync(int taskId);
    }
}
