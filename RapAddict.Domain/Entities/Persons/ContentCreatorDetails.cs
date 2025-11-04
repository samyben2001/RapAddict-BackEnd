using RapAddict.Domain.Entities.Videos;
using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Persons
{
    public class ContentCreatorDetails : PersonDetails
    {
        [JsonPropertyOrder(90)]
        public List<Analyse> Analyses { get; set; } = [];

        [JsonPropertyOrder(91)]
        public List<EntityPlatform> StreamingPlatforms { get; set; } = [];


        public ContentCreatorDetails(int id, string pseudo, DateTime addedDate, string? firstName, string? lastName, string? imageUrl) : base(id, pseudo, addedDate, firstName, lastName, imageUrl)
        {
        }
    }
}
