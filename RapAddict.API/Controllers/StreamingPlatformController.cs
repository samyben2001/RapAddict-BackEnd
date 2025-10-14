using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos;
using RapAddict.Domain.Commands;
using RapAddict.Domain.Repositories;
using RapAddict.Domain.Services;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingPlatformController : ControllerBase
    {
        private readonly IStreamingPlatformRepository _streamingPlatformService;

        public StreamingPlatformController(IStreamingPlatformRepository streamingPlatformService)
        {
            _streamingPlatformService = streamingPlatformService;
        }

        [HttpPost]
        public IActionResult Create(CreateStreamingPlatformDto dto)
        {
            ICqsResult<int> result = _streamingPlatformService.Execute(new CreateStreamingPlatformCommand(dto.Name));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = result.Data });
        }
    }
}
