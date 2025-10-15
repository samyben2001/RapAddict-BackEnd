using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Albums
{
    public class AddStreamingPlatformToAlbumCommand: ICommandDefinition
    {
        public int AlbumId { get; }
        public int StreamingPlatformId { get; }
        public string AlbumPlatformId { get; }


        public AddStreamingPlatformToAlbumCommand(int albumId, int streamingPlatformId, string albumPlatformId)
        {
            AlbumId = albumId;
            StreamingPlatformId = streamingPlatformId;
            AlbumPlatformId = albumPlatformId;
        }
    }
}
