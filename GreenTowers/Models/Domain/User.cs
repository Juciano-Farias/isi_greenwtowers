using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTowers.Models.Domain
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [StringLength(60)]
        public string Floor { get; set; }

        public DateTime Birth { get; set; }

        [Required]
        public Role Role { get; set; }
    }
    public enum Role
    {
        Admin,
        User,
        Rec
    }
}
