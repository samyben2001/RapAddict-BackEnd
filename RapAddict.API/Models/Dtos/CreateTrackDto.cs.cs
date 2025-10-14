using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos
{
    public class CreateTrackDto
    {
        [Required]
        public string Title { get; }

        public DateTime? ReleaseDate { get; }
        public int? DurationMs { get; }

        public string? Lyrics { get; }

        public CreateTrackDto(string title, DateTime? releaseDate, int? durationMs, string? lyrics)
        {
            Title = title;
            ReleaseDate = releaseDate;
            DurationMs = durationMs == 0 ? null : durationMs;
            Lyrics = lyrics;
        }
    }
}
