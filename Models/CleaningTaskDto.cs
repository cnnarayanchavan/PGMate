using System.ComponentModel.DataAnnotations;

namespace PGMate.Models
{
    public class CleaningTaskDto
    {
        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public string AssignedTo { get; set; }

        [Required]
        public string TaskType { get; set; }

        [Required]
        public DateTime ScheduledTime { get; set; }

        public bool IsRecurring { get; set; }
    }
}
