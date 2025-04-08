using System.ComponentModel.DataAnnotations;

namespace PGMate.Models
{
    public class PGMemberDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string ContactNumber { get; set; } = string.Empty;
        [Required]
        public int RoomId { get; set; }
    }
}
