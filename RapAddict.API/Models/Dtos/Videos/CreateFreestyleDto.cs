namespace RapAddict.API.Models.Dtos.Videos
{
    public class CreateFreestyleDto : CreateVideoDto
    {
        public CreateFreestyleDto(string title, DateTime? releaseDate, string url, int? durationMs) : base(title, releaseDate, url, durationMs)
        {
        }
    }
}
