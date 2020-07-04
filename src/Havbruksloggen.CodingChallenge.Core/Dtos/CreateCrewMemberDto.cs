using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Havbruksloggen.CodingChallenge.Core.Enumerations;

namespace Havbruksloggen.CodingChallenge.Core.Dtos
{
    public class CreateCrewMemberDto
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public CrewRole CrewRole { get; set; }

        public DateTime CertifiedUntil { get; set; }
    }
}
