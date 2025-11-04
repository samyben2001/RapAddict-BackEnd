using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Persons;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Persons
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personService;

        public PersonController(IPersonRepository personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public IActionResult Create(CreatePersonDto dto)
        {
            ICqsResult<int> result = _personService.Execute(new CreatePersonCommand(dto.Pseudo, dto.FirstName, dto.LastName, dto.ImageUrl));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = result.Data });
        }

        [HttpPost("{personId}/SocialMedia")]
        public IActionResult AddSocialMedia([FromRoute] int personId, [FromBody] AddPlatformToPersonDto dto)
        {
            ICqsResult result = _personService.Execute(new AddSocialMediaToPersonCommand(personId, dto.PlatformId, dto.PersonPlatformId));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

    }
}
