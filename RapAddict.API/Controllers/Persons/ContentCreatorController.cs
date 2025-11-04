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
    public class ContentCreatorController : ControllerBase
    {
        private readonly IPersonRepository _personService;
        private readonly IContentCreatorRepository _contentCreatorService;

        public ContentCreatorController(IPersonRepository personService, IContentCreatorRepository contentCreatorService)
        {
            _personService = personService;
            _contentCreatorService = contentCreatorService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateContentCreatorDto dto)
        {
            ICqsResult<int> resultP = _personService.Execute(new CreatePersonCommand(dto.Pseudo, dto.FirstName, dto.LastName, dto.ImageUrl));
            if (resultP.IsFailure)
            {
                return BadRequest(resultP);
            }

            ICqsResult result = _contentCreatorService.Execute(new CreateContentCreatorCommand(resultP.Data));
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = resultP.Data });
        }


        [HttpPost("{id}/StreamingPlatform")]
        public IActionResult AddStreamingPlatform([FromRoute] int id, [FromBody] AddPlatformToPersonDto dto)
        {
            ICqsResult result = _contentCreatorService.Execute(new AddStreamingPlatformToContentCreatorCommand(id, dto.PlatformId, dto.PersonPlatformId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpGet()]
        public IActionResult GetAll([FromQuery] GetPersonsDto dto)
        {
            ICqsResult<PagedList<ContentCreator>> result = _contentCreatorService.Execute(new GetContentCreatorsQuery(dto.Pseudo, dto.PageNumber, dto.PageSize));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            ICqsResult<ContentCreatorDetails> result = _contentCreatorService.Execute(new GetContentCreatorQuery(id));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }
    }
}
