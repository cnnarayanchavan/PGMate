using System.ComponentModel.DataAnnotations;

namespace PGMate.Models
{
    public class CleaningTaskDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string TaskName { get; set; } = string.Empty;
        [Required]
        public string AssignedTo { get; set; } = string.Empty;
        [Required]
        public DateTime ScheduledDate { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public int RoomId { get; set; }
    }
}
