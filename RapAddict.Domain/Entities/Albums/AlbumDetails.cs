
using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Albums
{
    public class AlbumDetails : Album
    {
        [JsonPropertyOrder(99)]
        public List<Track> Tracks { get; set; } = [];

        [JsonPropertyOrder(100)]
        public List<AlbumStreamingPlatform> AlbumStreamingPlatforms { get; set; } = [];

        public AlbumDetails(int id, string title, DateTime? releaseDate, int? durationMs, string? coverUrl) : base(id, title, releaseDate, durationMs, coverUrl)
        {
        }
    }
}
