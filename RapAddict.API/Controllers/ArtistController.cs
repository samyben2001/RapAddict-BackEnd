using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos;
using RapAddict.Domain.Commands;
using RapAddict.Domain.Repositories;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers
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
            ICqsResult<int> resultP = _personService.Execute(new CreatePersonCommand(dto.Pseudo, dto.FirstName, dto.LastName));
            if (resultP.IsFailure)
            {
                return BadRequest(resultP);
            }

            ICqsResult result = _artistService.Execute(new CreateArtistCommand(resultP.Data));
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = resultP.Data });
        }
    }
}
