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
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json;

namespace Havbruksloggen.CodingChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BoatsController : ApiControllerBase
    {
        private readonly IBoatService _boatService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;


        public BoatsController(IBoatService boatService, IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _boatService = boatService;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;

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
        public async Task<IActionResult> Create([FromForm] IFormFile file, [FromForm] string jsonString)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var createBoatDto = JsonConvert.DeserializeObject<CreateBoatDto>(jsonString);

            createBoatDto.UserId = int.Parse(userId);

            if (!(file is null))
            {
                var imageUrl = await GetUploadedFileUrl(file);
                createBoatDto.ImageUrl = imageUrl;
            }

            await _boatService.Create(createBoatDto);
            return Ok();
        }

        private async Task<string> GetUploadedFileUrl(IFormFile file)
        {
            var storageConnectionString = _configuration["ConnectionStrings:AzureStorageConnectionString"];

            if (!CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount)
            ) return "";

            var blobClient = storageAccount.CreateCloudBlobClient();

            var container = blobClient.GetContainerReference("profilepic");

            await container.CreateIfNotExistsAsync();

            var picBlob = container.GetBlockBlobReference(file.FileName);

            await picBlob.UploadFromStreamAsync(file.OpenReadStream());

            return picBlob.Uri.AbsoluteUri;

        }
    }
}
