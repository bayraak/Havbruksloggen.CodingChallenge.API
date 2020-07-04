using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Havbruksloggen.CodingChallenge.Api.Controllers;
using Havbruksloggen.CodingChallenge.Api.UnitTests.Controllers;
using Havbruksloggen.CodingChallenge.Core.Dtos;
using Havbruksloggen.CodingChallenge.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Havbruksloggen.CodingChallenge.UnitTests.Controllers
{
    public class BoatsControllerTests : ControllerTestsBase<BoatsController>
    {
        private readonly Mock<IBoatService> _boatServiceMock;

        public BoatsControllerTests()
        {
            _boatServiceMock = Mocker.GetMock<IBoatService>();
        }

        [Fact]
        public async Task GetAll_should_call_GetAllSortedByPlateAsync_onto_service()
        {
            //when
            await Controller.GetAll(default);

            //then
            _boatServiceMock.Verify(x => x.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory, AutoData]
        public async Task GetAll_should_return_Ok_with_expected_result(IEnumerable<BoatDto> boats)
        {
            //given
            _boatServiceMock.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(boats);

            //when
            var result = await Controller.GetAll(default) as OkObjectResult;

            //then
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeAssignableTo<IEnumerable<BoatDto>>();
            var value = result.Value as IEnumerable<BoatDto>;
            value.Should().HaveCount(boats.Count());
        }
    }
}
