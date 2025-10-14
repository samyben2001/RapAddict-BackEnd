
namespace RapAddict.API.Models.Dtos
{
    public class CreateClipDto : CreateVideoDto
    {
        public int ArtistId { get; }


        public CreateClipDto(int artistId, string title, DateTime? releaseDate, string url, int? durationMs) : base(title, releaseDate, url, durationMs)
        {
            ArtistId = artistId;
        }
    }
}
