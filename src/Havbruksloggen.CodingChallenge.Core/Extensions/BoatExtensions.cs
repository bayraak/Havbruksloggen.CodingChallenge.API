using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Havbruksloggen.CodingChallenge.Core.Dtos;
using Havbruksloggen.CodingChallenge.Core.Models;

namespace Havbruksloggen.CodingChallenge.Core.Extensions
{
    internal static class BoatExtensions
    {
        public static BoatDto MapToDto(this Boat source)
        {
            return new BoatDto
            {
                Id = source.Id,
                Name = source.Name,
                Producer = source.Producer,
                BuildNumber = source.BuildNumber,
                LoA = source.LoA,
                B = source.B,
                ImageUrl = source.ImageUrl
            };
        }

        public static Boat ToBoat(this CreateBoatDto source)
        {
            return new Boat
            {
                Name = source.Name,
                Producer = source.Producer,
                BuildNumber = source.BuildNumber,
                LoA = source.LoA,
                B = source.B,
                UserId =  source.UserId,
                CrewMembers = source.CrewMembers.ToEntities(),
                ImageUrl = source.ImageUrl
            };
        }

        public static ICollection<CrewMember> ToEntities(this ICollection<CreateCrewMemberDto> source)
        {
            return source.Select(x => new CrewMember
            {
                Name = x.Name,
                Age = x.Age,
                CertifiedUntil = x.CertifiedUntil,
                CrewRole = x.CrewRole,
                Email = x.Email
            }).ToList();
        }

        public static ICollection<CreateCrewMemberDto> ToDto(this ICollection<CrewMember> source)
        {
            return source.Select(x => new CreateCrewMemberDto
            {
                Name = x.Name,
                Age = x.Age,
                CertifiedUntil = x.CertifiedUntil,
                CrewRole = x.CrewRole,
                Email = x.Email
            }).ToList();
        }

    }
}
