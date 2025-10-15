using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Videos
{
    public class AddArtistToClipDto
    {
        [Required]
        public int ClipId { get; }

        [Required]
        public int ArtistId { get; }


        public AddArtistToClipDto(int clpiId, int artistId)
        {
            ClipId = clpiId;
            ArtistId = artistId;
        }
    }
}
