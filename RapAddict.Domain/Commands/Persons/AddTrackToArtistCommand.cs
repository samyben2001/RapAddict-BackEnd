using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class AddTrackToArtistCommand : ICommandDefinition
    {
        public int ArtistId { get; }
        public int TrackId { get; }

        public AddTrackToArtistCommand(int artistId, int trackId)
        {
            ArtistId = artistId;
            TrackId = trackId;
        }
    }
}
