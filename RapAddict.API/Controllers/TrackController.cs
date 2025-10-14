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
