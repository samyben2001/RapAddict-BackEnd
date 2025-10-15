using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Videos
{
    public class AddArtistToAnalyseDto
    {
        [Required]
        public int AnalyseId { get; }

        [Required]
        public int ArtistId { get; }


        public AddArtistToAnalyseDto(int analyseId, int artistId)
        {
            AnalyseId = analyseId;
            ArtistId = artistId;
        }
    }
}
