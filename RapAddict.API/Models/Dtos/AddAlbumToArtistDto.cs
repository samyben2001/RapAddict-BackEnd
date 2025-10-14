using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos
{
    public class AddAlbumToArtistDto
    {
        [Required]
        public int AlbumId { get; }

        public AddAlbumToArtistDto(int albumId)
        {
            AlbumId = albumId;
        }
    }
}
