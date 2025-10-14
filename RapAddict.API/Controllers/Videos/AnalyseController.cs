using Microsoft.AspNetCore.Mvc;
using RapAddict.API.Models.Dtos.Videos;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using Tools.Cqs.Results;

namespace RapAddict.API.Controllers.Videos
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyseController : ControllerBase
    {
        private readonly IVideoRepository _videoService;
        private readonly IAnalyseRepository _analyseService;

        public AnalyseController(IAnalyseRepository analyseService, IVideoRepository videoService)
        {
            _analyseService = analyseService;
            _videoService = videoService;
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateAnalyseDto dto)
        {
            ICqsResult<int> resultP = _videoService.Execute(new CreateVideoCommand(dto.Title, dto.ReleaseDate, dto.Url, dto.DurationMs));
            if (resultP.IsFailure)
            {
                return BadRequest(resultP);
            }

            ICqsResult result = _analyseService.Execute(new CreateAnalyseCommand(resultP.Data, dto.ContentCreatorId));
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(new { id = resultP.Data });
        }
    }
}
