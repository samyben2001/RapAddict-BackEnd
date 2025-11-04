using RapAddict.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Videos
{
    public class Analyse: Video
    {
        [JsonPropertyOrder(90)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ContentCreator? ContentCreator { get; }

        public Analyse(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate) : base(id, title, releaseDate, durationMs, url, addedDate)
        {
        }


        public Analyse(int id, ContentCreator contentCreator, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate) : base(id, title, releaseDate, durationMs, url, addedDate)
        {
            ContentCreator = contentCreator;
        }

        public Analyse(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate, int ccId, string ccPseudo, DateTime ccAddedDate, string ccImageUrl) : base(id, title, releaseDate, durationMs, url, addedDate)
        {
            ContentCreator = new ContentCreator(ccId, ccPseudo, ccAddedDate, ccImageUrl);
        }
    }
}
