using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Persons
{
    public class ArtistDetails: PersonDetails
    {
        [JsonPropertyOrder(90)]
        public List<ArtistStreamingPlatform> ArtistStreamingPlatforms { get; set; } = [];

        public ArtistDetails(int id, string pseudo, DateTime addedDate, string? firstName, string? lastName, string? imageUrl) : base(id, pseudo, addedDate, firstName, lastName, imageUrl)
        {
        }
    }
}
