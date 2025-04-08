using System.ComponentModel.DataAnnotations;

namespace PGMate.Models
{
    public class PGMember
    {
        [Key]
        public int PGMemberId { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int RoomId { get; set; }

        // Navigation Property
        public Room Room { get; set; }

        public ICollection<CleaningTask> CleaningTasks { get; set; }
    }
}
