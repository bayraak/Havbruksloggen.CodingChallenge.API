using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Havbruksloggen.CodingChallenge.Core.Models
{
    [Table("boats")]
    public partial class Boat
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Producer { get; set; }

        public int? BuildNumber { get; set; }

        [Column(TypeName = "decimal(5, 2")]
        public decimal LoA { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal B { get; set; }

        public virtual ICollection<CrewMember> CrewMembers { get; set; } = new HashSet<CrewMember>();

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string ImageUrl { get; set; }
    }
}
