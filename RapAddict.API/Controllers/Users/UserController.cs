using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Infrastructure.Token;
using RapAddict.API.Models.Dtos.Users;
using RapAddict.Domain.Commands.Users;
using RapAddict.Domain.Repositories.Users;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly ITokenRepository _tokenService;

        public UserController(IUserRepository userService, ITokenRepository tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto dto)
        {
            ICqsResult<int> result = _userService.Execute(new CreateUserCommand(dto.Username, dto.Email, dto.Password, dto.FirstName, dto.LastName));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = result.Data });
        }
    }
}
