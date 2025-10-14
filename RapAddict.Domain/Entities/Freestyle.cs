
namespace RapAddict.Domain.Entities
{
    public class Freestyle : Video
    {
        public Freestyle(int id, string title, DateTime? releaseDate, string url, int? durationMs) : base(id, title, releaseDate, url, durationMs)
        {
        }
    }
}
