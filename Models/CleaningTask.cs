using System.ComponentModel.DataAnnotations;

namespace PGMate.Models
{
    public class CleaningTask
    {
        [Key]
        public int CleaningTaskId { get; set; }
        public string TaskDescription { get; set; } = string.Empty; // Avoid nulls

        public DateTime ScheduledDate { get; set; }
        public bool IsCompleted { get; set; }

        // Foreign Key
        public int PGMemberId { get; set; }

        // Navigation Property
        public PGMember PGMember { get; set; }
    }
}
