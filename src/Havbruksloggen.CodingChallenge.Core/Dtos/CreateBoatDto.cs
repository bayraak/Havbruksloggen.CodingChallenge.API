using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Havbruksloggen.CodingChallenge.Core.Dtos
{
    public class CreateBoatDto
    {
        public string Producer { get; set; }

        public string Name { get; set; }

        public int? BuildNumber { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
        public decimal LoA { get; set; }
        public decimal B { get; set; }
        public ICollection<CreateCrewMemberDto> CrewMembers { get; set; }
    }
}
