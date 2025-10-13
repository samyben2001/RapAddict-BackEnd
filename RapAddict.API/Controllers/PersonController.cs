using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos;
using RapAddict.Domain.Commands;
using RapAddict.Domain.Repositories;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers
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
            ICqsResult<int> result = _personService.Execute(new CreatePersonCommand(dto.Pseudo, dto.FirstName, dto.LastName));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = result.Data });
        }
    }
}
