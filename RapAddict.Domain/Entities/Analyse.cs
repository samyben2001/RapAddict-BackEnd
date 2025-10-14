
namespace RapAddict.Domain.Entities
{
    public class Analyse: Video
    {
        public int ContentCreatorId { get; }


        public Analyse(int id, int contentCreatorId, string title, DateTime? releaseDate, string url, int? durationMs) : base(id, title, releaseDate, url, durationMs)
        {
            ContentCreatorId = contentCreatorId;
        }
    }
}
