namespace RapAddict.Domain.Entities.Videos
{
    public class Video
    {
        public int Id { get; }
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public string Url { get; }
        public int? DurationMs { get; }

        public Video(int id, string title, DateTime? releaseDate, string url, int? durationMs)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Url = url;
            DurationMs = durationMs;
        }
    }
}
