using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Videos;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Videos;
using RapAddict.Domain.Queries.Videos;
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

        [HttpGet()]
        public IActionResult GetAll([FromQuery] GetVideosDto dto)
        {
            ICqsResult<PagedList<Clip>> result = _clipService.Execute(new GetClipsQuery(dto.Title, dto.Year, dto.Month, dto.Day, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }


        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            ICqsResult<ClipDetails> result = _clipService.Execute(new GetClipQuery(id));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }
    }
}
