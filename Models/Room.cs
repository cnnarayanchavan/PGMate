using System.ComponentModel.DataAnnotations;

namespace PGMate.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }

        // Navigation Property
        public ICollection<PGMember> PGMembers { get; set; }
    }
}
