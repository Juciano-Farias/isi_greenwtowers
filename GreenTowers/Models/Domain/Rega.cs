using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTowers.Models.Domain
{
    public class Rega : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime InitialDate { get; set; }
        [Required]
        [StringLength(100)]
        public string? Temperature { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}