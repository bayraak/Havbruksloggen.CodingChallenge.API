using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Havbruksloggen.CodingChallenge.Core.Enumerations;

namespace Havbruksloggen.CodingChallenge.Core.Models
{
    [Table("crew_members")]
    public partial class CrewMember
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public CrewRole CrewRole { get; set; }

        public DateTime CertifiedUntil { get; set; }

        public int BoatId { get; set; }

        [ForeignKey("BoatId")]
        public virtual Boat Boat { get; set; }
    }
}
