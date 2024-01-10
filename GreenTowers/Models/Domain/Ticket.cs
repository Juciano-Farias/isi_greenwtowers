using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GreenTowers.Models.Domain
{
    public class Ticket : BaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public string? Reply { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User? User { get; set; }

    }
}
