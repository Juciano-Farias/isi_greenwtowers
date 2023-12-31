using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenTowers.Models.Domain
{
    public class IndividualWarning : BaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }

}
