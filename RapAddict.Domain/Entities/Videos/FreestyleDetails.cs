
using RapAddict.Domain.Entities.Persons;
using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Videos
{
    public class FreestyleDetails : Freestyle
    {
        [JsonPropertyOrder(90)]
        public List<Artist> Freestylers { get; set; } = [];
        public FreestyleDetails(int id, string title, DateTime? releaseDate, int? durationMs, string url, DateTime addedDate) : base(id, title, releaseDate, durationMs, url, addedDate)
        {
        }
    }
}
