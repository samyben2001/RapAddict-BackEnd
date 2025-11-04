using RapAddict.Domain.Entities.Persons;
using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Videos
{
    public class InterviewDetails : Interview
    {
        [JsonPropertyOrder(90)]
        public List<Artist> InterviewedArtists { get; set; } = [];

        public InterviewDetails(int id, Journalist journalist, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate) : base(id, journalist, title, releaseDate, durationMs, url, addedDate)
        {
        }

        public InterviewDetails(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate, int jId, string jPseudo, DateTime jAddedDate, string jImageUrl) : base(id, title, releaseDate, durationMs, url, addedDate, jId, jPseudo, jAddedDate, jImageUrl)
        {
        }
    }
}
