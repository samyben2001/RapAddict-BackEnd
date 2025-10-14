using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Persons;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Persons
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IPersonRepository _personService;
        private readonly IArtistRepository _artistService;

        public ArtistController(IPersonRepository personService, IArtistRepository artistService)
        {
            _personService = personService;
            _artistService = artistService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateArtistDto dto)
        {
            // Create Person in Database
            ICqsResult<int> resultPerson = _personService.Execute(new CreatePersonCommand(dto.Pseudo, dto.FirstName, dto.LastName));
            if (resultPerson.IsFailure)
            {
                return BadRequest(resultPerson);
            }

            // Create Artist in Database
            ICqsResult resultArtist = _artistService.Execute(new CreateArtistCommand(resultPerson.Data));
            if (resultArtist.IsFailure)
            {
                return BadRequest(resultArtist);
            }

            // Add Albums to Artist in Database
            if (dto.AlbumsId is not null && dto.AlbumsId.Length > 0)
            {
                foreach (int albumId in dto.AlbumsId)
                {

                    ICqsResult resultAlbum = _artistService.Execute(new AddAlbumToArtistCommand(resultPerson.Data, albumId));

                    if (resultAlbum.IsFailure)
                    {
                        return BadRequest(resultAlbum);
                    }
                }
            }

            return Ok(new { id = resultPerson.Data });
        }

        [HttpPost("{artistId}/AddAlbum")]
        public IActionResult AddAlbumToArtist([FromRoute] int artistId,[FromBody] AddAlbumToArtistDto dto)
        {
            ICqsResult resultAlbum = _artistService.Execute(new AddAlbumToArtistCommand(artistId, dto.AlbumId));

            if (resultAlbum.IsFailure)
            {
                return BadRequest(resultAlbum);
            }

            return NoContent();
        }
    }
}
