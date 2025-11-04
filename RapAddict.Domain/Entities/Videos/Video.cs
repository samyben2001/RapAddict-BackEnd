namespace RapAddict.Domain.Entities.Videos
{
    public class Video
    {
        public int Id { get; }
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public int? DurationMs { get; }
        public string Url { get; }
        public DateTime AddedDate { get; }

        public Video(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
            Url = url;
            AddedDate = addedDate;
        }
    }
}
