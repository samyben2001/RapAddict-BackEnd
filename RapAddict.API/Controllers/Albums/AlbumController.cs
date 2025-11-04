using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Albums;
using RapAddict.Domain.Commands.Albums;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using RapAddict.Domain.Queries.Albums;
using RapAddict.Domain.Repositories.Albums;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Albums
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumService;

        public AlbumController(IAlbumRepository albumService)
        {
            _albumService = albumService;
        }

        [HttpPost]
        public IActionResult Create(CreateAlbumDto dto)
        {
            ICqsResult<int> result = _albumService.Execute(new CreateAlbumCommand(dto.Title, dto.ReleaseDate, dto.DurationMs, dto.CoverUrl));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = result.Data });
        }

        [HttpPost("{albumId}/StreamingPlatform")]
        public IActionResult AddStreamingPlatform([FromRoute] int albumId, [FromBody] AddStreamingPlatformToAlbumDto dto)
        {
            ICqsResult resultAlbum = _albumService.Execute(new AddStreamingPlatformToAlbumCommand(albumId, dto.StreamingPlatformId, dto.AlbumPlatformId));

            if (resultAlbum.IsFailure)
            {
                return BadRequest(resultAlbum);
            }

            return NoContent();
        }

        [HttpPost("{albumId}/Track")]
        public IActionResult AddTrack([FromRoute] int albumId, [FromBody] AddTrackToAlbumDto dto)
        {
            ICqsResult resultAlbum = _albumService.Execute(new AddTrackToAlbumCommand(albumId, dto.TrackId, dto.Position));

            if (resultAlbum.IsFailure)
            {
                return BadRequest(resultAlbum);
            }

            return NoContent();
        }

        [HttpGet()]
        public IActionResult GetAll([FromQuery] GetAlbumsDto dto)
        {
            ICqsResult<PagedList<Album>> result = _albumService.Execute(new GetAlbumsQuery(dto.Title, dto.Year, dto.Month, dto.Day, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{albumId}")]
        public IActionResult Get([FromRoute] int albumId)
        {
            ICqsResult<AlbumDetails> result = _albumService.Execute(new GetAlbumQuery(albumId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }
    }
}


