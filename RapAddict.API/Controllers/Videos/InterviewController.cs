using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Videos;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Videos
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IVideoRepository _videoService;
        private readonly IInterviewRepository _interviewService;

        public InterviewController(IInterviewRepository interviewService, IVideoRepository videoService)
        {
            _interviewService = interviewService;
            _videoService = videoService;
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateInterviewDto dto)
        {
            ICqsResult<int> resultP = _videoService.Execute(new CreateVideoCommand(dto.Title, dto.ReleaseDate, dto.Url, dto.DurationMs));
            if (resultP.IsFailure)
            {
                return BadRequest(resultP);
            }

            ICqsResult result = _interviewService.Execute(new CreateInterviewCommand(resultP.Data, dto.JournalistId));
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = resultP.Data });
        }
    }
}
