using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Albums
{
    public class Album
    {
        [JsonPropertyOrder(0)]
        public int Id { get; }
        [JsonPropertyOrder(1)]
        public string Title { get; }
        [JsonPropertyOrder(2)]
        public DateTime? ReleaseDate { get; }
        [JsonPropertyOrder(3)]
        public int? DurationMs { get; }
        [JsonPropertyOrder(4)]
        public string? CoverUrl { get; }

        public Album(int id, string title, DateTime? releaseDate, int? durationMs, string? coverUrl)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
            CoverUrl = coverUrl;
        }
    }
}
