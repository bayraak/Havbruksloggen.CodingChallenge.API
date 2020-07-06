using System;
using System.Collections.Generic;
using Havbruksloggen.CodingChallenge.Core;
using Havbruksloggen.CodingChallenge.Core.Entities;

namespace Havbruksloggen.CodingChallenge.Api.IntegrationTests.Infrastructure
{
    public class BoatsContextDataFeeder
    {
        public static void Feed(ApplicationDbContext dbContext)
        {
            var owner1 = new CrewMember
            {
                Name = "Dom",
                Email = "Cobb@example.com",
            };
            dbContext.Owners.Add(owner1);

            var boat1 = new Boat
            {
                Name = "DW 12345",
                BuildNumber = 3,
                LoA = 3.3M,
                B = 2.2M,
                CrewMembers = new List<CrewMember> { owner1 },
            };
            dbContext.Boats.Add(boat1);

            dbContext.SaveChanges();
        }
    }
}
