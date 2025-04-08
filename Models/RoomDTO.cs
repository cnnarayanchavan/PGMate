using System.ComponentModel.DataAnnotations;

namespace PGMate.Models
{
    public class RoomDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string RoomNumber { get; set; } = string.Empty;
        [Required]
        public int Capacity { get; set; }
    }
}
