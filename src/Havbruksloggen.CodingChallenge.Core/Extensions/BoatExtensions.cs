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
                B = source.B
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
                UserId =  source.UserId
            };
        }
    }
}
