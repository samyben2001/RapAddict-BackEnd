namespace RapAddict.Domain.Entities.Albums
{
    public class Track
    {
        public int Id { get; }
        public string Title { get; }
        public int? Position { get; }
        public DateTime? ReleaseDate { get; }
        public int? DurationMs { get; }
        public string? Lyrics { get; }
        public int? ClipId { get; }

        public Track() { }

        public Track(int id, string title, int? position, DateTime? releaseDate, int? durationMs, string? lyrics, int? clipId)
        {
            Id = id;
            Title = title;
            Position = position;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
            Lyrics = lyrics;
            ClipId = clipId;
        }
    }
}
