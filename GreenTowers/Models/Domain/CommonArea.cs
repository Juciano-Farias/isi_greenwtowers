using System.ComponentModel.DataAnnotations;

namespace GreenTowers.Models.Domain
{
    public class CommonArea : BaseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
