using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos
{
    public class CreateVideoDto
    {
        [Required]
        public string Title { get; }

        public DateTime? ReleaseDate { get; }

        [Required]
        public string Url { get; }
        public int? DurationMs { get; }

        public CreateVideoDto(string title, DateTime? releaseDate, string url, int? durationMs)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Url = url;
            DurationMs = durationMs == 0 ? null : durationMs;
        }
    }
}
