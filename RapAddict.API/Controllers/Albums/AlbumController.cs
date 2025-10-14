using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Albums;
using RapAddict.Domain.Commands.Albums;
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
            ICqsResult<int> result = _albumService.Execute(new CreateAlbumCommand(dto.Title,dto.ReleaseDate,dto.DurationMs));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = result.Data });
        }
    }
}
