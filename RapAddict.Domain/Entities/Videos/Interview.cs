using RapAddict.Domain.Entities.Persons;
using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Videos
{
    public class Interview: Video
    {
        [JsonPropertyOrder(90)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Journalist? Journalist { get; }



        public Interview(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate) : base(id, title, releaseDate, durationMs, url, addedDate)
        {
        }

        public Interview(int id, Journalist journalist, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate): base(id, title, releaseDate, durationMs, url, addedDate)
        {
            Journalist = journalist;
        }

        public Interview(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate, int jId, string jPseudo, DateTime jAddedDate, string jImageUrl) : base(id, title, releaseDate, durationMs, url, addedDate)
        {
            Journalist = new Journalist(jId, jPseudo, jAddedDate, jImageUrl);
        }
    }
}
