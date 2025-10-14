using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos;
using RapAddict.Domain.Commands;
using RapAddict.Domain.Repositories;
using RapAddict.Domain.Services;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaRepository _socialMediaService;

        public SocialMediaController(ISocialMediaRepository socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpPost]
        public IActionResult Create(CreateSocialMediaDto dto)
        {
            ICqsResult<int> result = _socialMediaService.Execute(new CreateSocialMediaCommand(dto.Name));

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = result.Data });
        }
    }
}
