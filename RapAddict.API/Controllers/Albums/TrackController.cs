using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Albums;
using RapAddict.Domain.Commands.Albums;
using RapAddict.Domain.Repositories.Albums;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Albums
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackRepository _trackService;

        public TrackController(ITrackRepository trackService)
        {
            _trackService = trackService;
        }

        [HttpPost]
        public IActionResult Create(CreateTrackDto dto)
        {
            ICqsResult<int> result = _trackService.Execute(new CreateTrackCommand(dto.Title, dto.ReleaseDate, dto.DurationMs, dto.Lyrics));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = result.Data });
        }
    }
}
