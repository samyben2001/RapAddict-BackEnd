using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Persons
{
    public class AddTrackToArtistDto
    {
        [Required]
        public int ArtistId { get; }

        [Required]
        public int TrackId { get; }

        public AddTrackToArtistDto(int artistId, int trackId)
        {
            ArtistId = artistId;
            TrackId = trackId;
        }
    }
}
