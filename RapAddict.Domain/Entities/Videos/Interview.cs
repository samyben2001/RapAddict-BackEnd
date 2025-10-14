namespace RapAddict.Domain.Entities.Videos
{
    public class Interview: Video
    {
        public int JournalistId { get; }


        public Interview(int id, string title, DateTime? releaseDate, string url, int? durationMs, int journalistId) : base(id, title, releaseDate, url, durationMs)
        {
            JournalistId = journalistId;
        }
    }
}
