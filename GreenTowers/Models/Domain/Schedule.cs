using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenTowers.Models.Domain
{
    public class Schedule : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }


        [ForeignKey("CommonAreaId")]
        public int CommonAreaId { get; set; }
    }
}
