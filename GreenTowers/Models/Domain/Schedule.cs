using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenTowers.Models.Domain
{
    public class Schedule : BaseModel
    {
        public int Id { get; set; }


        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool Available { get; set; }
        [Required]
        public bool Canceled { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }


        [ForeignKey("CommonAreaId")]
        public int CommonAreaId { get; set; }
    }
}
