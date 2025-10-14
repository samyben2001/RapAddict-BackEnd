namespace RapAddict.API.Models.Dtos.Videos
{
    public class CreateAnalyseDto : CreateVideoDto
    {
        public int ContentCreatorId { get; }


        public CreateAnalyseDto(int contentCreatorId, string title, DateTime? releaseDate, string url, int? durationMs) : base(title, releaseDate, url, durationMs)
        {
            ContentCreatorId = contentCreatorId;
        }
    }
}
