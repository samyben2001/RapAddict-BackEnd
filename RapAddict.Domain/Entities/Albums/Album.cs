namespace RapAddict.Domain.Entities.Albums
{
    public class Album
    {
        public int Id { get; }
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public int? DurationMs { get; }
        public string? CoverUrl { get; }

        public Album(int id, string title, DateTime? releaseDate, int? durationMs, string? coverUrl)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
            CoverUrl = coverUrl;
        }
    }
}
