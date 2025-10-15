using System.ComponentModel.DataAnnotations;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Videos
{
    public class AddArtistToFreestyleCommand : ICommandDefinition
    {
        [Required]
        public int FreestyleId { get; }

        [Required]
        public int ArtistId { get; }


        public AddArtistToFreestyleCommand(int freestyleId, int artistId)
        {
            FreestyleId = freestyleId;
            ArtistId = artistId;
        }
    }
}
