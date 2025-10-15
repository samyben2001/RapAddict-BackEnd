using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Videos;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using RapAddict.Domain.Services.Videos;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Videos
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

        [HttpPost("{clipId}/Artist")]
        public IActionResult AddArtist([FromRoute] int clipId, [FromBody] AddArtistToClipDto dto)
        {
            ICqsResult result = _clipService.Execute(new AddArtistToClipCommand(clipId, dto.ArtistId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }
    }
}
