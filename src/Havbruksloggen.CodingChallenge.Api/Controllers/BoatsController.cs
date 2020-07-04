using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Havbruksloggen.CodingChallenge.Core.Dtos;
using Havbruksloggen.CodingChallenge.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Havbruksloggen.CodingChallenge.Api.Controllers
{
    [Route("api/boats")]
    [Authorize]
    public class BoatsController : ApiControllerBase
    {
        private readonly IBoatService _boatService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BoatsController(IBoatService boatService, IHttpContextAccessor httpContextAccessor)
        {
            _boatService = boatService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BoatDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken = default)
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value);

            var result = await _boatService.GetAllAsync(cancellationToken, userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBoatDto createBoatDto, CancellationToken cancellationToken = default)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            createBoatDto.UserId = int.Parse(userId);

            await _boatService.Create(createBoatDto);
            return Ok();
        }
    }
}
