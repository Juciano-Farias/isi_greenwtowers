using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenTowers.Models.Domain
{
    public class IndividualWarning
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public Type Type { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
    public enum Type
    {
        Global,
        Individual
    }
}
