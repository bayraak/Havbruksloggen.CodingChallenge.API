using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Havbruksloggen.CodingChallenge.Core;
using Havbruksloggen.CodingChallenge.Core.Entities;
using Havbruksloggen.CodingChallenge.Core.Repositories;
using Havbruksloggen.CodingChallenge.Core.Services;
using Havbruksloggen.CodingChallenge.Core.UnitTests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Havbruksloggen.CodingChallenge.Core.UnitTests.Services
{
    public class BoatServiceTests
    {
        private static readonly Fixture _fixture = new Fixture();

        private readonly BoatService _service;
        private readonly BoatRepository _mockRepo;

        public BoatServiceTests()
        {
            _service = new BoatService(_mockRepo);
        }

        [Theory, AutoData]
        public async Task GetAllSortedByPlateAsync_should_return_expected_result(int rand1, int rand2, int expectedId)
        {
            //given
            var Boats = new List<Boat>();
            _fixture.AddManyTo(Boats, rand1);
            Boats.Add(new Boat { Id = expectedId, Name = "SMTH" });
            _fixture.AddManyTo(Boats, rand2);

            //when
            var result = await _service.GetAllAsync(default, 1);

            //then
            result.First().Id.Should().Be(expectedId);
        }
    }
}
