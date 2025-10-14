using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Videos;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Videos
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreestyleController : ControllerBase
    {
        private readonly IVideoRepository _videoService;
        private readonly IFreestyleRepository _freestyleService;

        public FreestyleController(IFreestyleRepository freestyleService, IVideoRepository videoService)
        {
            _freestyleService = freestyleService;
            _videoService = videoService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateFreestyleDto dto)
        {
            ICqsResult<int> resultP = _videoService.Execute(new CreateVideoCommand(dto.Title, dto.ReleaseDate, dto.Url, dto.DurationMs));
            if (resultP.IsFailure)
            {
                return BadRequest(resultP);
            }

            ICqsResult result = _freestyleService.Execute(new CreateFreestyleCommand(resultP.Data));
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = resultP.Data });
        }
    }
}
