using RapAddict.Domain.Entities.Persons;
using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Videos
{
    public class ClipDetails : Clip
    {
        [JsonPropertyOrder(90)]
        public List<Artist> ClippedArtists { get; set; } = [];

        public ClipDetails(int id, Artist artist, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate) : base(id, artist, title, releaseDate, durationMs, url, addedDate)
        {
        }

        public ClipDetails(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate, int aId, string aPseudo, DateTime aAddedDate, string aImageUrl) : base(id, title, releaseDate, durationMs, url, addedDate, aId, aPseudo, aAddedDate, aImageUrl)
        {
        }
    }
}
