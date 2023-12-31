using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenTowers.Models.Domain
{
    public class GlobalWarning
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(5000)]
        public string Description { get; set; }
    }
}
