
namespace RapAddict.Domain.Entities.Albums
{
    public class AlbumDetails : Album
    {
        public string? StreamingPlatform { get; }
        public string? StreamingPlatformId { get; }
        public List<Track> Tracks { get; set; } = new List<Track> { };

        public AlbumDetails(int id, string title, DateTime? releaseDate, int? durationMs, string? coverUrl, string? streamingPlatform, string? streamingPlatformId) : base(id, title, releaseDate, durationMs, coverUrl)
        {
            StreamingPlatform = streamingPlatform;
            StreamingPlatformId = streamingPlatformId;
        }
    }
}
