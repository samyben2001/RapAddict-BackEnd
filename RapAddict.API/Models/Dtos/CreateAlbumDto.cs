using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos
{
    public class CreateAlbumDto
    {
        [Required]
        public string Title { get; }

        public DateTime? ReleaseDate { get; }
        public int? DurationMs { get; }

        public CreateAlbumDto(string title, DateTime? releaseDate, int? durationMs)
        {
            Title = title;
            ReleaseDate = releaseDate;
            DurationMs = durationMs == 0 ? null : durationMs;
        }
    }
}
