namespace RapAddict.Domain.Entities.Videos
{
    public class Freestyle : Video
    {
        public Freestyle(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate) : base(id, title, releaseDate, durationMs, url, addedDate)
        {
        }
    }
}
