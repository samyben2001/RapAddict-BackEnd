using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Persons;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
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
            ICqsResult<int> resultP = _personService.Execute(new CreatePersonCommand(dto.Pseudo, dto.FirstName, dto.LastName));
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
    }
}
