using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Infrastructure.Token;
using RapAddict.API.Models.Dtos.Auth;
using RapAddict.Domain.Commands.Auth;
using RapAddict.Domain.Entities.Users;
using RapAddict.Domain.Queries.Auth;
using RapAddict.Domain.Repositories.Auth;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _userService;
        private readonly ITokenRepository _tokenService;

        public AuthController(IAuthRepository userService, ITokenRepository tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            ICqsResult<int> result = _userService.Execute(new RegisterCommand(dto.Username, dto.Email, dto.Password, dto.FirstName, dto.LastName));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = result.Data });
        }



        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            ICqsResult<User> result = _userService.Execute(new LoginQuery(dto.Login, dto.Password));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(_tokenService.GenerateToken(result.Data));
        }
    }
}
