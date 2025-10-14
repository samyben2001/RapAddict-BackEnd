namespace RapAddict.Domain.Entities.Videos
{
    public class Clip: Video
    {
        public int ArtistId { get; }


        public Clip(int id, int artistId, string title, DateTime? releaseDate, string url, int? durationMs) : base(id, title, releaseDate, url, durationMs)
        {
            ArtistId = artistId;
        }
    }
}
