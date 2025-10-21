using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Persons
{
    public class AddTrackToArtistDto
    {
        [Required]
        public int TrackId { get; }

        public AddTrackToArtistDto(int trackId)
        {
            TrackId = trackId;
        }
    }
}
