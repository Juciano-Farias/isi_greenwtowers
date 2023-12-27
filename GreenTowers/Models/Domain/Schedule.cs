using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenTowers.Models.Domain
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey ("CommonAreaId")]
        public int CommonAreaId { get; set; }
        public CommonArea CommonArea { get; set; }
    }
}
