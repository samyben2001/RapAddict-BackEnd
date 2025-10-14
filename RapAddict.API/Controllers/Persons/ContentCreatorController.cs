using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Persons;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
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
            ICqsResult<int> resultP = _personService.Execute(new CreatePersonCommand(dto.Pseudo, dto.FirstName, dto.LastName));
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
    }
}
