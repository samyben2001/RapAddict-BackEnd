using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos;
using RapAddict.API.Models.Dtos.Persons;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Entities.Videos;
using RapAddict.Domain.Queries.Persons;
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

        [HttpPost("{id}/Album")]
        public IActionResult AddAlbum([FromRoute] int id, [FromBody] AddAlbumToArtistDto dto)
        {
            ICqsResult result = _artistService.Execute(new AddAlbumToArtistCommand(id, dto.AlbumId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpPost("{id}/Track")]
        public IActionResult AddTrack([FromRoute] int id, [FromBody] AddTrackToArtistDto dto)
        {
            ICqsResult result = _artistService.Execute(new AddTrackToArtistCommand(id, dto.TrackId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }


        [HttpPost("{id}/StreamingPlatform")]
        public IActionResult AddStreamingPlatform([FromRoute] int id, [FromBody] AddPlatformToPersonDto dto)
        {
            ICqsResult result = _artistService.Execute(new AddStreamingPlatformToArtistCommand(id, dto.PlatformId, dto.PersonPlatformId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpGet()]
        public IActionResult GetAll([FromQuery] GetPersonsDto dto)
        {
            ICqsResult<PagedList<Artist>> result = _artistService.Execute(new GetArtistsQuery(dto.Pseudo, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            ICqsResult<ArtistDetails> result = _artistService.Execute(new GetArtistQuery(id));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}/Albums")]
        public IActionResult GetAlbums([FromRoute] int id, [FromQuery] PagedListDto dto)
        {
            ICqsResult<PagedList<Album>> result = _artistService.Execute(new GetArtistAlbumsQuery(id, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}/Tracks")]
        public IActionResult GetTracks([FromRoute] int id, [FromQuery] PagedListDto dto)
        {
            ICqsResult<PagedList<Track>> result = _artistService.Execute(new GetArtistTracksQuery(id, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}/Interviews")]
        public IActionResult GetInterviews([FromRoute] int id, [FromQuery] PagedListDto dto)
        {
            ICqsResult<PagedList<Interview>> result = _artistService.Execute(new GetArtistInterviewsQuery(id, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}/Freestyles")]
        public IActionResult GetFreestyles([FromRoute] int id, [FromQuery] PagedListDto dto)
        {
            ICqsResult<PagedList<Freestyle>> result = _artistService.Execute(new GetArtistFreestylesQuery(id, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}/Clips")]
        public IActionResult GetClips([FromRoute] int id, [FromQuery] PagedListDto dto)
        {
            ICqsResult<PagedList<Clip>> result = _artistService.Execute(new GetArtistClipsQuery(id, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}/Analyses")]
        public IActionResult GetAnalyses([FromRoute] int id, [FromQuery] PagedListDto dto)
        {
            ICqsResult<PagedList<Analyse>> result = _artistService.Execute(new GetArtistAnalysesQuery(id, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }
    }
}
