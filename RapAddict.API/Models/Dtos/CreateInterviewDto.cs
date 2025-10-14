
namespace RapAddict.API.Models.Dtos
{
    public class CreateInterviewDto : CreateVideoDto
    {
        public int JournalistId { get; }

        public CreateInterviewDto(int journalistId, string title, DateTime? releaseDate, string url, int? durationMs) : base(title, releaseDate, url, durationMs)
        {
            JournalistId = journalistId;
        }
    }
}
