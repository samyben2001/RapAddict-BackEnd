using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Albums;
using RapAddict.API.Models.Dtos.Persons;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Queries.Albums;
using RapAddict.Domain.Queries.Persons;
using RapAddict.Domain.Repositories.Persons;
using RapAddict.Domain.Services.Albums;
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
            // Create PersonDetails in Database
            ICqsResult<int> resultPerson = _personService.Execute(new CreatePersonCommand(dto.Pseudo, dto.FirstName, dto.LastName, dto.ImageUrl));
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

        [HttpPost("{artistId}/Album")]
        public IActionResult AddAlbumToArtist([FromRoute] int artistId, [FromBody] AddAlbumToArtistDto dto)
        {
            ICqsResult result = _artistService.Execute(new AddAlbumToArtistCommand(artistId, dto.AlbumId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpPost("{artistId}/Track")]
        public IActionResult AddTrackoArtist([FromRoute] int artistId, [FromBody] AddTrackToArtistDto dto)
        {
            ICqsResult result = _artistService.Execute(new AddTrackToArtistCommand(artistId, dto.TrackId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpGet()]
        public IActionResult GetArtists([FromQuery] GetArtistsDto dto)
        {
            ICqsResult<PagedList<Artist>> result = _artistService.Execute(new GetArtistsQuery(dto.Pseudo, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{artistId}")]
        public IActionResult GetArtist([FromRoute] int artistId)
        {
            ICqsResult<ArtistDetails> result = _artistService.Execute(new GetArtistQuery(artistId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }
    }
}
