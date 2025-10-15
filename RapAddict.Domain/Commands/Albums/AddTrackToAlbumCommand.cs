using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Albums
{
    public class AddTrackToAlbumCommand: ICommandDefinition
    {
        public int AlbumId { get; }
        public int TrackId { get; }
        public int Position { get; }

        public AddTrackToAlbumCommand(int albumId, int trackId, int position)
        {
            AlbumId = albumId;
            TrackId = trackId;
            Position = position;
        }
    }
}
