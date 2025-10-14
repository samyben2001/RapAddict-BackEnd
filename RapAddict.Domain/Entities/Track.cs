namespace RapAddict.Domain.Entities
{
    public class Track
    {
        public int Id { get; }
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public int? DurationMs { get; }
        public string? Lyrics { get; }

        public Track(int id, string title, DateTime? releaseDate, int? durationMs, string? lyrics)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
            Lyrics = lyrics;
        }
    }
}
