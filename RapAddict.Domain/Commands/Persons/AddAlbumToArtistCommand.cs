using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class AddAlbumToArtistCommand : ICommandDefinition
    {
        public int ArtistId { get; }
        public int AlbumId { get; }

        public AddAlbumToArtistCommand(int artistId, int albumId)
        {
            ArtistId = artistId;
            AlbumId = albumId;
        }
    }
}
