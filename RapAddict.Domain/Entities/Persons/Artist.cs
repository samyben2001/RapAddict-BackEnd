using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Persons
{
    public class Artist : Person
    {
        [JsonPropertyOrder(90)]
        public List<ArtistStreamingPlatform> ArtistStreamingPlatforms { get; set; } = [];

        public Artist(int id, string pseudo, string? firstName, string? lastName, string? imageUrl) : base(id, pseudo, firstName, lastName, imageUrl)
        {
        }
    }
}
