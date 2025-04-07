namespace PGMate.Models
{
    public class CleaningTask
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public string AssignedTo { get; set; }

        public string TaskType { get; set; } // e.g., "Room Cleaning", "Bathroom", etc.

        public DateTime ScheduledTime { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Completed, Missed

        public bool IsRecurring { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
