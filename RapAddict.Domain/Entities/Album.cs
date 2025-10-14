namespace RapAddict.Domain.Entities
{
    public class Album
    {
        public int Id { get; }
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public int? DurationMs { get; }

        public Album(int id, string title, DateTime? releaseDate, int? durationMs)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
        }
    }
}
