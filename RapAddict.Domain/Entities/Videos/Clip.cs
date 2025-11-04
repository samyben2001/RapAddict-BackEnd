using RapAddict.Domain.Entities.Persons;
using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Videos
{
    public class Clip: Video
    {
        [JsonPropertyOrder(90)]
        public Artist Artist { get; }


        public Clip(int id, Artist artist, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate) : base(id, title, releaseDate, durationMs, url, addedDate)
        {
            Artist = artist;
        }

        public Clip(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate, int aId, string aPseudo, DateTime aAddedDate, string aImageUrl) : base(id, title, releaseDate, durationMs, url, addedDate)
        {
            Artist = new Artist(aId, aPseudo, aAddedDate, aImageUrl);
        }
    }
}
