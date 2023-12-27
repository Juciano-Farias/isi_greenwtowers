using System.ComponentModel.DataAnnotations;

namespace GreenTowers.Models.Domain
{
    public class CommonArea
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
