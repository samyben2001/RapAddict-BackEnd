using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Persons;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Queries.Persons;
using RapAddict.Domain.Repositories.Persons;
using RapAddict.Domain.Services.Persons;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Persons
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalistController : ControllerBase
    {
        private readonly IPersonRepository _personService;
        private readonly IJournalistRepository _journalistService;

        public JournalistController(IPersonRepository personService, IJournalistRepository journalistService)
        {
            _personService = personService;
            _journalistService = journalistService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateJournalistDto dto)
        {
            ICqsResult<int> resultP = _personService.Execute(new CreatePersonCommand(dto.Pseudo, dto.FirstName, dto.LastName, dto.ImageUrl));
            if (resultP.IsFailure)
            {
                return BadRequest(resultP);
            }

            ICqsResult result = _journalistService.Execute(new CreateJournalistCommand(resultP.Data));
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = resultP.Data });
        }


        [HttpPost("{id}/StreamingPlatform")]
        public IActionResult AddStreamingPlatform([FromRoute] int id, [FromBody] AddPlatformToPersonDto dto)
        {
            ICqsResult result = _journalistService.Execute(new AddStreamingPlatformToJournalistCommand(id, dto.PlatformId, dto.PersonPlatformId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpGet()]
        public IActionResult GetAll([FromQuery] GetPersonsDto dto)
        {
            ICqsResult<PagedList<Journalist>> result = _journalistService.Execute(new GetJournalistsQuery(dto.Pseudo, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            ICqsResult<JournalistDetails> result = _journalistService.Execute(new GetJournalistQuery(id));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }
    }
}
