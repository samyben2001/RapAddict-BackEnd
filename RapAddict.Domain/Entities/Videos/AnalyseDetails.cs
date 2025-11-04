using RapAddict.Domain.Entities.Persons;
using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Videos
{
    public class AnalyseDetails : Analyse
    {
        [JsonPropertyOrder(90)]
        public List<Artist> AnalysedArtists { get; set; } = [];

        public AnalyseDetails(int id, ContentCreator contentCreator, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate) : base(id, contentCreator, title, releaseDate, durationMs, url, addedDate)
        {
        }

        public AnalyseDetails(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate, int ccId, string ccPseudo, DateTime ccAddedDate, string ccImageUrl) : base(id, title, releaseDate, durationMs, url, addedDate, ccId, ccPseudo, ccAddedDate, ccImageUrl)
        {
        }
    }
}
