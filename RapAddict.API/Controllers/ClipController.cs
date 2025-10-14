using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClipController : ControllerBase
    {
        private readonly IVideoRepository _videoService;
        private readonly IClipRepository _clipService;

        public ClipController(IClipRepository clipService, IVideoRepository videoService)
        {
            _clipService = clipService;
            _videoService = videoService;
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateClipDto dto)
        {
            ICqsResult<int> resultP = _videoService.Execute(new CreateVideoCommand(dto.Title, dto.ReleaseDate, dto.Url, dto.DurationMs));
            if (resultP.IsFailure)
            {
                return BadRequest(resultP);
            }

            ICqsResult result = _clipService.Execute(new CreateClipCommand(resultP.Data, dto.ArtistId));
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = resultP.Data });
        }
    }
}
