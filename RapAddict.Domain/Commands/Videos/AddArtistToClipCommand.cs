using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Videos
{
    public class AddArtistToClipCommand : ICommandDefinition
    {
        public int ClipId { get; }
        public int ArtistId { get; }


        public AddArtistToClipCommand(int clpiId, int artistId)
        {
            ClipId = clpiId;
            ArtistId = artistId;
        }
    }
}
