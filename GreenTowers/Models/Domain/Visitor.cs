﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTowers.Models.Domain
{
    public class Visitor : BaseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime VisitDate { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User? User { get; set; }
    }

}
